using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGInventory.Dal;
using SGInventory.Business.Model;
using SGInventory.Model;
using SGInventory.Enums;
using Moq;
using SGInventory.Test.Data;

namespace SGInventory.BusinessModel.Test
{
    [TestClass]
    public class ProductBusinessModelTest
    {
        private readonly Product _product;
        private readonly List<Product> _products;
        public ProductBusinessModelTest()
        {
            var productTestData = new ProductTestData();
            _product = productTestData.GetEntity();
            _products = productTestData.GetEntities();
        }
       
        [TestMethod]
        public void Save_GivenProduct_IsNew_And_None_And_Valid_Exists_Test()
        {
            var productMock = new Moq.Mock<IProductDal>(Moq.MockBehavior.Strict);
            var productDetailMock = new Moq.Mock<IProductDetailDal>(Moq.MockBehavior.Strict);
            var productBusinessModel = new ProductBusinessModel(productMock.Object, productDetailMock.Object);
            _product.ModifiedDate = null;
            productMock.Setup(d => d.SelectPrimaryEntity<string>(It.IsAny<string>())).Returns(new Product());
            productMock.Setup(d => d.SaveOrUpdate(It.IsAny<Product>()));
            Assert.AreEqual("A new Product has been added", productBusinessModel.Save(_product));

            productMock.VerifyAll();

        }

        [TestMethod]
        public void Save_GivenProduct_Has_Invalid_Format_Test()
        {
            var productMock = new Moq.Mock<IProductDal>(Moq.MockBehavior.Strict);
            var productDetailMock = new Moq.Mock<IProductDetailDal>(Moq.MockBehavior.Strict);
            var productBusinessModel = new ProductBusinessModel(productMock.Object, productDetailMock.Object);
            _product.StockNumber = "BT-01(White)";
            _product.ModifiedDate = null;            
            Assert.AreEqual("Only accepts alphanumerics and a dash characters", productBusinessModel.Save(_product));

            productMock.VerifyAll();

        }

        [TestMethod]
        public void Save_GivenProduct_Exists()
        {
            var productMock = new Moq.Mock<IProductDal>(Moq.MockBehavior.Strict);
            var productDetailMock = new Moq.Mock<IProductDetailDal>(Moq.MockBehavior.Strict);
            var productBusinessModel = new ProductBusinessModel(productMock.Object, productDetailMock.Object);
            _product.ModifiedDate = DateTime.Now;
           
            productMock.Setup(d => d.SaveOrUpdate(It.IsAny<Product>()));
            Assert.AreEqual("Product has been updated", productBusinessModel.Save(_product));
            productMock.VerifyAll();
        }

        [TestMethod]
        public void Save_GivenProduct_IsNew_And_StockNumber_Exists()
        {
            var productMock = new Moq.Mock<IProductDal>(Moq.MockBehavior.Strict);
            var productDetailMock = new Moq.Mock<IProductDetailDal>(Moq.MockBehavior.Strict);
            var productBusinessModel = new ProductBusinessModel(productMock.Object, productDetailMock.Object);
            _product.ModifiedDate = null;

            productMock.Setup(d => d.SelectPrimaryEntity<string>(It.IsAny<string>())).Returns(_product);
            
            Assert.AreEqual("Product Already Exists", productBusinessModel.Save(_product));
            productMock.VerifyAll();
        }
      
        [TestMethod]
        public void Delete_Test()
        {
            var productMock = new Moq.Mock<IProductDal>(Moq.MockBehavior.Strict);
            var productDetailMock = new Moq.Mock<IProductDetailDal>(Moq.MockBehavior.Strict);
            var productBusinessModel = new ProductBusinessModel(productMock.Object, productDetailMock.Object);

            productMock.Setup(s => s.Delete(_product));

            productBusinessModel.Delete(_product);

            productMock.VerifyAll();


        }

        [TestMethod]
        public void SelectAll_ShouldReturnList_Test()
        {
            var productMock = new Moq.Mock<IProductDal>(Moq.MockBehavior.Strict);
            var productDetailMock = new Moq.Mock<IProductDetailDal>(Moq.MockBehavior.Strict);
            var productBusinessModel = new ProductBusinessModel(productMock.Object, productDetailMock.Object);

            productMock.Setup(s => s.SelectAll()).Returns(_products); ;

            var returnList = productBusinessModel.SelectAll();

            Assert.AreEqual(_products.Count, returnList.Count);

            productMock.VerifyAll();
        }

        [TestMethod]
        public void SelectByPrimaryId_Test()
        {
            var productMock = new Moq.Mock<IProductDal>(Moq.MockBehavior.Strict);
            var productDetailMock = new Moq.Mock<IProductDetailDal>(Moq.MockBehavior.Strict);
            var productBusinessModel = new ProductBusinessModel(productMock.Object, productDetailMock.Object);

            productMock.Setup(s => s.SelectPrimaryEntity<string>(It.IsAny<string>())).Returns(_product);

            Assert.IsTrue(!string.IsNullOrEmpty(productBusinessModel.SelectByPrimaryId(_product.StockNumber).StockNumber));
        }

        [TestMethod]
        public void SelectByStockNumberTest()
        {
            var productMock = new Mock<IProductDal>(MockBehavior.Strict);
            var productDetailMock = new Moq.Mock<IProductDetailDal>(Moq.MockBehavior.Strict);
            var productBusinessModel = new ProductBusinessModel(productMock.Object, productDetailMock.Object);

            productMock.Setup(s => s.SelectByStockNumber(It.IsAny<string>())).Returns(_products);

            productBusinessModel.SelectByStockNumber("XD");

            productMock.VerifyAll();
        }
        
        
    }
}
