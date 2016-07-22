using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SGInventory.Dal;
using SGInventory.Model;
using SGInventory.Test.Data;
using SGInventory.Business.Model;
using SGInventory.Enums;

namespace SGInventory.BusinessModel.Test
{
    [TestClass]
    public class DeliveryBusinessModelTest
    {
        private readonly Mock<IDeliveryDal> _deliveryDalMock;
        private readonly Mock<IProductDetailDal> _productDetailDalMock;
        private readonly Mock<ISupplierDal> _supplierBusinessModelMock;

        private ProductDetails _productDetail;
        private List<ProductDetails> _productDetails;
        private List<Supplier> _suppliers;
        private Supplier _supplier;
        private List<Delivery> _deliveries;
        private readonly IDeliveryBusinessModel _businessModel;

        public DeliveryBusinessModelTest()
        {
            _deliveryDalMock = new Mock<IDeliveryDal>(MockBehavior.Strict);
            _productDetailDalMock = new Mock<IProductDetailDal>(MockBehavior.Strict);
            _supplierBusinessModelMock = new Mock<ISupplierDal>(MockBehavior.Strict);

            var productDetailsTestData = new ProductDetailTestData();
            _productDetail = productDetailsTestData.GetEntity();
            _productDetails = productDetailsTestData.GetEntities();
            var suppliersTestData = new SupplierTestData();
            _suppliers = suppliersTestData.GetEntities();
            _supplier = suppliersTestData.GetEntity();
            _deliveries = new DeliveryTestData().GetEntities();

            _businessModel = new DeliveryBusinessModel(_deliveryDalMock.Object, _supplierBusinessModelMock.Object);

        }

        [TestMethod]
        public void SaveDelivery_Test()
        {          
            _deliveryDalMock.Setup(d => d.SaveOrUpdate(It.IsAny<Delivery>()));

            var delivery=new Delivery
            {
                DeliveryDate=new DateTime(2013,03,15),
                OrNumber="RCPT101",             
                Supplier=_supplier,
               DeliveryDetails=new List<DeliveryDetail>{
                    new DeliveryDetail{                       
                        Quantity=1200,                      
                        Status=(int)ProductStatus.Goods,
                        ProductDetail=new ProductDetails()//,
                        //Product = _productDetail.Product
                    }               
               }
            };
          
            Assert.AreEqual(DeliveryBusinessModel.DeliverySuccessfulMessage, _businessModel.Save(delivery));          
            _deliveryDalMock.VerifyAll();
        }
      
        [TestMethod]
        public void SaveDeliveryDetail_Test()
        {
            _deliveryDalMock.Setup(d => d.SaveDeliveryDetail(It.IsAny<DeliveryDetail>()));

            var delivery = new Delivery
            {
                DeliveryDate = new DateTime(2013, 03, 15),
                OrNumber = "RCPT101",
                Supplier = _supplier,
                DeliveryDetails = new List<DeliveryDetail>{
                    new DeliveryDetail{                       
                        Quantity=1200,                      
                        Status=(int)ProductStatus.Goods,
                        ProductDetail=new ProductDetails()//,
                        //Product = _productDetail.Product
                    }               
               }
            };

            Assert.AreEqual(DeliveryBusinessModel.DeliveryDetailSuccessfulMessage, _businessModel.SaveDeliveryDetail(delivery.DeliveryDetails[0]));
            _deliveryDalMock.VerifyAll();
        }

        [TestMethod]
        public void SelectBySupplier_Test()
        {
            _deliveryDalMock.Setup(d => d.SelectBySupplier(It.IsAny<Supplier>())).Returns(_deliveries);
            _supplierBusinessModelMock.Setup(s => s.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(_suppliers);

            _businessModel.SelectBySupplier("RTP");

            _deliveryDalMock.VerifyAll();
            _supplierBusinessModelMock.VerifyAll();
        }

        [TestMethod]
        public void SelectByDeliveryDate_Test()
        {
           
            _deliveryDalMock.Setup(d => d.SelectByDeliveryDate(It.IsAny<DateTime>())).Returns(_deliveries);
            
            _businessModel.SelectByDeliveryDate(DateTime.Now,DateTime.Now.AddDays(5));

            _deliveryDalMock.VerifyAll();
        }

        [TestMethod]
        public void SelectBySupplierAndDeliveryDate_Test()
        {
            _supplierBusinessModelMock.Setup(s => s.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(_suppliers);
            _deliveryDalMock.Setup(d => d.SelectBySupplierAndDeliveryDate(It.IsAny<DateTime>(),It.IsAny<Supplier>())).Returns(_deliveries);

            _businessModel.SelectByBoth("RTP", DateTime.Now);

            _deliveryDalMock.VerifyAll();
            _supplierBusinessModelMock.VerifyAll();
        }

       
    }
}
