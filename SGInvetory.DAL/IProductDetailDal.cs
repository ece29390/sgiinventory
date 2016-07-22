using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Common.Interfaces;
using SGInventory.DAL;

namespace SGInventory.Dal
{
    public interface IProductDetailDal : ICrud<ProductDetails>,ISelectByParent<Product,ProductDetails>
    {
        List<ProductDetails> SelectByBarcode(string code);

        List<ProductDetails> SelectActiveByParent(Product model);

        List<ProductDetails> SelectByStockNumber(string code);

        List<ProductInventoryView> SelectProductInterviewBy(string spName,Dictionary<string, object> parameters);

        ProductDetails SelectByStockNumberAndColorAndSizeAndStatus(string stockNumber, string color, string size, bool p);
    }
}
