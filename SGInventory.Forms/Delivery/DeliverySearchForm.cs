using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Views;
using SGInventory.Model;
using SGInventory.Presenters;

namespace SGInventory.Delivery
{
    public partial class DeliverySearchForm : Form, ISupplierSearchDeliveryView
    {
        private BusinessModelContainer _container;
        private SupplierSearchDeliveryPresenter _presenter;
        public DeliverySearchForm(BusinessModelContainer container)
        {
            InitializeComponent();
            _container = container;
            _presenter = new SupplierSearchDeliveryPresenter(
                this,
                container.SupplierBusinessModel,
                container.DeliveryBusinessModel);
            ucSearchBy.SaveButtonClick += new EventHandler<EventArgs>(ucSearchBy_SaveButtonClick);
            ucSearchBy.Button.Text = "Search";
            ucSupplier.InsideTextChange += new EventHandler<EventArgs>(ucSupplier_InsideTextChange);
            gvDeliveries.AutoGenerateColumns = false;
            gvDeliveries.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(gvDeliveries_DataBindingComplete);
        }

        void gvDeliveries_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SGInventory.Model.Delivery delivery = null;
            foreach (DataGridViewRow row in gvDeliveries.Rows)
            {
                delivery = (SGInventory.Model.Delivery)row.DataBoundItem;
                row.Cells["colSupplierName"].Value = delivery.Supplier.Name;
                delivery = null;
            }
            
        }

        void ucSupplier_InsideTextChange(object sender, EventArgs e)
        {
            EnableSearchButton(string.IsNullOrEmpty(ucSupplier.AutoCompleteValue) ? false : true);
        }

        void ucSearchBy_SaveButtonClick(object sender, EventArgs e)
        {
            _presenter.Search();
        }

        private void cboSearchMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            _presenter.OnSelectedSearchModeChange(GetSearchMode());
        }

        private void DeliverySearchForm_Load(object sender, EventArgs e)
        {
            _presenter.InitialLoad();
        }

        public void LoadSuppliers(List<Model.Supplier> list)
        {
            ucSupplier.LoadAutoCompleteIdNameSource<Supplier>(list);
        }

        public string GetSupplierName()
        {
            return ucSupplier.AutoCompleteValue;
        }

        public void LoadSearchMode(List<Enums.SupplierSearchDeliveryMode> list)
        {
            cboSearchMode.DataSource = list;
        }

        public Enums.SupplierSearchDeliveryMode GetSearchMode()
        {
            return (Enums.SupplierSearchDeliveryMode)cboSearchMode.SelectedItem;
        }

        public void LoadSearchDeliveries(List<Model.Delivery> list)
        {
            gvDeliveries.DataSource = list;
        }

        public DateTime GetDeliveryDateFrom()
        {
            return ucDateRangeFilter1.GetDeliveryDateFrom();
        }

        public Model.Delivery GetSelectedDelivery(int selectedRow)
        {
            var delivery = (SGInventory.Model.Delivery)gvDeliveries.Rows[selectedRow].DataBoundItem;           
            return delivery;
        }

      

        public void OpenSupplierDeliveryEditForm(Model.Delivery delivery)
        {
            var supplierDeliveryForm = new SupplierDeliveryForm(_container, delivery.Id);
            supplierDeliveryForm.ShowDialog();
        }

        public void EnableSearchButton(bool p)
        {
            ucSearchBy.EnabledButton(p);
        }

        private void gvDeliveries_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {               
                _presenter.LoadSelectedDelivery(e.RowIndex);
            }
            
        }

        public DateTime GetDeliveryDateTo()
        {
            return ucDateRangeFilter1.GetDeliveryDateTo();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
