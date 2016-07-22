using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SGInventory.Business.Model;
using SGInventory.Views;
using SGInventory.Presenters;
using SGInventory.Model;

namespace SGInventory.Presenters.Test
{
    [TestClass]
    public class LogInPresenterTest
    {
        [TestMethod]
        public void LogIn_GivenCredential_IsValid_ResultClosingOfLogInForm()
        {
            var businessModelMock = new Mock<IUserBusinessModel>(MockBehavior.Strict);
            var logInView = new Mock<ILoginView>(MockBehavior.Strict);
            var presenter = new LoginPresenter(businessModelMock.Object,logInView.Object);

            businessModelMock.Setup(b => b.LogIn(It.IsAny<string>(), It.IsAny<string>())).Returns(new SGInventory.Model.User { UserName = "sang", Name = "Santos Ngo Jr", Id = 1 });
            logInView.Setup(v => v.SetUserProfile(It.IsAny<SGInventory.Model.User>()));
            logInView.Setup(v => v.SetUserSettings(It.IsAny<SGInventory.Model.User>()));
            logInView.Setup(v => v.CloseForm());

            presenter.LogIn("sang", "123456");

            businessModelMock.VerifyAll();
            logInView.VerifyAll();


        }

        [TestMethod]
        public void LogIn_GivenCredential_IsNotValid_ResultClosingOfLogInForm()
        {
            var businessModelMock = new Mock<IUserBusinessModel>(MockBehavior.Strict);
            var logInView = new Mock<ILoginView>(MockBehavior.Strict);
            var presenter = new LoginPresenter(businessModelMock.Object,logInView.Object);
            User mockReturn = null;
            businessModelMock.Setup(b => b.LogIn(It.IsAny<string>(), It.IsAny<string>())).Returns(mockReturn);         
            logInView.Setup(v => v.ShowMessage(It.IsAny<string>()));

            presenter.LogIn("sang", "123456");

            businessModelMock.VerifyAll();
            logInView.VerifyAll();


        }
    }
}
