using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGInventory.Presenters;
using SGInventory.Views;
using SGInventory.Business.Model;
using Moq;
using SGInventory.Model;
using SGInventory.Helpers;

namespace SGInventory.Presenters.Test
{
    [TestClass]
    public class WashingEditPresenterTest
    {
         private readonly WashingEditPresenter _washingPresenter;
        private readonly Mock<IWashingEditView> _washingView;
        private readonly Mock<IWashingBusinessModel> _businessModel;

        public WashingEditPresenterTest()
        {
            _washingView = new Mock<IWashingEditView>(MockBehavior.Strict);
            _businessModel = new Mock<IWashingBusinessModel>(MockBehavior.Strict);
            _washingPresenter = new WashingEditPresenter(_washingView.Object, _businessModel.Object);
        }

        [TestMethod]
        public void SaveWashing_GivenThatCodeAndNameNotExistsCreateNewWashing_ResultSuccessfullPopUpMessage_Test()
        {

            var washingName = "STONE WASHING";        
            var user = "user";
            var washing = new Washing { Code="7", Name = washingName,  CreatedBy = "sgiuser", CreatedDate = DateTime.Now };
          
            var successfulResponse = "A new Washing has been added";

            _washingView.Setup(v => v.GetCode()).Returns(washing.Code);
            _washingView.Setup(v => v.GetName()).Returns(washingName);          
            _washingView.Setup(v => v.GetUser()).Returns(user);
            Washing mockWashing = null;
            _businessModel.Setup(b => b.SelectByPrimaryId(It.IsAny<string>())).Returns(mockWashing);
            _businessModel.Setup(b => b.Save(It.IsAny<Washing>())).Returns(successfulResponse);

            var listOfCategories = new List<Washing>();
          
            listOfCategories.Add(washing);

            _businessModel.Setup(b => b.SelectAll()).Returns(listOfCategories);

            var wasCalled = false;
            _washingPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsTrue(wasCalled);
            _washingView.VerifyAll();
            _businessModel.VerifyAll();

        }

        [TestMethod]
        public void SaveWashing_GivenThatNameNotExistsWashingAlreadyExists_ResultSuccessfullPopUpMessage_Test()
        {

            var washingName = "STONE WASHING";
           
            var user = "user";
            var washing = new Washing
            {
                Code = "7",
                Name = washingName,               
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var successfulResponse = "Washing has been updated";

            _washingView.Setup(v => v.GetName()).Returns(washingName);
            _washingView.Setup(v => v.GetCode()).Returns(washing.Code);
            _washingView.Setup(v => v.GetUser()).Returns(user);
            _businessModel.Setup(b => b.Save(It.IsAny<Washing>())).Returns(successfulResponse);

            var listOfWashing = new List<Washing>();          
            listOfWashing.Add(washing);

            _businessModel.Setup(b => b.SelectAll()).Returns(listOfWashing);

            var wasCalled = false;
            var washingPresenter = new WashingEditPresenter(_washingView.Object, _businessModel.Object, washing);
            washingPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsTrue(wasCalled);

            _washingView.VerifyAll();
            _businessModel.VerifyAll();

        }

        [TestMethod]
        public void Save_GivenNameExceedsTheMaximumLengthAndWashingIsNew_Test()
        {

            var washingName = "Upper garment sdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfsTopssdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfsUpper garment sdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfsTopssdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfsUpper garment sdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfsTopssdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfsUpper garment sdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfsTopssdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfs";
            var user = "user";
            var washing = new Washing
            {
                Name = washingName,
                Code= "7",
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
       

            _washingView.Setup(v => v.GetName()).Returns(washingName);
            _washingView.Setup(v => v.GetCode()).Returns(washing.Code);  
            _washingView.Setup(v => v.ShowMessage(It.IsAny<string>()));

            var wasCalled = false;
            _washingPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsFalse(wasCalled);
            _washingView.VerifyAll();
            _businessModel.VerifyAll();
        }

        [TestMethod]
        public void Save_GivenCodeExceedTheMaximumLength_Test()
        {
            var name = "STONE WASHING";
            var code = "Upper garment sdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfsTopssdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfs";
            var user = "user";
            var washing = new Washing
            {
                Name = name,
                Code=code,
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var validationError = FormsHelper.CodeValidationError;

            _washingView.Setup(v => v.GetName()).Returns(name);
            _washingView.Setup(v => v.GetCode()).Returns(code);             
            _washingView.Setup(v => v.ShowMessage(It.IsAny<string>()));

            var wasCalled = false;
            _washingPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsFalse(wasCalled);
            _washingView.VerifyAll();
            _businessModel.VerifyAll();
        }

        [TestMethod]
        public void Save_GivenThatOnCreateModeAndWashingAlreadyExist_ResultUnsuccessfullPopupMessage_Test()
        {
            var washingName = "STONE WASHING";
            var user = "user";
            var washing = new Washing { Code = "7", Name = washingName, CreatedBy = "sgiuser", CreatedDate = DateTime.Now };
           
            _washingView.Setup(v => v.GetCode()).Returns(washing.Code);
            _washingView.Setup(v => v.GetName()).Returns(washingName);
            _washingView.Setup(v => v.GetUser()).Returns(user);
            _businessModel.Setup(b => b.SelectByPrimaryId(It.IsAny<string>())).Returns(washing);
            _washingView.Setup(v => v.ShowMessage(It.IsAny<string>()));
            var listOfWashings = new List<Washing>();

            listOfWashings.Add(washing);            
            var wasCalled = false;
            _washingPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsFalse(wasCalled);
            _washingView.VerifyAll();
            _businessModel.VerifyAll();
        }


        [TestMethod]
        public void Keypress_GivenThatNameAndCodeHasLength_ShouldReturnTrue_Test()
        {
            var uniqueName = "STONE WASHING";
            var code = "7";

            _washingView.Setup(s => s.GetName()).Returns(uniqueName);
            _washingView.Setup(s => s.GetCode()).Returns(code);

            var presenter = new WashingEditPresenter(_washingView.Object, _businessModel.Object);
            Assert.IsTrue(_washingPresenter.ShouldEnable());
            _washingView.VerifyAll();
        }

        [TestMethod]
        public void Keypress_GivenThatNameHasLengthCodeHasNoLength_ShouldReturnTrue_Test()
        {
            var uniqueName = "STONE WASHING";
            var code = "";

            _washingView.Setup(s => s.GetName()).Returns(uniqueName);
            _washingView.Setup(s => s.GetCode()).Returns(code);

          
            Assert.IsFalse(_washingPresenter.ShouldEnable());
            _washingView.VerifyAll();
        }

        [TestMethod]
        public void Keypress_GivenThatNameHasNoLengthCodeHasLength_ShouldReturnTrue_Test()
        {
            var uniqueName = "";
            var code = "7";

            _washingView.Setup(s => s.GetName()).Returns(uniqueName);
         

          
            Assert.IsFalse(_washingPresenter.ShouldEnable());
            _washingView.VerifyAll();
        }

        [TestMethod]
        public void LoadWashing_GivenTheWashingIsNotNull()
        {
            var washingName = "STONE WASHING";            
            var user = "user";
            var washing = new Washing
            {
                Name = washingName,               
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };

            _washingView.Setup(v => v.LoadData(It.IsAny<Washing>()));


            _washingPresenter.LoadModels(washing);

            _washingView.VerifyAll();

        }
    }
}
