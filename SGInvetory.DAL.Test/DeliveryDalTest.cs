using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SGInventory.Dal;
using SGInventory.Helpers;
using NHibernate;
using SGInventory.Model;
using SGInventory.Test.Data;
using NHibernate.Criterion;

namespace SGInventory.DAL.Test
{
    [TestClass]
    public class DeliveryDalTest
    {
        private Mock<ISgiHelper> _helper;
        private IDeliveryDal _deliveryDal;
        private Mock<IDataHelper> _dataHelper;
        private Mock<ISessionFactory> _sessionFactory;
        private Mock<IProductDetailDal> _productDetailDal;
        private Mock<ISession> _session;
        private Mock<ITransaction> _transaction;

        private ProductDetails _productDetail;
        private Delivery _delivery;
        private List<Delivery> _deliveries;
        public DeliveryDalTest()
        {
            _helper = new Mock<ISgiHelper>(MockBehavior.Strict);
            _dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            _sessionFactory = new Mock<ISessionFactory>(MockBehavior.Strict);
            _session = new Mock<ISession>(MockBehavior.Strict);
            _productDetailDal = new Mock<IProductDetailDal>(MockBehavior.Strict);
            _transaction = new Mock<ITransaction>(MockBehavior.Strict);

            _helper.SetupGet(h => h.DataHelper).Returns(_dataHelper.Object);
            _dataHelper.SetupGet(d => d.SessionFactory).Returns(_sessionFactory.Object);

            _deliveryDal = new DeliveryDal(_helper.Object);

            var productDetailTestData = new ProductDetailTestData();
            _productDetail = productDetailTestData.GetEntity();

            var deliveryTestData = new DeliveryTestData();
            _delivery = deliveryTestData.GetEntity();
            _deliveries = deliveryTestData.GetEntities();
        }
        
        [TestMethod]
        public void SaveDelivery_Test()
        {
            
            _delivery.DeliveryDetails = new List<DeliveryDetail>();           
            _sessionFactory.Setup(f => f.OpenSession()).Returns(_session.Object);            
            _session.Setup(s => s.BeginTransaction()).Returns(_transaction.Object);
            _session.Setup(s => s.SaveOrUpdate(_delivery));                        
            _transaction.Setup(t => t.Commit());
            _transaction.Setup(t => t.Dispose());
            _session.Setup(s => s.Dispose());

            _deliveryDal.SaveOrUpdate(_delivery);
           
            _sessionFactory.VerifyAll();
            _session.VerifyAll();
            _transaction.VerifyAll();
        }

      

        [TestMethod]
        public void SaveDeliveryDetail_Test()
        {
            var sampleProductDetailId = "W0110046S2";
            ProductDetails productDetailMock = _productDetail;
            _sessionFactory.Setup(f => f.OpenSession()).Returns(_session.Object);
            _session.Setup(s => s.Get<ProductDetails>(sampleProductDetailId)).Returns(productDetailMock);
            _session.Setup(s => s.BeginTransaction()).Returns(_transaction.Object);            
            _session.Setup(s => s.SaveOrUpdate(_delivery.DeliveryDetails[0]));
            _session.Setup(s => s.SaveOrUpdate(It.IsAny<ProductDetails>()));
            _transaction.Setup(t => t.Commit());
            _transaction.Setup(t => t.Dispose());
            _session.Setup(s => s.Dispose());

            _deliveryDal.SaveDeliveryDetail(_delivery.DeliveryDetails[0]);
            
            _sessionFactory.VerifyAll();
            _session.VerifyAll();
            _transaction.VerifyAll();

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SaveDeliveryDetail_ReturnsException_Test()
        {
            var sampleProductDetailId = "W0110046S2";
            ProductDetails productDetailMock = _productDetail;
            _sessionFactory.Setup(f => f.OpenSession()).Returns(_session.Object);
            _session.Setup(s => s.Get<ProductDetails>(sampleProductDetailId)).Returns(productDetailMock);
            _session.Setup(s => s.BeginTransaction()).Returns(_transaction.Object);
            _session.Setup(s => s.SaveOrUpdate(_delivery.DeliveryDetails[0]));
            _session.Setup(s => s.SaveOrUpdate(It.IsAny<ProductDetails>())).Throws(new Exception("sample"));
            _transaction.Setup(t => t.Rollback());
            _transaction.Setup(t => t.Dispose());
            _session.Setup(s => s.Dispose());

            _deliveryDal.SaveDeliveryDetail(_delivery.DeliveryDetails[0]);

            _sessionFactory.VerifyAll();
            _session.VerifyAll();
            _transaction.VerifyAll();

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SaveDelivery_When_Exception()
        {
            
            _sessionFactory.Setup(f => f.OpenSession()).Returns(_session.Object);           
            _session.Setup(s => s.BeginTransaction()).Returns(_transaction.Object);
            _session.Setup(s => s.SaveOrUpdate(_delivery)).Throws(new Exception("sample"));                        
            _transaction.Setup(t => t.Rollback());
            _transaction.Setup(t => t.Dispose());
            _session.Setup(s => s.Dispose());

            _deliveryDal.SaveOrUpdate(_delivery);
            
            _sessionFactory.VerifyAll();
            _session.VerifyAll();
            _transaction.VerifyAll();

        }

        [TestMethod]
        public void SelectBySupplier_Test()
        {
            var criteria = new Mock<ICriteria>(MockBehavior.Strict);
            _sessionFactory.Setup(f => f.OpenSession()).Returns(_session.Object);
            _session.Setup(s => s.CreateCriteria<Delivery>()).Returns(criteria.Object);
            criteria.Setup(c => c.Add(It.IsAny<ICriterion>())).Returns(criteria.Object);
            criteria.Setup(c => c.List<Delivery>()).Returns(_deliveries);
            _session.Setup(f => f.Dispose());

            var deliveries = _deliveryDal.SelectBySupplier(new Supplier { Id = 1 });

            criteria.VerifyAll();
            _sessionFactory.VerifyAll();
            _session.VerifyAll();

        }

        [TestMethod]
        public void SelectByDeliveryDate_Test()
        {
            var criteria = new Mock<ICriteria>(MockBehavior.Strict);
            _sessionFactory.Setup(f => f.OpenSession()).Returns(_session.Object);
            _session.Setup(s => s.CreateCriteria<Delivery>()).Returns(criteria.Object);
      
            criteria.Setup(c => c.Add(It.IsAny<AbstractCriterion>())).Returns(criteria.Object);
            criteria.Setup(c => c.List<Delivery>()).Returns(_deliveries);
            _session.Setup(f => f.Dispose());

            var deliveries = _deliveryDal.SelectByDeliveryDate(DateTime.Now);

            criteria.VerifyAll();
            _sessionFactory.VerifyAll();
            _session.VerifyAll();

        }

        [TestMethod]
        public void SelectBySupplierAndDeliveryDate_Test()
        {
            var criteria = new Mock<ICriteria>(MockBehavior.Strict);
            _sessionFactory.Setup(f => f.OpenSession()).Returns(_session.Object);
            _session.Setup(s => s.CreateCriteria<Delivery>()).Returns(criteria.Object);
            
            criteria.SetupSequence(c => c.Add(It.IsAny<ICriterion>()))
                .Returns(criteria.Object)
                .Returns(criteria.Object);
            criteria.Setup(c => c.List<Delivery>()).Returns(_deliveries);
            _session.Setup(f => f.Dispose());

            var deliveries = _deliveryDal.SelectBySupplierAndDeliveryDate(DateTime.Now, new Supplier { Id = 1 });

            criteria.VerifyAll();
            _sessionFactory.VerifyAll();
            _session.VerifyAll();

        }
    }
}
