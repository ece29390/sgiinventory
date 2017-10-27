using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Presenters;
using SGInventory.Views;
using SGInventory.Model;
using SGInventory.Enums;
using SGInventory.CustomEventArgs;

namespace SGInventory.Delivery
{
    public partial class SupplierDeliveryEditForm : Form, ISupplierDeliveryEditView
    {
        private IList<DeliveryDetail> _deliveryDetails;
        private BusinessModelContainer _container;
        private SupplierDeliveryEditPresenter _presenter;
        private IList<DeliveryDetail> iList;
        public event EventHandler<ModelEventArgs<SGInventory.Model.Delivery>> OnDeactivateDeliveryDetail;
        public event EventHandler<UpdateDeliveryDetailArgs> OnUpdateDeliveryDetail;
        private bool _isEditMode;
               
        public SupplierDeliveryEditForm(IList<DeliveryDetail> deliveryDetails, BusinessModelContainer container,bool isEditMode)
        {
            InitializeComponent();
            _deliveryDetails = deliveryDetails;
            _container = container;
            dgvProductDetails.AutoGenerateColumns = false;
            _presenter = new SupplierDeliveryEditPresenter(this, _container.DeliveryBusinessModel);
            _isEditMode = isEditMode;
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            ucItemEditMenu1.OnCancelToolStripMenuItem += new EventHandler(ucItemEditMenu1_OnCancelToolStripMenuItem);
            ucItemEditMenu1.OnDeleteToolStripMenuItem += new EventHandler(ucItemEditMenu1_OnDeleteToolStripMenuItem);
            ucItemEditMenu1.OnUpdateToolStripMenuItem += new EventHandler(ucItemEditMenu1_OnUpdateToolStripMenuItem);
        }

        void ucItemEditMenu1_OnUpdateToolStripMenuItem(object sender, EventArgs e)
        {
            updateToolStripMenuItem_Click(sender, e);
        }

        void ucItemEditMenu1_OnDeleteToolStripMenuItem(object sender, EventArgs e)
        {
            deleteToolStripMenuItem_Click(sender, e);
        }

        void ucItemEditMenu1_OnCancelToolStripMenuItem(object sender, EventArgs e)
        {
            cancelToolStripMenuItem_Click(sender, e);
        }
              
        private void SupplierDeliveryEditForm_Load(object sender, EventArgs e)
        {            
            _presenter
                .LoadStatus()
                .LoadDamageList()
                .LoadDeliveryDistinctDetails(_deliveryDetails)               
                .ToDataGridView(dgvProductDetails);
        }

        private void dgvProductDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var deliveryDetail = (DeliveryDetail)dgvProductDetails.Rows[e.RowIndex].DataBoundItem;
                
                deliveryDetail.ProductDetail = _container.ProductDetailBusinessModel.SelectByPrimaryId(deliveryDetail.ProductDetail.Code);
                
                _presenter.LoadDeliveryDetailBy(deliveryDetail);
            }
        }

        private void dgvProductDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dgvProductDetails.Rows.Count; i++)
            {
                var deliveryDetail = (DeliveryDetail)dgvProductDetails.Rows[i].DataBoundItem;
                dgvProductDetails.Rows[i].Cells["colProductDetail"].Value = deliveryDetail.ProductDetail.Code;
                dgvProductDetails.Rows[i].Cells["colStatus"].Value = Enum.GetName(typeof(ProductStatus), deliveryDetail.Status);
            }
        }

        public void DisplayDeliveryDetail(DeliveryDetail deliveryDetail)
        {
            lblBarcodeNumber.Text = deliveryDetail.ProductDetail.Code;
            txtBoxQuantity.Text = deliveryDetail.Quantity.ToString();
            txtBoxRemarks.Text = deliveryDetail.Remarks;
            ncPrice.Numeric = deliveryDetail.Price;
            ucStatus1.LoadDeliveryDetail(deliveryDetail);
            panel2.Enabled = true;
        }

        public void DisplayProductStausList(List<ProductStatus> listOfProductStatus)
        {
            ucStatus1.LoadProductStatus(listOfProductStatus);
        }

        public void DisplayDamageList(List<Damage> listOfDamages)
        {
            ucStatus1.LoadDamageList(listOfDamages);
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.CancelEdit();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var isValid = _presenter.CheckIfStatusAndProductDetailCodeAlreadyExists(dgvProductDetails);

            if (!isValid)
            {
                ShowMessage("Item with same barcode and status already exists!");
                return;
            }

            string updateMessage = _presenter.SaveUpdate();

            if (_isEditMode)
            {
                var delivery = _container.DeliveryBusinessModel.SelectByPrimaryId(_deliveryDetails.First().Delivery.Id);
                _deliveryDetails = delivery.DeliveryDetails;                
            }

            if (!string.IsNullOrEmpty(updateMessage))
            {
                MessageBox.Show(updateMessage);
            }

            if (OnUpdateDeliveryDetail != null)
            {
                OnUpdateDeliveryDetail(sender, new UpdateDeliveryDetailArgs(_presenter.PreviousSelectedDeliveryDetail, _presenter.SelectedDeliveryDetail));
            }

            _presenter
                .LoadStatus()
                .LoadDamageList()
                .LoadDeliveryDistinctDetails(_deliveryDetails)
                .ToDataGridView(dgvProductDetails);

        }
                
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_isEditMode)
            {
                int? index = null;

                for (var i = 0; i < _deliveryDetails.Count; i++)
                {
                    if (_presenter.SelectedDeliveryDetail.Damage.HasValue
                        && _deliveryDetails[i].Damage.HasValue)
                    {
                        if (_deliveryDetails[i].ProductDetail.Code ==
                        _presenter.SelectedDeliveryDetail.ProductDetail.Code
                        && _deliveryDetails[i].Status ==
                        _presenter.SelectedDeliveryDetail.Status
                         && _deliveryDetails[i].Damage.Value == _presenter.SelectedDeliveryDetail.Damage.Value                        
                            )
                        {
                            index = i;
                            break;
                        }
                     
                    }
                    else
                    {
                        if (_deliveryDetails[i].ProductDetail.Code ==
                        _presenter.SelectedDeliveryDetail.ProductDetail.Code
                        && _deliveryDetails[i].Status ==
                        _presenter.SelectedDeliveryDetail.Status
                        )
                        {
                            index = i;
                            break;
                        }
                    }
                    
                }

                if (index.HasValue)
                {
                    _deliveryDetails.RemoveAt(index.Value);
                    _presenter.ToDataGridView(dgvProductDetails, _deliveryDetails);
                    RefreshControls();
                    if (_deliveryDetails.Count == 0)
                    {
                        this.Close();
                    }
                }
            }
            else
            {
                _presenter.DeActivateDeliveryDetail().ToDataGridView(dgvProductDetails);
            }
            
            if (OnDeactivateDeliveryDetail != null)
            {
                OnDeactivateDeliveryDetail(sender, new ModelEventArgs<SGInventory.Model.Delivery>(_presenter.SelectedDeliveryDetail.Delivery));
            }
        }

        public void RefreshControls()
        {
            lblBarcodeNumber.Text = "";
            txtBoxQuantity.Clear();
            txtBoxRemarks.Clear();
            ncPrice.Numeric = 0;
            panel2.Enabled = false;
        }

        public int GetQuantity()
        {
            return Convert.ToInt32(txtBoxQuantity.Text);
        }

        public string GetRemarks()
        {
            return txtBoxRemarks.Text.Trim();
        }

        public void SetStatusToDeliveryDetail(DeliveryDetail selectedDeliveryDetail)
        {
            ucStatus1.SetToDeliveryDetail(selectedDeliveryDetail);
        }

        public string GetBarcode()
        {
            return lblBarcodeNumber.Text.Trim();
        }

        public ProductStatus GetProductStatus()
        {
            var productStatus = ucStatus1.ProductStatus;
            return productStatus;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void EnableDelete(bool enable)
        {            
            ucItemEditMenu1.EnableDeleteMenuItem(enable);
        }

        public int? GetDamageStatus()
        {
            return ucStatus1.DamageStatus;
        }

        private void txtBoxQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                return;
            }

            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
