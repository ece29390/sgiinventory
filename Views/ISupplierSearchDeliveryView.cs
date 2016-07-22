using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Enums;
using SGInventory.Model;

namespace SGInventory.Views
{
    public interface ISupplierSearchDeliveryView:IMessageBox,IDateRangeFilter
    {
        void LoadSuppliers(List<SGInventory.Model.Supplier> list);

        string GetSupplierName();

        void LoadSearchMode(List<SupplierSearchDeliveryMode> list);

        SupplierSearchDeliveryMode GetSearchMode();

        void LoadSearchDeliveries(List<SGInventory.Model.Delivery> list);
        
        Delivery GetSelectedDelivery(int selectedRow);

        void OpenSupplierDeliveryEditForm(Delivery delivery,bool useScanner);

        void EnableSearchButton(bool p);
        
    }
}
