using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SGInventory.Business.Model;
using SGInventory.Presenters;
using SGInventory.Views;
using SGInventory.Model;
using System.Windows.Forms;

namespace SGInventory.Presenters.Test
{
    [TestClass]
    public class OutletSearchPresenterTest
    {
        private OutletSearchPresenter _outletSearchPresenter;
        private Mock<IOutletSearchView> _outletSearchView;
        private Mock<IOutletBusinessModel> _outletBusinessModel;
        private List<Outlet> _outlets;
        private Outlet _outlet;
        public OutletSearchPresenterTest()
        {
            _outletSearchView = new Mock<IOutletSearchView>(MockBehavior.Strict);
            _outletBusinessModel = new Mock<IOutletBusinessModel>(MockBehavior.Strict);
            _outletSearchPresenter = new OutletSearchPresenter(_outletSearchView.Object, _outletBusinessModel.Object);

            _outlets = new List<Outlet>
            {
                new Outlet
                {
                    Id=1,
                    Name="SM Cebu",
                    Address="Cebu",
                    CreatedDate=DateTime.Now,
                    CreatedBy="user",
                    ModifiedDate=DateTime.Now,
                    ModifiedBy="user"
                },
                   new Outlet
                {
                    Id=2,
                    Name="SM Manila",
                    Address="Ermita Manila",
                    CreatedDate=DateTime.Now,
                    CreatedBy="user",
                    ModifiedDate=DateTime.Now,
                    ModifiedBy="user"
                }
            };

            _outlet = new Outlet
            {
                Id = 2,
                Name = "SM San Lazaro",
                Address = "Tayuman, San Lazaro",
                CreatedDate = DateTime.Now,
                CreatedBy = "user",
                ModifiedDate = DateTime.Now,
                ModifiedBy = "user"
            };
        }

        [TestMethod]
        public void LoadAll_GivenAllAreSelected_Test()
        {
            
            _outletBusinessModel.Setup(b => b.SelectAll()).Returns(_outlets);
            _outletSearchView.Setup(s => s.LoadModel(It.IsAny<List<Outlet>>()));

            _outletSearchPresenter.LoadModels();

            _outletBusinessModel.VerifyAll();
            _outletSearchView.VerifyAll();
        }

        [TestMethod]
        public void AddModel_Test()
        {
            _outletSearchView.Setup(v => v.OpenEditForm());

            _outletSearchPresenter.OpenEditForm();

            _outletSearchView.VerifyAll();
        }

        [TestMethod]
        public void PopulateModelToEditForm_Test()
        {
            

            _outletSearchView.Setup(v => v.ConvertToModel(It.IsAny<object>())).Returns(_outlet);
            _outletSearchView.Setup(v => v.OpenEditForm(It.IsAny<Outlet>()));

            _outletSearchPresenter.PopulateModelToEditForm("colName", null);

            _outletSearchView.VerifyAll();

        }

        [TestMethod]
        public void DeleteSelectedModels_GivenTheUserSayYes_Test()
        {
            
            _outletSearchView.Setup(v => v.GetSelectedModels()).Returns(_outlets);
            _outletSearchView.Setup(v => v.ConfirmationPopUpYesNo(It.IsAny<string>())).Returns(DialogResult.Yes);
            _outletBusinessModel.Setup(b => b.Delete(It.IsAny<Outlet>()));
            _outletSearchView.Setup(v => v.DeletedPopUpMessage(It.IsAny<string>()));
            _outletBusinessModel.Setup(b => b.SelectAll()).Returns(new List<Outlet>());
            _outletSearchView.Setup(v => v.LoadModel(It.IsAny<List<Outlet>>()));

            _outletSearchPresenter.DeleteSelectedModels();

            _outletSearchView.VerifyAll();
            _outletBusinessModel.Verify(b => b.Delete(It.IsAny<Outlet>()), Times.Exactly(_outlets.Count));


        }

        [TestMethod]
        public void DeleteSelectedModels_GivenNothingIsSelected_Test()
        {
            var _outlet = new List<Outlet>();

            _outletSearchView.Setup(v => v.GetSelectedModels()).Returns(_outlet);

            _outletSearchPresenter.DeleteSelectedModels();

            _outletSearchView.VerifyAll();



        }

        [TestMethod]
        public void DeleteSelectedModels_GivenTheUserSayNo_Test()
        {
            


            _outletSearchView.Setup(v => v.GetSelectedModels()).Returns(_outlets);
            _outletSearchView.Setup(v => v.ConfirmationPopUpYesNo(It.IsAny<string>())).Returns(DialogResult.No);


            _outletSearchPresenter.DeleteSelectedModels();

            _outletSearchView.VerifyAll();
            _outletBusinessModel.VerifyAll();


        }
    }
}
