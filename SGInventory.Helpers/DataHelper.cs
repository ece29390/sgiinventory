using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Reflection;
using SGInventory.Model;
using FluentNHibernate.Automapping;
using System.Linq.Expressions;
namespace SGInventory.Helpers
{
    public class DataHelper:IDataHelper
    {
        public ISessionFactory SessionFactory{get;private set;}

        public DataHelper()
        {
            var config = Fluently.Configure().Database(
            MySQLConfiguration.Standard.ConnectionString(c => c.FromConnectionStringWithKey("MySqlConnectionString")))
            .Mappings(m =>
                {                    
                    m.AutoMappings.Add(AutoMap.AssemblyOf<Category>()
                        .Override<Size>(e=>e.Id(s=>s.Code))
                        .Override<Washing>(e=>e.Id(s=>s.Code))
                        .Override<ProductInventoryView>(e=>e.Id(s=>s.ProductDetailCode))
                        .Override<Color>(e=>{
                            e.Id(s=>s.Code);                            
                        })                        
                        .Override<Product>(e=>
                        {
                            e.Id(s=>s.StockNumber);
                            e.References(s=>s.Category,"CategoryId").Fetch.Join();
                            e.HasMany<ProductDetails>(s => s.ProductDetails)
                                .KeyColumn("Product")
                                .Inverse()
                                .Fetch.Join();
                            e.HasMany<ProductPricesHistory>(s => s.PriceHistory)
                                .KeyColumn("StockNumber")
                                .Inverse()
                                .Fetch.Join();
                            
                        })
                          .Override<ProductPricesHistory>(e =>
                          {
                              e.References(s => s.StockNumber, "StockNumber").Fetch.Join();
                          })
                        .Override<ProductDetails>(e=>
                        {
                            e.Id(s => s.Code);                            
                            e.References(s => s.Color, "Color").Fetch.Join();
                            e.References(s => s.Washing, "Washing").Fetch.Join();
                            e.References(s => s.Size, "Size").Fetch.Join();
                            e.References(s => s.Product, "Product").Fetch.Join();
                            e.HasMany<DeliveryDetail>(d => d.DeliveryDetails).KeyColumn("ProductDetail").Inverse().Fetch.Join();
                            e.HasMany<DeliveryToOutletDetail>(d => d.DeliveryToOutletDetails).KeyColumn("ProductDetail").Inverse().Fetch.Join();
                            e.HasMany<Sales>(d => d.Sales).KeyColumn("ProductDetail").Inverse().Fetch.Join();
                                                                                            
                        })
                        .Override<Delivery>(e=>{
                            e.References(d => d.Supplier, "Supplier").Fetch.Join();
                            e.HasMany<DeliveryDetail>(d => d.DeliveryDetails).KeyColumn("Delivery").Inverse().Fetch.Join();
                        })
                        .Override<DeliveryDetail>(e=>{
                            e.References(d => d.ProductDetail, "ProductDetail").Fetch.Join();                            
                            e.References(d => d.Delivery, "Delivery").Fetch.Join();
                        })
                        .Override<Sales>(e=>{
                            e.References(d => d.Outlet, "Outlet").Fetch.Join();
                            e.References(d => d.ProductDetail, "ProductDetail").Fetch.Join();  
                        })
                        .Override<DeliveryToOutlet>(e=>{
                            e.References(d=>d.Outlet,"Outlet").Fetch.Join();
                            e.HasMany<DeliveryToOutletDetail>(d => d.DeliveryToOutletDetails).KeyColumn("DeliveryToOutlet").Inverse().Fetch.Join();
                        })
                        .Override<DeliveryToOutletDetail>(e=>{
                            e.References(d => d.DeliveryToOutlet, "DeliveryToOutlet").Fetch.Join();
                            e.References(d => d.ProductDetail, "ProductDetail").Fetch.Join();
                        })
                        );                 
                }).BuildConfiguration();     
            
            SessionFactory = config.BuildSessionFactory();        
        }



        public List<T> SelectAll<T>() where T : class, new()
        {
            var returnValue = new List<T>();

            using (var session = SessionFactory.OpenSession())
            {
                returnValue = session.CreateCriteria<T>().List<T>().ToList<T>();
            }

            return returnValue;
        }

        public T SelectPrimary<T, D>(D primaryValue) where T : class, new()
        {
            var returnValue = new T();

            using (var session = SessionFactory.OpenSession())
            {
                returnValue = session.Get<T>(primaryValue);
            }

            return returnValue;
        }

        public void SaveOrUpdate<T>(T entity) where T : class, new()
        {
            using (var session = SessionFactory.OpenSession())
            {                
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        public List<T> SelectSp<T>(string spName) where T : class, new()
        {
            return SelectSp<T>(spName, null);
        }

        public List<T> SelectSp<T>(string spName, Dictionary<string, object> parameters) where T : class, new()
        {
            var returnValue = new List<T>();

            using (var session = SessionFactory.OpenSession())
            {
                IQuery query = session.CreateSQLQuery(spName).AddEntity(typeof(T));
                

                if (parameters != null)
                {
                    foreach (string parameterName in parameters.Keys)
                    {
                        query.SetParameter(parameterName, parameters[parameterName]);
                    }
                }

                returnValue = query.List<T>().ToList<T>();

                
            }

            return returnValue;
        }
       
        public void Delete<T>(T model)
        {
            using (var session = SessionFactory.OpenSession())
            {
                session.Delete(model);
                session.Flush();
            }
        }
    }
}
