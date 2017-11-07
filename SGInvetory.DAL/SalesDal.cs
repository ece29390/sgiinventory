using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Helpers;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace SGInventory.Dal
{
    public class SalesDal:DalBase<Sales>,ISalesDal
    {        
        public SalesDal(ISgiHelper helper):base(helper){}
      

        public List<Sales> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Sales SelectPrimaryEntity<D>(D primaryValue)
        {
            var sales = _helper.DataHelper.SelectPrimary<Sales, D>(primaryValue);
            return sales;
        }

        public List<Sales> SelectBySpQuery(string spName, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public void SaveOrUpdate(Sales entity)
        {
            _helper.DataHelper.SaveOrUpdate(entity);
        }

        public List<Sales> SelectBySpQuery(string spName)
        {
            throw new NotImplementedException();
        }

        public void Delete(Sales model)
        {
            _helper.DataHelper.Delete(model);
        }

        public List<Sales> SelectBy(DateTime salesofdate, Outlet outlet)
        {
            var sales = new List<Sales>();

            using (var session = _helper.DataHelper.SessionFactory.OpenSession())
            {
                sales = session.CreateCriteria<Sales>()
                    .Add(Expression.Eq("Outlet", outlet))
                    .Add(Expression.Eq("DateOfSales", Convert.ToDateTime(salesofdate.ToShortDateString())))
                    .List<Sales>().ToList();
            }
            sales = ReturnDistinctSales(sales);
            return sales;
        }

        private List<Sales> ReturnDistinctSales(List<Sales> sales)
        {
            sales = sales.GroupBy(s => s.ProductDetail).Select(s => s.First()).ToList();
            return sales;
        }

        public Sales SelectBy(DateTime dateTime, Outlet outlet, ProductDetails productDetails)
        {
            Sales sales = null;

            using (var session = _helper.DataHelper.SessionFactory.OpenSession())
            {
                var retSales = session.CreateCriteria<Sales>()
                    .Add(Expression.Eq("Outlet", outlet))
                    .Add(Expression.Eq("DateOfSales", Convert.ToDateTime(dateTime.ToShortDateString())))
                    .Add(Expression.Eq("ProductDetail",productDetails))
                    .List<Sales>().ToList();

                if (retSales.Any())
                {
                    sales = retSales.First();
                }
            }
           
            return sales;
        }


        public List<Sales> SelectBy(DateTime dateofsales)
        {
            var sales = new List<Sales>();
            using (var session = _helper.DataHelper.SessionFactory.OpenSession())
            {
                sales = session.CreateCriteria<Sales>()
                    .Add(Expression.Eq("DateOfSales", Convert.ToDateTime(dateofsales.ToShortDateString())))
                    .List<Sales>().ToList();
            }
            sales = ReturnDistinctSales(sales);
            return sales;
        }
        public List<Sales> SelectBy(int outletId,string productCode)
        {
            var sales = new List<Sales>();
            using (var session = _helper.DataHelper.SessionFactory.OpenSession())
            {
                Outlet outlet=null;
                ProductDetails productDetails=null;
                Sales sale=null;

                sales = session.QueryOver<Sales>(() => sale)
                    .JoinAlias(() => sale.Outlet,()=>outlet)
                    .JoinAlias(() => sale.ProductDetail,()=>productDetails)
                    .Where(() => outlet.Id == outletId)
                    .And(() => productDetails.Code == productCode)
                    .TransformUsing(Transformers.DistinctRootEntity)
                    .List<Sales>().ToList();               
            }
            return sales;
        }

        public List<Sales> SelectBy(string transactionNumber)
        {
            var listOfSales = new List<Sales>();
            using (var session = _helper.DataHelper.SessionFactory.OpenSession())
            {
                listOfSales = session.CreateCriteria<Sales>()
                                .Add(Expression.Eq("TransactionNumber", transactionNumber))
                                .SetResultTransformer(Transformers.DistinctRootEntity)
                                .List<Sales>().ToList();
            }
            return listOfSales;
        }

        public List<Sales> SelectSalesDoNotBelongToSalesId(int salesId, string productDetail, int outletId)
        {
            var sales = new List<Sales>();
            using (var session = _helper.DataHelper.SessionFactory.OpenSession())
            {
                Outlet outlet = null;
                ProductDetails productDetails = null;
                Sales sale = null;

                sales = session.QueryOver<Sales>(() => sale)
                    .JoinAlias(() => sale.Outlet, () => outlet)
                    .JoinAlias(() => sale.ProductDetail, () => productDetails)
                    .Where(() => outlet.Id == outletId)
                    .And(() => productDetails.Code == productDetail)
                    .AndNot(()=>sale.Id==salesId)
                    .TransformUsing(Transformers.DistinctRootEntity)
                    .List<Sales>().ToList();
            }
            return sales;
        }
    }
}
