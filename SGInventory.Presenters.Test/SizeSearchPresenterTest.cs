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
using System.Windows.Forms;

namespace SGInventory.Presenters.Test
{
    [TestClass]
    public class SizeSearchPresenterTest
    {
        private SizeSearchPresenter _sizeSearchPresenter;
        private Mock<ISizeSearchView> _sizeSearchView;
        private Mock<ISizeBusinessModel> _sizeBusinessModel;
        public SizeSearchPresenterTest()
        {
            _sizeSearchView = new Mock<ISizeSearchView>(MockBehavior.Strict);
            _sizeBusinessModel = new Mock<ISizeBusinessModel>(MockBehavior.Strict);

            _sizeSearchPresenter = new SizeSearchPresenter(_sizeSearchView.Object, _sizeBusinessModel.Object);
        }

        [TestMethod]
        public void LoadCategories_GivenAllCategories_Test()
        {
            var categories = new List<Size>
                                            {
                                                new Size{Name="S",Code="S2",CreatedBy="sgiuser",CreatedDate=DateTime.Now}
                                            };
            _sizeBusinessModel.Setup(b => b.SelectAll()).Returns(categories);
            _sizeSearchView.Setup(s => s.LoadModel(It.IsAny<List<Size>>()));

            _sizeSearchPresenter.LoadModels();

            _sizeBusinessModel.VerifyAll();
            _sizeSearchView.VerifyAll();
        }

        [TestMethod]
        public void AddModel_Test()
        {
            _sizeSearchView.Setup(v => v.OpenEditForm());

            _sizeSearchPresenter.OpenEditForm();

            _sizeSearchView.VerifyAll();
        }

        [TestMethod]
        public void PopulateModelToEditForm_Test()
        {
            var size = new Size
                {
                   Code="S2",
                    Name = "S",                   
                    CreatedDate = DateTime.Now,
                    CreatedBy = "user",
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = "user"
                };

            _sizeSearchView.Setup(v => v.ConvertToModel(It.IsAny<object>())).Returns(size);
            _sizeSearchView.Setup(v => v.OpenEditForm(It.IsAny<Size>()));

            _sizeSearchPresenter.PopulateModelToEditForm("colCode", null);

            _sizeSearchView.VerifyAll();

        }

        [TestMethod]
        public void DeleteSelectedCategories_GivenTheUserSayYes_Test()
        {
            var sizes = new List<Size>
                {
                    new Size
                    {
                       Code="S2",
                        Name="S",                        
                        CreatedDate=DateTime.Now,
                        CreatedBy="user",
                        ModifiedDate=DateTime.Now,
                        ModifiedBy="user"
                    },
                       new Size
                    {
                        Code="S3",
                        Name="M",                        
                        CreatedDate=DateTime.Now,
                        CreatedBy="user",
                        ModifiedDate=DateTime.Now,
                        ModifiedBy="user"
                    }
                };


            _sizeSearchView.Setup(v => v.GetSelectedModels()).Returns(sizes);
            _sizeSearchView.Setup(v => v.ConfirmationPopUpYesNo(It.IsAny<string>())).Returns(DialogResult.Yes);
            _sizeBusinessModel.Setup(b => b.Delete(It.IsAny<Size>()));
            _sizeSearchView.Setup(v => v.DeletedPopUpMessage(It.IsAny<string>()));
            _sizeBusinessModel.Setup(b => b.SelectAll()).Returns(new List<Size>());
            _sizeSearchView.Setup(v => v.LoadModel(It.IsAny<List<Size>>()));

            _sizeSearchPresenter.DeleteSelectedModels();

            _sizeSearchView.VerifyAll();
            _sizeBusinessModel.Verify(b => b.Delete(It.IsAny<Size>()), Times.Exactly(sizes.Count));


        }

        [TestMethod]
        public void DeleteSelectedCategories_GivenNoCategoriesIsSelected_Test()
        {
            var categories = new List<Size>();

            _sizeSearchView.Setup(v => v.GetSelectedModels()).Returns(categories);

            _sizeSearchPresenter.DeleteSelectedModels();

            _sizeSearchView.VerifyAll();



        }

        [TestMethod]
        public void DeleteSelectedCategories_GivenTheUserSayNo_Test()
        {
            var sizes = new List<Size>
                {
                    new Size
                    {
                        Code="S2",
                        Name="S",                        
                        CreatedDate=DateTime.Now,
                        CreatedBy="user",
                        ModifiedDate=DateTime.Now,
                        ModifiedBy="user"
                    },
                       new Size
                    {
                          Code="S3",
                        Name="M",                        
                        CreatedDate=DateTime.Now,
                        CreatedBy="user",
                        ModifiedDate=DateTime.Now,
                        ModifiedBy="user"
                    }
                };


            _sizeSearchView.Setup(v => v.GetSelectedModels()).Returns(sizes);
            _sizeSearchView.Setup(v => v.ConfirmationPopUpYesNo(It.IsAny<string>())).Returns(DialogResult.No);


            _sizeSearchPresenter.DeleteSelectedModels();

            _sizeSearchView.VerifyAll();
            _sizeBusinessModel.VerifyAll();


        }
     
    }
}
