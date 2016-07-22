using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGInventory.Model;
using Moq;
using SGInventory.Business.Model;
using SGInventory.Presenters;
using SGInventory.Views;

namespace SGInventory.Presenters.Test
{
    [TestClass]
    public class ChangePasswordPresenterTest
    {
        private readonly User _mockUser;
        private readonly string _userName;
        private readonly ChangePasswordPresenter _presenter;
        private readonly Mock<IChangePasswordView> _view;
        private readonly Mock<IUserBusinessModel> _businessModel;
        public ChangePasswordPresenterTest()
        {
            _userName = "sang";
            _mockUser = new User { UserName = _userName, Name = "Santos Ngo Jr", Password = "password", Roletype = 1, Id = 1 };
           
            _view=new Mock<IChangePasswordView>(MockBehavior.Strict);
            _businessModel = new Mock<IUserBusinessModel>(MockBehavior.Strict);            
            _presenter = new ChangePasswordPresenter(_businessModel.Object, _view.Object);
        }

        [TestMethod]
        public void ChangePassword_GivenTheConfirmationOldPasswordIsNotCorrect_ResultWillBeNewPasswordWillNotPushThrough()
        {          
            var mockList = new List<User>{_mockUser};
            var confirmationOldPassword = "pass1";
            var newPassword = "password1";

            _businessModel.Setup(b => b.SelectUserByUserName(_userName)).Returns(_mockUser);
            _view.Setup(v => v.GetUserName()).Returns(_userName);
            _view.Setup(v => v.ConfirmationOldPassword()).Returns(confirmationOldPassword);            
            _view.Setup(v=>v.ShowMessage(It.IsAny<string>()));

            _presenter.ProcessNewPassword();

            _businessModel.VerifyAll();
            _view.VerifyAll();
            
        }

        [TestMethod]
        public void ChangePassword_GivenTheConfirmationOldPasswordIsCorrect_ResultWillBeNewPasswordWillPushThrough()
        {
            var mockList = new List<User> { _mockUser };
            var confirmationOldPassword = _mockUser.Password;
            var newPassword = "password1";

            _businessModel.Setup(b => b.SelectUserByUserName(_userName)).Returns(_mockUser);
            _view.Setup(v => v.GetUserName()).Returns(_userName);
            _view.Setup(v => v.ConfirmationOldPassword()).Returns(confirmationOldPassword);
            _view.Setup(v => v.NewPassword()).Returns(newPassword);
            _businessModel.Setup(b=>b.CreateOrUpdate(It.IsAny<User>()));
            _view.Setup(v => v.ShowMessage(It.IsAny<string>()));
            _view.Setup(v=>v.CloseForm());
            _presenter.ProcessNewPassword();

            _businessModel.VerifyAll();
            _view.VerifyAll();

        }
    }
}
