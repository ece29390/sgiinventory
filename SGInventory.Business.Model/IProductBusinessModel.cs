using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Dal;
using SGInventory.Model;
using SGInventory.Business.Model.Response;

namespace SGInventory.Business.Model
{
    public interface IProductBusinessModel : ISelectAll<Product>, ISelectByPrimary<Product, string>, IValidate<Product>, IBusinessTransact<Product>, ISave<Product>
    {
        List<Product> SelectByStockNumber(string stockNumber);

        Product SelectBothActiveAndNonActiveByPrimaryId(string stockNumber);

        string SaveUsingTransaction(Product _model);

        List<Product> SelectBySearch(string searchBy, string searchValue);

        List<ProductPricesHistory> GetProductHistoryByStockNumber(string p);

        Product SelectBy(string stockNumber, string colorCode, string washingCode);

        string SaveUsingTransaction(string modelName,Product model, Product dbModel, Color selectedColor, Washing selectedWashing);
    }
}
