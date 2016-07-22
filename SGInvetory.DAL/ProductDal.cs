using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using NHibernate.Criterion;
using SGInventory.Helpers;
using System.Configuration;

namespace SGInventory.Dal
{
    public class ProductDal:DalBase<Product>, IProductDal
    {        
        public ProductDal(Helpers.ISgiHelper iSgiHelper):base(iSgiHelper)
        {
                        
        }

        public List<Product> SelectAll()
        {
            return _helper.DataHelper.SelectAll<Product>();
        }
        
        public Product SelectPrimaryEntity<D>(D primaryValue)
        {
            return _helper.DataHelper.SelectPrimary<Product, D>(primaryValue);
        }

        public List<Product> SelectBySpQuery(string spName, Dictionary<string, object> parameters)
        {
            return _helper.DataHelper.SelectSp<Product>(spName, parameters);
        }

        public void SaveOrUpdate(Product entity)
        {
            var product = SelectPrimaryEntity<string>(entity.StockNumber);
            var isNew = product==null||string.IsNullOrEmpty(product.StockNumber);

            using (var session = _helper.DataHelper.SessionFactory.OpenSession())
            {
                if (isNew)
                {
                    session.Save(entity);
                    session.Flush();
                }
                else
                {
                    using (var transaction = session.Transaction)
                    {
                        transaction.Begin();
                        try
                        {
                            session.Update(entity);

                            if (
                                product.Cost != entity.Cost
                                || product.RegularPrice != entity.RegularPrice
                                || product.MarkdownPrice != entity.MarkdownPrice
                                )
                            {
                                session.Save(new ProductPricesHistory
                                {
                                    StockNumber = product,
                                    Cost = product.Cost,
                                    CreatedBy = product.ModifiedBy,
                                    CreatedDate = product.ModifiedDate.Value,
                                    MarkdownPrice = product.MarkdownPrice,
                                    RegularPrice = product.RegularPrice
                                });
                            }
                            
                            transaction.Commit();
                            session.Flush();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
                
            }
            
        }

        public List<Product> SelectBySpQuery(string spName)
        {
            return _helper.DataHelper.SelectSp<Product>(spName);
        }

        public void Delete(Product model)
        {
            _helper.DataHelper.Delete<Product>(model);
        }

        public List<Product> SelectByStockNumber(string stockOrBarcode)
        {
            var products = new List<Product>();

            var columnName = "StockNumber";
            
            using (var session = _helper.DataHelper.SessionFactory.OpenSession())
            {
                products = session.CreateCriteria<Product>()                  
                    .Add(Expression.Like(columnName, string.Format("%{0}%", stockOrBarcode)))              
                    .List<Product>()
                    .ToList<Product>();
            }
                                 
            return products;
        }

        public void SaveTransaction(Product model)
        {
            using (var session = _helper.DataHelper.SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var isNew = model == null || string.IsNullOrEmpty(model.StockNumber);

                        session.SaveOrUpdate(model);

                        foreach (var detail in model.ProductDetails)
                        {
                            session.SaveOrUpdate(detail);
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

        
        public void SaveTransaction(Product model, List<ProductDetails> productDetails)
        {
            var product = SelectPrimaryEntity<string>(model.StockNumber);
            var isNew = product == null || string.IsNullOrEmpty(product.StockNumber);

            using (var session = _helper.DataHelper.SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {                        
                        session.SaveOrUpdate(model);

                        foreach (var productDetail in productDetails)
                        {
                            var query = model.ProductDetails.Where(pd => pd.IsActive == 1 && pd.Code == productDetail.Code);
                            if (query.Count() == 0)
                            {
                                productDetail.IsActive = 0;
                                session.SaveOrUpdate(productDetail);
                            }
                            else
                            {
                                var selectedProductDetail = query.First();
                                selectedProductDetail.CreatedBy = productDetail.CreatedBy;
                                selectedProductDetail.CreatedDate = productDetail.CreatedDate;
                                selectedProductDetail.IsActive = 1;
                            }
                        }
                       
                        foreach (var detail in model.ProductDetails)
                        {
                            session.SaveOrUpdate(detail);
                          
                        }

                        if (!isNew)
                        {
                            if (
                               product.Cost != model.Cost
                               || product.RegularPrice != model.RegularPrice
                               || product.MarkdownPrice != model.MarkdownPrice
                               )
                            {
                                session.Save(new ProductPricesHistory
                                {
                                    StockNumber = model,
                                    Cost = product.Cost,
                                    CreatedBy = product.CreatedBy,
                                    CreatedDate = product.CreatedDate,
                                    MarkdownPrice = product.MarkdownPrice,
                                    RegularPrice = product.RegularPrice
                                });
                            }
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


        public List<Product> SelectBySearch(string searchBy, string searchValue)
        {
            var result = new List<Product>();
            if (searchBy == SgiHelper.SEARCH_ALL)
            {
                result = SelectAll();
                return result;
            }
            
            using (var session = _helper.DataHelper.SessionFactory.OpenSession())
            {
                switch (searchBy)
                {
                    case SgiHelper.PRODUCT_SEARCH_STOCKNUMBER:
                        result = session.CreateCriteria<Product>()
                                .Add(
                                Expression.Like("StockNumber", string.Format("%{0}%",searchValue))
                                )
                                .List<Product>().ToList<Product>();
                        break;
                    case SgiHelper.PRODUCT_SEARCH_CATEGORYNAME:                        
                        result = session.CreateCriteria<Product>()
                            .CreateAlias("Category", "cat")
                            .Add(
                            Expression.Like("cat.Name", string.Format("%{0}%", searchValue))
                            ).List<Product>().ToList<Product>();
                                    
                        break;                   
                }
                
            }


            return result;
        }


        public List<ProductPricesHistory> GetProductHistoryByStockNumber(string stockNumber)
        {
            var productPricesHistory = new List<ProductPricesHistory>();
           
            using (var session = _helper.DataHelper.SessionFactory.OpenSession())
            {
                productPricesHistory = session.CreateCriteria<ProductPricesHistory>()
                    .Add(Expression.Eq("StockNumber", new Product { StockNumber = stockNumber }))
                    .List<ProductPricesHistory>()
                    .ToList<ProductPricesHistory>();
            }
            return productPricesHistory;
        }
        
    }
}
