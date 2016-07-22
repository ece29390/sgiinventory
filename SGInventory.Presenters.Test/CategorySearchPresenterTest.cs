using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SGInventory.Business.Model;
using SGInventory.Model;
using SGInventory.Presenters;
using SGInventory.Views;
using Moq.Language;
using System.Windows.Forms;

namespace SGInventory.Presenters.Test
{
    [TestClass]
    public class CategorySearchPresenterTest
    {
        private CategorySearchPresenter _categorySearchPresenter;
        private Mock<ICategorySearchView> _categorySearchView;
        private Mock<ICategoryBusinessModel> _categoryBusinessModel;
        public CategorySearchPresenterTest()
        {
            _categorySearchView=new Mock<ICategorySearchView>(MockBehavior.Strict);
            _categoryBusinessModel=new Mock<ICategoryBusinessModel>(MockBehavior.Strict);

            _categorySearchPresenter = new CategorySearchPresenter(_categorySearchView.Object, _categoryBusinessModel.Object);
        }

        [TestMethod]
        public void LoadCategories_GivenAllCategories_Test()
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Id=1,
                    Name="Tops",
                    Description="Upper Garment",
                    CreatedDate=DateTime.Now,
                    CreatedBy="user",
                    ModifiedDate=DateTime.Now,
                    ModifiedBy="user"
                },
                   new Category
                {
                    Id=2,
                    Name="Bottoms",
                    Description="Lower Garment",
                    CreatedDate=DateTime.Now,
                    CreatedBy="user",
                    ModifiedDate=DateTime.Now,
                    ModifiedBy="user"
                }
            };
            _categoryBusinessModel.Setup(b => b.SelectAll()).Returns(categories);
            _categorySearchView.Setup(s=>s.LoadModel(It.IsAny<List<Category>>()));

            _categorySearchPresenter.LoadModels();

            _categoryBusinessModel.VerifyAll();
            _categorySearchView.VerifyAll();
        }

        [TestMethod]
        public void AddModel_Test()
        {
            _categorySearchView.Setup(v => v.OpenEditForm());
   
            _categorySearchPresenter.OpenEditForm();

            _categorySearchView.VerifyAll();
        }

        [TestMethod]
        public void PopulateModelToEditForm_Test()
        {
            var category=  new Category
                {
                    Id=2,
                    Name="Bottoms",
                    Description="Lower Garment",
                    CreatedDate=DateTime.Now,
                    CreatedBy="user",
                    ModifiedDate=DateTime.Now,
                    ModifiedBy="user"
                };

            _categorySearchView.Setup(v => v.ConvertToModel(It.IsAny<object>())).Returns(category);
            _categorySearchView.Setup(v => v.OpenEditForm(It.IsAny<Category>()));
       
            _categorySearchPresenter.PopulateModelToEditForm("colName",null);

            _categorySearchView.VerifyAll();

        }

        [TestMethod]
        public void DeleteSelectedCategories_GivenTheUserSayYes_Test()
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Id=1,
                    Name="Tops",
                    Description="Upper Garment",
                    CreatedDate=DateTime.Now,
                    CreatedBy="user",
                    ModifiedDate=DateTime.Now,
                    ModifiedBy="user"
                },
                   new Category
                {
                    Id=2,
                    Name="Bottoms",
                    Description="Lower Garment",
                    CreatedDate=DateTime.Now,
                    CreatedBy="user",
                    ModifiedDate=DateTime.Now,
                    ModifiedBy="user"
                },
                  new Category
                {
                    Id=3,
                    Name="Undies",
                    Description="Lower Garment",
                    CreatedDate=DateTime.Now,
                    CreatedBy="user",
                    ModifiedDate=DateTime.Now,
                    ModifiedBy="user"
                }
            };


            _categorySearchView.Setup(v => v.GetSelectedModels()).Returns(categories);
            _categorySearchView.Setup(v => v.ConfirmationPopUpYesNo(It.IsAny<string>())).Returns(DialogResult.Yes);
            _categoryBusinessModel.Setup(b => b.Delete(It.IsAny<Category>()));
            _categorySearchView.Setup(v => v.DeletedPopUpMessage(It.IsAny<string>()));
            _categoryBusinessModel.Setup(b => b.SelectAll()).Returns(new List<Category>());
            _categorySearchView.Setup(v => v.LoadModel(It.IsAny<List<Category>>()));

            _categorySearchPresenter.DeleteSelectedModels();

            _categorySearchView.VerifyAll();
            _categoryBusinessModel.Verify(b => b.Delete(It.IsAny<Category>()),Times.Exactly(categories.Count));
            
            
        }

        [TestMethod]
        public void DeleteSelectedCategories_GivenNoCategoriesIsSelected_Test()
        {
            var categories = new List<Category>();
            
            _categorySearchView.Setup(v => v.GetSelectedModels()).Returns(categories);
           
            _categorySearchPresenter.DeleteSelectedModels();

            _categorySearchView.VerifyAll();
           


        }

        [TestMethod]
        public void DeleteSelectedCategories_GivenTheUserSayNo_Test()
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Id=1,
                    Name="Tops",
                    Description="Upper Garment",
                    CreatedDate=DateTime.Now,
                    CreatedBy="user",
                    ModifiedDate=DateTime.Now,
                    ModifiedBy="user"
                },
                   new Category
                {
                    Id=2,
                    Name="Bottoms",
                    Description="Lower Garment",
                    CreatedDate=DateTime.Now,
                    CreatedBy="user",
                    ModifiedDate=DateTime.Now,
                    ModifiedBy="user"
                },
                  new Category
                {
                    Id=3,
                    Name="Undies",
                    Description="Lower Garment",
                    CreatedDate=DateTime.Now,
                    CreatedBy="user",
                    ModifiedDate=DateTime.Now,
                    ModifiedBy="user"
                }
            };


            _categorySearchView.Setup(v => v.GetSelectedModels()).Returns(categories);
            _categorySearchView.Setup(v => v.ConfirmationPopUpYesNo(It.IsAny<string>())).Returns(DialogResult.No);
      

            _categorySearchPresenter.DeleteSelectedModels();

            _categorySearchView.VerifyAll();
            _categoryBusinessModel.VerifyAll();


        }
    }
}
