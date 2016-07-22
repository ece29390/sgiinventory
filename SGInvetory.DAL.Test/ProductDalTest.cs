using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGInventory.Enums;
using SGInventory.Dal;
using SGInventory.Helpers;
using Moq;
using SGInventory.Model;
using SGInventory.Test.Data;
using NHibernate;

namespace SGInvetory.DAL.Test
{
    [TestClass]
    public class ProductDalTest
    {
        private readonly Product _model;
        private readonly List<Product> _models;
        public ProductDalTest()
        {
            var productTestData = new ProductTestData();
            _model = productTestData.GetEntity();
            _models = productTestData.GetEntities();
        }

        [TestMethod]
        public void SaveOrUpdateGivenItIsNewTest()
        {
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            var sessionFactory = new Mock<ISessionFactory>(MockBehavior.Strict);
            var session = new Mock<ISession>(MockBehavior.Strict);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);
            dataHelper.SetupGet<ISessionFactory>(d => d.SessionFactory).Returns(sessionFactory.Object);

            dataHelper.Setup(d => d.SelectPrimary<Product, string>(It.IsAny<string>())).Returns(new Product());
            sessionFactory.Setup(f => f.OpenSession()).Returns(session.Object);
            session.Setup(s => s.Save(It.IsAny<object>())).Returns(_model);
            session.Setup(s => s.Flush());
            session.Setup(s => s.Dispose());

            var abstractDal = new ProductDal(sgiHelper.Object);

            abstractDal.SaveOrUpdate(_model);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();

        }

        [TestMethod]
        public void SaveOrUpdateGivenItIsProductIsNullTest()
        {
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            var sessionFactory = new Mock<ISessionFactory>(MockBehavior.Strict);
            var session = new Mock<ISession>(MockBehavior.Strict);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);
            dataHelper.SetupGet<ISessionFactory>(d => d.SessionFactory).Returns(sessionFactory.Object);

            Product mockProduct = null;
            dataHelper.Setup(d => d.SelectPrimary<Product, string>(It.IsAny<string>())).Returns(mockProduct);
            sessionFactory.Setup(f => f.OpenSession()).Returns(session.Object);
            session.Setup(s => s.Save(It.IsAny<object>())).Returns(_model);
            session.Setup(s => s.Flush());
            session.Setup(s => s.Dispose());

            var abstractDal = new ProductDal(sgiHelper.Object);

            abstractDal.SaveOrUpdate(_model);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();

        }

        [TestMethod]
        public void SaveOrUpdateGivenItIsNotNewAndNoChangesMadeEitherInPricesTest()
        {
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            var sessionFactory = new Mock<ISessionFactory>(MockBehavior.Strict);
            var session = new Mock<ISession>(MockBehavior.Strict);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);
            dataHelper.SetupGet<ISessionFactory>(d => d.SessionFactory).Returns(sessionFactory.Object);
            var transaction = new Mock<ITransaction>(MockBehavior.Strict);

            dataHelper.Setup(d => d.SelectPrimary<Product, string>(It.IsAny<string>())).Returns(_model);
            sessionFactory.Setup(f => f.OpenSession()).Returns(session.Object);
            session.Setup(s => s.Update(It.IsAny<object>()));
            session.Setup(s => s.Flush());
            session.Setup(s => s.Dispose());
            session.SetupGet<ITransaction>(s => s.Transaction).Returns(transaction.Object);
            transaction.Setup(t => t.Begin());
            transaction.Setup(t => t.Commit());
            transaction.Setup(s => s.Dispose());
            IProductDal abstractDal = new ProductDal(sgiHelper.Object);

            abstractDal.SaveOrUpdate(_model);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SaveOrUpdateGivenItIsNotNewAndThereIsExceptionTest()
        {
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            var sessionFactory = new Mock<ISessionFactory>(MockBehavior.Strict);
            var session = new Mock<ISession>(MockBehavior.Strict);
            var transaction = new Mock<ITransaction>(MockBehavior.Strict);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);
            dataHelper.SetupGet<ISessionFactory>(d => d.SessionFactory).Returns(sessionFactory.Object);

            dataHelper.Setup(d => d.SelectPrimary<Product, string>(It.IsAny<string>())).Returns(_model);
            sessionFactory.Setup(f => f.OpenSession()).Returns(session.Object);
            session.Setup(s => s.Update(It.IsAny<object>()));
            session.Setup(s => s.Flush());
            session.Setup(s => s.Dispose());
            session.SetupGet<ITransaction>(s => s.Transaction).Returns(transaction.Object);

            var productionPricesHistory = new ProductPricesHistory
            {
                StockNumber = _model,
                Cost = _model.Cost,
                MarkdownPrice = _model.MarkdownPrice,
                RegularPrice = _model.RegularPrice,
                CreatedBy = "sang",
                CreatedDate = DateTime.Now,
                Id = 1
            };

            transaction.Setup(t => t.Begin());
            session.Setup(s => s.Save(It.IsAny<object>())).Throws(new Exception("Test Exception"));
            transaction.Setup(t => t.Rollback());
            transaction.Setup(s => s.Dispose());
            IProductDal abstractDal = new ProductDal(sgiHelper.Object);

            var product = new Product
            {
                CreatedBy = _model.CreatedBy,
                CreatedDate = _model.CreatedDate,
                ModifiedBy = "sang",
                ModifiedDate = DateTime.Now,
                StockNumber = _model.StockNumber,
                RegularPrice = 2001.50,
                Cost = 1001.50,
                MarkdownPrice = 1501.50
            };
            abstractDal.SaveOrUpdate(product);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();
            transaction.VerifyAll();

        }

        [TestMethod]
        public void SaveOrUpdateGivenItIsNotNewAndChangesMadeInPricesTest()
        {
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            var sessionFactory = new Mock<ISessionFactory>(MockBehavior.Strict);
            var session = new Mock<ISession>(MockBehavior.Strict);
            var transaction = new Mock<ITransaction>(MockBehavior.Strict);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);
            dataHelper.SetupGet<ISessionFactory>(d => d.SessionFactory).Returns(sessionFactory.Object);

            dataHelper.Setup(d => d.SelectPrimary<Product, string>(It.IsAny<string>())).Returns(_model);
            sessionFactory.Setup(f => f.OpenSession()).Returns(session.Object);
            session.Setup(s => s.Update(It.IsAny<object>()));
            session.Setup(s => s.Flush());
            session.Setup(s => s.Dispose());
            session.SetupGet<ITransaction>(s => s.Transaction).Returns(transaction.Object);



            var productionPricesHistory = new ProductPricesHistory
            {
                StockNumber = _model,
                Cost = _model.Cost,
                MarkdownPrice = _model.MarkdownPrice,
                RegularPrice = _model.RegularPrice,
                CreatedBy = "sang",
                CreatedDate = DateTime.Now,
                Id = 1
            };
          
            transaction.Setup(t => t.Begin());
            session.Setup(s => s.Save(It.IsAny<object>())).Returns(productionPricesHistory);
            transaction.Setup(t => t.Commit());
            transaction.Setup(s => s.Dispose());
            IProductDal abstractDal = new ProductDal(sgiHelper.Object);

            var product = new Product
            {
              
                CreatedBy = _model.CreatedBy,
                CreatedDate = _model.CreatedDate,
                ModifiedBy = "sang",
                ModifiedDate = DateTime.Now,
                StockNumber=_model.StockNumber,
                RegularPrice=2000.50,
                Cost = 1000.50,
                MarkdownPrice=1500.50
            };

            abstractDal.SaveOrUpdate(product);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();
            transaction.VerifyAll();

        }
    
        [TestMethod]
        public void SelectByPrimaryKey_GivenPrimaryKey_ReturnShouldNotBeNull()
        {
                   
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectPrimary<Product, string>(It.IsAny<string>())).Returns(_model);

            var sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);

            IProductDal abstractDal = new ProductDal(sgiHelper.Object);

            var actualProduct= abstractDal.SelectPrimaryEntity<string>("W-011");

            Assert.AreEqual(_model.StockNumber, actualProduct.StockNumber);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();
        }

        [TestMethod]
        public void SelectAllTest()
        {
            

            var mockList = new List<Product> { _model };

            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectAll<Product>()).Returns(mockList);

            var sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);

            IProductDal abstractDal = new ProductDal(sgiHelper.Object);
            abstractDal.SelectAll();

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();

        }

        [TestMethod]
        public void Delete()
        {           
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.Delete<Product>(It.IsAny<Product>()));

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);

            IProductDal abstractDal = new ProductDal(sgiHelper.Object);

            abstractDal.Delete(_model);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();
        }

        [TestMethod]
        public void SelectByStockNumberTest()
        {
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            var sessionFactory = new Mock<ISessionFactory>(MockBehavior.Strict);
            var session = new Mock<ISession>(MockBehavior.Strict);
            var criteria=new Mock<ICriteria>(MockBehavior.Strict);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);
            dataHelper.SetupGet<ISessionFactory>(d => d.SessionFactory).Returns(sessionFactory.Object);
            sessionFactory.Setup(f => f.OpenSession()).Returns(session.Object);
            session.Setup(s => s.CreateCriteria<Product>()).Returns(criteria.Object);
            criteria.Setup(c => c.Add(It.IsAny<NHibernate.Criterion.ICriterion>())).Returns(criteria.Object);
            criteria.Setup(c => c.List<Product>()).Returns(_models);
            session.Setup(s => s.Dispose());
            var productDal = new ProductDal(sgiHelper.Object);
            var expectedResults = productDal.SelectByStockNumber("W-");

            dataHelper.VerifyAll();
            sessionFactory.VerifyAll();
            session.VerifyAll();
            criteria.VerifyAll();
        }
    }
}
