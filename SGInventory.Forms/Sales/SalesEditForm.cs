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
using SGInventory.Delivery;
using SGInventory.Presenters.Model;
using SGInventory.Helpers;

namespace SGInventory.Sales
{
    public partial class SalesEditForm : Form,ISalesEditView
    {
        public event EventHandler<FormClosingEventArgs> _OnFormClosingEventArgs;
        private BusinessModelContainer _container;
        private int? _salesId;
        private SalesEditPresenter _presenter;

        public SalesEditForm(
            BusinessModelContainer container
            ,bool usescanner
            ,int? salesid = null
            )
        {
            InitializeComponent();
            _container = container;
            _salesId = salesid;

            _presenter = new SalesEditPresenter(
                this
                , _container.SalesBusinessModel
                , _container.OutletBusinessModel
                ,_container.ProductBusinessModel
                ,_container.ProductDetailBusinessModel
                , _container.ColorBusinessModel
                ,_container.SizeBusinessModel
                ,_container.WashingBusinessModel
                ,usescanner
                );

            _presenter.DisplayListOfSalesOnAdd += new EventHandler<DisplaySalesArg>(_presenter_DisplayListOfSalesOnAdd);

            ucManualEntryDisplay1.InitializeControls(usescanner);
            ucManualEntryDisplay1.OnCheckProductCodeOrScanner += new EventHandler(ucManualEntryDisplay1_OnCheckProductCodeOrScanner);
            ucManualEntryDisplay1.OnChkBoxUseScanner += new EventHandler(ucManualEntryDisplay1_OnChkBoxUseScanner);
            ucManualEntryDisplay1.OnStockNumberComboBoxKeyPress += new EventHandler<KeyPressEventArgs>(ucManualEntryDisplay1_OnStockNumberComboBoxKeyPress);
            ucManualEntryDisplay1.OnStockNumberComboBoxSelectedIndex += new EventHandler(ucManualEntryDisplay1_OnStockNumberComboBoxSelectedIndex);
            ucManualEntryDisplay1.OnColorAutoCompleteLeave += new EventHandler(ucManualEntryDisplay1_OnColorAutoCompleteLeave);
            ucManualEntryDisplay1.OnWashingAutoCompleteLeave += new EventHandler(ucManualEntryDisplay1_OnWashingAutoCompleteLeave);
            ucManualEntryDisplay1.OnSizeAutoCompleteLeave += new EventHandler(ucManualEntryDisplay1_OnSizeAutoCompleteLeave);
        }

        void _presenter_DisplayListOfSalesOnAdd(object sender, DisplaySalesArg e)
        {
            bindingSourceListOfSales.DataSource = e.ListOfSalesForDisplay;
        }

        void ucManualEntryDisplay1_OnStockNumberComboBoxSelectedIndex(object sender, EventArgs e)
        {
            _presenter.LoadSelectedProduct();
        }

        void ucManualEntryDisplay1_OnSizeAutoCompleteLeave(object sender, EventArgs e)
        {
            _presenter.LoadProductDetail();
        }

        void ucManualEntryDisplay1_OnWashingAutoCompleteLeave(object sender, EventArgs e)
        {
            _presenter.LoadProductDetail();
        }

        void ucManualEntryDisplay1_OnColorAutoCompleteLeave(object sender, EventArgs e)
        {
            _presenter.LoadProductDetail();
        }

       
        void ucManualEntryDisplay1_OnStockNumberComboBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                _presenter.LoadProducts();
                buttonAddSales.Focus();
                //if (_presenter.ShouldUseScanner)
                //{
                //    Presenter_OnScanAction(sender, new ScannerResponse { ItemCode = GetStockNumber() });
                //    ucManualEntryDisplay1.ClearInputText();
                //}
                                               
            }
        }

        void ucManualEntryDisplay1_OnChkBoxUseScanner(object sender, EventArgs e)
        {
            _presenter.UseScanner(ucManualEntryDisplay1.ChkBarcodeOrStockNumberControl.Checked);
        }

        void ucManualEntryDisplay1_OnCheckProductCodeOrScanner(object sender, EventArgs e)
        {
            _presenter.OnSelectBarcodeSwitch();
        }

        private void SalesEditForm_Load(object sender, EventArgs e)
        {
            dataGridViewListOfSales.AllowUserToAddRows = false;
            _presenter.InitializeControl(_salesId);
        }

        private void buttonAddSales_Click(object sender, EventArgs e)
        {
            if (ncQuantity.Numeric == 0)
            {
                ShowMessage("Invalid Quantity");
                return;
            }
            _presenter.AddSales();
            ucManualEntryDisplay1.FocusOnInputText();
        }

        public void LoadOutlets(List<Outlet> outlets)
        {
            ucACOutlet.LoadAutoCompleteIdNameSource(outlets);
        }

        public void LoadSales(Model.Sales sales)
        {
            if (sales.Id == 0)
            {
                sales.DateOfSales = dtpDateOfSales.Value;
            }
            else
            {
                buttonAddSales.Enabled = true;  
            }
            
            bindingSourceSales.DataSource = sales;
            if (sales.Outlet != null)
            {
                ucACOutlet.AutoCompleteValue = sales.Outlet.Name;
            }
           
            if (sales.ProductDetail != null)
            {
                ucManualEntryDisplay1.LoadProductDetail(sales.ProductDetail);  
            }
                   
        }

        public void LoadProducts(List<Product> list)
        {
            ucManualEntryDisplay1.LoadProducts(list);
        }

        public Product GetSelectedProduct()
        {
            return ucManualEntryDisplay1.GetSelectedProduct();
        }

        public void LoadColors(List<Model.Color> list)
        {
            ucManualEntryDisplay1.LoadColors(list);  
        }

        public void LoadWashings(List<Washing> list)
        {
            ucManualEntryDisplay1.LoadWashings(list);
        }

        public void LoadSizes(List<Model.Size> list)
        {
            ucManualEntryDisplay1.LoadSizes(list);
        }

        public bool GetSelectByProductCode()
        {
            return ucManualEntryDisplay1.GetSelectByProductCode();
        }

        public void DisabledProductDetail(bool disable)
        {
            ucManualEntryDisplay1.DisabledProductDetail(disable);
        }

        public void RenameStockOrCodeLabel(string label)
        {
            ucManualEntryDisplay1.RenameStockOrCodeLabel(label);
        }

        public void LoadProducts(List<ProductDetails> list)
        {
            ucManualEntryDisplay1.LoadProducts(list);
        }

        public ProductDetails GetSelectedProductDetails()
        {
            return ucManualEntryDisplay1.GetSelectedProductDetails();
        }

        public void ClearProductDetailControls()
        {
            ucManualEntryDisplay1.ClearProductDetailControls();
        }

        public void SetSelectByBarcodeTo(bool selectByBarcode)
        {
            ucManualEntryDisplay1.SetSelectByBarcodeTo(selectByBarcode);
        }

        public string GetStockNumber()
        {
            return ucManualEntryDisplay1.GetStockNumber();
        }

        public string GetColorCode()
        {
            return ucManualEntryDisplay1.GetColorCode();
        }

        public string GetWashingCode()
        {
            return ucManualEntryDisplay1.GetWashingCode();
        }

        public string GetSizeCode()
        {
            return ucManualEntryDisplay1.GetSizeCode();
        }

        public void ShowScannerWindow(bool shouldusescanner)
        {
            if (shouldusescanner)
            {
                var window = new ScannerForm();
                window.Presenter.OnScanAction += new EventHandler<ScannerResponse>(Presenter_OnScanAction);
                window.OnScannerFormClosing += new EventHandler<EventArgs>(window_OnScannerFormClosing);
                window.Show();
            }
        }

        void window_OnScannerFormClosing(object sender, EventArgs e)
        {
            ucManualEntryDisplay1.ChkBarcodeOrStockNumberControl.Checked = false;
        }

        void Presenter_OnScanAction(object sender, ScannerResponse e)
        {
            if (!ucManualEntryDisplay1.ChkBarcodeOrStockNumberControl.Checked)
            {
                return;
            }
            var isValid = _presenter.ValidateItemCodeAfterScanning(e.ItemCode);

            if (isValid)
            {
                buttonAddSales_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Scanned barcode not exists!");
            }
        }

        public void EnableAddButton(bool enable)
        {
            buttonAddSales.Enabled = enable;
        }


        public void SetBarcodeAs(ProductDetails productDetail)
        {
            LoadProducts(new List<ProductDetails> { productDetail });
            ucManualEntryDisplay1.StockNumberComboBoxControl.SelectedIndex = 0;
        }


        public void SetWashingCode(string washing)
        {
            ucManualEntryDisplay1.WashingAutoCompleteControl.AutoCompleteValue = washing;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }


        public Model.Sales GetSalesObject()
        {
            var sales = (Model.Sales)bindingSourceSales.DataSource;
            sales.Outlet = new Outlet { Id = ucACOutlet.AutoCompleteId.Value };
            if (_presenter.ShouldUseScanner)
            {
                sales.ProductDetail = GetSelectedProductDetails();
            }
            else
            {
                sales.ProductDetail = _presenter.BuildProductDetail();
                
            }
            
            return sales;
        }

        private void dataGridViewListOfSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                 var salesDisplayModel = (SalesDisplayModel)dataGridViewListOfSales.Rows[e.RowIndex].DataBoundItem;
                if (dataGridViewListOfSales.Columns[e.ColumnIndex].DataPropertyName == "Id")
                {                   
                    _presenter.LoadExistingSales(salesDisplayModel.Id);
                }
                else if(dataGridViewListOfSales.Columns[e.ColumnIndex].DataPropertyName =="DeleteDescription")
                {
                    _presenter.DeleteExistingSales(salesDisplayModel.Id); 
                }
            }
        }


        public void ResetControls()
        {
            var sales = new Model.Sales { DateOfSales = dtpDateOfSales.Value };
            LoadSales(sales);            
            ucManualEntryDisplay1.ClearInputText();

        }

        private void SalesEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_OnFormClosingEventArgs != null)
            {
                _OnFormClosingEventArgs(sender, e);
            }
        }

        public void LoadColor(Model.Color color)
        {
            ucManualEntryDisplay1.ColorAutoCompleteControl.AutoCompleteValue = color.Name;
        }

        public void LoadSizes(Model.Size size)
        {
            ucManualEntryDisplay1.SizeAutoCompleteControl.AutoCompleteValue = size.Name;
        }

        public void LoadWashings(Washing washing)
        {
            ucManualEntryDisplay1.WashingAutoCompleteControl.AutoCompleteValue = washing.Name;
        }
    }
}
