using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Presenters;
using SGInventory.Views;
using SGInventory.Model;
using SGInventory.Enums;

namespace SGInventory.Delivery
{
    public partial class DeliveryToOutletSearchForm : Form,IDeliveryToOutletSearchView
    {
        private BusinessModelContainer _container;
        private DeliveryToOutletSearchPresenter _presenter;
        public DeliveryToOutletSearchForm(BusinessModelContainer container)
        {
            InitializeComponent();

            _container = container;

            InitializeObjectsAndControls();
            
        }

        private void InitializeObjectsAndControls()
        {
            _presenter = new DeliveryToOutletSearchPresenter(
                this,
                _container.OutletBusinessModel,
                _container.DeliveryToOutletBusinessModel);

            ucSearchBy.SaveButtonClick += new EventHandler<EventArgs>(ucSearchBy_SaveButtonClick);
            ucSearchBy.Button.Text = "Search";
            ucOutlet.InsideTextChange += new EventHandler<EventArgs>(ucOutlet_InsideTextChange);
            gvDeliveries.AutoGenerateColumns = false;
            gvDeliveries.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(gvDeliveries_DataBindingComplete);
        }

        void gvDeliveries_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
            DeliveryToOutlet deliveryToOutlet = null;
            foreach (DataGridViewRow row in gvDeliveries.Rows)
            {
                deliveryToOutlet = (SGInventory.Model.DeliveryToOutlet)row.DataBoundItem;
                row.Cells["colOutletName"].Value = deliveryToOutlet.Outlet.Name;
                deliveryToOutlet = null;
            }
        }

        private void gvDeliveries_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
               
                _presenter.LoadSelectedDelivery(e.RowIndex);
            }

        }

        private void cboSearchMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            _presenter.OnSelectedSearchModeChange(GetSearchMode());
        }

        void ucOutlet_InsideTextChange(object sender, EventArgs e)
        {
            EnableSearchButton(string.IsNullOrEmpty(ucOutlet.AutoCompleteValue) ? false : true);
        }

        void ucSearchBy_SaveButtonClick(object sender, EventArgs e)
        {
            _presenter.Search();
        }

        public void LoadOutlets(List<Outlet> outlets)
        {
            ucOutlet.LoadAutoCompleteIdNameSource(outlets);
        }

        public void LoadSearchMode(List<Enums.DeliveryToOutletSearchMode> searchModes)
        {
            cboSearchMode.DataSource = searchModes;
        }

        public Enums.DeliveryToOutletSearchMode GetSearchMode()
        {
            return (Enums.DeliveryToOutletSearchMode)cboSearchMode.SelectedItem;
        }

        public Outlet GetOutlet()
        {
            var outletId = ucOutlet.AutoCompleteId;
            Outlet outlet = null;

            if(outletId.HasValue)
            {
                outlet = _container.OutletBusinessModel.SelectByPrimaryId(outletId.Value);
            }

            return outlet;            
        }

        public void LoadSearchDeliveries(List<DeliveryToOutlet> searchLists)
        {
            gvDeliveries.DataSource = searchLists;
        }

        public DeliveryToOutlet GetSelectedDeliveryToOutlet(int selectedIndex)
        {
            var retValue = (DeliveryToOutlet)gvDeliveries.Rows[selectedIndex].DataBoundItem;
            return retValue;
        }
        
        public void OpenDeliveryToOutletEditForm(DeliveryToOutlet deliveryToOutlet)
        {
            var status = (ProductStatus)deliveryToOutlet.DeliveryToOutletDetails.First().Status;
            var form = new DeliveryToOutletForm(_container, deliveryToOutlet.PackingListNumber, status);
            form.ShowDialog();
        }

        public void EnableSearchButton(bool enable)
        {
            ucSearchBy.EnabledButton(enable);
        }

        public DateTime GetDeliveryDateFrom()
        {
            return ucDateRangeFilter1.GetDeliveryDateFrom();
        }

        public DateTime GetDeliveryDateTo()
        {
            return ucDateRangeFilter1.GetDeliveryDateTo();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void DeliveryToOutletSearchForm_Load(object sender, EventArgs e)
        {
            _presenter.InitialLoad();
        }


        public void OpenDeliveryToOutletEditForm(DeliveryToOutlet deliveryToOutlet, bool useScanner)
        {
            throw new NotImplementedException();
        }
    }
}
