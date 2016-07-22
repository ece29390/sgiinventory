using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using NHibernate.Criterion;
using NHibernate.Criterion.Lambda;
using SGInventory.DAL;
using NHibernate;

namespace SGInventory.Dal
{
    public class ProductDetailDal:DalBase<ProductDetailDal>, IProductDetailDal
    {       
        public ProductDetailDal(Helpers.ISgiHelper sgiHelper):base(sgiHelper)
        {          
        }

        public List<Model.ProductDetails> SelectAll()
        {
            return _helper.DataHelper.SelectAll<ProductDetails>();
        }

        public Model.ProductDetails SelectPrimaryEntity<D>(D primaryValue)
        {
            return _helper.DataHelper.SelectPrimary<ProductDetails, D>(primaryValue);
        }

        public List<Model.ProductDetails> SelectBySpQuery(string spName, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public void SaveOrUpdate(Model.ProductDetails entity)
        {
          
            var productDetail = SelectPrimaryEntity<string>(entity.Code);
            using (var session = _helper.DataHelper.SessionFactory.OpenSession())
            {
                if (productDetail==null||string.IsNullOrEmpty(productDetail.Code))
                {
                    var saveProductDetail = session.Save(entity);
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
                            if (productDetail.QuantityOnHand != entity.QuantityOnHand)
                            {
                                session.Save(new ProductDetailQuantityHistory
                                {
                                    Barcode = entity.Code,
                                    StockNumber = productDetail.Product.StockNumber,
                                    CreatedBy = entity.ModifiedBy,
                                    CreatedDate = entity.ModifiedDate.Value,
                                    Quantity = productDetail.QuantityOnHand
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

        public List<Model.ProductDetails> SelectBySpQuery(string spName)
        {
            throw new NotImplementedException();
        }

        public void Delete(Model.ProductDetails model)
        {
            _helper.DataHelper.Delete<ProductDetails>(model);
        }

    
        public List<ProductDetails> SelectByParent(Product parentEntity)
        {
            var ret = new List<ProductDetails>();

            using (var session = _helper.DataHelper.SessionFactory.OpenSession())
            {
                ret = session.CreateCriteria<ProductDetails>()
                    .Add(
                    Expression.Eq("Product", parentEntity)
                    )
                    .List<ProductDetails>().ToList<ProductDetails>();
            }

            return ret;
        }

        public List<ProductDetails> SelectByBarcode(string code)
        {
            var products = new List<ProductDetails>();

            var columnName = "Code";

            using (var session = _helper.DataHelper.SessionFactory.OpenSession())
            {
                products = session.CreateCriteria<ProductDetails>()
                    .Add(Expression.Like(columnName, string.Format("%{0}%", code)))
                    .Add(Expression.Eq("IsActive",1))
                    .List<ProductDetails>()
                    .ToList<ProductDetails>();
            }

            products = ReturnDistinctProductDetails(products);
                       
            return products;
        }

        private List<ProductDetails> ReturnDistinctProductDetails(List<ProductDetails> productDetails)
        {
            return productDetails.GroupBy((product) => product.Code).Select((product) => product.First()).ToList();
        }

        public List<ProductDetails> SelectActiveByParent(Product model)
        {
            var ret = new List<ProductDetails>();

            using (var session = _helper.DataHelper.SessionFactory.OpenSession())
            {
                ret = session.CreateCriteria<ProductDetails>()
                    .Add(Expression.Eq("Product", model))                    
                    .Add(Expression.Eq("IsActive",1))
                    .List<ProductDetails>().ToList<ProductDetails>();
            }
            ret = ReturnDistinctProductDetails(ret);
            return ret;
        }

        public List<ProductDetails> SelectByStockNumber(string code)
        {
            var products = new List<ProductDetails>();
            
            using (var session = _helper.DataHelper.SessionFactory.OpenSession())
            {
                products = session.CreateCriteria<ProductDetails>()
                    .CreateAlias("Product","prod")
                    .Add(Expression.Like("prod.StockNumber", string.Format("%{0}%", code)))
                    .Add(Expression.Eq("IsActive", 1))
                    .List<ProductDetails>()
                    .ToList<ProductDetails>();
            }

            products = ReturnDistinctProductDetails(products);
            
            return products;
        }

        public List<ProductInventoryView> SelectProductInterviewBy(string spName,Dictionary<string, object> parameters)
        {
            var retValue = new List<ProductInventoryView>();
            using (var session = _helper.DataHelper.SessionFactory.OpenSession())
            {
                IQuery query = session.CreateSQLQuery(spName).AddEntity(typeof(ProductInventoryView));
                if (parameters != null)
                {
                    foreach (string parameterName in parameters.Keys)
                    {
                        query.SetParameter(parameterName, parameters[parameterName]);
                    }
                }

                retValue = query.List<ProductInventoryView>().ToList<ProductInventoryView>();                
            }
            return retValue;
        }


        public ProductDetails SelectByStockNumberAndColorAndSizeAndStatus(string stockNumber, string color, string size, bool isactive)
        {
            var ret = new List<ProductDetails>();

            using (var session = _helper.DataHelper.SessionFactory.OpenSession())
            {
                ret = session.CreateCriteria<ProductDetails>()
                    .Add(Expression.Eq("Product", new Product { StockNumber = stockNumber }))
                    .Add(Expression.Eq("IsActive", isactive ? 1 : 0))
                    .Add(Expression.Eq("Color", new Color { Code = color }))
                    .Add(Expression.Eq("Size", new Size { Code = size }))
                    .List<ProductDetails>().ToList<ProductDetails>();
            }
            ret = ReturnDistinctProductDetails(ret);
            return ret.First();
        }
    }
}
