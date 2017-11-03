using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Dal;
using SGInventory.Common.Interfaces;
using SGInventory.DAL;
using SGInventory.Enums;

namespace SGInventory.Business.Model
{
    public interface IProductDetailBusinessModel : ISelectAll<ProductDetails>, ISelectByPrimary<ProductDetails, string>, IValidate<ProductDetails>, IBusinessTransact<ProductDetails>, ISave<ProductDetails>,ISelectByParent<Product,ProductDetails>
    {
        List<ProductDetails> SearchByBarcode(string barcode);

        List<ProductDetails> SelectAllActiveByParent(Product model);

        List<ProductDetails> SelectByStockNumber(string code);

        void DeactivateProductDetail(ProductDetails productDetail);

        List<ProductInventoryView> SelectProductInterviewBy(string stock);

        ProductDetails SelectByStockNumberAndColorAndSize(string stockNumber, string color, string size);
        List<ProductDetails> GetActiveAvailableProductForSales(string code, int outletId, ProductStatus goods, bool isBarcode);
    }
}
