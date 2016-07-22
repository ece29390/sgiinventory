using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Enums;

namespace SGInventory.Views
{
    public interface IDeliveryToOutletSearchView:IDateRangeFilter,IMessageBox
    {
        void LoadOutlets(List<Model.Outlet> outlets);

        void LoadSearchMode(List<Enums.DeliveryToOutletSearchMode> searchModes);

        Enums.DeliveryToOutletSearchMode GetSearchMode();

        Outlet GetOutlet();

        void LoadSearchDeliveries(List<DeliveryToOutlet> searchLists);

        DeliveryToOutlet GetSelectedDeliveryToOutlet(int selectedIndex);

        void OpenDeliveryToOutletEditForm(DeliveryToOutlet deliveryToOutlet,bool useScanner,ProductStatus status);

        void EnableSearchButton(bool enable);
    }
}
