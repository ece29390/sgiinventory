using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Views
{
    public interface IDeliveryBaseView : IScanBarcodeDisplay, IMessageBox,IGetItemLimit
    {
        void LoadProductIntoForm(Product product);

        void LoadProductIntoForm(ProductDetails productDetails);

        void EnableSaveDeliveryDetailButton(bool shouldEnable);

        void ShowScannerWindow(bool useScanner);

        void EnableSaveAddProductButton(bool enable);

        void SetBarcodeAs(ProductDetails productDetails);

        void SetWashingCode(string washing);
    }
}
