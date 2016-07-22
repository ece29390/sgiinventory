using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Enums;

namespace SGInventory.Views
{
    public interface ISupplierDeliveryEditView:IShowMessage,IDeliveryEditBaseView<DeliveryDetail>
    {
        
        void DisplayProductStausList(List<ProductStatus> _listOfProductStatus);

        void DisplayDamageList(List<Damage> _listOfDamages);

        void SetStatusToDeliveryDetail(DeliveryDetail selectedDeliveryDetail);
        
        ProductStatus GetProductStatus();

        int? GetDamageStatus();
    }
}
