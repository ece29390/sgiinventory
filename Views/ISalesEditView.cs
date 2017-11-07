using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Views
{
    public interface ISalesEditView : IScanBarcodeDisplay,IShowMessage
    {
        string TransactionNumber { get; set; }

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
        int GetOutletId();
        string GetSelectedOutlet();
        void TriggerAddSales();
        string GetSelectedProductCode();
        void ShowEditControls(bool shouldShow);
        void SetEditMode(bool setToEditMode);
    }
}
