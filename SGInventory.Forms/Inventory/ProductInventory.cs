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
using SGInventory.DAL;

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

            var productDetails =
                _container.ProductDetailBusinessModel.SelectAllActiveByParent(new Product { StockNumber = stockNumber });

            var groupProductDetail = (from productDetail in productDetails
                                      orderby productDetail.Color.Name
                                      group productDetail by productDetail.Color.Code into pGroup
                                      select new { ColorCode = pGroup.Key}).ToList();

            var listOfProductInventoryView = new List<ProductInventoryView>();

            groupProductDetail.ForEach(code => {
                var result = (from productDetail in productDetails
                              where productDetail.Color.Code.Equals(code.ColorCode)
                              //orderby productDetail.Size.Name
                              select new ProductInventoryView
                              {
                                  ColorName = productDetail.Color.Name
                                  ,
                                  ProductDetailCode = productDetail.Code
                                  ,
                                  SizeName = productDetail.Size.Name
                                  ,
                                  StockNumber = productDetail.Product.StockNumber
                                  ,
                                  WashingName = productDetail.Washing.Name
                                  ,
                                  Quantity = GetAvailableQuantity(productDetail)
                              }
                              ).ToList();

                result.Sort(new ProductInventoryViewComparer());
                listOfProductInventoryView.AddRange(result);
            });
                        
            dgvInventoryStock.DataSource = listOfProductInventoryView;
            
        }

        private int GetAvailableQuantity(ProductDetails productDetail)
        {
            var supplierDeliveryQuantity = productDetail.DeliveryDetails != null && productDetail.DeliveryDetails.Count > 0
                ? productDetail.DeliveryDetails.
                Where(dd=>dd.IsActive==1).GroupBy(dd=>dd.Id).Select(dd=>dd.First()).Sum(dd=>dd.Quantity) : 0;

            var deliveryToOutletQuantity =
                productDetail.DeliveryToOutletDetails != null && productDetail.DeliveryToOutletDetails.Count > 0
                ? productDetail.DeliveryToOutletDetails.Where(dd => dd.IsActive == 1).GroupBy(dd => dd.Id).Select(dd => dd.First()).Sum(dd => dd.Quantity) : 0;

            var availableQuantity = supplierDeliveryQuantity - deliveryToOutletQuantity;
            return availableQuantity;
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
