using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SGInventory.Dal;
using SGInventory.Business.Model;
using SGInventory.Model;
using SGInventory.Test.Data;
namespace SGInventory.BusinessModel.Test
{
    [TestClass]
    public class ProductDetailBusinessModelTest
    {
        private Mock<IProductDetailDal> _dalMoq;
        private IProductDetailBusinessModel _businessModel;
        private ProductDetails _model;
        private List<ProductDetails> _models;
        public ProductDetailBusinessModelTest()
        {
            var testData = new ProductDetailTestData();
            _model = testData.GetEntity();
            _models = testData.GetEntities();
            _dalMoq = new Mock<IProductDetailDal>(MockBehavior.Strict);
            _businessModel = new ProductDetailBusinessModel(_dalMoq.Object);
        }

        [TestMethod]
        public void Save_GivenBarcodeNotExists_ReturnNewInstance_Successfull_Test()
        {
            _dalMoq.Setup(s => s.SelectPrimaryEntity<string>(It.IsAny<string>())).Returns(new ProductDetails());      
            _dalMoq.Setup(s => s.SaveOrUpdate(It.IsAny<ProductDetails>()));

            var message = _businessModel.Save(_model);

            Assert.AreEqual("A Product Detail has been saved", message);

            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void Save_GivenBarcodeNotExists_ReturnOldInstance_Successfull_Test()
        {
            _dalMoq.Setup(s => s.SelectPrimaryEntity<string>(It.IsAny<string>())).Returns(new ProductDetails());
            _dalMoq.Setup(s => s.SaveOrUpdate(It.IsAny<ProductDetails>()));

            _model.Code = "XX";
            var message = _businessModel.Save(_model);

            Assert.AreEqual("A Product Detail has been saved", message);

            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void Save_GivenBarcodeExists_ReturnNull_Successfull_Test()
        {
          
            _dalMoq.Setup(s => s.SelectPrimaryEntity<string>(It.IsAny<string>())).Returns(_model);            
            var message = _businessModel.Save(_model);

            Assert.AreEqual("Product Detail already Exists", message);

            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void SelectByParent_ReturnsList_Test()
        {
            _dalMoq.Setup(d => d.SelectByParent(It.IsAny<Product>())).Returns(_models);

            var models = _businessModel.SelectByParent(new Product { StockNumber = _models[0].Product.StockNumber });

            Assert.IsTrue(models.Count == _models.Count);
        }

    

    }
}
