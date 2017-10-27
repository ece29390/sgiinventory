using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Dal;
using SGInventory.Model;
using SGInventory.Enums;

namespace SGInventory.Business.Model
{
    public class DeliveryToOutletBusinessModel : IDeliveryToOutletBusinessModel
    {
        private Dal.IDeliveryToOutletDal _iDeliveryToOutletDal;
        public const string SuccessfulMessageOnCreate = "Delivery to outlet has been successfully saved";
        public const string SuccessfulMessageOnUpdate = "Delivery to outlet has been updated successfully";
        public const string DrNumberAlreadyExists = "DR Number already exists!";

        public DeliveryToOutletBusinessModel(Dal.IDeliveryToOutletDal iDeliveryToOutletDal)
        {            
            this._iDeliveryToOutletDal = iDeliveryToOutletDal;
        }


        public string SaveDeliveryToOutlet(SGInventory.Model.DeliveryToOutlet deliveryToOutlet)
        {
            var message = deliveryToOutlet.Id == 0 ? SuccessfulMessageOnCreate : SuccessfulMessageOnUpdate;

            var existingDeliveryToOutlet = GetDeliveryToOutletByPackingListNumber(deliveryToOutlet.PackingListNumber);

            if (existingDeliveryToOutlet == null || (existingDeliveryToOutlet!=null && existingDeliveryToOutlet.Id == deliveryToOutlet.Id))
            {
                
                _iDeliveryToOutletDal.SaveOrUpdate(deliveryToOutlet);
            }
            else
            {
                message = DrNumberAlreadyExists;
            }
            
            return message;
           
        }

        public DeliveryToOutlet GetDeliveryToOutletByPackingListNumber(string packingListNumber)
        {
            var deliveryToOutlet = _iDeliveryToOutletDal.SelectByPackingListNumber(packingListNumber);
            return deliveryToOutlet;
        }


        public List<DeliveryToOutlet> SelectByOutlet(Outlet deliveryToOutlet)
        {
            var retValue = _iDeliveryToOutletDal.SelectBy(deliveryToOutlet);
            return retValue;
        }

        public List<DeliveryToOutlet> SelectByDeliveryDate(DateTime dateFrom, DateTime dateTo)
        {
            var retValue = _iDeliveryToOutletDal.SelectBy(null, dateFrom, dateTo);
            return retValue;
        }

        public List<DeliveryToOutlet> SelectByBoth(Outlet deliveryToOutlet, DateTime dateFrom, DateTime dateTo)
        {
            var retValue = _iDeliveryToOutletDal.SelectBy(deliveryToOutlet, dateFrom, dateTo);
            return retValue;
        }

        public DeliveryToOutlet SelectByPrimaryId(int id)
        {
            var retValue = _iDeliveryToOutletDal.SelectPrimaryEntity(id);
            return retValue;
        }


        public void DeleteDeliveryToOutletDetail(DeliveryToOutlet deliveryToOutlet)
        {
            
        }

        public int GetDeliveryDetailToOutletTotalQuantityByCodeAndStatus(string code, ProductStatus status)
        {
            var result = _iDeliveryToOutletDal.SelectActiveByProductCode(code);
            result = result.Where(r => r.Status == (int)status).ToList();
            return result.Sum(r => r.Quantity);
        }


        public List<DeliveryTotalByProductDetailCode> GetTotalActiveDeliveryTotal()
        {
            var details = _iDeliveryToOutletDal.SelectAllActive();
            var retValue = (from detail in details
                            group detail by new { detail.ProductDetail.Code } into detailGroup
                            select new DeliveryTotalByProductDetailCode
                            {
                                ProductDetailCode = detailGroup.Key.Code
                                ,
                                Quantity = detailGroup.Sum(dd => dd.Quantity)
                            }).ToList();

            return retValue;
        }

        public List<DeliveryToOutletDetail> GetDeliveryToOutletDetailBy(string code, DateTime from, DateTime to, bool isActive)
        {
            var retValue = _iDeliveryToOutletDal.SelectDeliveryToOutletDetailBy(code, from, to, isActive);
            return retValue;
        }

        public DeliveryToOutletDetail GetDeliveryToOutletDetailBy(int deliverytoOutletDetailId)
        {
            var retValue = _iDeliveryToOutletDal.SelectDeliveryDetailBy(deliverytoOutletDetailId);
            return retValue;
        }

        public string SaveAdjustment(DeliveryToOutletDetail deliveryToOutletDetail)
        {
            _iDeliveryToOutletDal.SaveDeliveryToOutletDetail(deliveryToOutletDetail);
            return "Delivery to outlet detail has been successfully saved";
        }

        public void DeleteDeliveryToOutletDetail(DeliveryToOutletDetail deliveryToOutletDetail)
        {
            _iDeliveryToOutletDal.DeleteDeliveryToOutletDetail(deliveryToOutletDetail);
        }

        public int GetDeliveryDetailToOutletTotalQuantityByCodeAndStatusAndDeliveryToOutletId(string code, ProductStatus status, int deliverytoOutletId)
        {
            var result = _iDeliveryToOutletDal.SelectActiveByProductCode(code);
            result = result.Where(dd => dd.Status == (int)status && dd.DeliveryToOutlet.Id.Equals(deliverytoOutletId)).ToList();
            return result.Sum(dd => dd.Quantity);
        }
    }
}
