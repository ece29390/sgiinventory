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
using SGInventory.Presenters.Model;

namespace SGInventory.Sales
{
    public partial class SalesSearchForm : Form,ISalesSearchView
    {
        private SalesSearchPresenter _presenter;
        private BusinessModelContainer _container;

        public SalesSearchForm(BusinessModelContainer container)
        {
            InitializeComponent();
            _container = container;
            _presenter = new SalesSearchPresenter(
                container.SalesBusinessModel
                ,container.OutletBusinessModel
                ,this
                );
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            _presenter.Search();
        }

        private void SalesSearchForm_Load(object sender, EventArgs e)
        {
            _presenter.Initialize();
        }

        public void LoadOutlets(List<Model.Outlet> outlets)
        {
            ucACOutlet.LoadAutoCompleteIdNameSource(outlets);
        }

        public void LoadSales(List<Model.Sales> sales)
        {
            List<SalesDisplayModel> displaySales = _presenter.ConvertToListOfSalesDisplayModel(sales);
            bindingSourceListOfSales.DataSource = displaySales;
        }

        public void LoadSales(Model.Sales sale)
        {
            if (sale.Id == 0)
            {
                sale.DateOfSales = dtpDateOfSales.Value;
            }
            bindingSourceSales.DataSource = sale;
        }

        public Model.Sales GetSales()
        {
            var sales = (Model.Sales)bindingSourceSales.DataSource;
            if (!string.IsNullOrEmpty(ucACOutlet.AutoCompleteValue))
            {
                sales.Outlet = new Outlet { Id = ucACOutlet.AutoCompleteId.Value };
            }
            else
            {
                sales.Outlet = null;
            }

            return sales;
        }

        private void dataGridViewListOfSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var dataPropertyName = dataGridViewListOfSales.Columns[e.ColumnIndex].DataPropertyName;

                if (dataPropertyName == "Id")
                {                    
                    var salesDisplayModel = (SalesDisplayModel)dataGridViewListOfSales.Rows[e.RowIndex].DataBoundItem;
                    SalesEditForm editForm= new SalesEditForm(_container, salesDisplayModel.Id);
                    editForm._OnFormClosingEventArgs += new EventHandler<FormClosingEventArgs>(editForm__OnFormClosingEventArgs);
                    editForm.ShowDialog();
                   
                }
            }
        }

        void editForm__OnFormClosingEventArgs(object sender, FormClosingEventArgs e)
        {
            _presenter.Search();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
