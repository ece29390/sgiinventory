using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGInventory.Presenters;
using Moq;
using SGInventory.Views;
using SGInventory.Business.Model;
using SGInventory.Model;
using SGInventory.Helpers;

namespace SGInventory.Presenters.Test
{
    [TestClass]
    public class SizeEditPresenterTest
    {
        private readonly SizeEditPresenter _sizePresenter;
        private readonly Mock<ISizeEditView> _sizeView;
        private readonly Mock<ISizeBusinessModel> _businessModel;

        public SizeEditPresenterTest()
        {
            _sizeView = new Mock<ISizeEditView>(MockBehavior.Strict);
            _businessModel = new Mock<ISizeBusinessModel>(MockBehavior.Strict);
            _sizePresenter = new SizeEditPresenter(_sizeView.Object, _businessModel.Object);
        }

        [TestMethod]
        public void SaveSize_GivenThatCodeAndNameNotExistsCreateNewSize_ResultSuccessfullPopUpMessage_Test()
        {

            var sizeName = "S";        
            var user = "user";
            var size = new Size { Code="S2", Name = sizeName,  CreatedBy = "sgiuser", CreatedDate = DateTime.Now };
          
            var successfulResponse = "A new Size has been added";

            _sizeView.Setup(v => v.GetCode()).Returns(size.Code);
            _sizeView.Setup(v => v.GetName()).Returns(sizeName);          
            _sizeView.Setup(v => v.GetUser()).Returns(user);
            Size mockSize = null;
            _businessModel.Setup(b => b.SelectByPrimaryId(It.IsAny<string>())).Returns(mockSize);
            _businessModel.Setup(b => b.Save(It.IsAny<Size>())).Returns(successfulResponse);

            var listOfCategories = new List<Size>();
          
            listOfCategories.Add(size);

            _businessModel.Setup(b => b.SelectAll()).Returns(listOfCategories);

            var wasCalled = false;
            _sizePresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsTrue(wasCalled);
            _sizeView.VerifyAll();
            _businessModel.VerifyAll();

        }

        [TestMethod]
        public void SaveSize_GivenThatNameNotExistsSizeAlreadyExists_ResultSuccessfullPopUpMessage_Test()
        {

            var sizeName = "M";
           
            var user = "user";
            var size = new Size
            {
                Code = "S2",
                Name = sizeName,               
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var successfulResponse = "Size has been updated";

            _sizeView.Setup(v => v.GetName()).Returns(sizeName);
            
            _sizeView.Setup(v => v.GetUser()).Returns(user);
            _businessModel.Setup(b => b.Save(It.IsAny<Size>())).Returns(successfulResponse);

            var listOfSize = new List<Size>();          
            listOfSize.Add(size);

            _businessModel.Setup(b => b.SelectAll()).Returns(listOfSize);

            var wasCalled = false;
            var sizePresenter = new SizeEditPresenter(_sizeView.Object, _businessModel.Object, size);
            sizePresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsTrue(wasCalled);

            _sizeView.VerifyAll();
            _businessModel.VerifyAll();

        }

        [TestMethod]
        public void Save_GivenNameExceedsTheMaximumLengthAndSizeIsNew_Test()
        {
            
            var sizeName = "Upper garment sdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfsTopssdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfs";
            var user = "user";
            var size = new Size
            {
                Name = sizeName,
                Code= "S2",
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var validationError = FormsHelper.NameValidationError;

            _sizeView.Setup(v => v.GetName()).Returns(sizeName);         
            _sizeView.Setup(v => v.ShowMessage(It.IsAny<string>()));

            var wasCalled = false;
            _sizePresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsFalse(wasCalled);
            _sizeView.VerifyAll();
            _businessModel.VerifyAll();
        }

        [TestMethod]
        public void Save_GivenCodeExceedTheMaximumLength_Test()
        {
            var name = "S";
            var code = "Upper garment sdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfsTopssdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfs";
            var user = "user";
            var size = new Size
            {
                Name = name,
                Code=code,
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var validationError = FormsHelper.DescriptionValidationError;

            _sizeView.Setup(v => v.GetName()).Returns(name);
            _sizeView.Setup(v => v.GetCode()).Returns(code);        
            _sizeView.Setup(v => v.ShowMessage(It.IsAny<string>()));

            var wasCalled = false;
            _sizePresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsFalse(wasCalled);
            _sizeView.VerifyAll();
            _businessModel.VerifyAll();
        }

        [TestMethod]
        public void Save_GivenThatOnCreateModeAndSizeAlreadyExist_ResultUnsuccessfullPopupMessage_Test()
        {
            var sizeName = "S";
            var user = "user";
            var size = new Size { Code = "S2", Name = sizeName, CreatedBy = "sgiuser", CreatedDate = DateTime.Now };
           
            _sizeView.Setup(v => v.GetCode()).Returns(size.Code);
            _sizeView.Setup(v => v.GetName()).Returns(sizeName);
            _sizeView.Setup(v => v.GetUser()).Returns(user);
            _businessModel.Setup(b => b.SelectByPrimaryId(It.IsAny<string>())).Returns(size);
            _sizeView.Setup(v => v.ShowMessage(It.IsAny<string>()));
            var listOfSizes = new List<Size>();

            listOfSizes.Add(size);            
            var wasCalled = false;
            _sizePresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsFalse(wasCalled);
            _sizeView.VerifyAll();
            _businessModel.VerifyAll();
        }


        [TestMethod]
        public void Keypress_GivenThatNameAndCodeHasLength_ShouldReturnTrue_Test()
        {
            var uniqueName = "S";
            var code = "S2";

            _sizeView.Setup(s => s.GetName()).Returns(uniqueName);
            _sizeView.Setup(s => s.GetCode()).Returns(code);

            var presenter = new SizeEditPresenter(_sizeView.Object, _businessModel.Object);
            Assert.IsTrue(_sizePresenter.ShouldEnable());
            _sizeView.VerifyAll();
        }

        [TestMethod]
        public void Keypress_GivenThatNameHasLengthCodeHasNoLength_ShouldReturnTrue_Test()
        {
            var uniqueName = "S";
            var code = "";

            _sizeView.Setup(s => s.GetName()).Returns(uniqueName);
            _sizeView.Setup(s => s.GetCode()).Returns(code);

          
            Assert.IsFalse(_sizePresenter.ShouldEnable());
            _sizeView.VerifyAll();
        }

        [TestMethod]
        public void Keypress_GivenThatNameHasNoLengthCodeHasLength_ShouldReturnTrue_Test()
        {
            var uniqueName = "";
            var code = "S2";

            _sizeView.Setup(s => s.GetName()).Returns(uniqueName);
         

          
            Assert.IsFalse(_sizePresenter.ShouldEnable());
            _sizeView.VerifyAll();
        }

        [TestMethod]
        public void LoadSize_GivenTheSizeIsNotNull()
        {
            var sizeName = "Tops";            
            var user = "user";
            var size = new Size
            {
                Name = sizeName,               
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };

            _sizeView.Setup(v => v.LoadData(It.IsAny<Size>()));


            _sizePresenter.LoadModels(size);

            _sizeView.VerifyAll();

        }

        

      

        
    }
}
