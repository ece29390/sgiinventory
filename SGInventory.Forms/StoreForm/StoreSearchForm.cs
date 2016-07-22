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

namespace SGInventory.StoreForm
{
    public partial class StoreSearchForm : Form, IStoreSearchView
    {
        private BusinessModelContainer _container;
        private StoreSearchPresenter _storeSearchPresenter;
        private Business.Model.IStoreBusinessModel _businessModel;

        public StoreSearchForm()
        {
            InitializeComponent();
          
        }

        public StoreSearchForm(BusinessModelContainer container)
        {
            // TODO: Complete member initialization
            this._container = container;
            InitializeComponent();

            ucAddDelete1.AddButtonClick += new EventHandler<EventArgs>(ucAddDelete1_AddButtonClick);
            ucAddDelete1.DeleteButtonClick += new EventHandler<EventArgs>(ucAddDelete1_DeleteButtonClick);

            _storeSearchPresenter = new StoreSearchPresenter(this, container.StoreBusinessModel);
            _businessModel = container.StoreBusinessModel;
        }

        void ucAddDelete1_DeleteButtonClick(object sender, EventArgs e)
        {
            _storeSearchPresenter.DeleteSelectedModels();
        }

        void ucAddDelete1_AddButtonClick(object sender, EventArgs e)
        {
            _storeSearchPresenter.OpenEditForm();
        }

        public void LoadModel(List<Model.Store> list)
        {
            storeSearchGrid.AutoGenerateColumns = false;
            storeSearchGrid.DataSource = list;
        }

        public void OpenEditForm()
        {
            var form = new StoreEditForm(_businessModel);
            form.OnModelUpdateSuccessful += new EventHandler<CustomEventArgs.ModelEventArgs<Model.Store>>(form_OnModelUpdateSuccessful);
            form.Show();
        }

        public Model.Store ConvertToModel(object dataBoundItem)
        {
            return (Model.Store)dataBoundItem;
        }

        public void OpenEditForm(Model.Store model)
        {
            var form = new StoreEditForm(_businessModel, model);
            form.OnModelUpdateSuccessful += new EventHandler<CustomEventArgs.ModelEventArgs<Model.Store>>(form_OnModelUpdateSuccessful);
            form.Show();
        }

        void form_OnModelUpdateSuccessful(object sender, CustomEventArgs.ModelEventArgs<Model.Store> e)
        {
            LoadModel(e.ModelList);
        }

        public DialogResult ConfirmationPopUpYesNo(string message)
        {
            return MessageBox.Show(message, "Delete Confirmation", MessageBoxButtons.YesNo);
        }

        public void DeletedPopUpMessage(string message)
        {
            MessageBox.Show(message);
        }

        public List<Model.Store> GetSelectedModels()
        {
            return FormsHelper.GetSelectedModel<Model.Store>("colId", storeSearchGrid);
        }

        private void StoreSearchForm_Load(object sender, EventArgs e)
        {
            _storeSearchPresenter.LoadModels();
        }

        private void storeSearchGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var columnName = storeSearchGrid.Columns[e.ColumnIndex].Name;
            if (columnName == "colCode")
            {
                _storeSearchPresenter.PopulateModelToEditForm
                    (
                        columnName
                        , storeSearchGrid.Rows[e.RowIndex].DataBoundItem
                    );
            }
        }
    }
}
