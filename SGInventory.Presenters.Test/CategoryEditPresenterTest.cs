using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SGInventory.Business.Model;
using SGInventory.Views;
using SGInventory.Model;
using SGInventory.Helpers;
namespace SGInventory.Presenters.Test
{
    [TestClass]
    public class CategoryEditPresenterTest
    {
        private readonly CategoryEditPresenter _categoryPresenter;
        private readonly Mock<ICategoryEditView> _categoryView ;
        private readonly Mock<ICategoryBusinessModel>  _businessModel;

        public CategoryEditPresenterTest()
        {
            _categoryView = new Mock<ICategoryEditView>(MockBehavior.Strict);
            _businessModel = new Mock<ICategoryBusinessModel>(MockBehavior.Strict);
            _categoryPresenter = new CategoryEditPresenter(_categoryView.Object,_businessModel.Object);
        }

        [TestMethod]
        public void SaveCategory_GivenThanNameNotExistsCreateNewCategory_ResultSuccessfullPopUpMessage_Test()
        {

            var categoryName ="Tops";
            var description="Upper garment";
            var user="user";
            var category = new Category
            {
                Name = categoryName,
                Description = description,
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var successfulResponse = "A new Category has been added";

            _categoryView.Setup(v => v.GetName()).Returns(categoryName);
            _categoryView.Setup(v => v.GetDescription()).Returns(description);
            _categoryView.Setup(v => v.GetUser()).Returns(user);                                            
            _businessModel.Setup(b => b.Save(It.IsAny<Category>())).Returns(successfulResponse);

            var listOfCategories = new List<Category>();
            category.Id = 1;
            listOfCategories.Add(category);

            _businessModel.Setup(b => b.SelectAll()).Returns(listOfCategories);

            var wasCalled = false;
            _categoryPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsTrue(wasCalled);
            _categoryView.VerifyAll();
            _businessModel.VerifyAll();            

        }

        [TestMethod]
        public void SaveCategory_GivenThanNameNotExistsCategoryAlreadyExists_ResultSuccessfullPopUpMessage_Test()
        {

            var categoryName = "Tops";
            var description = "Upper garment";
            var user = "user";
            var category = new Category
            {
                Id=1,
                Name = categoryName,
                Description = description,
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var successfulResponse = "Category has been updated";

            _categoryView.Setup(v => v.GetName()).Returns(categoryName);
            _categoryView.Setup(v => v.GetDescription()).Returns(description);
            _categoryView.Setup(v => v.GetUser()).Returns(user);
            _businessModel.Setup(b => b.Save(It.IsAny<Category>())).Returns(successfulResponse);

            var listOfCategories = new List<Category>();
            category.Id = 1;
            listOfCategories.Add(category);

            _businessModel.Setup(b => b.SelectAll()).Returns(listOfCategories);

            var wasCalled = false;
            _categoryPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsTrue(wasCalled);

            _categoryView.VerifyAll();
            _businessModel.VerifyAll();

        }

        [TestMethod]
        public void SaveCategory_GivenThanNameExistsCreateNewCategory_ResultUnSuccessfullPopUpMessage_Test()
        {
            var categoryName = "Tops";
            var description = "Upper garment";
            var user = "user";
            var category = new Category
            {
                Name = categoryName,
                Description = description,
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var unsuccessfulResponse = "Category already exists";

            _categoryView.Setup(v => v.GetName()).Returns(categoryName);
            _categoryView.Setup(v => v.GetDescription()).Returns(description);
            _categoryView.Setup(v => v.GetUser()).Returns(user);
            _businessModel.Setup(b => b.Save(It.IsAny<Category>())).Returns(unsuccessfulResponse);
          
            var wasCalled = false;
            _categoryPresenter.Save((response, list) => { wasCalled=true;});

            _categoryView.VerifyAll();
            _businessModel.VerifyAll();  

            Assert.IsTrue(wasCalled);

        }

     
              
        [TestMethod]
        public void LoadCategory_GivenTheCategoryIsNotNull()
        {
            var categoryName = "Tops";
            var description = "Upper garment";
            var user = "user";
            var category = new Category
            {
                Name = categoryName,
                Description = description,
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };

            _categoryView.Setup(v => v.LoadData(It.IsAny<Category>()));
   

            _categoryPresenter.LoadModels(category);

            _categoryView.VerifyAll();

        }

        [TestMethod]
        public void UniqueNameKeypress_GivenThatTextHasLength_ShouldReturnTrue_Test()
        {
            var uniqueName = "sample";

            _categoryView.Setup(s => s.GetName()).Returns(uniqueName);

            var presenter = new CategoryEditPresenter(_categoryView.Object, _businessModel.Object);
            Assert.IsTrue(_categoryPresenter.ShouldEnable());
            _categoryView.VerifyAll();
        }

        [TestMethod]
        public void UniqueNameKeypress_GivenThatTextHasNoLength_ShouldReturnTrue_Test()
        {
            var uniqueName = "";

            _categoryView.Setup(s => s.GetName()).Returns(uniqueName);

            var presenter = new CategoryEditPresenter(_categoryView.Object, _businessModel.Object);
            Assert.IsFalse(_categoryPresenter.ShouldEnable());
            _categoryView.VerifyAll();
        }

        [TestMethod]
        public void Save_GivenDescriptionExceedTheMaximumLength_Test()
        {
            var categoryName = "Tops";
            var description = "Upper garment sdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfsTopssdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfs";
            var user = "user";
            var category = new Category
            {
                Name = categoryName,
                Description = description,
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var validationError = FormsHelper.DescriptionValidationError;

            _categoryView.Setup(v => v.GetName()).Returns(categoryName);
            _categoryView.Setup(v => v.GetDescription()).Returns(description);
            _categoryView.Setup(v => v.GetUser()).Returns(user);
            _categoryView.Setup(v => v.ShowMessage(It.IsAny<string>()));
                    
            var wasCalled = false;
            _categoryPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsFalse(wasCalled);
            _categoryView.VerifyAll();
            _businessModel.VerifyAll();   
        }

        [TestMethod]
        public void Save_GivenNameExceedTheMaximumLength_Test()
        {
            var description = "Tops";
            var  categoryName= "Upper garment sdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfsTopssdfsfsdfsdfdsfsdfsdfsdfsfsdfsdfdsfsdfsfsdfsfsfsdfsdfsdfsdfsfsdfsdfsfsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdsfs";
            var user = "user";
            var category = new Category
            {
                Name = categoryName,
                Description = description,
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var validationError = FormsHelper.DescriptionValidationError;

            _categoryView.Setup(v => v.GetName()).Returns(categoryName);
            _categoryView.Setup(v => v.GetDescription()).Returns(description);
            _categoryView.Setup(v => v.GetUser()).Returns(user);
            _categoryView.Setup(v => v.ShowMessage(It.IsAny<string>()));

            var wasCalled = false;
            _categoryPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsFalse(wasCalled);
            _categoryView.VerifyAll();
            _businessModel.VerifyAll();
        }

       

       
    }
}
