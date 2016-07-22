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
    public class ColorSearchPresenterTest
    {
        private ColorSearchPresenter _colorSearchPresenter;
        private Mock<IColorSearchView> _colorSearchView;
        private Mock<IColorBusinessModel> _colorBusinessModel;
        public ColorSearchPresenterTest()
        {
            _colorSearchView = new Mock<IColorSearchView>(MockBehavior.Strict);
            _colorBusinessModel = new Mock<IColorBusinessModel>(MockBehavior.Strict);

            _colorSearchPresenter = new ColorSearchPresenter(_colorSearchView.Object, _colorBusinessModel.Object);
        }

        [TestMethod]
        public void LoadCategories_GivenAllCategories_Test()
        {
            var categories = new List<Color>
                                            {
                                                new Color{Name="Navy Blue",Code="001",CreatedBy="sgiuser",CreatedDate=DateTime.Now}
                                            };
            _colorBusinessModel.Setup(b => b.SelectAll()).Returns(categories);
            _colorSearchView.Setup(s => s.LoadModel(It.IsAny<List<Color>>()));

            _colorSearchPresenter.LoadModels();

            _colorBusinessModel.VerifyAll();
            _colorSearchView.VerifyAll();
        }

        [TestMethod]
        public void AddModel_Test()
        {
            _colorSearchView.Setup(v => v.OpenEditForm());

            _colorSearchPresenter.OpenEditForm();

            _colorSearchView.VerifyAll();
        }

        [TestMethod]
        public void PopulateModelToEditForm_Test()
        {
            var color = new Color
                {
                   Code="001",
                    Name = "Navy Blue",                   
                    CreatedDate = DateTime.Now,
                    CreatedBy = "user",
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = "user"
                };

            _colorSearchView.Setup(v => v.ConvertToModel(It.IsAny<object>())).Returns(color);
            _colorSearchView.Setup(v => v.OpenEditForm(It.IsAny<Color>()));

            _colorSearchPresenter.PopulateModelToEditForm("colCode", null);

            _colorSearchView.VerifyAll();

        }

        [TestMethod]
        public void DeleteSelectedCategories_GivenTheUserSayYes_Test()
        {
            var colors = new List<Color>
                {
                    new Color
                    {
                       Code="001",
                        Name="Navy Blue",                        
                        CreatedDate=DateTime.Now,
                        CreatedBy="user",
                        ModifiedDate=DateTime.Now,
                        ModifiedBy="user"
                    },
                       new Color
                    {
                        Code="S3",
                        Name="M",                        
                        CreatedDate=DateTime.Now,
                        CreatedBy="user",
                        ModifiedDate=DateTime.Now,
                        ModifiedBy="user"
                    }
                };


            _colorSearchView.Setup(v => v.GetSelectedModels()).Returns(colors);
            _colorSearchView.Setup(v => v.ConfirmationPopUpYesNo(It.IsAny<string>())).Returns(DialogResult.Yes);
            _colorBusinessModel.Setup(b => b.Delete(It.IsAny<Color>()));
            _colorSearchView.Setup(v => v.DeletedPopUpMessage(It.IsAny<string>()));
            _colorBusinessModel.Setup(b => b.SelectAll()).Returns(new List<Color>());
            _colorSearchView.Setup(v => v.LoadModel(It.IsAny<List<Color>>()));

            _colorSearchPresenter.DeleteSelectedModels();

            _colorSearchView.VerifyAll();
            _colorBusinessModel.Verify(b => b.Delete(It.IsAny<Color>()), Times.Exactly(colors.Count));


        }

        [TestMethod]
        public void DeleteSelectedCategories_GivenNoCategoriesIsSelected_Test()
        {
            var categories = new List<Color>();

            _colorSearchView.Setup(v => v.GetSelectedModels()).Returns(categories);

            _colorSearchPresenter.DeleteSelectedModels();

            _colorSearchView.VerifyAll();



        }

        [TestMethod]
        public void DeleteSelectedCategories_GivenTheUserSayNo_Test()
        {
            var colors = new List<Color>
                {
                    new Color
                    {
                        Code="001",
                        Name="Navy Blue",                        
                        CreatedDate=DateTime.Now,
                        CreatedBy="user",
                        ModifiedDate=DateTime.Now,
                        ModifiedBy="user"
                    },
                       new Color
                    {
                          Code="S3",
                        Name="M",                        
                        CreatedDate=DateTime.Now,
                        CreatedBy="user",
                        ModifiedDate=DateTime.Now,
                        ModifiedBy="user"
                    }
                };


            _colorSearchView.Setup(v => v.GetSelectedModels()).Returns(colors);
            _colorSearchView.Setup(v => v.ConfirmationPopUpYesNo(It.IsAny<string>())).Returns(DialogResult.No);


            _colorSearchPresenter.DeleteSelectedModels();

            _colorSearchView.VerifyAll();
            _colorBusinessModel.VerifyAll();


        }
    }
}
