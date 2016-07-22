using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Views
{
    public interface ISalesSearchView:IShowMessage
    {
        void LoadOutlets(List<Model.Outlet> outlets);

        void LoadSales(List<Model.Sales> sales);

        void LoadSales(Model.Sales sale);

        Model.Sales GetSales();
    }
}
