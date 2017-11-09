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
        private bool _isEdit;

        public string TransactionNumber
        {
            get
            {
                return labelTransactionNumber.Text;
            }

            set
            {
                labelTransactionNumber.Text = value;
            }
        }

        public SalesEditForm(
            BusinessModelContainer container         
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
                ,_container.DeliveryToOutletBusinessModel
                );

            _presenter.DisplayListOfSalesOnAdd += new EventHandler<DisplaySalesArg>(_presenter_DisplayListOfSalesOnAdd);

            
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
            }
        }
                
        private void SalesEditForm_Load(object sender, EventArgs e)
        {
            dataGridViewListOfSales.AllowUserToAddRows = false;
            userControlSelectProduct1.OnEnter += UserControlSelectProduct1_OnEnter;
            userControlSelectProduct1.OnManuallySelected += UserControlSelectProduct1_OnManuallySelected;
            ucACOutlet.AfterSelecting += UcACOutlet_OnChanges;
          
            _presenter.InitializeControl(_salesId);
        }

        private void UcACOutlet_OnChanges(object sender, EventArgs e)
        {
            if(_isEdit)
            {
                return;
            }
            var outlet = GetSelectedOutlet();
            userControlSelectProduct1.Enabled = !string.IsNullOrEmpty(outlet);
            if(userControlSelectProduct1.Enabled)
            {
                userControlSelectProduct1.Focus();
            }
        }

        private void UserControlSelectProduct1_OnManuallySelected(object sender, CustomEventArgs.ScanCodeArgs e)
        {
            buttonAddSales_Click(null, null);
        }

        private void UserControlSelectProduct1_OnEnter(object sender, CustomEventArgs.ScanCodeArgs e)
        {
            _presenter.OnRetrievingProduct(e.Code, e.IsBarCode);
        }

        private void buttonAddSales_Click(object sender, EventArgs e)
        {
            var enterQuantityForm =
                new EnterQuantityForm(
                    userControlSelectProduct1.SelectedProductDetails.Description,
                    userControlSelectProduct1.SelectedProductDetails.ProductCode
                    );
            enterQuantityForm.ShowDialog();
            if(enterQuantityForm.Quantity<=0)
            {
                ShowMessage("Invalid Quantity");
                return;
            }
            ncQuantity.Numeric = enterQuantityForm.Quantity;
            
            if(_presenter.VerifyIfQuantityIsEnough(enterQuantityForm.Quantity))
            {
                _presenter.AddSales();
            }
            else
            {
                ShowMessage(string.Format(SalesEditPresenter.InsufficientQuantityErrorFormat, GetSelectedOutlet()));
            }      
                   
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
                _presenter.LoadOtherSalesWithSameTransaction(sales);
            }
            bindingSourceSales.DataSource = sales;
            if (sales.Outlet != null)
            {
                ucACOutlet.AutoCompleteValue = sales.Outlet.Name;
            }
        }

        public void LoadProducts(List<Product> list)
        {
            
        }

        public Product GetSelectedProduct()
        {
            throw new NotImplementedException("Method has not been implemented");
        }

        public void LoadColors(List<Model.Color> list)
        {
           
        }

        public void LoadWashings(List<Washing> list)
        {
           
        }

        public void LoadSizes(List<Model.Size> list)
        {
            
        }

        public bool GetSelectByProductCode()
        {
            throw new NotImplementedException("Method has not been implemented");
        }

        public void DisabledProductDetail(bool disable)
        {
            userControlSelectProduct1.Enabled = !disable;
        }

        public void RenameStockOrCodeLabel(string label)
        {
           
        }

        public void LoadProducts(List<ProductDetails> list)
        {
            userControlSelectProduct1.LoadResult(list
                , (pd) => pd.Product.MarkdownPrice > 0 
                ? pd.Product.MarkdownPrice 
                : pd.Product.RegularPrice);
        }

        public ProductDetails GetSelectedProductDetails()
        {
            throw new NotImplementedException("Method has not been implemented");
        }

        public void ClearProductDetailControls()
        {
            
        }

        public void SetSelectByBarcodeTo(bool selectByBarcode)
        {
           
        }

        public string GetStockNumber()
        {
            throw new NotImplementedException("Method has not been implemented");
        }

        public string GetColorCode()
        {
            throw new NotImplementedException("Method has not been implemented");
        }

        public string GetWashingCode()
        {
            throw new NotImplementedException("Method has not been implemented");
        }

        public string GetSizeCode()
        {
            throw new NotImplementedException("Method has not been implemented");
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
            
        }

        void Presenter_OnScanAction(object sender, ScannerResponse e)
        {
          
        }

        public void EnableAddButton(bool enable)
        {
            buttonAddSales.Enabled = enable;
        }


        public void SetBarcodeAs(ProductDetails productDetail)
        {
            LoadProducts(new List<ProductDetails> { productDetail });
          
        }


        public void SetWashingCode(string washing)
        {
           
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }


        public Model.Sales GetSalesObject()
        {
            var sales = (Model.Sales)bindingSourceSales.DataSource;
            sales.DateOfSales = sales.DateOfSales.Date;
            sales.Outlet = new Outlet { Id = ucACOutlet.AutoCompleteId.Value };
            sales.ProductDetail = _presenter.BuildProductDetail();
            sales.Quantity = (int)ncQuantity.Numeric;
            sales.TransactionNumber = labelTransactionNumber.Text.Trim();
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
            sales.TransactionNumber = labelTransactionNumber.Text;
            LoadSales(sales);                      
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
            
        }

        public void LoadSizes(Model.Size size)
        {
            
        }

        public void LoadWashings(Washing washing)
        {
           
        }

        public int GetOutletId()
        {
            return ucACOutlet.AutoCompleteId.Value;
        }

        public string GetSelectedOutlet()
        {
            return ucACOutlet.AutoCompleteValue;
        }

        public void TriggerAddSales()
        {
            buttonAddSales_Click(null, null);
        }

        public string GetSelectedProductCode()
        {
            return userControlSelectProduct1.SelectedProductDetails.ProductCode;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            _presenter.UpdateSales();
        }

        public void ShowEditControls(bool shouldShow)
        {
            label3.Visible = shouldShow;
            ncQuantity.Visible = shouldShow;
            buttonUpdate.Visible = shouldShow;
        }

        public void SetEditMode(bool setToEditMode)
        {
            _isEdit = setToEditMode;
        }
    }
}
