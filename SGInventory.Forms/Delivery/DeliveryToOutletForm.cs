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
using SGInventory.Helpers;
using SGInventory.Enums;
using System.Configuration;
using System.Threading;
using SGInventory.Views.UIModel;
using SGInventory.Model;

namespace SGInventory.Delivery
{
    public partial class DeliveryToOutletForm : Form, IDeliveryToOutletView
    {
        private BusinessModelContainer _container;
        private string _packingNumber;
        private DeliveryToOutletPresenter _presenter;
        private DeliveryToOutletViewModel _viewModel;

        private DeliveryToOutletForm(BusinessModelContainer container, string packingNumber)
        {
            InitializeComponent();
            _viewModel = new DeliveryToOutletViewModel();

            _container = container;
            _packingNumber = packingNumber;

            _presenter = new DeliveryToOutletPresenter(
                _container.DeliveryToOutletBusinessModel
                , this
                , _container.ProductBusinessModel
                , _container.OutletBusinessModel
                , _container.ProductDetailBusinessModel
                , _container.ColorBusinessModel
                , _container.SizeBusinessModel
                , _container.WashingBusinessModel
                , container.DeliveryBusinessModelHelper
                ,_viewModel
                );
            InitializeEvents();
            ucSaveDeliveryDetail.Button.Text = "Save Delivery";
            var newSize = 6.5f;
            ucSaveDeliveryDetail.Button.Font = new Font(ucSaveDeliveryDetail.Button.Font.Name, newSize);
        }

        public DeliveryToOutletForm(BusinessModelContainer container, string packingNumber, ProductStatus status) : this(container, packingNumber)
        {
            this._status = status;
        }

        private void DeliveryToOutletForm_Load(object sender, EventArgs e)
        {
           
            InitializeObjects();
                                  
            _presenter.InitializeControlsToDefaultState();

            if (!string.IsNullOrEmpty(_packingNumber))
            {
                _presenter.LoadDeliveryOutletToView(_packingNumber);
            }
            _presenter.LoadProductStatus();

            deliveryToOutletBindingSource.DataSource = _viewModel;
        }

        void userControlSelectProduct1_OnEnter(object sender, CustomEventArgs.ScanCodeArgs e)
        {
            _presenter.LoadResultByCode(e.IsBarCode, e.Code);

            if (e.IsBarCode)
            {
                buttonAdd_Click(sender, e);
                _viewModel.SaveProductEnable = true;
                _viewModel.AddProductEnable = true;
                deliveryToOutletBindingSource.ResetBindings(true);
                
            }            
        }

        void userControlSelectProduct1_OnManuallySelected(object sender, CustomEventArgs.ScanCodeArgs e)
        {
            buttonAdd_Click(sender, e);
            _viewModel.ProductCode = e.Code;
            _viewModel.SaveProductEnable = true;
            deliveryToOutletBindingSource.ResetBindings(true);
        }

        public void LoadProductStatusIntoForm(List<Enums.ProductStatus> list)
        {
            StatusComboBox.DataSource = list;
            if (list.Count > 0)
            {
                _viewModel.Status = list[0];
            }
        }

        private void InitializeObjects()
        {
            userControlSelectProduct1.OnEnter += userControlSelectProduct1_OnEnter;
            userControlSelectProduct1.OnManuallySelected += userControlSelectProduct1_OnManuallySelected;

            this.ParentDeliveryToOutlet = new Model.DeliveryToOutlet();
            this.SelectedDeliveryToOutletDetails = new List<Model.DeliveryToOutletDetail>();
            _viewModel.Quantity = 1;
            
        }
        
        private void InitializeEvents()
        {
            ucSaveDeliveryDetail.SaveButtonClick += new EventHandler<EventArgs>(ucSaveDeliveryDetail_SaveButtonClick);
           
        }
          
        void ucSaveDeliveryDetail_SaveButtonClick(object sender, EventArgs e)
        {
            _presenter.SaveDeliveryToOutlet(() => { 
                _presenter.BuildProductDetailIntoPanel(dgvItem);
                msDeliveryToOutletTransaction.Enabled = true;
                _packingNumber = GetPackingNumber();
            });
        }

        public int GetOutletId()
        {
            int? retValue = ucAutoCompleteStore.AutoCompleteId;
            return retValue.HasValue?retValue.Value:0;
        }

        public DateTime GetDeliveryDate()
        {
            var retValue = dtpDateDelivered.Value;
            return retValue;
        }

        public string GetPackingNumber()
        {
            var retValue = txtDrNo.Text.Trim();
            return retValue;
        }

        public void EnableSaveButton(bool shouldEnable)
        {            
            ucSaveDeliveryDetail.EnabledButton(shouldEnable);
        }

        public void EnablePackingListNumberTextBox(bool shouldEnable)
        {
            txtDrNo.Enabled = shouldEnable;
        }

        public void LoadDeliveryToOutlet()
        {          
            msDeliveryToOutletTransaction.Enabled = true;
            _presenter.BuildProductDetailIntoPanel(dgvItem);
        }

        public void LoadOutletToControl(List<Model.Outlet> stores)
        {
            ucAutoCompleteStore.LoadAutoCompleteIdNameSource(stores);
        }

        public void CheckUseScannerAsDefault()
        {
            //ucScanBarcodeDisplay1.UseScanner = true;
        }

        public void EnableEditDeliveriesToOutlet(bool shouldEnable)
        {
            
        }

        public List<Model.DeliveryToOutletDetail> SelectedDeliveryToOutletDetails
        {
            get;
            set;
        }

        public Model.DeliveryToOutlet ParentDeliveryToOutlet
        {
            get;
            set;
        }

        public int GetQuantity()
        {
            var retValue = 0;
            int.TryParse(txtQuantity.Text, out retValue);
            return retValue;
        }

        public double Srp
        {
            get { return ncSrpPrice.Numeric; }
            set { ncSrpPrice.Numeric = value; }
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void LoadProductIntoForm(Model.Product product)
        {
            
        }

        public void LoadProductIntoForm(Model.ProductDetails productDetails)
        {
            if (productDetails == null)
                return;
            ncSrpPrice.Numeric = productDetails.Product.RegularPrice;
          
        }

        public void EnableSaveDeliveryDetailButton(bool shouldEnable)
        {
            ucSaveDeliveryDetail.Enabled = shouldEnable;
        }

        ScannerForm _window;
        public void ShowScannerWindow(bool useScanner)
        {
            if (useScanner)
            {
                
                    _window = new ScannerForm();
                    _window.Presenter.OnScanAction += new EventHandler<ScannerResponse>(Presenter_OnScanAction);
                    _window.OnScannerFormClosing += new EventHandler<EventArgs>(window_OnScannerFormClosing);
                    _window.Show();
                

            }
            else
            {
                _window.Close();
            }
        }

        void window_OnScannerFormClosing(object sender, EventArgs e)
        {
            //ucScanBarcodeDisplay1.UseScanner = false;
        }

        void Presenter_OnScanAction(object sender, ScannerResponse e)
        {
          
            var isValid = _presenter.ValidateItemCodeAfterScanning(e.ItemCode);

            if (isValid)
            {                           
                buttonAdd_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Scanned barcode not exists!");
            }
        }

        public void EnableSaveAddProductButton(bool enable)
        {
            this.buttonAdd.Enabled = enable;
        }

        public void SetBarcodeAs(Model.ProductDetails productDetails)
        {
            LoadProducts(new List<SGInventory.Model.ProductDetails> { productDetails });
            
        }

        public void LoadProducts(List<Model.Product> list)
        {
           
        }

        
        public Model.Product GetSelectedProduct()
        {
            return null;
        }

        public void LoadColors(List<Model.Color> list)
        {
            
        }

        public void LoadWashings(List<Model.Washing> list)
        {
            
        }

        public void LoadSizes(List<Model.Size> list)
        {
            
        }

        public string GetColorCode()
        {
            return null;
        }

        public string GetWashingCode()
        {
            return null;
        }

        public string GetSizeCode()
        {
            return null;
        }

        public bool GetSelectByProductCode()
        {
            return true;
        }

        public void DisabledProductDetail(bool disable)
        {
            
        }

        public void RenameStockOrCodeLabel(string label)
        {
            
        }

        public void LoadProducts(List<Model.ProductDetails> list)
        {
           
        }

        public Model.ProductDetails GetSelectedProductDetails()
        {
            return null;
        }

        public void ClearProductDetailControls()
        {
            
        }

        public void SetSelectByBarcodeTo(bool selectByBarcode)
        {
          
        }

       
        public string GetStockNumber()
        {
            return userControlSelectProduct1.SelectedProductDetails.ProductCode;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var productDescription = userControlSelectProduct1.SelectedProductDetails.Description;
            ncSrpPrice.Numeric = userControlSelectProduct1.SelectedProductDetails.Cost;
            var stockNumber = GetStockNumber();
            var enterQuantityForm = new EnterQuantityForm(productDescription, stockNumber);
            enterQuantityForm.ShowDialog();
            
            if(enterQuantityForm.Quantity>0)
            {
                _viewModel.Quantity = enterQuantityForm.Quantity;
                txtQuantity.Text = _viewModel.Quantity.ToString();
                _presenter.AddDeliveryToOutletDetail(() =>
                {
                    _presenter.BuildProductDetailIntoPanel(dgvItem);                    
                });
            }
                   
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
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
        private DeliveryToOutletEditForm _editForm;
        private ProductStatus _status;

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var administrator = Enum.GetName(typeof(RoleType), RoleType.Administrator);
            var allowedAccess = Thread.CurrentPrincipal.IsInRole(administrator);

            if (!allowedAccess)
            {
                MessageBox.Show("Access denied!");
                return;
            }
                
            _editForm = new DeliveryToOutletEditForm(_container,ParentDeliveryToOutlet);
            _editForm.OnUpdateDeliveryDetail += new EventHandler(form_OnChangesDeliveryDetail);
            _editForm.OnDeactivateDeliveryDetail += new EventHandler(form_OnChangesDeliveryDetail);
            _editForm.ShowDialog();

        }
        
        void form_OnChangesDeliveryDetail(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(_packingNumber))
            {
                _presenter.LoadDeliveryOutletToView(_packingNumber);
            }    
            else
            {
                _presenter.BuildProductDetailIntoPanel(dgvItem);
            }
                          
        }

        private void DeliveryToOutletForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormsHelper.CloseAllOpenFormsWithName("ScannerForm", "DeliveryToOutletEditForm");            
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.OnPrinting();
          
        }

        private void txtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
            }
        }
        private void ucAutoCompleteStore_Leave(object sender, EventArgs e)
        {
            _presenter.StoreDetailChange();
        }        
        public void EnableProductDetailsGroup(bool shouldEnable)
        {
            this.grpProductDetail.Enabled = shouldEnable;
        }
        public string GetStoreName()
        {
            return ucAutoCompleteStore.AutoCompleteValue.Trim();
        }
        public int GetMaximumLimit()
        {
            var limit = ConfigurationManager.AppSettings["ItemLimit"];
            return Convert.ToInt32(limit);
        }
        public void SetWashingCode(string washing)
        {
          
        }
        public void LoadResultToView(List<ProductDetails> result)
        {
            userControlSelectProduct1.LoadResult(result,(prodDetail)=>prodDetail.Product.MarkdownPrice>0?prodDetail.Product.MarkdownPrice:prodDetail.Product.RegularPrice);
        }
        public ProductStatus GetProductStatus()
        {
            return _status;
        }
        public void LoadDeliveryToOutlet(DeliveryToOutlet deliveryToOutlet)
        {
            _viewModel.Outlet = deliveryToOutlet.Outlet.Name;
            _viewModel.DrNumber = deliveryToOutlet.PackingListNumber;
            _viewModel.DeliveryDate = deliveryToOutlet.DeliveryDate;
            _presenter.BuildProductDetailIntoPanel(dgvItem);
            
           
        }
        public DialogResult ShowYesNoMessage(string message, string caption)
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo);
        }
        public void OnSave()
        {
            ucSaveDeliveryDetail_SaveButtonClick(null, null);
        }
        public void PopupPrintForm()
        {
            var form = new DeliveryToOutletPrintForm(_container
              , ParentDeliveryToOutlet.Id);
            form.ShowDialog();
        }
    }
}
