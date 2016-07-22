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
    public class ColorEditPresenterTest
    {
       private readonly ColorEditPresenter _colorPresenter;
        private readonly Mock<IColorEditView> _colorView;
        private readonly Mock<IColorBusinessModel> _businessModel;

        public ColorEditPresenterTest()
        {
            _colorView = new Mock<IColorEditView>(MockBehavior.Strict);
            _businessModel = new Mock<IColorBusinessModel>(MockBehavior.Strict);
            _colorPresenter = new ColorEditPresenter(_colorView.Object, _businessModel.Object);
        }

        [TestMethod]
        public void SaveColor_GivenThatCodeAndNameNotExistsCreateNewColor_ResultSuccessfullPopUpMessage_Test()
        {

            var colorName = "Navy Blue";        
            var user = "user";
            var color = new Color { Code="002", Name = colorName,  CreatedBy = "sgiuser", CreatedDate = DateTime.Now };
          
            var successfulResponse = "A new Color has been added";

            _colorView.Setup(v => v.GetCode()).Returns(color.Code);
            _colorView.Setup(v => v.GetName()).Returns(colorName);          
            _colorView.Setup(v => v.GetUser()).Returns(user);
            Color mockColor = null;
            _businessModel.Setup(b => b.SelectByPrimaryId(It.IsAny<string>())).Returns(mockColor);
            _businessModel.Setup(b => b.Save(It.IsAny<Color>())).Returns(successfulResponse);

            var listOfCategories = new List<Color>();
          
            listOfCategories.Add(color);

            _businessModel.Setup(b => b.SelectAll()).Returns(listOfCategories);

            var wasCalled = false;
            _colorPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsTrue(wasCalled);
            _colorView.VerifyAll();
            _businessModel.VerifyAll();

        }

        [TestMethod]
        public void SaveColor_GivenThatNameNotExistsColorAlreadyExists_ResultSuccessfullPopUpMessage_Test()
        {

            var colorName = "Khaki";
           
            var user = "user";
            var color = new Color
            {
                Code = "002",
                Name = colorName,               
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var successfulResponse = "Color has been updated";

            _colorView.Setup(v => v.GetName()).Returns(colorName);
            
            _colorView.Setup(v => v.GetUser()).Returns(user);
            
            _businessModel.Setup(b => b.Save(It.IsAny<Color>())).Returns(successfulResponse);

            var listOfColor = new List<Color>();          
            listOfColor.Add(color);

            _businessModel.Setup(b => b.SelectAll()).Returns(listOfColor);
            
            var wasCalled = false;
            var colorPresenter = new ColorEditPresenter(_colorView.Object, _businessModel.Object, color);
            colorPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsTrue(wasCalled);

            _colorView.VerifyAll();
            _businessModel.VerifyAll();

        }

        [TestMethod]
        public void Save_GivenNameExceedsTheMaximumLengthAndColorIsNew_Test()
        {
            
            var colorName = "Upper garment sdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfsTopssdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfs";
            var user = "user";
            var color = new Color
            {
                Name = colorName,
                Code= "002",
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var validationError = FormsHelper.WashingNameValidationError;

            _colorView.Setup(v => v.GetName()).Returns(colorName);         
            _colorView.Setup(v => v.ShowMessage(It.IsAny<string>()));

            var wasCalled = false;
            _colorPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsFalse(wasCalled);
            _colorView.VerifyAll();
            _businessModel.VerifyAll();
        }

        [TestMethod]
        public void Save_GivenCodeExceedTheMaximumLength_Test()
        {
            var name = "Navy Blue";
            var code = "Upper garment sdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfsTopssdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfs";
            var user = "user";
            var color = new Color
            {
                Name = name,
                Code=code,
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var validationError = FormsHelper.DescriptionValidationError;

            _colorView.Setup(v => v.GetName()).Returns(name);
            _colorView.Setup(v => v.GetCode()).Returns(code);        
            _colorView.Setup(v => v.ShowMessage(It.IsAny<string>()));

            var wasCalled = false;
            _colorPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsFalse(wasCalled);
            _colorView.VerifyAll();
            _businessModel.VerifyAll();
        }

        [TestMethod]
        public void Save_GivenThatOnCreateModeAndColorAlreadyExist_ResultUnsuccessfullPopupMessage_Test()
        {
            var colorName = "Navy Blue";
            var user = "user";
            var color = new Color { Code = "002", Name = colorName, CreatedBy = "sgiuser", CreatedDate = DateTime.Now };
           
            _colorView.Setup(v => v.GetCode()).Returns(color.Code);
            _colorView.Setup(v => v.GetName()).Returns(colorName);
            _colorView.Setup(v => v.GetUser()).Returns(user);
            _businessModel.Setup(b => b.SelectByPrimaryId(It.IsAny<string>())).Returns(color);
            _colorView.Setup(v => v.ShowMessage(It.IsAny<string>()));
            var listOfColors = new List<Color>();

            listOfColors.Add(color);            
            var wasCalled = false;
            _colorPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsFalse(wasCalled);
            _colorView.VerifyAll();
            _businessModel.VerifyAll();
        }


        [TestMethod]
        public void Keypress_GivenThatNameAndCodeHasLength_ShouldReturnTrue_Test()
        {
            var uniqueName = "Navy Blue";
            var code = "002";

            _colorView.Setup(s => s.GetName()).Returns(uniqueName);
            _colorView.Setup(s => s.GetCode()).Returns(code);

            var presenter = new ColorEditPresenter(_colorView.Object, _businessModel.Object);
            Assert.IsTrue(_colorPresenter.ShouldEnable());
            _colorView.VerifyAll();
        }

        [TestMethod]
        public void Keypress_GivenThatNameHasLengthCodeHasNoLength_ShouldReturnTrue_Test()
        {
            var uniqueName = "Navy Blue";
            var code = "";

            _colorView.Setup(s => s.GetName()).Returns(uniqueName);
            _colorView.Setup(s => s.GetCode()).Returns(code);

          
            Assert.IsFalse(_colorPresenter.ShouldEnable());
            _colorView.VerifyAll();
        }

        [TestMethod]
        public void Keypress_GivenThatNameHasNoLengthCodeHasLength_ShouldReturnTrue_Test()
        {
            var uniqueName = "";
            var code = "002";

            _colorView.Setup(s => s.GetName()).Returns(uniqueName);
         

          
            Assert.IsFalse(_colorPresenter.ShouldEnable());
            _colorView.VerifyAll();
        }

        [TestMethod]
        public void LoadColor_GivenTheColorIsNotNull()
        {
            var colorName = "Tops";            
            var user = "user";
            var color = new Color
            {
                Name = colorName,               
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };

            _colorView.Setup(v => v.LoadData(It.IsAny<Color>()));


            _colorPresenter.LoadModels(color);

            _colorView.VerifyAll();

        }
    }
}
