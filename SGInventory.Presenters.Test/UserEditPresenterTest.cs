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

namespace SGInventory.Presenters.Test
{
    [TestClass]
    public class UserEditPresenterTest
    {
       private readonly UserEditPresenter _modelPresenter;
        private readonly Mock<IUserEditView> _modelView;
        private readonly Mock<IUserBusinessModel> _businessModel;

        public UserEditPresenterTest()
        {
            _modelView = new Mock<IUserEditView>(MockBehavior.Strict);
            _businessModel = new Mock<IUserBusinessModel>(MockBehavior.Strict);
            _modelPresenter = new UserEditPresenter(_modelView.Object, _businessModel.Object);
        }

        [TestMethod]
        public void Save_GivenThanNameNotExistsCreateNewModel_ResultSuccessfullPopUpMessage_Test()
        {

            var userName = "UserX";
            var password = "QC";
            var user = "user";

            var model = new User
            {
                UserName = userName,
                Password = password,
                Name="Fullname",
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var successfulResponse = "A new User has been added";

            _modelView.Setup(v => v.GetName()).Returns(userName);
            _modelView.Setup(v => v.GetPassword()).Returns(password);
            _modelView.Setup(v => v.UserName()).Returns(userName);
            _modelView.Setup(v => v.GetUser()).Returns(user);
            _modelView.Setup(v => v.GetRoleTypeValue()).Returns(1);
            _businessModel.Setup(b => b.Save(It.IsAny<User>())).Returns(successfulResponse);

            var listOfUser = new List<User>();
            model.Id = 1;
            listOfUser.Add(model);

            _businessModel.Setup(b => b.SelectAll()).Returns(listOfUser);

            var wasCalled = false;
            _modelPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsTrue(wasCalled);
            _modelView.VerifyAll();
            _businessModel.VerifyAll();

        }

        [TestMethod]
        public void SaveUser_GivenThanNameNotExistsUserAlreadyExists_ResultSuccessfullPopUpMessage_Test()
        {

            var modelName = "UserX QC";
            var password = "QC";
            var user = "user";
            var model = new User
            {
                Id = 1,
                Name = modelName,
                Password = password,
                UserName="UserXQC",
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var successfullResponse = "User has been updated";

            _modelView.Setup(v => v.GetName()).Returns(modelName);
            _modelView.Setup(v => v.UserName()).Returns("XQC");
            _modelView.Setup(v => v.GetPassword()).Returns(password);
            _modelView.Setup(v => v.GetUser()).Returns(user);
            _modelView.Setup(v => v.GetRoleTypeValue()).Returns(1);
            _businessModel.Setup(b => b.Save(It.IsAny<User>())).Returns(successfullResponse);

            var listOfUsers = new List<User>();
            model.Id = 1;
            listOfUsers.Add(model);

            _businessModel.Setup(b => b.SelectAll()).Returns(listOfUsers);

            var wasCalled = false;
            _modelPresenter.Save((response, list) => { wasCalled = true; });
            Assert.IsTrue(wasCalled);

            _modelView.VerifyAll();
            _businessModel.VerifyAll();

        }

        [TestMethod]
        public void SaveUser_GivenThanNameExistsCreateNewUser_ResultUnSuccessfullPopUpMessage_Test()
        {
            var modelName = "UserX QC";
            var password = "QC";
            var user = "user";
            var model = new User
            {
                Name = modelName,
                Password = password,
                UserName="XQC",
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            var unsuccessfulResponse = "User already exists";

            _modelView.Setup(v => v.GetName()).Returns(modelName);
            _modelView.Setup(v => v.GetPassword()).Returns(password);
            _modelView.Setup(v => v.UserName()).Returns(model.UserName);
            _modelView.Setup(v => v.GetUser()).Returns(user);
            _businessModel.Setup(b => b.Save(It.IsAny<User>())).Returns(unsuccessfulResponse);
            _modelView.Setup(v => v.GetRoleTypeValue()).Returns(1);
            var wasCalled = false;
            _modelPresenter.Save((response, list) => { wasCalled = true; });

            _modelView.VerifyAll();
            _businessModel.VerifyAll();

            Assert.IsTrue(wasCalled);

        }

        [TestMethod]
        public void LoadUser_GivenTheUserIsNotNull()
        {
            var modelName = "UserX QC";
            var password = "QC";
            var user = "user";
            var model = new User
            {
                Name = modelName,
                Password = password,
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };

            _modelView.Setup(v => v.LoadData(It.IsAny<User>()));


            _modelPresenter.LoadModels(model);

            _modelView.VerifyAll();

        }

     
        [TestMethod]
        public void ValidationError_GivenPasswordExceedsTheLimit_Test()
        {
            var modelName = "UserX QC";
            var password = "QC dsadasdasdasdasdasdasdsffdgffsdgsdfsdlfjosjfjdpoursjfl;js;fjsodufopsuwf;ljsdl;fjsdl;fjl;sdjfsjdflsdkhflshdfhslkdhfklsdhfklshdfsdhfklsdfklsdfuywiourfl;sdkfjopweurfopjws.fsdklfjosurejdfklsdofuiwsofhklsdhfioyekhfsklhfisdyrfiosehfklhsdifyowifhkldshfoisyfklyhdiowy";
            var user = "user";
            var model = new User
            {
                Id = 1,
                Name = modelName,
                Password = password,
                UserName="XQC",
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };
            

            _modelView.Setup(v => v.GetName()).Returns(modelName);
            _modelView.Setup(v => v.GetPassword()).Returns(password);
            _modelView.Setup(v => v.UserName()).Returns(model.UserName);
            _modelView.Setup(v => v.GetUser()).Returns(user);
            _modelView.Setup(v => v.ShowMessage(It.IsAny<string>()));
            _modelView.Setup(v => v.GetRoleTypeValue()).Returns(1);
          

            var wasCalled = false;
            _modelPresenter.Save((response, list) => { wasCalled = false ; });
            Assert.IsFalse(wasCalled);

            _modelView.VerifyAll();
            _businessModel.VerifyAll();
        }

        [TestMethod]
        public void ValidationError_GivenUserNameExceedsTheLimit_Test()
        {
            var fullName = "FullName";
            var userName = "QC dsadasdasdasdasdasdasdsffdgffsdgsdfsdlfjosjfjdpoursjfl;js;fjsodufopsuwf;ljsdl;fjsdl;fjl;sdjfsjdflsdkhflshdfhslkdhfklsdhfklshdfsdhfklsdfklsdfuywiourfl;sdkfjopweurfopjws.fsdklfjosurejdfklsdofuiwsofhklsdhfioyekhfsklhfisdyrfiosehfklhsdifyowifhkldshfoisyfklyhdiowy";
            var user = "user";
            var model = new User
            {
                Id = 1,
                Name = fullName,
                Password = "1234",                
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };


            _modelView.Setup(v => v.GetName()).Returns(fullName);
            _modelView.Setup(v => v.UserName()).Returns(userName);
            _modelView.Setup(v => v.GetPassword()).Returns(model.Password);
            _modelView.Setup(v => v.GetUser()).Returns(user);
            _modelView.Setup(v => v.ShowMessage(It.IsAny<string>()));
            _modelView.Setup(v => v.GetRoleTypeValue()).Returns(1);


            var wasCalled = false;
            _modelPresenter.Save((response, list) => { wasCalled = false; });
            Assert.IsFalse(wasCalled);

            _modelView.VerifyAll();
            _businessModel.VerifyAll();
        }

        [TestMethod]
        public void ValidationError_GivenNameExceedsTheLimit_Test()
        {
            var  userName= "userName";
            var fullName = "QC dsadasdasdasdasdasdasdsffdgffsdgsdfsdlfjosjfjdpoursjfl;js;fjsodufopsuwf;ljsdl;fjsdl;fjl;sdjfsjdflsdkhflshdfhslkdhfklsdhfklshdfsdhfklsdfklsdfuywiourfl;sdkfjopweurfopjws.fsdklfjosurejdfklsdofuiwsofhklsdhfioyekhfsklhfisdyrfiosehfklhsdifyowifhkldshfoisyfklyhdiowy";
            var user = "user";
            var model = new User
            {
                Id = 1,
                Name = fullName,
                Password = "1234",
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };


            _modelView.Setup(v => v.GetName()).Returns(fullName);
            _modelView.Setup(v => v.UserName()).Returns(userName);
            _modelView.Setup(v => v.GetPassword()).Returns(model.Password);
            _modelView.Setup(v => v.GetUser()).Returns(user);
            _modelView.Setup(v => v.ShowMessage(It.IsAny<string>()));
            _modelView.Setup(v => v.GetRoleTypeValue()).Returns(1);


            var wasCalled = false;
            _modelPresenter.Save((response, list) => { wasCalled = false; });
            Assert.IsFalse(wasCalled);

            _modelView.VerifyAll();
            _businessModel.VerifyAll();
        }

        [TestMethod]
        public void ShouldEnable_GivenAllKeyFieldsAreNotEmpty_ShouldReturnTrue()
        {
            _modelView.Setup(v => v.UserName()).Returns("userName");
            _modelView.Setup(v => v.GetName()).Returns("name");
            _modelView.Setup(v => v.GetPassword()).Returns("password");

            var presenter = new UserEditPresenter(_modelView.Object, _businessModel.Object);
            Assert.IsTrue(presenter.ShouldEnable());

            _modelView.VerifyAll();
        }

        [TestMethod]
        public void ShouldEnable_AtleastOneKeyFieldsIsEmpty_ShouldReturnFalse()
        {
            _modelView.Setup(v => v.UserName()).Returns("");
           
            var presenter = new UserEditPresenter(_modelView.Object, _businessModel.Object);
            Assert.IsFalse(presenter.ShouldEnable());

            _modelView.VerifyAll();
        }

        [TestMethod]
        public void LoadRoleTypes_ShouldLoadToComboBox()
        {
            _modelView.Setup(v => v.LoadRoleTypes());

            _modelPresenter.LoadRoleTypes();

            _modelView.VerifyAll();
        }
    }
}
