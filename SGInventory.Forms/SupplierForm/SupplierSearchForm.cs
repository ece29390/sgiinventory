using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Views;
using SGInventory.Helpers;
using SGInventory.Presenters;
using SGInventory.Model;

namespace SGInventory.SupplierForm
{
    public partial class SupplierSearchForm : Form,ISupplierSearchView
    {
        private SupplierSearchPresenter _supplierSearchPresenter;
        private BusinessModelContainer _container;

        public SupplierSearchForm(BusinessModelContainer container)
        {
            InitializeComponent();
            FormsHelper.ApplySearchViewSetting(this);

            _container = container;
            _supplierSearchPresenter = new SupplierSearchPresenter(this, container.SupplierBusinessModel);
            ucAddDelete1.AddButtonClick += new EventHandler<EventArgs>(ucAddDelete1_AddButtonClick);
            ucAddDelete1.DeleteButtonClick += new EventHandler<EventArgs>(ucAddDelete1_DeleteButtonClick);
            ucNameAddress1.OnCellContentClick += new EventHandler<DataGridViewCellEventArgs>(ucNameAddress1_OnCellContentClick);
        }

        void ucNameAddress1_OnCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var columnName = ucNameAddress1.NameAddressView.Columns[e.ColumnIndex].Name;

            if (columnName == "colName")
            {
                _supplierSearchPresenter.PopulateModelToEditForm(
               columnName,
               ucNameAddress1.NameAddressView.Rows[e.RowIndex].DataBoundItem);
            }
           
        }

        void ucAddDelete1_DeleteButtonClick(object sender, EventArgs e)
        {
            _supplierSearchPresenter.DeleteSelectedModels();
        }

        void ucAddDelete1_AddButtonClick(object sender, EventArgs e)
        {
            _supplierSearchPresenter.OpenEditForm();
        }

        public void LoadModel(List<Model.Supplier> list)
        {
            ucNameAddress1.LoadData<Supplier>(list);
        }

        public void OpenEditForm()
        {
            var form = new SupplierEditForm(_container);
            form.OnModelUpdateSuccessful += new EventHandler<CustomEventArgs.ModelEventArgs<Supplier>>(form_OnModelUpdateSuccessful);
            form.Show();
        }

        void form_OnModelUpdateSuccessful(object sender, CustomEventArgs.ModelEventArgs<Supplier> e)
        {
            LoadModel(e.ModelList);
        }

        public Model.Supplier ConvertToModel(object dataBoundItem)
        {
            return (Supplier)dataBoundItem;
        }

        public void OpenEditForm(Model.Supplier model)
        {
            var form = new SupplierEditForm(_container, model);
            form.OnModelUpdateSuccessful += new EventHandler<CustomEventArgs.ModelEventArgs<Supplier>>(form_OnModelUpdateSuccessful);
            form.Show();
        }

        public DialogResult ConfirmationPopUpYesNo(string message)
        {
            return MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo);
        }

        public void DeletedPopUpMessage(string message)
        {
            MessageBox.Show(message);
        }

        public List<Model.Supplier> GetSelectedModels()
        {
            return FormsHelper.GetSelectedModel<Supplier>("colId", ucNameAddress1.NameAddressView);
        }

        private void SupplierSearchForm_Load(object sender, EventArgs e)
        {
            _supplierSearchPresenter.LoadModels();
        }


    }
}
