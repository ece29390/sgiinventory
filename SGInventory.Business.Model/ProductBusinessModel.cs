using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Dal;
using SGInventory.Model;
using System.Text.RegularExpressions;
using SGInventory.Business.Model.Aspect;
using SGInventory.Business.Model.Response;

namespace SGInventory.Business.Model
{
    public class ProductBusinessModel:IProductBusinessModel
    {
        private Dal.IProductDal _iProductDal;
        private Dal.IProductDetailDal _productDetail;

        public ProductBusinessModel(Dal.IProductDal iProductDal, Dal.IProductDetailDal productDetailDal)
        {            
            this._iProductDal = iProductDal;
            this._productDetail = productDetailDal;
        }

        public string Save(Product model)
        {
            var modelName = "Product";          
            if (!model.ModifiedDate.HasValue)
            {
                var match = Regex.IsMatch(model.StockNumber, @"^[a-zA-Z0-9\-]+$");

                if (!match)
                {
                    return "Only accepts alphanumerics and a dash characters";
                }

                if(Valid(model))
                {
                    CreateOrUpdate(model);
                    return string.Format("A new {0} has been added", modelName);
                }
                else
                {
                    return string.Format("{0} Already Exists", modelName);
                }
                
            }

            CreateOrUpdate(model);
                       
            return string.Format("{0} has been updated",modelName);                   
        }

        public List<Product> SelectAll()
        {
            var products = _iProductDal.SelectAll();
            products = GetDistinctStockNumber(products);
            return products;
        }

        public Product SelectByPrimaryId(string id)
        {
            var product = _iProductDal.SelectPrimaryEntity<string>(id);
            if (product!=null && product.ProductDetails != null)
            {
                product.ProductDetails = product.ProductDetails.Where(p => p.IsActive == 1).ToList();
            }
            
            return product;
        }

        public bool Valid(Product model)
        {
            var product = _iProductDal.SelectPrimaryEntity<string>(model.StockNumber);
            if (product == null || string.IsNullOrEmpty(product.StockNumber))
            {
                return true;
            }
            return false;
        }

        public void Delete(Product model)
        {
            _iProductDal.Delete(model);
        }

        public void CreateOrUpdate(Product model)
        {
            _iProductDal.SaveOrUpdate(model);
        }

        public List<Product> SelectByStockNumber(string stockNumber)
        {
            var products = _iProductDal.SelectByStockNumber(stockNumber);

            products = (from product in products.AsEnumerable()
                        group product by new { product.StockNumber,product.ProductDetails } into productGroup
                        select new Product
                        {
                            StockNumber = productGroup.Key.StockNumber,
                            ProductDetails = productGroup.Key.ProductDetails
                        }).ToList<Product>();


            return products;
        }

        public string SaveUsingTransaction(Product model)
        {
            var modelName = "Product";
            List<ProductDetails> productDetails = _productDetail.SelectActiveByParent(model);
            if (!model.ModifiedDate.HasValue)
            {
                var match = Regex.IsMatch(model.StockNumber, @"^[a-zA-Z0-9\-]+$");

                if (!match)
                {
                    return "Only accepts alphanumerics and a dash characters";
                }

                if (Valid(model))
                {
                    _iProductDal.SaveTransaction(model, productDetails);
                    return string.Format("A new {0} has been added", modelName);
                }
                else
                {
                    return string.Format("{0} Already Exists", modelName);
                }

            }

            _iProductDal.SaveTransaction(model, productDetails);

            return string.Format("{0} has been updated", modelName);      
        }

        [GenericValidate]
        public string SaveUsingTransaction(string modelName, Product model, Product dbModel, Color selectedColor, Washing selectedWashing)
        {   
            
            List<ProductDetails> productDetails = _productDetail.SelectActiveByParent(model);

            productDetails = productDetails.Where(pd => pd.Color.Code == selectedColor.Code && pd.Washing.Code == selectedWashing.Code).ToList();
             
            _iProductDal.SaveTransaction(model, productDetails);

            return string.Format("{0} has been saved", modelName);  
        }

        public List<Product> SelectBySearch(string searchBy, string searchValue)
        {
            var result = _iProductDal.SelectBySearch(searchBy, searchValue);
            result = GetDistinctStockNumber(result);
            return result;
        }

        private List<Product> GetDistinctStockNumber(List<Product> products)
        {
            var retValue = new List<Product>();

            retValue = (from product in products
                        group product by new { StockNumber = product.StockNumber, Product = product} into productGroup
                        select new Product
                        {
                            StockNumber = productGroup.Key.StockNumber,
                            Category = productGroup.Key.Product.Category,
                            Cost = productGroup.Key.Product.Cost,
                            CreatedBy = productGroup.Key.Product.CreatedBy,
                            CreatedDate = productGroup.Key.Product.CreatedDate,
                            Description = productGroup.Key.Product.Description,
                            MarkdownPrice = productGroup.Key.Product.MarkdownPrice,
                            ModifiedBy = productGroup.Key.Product.ModifiedBy,
                            ModifiedDate = productGroup.Key.Product.ModifiedDate,
                            ProductDetails = productGroup.Key.Product.ProductDetails,
                            RegularPrice = productGroup.Key.Product.RegularPrice
                        }).ToList<Product>();

            return retValue;
        }

        public List<ProductPricesHistory> GetProductHistoryByStockNumber(string stockNumber)
        {
            var result = _iProductDal.GetProductHistoryByStockNumber(stockNumber);
            result = TrimProductHistoryIntoDistinct(result);
            return result;
        }

        private List<ProductPricesHistory> TrimProductHistoryIntoDistinct(List<ProductPricesHistory> productHistory)
        {
            productHistory = (from ph in productHistory
                              group ph by new { Id = ph.Id, ProductHistory = ph } into phGroup
                              select new ProductPricesHistory
                              {
                                  Cost = phGroup.Key.ProductHistory.Cost,
                                  CreatedBy = phGroup.Key.ProductHistory.CreatedBy,
                                  CreatedDate = phGroup.Key.ProductHistory.CreatedDate,
                                  Id = phGroup.Key.Id,
                                  MarkdownPrice = phGroup.Key.ProductHistory.MarkdownPrice,
                                  RegularPrice = phGroup.Key.ProductHistory.RegularPrice,
                                  StockNumber = phGroup.Key.ProductHistory.StockNumber
                              }).ToList<ProductPricesHistory>();

            return productHistory;
        }

        public Product SelectBy(string stockNumber, string colorCode, string washingCode)
        {
            var product = _iProductDal.SelectPrimaryEntity(stockNumber);                        

            var productDetails = (from pd in product.ProductDetails
                                  where pd.Color.Code.Equals(colorCode, StringComparison.InvariantCultureIgnoreCase)
                                  && pd.Washing.Code.Equals(washingCode, StringComparison.InvariantCultureIgnoreCase)
                                  select pd).ToList();

            product.ProductDetails = productDetails;

            return product;
        }

        private Product CreateNewProduct(Product product)
        {
            var retValue = new Product 
            {
                Category = product.Category,
                Cost = product.Cost,
                CreatedBy = product.CreatedBy,
                CreatedDate = product.CreatedDate,
                Description = product.Description,
                MarkdownPrice = product.MarkdownPrice,
                ModifiedBy = product.ModifiedBy,
                ModifiedDate = product.ModifiedDate,
                PriceHistory = product.PriceHistory,
                ProductDetails = new List<ProductDetails>(),
                RegularPrice = product.RegularPrice,
                StockNumber = product.StockNumber
            };

            return retValue;
        }

        public Product SelectBothActiveAndNonActiveByPrimaryId(string stockNumber)
        {
            var product = _iProductDal.SelectPrimaryEntity<string>(stockNumber);           
            return product;
        }
    }
}
