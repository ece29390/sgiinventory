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

namespace SGInventory.Delivery
{
    public partial class DeliveryToOutletForm : Form, IDeliveryToOutletView
    {
        private BusinessModelContainer _container;
        private string _packingNumber;
        private DeliveryToOutletPresenter _presenter;

        public DeliveryToOutletForm(BusinessModelContainer container, string packingNumber,bool useScanner,ProductStatus status)
        {
            InitializeComponent();

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
                ,useScanner
                ,status
                );
            InitializeEvents();
            ucSaveDeliveryDetail.Button.Text = "Save Delivery";
            var newSize = 6.5f;
            ucSaveDeliveryDetail.Button.Font = new Font(ucSaveDeliveryDetail.Button.Font.Name, newSize);
        }

        private void DeliveryToOutletForm_Load(object sender, EventArgs e)
        {
            ucScanBarcodeDisplay1.InitializeControls(_presenter.UsingScanner);
            InitializeObjects();
            _presenter.InitializeControlsToDefaultState();

            if (!string.IsNullOrEmpty(_packingNumber))
            {
                _presenter.LoadDeliveryOutletToView(_packingNumber);
            }

        }

        private void InitializeObjects()
        {
            this.ParentDeliveryToOutlet = new Model.DeliveryToOutlet();
            this.SelectedDeliveryToOutletDetails = new List<Model.DeliveryToOutletDetail>();
            txtQuantity.Text = "1";
            
        }

        private void InitializeEvents()
        {
            ucSaveDeliveryDetail.SaveButtonClick += new EventHandler<EventArgs>(ucSaveDeliveryDetail_SaveButtonClick);
            ucScanBarcodeDisplay1.OnCheckProductCodeOrScanner += new EventHandler(ucScanBarcodeDisplay1_OnCheckProductCodeOrScanner);            
            ucScanBarcodeDisplay1.OnStockNumberComboBoxKeyPress += new EventHandler<KeyPressEventArgs>(ucScanBarcodeDisplay1_OnStockNumberComboBoxKeyPress);
            ucScanBarcodeDisplay1.OnStockNumberComboBoxSelectedIndex += new EventHandler(ucScanBarcodeDisplay1_OnStockNumberComboBoxSelectedIndex);
            ucScanBarcodeDisplay1.OnColorAutoCompleteLeave += new EventHandler(ucScanBarcodeDisplay1_OnColorAutoCompleteLeave);
            ucScanBarcodeDisplay1.OnWashingAutoCompleteLeave += new EventHandler(ucScanBarcodeDisplay1_OnWashingAutoCompleteLeave);
            ucScanBarcodeDisplay1.OnSizeAutoCompleteLeave += new EventHandler(ucScanBarcodeDisplay1_OnSizeAutoCompleteLeave);
        }

        void ucScanBarcodeDisplay1_OnSizeAutoCompleteLeave(object sender, EventArgs e)
        {
            _presenter.OnProductDetailChanges();
        }

        void ucScanBarcodeDisplay1_OnWashingAutoCompleteLeave(object sender, EventArgs e)
        {
            _presenter.OnProductDetailChanges();
        }

        void ucScanBarcodeDisplay1_OnColorAutoCompleteLeave(object sender, EventArgs e)
        {
            _presenter.OnProductDetailChanges();
        }

        void ucScanBarcodeDisplay1_OnStockNumberComboBoxSelectedIndex(object sender, EventArgs e)
        {
            _presenter.LoadSelectedProduct();
        }

        void ucScanBarcodeDisplay1_OnStockNumberComboBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                _presenter.LoadProducts();
                if (_presenter.UsingScanner)
                {
                    Presenter_OnScanAction(sender, new ScannerResponse { ItemCode = GetStockNumber() });
                    ucScanBarcodeDisplay1.ClearInputText();
                }
            }
        }

      

        void ucScanBarcodeDisplay1_OnCheckProductCodeOrScanner(object sender, EventArgs e)
        {
            _presenter.OnSelectBarcodeSwitch();
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

        public void LoadDeliveryToOutlet(Model.DeliveryToOutlet deliveryToOutlet)
        {
            ucAutoCompleteStore.AutoCompleteValue = deliveryToOutlet.Outlet.Name;
            txtDrNo.Text = deliveryToOutlet.PackingListNumber;
            txtDrNo.ReadOnly = true;
            ucAutoCompleteStore.Enabled = false;
            dtpDateDelivered.Enabled = false;
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
            ucScanBarcodeDisplay1.SizeAutoCompleteControl.AutoCompleteValue = productDetails.Size.Name;
            ucScanBarcodeDisplay1.ColorAutoCompleteControl.AutoCompleteValue = productDetails.Color.Name;
            ucScanBarcodeDisplay1.WashingAutoCompleteControl.AutoCompleteValue = productDetails.Washing.Name;
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
            if (!ucScanBarcodeDisplay1.ChkBarcodeOrStockNumberControl.Checked)
            {
                return;
            }
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
            ucScanBarcodeDisplay1.StockNumberComboBoxControl.SelectedIndex = 0;
        }

        public void LoadProducts(List<Model.Product> list)
        {
            ucScanBarcodeDisplay1.LoadProducts(list);
        }

        
        public Model.Product GetSelectedProduct()
        {
            return ucScanBarcodeDisplay1.GetSelectedProduct();
        }

        public void LoadColors(List<Model.Color> list)
        {
            ucScanBarcodeDisplay1.LoadColors(list);   
        }

        public void LoadWashings(List<Model.Washing> list)
        {
            ucScanBarcodeDisplay1.LoadWashings(list);
        }

        public void LoadSizes(List<Model.Size> list)
        {
            ucScanBarcodeDisplay1.LoadSizes(list);
        }

        public string GetColorCode()
        {
            return ucScanBarcodeDisplay1.GetColorCode();
        }

        public string GetWashingCode()
        {
            return ucScanBarcodeDisplay1.GetWashingCode();
        }

        public string GetSizeCode()
        {
            return ucScanBarcodeDisplay1.GetSizeCode();
        }

        public bool GetSelectByProductCode()
        {
            return ucScanBarcodeDisplay1.ChkBarcodeOrStockNumberControl.Checked;
        }

        public void DisabledProductDetail(bool disable)
        {
            ucScanBarcodeDisplay1.DisabledProductDetail(disable);
        }

        public void RenameStockOrCodeLabel(string label)
        {
            ucScanBarcodeDisplay1.RenameStockOrCodeLabel(label);
        }

        public void LoadProducts(List<Model.ProductDetails> list)
        {
            ucScanBarcodeDisplay1.LoadProducts(list);
        }

        public Model.ProductDetails GetSelectedProductDetails()
        {
            return ucScanBarcodeDisplay1.GetSelectedProductDetails();
        }

        public void ClearProductDetailControls()
        {
            ucScanBarcodeDisplay1.ClearProductDetailControls();
        }

        public void SetSelectByBarcodeTo(bool selectByBarcode)
        {
            ucScanBarcodeDisplay1.SetSelectByBarcodeTo(selectByBarcode); 
        }

       
        public string GetStockNumber()
        {
            return ucScanBarcodeDisplay1.GetStockNumber();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _presenter.AddDeliveryToOutletDetail(() => 
                {
                    _presenter.BuildProductDetailIntoPanel(dgvItem);
                    EnableSaveButton(true);
                });            
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
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var administrator = Enum.GetName(typeof(RoleType), RoleType.Administrator);
            var allowedAccess = Thread.CurrentPrincipal.IsInRole(administrator);

            if (!allowedAccess)
            {
                MessageBox.Show("Access denied!");
                return;
            }

            var form = new DeliveryToOutletEditForm(_container, ParentDeliveryToOutlet.Id);
            form.OnUpdateDeliveryDetail += new EventHandler(form_OnChangesDeliveryDetail);
            form.OnDeactivateDeliveryDetail += new EventHandler(form_OnChangesDeliveryDetail);
            form.ShowDialog();

            if (_editForm == null)
            {
                _editForm = new DeliveryToOutletEditForm(_container, ParentDeliveryToOutlet.Id);
                _editForm.OnUpdateDeliveryDetail += new EventHandler(form_OnChangesDeliveryDetail);
                _editForm.OnDeactivateDeliveryDetail += new EventHandler(form_OnChangesDeliveryDetail);
                _editForm.ShowDialog();
            }
        }
        
        void form_OnChangesDeliveryDetail(object sender, EventArgs e)
        {
            _presenter.LoadDeliveryOutletToView(_packingNumber);
        }

        private void DeliveryToOutletForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormsHelper.CloseAllOpenFormsWithName("ScannerForm", "DeliveryToOutletEditForm");            
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new DeliveryToOutletPrintForm(_container
                , ParentDeliveryToOutlet.Id);
            form.ShowDialog();
        }

        private void txtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ucScanBarcodeDisplay1.FocusOnInputText();
            }
        }

        private void ucAutoCompleteStore_Leave(object sender, EventArgs e)
        {
            _presenter.StoreDetailChange();
        }

        private void txtDrNo_TextChanged(object sender, EventArgs e)
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
            ucScanBarcodeDisplay1.WashingAutoCompleteControl.AutoCompleteValue = washing;
        }
    }
}
