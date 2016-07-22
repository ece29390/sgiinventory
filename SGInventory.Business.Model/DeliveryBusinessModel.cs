using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Business.Model.Exception;
using SGInventory.Model;
using SGInventory.Dal;
using SGInventory.Enums;

namespace SGInventory.Business.Model
{
    public class DeliveryBusinessModel:IDeliveryBusinessModel
    {
        public const string DeliverySuccessfulMessage = "Delivery Detail has been Saved",
                            DeliveryDetailSuccessfulMessage = "Delivery item has been saved";

        private Dal.IDeliveryDal _deliveryDal;
        private ISupplierDal _supplierDal;

        public DeliveryBusinessModel(Dal.IDeliveryDal deliveryDal, ISupplierDal supplierDal)
        {                      
            this._deliveryDal = deliveryDal;
            _supplierDal = supplierDal;
        }
      
        public void Delete(SGInventory.Model.Delivery model)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdate(SGInventory.Model.Delivery model)
        {        
            _deliveryDal.SaveOrUpdate(model);                       
        }

        public string Save(SGInventory.Model.Delivery model)
        {
            var returnValue = DeliverySuccessfulMessage;
            CreateOrUpdate(model);
            return returnValue;
        }

        public string SaveDeliveryDetail(DeliveryDetail deliveryDetail)
        {
            var returnValue = DeliveryDetailSuccessfulMessage;
            _deliveryDal.SaveDeliveryDetail(deliveryDetail);
            return returnValue;
        }

        public Delivery SelectByPrimaryId(int id)
        {
            var delivery = _deliveryDal.SelectPrimaryEntity(id);
            delivery.DeliveryDetails = delivery.DeliveryDetails.Where(d=>d.IsActive==1).ToList();
            return delivery;
        }

        public List<Delivery> SelectBySupplier(string supplierName)
        {           
            var supplier = _supplierDal.SelectBySpQuery(GetSupplierByNameQuery(), BuildSupplierParameterObject(supplierName));

            if (supplier == null || supplier.Count <= 0)
            {
                throw new InvalidSupplierException(supplierName);
            }

            return _deliveryDal.SelectBySupplier(supplier[0]);
            
        }

        private string GetSupplierByNameQuery()
        {
            var parameterName = "supplierName";

            var spQuery = string.Format("CALL SelectSupplierByName(:{0})", parameterName);

            return spQuery;
        }

        private Dictionary<string, object> BuildSupplierParameterObject(string supplierName)
        {
            var parameterName = "supplierName";
            var parameters = new Dictionary<string, object> { 
                {parameterName,supplierName}
            };

            return parameters;
        }

        public List<Delivery> SelectByDeliveryDate(DateTime deliveryDate)
        {
            return _deliveryDal.SelectByDeliveryDate(deliveryDate);
        }

        public List<Delivery> SelectByBoth(string supplierName, DateTime dateTime)
        {
            var supplier = _supplierDal.SelectBySpQuery(GetSupplierByNameQuery(), BuildSupplierParameterObject(supplierName));

            if (supplier == null || supplier.Count <= 0)
            {
                throw new InvalidSupplierException(supplierName);
            }

            return _deliveryDal.SelectBySupplierAndDeliveryDate(dateTime, supplier[0]);
        }

        public List<DeliveryDetail> SelectDeliveryDetailByProduct(Product model)
        {
            return _deliveryDal.SelectByProduct(model);
        }

        public List<Delivery> SelectByDeliveryDate(DateTime deliveryDateFrom, DateTime deliveryDateTo)
        {
            return _deliveryDal.SelectByDeliveryDate(deliveryDateFrom, deliveryDateTo);
        }

        public string SaveInTransaction(Delivery delivery)
        {
            var returnValue = DeliverySuccessfulMessage;
            
            string orNumber = delivery.OrNumber;

            var existingDelivery = _deliveryDal.GetBy(delivery.Supplier, orNumber);

            if (existingDelivery != null && delivery.Id==0)
            {
                returnValue = "DR number already exists to the given supplier";
            }
            else
            {
                _deliveryDal.SaveInTransaction(delivery);
            }
                        
            return returnValue;

        }

        public Delivery DeactivateDelivertyDetailReturnAllActive(DeliveryDetail deliveryDetail)
        {
            _deliveryDal.DeactivateDeliveryDetail(deliveryDetail);

            var delivery = _deliveryDal.SelectPrimaryEntity(deliveryDetail.Delivery.Id);
            var deliveryDetails = delivery.DeliveryDetails.Where(d => d.IsActive == 1).ToList() ;
            delivery.DeliveryDetails = deliveryDetails;
            deliveryDetail.Delivery = delivery;

            return delivery;
        }

        public int GetDeliveryDetailTotalQuantityByCode(string code, ProductStatus status)
        {
            var result = _deliveryDal.SelectActiveByProductDetailCode(code);
            result = result.Where(s => s.Status == (int)status).ToList();
            return result.Sum(dd => dd.Quantity);
        }

        public List<DeliveryTotalByProductDetailCode> GetTotalActiveDeliveryTotal()
        {
            var deliveryDetails = _deliveryDal.SelectAllActive();

            var retValue = (from deliveryDetail in deliveryDetails
                            group deliveryDetail by new { deliveryDetail.ProductDetail.Code } into deliveryDetailGroup
                            select new DeliveryTotalByProductDetailCode
                            {
                                ProductDetailCode = deliveryDetailGroup.Key.Code
                                ,
                                Quantity = deliveryDetailGroup.Sum(dd => dd.Quantity)
                            }).ToList();

            return retValue;

        }

        public List<DeliveryDetail> GetDeliveryDetailBy(string code, DateTime from, DateTime to, bool isActive)
        {
            var retValue = _deliveryDal.SelectDeliveryDetailBy(code, from, to, isActive);
            return retValue;
        }

        public DeliveryDetail GetPrimaryDeliveryDetail(int deliveryDetailId)
        {
            var retValue = _deliveryDal.SelectPrimaryDeliveryDetail(deliveryDetailId);
            return retValue;

        }

        public void DeleteDeliveryDetail(DeliveryDetail deliveryDetail)
        {
            _deliveryDal.DeleteDeliveryDetail(deliveryDetail);
        }
    }
}
