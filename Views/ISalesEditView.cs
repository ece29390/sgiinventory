using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Views
{
    public interface ISalesEditView : IScanBarcodeDisplay,IShowMessage
    {
        void LoadOutlets(List<Outlet> outlets);

        void LoadSales(Sales sales);

        void ShowScannerWindow(bool shouldusescanner);

        void EnableAddButton(bool enable);

        void SetBarcodeAs(ProductDetails productDetail);

        void SetWashingCode(string p);

        Sales GetSalesObject();

        void ResetControls();

        void LoadColor(Color color);

        void LoadSizes(Size size);

        void LoadWashings(Washing washing);
    }
}
