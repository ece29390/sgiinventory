using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGInventory.Presenters;
using SGInventory.Views;
using Moq;
using SGInventory.Business.Model;
using SGInventory.Model;
using System.Windows.Forms;

namespace SGInventory.Presenters.Test
{
    [TestClass]
    public class WashingSearchPresenterTest
    {
        private WashingSearchPresenter _washingSearchPresenter;
        private Mock<IWashingSearchView> _washingSearchView;
        private Mock<IWashingBusinessModel> _washingBusinessModel;
        public WashingSearchPresenterTest()
        {
            _washingSearchView = new Mock<IWashingSearchView>(MockBehavior.Strict);
            _washingBusinessModel = new Mock<IWashingBusinessModel>(MockBehavior.Strict);

            _washingSearchPresenter = new WashingSearchPresenter(_washingSearchView.Object, _washingBusinessModel.Object);
        }

        [TestMethod]
        public void LoadAllModels_Test()
        {
            var washings = new List<Washing>
                                            {
                                                new Washing{Name="STONE WASHING",Code="7",CreatedBy="sgiuser",CreatedDate=DateTime.Now}
                                            };
            _washingBusinessModel.Setup(b => b.SelectAll()).Returns(washings);
            _washingSearchView.Setup(s => s.LoadModel(It.IsAny<List<Washing>>()));

            _washingSearchPresenter.LoadModels();

            _washingBusinessModel.VerifyAll();
            _washingSearchView.VerifyAll();
        }

        [TestMethod]
        public void AddModel_Test()
        {
            _washingSearchView.Setup(v => v.OpenEditForm());

            _washingSearchPresenter.OpenEditForm();

            _washingSearchView.VerifyAll();
        }

        [TestMethod]
        public void PopulateModelToEditForm_Test()
        {
            var washing = new Washing
                {
                   Code="7",
                    Name = "STONE WASHING",                   
                    CreatedDate = DateTime.Now,
                    CreatedBy = "user",
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = "user"
                };

            _washingSearchView.Setup(v => v.ConvertToModel(It.IsAny<object>())).Returns(washing);
            _washingSearchView.Setup(v => v.OpenEditForm(It.IsAny<Washing>()));

            _washingSearchPresenter.PopulateModelToEditForm("colCode", null);

            _washingSearchView.VerifyAll();

        }

        [TestMethod]
        public void DeleteSelectedModels_GivenTheUserSayYes_Test()
        {
            var washings = new List<Washing>
                {
                    new Washing
                    {
                       Code="7",
                        Name="STONE WASHING",                        
                        CreatedDate=DateTime.Now,
                        CreatedBy="user",
                        ModifiedDate=DateTime.Now,
                        ModifiedBy="user"
                    },
                       new Washing
                    {
                        Code="A",
                        Name="Urban Blue",                        
                        CreatedDate=DateTime.Now,
                        CreatedBy="user",
                        ModifiedDate=DateTime.Now,
                        ModifiedBy="user"
                    }
                };


            _washingSearchView.Setup(v => v.GetSelectedModels()).Returns(washings);
            _washingSearchView.Setup(v => v.ConfirmationPopUpYesNo(It.IsAny<string>())).Returns(DialogResult.Yes);
            _washingBusinessModel.Setup(b => b.Delete(It.IsAny<Washing>()));
            _washingSearchView.Setup(v => v.DeletedPopUpMessage(It.IsAny<string>()));
            _washingBusinessModel.Setup(b => b.SelectAll()).Returns(new List<Washing>());
            _washingSearchView.Setup(v => v.LoadModel(It.IsAny<List<Washing>>()));

            _washingSearchPresenter.DeleteSelectedModels();

            _washingSearchView.VerifyAll();
            _washingBusinessModel.Verify(b => b.Delete(It.IsAny<Washing>()), Times.Exactly(washings.Count));


        }

        [TestMethod]
        public void DeleteSelectedModels_GivenNoModelIsSelected_Test()
        {
            var categories = new List<Washing>();

            _washingSearchView.Setup(v => v.GetSelectedModels()).Returns(categories);

            _washingSearchPresenter.DeleteSelectedModels();

            _washingSearchView.VerifyAll();



        }

        [TestMethod]
        public void DeleteSelectedModels_GivenTheUserSayNo_Test()
        {
            var washings = new List<Washing>
                {
                    new Washing
                    {
                        Code="7",
                        Name="STONE WASHING",                        
                        CreatedDate=DateTime.Now,
                        CreatedBy="user",
                        ModifiedDate=DateTime.Now,
                        ModifiedBy="user"
                    },
                       new Washing
                    {
                          Code="A",
                        Name="Urban Blue",                        
                        CreatedDate=DateTime.Now,
                        CreatedBy="user",
                        ModifiedDate=DateTime.Now,
                        ModifiedBy="user"
                    }
                };


            _washingSearchView.Setup(v => v.GetSelectedModels()).Returns(washings);
            _washingSearchView.Setup(v => v.ConfirmationPopUpYesNo(It.IsAny<string>())).Returns(DialogResult.No);


            _washingSearchPresenter.DeleteSelectedModels();

            _washingSearchView.VerifyAll();
            _washingBusinessModel.VerifyAll();


        }
    }
}
