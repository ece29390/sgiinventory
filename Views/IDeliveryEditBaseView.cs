using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Views
{
    public interface IDeliveryEditBaseView<T>
    {
        void DisplayDeliveryDetail(T deliveryDetail);

        void RefreshControls();

        int GetQuantity();

        string GetRemarks();

        string GetBarcode();

        void EnableDelete(bool enable);
    }
}
