using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Views;
using Ninject;
using SGInventory.Presenters;
using SGInventory.Business.Model;
using SGInventory.Helpers;

namespace SGInventory.CategoryForm
{
    public partial class CategorySearchForm : Form,ICategorySearchView
    {
        private CategorySearchPresenter _categorySearchPresenter;
        private ICategoryBusinessModel _businessModel;
        


        public CategorySearchForm(BusinessModelContainer container)
        {
            InitializeComponent();

            
            this.ucAddDelete1.AddButtonClick += new EventHandler<EventArgs>(ucAddDelete1_AddButtonClick);
            this.ucAddDelete1.DeleteButtonClick += new EventHandler<EventArgs>(ucAddDelete1_DeleteButtonClick);

            FormsHelper.ApplySearchViewSetting(this);

            _businessModel = container.CategoryBusinessModel;
            _categorySearchPresenter = new CategorySearchPresenter(this, _businessModel);

        }

      

        void ucAddDelete1_DeleteButtonClick(object sender, EventArgs e)
        {
            _categorySearchPresenter.DeleteSelectedModels();
        }

        void ucAddDelete1_AddButtonClick(object sender, EventArgs e)
        {
            _categorySearchPresenter.OpenEditForm();
        }

        public void LoadModel(List<Model.Category> list)
        {                     
              categoryDataView.AutoGenerateColumns = false;
              categoryDataView.DataSource = list;
            
        }

        private void CategorySearchForm_Load(object sender, EventArgs e)
        {
            _categorySearchPresenter.LoadModels();
        }

        public void OpenEditForm()
        {
            var categoryEditForm = new CategoryEditForm(_businessModel);
            categoryEditForm.OnModelUpdateSuccessful += new EventHandler<CustomEventArgs.ModelEventArgs<Model.Category>>(categoryEditForm_OnModelUpdateSuccessful);
            categoryEditForm.Show();
        }

        void categoryEditForm_OnModelUpdateSuccessful(object sender, CustomEventArgs.ModelEventArgs<Model.Category> e)
        {
            LoadModel(e.ModelList);
        }

        private void categoryDataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var columnName =categoryDataView.Columns[e.ColumnIndex].Name;
            if (columnName == "colName")
            {
                _categorySearchPresenter.PopulateModelToEditForm
                    (
                        columnName
                        , categoryDataView.Rows[e.RowIndex].DataBoundItem
                    );
            }
        }

        public Model.Category ConvertToModel(object dataBoundItem)
        {
            return (Model.Category)dataBoundItem;
        }

        public void OpenEditForm(Model.Category category)
        {
            var categoryEditForm = new CategoryEditForm(_businessModel, category);
            categoryEditForm.OnModelUpdateSuccessful+=new EventHandler<CustomEventArgs.ModelEventArgs<Model.Category>>(categoryEditForm_OnModelUpdateSuccessful);
            categoryEditForm.Show();
            
        }


        public DialogResult ConfirmationPopUpYesNo(string message)
        {
            return MessageBox.Show(message, "Delete Confirmation", MessageBoxButtons.YesNo);
        }

        public void DeletedPopUpMessage(string message)
        {
            MessageBox.Show(message);
        }

        public List<Model.Category> GetSelectedModels()
        {
            return FormsHelper.GetSelectedModel<Model.Category>("colId", categoryDataView);
        }
    }
}
