using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.DAL;
using SGInventory.Enums;

namespace SGInventory.Business.Model
{
    public class ProductDetailBusinessModel:IProductDetailBusinessModel
    {
        private Dal.IProductDetailDal _productDetailDal;

        public ProductDetailBusinessModel(Dal.IProductDetailDal productDetailDal)
        {         
            this._productDetailDal = productDetailDal;
        }

        public List<SGInventory.Model.ProductDetails> SelectAll()
        {
            return _productDetailDal.SelectAll();
        }

        public SGInventory.Model.ProductDetails SelectByPrimaryId(string id)
        {
            return _productDetailDal.SelectPrimaryEntity<string>(id);
        }

        public bool Valid(SGInventory.Model.ProductDetails model)
        {
            return true;
        }

        public void Delete(SGInventory.Model.ProductDetails model)
        {
            _productDetailDal.Delete(model);
        }

        public void CreateOrUpdate(SGInventory.Model.ProductDetails model)
        {
            _productDetailDal.SaveOrUpdate(model);       
        }

        public string Save(SGInventory.Model.ProductDetails model)
        {
            var modelName ="Product Detail";
            var barcode = string.IsNullOrEmpty(model.Code) ? "" : model.Code;
            var dbProductDetail = SelectByPrimaryId(model.Code);
            if (dbProductDetail != null && !string.IsNullOrEmpty(dbProductDetail.Code))
            {
                return string.Format("{0} already Exists", modelName);
            }

            CreateOrUpdate(model);
            return string.Format("A {0} has been saved", modelName);
        }

        public List<ProductDetails> SelectByParent(Product parentEntity)
        {
            return _productDetailDal.SelectByParent(parentEntity);
        }

        public List<ProductDetails> SearchByBarcode(string barcode)
        {
            return _productDetailDal.SelectByBarcode(barcode);
        }


        public List<ProductDetails> SelectAllActiveByParent(Product model)
        {
            return _productDetailDal.SelectActiveByParent(model);
        }


        public List<ProductDetails> SelectByStockNumber(string code)
        {
            return _productDetailDal.SelectByStockNumber(code);
        }

        public void DeactivateProductDetail(ProductDetails productDetail)
        {
            productDetail.IsActive = 0;
            _productDetailDal.SaveOrUpdate(productDetail);
        }


        public List<DAL.ProductInventoryView> SelectProductInterviewBy(string stock)
        {
            var parameters = new Dictionary<string, object>();
          
            var query = !string.IsNullOrEmpty(stock) ? "CALL SelectProductInterviewBy(:stock)" : "SelectProductInterview";

            if (!string.IsNullOrEmpty(stock))
            {
                parameters.Add("stock", stock);
            }

            var retValue = _productDetailDal.SelectProductInterviewBy(query, parameters);
            return retValue;
        }

        public ProductDetails SelectByStockNumberAndColorAndSize(string stockNumber, string color, string size)
        {
            return _productDetailDal.SelectByStockNumberAndColorAndSizeAndStatus(stockNumber, color, size, true);
        }

        public List<ProductDetails> GetActiveAvailableProductForSales(string code, int outletId, ProductStatus goods, bool isBarcode)
        {
            List<ProductDetails> result =
                isBarcode ? _productDetailDal.SelectAvailableActiveProductForSaleUsingProductCode(code, outletId, (int)goods)
                : _productDetailDal.SelectAvailableActiveProductForSaleUsingStockNumber(code, outletId, (int)goods);
            return result;
        }
    }
}
