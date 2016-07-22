using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGInventory.Model;
using SGInventory.Helpers;
using Moq;
using SGInventory.Dal;
using SGInventory.Test.Data;
using NHibernate.Criterion;
using NHibernate.Criterion.Lambda;
using NHibernate;
using System.IO.IsolatedStorage;

namespace SGInventory.DAL.Test
{
    [TestClass]
    public class ProductDetailDalTest
    {
        private string   _stockNumber = "W011",
                         _month = "C",
                         _year = "M",
                         _colorCode = "004",
                         _washingCode = "6",
                         _sizeCode = "S2";

        private ProductDetails _productDetail;

        private TestDataBase<ProductDetails> _testData;

        public ProductDetailDalTest()
        {           
            _testData = new ProductDetailTestData();
            _productDetail = _testData.GetEntity();

        }
        [TestMethod]
        public void SelectByPrimaryKey_GivenPrimaryKey_ReturnShouldNotBeNull()
        {
           
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectPrimary<ProductDetails, string>(It.IsAny<string>())).Returns(_productDetail);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            IProductDetailDal abstractDal = new ProductDetailDal(sgiHelper.Object);
            var productDetail = abstractDal.SelectPrimaryEntity<string>(_productDetail.Code);

            Assert.IsNotNull(productDetail);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();

        }

        [TestMethod]
        public void SelectByParent_Test()
        {
            List<Color> colors = new List<Color>
                                            {
                                                new Color{Code ="001",Name="Navy Blue",CreatedBy="sang",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,ModifiedBy="sang"},
                                                new Color{Code ="002",Name="Khaki",CreatedBy="sang",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,ModifiedBy="sang"}
                                            };

            string spName = "spTest";
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectSp<Color>(spName)).Returns(colors);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            IColorDal abstractDal = new ColorDal(sgiHelper.Object);

            List<Color> actualCategories = abstractDal.SelectBySpQuery(spName);

            Assert.AreEqual(colors.Count, actualCategories.Count);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }
        
        [TestMethod]
        public void SaveOrUpdateGivenItIsNewTest()
        {           
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            var sessionFactory = new Mock<ISessionFactory>(MockBehavior.Strict);
            var session=new Mock<ISession>(MockBehavior.Strict);
       
            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);
            dataHelper.SetupGet<ISessionFactory>(d=>d.SessionFactory).Returns(sessionFactory.Object);

            dataHelper.Setup(d=>d.SelectPrimary<ProductDetails,string>(It.IsAny<string>())).Returns(new ProductDetails());
            sessionFactory.Setup(f => f.OpenSession()).Returns(session.Object);
            session.Setup(s => s.Save(It.IsAny<object>())).Returns(_productDetail);
            session.Setup(s => s.Flush());
            session.Setup(s => s.Dispose());

            IProductDetailDal abstractDal = new ProductDetailDal(sgiHelper.Object);

            abstractDal.SaveOrUpdate(_productDetail);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();                     
        
        }
        
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SaveOrUpdateGivenItIsNotNewAndNoChangesMadeInQuantityAndThereIsExceptionTest()
        {
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            var sessionFactory = new Mock<ISessionFactory>(MockBehavior.Strict);
            var session = new Mock<ISession>(MockBehavior.Strict);
            var transaction = new Mock<ITransaction>(MockBehavior.Strict);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);
            dataHelper.SetupGet<ISessionFactory>(d => d.SessionFactory).Returns(sessionFactory.Object);

            dataHelper.Setup(d => d.SelectPrimary<ProductDetails, string>(It.IsAny<string>())).Returns(_productDetail);
            sessionFactory.Setup(f => f.OpenSession()).Returns(session.Object);
            session.Setup(s => s.Update(It.IsAny<object>()));
            session.Setup(s => s.Flush());
            session.Setup(s => s.Dispose());
            session.SetupGet<ITransaction>(s => s.Transaction).Returns(transaction.Object);
         
            var productionDetailQuantityHistory = new ProductDetailQuantityHistory
            {
                Barcode = _productDetail.Code,
                CreatedBy = "sang",
                CreatedDate = DateTime.Now,
                Quantity = _productDetail.QuantityOnHand,
                Id = 1
            };

            transaction.Setup(t => t.Begin());        
            session.Setup(s => s.Save(It.IsAny<object>())).Throws(new Exception("Test Exception"));
            transaction.Setup(t => t.Rollback());
            transaction.Setup(s => s.Dispose());
            IProductDetailDal abstractDal = new ProductDetailDal(sgiHelper.Object);

            var productDetail = new ProductDetails
            {
                Code = _productDetail.Code,
                Color = _productDetail.Color,               
                CreatedBy = _productDetail.CreatedBy,
                CreatedDate = _productDetail.CreatedDate,               
                ModifiedBy = "sang",
                ModifiedDate = DateTime.Now,
               
                Product = _productDetail.Product,
                QuantityOnHand = 350,    
                Size = _productDetail.Size,
                Washing = _productDetail.Washing,
                
            };

            abstractDal.SaveOrUpdate(productDetail);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();
            transaction.VerifyAll();

        }

        [TestMethod]
        public void SaveOrUpdateGivenItIsNotNewAndChangesMadeInQuantityTest()
        {
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            var sessionFactory = new Mock<ISessionFactory>(MockBehavior.Strict);
            var session = new Mock<ISession>(MockBehavior.Strict);
            var transaction = new Mock<ITransaction>(MockBehavior.Strict);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);
            dataHelper.SetupGet<ISessionFactory>(d => d.SessionFactory).Returns(sessionFactory.Object);

            dataHelper.Setup(d => d.SelectPrimary<ProductDetails, string>(It.IsAny<string>())).Returns(_productDetail);
            sessionFactory.Setup(f => f.OpenSession()).Returns(session.Object);
            session.Setup(s => s.Update(It.IsAny<object>()));
            session.Setup(s => s.Flush());
            session.Setup(s => s.Dispose());
            session.SetupGet<ITransaction>(s => s.Transaction).Returns(transaction.Object);
                    
            var productionDetailQuantityHistory = new ProductDetailQuantityHistory
            {
                Barcode = _productDetail.Code,
                CreatedBy="sang",
                CreatedDate=DateTime.Now,
                Quantity=_productDetail.QuantityOnHand,
                Id=1
            };

            transaction.Setup(t => t.Begin());           
            session.Setup(s => s.Save(It.IsAny<object>())).Returns(productionDetailQuantityHistory);
            transaction.Setup(t => t.Commit());
            transaction.Setup(s => s.Dispose());
            IProductDetailDal abstractDal = new ProductDetailDal(sgiHelper.Object);

            var productDetail = new ProductDetails
            {
                Code = _productDetail.Code,
                Color = _productDetail.Color,             
                CreatedBy = _productDetail.CreatedBy,
                CreatedDate = _productDetail.CreatedDate,               
                ModifiedBy = "sang",
                ModifiedDate = DateTime.Now,
         
                Product = _productDetail.Product,
                QuantityOnHand = 350,             
                Size = _productDetail.Size,
                Washing = _productDetail.Washing,
          
            };

            abstractDal.SaveOrUpdate(productDetail);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();
            transaction.VerifyAll();

        }

        [TestMethod]
        public void Delete()
        {           
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.Delete<ProductDetails>(_productDetail));

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);

            IProductDetailDal abstractDal = new ProductDetailDal(sgiHelper.Object);

            abstractDal.Delete(_productDetail);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();
        }

        [TestMethod]
        public void SelectByBarcodeTest()
        {
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            var sessionFactory = new Mock<ISessionFactory>(MockBehavior.Strict);
            var session = new Mock<ISession>(MockBehavior.Strict);
            var criteria = new Mock<ICriteria>(MockBehavior.Strict);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);
            dataHelper.SetupGet<ISessionFactory>(d => d.SessionFactory).Returns(sessionFactory.Object);
            sessionFactory.Setup(f => f.OpenSession()).Returns(session.Object);
            session.Setup(s => s.CreateCriteria<ProductDetails>()).Returns(criteria.Object);
            criteria.Setup(c => c.Add(It.IsAny<NHibernate.Criterion.ICriterion>())).Returns(criteria.Object);
            criteria.Setup(c => c.List<ProductDetails>()).Returns(new List<ProductDetails> { _productDetail});
            session.Setup(s => s.Dispose());
            var productDal = new ProductDetailDal(sgiHelper.Object);
            var expectedResults = productDal.SelectByBarcode("W-");

            dataHelper.VerifyAll();
            sessionFactory.VerifyAll();
            session.VerifyAll();
            criteria.VerifyAll();
        }
        
    }
}
