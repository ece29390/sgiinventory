using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Views;
using SGInventory.Model;
using SGInventory.Presenters;

namespace SGInventory.Delivery
{
    public partial class DeliveryToOutletEditForm : Form,IDeliveryToOutletEditView
    {
        private int _deliveryDetailToOutletId;
        private DeliveryToOutletDetailEditPresenter _presenter;
        private DeliveryToOutlet _deliveryToOutlet;

        public event EventHandler OnUpdateDeliveryDetail,
                                  OnDeactivateDeliveryDetail;

        public DeliveryToOutletEditForm(
            BusinessModelContainer container           
            , DeliveryToOutlet deliveryToOutlet
            )
        {
            InitializeComponent();
            _deliveryDetailToOutletId = deliveryToOutlet.Id;
            dgvProductDetails.AutoGenerateColumns = false;
            _presenter = new DeliveryToOutletDetailEditPresenter(this, container.DeliveryToOutletBusinessModel,container.DeliveryBusinessModelHelper);
            InitializeEvents();
            _deliveryToOutlet = deliveryToOutlet;
        }

        private void InitializeEvents()
        {
            ucItemEditMenu1.OnCancelToolStripMenuItem += new EventHandler(ucItemEditMenu1_OnCancelToolStripMenuItem);
            ucItemEditMenu1.OnDeleteToolStripMenuItem += new EventHandler(ucItemEditMenu1_OnDeleteToolStripMenuItem);
            ucItemEditMenu1.OnUpdateToolStripMenuItem += new EventHandler(ucItemEditMenu1_OnUpdateToolStripMenuItem);
        }

        void ucItemEditMenu1_OnUpdateToolStripMenuItem(object sender, EventArgs e)
        {
            _presenter.SaveDeliveryToOutletDetail();
            
            if (OnUpdateDeliveryDetail != null)
            {
                OnUpdateDeliveryDetail(sender, e);
            }
        }

        void ucItemEditMenu1_OnDeleteToolStripMenuItem(object sender, EventArgs e)
        {
            _presenter.DeactivateDeliveryToOutletDetail();

            if (OnDeactivateDeliveryDetail != null)
            {
                OnDeactivateDeliveryDetail(sender, e);
            }
        }

        void ucItemEditMenu1_OnCancelToolStripMenuItem(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void DeliveryToOutletEditForm_Load(object sender, EventArgs e)
        {
            _presenter.LoadDeliveryToOutlet(_deliveryToOutlet);
        }

        public void DisplayDeliveryDetail(Model.DeliveryToOutletDetail deliveryDetail)
        {
            txtBoxQuantity.Text = deliveryDetail.Quantity.ToString();
            txtBoxRemarks.Text = deliveryDetail.Remarks;
            ncPrice.Numeric = deliveryDetail.SuggestedRetailPrice;
            lblBarcodeNumber.Text = deliveryDetail.ProductDetail.Code;
            panel2.Enabled = true;
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
            return Convert.ToInt32(txtBoxQuantity.Text.Trim());
        }

        public string GetRemarks()
        {
            return txtBoxRemarks.Text.Trim();
        }

        public string GetBarcode()
        {
            return lblBarcodeNumber.Text.Trim();
        }

        public void EnableDelete(bool enable)
        {
            ucItemEditMenu1.EnableDeleteMenuItem(enable);
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

        public void LoadDisplayDeliveryDetailList(IList<DeliveryToOutletDetail> list)
        {
            dgvProductDetails.Refresh();
            dgvProductDetails.DataSource = list;           
        }

        private void dgvProductDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 0)
            {
                var selectedDeliveryToOutletDetail = (DeliveryToOutletDetail)dgvProductDetails.Rows[e.RowIndex].DataBoundItem;
                _presenter.LoadDeliveryToOutletDetail(selectedDeliveryToOutletDetail);
            }
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void dgvProductDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvProductDetails.Rows)
            {
                var deliveryToOutletDetail = (DeliveryToOutletDetail)row.DataBoundItem;
                row.Cells["colProductDetail"].Value = deliveryToOutletDetail.ProductDetail.Code;
            }
        }
    }
}
