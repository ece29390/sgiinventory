using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using SGInventory.Helpers;
using SGInventory.Views;
using SGInventory.Presenters;
using SGInventory.Business.Model;
using SGInventory.Model;
using System.Linq;
namespace SGInventory.ProductForm
{
    public partial class ProductDetailSearchForm : Form,IProductDetailSearchView
    {
        private readonly ProductDetailSearchPresenter _searchPresenter;
        private readonly BusinessModelContainer _container;
        private readonly Product _product;
        public ProductDetailSearchForm(BusinessModelContainer container,Product product)
        {
            InitializeComponent();

            ProductDetailSearchGridView.AutoGenerateColumns = false;
            FormsHelper.ApplySearchViewSetting(this);

            ucAddDelete1.AddButtonClick += new EventHandler<EventArgs>(ucAddDelete1_AddButtonClick);
            ucAddDelete1.DeleteButtonClick += new EventHandler<EventArgs>(ucAddDelete1_DeleteButtonClick);

            _container = container;
            _product = product;
            _searchPresenter = new ProductDetailSearchPresenter(this, _container.ProductDetailBusinessModel, product);        
        }

        void ucAddDelete1_DeleteButtonClick(object sender, EventArgs e)
        {
            _searchPresenter.DeleteSelectedModels();
        }

        void ucAddDelete1_AddButtonClick(object sender, EventArgs e)
        {
            _searchPresenter.OpenEditForm();
        }

        private void ProductDetailSearchForm_Load(object sender, EventArgs e)
        {
            _searchPresenter.LoadModels();
        }
     
        public void OpenEditForm()
        {
            var form = new ProductDetailEditForm(_container, new ProductDetails { Product = _product});
            form.OnModelUpdateSuccessful+=new EventHandler<CustomEventArgs.ModelEventArgs<ProductDetails>>(form_OnModelUpdateSuccessful);
            form.ShowDialog();
        }

        public Model.ProductDetails ConvertToModel(object databoundItem)
        {
            var productDetail = (ProductDetails)databoundItem;
            return productDetail;
        }

        public void OpenEditForm(Model.ProductDetails productDetail)
        {
            var form = new ProductDetailEditForm(_container, productDetail);
            form.OnModelUpdateSuccessful += new EventHandler<CustomEventArgs.ModelEventArgs<ProductDetails>>(form_OnModelUpdateSuccessful);
            form.ShowDialog();
        }

        void form_OnModelUpdateSuccessful(object sender, CustomEventArgs.ModelEventArgs<ProductDetails> e)
        {
            LoadModel(e.ModelList);
        }

        public List<Model.ProductDetails> GetSelectedModels()
        {            
            return FormsHelper.GetSelectedModel<Model.ProductDetails>("colId", ProductDetailSearchGridView);
        }

        public DialogResult ConfirmationPopUpYesNo(string message)
        {
           return MessageBox.Show(message,"Confirmation",MessageBoxButtons.YesNo);
        }

        public void DeletedPopUpMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void ProductDetailSearchGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ProductDetails productDetail=null;
            foreach (DataGridViewRow dataGridViewRow in ProductDetailSearchGridView.Rows)
            {
                productDetail = (ProductDetails)dataGridViewRow.DataBoundItem;
                dataGridViewRow.Cells["colColor"].Value = productDetail.Color.Name;
                dataGridViewRow.Cells["colSize"].Value = productDetail.Size.Name;
                dataGridViewRow.Cells["colWashing"].Value = productDetail.Washing.Name;

                productDetail = null;
            }
        
        }

        private void ProductDetailSearchGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var columnName = ProductDetailSearchGridView.Columns[e.ColumnIndex].Name;
            if (columnName == "colBarcode")
            {
                _searchPresenter.PopulateModelToEditForm
                    (
                        columnName
                        , ProductDetailSearchGridView.Rows[e.RowIndex].DataBoundItem
                    );
            }
        }

        public void LoadModel(IList<ProductDetails> list)
        {
            foreach (var productDetail in list)
            {
                if (!productDetail.OverrideCost.HasValue)
                {
                    productDetail.OverrideCost = _product.Cost;
                }
            }

            ProductDetailSearchGridView.DataSource = list;
        }
    }
}
