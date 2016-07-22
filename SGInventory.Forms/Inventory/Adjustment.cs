using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Model;
using SGInventory.Enums;
using SGInventory.Helpers;

namespace SGInventory.Inventory
{
    public partial class Adjustment : Form
    {
        public event EventHandler OnSave;
        public event EventHandler OnDelete;

        private string _productDetailCode;
        private BusinessModelContainer _container;
        private DeliveryDetail _deliveryDetail;
        private DeliveryToOutletDetail _deliveryToOutletDetail;

        private bool _isDeliveryComing;

        public Adjustment(string productDetailCode
            , BusinessModelContainer container)
        {
            InitializeComponent();
            _productDetailCode = productDetailCode;
            _container = container;
        }

        public Adjustment AttachId(int id)
        {
            EntityId = id;
            return this;
        }

        public Adjustment AttachDeliveryComing(bool deliveryComing)
        {
            _isDeliveryComing = deliveryComing;
            return this;
        }

        private void LoadStatusList()
        {
            var statusList = SgiHelper.ConvertEnumToList<ProductStatus>(() => Enum.GetValues(typeof(ProductStatus)), (enumItem) => (ProductStatus)enumItem);
            cboStatus.DataSource = statusList;
        }

        private void LoadDamageList()
        {
            var damageList = SgiHelper.ConvertEnumToList<Damage>(() => Enum.GetValues(typeof(Damage)), (enumItem) => (Damage)enumItem);
            cboDamageStatus.DataSource = damageList;
        }

        private void LoadAdjustmentModeList()
        {
            var adjustmentModeList = SgiHelper.ConvertEnumToList<AdjustmentMode>(() => Enum.GetValues(typeof(AdjustmentMode)), (enumItem) => (AdjustmentMode)enumItem);
            cboMode.DataSource = adjustmentModeList;
        }

        private void cboDamageStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedDamage = (Damage)cboDamageStatus.SelectedItem;
            StatusDescriptionTextbox.Enabled = selectedDamage == Damage.Others ? true : false;

        }

        private void Adjustment_Load(object sender, EventArgs e)
        {
            LoadStatusList();
            LoadDamageList();
            LoadAdjustmentModeList();

            baseDeliveryUserControl1.ProductDetailCode = _productDetailCode;

            if (EntityId > 0)
            {
                var adjusmentModeValue = 0;
                var adjustmentRemarks = "";
                var status = 0;
                if (_isDeliveryComing)
                {
                    _deliveryDetail = _container.DeliveryBusinessModel.GetPrimaryDeliveryDetail(EntityId);
                    baseDeliveryUserControl1.LoadDelivery(_deliveryDetail);
                    adjusmentModeValue = _deliveryDetail.AdjustmentMode.Value;
                    adjustmentRemarks = _deliveryDetail.AdjustmentRemarks;
                    status = _deliveryDetail.Status;                    
                    StatusDescriptionTextbox.Text = _deliveryDetail.StatusDescription;
                    SetDamageInCombobox(_deliveryDetail.Damage.Value);
                }
                else
                {
                    _deliveryToOutletDetail = _container.DeliveryToOutletBusinessModel.GetDeliveryToOutletDetailBy(EntityId);
                    baseDeliveryUserControl1.LoadDelivery(_deliveryToOutletDetail);
                    adjusmentModeValue = _deliveryToOutletDetail.AdjustmentMode.Value;
                    adjustmentRemarks = _deliveryToOutletDetail.AdjustmentRemarks;
                    status = _deliveryToOutletDetail.Status;
                }
                SetAdjustmentMode(adjusmentModeValue);
                SetStatusInCombobox(status);
                txtAdjustmentRemarks.Text = adjustmentRemarks;
                
                btnDelete.Enabled = true;
            }     
        }

        public void SetAdjustmentMode(int adjustmentModeValue)
        {
            for (var i = 0; i < cboMode.Items.Count; i++)
            {
                var adjustmentMode = (AdjustmentMode)cboMode.Items[i];
                if ((int)adjustmentMode == adjustmentModeValue)
                {
                    cboMode.SelectedIndex = i;
                    break;
                }
            }
        }

        public void SetStatusInCombobox(int status)
        {
            for (var i = 0; i < cboStatus.Items.Count; i++)
            {
                var statusMode = (ProductStatus)cboStatus.Items[i];
                if ((int)statusMode == status)
                {
                    cboStatus.SelectedIndex = i;
                    break;
                }
            }
        }

        public void SetDamageInCombobox(int damage)
        {
            for (var i = 0; i < cboDamageStatus.Items.Count; i++)
            {
                var damageMode = (Damage)cboDamageStatus.Items[i];
                if ((int)damageMode == damage)
                {
                    cboDamageStatus.SelectedIndex = i;
                    break;
                }
            }
        }
       
        public int EntityId { get; private set; }
         
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var adjustmentMode = (AdjustmentMode)cboMode.SelectedItem;

            var dialog = MessageBox.Show("Are you sure you want to delete this?", "Delete", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.No)
            {
                return;
            }

            switch (adjustmentMode)
            {
                case AdjustmentMode.Add_to_Warehouse:
                case AdjustmentMode.Deduct_from_Warehouse:
                     _container.DeliveryBusinessModel.DeleteDeliveryDetail(_deliveryDetail);
                    if (OnDelete != null)
                    {
                        OnDelete(sender, e);
                    }
                    _deliveryDetail = null;
                    EntityId = 0;
                    Close();
                    break;
                case AdjustmentMode.Add_to_Outlet:
                case AdjustmentMode.Deduct_from_Outlet:
                    _container.DeliveryToOutletBusinessModel.DeleteDeliveryToOutletDetail(_deliveryToOutletDetail);
                    if (OnDelete != null)
                    {
                        OnDelete(sender, e);
                    }
                    _deliveryToOutletDetail = null;
                    EntityId = 0;
                    Close();
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (baseDeliveryUserControl1.Quantity == 0)
            {
                MessageBox.Show("Quantity should be greater than 0");
                return;
            }

            var adjustmentMode = (AdjustmentMode)cboMode.SelectedItem;

            var status = (ProductStatus)cboStatus.SelectedItem;
            var damage = (Damage)cboDamageStatus.SelectedItem;
            var message = string.Empty;
            var signOne = 1;

            switch (adjustmentMode)
            {
                case AdjustmentMode.Add_to_Warehouse:
                case AdjustmentMode.Deduct_from_Warehouse:
                    if (_deliveryDetail == null)
                    {
                        var productDetail = _container.ProductDetailBusinessModel.SelectByPrimaryId(_productDetailCode);

                        _deliveryDetail = new DeliveryDetail
                        {
                                      
                            Price = productDetail.Product.RegularPrice
                            ,
                            ProductDetail = productDetail                                    
                        };
                    }
                    
                    _deliveryDetail.AdjustmentDate = baseDeliveryUserControl1.AdjustmentDate;
                    if (status == ProductStatus.Damaged)
                    {
                        _deliveryDetail.Damage = (int)damage;
                    }

                    if (adjustmentMode == AdjustmentMode.Deduct_from_Warehouse)
                    {
                        signOne = -1;
                    }

                    //var availableQuantityInWarehouse = _container.DeliveryBusinessModelHelper.IsQuantityAvailable(
                    //    _deliveryDetail.ProductDetail.Code
                    //    , baseDeliveryUserControl1.Quantity * signOne
                    //    , status);

                    //if (!availableQuantityInWarehouse)
                    //{
                    //    MessageBox.Show("Quantity is invalid");
                    //    return;
                    //}

                    _deliveryDetail.Quantity = baseDeliveryUserControl1.Quantity * signOne;
                    _deliveryDetail.Status = (int)status;
                    _deliveryDetail.StatusDescription = StatusDescriptionTextbox.Text;
                    _deliveryDetail.AdjustmentRemarks = txtAdjustmentRemarks.Text;
                    _deliveryDetail.AdjustmentMode = (int)cboMode.SelectedValue;
                    _deliveryDetail.Damage = (int)cboDamageStatus.SelectedValue;
                    message = _container.DeliveryBusinessModel.SaveDeliveryDetail(_deliveryDetail);
                    MessageBox.Show(message);

                    if (OnSave != null)
                    {
                        OnSave(sender, e);
                    }
                    _deliveryDetail = null;
                    EntityId = 0;
                    Close();
                    break;
                case AdjustmentMode.Add_to_Outlet:
                case AdjustmentMode.Deduct_from_Outlet:
                    //var availableQuantity = 
                    //        _container.DeliveryBusinessModelHelper.IsQuantityAvailable(
                    //                        _productDetailCode
                    //                        ,baseDeliveryUserControl1.Quantity
                    //                        , status);

                    //    if(!availableQuantity && EntityId==0)
                    //    {
                    //        MessageBox.Show("The quantity is more than the quantity on hand");
                    //        return;
                    //    }


                        if (_deliveryToOutletDetail == null)
                        {
                            var productDetail = _container.ProductDetailBusinessModel.SelectByPrimaryId(_productDetailCode);

                            _deliveryToOutletDetail = new DeliveryToOutletDetail
                            {
                                SuggestedRetailPrice = productDetail.Product.RegularPrice                   
                                ,
                                ProductDetail = productDetail
                            };
                        }

                        if (adjustmentMode == AdjustmentMode.Deduct_from_Outlet)
                        {
                            signOne = -1;
                        }

                        //var availableQuantityInOutlet = _container.DeliveryBusinessModelHelper.IsQuantityAvailable(
                        //    _deliveryToOutletDetail.ProductDetail.Code
                        //    , baseDeliveryUserControl1.Quantity * signOne
                        //    , status);

                        //if (!availableQuantityInOutlet)
                        //{
                        //    MessageBox.Show("Quantity is invalid");
                        //    return;
                        //}

                        _deliveryToOutletDetail.AdjustmentDate = baseDeliveryUserControl1.AdjustmentDate;
                        _deliveryToOutletDetail.AdjustmentRemarks = txtAdjustmentRemarks.Text;
                        _deliveryToOutletDetail.Quantity = baseDeliveryUserControl1.Quantity*signOne;
                        _deliveryToOutletDetail.Status = (int)cboStatus.SelectedValue;
                        _deliveryToOutletDetail.AdjustmentMode = (int)cboMode.SelectedValue;

                        message = _container.DeliveryToOutletBusinessModel.SaveAdjustment(_deliveryToOutletDetail);
                        MessageBox.Show(message);

                        if (OnSave != null)
                        {
                            OnSave(sender, e);
                        }
                        _deliveryToOutletDetail = null;
                        EntityId = 0;
                        Close();
                    break;
            }
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            var productStatus = (ProductStatus)cboStatus.SelectedItem;
            gbDamageDetail.Enabled = productStatus == ProductStatus.Damaged ? true : false;
        }

        private void Adjustment_FormClosing(object sender, FormClosingEventArgs e)
        {
            EntityId = 0;
            _deliveryDetail = null;
            _deliveryToOutletDetail = null;
            baseDeliveryUserControl1.Quantity = 0;
            txtAdjustmentRemarks.Text = "";
            StatusDescriptionTextbox.Text = "";
        }
    }
}
