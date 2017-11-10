using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace SGInventory.Dal
{
    public class DeliveryDal:IDeliveryDal
    {
        private Helpers.ISgiHelper _sgiHelper;

        public DeliveryDal(Helpers.ISgiHelper sgiHelper)
        {
            _sgiHelper = sgiHelper;
        }

        public List<Model.Delivery> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Model.Delivery SelectPrimaryEntity<D>(D primaryValue)
        {
            var retValue = _sgiHelper.DataHelper.SelectPrimary<Delivery, D>(primaryValue);
            var delDetails = retValue
                .DeliveryDetails
                .GroupBy((deliveryDetails) => deliveryDetails.Id)
                .Select((deliveryDetail) => deliveryDetail.First()).ToList();

            retValue.DeliveryDetails = delDetails;
            
                
            return retValue;
        }

        public List<Model.Delivery> SelectBySpQuery(string spName, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public void  SaveDeliveryDetail(DeliveryDetail deliveryDetail)
        {
            var productDetailCode = deliveryDetail.ProductDetail.Code;
            using (var session = _sgiHelper.DataHelper.SessionFactory.OpenSession())
            {
                //var productDetails = session.Get<ProductDetails>(productDetailCode);
                //productDetails.QuantityOnHand += deliveryDetail.Quantity;
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(deliveryDetail);

                        //session.SaveOrUpdate(productDetails);

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }                      
        }

        public void SaveOrUpdate(Model.Delivery entity)
        {         
            using (var session = _sgiHelper.DataHelper.SessionFactory.OpenSession())
            {               
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(entity);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
              
                }                              
            }
        }
      
        public void Delete(Model.Delivery model)
        {
            throw new NotImplementedException();
        }

        public List<Delivery> SelectBySupplier(Supplier supplier)
        {
            var result = new List<Delivery>();

            using (var session = _sgiHelper.DataHelper.SessionFactory.OpenSession())
            {
                result = session.CreateCriteria<Delivery>()
                   .Add(Expression.Eq("Supplier", supplier))
                   .List<Delivery>().ToList<Delivery>();
                result = ReturnAllDistinct(result);
            }

            return result;
        }

        public List<Delivery> SelectByDeliveryDate(DateTime dateTime)
        {
            var result = new List<Delivery>();
            var lower = new DateTime(dateTime.Year,dateTime.Month,dateTime.Day,0,0,0);
            var upper = new DateTime(dateTime.Year,dateTime.Month,dateTime.Day,23,59,59);
            using (var session = _sgiHelper.DataHelper.SessionFactory.OpenSession())
            {
                result = session.CreateCriteria<Delivery>()
                   .Add(Expression.Between("DeliveryDate",lower,upper))
                   .List<Delivery>().ToList<Delivery>();
                result = ReturnAllDistinct(result);
            }

            return result;
        }

        public  List<Delivery> ReturnAllDistinct(List<Delivery> deliveries)
        {
            var newDeliveries = 
                deliveries
                .GroupBy((delivery) => delivery.Id)
                .Select(
                (list)=>
                    {
                        var delivery = list.First<Delivery>();
                        delivery.DeliveryDetails =
                            delivery.DeliveryDetails
                            .GroupBy((deliveryDetail) => deliveryDetail.Id)
                            .Select((deliveryDetailList) => deliveryDetailList.First<DeliveryDetail>()).ToList();
                        return delivery;                       
                    }
                   // list.First<Delivery>()
                )
                .ToList();
            return newDeliveries;
        }
        
        public List<Delivery> SelectBySupplierAndDeliveryDate(DateTime dateTime, Supplier supplier)
        {
            var result = new List<Delivery>();
            var lower = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
            var upper = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59);
            using (var session = _sgiHelper.DataHelper.SessionFactory.OpenSession())
            {
                result = session.CreateCriteria<Delivery>()
                   .Add(Expression.Between("DeliveryDate", lower, upper))
                   .Add(Expression.Eq("Supplier",supplier))
                   .List<Delivery>().ToList<Delivery>();
                result = ReturnAllDistinct(result);
            }

            return result;
        }

        public List<Delivery> SelectBySpQuery(string spName)
        {
            throw new NotImplementedException();
        }

        public List<DeliveryDetail> SelectByProduct(Product model)
        {
            var result = new List<DeliveryDetail>();

            foreach (var productDetail in model.ProductDetails)
            {
                using (var session = _sgiHelper.DataHelper.SessionFactory.OpenSession())
                {
                    var query = session.CreateCriteria<DeliveryDetail>()
                       .Add(Expression.Eq("ProductDetail", productDetail)).List<DeliveryDetail>();

                    if (query.Count() > 0)
                    {
                        result.Add(query.First());
                    }                                           
                }
            }
            

            return result;
        }

        public List<Delivery> SelectByDeliveryDate(DateTime deliveryDateFrom, DateTime deliveryDateTo)
        {
            var result = new List<Delivery>();
            var lower = new DateTime(deliveryDateFrom.Year, deliveryDateFrom.Month, deliveryDateFrom.Day, 0, 0, 0);
            var upper = new DateTime(deliveryDateTo.Year, deliveryDateTo.Month, deliveryDateTo.Day, 23, 59, 59);
            using (var session = _sgiHelper.DataHelper.SessionFactory.OpenSession())
            {
                result = session.CreateCriteria<Delivery>()
                   .Add(Expression.Between("DeliveryDate", lower, upper))
                   .List<Delivery>().ToList<Delivery>();
                result = ReturnAllDistinct(result);
            }

            return result;
        }

        public void SaveInTransaction(Delivery delivery)
        {
            using (var session = _sgiHelper.DataHelper.SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(delivery);

                        foreach (var deliveryDetail in delivery.DeliveryDetails)
                        {
                            session.SaveOrUpdate(deliveryDetail);
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public Delivery GetBy(Supplier supplier, string orNumber)
        {
            Delivery returnValue = null;

            using (var session = _sgiHelper.DataHelper.SessionFactory.OpenSession())
            {
                var deliveries = session.CreateCriteria<Delivery>()
                    .Add(Expression.Eq("Supplier", supplier))
                    .Add(Expression.Eq("OrNumber", orNumber))
                    .List<Delivery>();

                if (deliveries.Count() > 0)
                {
                    returnValue = deliveries.First();
                }
            }
            return returnValue;
        }

        public void DeactivateDeliveryDetail(DeliveryDetail deliveryDetail)
        {
            deliveryDetail.IsActive = 0;

            _sgiHelper.DataHelper.SaveOrUpdate(deliveryDetail);
        }

        public List<DeliveryDetail> SelectActiveByProductDetailCode(string code)
        {
            var retValue = new List<DeliveryDetail>();

            using (var session = _sgiHelper.DataHelper.SessionFactory.OpenSession())
            {
                var productDetail = new ProductDetails { Code = code };

                var result = session.CreateCriteria<DeliveryDetail>()
                    .Add(Expression.Eq("ProductDetail", productDetail))
                    .Add(Expression.Eq("IsActive", 1)).List<DeliveryDetail>();

                retValue = result.GroupBy(r => r.Id).Select(s => s.First()).ToList();
            }

            return retValue;
        }

        public List<DeliveryDetail> SelectAllActive()
        {
            var retValue = new List<DeliveryDetail>();

            using (var session = _sgiHelper.DataHelper.SessionFactory.OpenSession())
            {                
                var result = session.CreateCriteria<DeliveryDetail>()                    
                    .Add(Expression.Eq("IsActive", 1)).List<DeliveryDetail>();

                retValue = result.GroupBy(r => r.Id).Select(s => s.First()).ToList();
            }

            return retValue;
        }

        public List<DeliveryDetail> SelectDeliveryDetailBy(string code, DateTime from, DateTime to, bool isActive)
        {
            var retValue = new List<DeliveryDetail>();

            var lower = new DateTime(from.Year, from.Month, from.Day, 0, 0, 0);
            var upper = new DateTime(to.Year, to.Month, to.Day, 23, 59, 59);

            using (var session = _sgiHelper.DataHelper.SessionFactory.OpenSession())
            {
                var result = session.CreateCriteria<DeliveryDetail>()
                    .Add(Expression.Eq("IsActive", 1))                    
                    .Add(Expression.Eq("ProductDetail", new ProductDetails{Code = code}))             
                    .List<DeliveryDetail>();

                retValue = result
                    .Where(dd=>dd.Delivery!=null?(dd.Delivery.DeliveryDate>=lower && dd.Delivery.DeliveryDate<=upper):(dd.AdjustmentDate.Value>=lower&&dd.AdjustmentDate.Value<=upper))
                    .GroupBy(r => r.Id).Select(s => s.First())
                    .OrderBy(dd=>dd.Delivery!=null?dd.Delivery.DeliveryDate:dd.AdjustmentDate.Value)
                    .ToList();
            }

            return retValue;
        }

        public DeliveryDetail SelectPrimaryDeliveryDetail(int deliveryDetailId)
        {
            var retValue = _sgiHelper.DataHelper.SelectPrimary<DeliveryDetail, int>(deliveryDetailId);
            return retValue;
        }

        public void DeleteDeliveryDetail(DeliveryDetail deliveryDetail)
        {
            _sgiHelper.DataHelper.Delete<DeliveryDetail>(deliveryDetail);
        }

        public List<DeliveryDetail> SelectByCodeOrStockNumber(string code)
        {
            var result = new List<DeliveryDetail>();

            using (var session = _sgiHelper.DataHelper.SessionFactory.OpenSession())
            {
                 result = session.CreateCriteria<DeliveryDetail>()
                    .Add(Restrictions.Or(Restrictions.Eq("Code",code),Restrictions.Eq("Product", new Product{StockNumber = code})))                    
                    .List<DeliveryDetail>().ToList();

                
            }

            return result;
        }

        public Delivery SelectLatestAdjustedDelivery(DateTime adjustmentDate)
        {
            Delivery delivery = null;
            var format = "yyyy-MM-dd";
            var highDate = $"{adjustmentDate.ToString(format)} 23:59:59";
            var lowDate = $"{adjustmentDate.ToString(format)} 00:00:00";

            using (var session = _sgiHelper.DataHelper.SessionFactory.OpenSession())
            {
                var result = session.CreateCriteria<Delivery>()
                            .Add(Expression.Between("DeliveryDate", Convert.ToDateTime(lowDate), Convert.ToDateTime(highDate)))
                            .AddOrder(Order.Desc("OrNumber"))
                            .SetResultTransformer(Transformers.DistinctRootEntity)
                            .List<Delivery>();
                if(result.Any())
                {
                    delivery = result.FirstOrDefault();
                }
            }
            return delivery;
        }
    }
}
