using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Enums;
using SGInventory.Dal;

namespace SGInventory.Business.Model
{
    public interface IDeliveryToOutletBusinessModel:ISelectByPrimary<DeliveryToOutlet,int>
    {
        string SaveDeliveryToOutlet(SGInventory.Model.DeliveryToOutlet deliveryToOutlet);

        DeliveryToOutlet GetDeliveryToOutletByPackingListNumber(string packingListNumber);

        List<DeliveryToOutlet> SelectByOutlet(Outlet deliveryToOutlet);

        List<DeliveryToOutlet> SelectByDeliveryDate(DateTime dateFrom, DateTime dateTo);

        List<DeliveryToOutlet> SelectByBoth(Outlet deliveryToOutlet, DateTime dateFrom, DateTime dateTo);

        int GetDeliveryDetailToOutletTotalQuantityByCodeAndStatus(string code,ProductStatus status);

        int GetDeliveryDetailToOutletTotalQuantityByCodeAndStatusAndDeliveryToOutletId(string code, ProductStatus status, int deliverytoOutletId);
        List<DeliveryTotalByProductDetailCode> GetTotalActiveDeliveryTotal();

        List<DeliveryToOutletDetail> GetDeliveryToOutletDetailBy(string code, DateTime from, DateTime to, bool isActive);

        DeliveryToOutletDetail GetDeliveryToOutletDetailBy(int deliverytoOutletDetailId);

        string SaveAdjustment(DeliveryToOutletDetail deliveryToOutletDetail);

        void DeleteDeliveryToOutletDetail(DeliveryToOutletDetail deliveryToOutletDetail);
        List<DeliveryToOutletDetail> GetActiveDeliveryToOutletDetailBy(ProductStatus goods, string code, int outletId);
        List<DeliveryToOutletDetail> GetActiveDeliveryToOutletDetailByStockNumberAnd(ProductStatus goods, string code, int outletId);
    }
}
