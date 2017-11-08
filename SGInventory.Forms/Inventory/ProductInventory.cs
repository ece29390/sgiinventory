using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Model;
using SGInventory.Dal;
using SGInventory.Presenters;

namespace SGInventory.Inventory
{
    public partial class ProductInventory : Form
    {
        private BusinessModelContainer _container;
        private const string ColumnViewHistoryKey = "colViewHistory";

        public ProductInventory(BusinessModelContainer container)
        {
            InitializeComponent();
            _container = container;
        }

        private void ProductInventory_Load(object sender, EventArgs e)
        {
            InitializeData();
            InitializeEvents();
        }

        private void InitializeData()
        {
           var products = _container.ProductBusinessModel.SelectAll();
           var autoStringCollection = new AutoCompleteStringCollection();
           products.ForEach(p => autoStringCollection.Add(p.StockNumber));
           ucAutoComplete1.LoadAutoComplete(autoStringCollection);
        }

        public void InitializeEvents()
        {
            ucAutoComplete1.AutoCompleteKeyup += new EventHandler<KeyEventArgs>(ucAutoComplete1_AutoCompleteKeyup);
        }

        void ucAutoComplete1_AutoCompleteKeyup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchByOrSearchAll_Click(sender, e);
            }
        }

        private void btnSearchByOrSearchAll_Click(object sender, EventArgs e)
        {
            var stockNumber = ucAutoComplete1.AutoCompleteValue;

            if (string.IsNullOrEmpty(stockNumber))
            {
                MessageBox.Show("Stock Number is empty");
                return;
            }
          
            var listOfProductInventoryView = _container.ProductDetailBusinessModel.SelectProductInterviewBy(stockNumber);
            listOfProductInventoryView.Sort(new ProductInventoryViewComparer());

            var listOfProductInventoryViewModel = AutoMapper.Mapper.Map<List<ProductInventoryViewModel>>(listOfProductInventoryView);
            

            dgvInventoryStock.DataSource = listOfProductInventoryViewModel;
            
        }
                
        private void dgvInventoryStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1)
            {
                var name = dgvInventoryStock.Columns[e.ColumnIndex].Name;

                if (name == ColumnViewHistoryKey)
                {
                    var productInventoryView = (ProductInventoryView)dgvInventoryStock.Rows[e.RowIndex].DataBoundItem;
                    var form = new ViewHistory(productInventoryView,_container);
                    form.OnFormClosing += new EventHandler(form_OnFormClosing);
                    form.ShowDialog();
                }
            }
        }

        void form_OnFormClosing(object sender, EventArgs e)
        {
            btnSearchByOrSearchAll_Click(sender, e);
        }       
      
    }
}
