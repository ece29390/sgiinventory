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

namespace SGInventory.Presenters.Test
{
    [TestClass]
    public class OutletEditPresenterTest
    {
        private readonly OutletEditPresenter _outletPresenter;
        private readonly Mock<IOutletEditView> _outletView;
        private readonly Mock<IOutletBusinessModel> _businessModel;

        public OutletEditPresenterTest()
        {
            _outletView = new Mock<IOutletEditView>(MockBehavior.Strict);
            _businessModel = new Mock<IOutletBusinessModel>(MockBehavior.Strict);
            _outletPresenter = new OutletEditPresenter(_outletView.Object, _businessModel.Object);
        }

        [TestMethod]
        public void Save_GivenThanNameNotExistsCreateNewModel_ResultSuccessfullPopUpMessage_Test()
        {

            var outletName = "SM City";
            var address = "Cebu";
            var user = "user";

            var outlet = new Outlet
            {
                Name = outletName,
                Address = address,
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var successfulResponse = "A new Outlet has been added";

            _outletView.Setup(v => v.GetName()).Returns(outletName);
            _outletView.Setup(v => v.GetAddress()).Returns(address);
            _outletView.Setup(v => v.GetUser()).Returns(user);
            _businessModel.Setup(b => b.Save(It.IsAny<Outlet>())).Returns(successfulResponse);

            var listOfOutlet = new List<Outlet>();
            outlet.Id = 1;
            listOfOutlet.Add(outlet);

            _businessModel.Setup(b => b.SelectAll()).Returns(listOfOutlet);

            var wasCalled = false;
            _outletPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsTrue(wasCalled);
            _outletView.VerifyAll();
            _businessModel.VerifyAll();

        }

        [TestMethod]
        public void SaveOutlet_GivenThanNameNotExistsOutletAlreadyExists_ResultSuccessfullPopUpMessage_Test()
        {

            var outletName = "SM City Cebu";
            var address = "Cebu";
            var user = "user";
            var outlet = new Outlet
            {
                Id = 1,
                Name = outletName,
                Address = address,
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var successfullResponse = "Outlet has been updated";

            _outletView.Setup(v => v.GetName()).Returns(outletName);
            _outletView.Setup(v => v.GetAddress()).Returns(address);
            _outletView.Setup(v => v.GetUser()).Returns(user);
            _businessModel.Setup(b => b.Save(It.IsAny<Outlet>())).Returns(successfullResponse);

            var listOfOutlets = new List<Outlet>();
            outlet.Id = 1;
            listOfOutlets.Add(outlet);

            _businessModel.Setup(b => b.SelectAll()).Returns(listOfOutlets);

            var wasCalled = false;
            _outletPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsTrue(wasCalled);

            _outletView.VerifyAll();
            _businessModel.VerifyAll();

        }

        [TestMethod]
        public void SaveOutlet_GivenThanNameExistsCreateNewOutlet_ResultUnSuccessfullPopUpMessage_Test()
        {
            var outletName = "SM City Cebu";
            var address = "Cebu";
            var user = "user";
            var outlet = new Outlet
            {
                Name = outletName,
                Address = address,
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var unsuccessfulResponse = "Outlet already exists";

            _outletView.Setup(v => v.GetName()).Returns(outletName);
            _outletView.Setup(v => v.GetAddress()).Returns(address);
            _outletView.Setup(v => v.GetUser()).Returns(user);
            _businessModel.Setup(b => b.Save(It.IsAny<Outlet>())).Returns(unsuccessfulResponse);

            var wasCalled = false;
            _outletPresenter.Save((response, list) => { wasCalled = true; });

            _outletView.VerifyAll();
            _businessModel.VerifyAll();

            Assert.IsTrue(wasCalled);

        }


        [TestMethod]
        public void LoadOutlet_GivenTheOutletIsNotNull()
        {
            var outletName = "SM City Cebu";
            var address = "Cebu";
            var user = "user";
            var outlet = new Outlet
            {
                Name = outletName,
                Address = address,
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };

            _outletView.Setup(v => v.LoadData(It.IsAny<Outlet>()));


            _outletPresenter.LoadModels(outlet);

            _outletView.VerifyAll();

        }

        [TestMethod]
        public void UniqueNameKeypress_GivenThatTextHasLength_ShouldReturnTrue_Test()
        {
            var uniqueName = "sample";

            _outletView.Setup(s => s.GetName()).Returns(uniqueName);

            var presenter = new OutletEditPresenter(_outletView.Object, _businessModel.Object);
            Assert.IsTrue(this._outletPresenter.ShouldEnable());
            _outletView.VerifyAll();
        }

        [TestMethod]
        public void UniqueNameKeypress_GivenThatTextHasNoLength_ShouldReturnTrue_Test()
        {
            var uniqueName = "";

            _outletView.Setup(s => s.GetName()).Returns(uniqueName);

            var presenter = new OutletEditPresenter(_outletView.Object, _businessModel.Object);
            Assert.IsFalse(_outletPresenter.ShouldEnable());
            _outletView.VerifyAll();
        }

        [TestMethod]
        public void ValidationError_GivenAddressExceedsTheLimit_Test()
        {
            var outletName = "SM City Cebu";
            var address = "Cebu dsadasdasdasdasdasdasdsffdgffsdgsdfsdlfjosjfjdpoursjfl;js;fjsodufopsuwf;ljsdl;fjsdl;fjl;sdjfsjdflsdkhflshdfhslkdhfklsdhfklshdfsdhfklsdfklsdfuywiourfl;sdkfjopweurfopjws.fsdklfjosurejdfklsdofuiwsofhklsdhfioyekhfsklhfisdyrfiosehfklhsdifyowifhkldshfoisyfklyhdiowy";
            var user = "user";
            var outlet = new Outlet
            {
                Id = 1,
                Name = outletName,
                Address = address,
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var successfullResponse = "Outlet has been updated";

            _outletView.Setup(v => v.GetName()).Returns(outletName);
            _outletView.Setup(v => v.GetAddress()).Returns(address);
            _outletView.Setup(v => v.GetUser()).Returns(user);
            _outletView.Setup(v => v.ShowMessage(It.IsAny<string>()));

          

            var wasCalled = false;
            _outletPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsFalse(wasCalled);

            _outletView.VerifyAll();
            _businessModel.VerifyAll();
        }

        [TestMethod]
        public void ValidationError_GivenNameExceedsTheLimit_Test()
        {
            var address = "SM City Cebu";
            var  outletName= "Cebu dsadasdasdasdasdasdasdsffdgffsdgsdfsdlfjosjfjdpoursjfl;js;fjsodufopsuwf;ljsdl;fjsdl;fjl;sdjfsjdflsdkhflshdfhslkdhfklsdhfklshdfsdhfklsdfklsdfuywiourfl;sdkfjopweurfopjws.fsdklfjosurejdfklsdofuiwsofhklsdhfioyekhfsklhfisdyrfiosehfklhsdifyowifhkldshfoisyfklyhdiowy";
            var user = "user";
            var outlet = new Outlet
            {
                Id = 1,
                Name = outletName,
                Address = address,
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var successfullResponse = "Outlet has been updated";

            _outletView.Setup(v => v.GetName()).Returns(outletName);
            _outletView.Setup(v => v.GetAddress()).Returns(address);
            _outletView.Setup(v => v.GetUser()).Returns(user);
            _outletView.Setup(v => v.ShowMessage(It.IsAny<string>()));



            var wasCalled = false;
            _outletPresenter.Save((response, list) => { wasCalled = false; });
            Assert.IsFalse(wasCalled);

            _outletView.VerifyAll();
            _businessModel.VerifyAll();
        }
    }
}
