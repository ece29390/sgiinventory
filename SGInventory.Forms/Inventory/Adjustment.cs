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

        private readonly string _productDetailCode;
        private readonly BusinessModelContainer _container;
        private DeliveryDetail _deliveryDetail;
        private DeliveryToOutletDetail _deliveryToOutletDetail;

        private bool _isDeliveryComing;
        private List<Outlet> _outlets;
        private List<Supplier> _suppliers;
        private int? _selectedOutletOrSupplier;
        

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
        private void GetOutlets()
        {
            _outlets = _container.OutletBusinessModel.SelectAll();
        }
        private void GetSuppliers()
        {
            _suppliers = _container.SupplierBusinessModel.SelectAll();
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
            GetSuppliers();
            GetOutlets();
            InitializeAutoCompleteControl();
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
                    if(_deliveryDetail.Damage.HasValue)
                    {
                        SetDamageInCombobox(_deliveryDetail.Damage.Value);
                    }   
                    if(_deliveryDetail.Delivery!=null)
                    {
                        ucAutoCompleteOutletOrSupplier.AutoCompleteValue = _deliveryDetail.Delivery.Supplier.Name;
                    }                    
                }
                else
                {
                    _deliveryToOutletDetail = _container.DeliveryToOutletBusinessModel.GetDeliveryToOutletDetailBy(EntityId);
                    baseDeliveryUserControl1.LoadDelivery(_deliveryToOutletDetail);
                    adjusmentModeValue = _deliveryToOutletDetail.AdjustmentMode.Value;
                    adjustmentRemarks = _deliveryToOutletDetail.AdjustmentRemarks;
                    status = _deliveryToOutletDetail.Status;

                    if(_deliveryToOutletDetail.DeliveryToOutlet!=null)
                    {
                        ucAutoCompleteOutletOrSupplier.AutoCompleteValue = _deliveryToOutletDetail.DeliveryToOutlet.Outlet.Name;
                    }
                }
                SetAdjustmentMode(adjusmentModeValue);
                SetStatusInCombobox(status);
                txtAdjustmentRemarks.Text = adjustmentRemarks;

                btnDelete.Enabled = true;
            }
        }

        private void InitializeAutoCompleteControl()
        {
            ucAutoCompleteOutletOrSupplier.AfterSelecting += UcAutoCompleteOutletOrSupplier_AfterSelecting;
            ucAutoCompleteOutletOrSupplier.InsideTextChange += UcAutoCompleteOutletOrSupplier_InsideTextChange;
            ucAutoCompleteOutletOrSupplier.AutoCompleteKeyup += UcAutoCompleteOutletOrSupplier_AutoCompleteKeyup;
        }

        private void UcAutoCompleteOutletOrSupplier_AutoCompleteKeyup(object sender, KeyEventArgs e)
        {
            
        }

        private void UcAutoCompleteOutletOrSupplier_InsideTextChange(object sender, EventArgs e)
        {
            
        }

        private void UcAutoCompleteOutletOrSupplier_AfterSelecting(object sender, EventArgs e)
        {
            _selectedOutletOrSupplier = ucAutoCompleteOutletOrSupplier.AutoCompleteId;
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
        private bool Validate(AdjustmentMode mode)
        {
            if (baseDeliveryUserControl1.Quantity <= 0)
            {
                MessageBox.Show("Quantity should be greater than 0");
                return false;
            }

            if(!_selectedOutletOrSupplier.HasValue&&mode!=AdjustmentMode.Deduct_from_Warehouse)
            {
                var outletOrSupplier = (mode == AdjustmentMode.Add_to_Outlet || mode == AdjustmentMode.Deduct_from_Outlet) ? "Outlet" : "Supplier";
                var message = $"Select a {outletOrSupplier}";
                MessageBox.Show(message);
                return false;
            }

            return true;
        }
        private Model.Delivery GenerateParentDelivery()
        {
            string orNumber = _container.DeliveryBusinessModel.GetAdjustmentNumberBy(baseDeliveryUserControl1.AdjustmentDate);
            var delivery = new Model.Delivery
            {
                CreatedBy = SgiHelper.GetIdentityUserName()
                                ,
                CreatedDate = DateTime.Now
                                ,
                Supplier = new Supplier { Id = _selectedOutletOrSupplier.Value }
                                ,
                DeliveryDate = baseDeliveryUserControl1.AdjustmentDate
                ,
                OrNumber = orNumber
             };
            return delivery;
        }

        private void SaveManualDelivery(
            AdjustmentMode adjustmentMode
            , ProductStatus status
            , Damage damage
            , int signOne
            , object sender
            , EventArgs e
            )
        {
            var message = string.Empty;
            if (_deliveryDetail == null)
            {
                var productDetail = _container.ProductDetailBusinessModel.SelectByPrimaryId(_productDetailCode);

                _deliveryDetail = new DeliveryDetail
                {
                    Price = productDetail.Product.Cost
                    ,
                    ProductDetail = productDetail
                };
                AttachParentDeliveryIfModeIsAddToWarehouse(adjustmentMode);

                if (adjustmentMode == AdjustmentMode.Add_to_Warehouse)
                {
                    _deliveryDetail.Delivery.DeliveryDetails = new List<DeliveryDetail> { _deliveryDetail };
                }
            }
            else
            {
                if (_deliveryDetail.Delivery == null)
                {
                    AttachParentDeliveryIfModeIsAddToWarehouse(adjustmentMode);
                    if (adjustmentMode == AdjustmentMode.Add_to_Warehouse)
                    {
                        _deliveryDetail.Delivery.DeliveryDetails = new List<DeliveryDetail> { _deliveryDetail };
                    }
                }
            }

            _deliveryDetail.AdjustmentDate = baseDeliveryUserControl1.AdjustmentDate;
             
            if (status == ProductStatus.Damaged)
            {
                _deliveryDetail.Damage = (int)damage;
            }
           

            _deliveryDetail.Quantity = baseDeliveryUserControl1.Quantity * signOne;
            _deliveryDetail.Status = (int)status;
            _deliveryDetail.StatusDescription = StatusDescriptionTextbox.Text;
            _deliveryDetail.AdjustmentRemarks = txtAdjustmentRemarks.Text;
            _deliveryDetail.AdjustmentMode = (int)cboMode.SelectedValue;
                                   
            message = adjustmentMode == AdjustmentMode.Deduct_from_Warehouse ?
                _container.DeliveryBusinessModel.SaveDeliveryDetail(_deliveryDetail)
                : _container.DeliveryBusinessModel.SaveInTransaction(_deliveryDetail.Delivery);

            MessageBox.Show(message);

            if (OnSave != null)
            {
                OnSave(sender, e);
            }
            _deliveryDetail = null;
            EntityId = 0;
            Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            var adjustmentMode = (AdjustmentMode)cboMode.SelectedItem;
            if (!Validate(adjustmentMode))
            {
                return;
            }
            
            var status = (ProductStatus)cboStatus.SelectedItem;
            var damage = (Damage)cboDamageStatus.SelectedItem;
            var message = string.Empty;
            var signOne = 1;
            var quantity = 0;
            var invalidQuantityFormat = $"The suggested quantity is more than the total quantity in the record for product {_productDetailCode}";
            switch (adjustmentMode)
            {
                case AdjustmentMode.Add_to_Warehouse:
                case AdjustmentMode.Deduct_from_Warehouse:
                    if (adjustmentMode == AdjustmentMode.Deduct_from_Warehouse)
                    {
                        signOne = -1;
                    }
                     quantity = baseDeliveryUserControl1.Quantity * signOne;
                    if (!IsQuantityValid(adjustmentMode, () => _container.DeliveryBusinessModel.GetDeliveryDetailTotalQuantityByCode(_productDetailCode,status)))
                    {
                        MessageBox.Show(invalidQuantityFormat);
                        return;
                    }
                    SaveManualDelivery(adjustmentMode, status, damage, signOne, sender, e);
                 
                    break;
                case AdjustmentMode.Add_to_Outlet:
                case AdjustmentMode.Deduct_from_Outlet:
                    if (adjustmentMode == AdjustmentMode.Deduct_from_Outlet)
                    {
                        signOne = -1;
                    }
                     quantity = baseDeliveryUserControl1.Quantity * signOne;

                    if(!IsQuantityValid(adjustmentMode,()=>_container.DeliveryToOutletBusinessModel.GetOverallQuantityPerOutlet(_selectedOutletOrSupplier.Value,_productDetailCode)))
                    {
                        MessageBox.Show(invalidQuantityFormat);
                        return;
                    }

                    SaveAdjustmentForOutlet(sender, e, adjustmentMode, quantity);                    
                    break;
            }

            
        }

        private void AttachParentDeliveryIfModeIsAddToWarehouse(AdjustmentMode adjustmentMode)
        {
            if (adjustmentMode == AdjustmentMode.Add_to_Warehouse)
            {
                _deliveryDetail.Delivery = GenerateParentDelivery();
            }
        }

        private bool IsQuantityValid(AdjustmentMode mode,Func<int> getAvailableQuantity)
        {
            if(mode == AdjustmentMode.Add_to_Outlet || mode == AdjustmentMode.Add_to_Warehouse)
            {
                return true;
            }
            var quantity = baseDeliveryUserControl1.Quantity;
            var availableQuantity = getAvailableQuantity();
            return availableQuantity >= quantity;
        }

        private DeliveryToOutlet GenerateParentDeliveryToOutlet()
        {
            string packingListNumber = _container.DeliveryToOutletBusinessModel
                        .GenerateAdjustmentNumberBy(baseDeliveryUserControl1.AdjustmentDate);
            var parentDeliveryToOutlet = new DeliveryToOutlet
            {
                CreatedBy = SgiHelper.GetIdentityUserName()
                       ,
                CreatedDate = DateTime.Now
                       ,
                DeliveryDate = baseDeliveryUserControl1.AdjustmentDate
                       ,
                Outlet = new Outlet { Id = _selectedOutletOrSupplier.Value }
                       ,
                IsActive = 1
                       ,
                PackingListNumber = packingListNumber
            };
            return parentDeliveryToOutlet;
        }
        private void SaveAdjustmentForOutlet(object sender, EventArgs e, AdjustmentMode adjustmentMode,  int quantity)
        {
            var message = string.Empty;
            if (_deliveryToOutletDetail == null)
            {
                var productDetail = _container.ProductDetailBusinessModel.SelectByPrimaryId(_productDetailCode);

                _deliveryToOutletDetail = new DeliveryToOutletDetail
                {
                    SuggestedRetailPrice = productDetail.Product.MarkdownPrice > 0 ? productDetail.Product.MarkdownPrice : productDetail.Product.RegularPrice
                    ,
                    ProductDetail = productDetail
                    ,
                    DeliveryToOutlet = GenerateParentDeliveryToOutlet()
                };
                
                
            }
            else
            {               
                if (_deliveryToOutletDetail.DeliveryToOutlet == null)
                {
                    _deliveryToOutletDetail.DeliveryToOutlet = GenerateParentDeliveryToOutlet();
                }               
            }

            AssignValuesToOtherPropertiesOfDeliveryToOutletDetail(quantity);
            _deliveryToOutletDetail.DeliveryToOutlet.DeliveryToOutletDetails = new List<DeliveryToOutletDetail> { _deliveryToOutletDetail };
            message = _container.DeliveryToOutletBusinessModel.SaveDeliveryToOutlet(_deliveryToOutletDetail.DeliveryToOutlet);
            MessageBox.Show(message);

            if (OnSave != null)
            {
                OnSave(sender, e);
            }
            _deliveryToOutletDetail = null;
            EntityId = 0;
            Close();

        }

        private void AssignValuesToOtherPropertiesOfDeliveryToOutletDetail(int quantity)
        {
            _deliveryToOutletDetail.AdjustmentDate = baseDeliveryUserControl1.AdjustmentDate;
            _deliveryToOutletDetail.AdjustmentRemarks = txtAdjustmentRemarks.Text;
            _deliveryToOutletDetail.Quantity = quantity;
            _deliveryToOutletDetail.Status = (int)cboStatus.SelectedValue;
            _deliveryToOutletDetail.AdjustmentMode = (int)cboMode.SelectedValue;
        }

        private void SetSelectedOutletAndSupplierToNull()
        {
            _selectedOutletOrSupplier = null;            
        }
        private AdjustmentMode GetSelectedMode()
        {
            var mode = (AdjustmentMode)cboMode.SelectedValue;
            return mode;
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

        private void cboMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSelectedOutletAndSupplierToNull();
            var mode = GetSelectedMode();
            switch (mode)
            {
                case AdjustmentMode.Add_to_Outlet:
                case AdjustmentMode.Deduct_from_Outlet:
                    ucAutoCompleteOutletOrSupplier.LoadAutoCompleteIdNameSource(_outlets);
                    break;
                case AdjustmentMode.Add_to_Warehouse:
                case AdjustmentMode.Deduct_from_Warehouse:
                    ucAutoCompleteOutletOrSupplier.LoadAutoCompleteIdNameSource(_suppliers);                    
                    break;
            }
            ucAutoCompleteOutletOrSupplier.Enabled = !(mode == AdjustmentMode.Deduct_from_Warehouse);
            labelSupplierOrOutlet.Text = (mode == AdjustmentMode.Add_to_Outlet || mode == AdjustmentMode.Deduct_from_Outlet) ? "Outlets" : "Suppliers";
        }
    }
}
