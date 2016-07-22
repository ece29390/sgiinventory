using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Helpers;
using SGInventory.Views;
using SGInventory.Presenters;
using SGInventory.Model;
using SGInventory.UserControls;
using SGInventory.Presenters.Model;

namespace SGInventory.ProductForm
{
    public partial class ProductSearchForm : Form,IProductSearchView
    {
        private ProductSearchPresenter _presenter;
        private BusinessModelContainer _container;

        public ProductSearchForm(BusinessModelContainer container)
        {
            InitializeComponent();

            //FormsHelper.ApplySearchViewSetting(this);
            StartPosition = FormStartPosition.CenterScreen;
            Size = new System.Drawing.Size(790, 476);
            _container = container;
            _presenter = new ProductSearchPresenter(this, container.ProductBusinessModel);
            this.ucAddDelete1.AddButtonClick += new EventHandler<EventArgs>(ucAddDelete1_AddButtonClick);
            this.ucAddDelete1.DeleteButtonClick += new EventHandler<EventArgs>(ucAddDelete1_DeleteButtonClick);
        }

        void ucAddDelete1_DeleteButtonClick(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you sure you want to deactivate the selected item(s)?", "Deactivating Product Detail", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
            {
                return;
            }

            var models = new List<ProductSearchDisplayModel>();

            foreach (DataGridViewRow row in productDataGridView.Rows)
            {
                if ((bool)row.Cells["colCheckBox"].FormattedValue)
                {
                    models.Add((ProductSearchDisplayModel)row.DataBoundItem);
                }

            }

            if (models.Count > 0)
            {
                _presenter.DeactivateProductDetailsOfAllSelectedModels(models);
                _presenter.SearchProduct(userControlSearch1.GetSearchTextValue(), userControlSearch1.GetSearchBy());
            }
                        
        }

        void ucAddDelete1_AddButtonClick(object sender, EventArgs e)
        {
            _presenter.OpenEditForm();
        }


        public void LoadModel(List<Model.Product> list)
        {
            _presenter.LoadToGrid(productDataGridView, list);
        }

        public void OpenEditForm()
        {
            var form = new ProductEditForm(_container,null,null,null);
            form.OnModelUpdateSuccessful += new EventHandler<CustomEventArgs.ModelEventArgs<Product>>(form_OnModelUpdateSuccessful);
            form.Show();
        }

        void form_OnModelUpdateSuccessful(object sender, CustomEventArgs.ModelEventArgs<Product> e)
        {
            var searchText = userControlSearch1.GetSearchTextValue();
            var searchBy = userControlSearch1.GetSearchBy();
            _presenter.SearchProduct(searchBy, searchText);                     
        }

        public Model.Product ConvertToModel(object dataBoundItem)
        {
            return (Product)dataBoundItem;
        }

        public void OpenEditForm(Model.Product model)
        {           
            var productDetail = model.ProductDetails.FirstOrDefault();
            var form = new ProductEditForm(_container, model.StockNumber, productDetail.Color.Code, productDetail.Washing.Code);
            form.OnModelUpdateSuccessful+=new EventHandler<CustomEventArgs.ModelEventArgs<Product>>(form_OnModelUpdateSuccessful);
            form.Show();
        }

        public DialogResult ConfirmationPopUpYesNo(string message)
        {
            return MessageBox.Show(message, "Delete Confirmation", MessageBoxButtons.YesNo);
        }

        public void DeletedPopUpMessage(string message)
        {
            MessageBox.Show(message);
        }

        public List<Model.Product> GetSelectedModels()
        {
            var products= FormsHelper.GetSelectedModel<Model.Product>("colCheckBox", productDataGridView);           
            return products;
        }

        private void ProductSearchForm_Load(object sender, EventArgs e)
        {
            _presenter.LoadModels();

            productDataGridView.AutoGenerateColumns = false;            
            userControlSearch1._OnSearch += new EventHandler<UserControls.SeachArgs>(userControlSearch1__OnSearch);
            LoadUserSearchParameters();
        }

        private void LoadUserSearchParameters()
        {
            var searchModels = new List<SearchModel>
            {
                new SearchModel{Code=SgiHelper.SEARCH_ALL,Description = "All"},
                new SearchModel{Code=SgiHelper.PRODUCT_SEARCH_STOCKNUMBER,Description = "Stock Number"},
                new SearchModel{Code=SgiHelper.PRODUCT_SEARCH_CATEGORYNAME,Description = "Category"}                
            };

            userControlSearch1.LoadToSearchByComboBox(searchModels);
        }

        void userControlSearch1__OnSearch(object sender, UserControls.SeachArgs e)
        {
            _presenter.SearchProduct(e.SearchParams.SeachParamBy,e.SearchParams.SearchParamValue);
        }

        private void productDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var columnName = productDataGridView.Columns[e.ColumnIndex].Name;         
            switch (columnName)
            {
                case "colStockNumber":
                    _presenter.LaunchProduct(productDataGridView.Rows[e.RowIndex].DataBoundItem);
                    break;
                case "colAddProductDetail":
                    var model = (Product)productDataGridView.Rows[e.RowIndex].DataBoundItem;
                    model.ProductDetails = _container.ProductDetailBusinessModel.SelectByParent(model);
                    var form = new ProductDetailSearchForm(_container, model);
                    form.Show();
                    break;
            }
        }

        private void productDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
         
        }

        public void DeactivateProductDetail(ProductDetails pd)
        {
            _container.ProductDetailBusinessModel.DeactivateProductDetail(pd);
        }

        public bool IsActive
        {
            get
            {
                return rbIsActive.Checked;
            }
            set
            {
                rbIsActive.Checked = value;
                rbNonActive.Checked = !value;
            }
        }


        public string SearchText
        {
            get { return userControlSearch1.GetSearchTextValue(); }
        }

        public string SearchBy
        {
            get { return userControlSearch1.GetSearchBy(); }
        }
    }
}
