using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Business.Model
{
    public interface ISalesBusinessModel
    {
        Sales SelectBy(int salesid);

        void Save(Sales sales);

        List<Sales> SelectByOutletAndDateOfSales(Sales sales);

        Sales SelectByOutletDateOfSalesProductDetail(Sales sales);

        void Delete(Sales sales);

        List<Sales> SelectByDateOfSales(Sales sales);
        int GetTotalQuantityPerOutlet(int outletId);
    }
}
