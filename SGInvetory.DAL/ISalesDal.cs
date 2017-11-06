using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Dal
{
    public interface ISalesDal:ICrud<Sales>
    {
        List<Sales> SelectBy(DateTime salesofdate,Outlet outlet);

        Sales SelectBy(DateTime dateofsales, Outlet outlet, ProductDetails productDetails);

        List<Sales> SelectBy(DateTime dateofsales);
        List<Sales> SelectBy(int outletId,string productCode);
    }
}
