using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Views;
using SGInventory.Presenters;
using SGInventory.Model;
using SGInventory.Enums;
using SGInventory.Test.Data;
using Model=SGInventory.Model;
using SGInventory.Helpers;
using SGInventory.CustomEventArgs;
using System.Configuration;
using System.Security.Permissions;
using System.Threading;
using SGInventory.Views.UIModel;

namespace SGInventory.Delivery
{
    public partial class SupplierDeliveryForm : Form, IDeliveryPresenterView
    {
        private readonly DeliveryPresenter _presenter;
        private List<DeliveryDetail> _deliveryDetails;
        private Model.Delivery _delivery;
        private List<Model.Color> _colors;
        private List<Model.Size> _sizes;
        private List<Model.Washing> _washings;
        private Model.DeliveryDetail _selectedDelivery;
        private BusinessModelContainer _container;
        private int _deliveryId;
        private SupplierDeliveryViewModel _viewModel;

        public SupplierDeliveryForm(BusinessModelContainer container,int deliveryId,bool useScanner)
        {
            InitializeComponent();
            _deliveryId = deliveryId;            
            _selectedDelivery = new DeliveryDetail();
            _viewModel = new SupplierDeliveryViewModel();

            InitilizeControls();
            
            _container = container;
            _presenter = new DeliveryPresenter(
                this
                , container.SupplierBusinessModel
                , container.ProductBusinessModel
                , container.ProductDetailBusinessModel
                , container.ColorBusinessModel
                , container.SizeBusinessModel
                , container.WashingBusinessModel
                , container.DeliveryBusinessModel
                ,useScanner
                , _viewModel
                );
            ucSaveDeliveryDetail.SaveButtonClick += new EventHandler<EventArgs>(ucSaveEditForm1_SaveButtonClick);
            
            userControlSelectProduct1.OnEnter += userControlSelectProduct1_OnEnter;
            userControlSelectProduct1.OnManuallySelected += userControlSelectProduct1_OnManuallySelected;

            ucSaveDeliveryDetail.Button.Text = "Save Delivery";
            var newSize = 6.5f;
            ucSaveDeliveryDetail.Button.Font = new Font(ucSaveDeliveryDetail.Button.Font.Name, newSize);
            
            supplierDeliveryViewModelBindingSource.DataSource = _viewModel;
                                               
        }

        void userControlSelectProduct1_OnManuallySelected(object sender, ScanCodeArgs e)
        {
            buttonAdd_Click(sender,e);
            _viewModel.ProductCode = e.Code;
            _viewModel.SaveDeliveryEnable = true;
            supplierDeliveryViewModelBindingSource.ResetBindings(true);
        }

        void userControlSelectProduct1_OnEnter(object sender, ScanCodeArgs e)
        {                    
            _presenter.LoadResultByCode(e.IsBarCode, e.Code);

            if (e.IsBarCode)
            {
                supplierDeliveryViewModelBindingSource.ResetBindings(true);
                buttonAdd_Click(sender,e);
            }            
        }
                     
        void ucSaveEditForm1_SaveButtonClick(object sender, EventArgs e)
        {
            try
            {
                _presenter.SaveDelivery(_delivery);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
               
        }

        private void InitilizeControls()
        {
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            var width = 201;
            
            SupplierAutoComplete.SetTheWitdhOfTheTextbox(width);                     
        }
          
        public void LoadDelivery(Model.Delivery delivery)
        {
            SupplierAutoComplete.AutoCompleteValue = delivery.Supplier.Name;
            OrTextbox.Text = delivery.OrNumber;
            DeliveryDateDtp.Value = delivery.DeliveryDate;

            _presenter.BuildDeliveryInPanel(delivery, gvDeliveryDetails);
            
            _presenter.SetStocknumber(delivery);
        }

        public void LoadSuppliers(List<Model.Supplier> list)
        {
            SupplierAutoComplete.LoadAutoCompleteIdNameSource<Supplier>(list);
        }

        public void LoadProducts(List<Model.Product> list)
        {
            //ucScanBarcodeDisplay1.LoadProducts(list);            
        }

        public string GetStockNumber()
        {
            return userControlSelectProduct1.SelectedProductDetails.ProductCode;
        }
       
        public Model.Product GetSelectedProduct()
        {
            return null;//ucScanBarcodeDisplay1.GetSelectedProduct();
        }

        public void LoadColors(List<Model.Color> list)
        {
            //ucScanBarcodeDisplay1.LoadColors(list);            
            _colors = list;
        }

        public void LoadWashings(List<Model.Washing> list)
        {
            //ucScanBarcodeDisplay1.LoadWashings(list);
            _washings = list;
        }

        public void LoadSizes(List<Model.Size> list)
        {
            //ucScanBarcodeDisplay1.LoadSizes(list);
            _sizes = list;
        }

        private void DeliveryForm_Load(object sender, EventArgs e)
        {
            //ucScanBarcodeDisplay1.InitializeControls(_presenter.UsingScanner);

            if (_deliveryId > 0)
            {
                _delivery = _container.DeliveryBusinessModel.SelectByPrimaryId(_deliveryId);
            }
            _presenter.InitialLoad(_delivery);

            if (_delivery != null)
            {
                LoadDelivery(_delivery);
            }
        }
        
        public string GetColorCode()
        {
            return "";// ucScanBarcodeDisplay1.GetColorCode();
        }

        public string GetWashingCode()
        {
            return "";// ucScanBarcodeDisplay1.GetWashingCode();
        }

        public string GetSizeCode()
        {
            return "";// ucScanBarcodeDisplay1.GetSizeCode();
        }
      
        public void LoadProductIntoForm(Product product)
        {
            CostNumericControl.Numeric = product==null?0.0:product.Cost;
        }

        public void LoadProductStatusIntoForm(List<Enums.ProductStatus> list)
        {
            StatusComboBox.DataSource = list;
        }

        private void StatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_presenter.SelectProductStatus((ProductStatus)StatusComboBox.SelectedItem);
            //_presenter.DisableOrEnableSaveDeliveryDetailButton();
        }
      
        private void SupplierAutoComplete_Leave(object sender, EventArgs e)
        {
            _presenter.SupplierDetailChange();
        }

        private void OrTextbox_TextChanged(object sender, EventArgs e)
        {
            _presenter.SupplierDetailChange();
        }

        private void QuantityNumericControl_Leave(object sender, EventArgs e)
        {
            
        }

        private void StatusDescriptionTextbox_TextChanged(object sender, EventArgs e)
        {
            _presenter.DisableOrEnableSaveDeliveryDetailButton();
        }

        public string GetSupplierName()
        {
            return SupplierAutoComplete.AutoCompleteValue.Trim();
        }

        public string GetOrNumber()
        {
            return OrTextbox.Text.Trim();
        }

        public void EnableSaveDeliveryButton(bool shouldEnable)
        {
           //ucSaveDelivery.EnabledButton(shouldEnable);
        }

        public ProductStatus GetProductStatus()
        {
            return (ProductStatus)StatusComboBox.SelectedItem;
        }

        public int GetQuantity()
        {
            var quantity = 0;
            int.TryParse(QuantityTextbox.Text.Trim(), out quantity);
            return quantity;
        }

        private void QuantityTextbox_KeyPress(object sender, KeyPressEventArgs e)
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

        public string GetStatusDescription()
        {
            return StatusDescriptionTextbox.Text.Trim();
        }

        private void QuantityTextbox_TextChanged(object sender, EventArgs e)
        {
            _presenter.DisableOrEnableSaveDeliveryButton();
        }

        public void LoadDelivery(DeliveryDetail deliveryDetails)
        {
            
        }

        public DateTime GetDeliveryDate()
        {
            return DeliveryDateDtp.Value;
        }

        public void DisableDeliveryControls()
        {
            SupplierAutoComplete.Enabled = false;
            DeliveryDateDtp.Enabled = false;
            OrTextbox.Enabled = false;
            //ucScanBarcodeDisplay1.StockNumberComboBoxControl.Enabled = false;            
        }

        public double GetPrice()
        {
            return CostNumericControl.Numeric;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void EnableProductDetailsGroup(bool enable)
        {
            //this.ProductGroupBox.Enabled = enable;
        }

        public void ResetPreviousControlState()
        {
            QuantityTextbox.Text = "1";
            QuantityTextbox.Focus();
            StatusDescriptionTextbox.Clear();
            //ucScanBarcodeDisplay1.StockNumberComboBoxControl.ResetText();
            //ucScanBarcodeDisplay1.SizeAutoCompleteControl.AutoCompleteValue = "";
            //ucScanBarcodeDisplay1.WashingAutoCompleteControl.AutoCompleteValue = "";
            //ucScanBarcodeDisplay1.ColorAutoCompleteControl.AutoCompleteValue = "";
            CostNumericControl.Numeric = 0.0;
            StatusDescriptionTextbox.Clear();
        }

        public Model.Size GetSelectedSize()
        {
            return null; //SgiHelper.SelectModelByNameInTheCollection<Model.Size>(_sizes, ucScanBarcodeDisplay1.SizeAutoCompleteControl.AutoCompleteValue);
        }

        public Washing GetSelectedWashing()
        {
            return null;// SgiHelper.SelectModelByNameInTheCollection<Model.Washing>(_washings, ucScanBarcodeDisplay1.WashingAutoCompleteControl.AutoCompleteValue);
        }

        public Model.Color GetSelectedColor()
        {
            return null;// SgiHelper.SelectModelByNameInTheCollection<Model.Color>(_colors, ucScanBarcodeDisplay1.ColorAutoCompleteControl.AutoCompleteValue);
        }

        public void SetDeliveryDetailItemCost(double? cost)
        {
            if (cost.HasValue)
            {
                CostNumericControl.Numeric = cost.Value;
            }
        }

        public void EnableSaveDeliveryDetailButton(bool shouldEnable)
        {
            //ucSaveDeliveryDetail.EnabledButton(shouldEnable);
        }

        public void LoadDamageIntoForm(List<Damage> list)
        {
            cboDamageStatus.DataSource = list;
        }

        public void ShouldEnableDamageDetailGroup(bool isEnable)
        {
            //gbDamageDetail.Enabled = isEnable;
        }

        private void cboDamageStatus_SelectedIndexChanged(object sender, EventArgs e)
        {            
            _presenter.SelectDamage((Damage)cboDamageStatus.SelectedItem);
            _presenter.DisableOrEnableSaveDeliveryDetailButton();
        }

        public void ShouldEnableStatusDescription(bool isEnable)
        {
            StatusDescriptionTextbox.Enabled = isEnable;
        }

        public Damage GetDamage()
        {
            return cboDamageStatus.SelectedItem==null?Damage.Fabric:(Damage)cboDamageStatus.SelectedItem;
        }
       
        public bool GetSelectByProductCode()
        {
            return true;//ucScanBarcodeDisplay1.GetSelectByProductCode();
        }

        public void DisabledProductDetail(bool disable)
        {
            //ucScanBarcodeDisplay1.DisabledProductDetail(disable);
        }

        public void RenameStockOrCodeLabel(string label)
        {
            //ucScanBarcodeDisplay1.RenameStockOrCodeLabel(label);
        }

        public void LoadProducts(List<ProductDetails> list)
        {
            //ucScanBarcodeDisplay1.LoadProducts(list);
        }

        public ProductDetails GetSelectedProductDetails()
        {           
            return null;// ucScanBarcodeDisplay1.GetSelectedProductDetails();
        }

        public void LoadProductIntoForm(ProductDetails productDetails)
        {
            if (productDetails == null)
                return;
            CostNumericControl.Numeric = productDetails.OverrideCost.HasValue ? productDetails.OverrideCost.Value : productDetails.Product.Cost;
            //ucScanBarcodeDisplay1.SizeAutoCompleteControl.AutoCompleteValue = productDetails.Size.Name;
            //ucScanBarcodeDisplay1.ColorAutoCompleteControl.AutoCompleteValue = productDetails.Color.Name;
            //ucScanBarcodeDisplay1.WashingAutoCompleteControl.AutoCompleteValue = productDetails.Washing.Name;
        }

        public void ClearProductDetailControls()
        {
            //ucScanBarcodeDisplay1.ClearProductDetailControls();
        }
       
        public void ShowScannerWindow(bool useScanner)
        {
            if (useScanner)
            {
                var window = new ScannerForm();
                //window.Presenter.OnScanAction += new EventHandler<ScannerResponse>(Presenter_OnScanAction);
                window.OnScannerFormClosing += new EventHandler<EventArgs>(window_OnScannerFormClosing);
                window.Show();
            }
    
        }

        void window_OnScannerFormClosing(object sender, EventArgs e)
        {
            //ucScanBarcodeDisplay1.ChkBarcodeOrStockNumberControl.Checked = false;

        }
       
        public void SetSelectByBarcodeTo(bool selectByBarcode)
        {
            //ucScanBarcodeDisplay1.SetSelectByBarcodeTo(selectByBarcode); 
        }

        public void SetBarcodeAs(ProductDetails productDetails)
        {            
            LoadProducts(new List<ProductDetails> { productDetails });
            //ucScanBarcodeDisplay1.StockNumberComboBoxControl.SelectedIndex = 0;
        }
       
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            CostNumericControl.Numeric = userControlSelectProduct1.SelectedProductDetails.Cost;
            _presenter.StoreDeliveryDetailToDelivery(ref _delivery);           
        }

        public void LoadToDeliveryDetailGrid(Model.Delivery delivery)
        {
            _presenter.BuildDeliveryInPanel(delivery, gvDeliveryDetails);
            EnableEditMenu(true);
        }

        public void EnableSaveAddProductButton(bool enable)
        {
            //buttonAdd.Enabled = enable;
        }
        
        private void editDeliveriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var administrator = Enum.GetName(typeof(RoleType), RoleType.Administrator);
            var allowedAccess = Thread.CurrentPrincipal.IsInRole(administrator);

            if (!allowedAccess)
            {
                MessageBox.Show("Access denied!");
                return;
            }

            _delivery.DeliveryDetails = _delivery.DeliveryDetails.Where(d => d.IsActive == 1).ToList();
            var supplierDeliveryEditForm = new SupplierDeliveryEditForm(_delivery.DeliveryDetails, _container, _delivery == null ? false : (_delivery.Id > 0 ? true : false));
            supplierDeliveryEditForm.OnDeactivateDeliveryDetail += new EventHandler<CustomEventArgs.ModelEventArgs<SGInventory.Model.Delivery>>(supplierDeliveryEditForm_OnDeactivateDeliveryDetail);
            supplierDeliveryEditForm.OnUpdateDeliveryDetail += new EventHandler<UpdateDeliveryDetailArgs>(supplierDeliveryEditForm_OnUpdateDeliveryDetail);
            supplierDeliveryEditForm.ShowDialog();                      
        }

        void supplierDeliveryEditForm_OnUpdateDeliveryDetail(object sender, UpdateDeliveryDetailArgs e)
        {
            if (e.CurrentSelectedDeliveryDetail.Delivery.Id > 0)
            {
                _delivery = _container.DeliveryBusinessModel.SelectByPrimaryId(e.CurrentSelectedDeliveryDetail.Delivery.Id);
               
            }
            
            
            for (int i = 0; i < _delivery.DeliveryDetails.Count; i++)
            {
                if (_delivery.DeliveryDetails[i].Id > 0  && _delivery.DeliveryDetails[i].Id == e.CurrentSelectedDeliveryDetail.Id)
                {
                    _delivery.DeliveryDetails[i] = e.CurrentSelectedDeliveryDetail;
                    break;
                }
                else
                {
                    if (e.PreviousSelectedDeliveryDetail.Status == (int)ProductStatus.Goods)
                    {
                        if (_delivery.DeliveryDetails[i].ProductDetail.Code == e.CurrentSelectedDeliveryDetail.ProductDetail.Code
                            && _delivery.DeliveryDetails[i].Status == (int)ProductStatus.Goods)
                        {
                            _delivery.DeliveryDetails[i] = e.CurrentSelectedDeliveryDetail;
                            break;
                        }
                    }
                    else
                    {
                        if (_delivery.DeliveryDetails[i].ProductDetail.Code == e.CurrentSelectedDeliveryDetail.ProductDetail.Code
                            && (_delivery.DeliveryDetails[i].Damage.HasValue && _delivery.DeliveryDetails[i].Damage.Value== 
                            (e.PreviousSelectedDeliveryDetail.Damage.Value))
                            )
                        {
                            _delivery.DeliveryDetails[i] = e.CurrentSelectedDeliveryDetail;
                            break;
                        }
                    }
                    
                }
                
            }
            LoadToDeliveryDetailGrid(_delivery);
        }

        void supplierDeliveryEditForm_OnDeactivateDeliveryDetail(object sender, CustomEventArgs.ModelEventArgs<SGInventory.Model.Delivery> e)
        {
            if (e.Model.Id > 0)
            {
                _delivery = _container.DeliveryBusinessModel.SelectByPrimaryId(e.Model.Id);
            }
            
            LoadDelivery(e.Model);
            _viewModel.SaveDeliveryEnable = _delivery.DeliveryDetails.Count > 0;
            supplierDeliveryViewModelBindingSource.ResetBindings(true);
        }

        public void EnableEditMenu(bool enable)
        {
            editDeliveriesToolStripMenuItem.Enabled = enable;
        }

        public bool DeliveryAlreadyExists(string barcodeNumber, int status, int? damageStatus)
        {
            var alreadyExists = _delivery.DeliveryDetails.Where(d => 
                {
                    if (status == (int)ProductStatus.Goods)
                    {
                        return d.ProductDetail.Code.Equals(barcodeNumber) && d.Status == status && d.IsActive==1;
                    }
                    else
                    {
                        return d.ProductDetail.Code.Equals(barcodeNumber) && d.Status == status && d.Damage.Value == damageStatus.Value && d.IsActive == 1;
                    }
                    
                }
                ).Any();
            return alreadyExists;
        }

        private void QuantityTextbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (_presenter.UsingScanner && e.KeyCode == Keys.Enter)
            {
                //ucScanBarcodeDisplay1.FocusOnInputText();
            }
        }

        public int GetMaximumLimit()
        {
            var limit = ConfigurationManager.AppSettings["ItemLimit"];
            return Convert.ToInt32(limit);
        }


        public string Stocknumber
        {
            set { lblStockNumber.Text = value; }
        }

        public int GetRowCount()
        {
            if (gvDeliveryDetails.DataSource == null)
            {
                return 0;
            }

            return gvDeliveryDetails.RowCount;
        }

        public void LoadResultToView(List<ProductDetails> result)
        {
            userControlSelectProduct1.LoadResult(result);
        }
      
        public void SetWashingCode(string washing)
        {
            //ucScanBarcodeDisplay1.WashingAutoCompleteControl.AutoCompleteValue = washing;
        }
    }

       
}
