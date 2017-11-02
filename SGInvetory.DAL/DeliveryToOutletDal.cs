using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;
using SGInventory.Model;

namespace SGInventory.Dal
{
    public class DeliveryToOutletDal:IDeliveryToOutletDal
    {
        private Helpers.ISgiHelper _sgiHelper;

        public DeliveryToOutletDal(Helpers.ISgiHelper sgiHelper)
        {
            _sgiHelper = sgiHelper;
        }

        public List<Model.DeliveryToOutlet> SelectAll()
        {
            return _sgiHelper.DataHelper.SelectAll <Model.DeliveryToOutlet>();
        }

        public Model.DeliveryToOutlet SelectPrimaryEntity<D>(D primaryValue)
        {
            var retValue = _sgiHelper.DataHelper.SelectPrimary<Model.DeliveryToOutlet, D>(primaryValue);
            retValue.DeliveryToOutletDetails = ReturnDistinctDeliveryToOutletDetails(retValue);
            return retValue;
        }

        public List<Model.DeliveryToOutlet> SelectBySpQuery(string spName, Dictionary<string, object> parameters)
        {
            if (parameters != null)
            {
                return _sgiHelper.DataHelper.SelectSp<Model.DeliveryToOutlet>(spName, parameters);
            }
            else
            {
                return _sgiHelper.DataHelper.SelectSp<Model.DeliveryToOutlet>(spName);
            }
        }

        public void SaveOrUpdate(Model.DeliveryToOutlet entity)
        {
            using (var session = _sgiHelper.DataHelper.SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(entity);

                        foreach (var dtod in entity.DeliveryToOutletDetails)
                        {                            
                            session.SaveOrUpdate(dtod);                          
                        }

                        transaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public List<Model.DeliveryToOutlet> SelectBySpQuery(string spName)
        {
            throw new NotImplementedException();
        }

        public void Delete(Model.DeliveryToOutlet model)
        {
            throw new NotImplementedException();
        }

        public Model.DeliveryToOutlet SelectByPackingListNumber(string number)
        {
            Model.DeliveryToOutlet deliveryToOutlet;

            using (var session = _sgiHelper.DataHelper.SessionFactory.OpenSession())
            {
                var query = session.CreateCriteria<Model.DeliveryToOutlet>()
                    .Add(Expression.Eq("PackingListNumber", number)).List<Model.DeliveryToOutlet>();

                deliveryToOutlet = query.FirstOrDefault();

                if (deliveryToOutlet != null)
                {
                    deliveryToOutlet.DeliveryToOutletDetails = ReturnDistinctDeliveryToOutletDetails(deliveryToOutlet);
                }
            }

            return deliveryToOutlet;
        }

        private List<DeliveryToOutletDetail> ReturnDistinctDeliveryToOutletDetails(DeliveryToOutlet deliveryToOutlet)
        {
            var retValue = deliveryToOutlet.DeliveryToOutletDetails.Where((d)=>d.IsActive==1).GroupBy((d) => d.Id).Select(s => s.First()).ToList();            
            return retValue;
        }


        public List<DeliveryToOutlet> SelectBy(Outlet outlet, DateTime? dateFrom = null, DateTime? dateTo = null)
        {
            var retValue = new List<DeliveryToOutlet>();

            using (var session = _sgiHelper.DataHelper.SessionFactory.OpenSession())
            {
                var query = session.CreateCriteria<Model.DeliveryToOutlet>();

                if (outlet != null)
                {
                    query.Add(Expression.Eq("Outlet", outlet));
                }

                if (dateFrom.HasValue && dateTo.HasValue)
                {
                    query.Add(Expression.Between("DeliveryDate", dateFrom.Value, dateTo.Value));
                }

                retValue = query.List<DeliveryToOutlet>()
                    .GroupBy((d) => d.Id)
                    .Select((s) =>
                        {
                            var dtoFirst = s.First();
                            dtoFirst.DeliveryToOutletDetails = ReturnDistinctDeliveryToOutletDetails(dtoFirst);
                            return dtoFirst;
                        })
                        .ToList();                                                                                                                              
            }

            return retValue;
        }


        public List<DeliveryToOutletDetail> SelectActiveByProductCode(string code)
        {
            var retValue = new List<DeliveryToOutletDetail>();

            using (var session = _sgiHelper.DataHelper.SessionFactory.OpenSession())
            {
                var productDetail = new ProductDetails { Code = code };

                var result = session.CreateCriteria<DeliveryToOutletDetail>()
                    .Add(Expression.Eq("ProductDetail", productDetail))
                    .Add(Expression.Eq("IsActive", 1)).List<DeliveryToOutletDetail>();

                retValue = result.GroupBy(r => r.Id).Select(r => r.First()).ToList();
            }

            return retValue;
        }


        public List<DeliveryToOutletDetail> SelectAllActive()
        {
            var retValue = new List<DeliveryToOutletDetail>();

            using (var session = _sgiHelper.DataHelper.SessionFactory.OpenSession())
            {                
                var result = session.CreateCriteria<DeliveryToOutletDetail>()                    
                    .Add(Expression.Eq("IsActive", 1)).List<DeliveryToOutletDetail>();

                retValue = result.GroupBy(r => r.Id).Select(r => r.First()).ToList();
            }

            return retValue;
        }


        public List<DeliveryToOutletDetail> SelectDeliveryToOutletDetailBy(string code, DateTime from, DateTime to, bool isActive)
        {
            var retValue = new List<DeliveryToOutletDetail>();
            var lower = new DateTime(from.Year,from.Month,from.Day,0,0,0);
            var upper = new DateTime(to.Year,to.Month,to.Day,23,59,59);

            using (var session = _sgiHelper.DataHelper.SessionFactory.OpenSession())
            {
                var productDetail = new ProductDetails { Code = code };

                var result = session.CreateCriteria<DeliveryToOutletDetail>()
                    .Add(Expression.Eq("ProductDetail", productDetail))
                    .Add(Expression.Eq("IsActive", 1)).List<DeliveryToOutletDetail>();

                retValue = result
                    .Where(dod => dod.DeliveryToOutlet != null ? (dod.DeliveryToOutlet.DeliveryDate >= from && dod.DeliveryToOutlet.DeliveryDate <= to) : (dod.AdjustmentDate.Value >= from && dod.AdjustmentDate.Value <= to))
                    .GroupBy(r => r.Id).Select(r => r.First())
                    .OrderBy(dod=>dod.DeliveryToOutlet != null?dod.DeliveryToOutlet.DeliveryDate:dod.AdjustmentDate.Value)
                    .ToList();
            }

            return retValue;
        }

        public DeliveryToOutletDetail SelectDeliveryDetailBy(int deliveryDetailId)
        {
            var retvalue = _sgiHelper.DataHelper.SelectPrimary<DeliveryToOutletDetail, int>(deliveryDetailId);
            return retvalue;
        }

        public void SaveDeliveryToOutletDetail(DeliveryToOutletDetail deliveryToOutletDetail)
        {
            _sgiHelper.DataHelper.SaveOrUpdate<DeliveryToOutletDetail>(deliveryToOutletDetail);
        }

        public void DeleteDeliveryToOutletDetail(DeliveryToOutletDetail deliveryToOutletDetail)
        {
            _sgiHelper.DataHelper.Delete<DeliveryToOutletDetail>(deliveryToOutletDetail);
        }

        public List<DeliveryToOutletDetail> SelectDeliveryToOutletDetailBySpQuery(string spQuery, Dictionary<string, object> parameters)
        {
            return _sgiHelper.DataHelper.SelectSp<DeliveryToOutletDetail>(spQuery, parameters);
        }
    }
}
