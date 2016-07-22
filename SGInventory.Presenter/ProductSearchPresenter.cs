using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Business.Model;
using SGInventory.Views;
using System.Windows.Forms;
using SGInventory.Presenters.Model;
using SGInventory.Helpers;

namespace SGInventory.Presenters
{
    public class ProductSearchPresenter : SearchPresenterBase<Product, IProductBusinessModel, string>
    {
        private IProductSearchView _productSearchView;
        private IProductBusinessModel _productBusinessModel;

        public List<Product> SearchProducts { get; private set; }

        public ProductSearchPresenter(IProductSearchView iProductSearchView, IProductBusinessModel iProductBusinessModel)
            :base(iProductSearchView,iProductBusinessModel)
        {
            _productSearchView = iProductSearchView;
            _productBusinessModel = iProductBusinessModel;
            SearchProducts = new List<Product>();
        }

        public override void LoadModels()
        {
            if (SearchProducts.Count > 0)
            {
                base._view.LoadModel(SearchProducts);
            }
            else
            {
                base.LoadModels();
            }
            
        }

        public void SearchProduct(string searchBy, string searchValue)
        {
            SearchProducts = _productBusinessModel.SelectBySearch(searchBy, searchValue);
            
            LoadModels();
        }

        public void LoadToGrid(DataGridView gridView, List<Product> products)
        {
            var isActive = _productSearchView.IsActive ? 1 : 0;

            var searchProducts = products                                   
                                .Select(p => p)
                                .SelectMany<Product, ProductSearchDisplayModel>(product =>
                                {
                                    var colorWashingProductDetails =
                                        (from pd in product.ProductDetails   
                                         where pd.IsActive == isActive
                                         group pd by new { StockNumber = pd.Product.StockNumber, Cost = pd.Product.Cost, MarkdownPrice = pd.Product.MarkdownPrice, RegularPrice = pd.Product.RegularPrice, Category = pd.Product.Category.Name, Description = pd.Product.Description, ColorCode = pd.Color.Code, WashingCode = pd.Washing.Code,ColorName = pd.Color.Name,WashingName = pd.Washing.Name } into pdGroup
                                         select new ProductSearchDisplayModel
                                         {
                                             StockNumber = pdGroup.Key.StockNumber,
                                             Cost = pdGroup.Key.Cost,
                                             RegularPrice = pdGroup.Key.RegularPrice,
                                             MarkdownPrice = pdGroup.Key.MarkdownPrice,
                                             Description = pdGroup.Key.Description,
                                             Category = pdGroup.Key.Category,
                                             ColorCode = pdGroup.Key.ColorCode,
                                             WashingCode = pdGroup.Key.WashingCode,
                                             ColorName = pdGroup.Key.ColorName,
                                             WashingName = pdGroup.Key.WashingName
                                             
                                         });

                                    return colorWashingProductDetails;
                                }).ToList<ProductSearchDisplayModel>();

            gridView.AutoGenerateColumns = false;
            gridView.DataSource = searchProducts;
                
                
        }

        public void LaunchProduct(object databoundItem)
        {
            var seachProductDisplayModel = (ProductSearchDisplayModel)databoundItem;

            var product = _businessModel.SelectBy(seachProductDisplayModel.StockNumber, seachProductDisplayModel.ColorCode, seachProductDisplayModel.WashingCode);

            _view.OpenEditForm(product);

        }

        public void DeactivateProductDetailsOfAllSelectedModels(List<ProductSearchDisplayModel> models)
        {
            models.ForEach(m => {
                
                var product = _businessModel.SelectBy(m.StockNumber, m.ColorCode, m.WashingCode);

                var productDetails = product.ProductDetails.ToList();

                productDetails.ForEach(pd => _productSearchView.DeactivateProductDetail(pd));

            });

            SearchProduct(_productSearchView.SearchBy, _productSearchView.SearchText);
            
        }
    }
}
