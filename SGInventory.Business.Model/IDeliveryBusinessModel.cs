using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Enums;
using SGInventory.Dal;

namespace SGInventory.Business.Model
{
    public interface IDeliveryBusinessModel : IBusinessTransact<Delivery>, ISave<Delivery>,ISelectByPrimary<Delivery,int>
    {
        string SaveDeliveryDetail(DeliveryDetail deliveryDetail);

        List<Delivery> SelectBySupplier(string supplierName);

        List<Delivery> SelectByDeliveryDate(DateTime deliveryDateFrom, DateTime deliveryDateTo);

        List<Delivery> SelectByBoth(string supplierName, DateTime dateTime);

        List<DeliveryDetail> SelectDeliveryDetailByProduct(Product model);

        string SaveInTransaction(Delivery delivery);

        Delivery DeactivateDelivertyDetailReturnAllActive(DeliveryDetail deliveryDetail);

        int GetDeliveryDetailTotalQuantityByCode(string code,ProductStatus status);

        List<DeliveryTotalByProductDetailCode> GetTotalActiveDeliveryTotal();
       
        List<DeliveryDetail> GetDeliveryDetailBy(string code, DateTime from, DateTime to, bool isActive);

        DeliveryDetail GetPrimaryDeliveryDetail(int deliveryDetailId);

        void DeleteDeliveryDetail(DeliveryDetail deliveryDetail);
    }
}
