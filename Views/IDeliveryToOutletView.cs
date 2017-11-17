using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Enums;
using SGInventory.Model;

namespace SGInventory.Views
{
    public interface IDeliveryToOutletView : IShowMessage, IDeliveryBaseView
    {
        int GetOutletId();

        DateTime GetDeliveryDate();

        string GetPackingNumber();
                
        void EnableSaveButton(bool shouldEnable);

        void EnablePackingListNumberTextBox(bool shouldEnable);

        void LoadDeliveryToOutlet();

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

        void LoadResultToView(List<ProductDetails> result);
        ProductStatus GetProductStatus();
        void LoadDeliveryToOutlet(DeliveryToOutlet deliveryToOutlet);
        DialogResult ShowYesNoMessage(string message, string caption);
        void OnSave();
        void PopupPrintForm();
    }
}
