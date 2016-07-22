using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Dal
{
    public interface IProductDal : ICrud<Product>
    {
        List<Product> SelectByStockNumber(string stockOrBarcode);

        void SaveTransaction(Product model);

        void SaveTransaction(Product model, List<ProductDetails> productDetails);

        List<Product> SelectBySearch(string searchBy, string searchValue);

        List<ProductPricesHistory> GetProductHistoryByStockNumber(string stockNumber);        
    }
}
