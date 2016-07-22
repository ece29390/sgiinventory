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
using SGInventory.Business.Model;
using SGInventory.Model;
namespace SGInventory.OutletForm
{
    public partial class OutletSearchForm : Form,IOutletSearchView
    {
        private OutletSearchPresenter _outletSearchPresenter;
        private BusinessModelContainer _container;
        
        public OutletSearchForm(BusinessModelContainer container)
        {
            InitializeComponent();
            FormsHelper.ApplySearchViewSetting(this);

            ucNameAddress1.OnCellContentClick += new EventHandler<DataGridViewCellEventArgs>(ucNameAddress1_OnCellContentClick);
            ucAddDelete1.AddButtonClick += new EventHandler<EventArgs>(ucAddDelete1_AddButtonClick);
            ucAddDelete1.DeleteButtonClick += new EventHandler<EventArgs>(ucAddDelete1_DeleteButtonClick);

            _outletSearchPresenter = new OutletSearchPresenter(this, container.OutletBusinessModel);
            _container = container;
        }

        void ucAddDelete1_DeleteButtonClick(object sender, EventArgs e)
        {
            _outletSearchPresenter.DeleteSelectedModels();
        }

        void ucAddDelete1_AddButtonClick(object sender, EventArgs e)
        {
            _outletSearchPresenter.OpenEditForm();
        }

        void ucNameAddress1_OnCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var columnName = ucNameAddress1.NameAddressView.Columns[e.ColumnIndex].Name;

            if (columnName == "colName")
            {
                _outletSearchPresenter.PopulateModelToEditForm(
                columnName,
                ucNameAddress1.NameAddressView.Rows[e.RowIndex].DataBoundItem);
            }
            
        }

        public void LoadModel(List<Model.Outlet> list)
        {
            ucNameAddress1.LoadData<Outlet>(list);
        }

        public void OpenEditForm()
        {
            OutletEditForm form = new OutletEditForm(_container);
            form.OnModelUpdateSuccessful+=new EventHandler<CustomEventArgs.ModelEventArgs<Outlet>>(form_OnModelUpdateSuccessful);
            form.Show();
        }

        public Model.Outlet ConvertToModel(object dataBoundItem)
        {
            return (Outlet)dataBoundItem;

        }

        public void OpenEditForm(Model.Outlet model)
        {
            OutletEditForm form = new OutletEditForm(_container, model);
            form.OnModelUpdateSuccessful += new EventHandler<CustomEventArgs.ModelEventArgs<Outlet>>(form_OnModelUpdateSuccessful);
            form.Show();
        }

        void form_OnModelUpdateSuccessful(object sender, CustomEventArgs.ModelEventArgs<Outlet> e)
        {
            LoadModel(e.ModelList);
        }

        public DialogResult ConfirmationPopUpYesNo(string message)
        {
            return MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo);
        }

        public void DeletedPopUpMessage(string message)
        {
            MessageBox.Show(message);
        }

        public List<Model.Outlet> GetSelectedModels()
        {
            return FormsHelper.GetSelectedModel<Outlet>("colId", ucNameAddress1.NameAddressView);
        }

        private void OutletSearchForm_Load(object sender, EventArgs e)
        {
            _outletSearchPresenter.LoadModels();
        }
    }
}
