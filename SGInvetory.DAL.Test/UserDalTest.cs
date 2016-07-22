using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGInventory.Model;
using Moq;
using SGInventory.Helpers;
using SGInventory.Dal;

namespace SGInventory.DAL.Test
{
    [TestClass]
    public class UserDalTest
    {
        [TestMethod]
        public void SelectAllTest()
        {
            List<User> users = new List<User>
                                            {
                                                new User{UserName="userNameA",Name="Fullname of User A",CreatedBy="sgiuser",CreatedDate=DateTime.Now},
                                                new User{UserName="userNameB",Name="Fullname of User B",CreatedBy="sgiuser",CreatedDate=DateTime.Now}
                                            };

            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectAll<User>()).Returns(users);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            IUserDal abstractDal = new UserDal(sgiHelper.Object);
            List<User> actualCategories = abstractDal.SelectAll();

            Assert.AreEqual(users.Count, actualCategories.Count);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void SelectByPrimaryKey_GivenPrimaryKey_ReturnShouldNotBeNull()
        {

            var user = new User { UserName = "userNameA", Name = "Fullname of User A", CreatedBy = "sgiuser", CreatedDate = DateTime.Now };


            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectPrimary<User, int>(1)).Returns(user);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            IUserDal abstractDal = new UserDal(sgiHelper.Object);
            User actualUser = abstractDal.SelectPrimaryEntity<int>(1);

            Assert.IsNotNull(actualUser);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();

        }

        [TestMethod]
        public void SelectBySp_GivenThereIsNoParameter_ReturnShouldBeInList()
        {
            List<User> users = new List<User>
                                            {
                                                new User{UserName="userNameA",Name="Fullname of User A",CreatedBy="sgiuser",CreatedDate=DateTime.Now},
                                                new User{UserName="userNameB",Name="Fullname of User B",CreatedBy="sgiuser",CreatedDate=DateTime.Now}
                                            };

            string spName = "spTest";
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectSp<User>(spName)).Returns(users);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            IUserDal abstractDal = new UserDal(sgiHelper.Object);

            List<User> actualCategories = abstractDal.SelectBySpQuery(spName);

            Assert.AreEqual(users.Count, actualCategories.Count);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void SelectBySp_GivenThereIsAParameter_ReturnShouldBeInList()
        {
            List<User> users = new List<User>
                                            {
                                                new User{UserName="userNameA",Name="Fullname of User A",CreatedBy="sgiuser",CreatedDate=DateTime.Now},
                                                new User{UserName="userNameB",Name="Fullname of User B",CreatedBy="sgiuser",CreatedDate=DateTime.Now}
                                            };

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"parameter1",1}
            };

            string spName = "spTest";

            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectSp<User>(spName, parameters)).Returns(users);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            IUserDal abstractDal = new UserDal(sgiHelper.Object);

            List<User> actualCategories = abstractDal.SelectBySpQuery(spName, parameters);

            Assert.AreEqual(users.Count, actualCategories.Count);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void SaveOrUpdate()
        {
            var user = new User { UserName = "userNameA", Name = "Fullname of User A", CreatedBy = "sgiuser", CreatedDate = DateTime.Now };


            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SaveOrUpdate<User>(user));

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);

            IUserDal abstractDal = new UserDal(sgiHelper.Object);

            abstractDal.SaveOrUpdate(user);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void Delete()
        {
            var user = new User { UserName = "userNameA", Name = "Fullname of User A", CreatedBy = "sgiuser", CreatedDate = DateTime.Now };


            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.Delete<User>(user));

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);

            IUserDal abstractDal = new UserDal(sgiHelper.Object);

            abstractDal.Delete(user);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }
    }
}
