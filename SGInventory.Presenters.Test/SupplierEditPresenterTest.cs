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

namespace SGInventory.Presenters.Test
{
    [TestClass]
    public class SupplierEditPresenterTest
    {
       private readonly SupplierEditPresenter _outletPresenter;
        private readonly Mock<ISupplierEditView> _outletView;
        private readonly Mock<ISupplierBusinessModel> _businessModel;

        public SupplierEditPresenterTest()
        {
            _outletView = new Mock<ISupplierEditView>(MockBehavior.Strict);
            _businessModel = new Mock<ISupplierBusinessModel>(MockBehavior.Strict);
            _outletPresenter = new SupplierEditPresenter(_outletView.Object, _businessModel.Object);
        }

        [TestMethod]
        public void Save_GivenThanNameNotExistsCreateNewModel_ResultSuccessfullPopUpMessage_Test()
        {

            var outletName = "SupplierX";
            var address = "QC";
            var user = "user";

            var outlet = new Supplier
            {
                Name = outletName,
                Address = address,
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var successfulResponse = "A new Supplier has been added";

            _outletView.Setup(v => v.GetName()).Returns(outletName);
            _outletView.Setup(v => v.GetAddress()).Returns(address);
            _outletView.Setup(v => v.GetUser()).Returns(user);
            _businessModel.Setup(b => b.Save(It.IsAny<Supplier>())).Returns(successfulResponse);

            var listOfSupplier = new List<Supplier>();
            outlet.Id = 1;
            listOfSupplier.Add(outlet);

            _businessModel.Setup(b => b.SelectAll()).Returns(listOfSupplier);

            var wasCalled = false;
            _outletPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsTrue(wasCalled);
            _outletView.VerifyAll();
            _businessModel.VerifyAll();

        }

        [TestMethod]
        public void SaveSupplier_GivenThanNameNotExistsSupplierAlreadyExists_ResultSuccessfullPopUpMessage_Test()
        {

            var outletName = "SupplierX QC";
            var address = "QC";
            var user = "user";
            var outlet = new Supplier
            {
                Id = 1,
                Name = outletName,
                Address = address,
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var successfullResponse = "Supplier has been updated";

            _outletView.Setup(v => v.GetName()).Returns(outletName);
            _outletView.Setup(v => v.GetAddress()).Returns(address);
            _outletView.Setup(v => v.GetUser()).Returns(user);
            _businessModel.Setup(b => b.Save(It.IsAny<Supplier>())).Returns(successfullResponse);

            var listOfSuppliers = new List<Supplier>();
            outlet.Id = 1;
            listOfSuppliers.Add(outlet);

            _businessModel.Setup(b => b.SelectAll()).Returns(listOfSuppliers);

            var wasCalled = false;
            _outletPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsTrue(wasCalled);

            _outletView.VerifyAll();
            _businessModel.VerifyAll();

        }

        [TestMethod]
        public void SaveSupplier_GivenThanNameExistsCreateNewSupplier_ResultUnSuccessfullPopUpMessage_Test()
        {
            var outletName = "SupplierX QC";
            var address = "QC";
            var user = "user";
            var outlet = new Supplier
            {
                Name = outletName,
                Address = address,
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var unsuccessfulResponse = "Supplier already exists";

            _outletView.Setup(v => v.GetName()).Returns(outletName);
            _outletView.Setup(v => v.GetAddress()).Returns(address);
            _outletView.Setup(v => v.GetUser()).Returns(user);
            _businessModel.Setup(b => b.Save(It.IsAny<Supplier>())).Returns(unsuccessfulResponse);

            var wasCalled = false;
            _outletPresenter.Save((response, list) => { wasCalled = true; });

            _outletView.VerifyAll();
            _businessModel.VerifyAll();

            Assert.IsTrue(wasCalled);

        }


        [TestMethod]
        public void LoadSupplier_GivenTheSupplierIsNotNull()
        {
            var outletName = "SupplierX QC";
            var address = "QC";
            var user = "user";
            var outlet = new Supplier
            {
                Name = outletName,
                Address = address,
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };

            _outletView.Setup(v => v.LoadData(It.IsAny<Supplier>()));


            _outletPresenter.LoadModels(outlet);

            _outletView.VerifyAll();

        }

        [TestMethod]
        public void UniqueNameKeypress_GivenThatTextHasLength_ShouldReturnTrue_Test()
        {
            var uniqueName = "sample";

            _outletView.Setup(s => s.GetName()).Returns(uniqueName);

            var presenter = new SupplierEditPresenter(_outletView.Object, _businessModel.Object);
            Assert.IsTrue(this._outletPresenter.ShouldEnable());
            _outletView.VerifyAll();
        }

        [TestMethod]
        public void UniqueNameKeypress_GivenThatTextHasNoLength_ShouldReturnTrue_Test()
        {
            var uniqueName = "";

            _outletView.Setup(s => s.GetName()).Returns(uniqueName);

            var presenter = new SupplierEditPresenter(_outletView.Object, _businessModel.Object);
            Assert.IsFalse(_outletPresenter.ShouldEnable());
            _outletView.VerifyAll();
        }

        [TestMethod]
        public void ValidationError_GivenAddressExceedsTheLimit_Test()
        {
            var outletName = "SupplierX QC";
            var address = "QC dsadasdasdasdasdasdasdsffdgffsdgsdfsdlfjosjfjdpoursjfl;js;fjsodufopsuwf;ljsdl;fjsdl;fjl;sdjfsjdflsdkhflshdfhslkdhfklsdhfklshdfsdhfklsdfklsdfuywiourfl;sdkfjopweurfopjws.fsdklfjosurejdfklsdofuiwsofhklsdhfioyekhfsklhfisdyrfiosehfklhsdifyowifhkldshfoisyfklyhdiowy";
            var user = "user";
            var outlet = new Supplier
            {
                Id = 1,
                Name = outletName,
                Address = address,
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var successfullResponse = "Supplier has been updated";

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

        [TestMethod]
        public void ValidationError_GivenNameExceedsTheLimit_Test()
        {
            var address = "SupplierX QC";
            var  outletName= "QC dsadasdasdasdasdasdasdsffdgffsdgsdfsdlfjosjfjdpoursjfl;js;fjsodufopsuwf;ljsdl;fjsdl;fjl;sdjfsjdflsdkhflshdfhslkdhfklsdhfklshdfsdhfklsdfklsdfuywiourfl;sdkfjopweurfopjws.fsdklfjosurejdfklsdofuiwsofhklsdhfioyekhfsklhfisdyrfiosehfklhsdifyowifhkldshfoisyfklyhdiowy";
            var user = "user";
            var outlet = new Supplier
            {
                Id = 1,
                Name = outletName,
                Address = address,
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var successfullResponse = "Supplier has been updated";

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
