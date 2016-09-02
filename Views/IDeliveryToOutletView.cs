using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Enums;

namespace SGInventory.Views
{
    public interface IDeliveryToOutletView : IShowMessage, IDeliveryBaseView
    {
        int GetOutletId();

        DateTime GetDeliveryDate();

        string GetPackingNumber();
                
        void EnableSaveButton(bool shouldEnable);

        void EnablePackingListNumberTextBox(bool shouldEnable);

        void LoadDeliveryToOutlet(Model.DeliveryToOutlet deliveryToOutlet);

        void LoadOutletToControl(List<Model.Outlet> stores);

        void CheckUseScannerAsDefault();

        void EnableEditDeliveriesToOutlet(bool shouldEnable);

        List<Model.DeliveryToOutletDetail> SelectedDeliveryToOutletDetails { get; set; }

        Model.DeliveryToOutlet ParentDeliveryToOutlet { get; set; }

        int GetQuantity();

        double Srp { get; set; }

        void EnableProductDetailsGroup(bool shouldEnable);

        string GetStoreName();

        void LoadProductStatusIntoForm(List<ProductStatus> list);
    }
}
