using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Dal
{
    public interface IDeliveryToOutletDal: ICrud<DeliveryToOutlet>
    {
        DeliveryToOutlet SelectByPackingListNumber(string number);
        List<DeliveryToOutlet> SelectBy(Outlet outlet, DateTime? dateFrom = null, DateTime? dateTo = null);
        List<DeliveryToOutletDetail> SelectActiveByProductCode(string code);
        List<DeliveryToOutletDetail> SelectAllActive();
        List<DeliveryToOutletDetail> SelectDeliveryToOutletDetailBy(string code, DateTime from, DateTime to, bool isActive);
        DeliveryToOutletDetail SelectDeliveryDetailBy(int deliveryDetailId);
        void SaveDeliveryToOutletDetail(DeliveryToOutletDetail deliveryToOutletDetail);
        void DeleteDeliveryToOutletDetail(DeliveryToOutletDetail deliveryToOutletDetail);
        List<DeliveryToOutletDetail> SelectDeliveryToOutletDetailBySpQuery(string spQuery, Dictionary<string, object> parameters);
        List<DeliveryToOutletDetail> SelectDeliveryToOutletDetailBy(int outletId,int isActive);
    }
}
