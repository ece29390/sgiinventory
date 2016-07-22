using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGInventory.Business.Model;
using SGInventory.Presenters;
using SGInventory.Views;
using Moq;
using SGInventory.Model;
using SGInventory.Test.Data;
using SGInventory.Helpers;
namespace SGInventory.Presenters.Test
{
    [TestClass]
    public class ProductEditPresenterTest
    {
        private readonly ProductEditPresenter _productPresenter;
        private readonly Mock<IProductEditView> _productView;
        private readonly Mock<IProductBusinessModel> _businessModel;
        private readonly Mock<ICategoryBusinessModel> _catBusinessModel;
        private readonly List<Product> _models;
        private readonly Product _model;
        public ProductEditPresenterTest()
        {
            _productView = new Mock<IProductEditView>(MockBehavior.Strict);
            _businessModel = new Mock<IProductBusinessModel>(MockBehavior.Strict);
            _catBusinessModel = new Mock<ICategoryBusinessModel>(MockBehavior.Strict);

            _productPresenter = new ProductEditPresenter(_productView.Object,_businessModel.Object);
            
            var testData = new ProductTestData();
            _models = testData.GetEntities();
            _model = testData.GetEntity();
        }

        [TestMethod]
        public void SaveProduct_GivenCreateNewProduct_ResultSuccessfullPopUpMessage_Test()
        {              
            var user = "user";                      
            var successfulResponse = "A new Product has been added";

            _productView.Setup(v => v.GetCode()).Returns(_model.StockNumber);
            _productView.Setup(v => v.GetDescription()).Returns(_model.Description);          
            _productView.Setup(v => v.GetUser()).Returns(user);
            _productView.Setup(v => v.GetGategory()).Returns(_model.Category);
            _productView.Setup(v => v.GetCost()).Returns(_model.Cost);
            _productView.Setup(v => v.GetMarkdownPrice()).Returns(_model.MarkdownPrice);
            _productView.Setup(v => v.GetRegularPrice()).Returns(_model.RegularPrice);
            var mockProduct = new Product();
            _businessModel.Setup(b => b.SelectByPrimaryId(It.IsAny<string>())).Returns(mockProduct);
            _businessModel.Setup(b => b.Save(It.IsAny<Product>())).Returns(successfulResponse);
            
            _businessModel.Setup(b => b.SelectAll()).Returns(_models);

            var wasCalled = false;
            _productPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsTrue(wasCalled);
            _productView.VerifyAll();
            _businessModel.VerifyAll();

        }

        [TestMethod]
        public void SaveProduct_GivenThatProductAlreadyExists_ResultSuccessfullPopUpMessage_Test()
        {

            var user = "user";

            var successfulResponse = "Product has been updated";
            _model.Description = "Description was updated";

            _productView.Setup(v => v.GetDescription()).Returns(_model.Description);           
            _productView.Setup(v => v.GetUser()).Returns(user);
            _productView.Setup(v => v.GetGategory()).Returns(_model.Category);
            _productView.Setup(v => v.GetCost()).Returns(_model.Cost);
            _productView.Setup(v => v.GetMarkdownPrice()).Returns(_model.MarkdownPrice);
            _productView.Setup(v => v.GetRegularPrice()).Returns(_model.RegularPrice);
            _businessModel.Setup(b => b.Save(It.IsAny<Product>())).Returns(successfulResponse);
            _businessModel.Setup(b => b.SelectAll()).Returns(_models);

            var wasCalled = false;
            var productPresenter = new ProductEditPresenter(_productView.Object, _businessModel.Object, _model);
            productPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsTrue(wasCalled);

            _productView.VerifyAll();
            _businessModel.VerifyAll();

        }

        [TestMethod]
        public void Save_GivenThatOnCreateModeAndProductAlreadyExist_ResultUnsuccessfullPopupMessage_Test()
        {            
            var user = "user";           
            _productView.Setup(v => v.GetCode()).Returns(_model.StockNumber);
            _productView.Setup(v => v.GetGategory()).Returns(_model.Category);
            _productView.Setup(v => v.GetDescription()).Returns(_model.Description);           
            _productView.Setup(v => v.GetUser()).Returns(user);
            _businessModel.Setup(b => b.SelectByPrimaryId(It.IsAny<string>())).Returns(_model);
            _productView.Setup(v => v.ShowMessage(It.IsAny<string>()));
          
            var wasCalled = false;
            _productPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsFalse(wasCalled);
            _productView.VerifyAll();
            _businessModel.VerifyAll();
        }

        [TestMethod]
        public void Save_GivenDescriptionExceedsTheMaximumLength_Test()
        {
            var description = "Upper garment sdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfsTopssdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfsUpper garment sdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfsTopssdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfsUpper garment sdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfsTopssdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfsUpper garment sdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfsTopssdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfs";           
            _model.Description = description;

            _productView.Setup(v => v.GetDescription()).Returns(description);        
            _productView.Setup(v => v.ShowMessage(It.IsAny<string>()));

            var wasCalled = false;
            _productPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsFalse(wasCalled);
            _productView.VerifyAll();
            _businessModel.VerifyAll();
        }

        [TestMethod]
        public void Save_GivenStockNumberExceedTheMaximumLength_Test()
        {
            var code = "Upper garment sdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfsTopssdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfs";
            var user = "user";
            _model.StockNumber = code;
            var validationError = FormsHelper.CodeValidationError;

            _productView.Setup(v => v.GetDescription()).Returns(_model.Description);
            _productView.Setup(v => v.GetCode()).Returns(code);
            _productView.Setup(v => v.GetGategory()).Returns(_model.Category);
            _productView.Setup(v => v.GetUser()).Returns(user);
            _productView.Setup(v => v.ShowMessage(It.IsAny<string>()));

            var wasCalled = false;
            _productPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsFalse(wasCalled);
            _productView.VerifyAll();
            _businessModel.VerifyAll();
        }


        [TestMethod]
        public void Keypress_GivenThatNameAndCodeHasLength_ShouldReturnTrue_Test()
        {                               
            _productView.Setup(s => s.GetCode()).Returns(_model.StockNumber);

            var presenter = new ProductEditPresenter(_productView.Object, _businessModel.Object);
            Assert.IsTrue(_productPresenter.ShouldEnable());
            _productView.VerifyAll();
        }

        [TestMethod]
        public void Keypress_GivenThatNameHasLengthCodeHasNoLength_ShouldReturnFalse_Test()
        {         
            _productView.Setup(s => s.GetCode()).Returns("");
            Assert.IsFalse(_productPresenter.ShouldEnable());
            _productView.VerifyAll();
        }

        [TestMethod]
        public void LoadProduct_GivenTheProductIsNotNull()
        {          
            _productView.Setup(v => v.LoadData(It.IsAny<Product>()));
            _productPresenter.LoadModels(_model);
            _productView.VerifyAll();

        }

        [TestMethod]
        public void LoadAllReferenceModel()
        {
            _productView.Setup(v => v.LoadAllCategories());
            _productPresenter.LoadAllReferenceModels();
            _productView.VerifyAll();

        }
    }
}
