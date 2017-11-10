using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Dal
{
    public interface IDeliveryDal : ICrud<Delivery>
    {
        void SaveDeliveryDetail(DeliveryDetail deliveryDetail);

        List<Delivery> SelectBySupplier(Supplier supplier);

        List<Delivery> SelectByDeliveryDate(DateTime dateTime);

        List<Delivery> SelectBySupplierAndDeliveryDate(DateTime dateTime, Supplier supplier);

        List<DeliveryDetail> SelectByProduct(Product model);

        List<Delivery> SelectByDeliveryDate(DateTime deliveryDateFrom, DateTime deliveryDateTo);

        void SaveInTransaction(Delivery delivery);

        Delivery GetBy(Supplier supplier, string orNumber);

        void DeactivateDeliveryDetail(DeliveryDetail deliveryDetail);

        List<DeliveryDetail> SelectActiveByProductDetailCode(string code);

        List<DeliveryDetail> SelectAllActive();

        List<DeliveryDetail> SelectDeliveryDetailBy(string code, DateTime from, DateTime to, bool isActive);

        DeliveryDetail SelectPrimaryDeliveryDetail(int deliveryDetailId);

        void DeleteDeliveryDetail(DeliveryDetail deliveryDetail);

        List<DeliveryDetail> SelectByCodeOrStockNumber(string code);
        Delivery SelectLatestAdjustedDelivery(DateTime adjustmentDate);
    }
}
