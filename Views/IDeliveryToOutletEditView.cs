using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Views
{
    public interface IDeliveryToOutletEditView:IDeliveryEditBaseView<DeliveryToOutletDetail>,IShowMessage
    {
        void LoadDisplayDeliveryDetailList(IList<DeliveryToOutletDetail> list);
    }
}
