using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGInventory.Dal;
using Moq;
using SGInventory.Business.Model;
using SGInventory.Model;

namespace SGInventory.BusinessModel.Test
{
    [TestClass]
    public class UserBusinessModelTest
    {
        private Mock<IUserDal> _dalMoq;
        private IUserBusinessModel _businessModel;
        private readonly User _user;

        public UserBusinessModelTest()
        {
            _dalMoq = new Mock<IUserDal>(MockBehavior.Strict);
            _businessModel = new UserBusinessModel(_dalMoq.Object);

            _user = new User
            {
                Name = "Sandee Co",
                UserName="sco",
                Password="password",
                CreatedDate = DateTime.Now,
                CreatedBy = "user"
            };
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion


        [TestMethod]
        public void SelectAll_ShouldReturnList_Test()
        {
            _dalMoq.Setup(d => d.SelectAll()).Returns(new List<User> { 
                {new User{Name="UserX",Password="password",UserName="userX",CreatedDate=DateTime.Now,CreatedBy="user",Id=1}},
                 {new User{Name="UserY",Password="password",UserName="userY",CreatedDate=DateTime.Now,CreatedBy="user",Id=2}},
                 {new User{Name="UserZ",Password="password",UserName="userZ",CreatedDate=DateTime.Now,CreatedBy="user",Id=3}},
            });

            List<User> supplier = _businessModel.SelectAll();

            Assert.AreEqual(3, supplier.Count);

            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void SelectByPrimaryId_GivenTheId_Exists_ShouldReturnOneObjectTest()
        {
            var primaryId = 1;

            _dalMoq.Setup(d => d.SelectPrimaryEntity<int>(primaryId)).Returns(new User { UserName = "UserY", Password = "Manila", CreatedDate = DateTime.Now, CreatedBy = "user", Id = 1 });

            User supplier = _businessModel.SelectByPrimaryId(primaryId);

            Assert.IsNotNull(supplier);

            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void SelectByPrimaryId_GivenTheIdNotExists_ShouldReturnEmptyCollectionTest()
        {


            var primaryId = 1;

            var expectedUser = new User();

            _dalMoq.Setup(d => d.SelectPrimaryEntity<int>(primaryId)).Returns(expectedUser);

            var supplier = _businessModel.SelectByPrimaryId(primaryId);

            Assert.AreEqual<int>(expectedUser.Id, supplier.Id);

            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void Validate_GivenInAddModeAndTheUserNameAlreadyExists_ShouldReturnFalse()
        {
            var name = "UserX";
            var address = "QC";
            var dateNow = DateTime.Now;
            var user = "user";


            _dalMoq.Setup(s => s.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(new List<User> { 
                {new User{UserName="UserX",Password="San Lazaro",CreatedDate=DateTime.Now,CreatedBy="user",Id=1}}                                 
            });

            var inputUser = new User
            {
                Id = 0,
                UserName = name,
                Password = address,
                CreatedBy = user,
                CreatedDate = dateNow,
                ModifiedBy = user,
                ModifiedDate = dateNow
            };

            var isValid = _businessModel.Valid(inputUser);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Validate_GivenInEditModeTheUserNameAlreadyExistsFromDifferentId_ShouldReturnFalse()
        {

            var name = "UserX";
            var address = "QC";
            var dateNow = DateTime.Now;
            var user = "user";

            var dictionary = new Dictionary<string, object>{
                        {"name",name}
            
            };

            _dalMoq.Setup(s => s.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(new List<User> { 
                {new User{UserName="UserX",Password="QC",CreatedDate=DateTime.Now,CreatedBy="user",Id=2}}                                 
            });

            var inputUser = new User
            {
                Id = 1,
                UserName = name,
                Password = address,
                CreatedBy = user,
                CreatedDate = dateNow,
                ModifiedBy = user,
                ModifiedDate = dateNow
            };

            var isExists = _businessModel.Valid(inputUser);

            Assert.IsFalse(isExists);
        }

        [TestMethod]
        public void Validate_GivenInEditModeTheUserNameAlreadyExistsFromSameId_ShouldReturnTrue()
        {

            var name = "UserX";
            var address = "QC Edit";
            var dateNow = DateTime.Now;
            var user = "user";

            var dictionary = new Dictionary<string, object>{
                        {"name",name}
            
            };

            _dalMoq.Setup(s => s.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(new List<User> { 
                {new User{UserName=name,Password="QC",CreatedDate=DateTime.Now,CreatedBy="user",Id=1}}                                 
            });

            var inputUser = new User
            {
                Id = 1,
                UserName = name,
                Password = address,
                CreatedBy = user,
                CreatedDate = dateNow,
                ModifiedBy = user,
                ModifiedDate = dateNow
            };

            var isExists = _businessModel.Valid(inputUser);

            Assert.IsTrue(isExists);
        }

        [TestMethod]
        public void Validate_GivenInNewModeTheUserNameNotExists_ShouldReturnTrue()
        {

            var name = "UserX";
            var address = "QC";
            var dateNow = DateTime.Now;
            var user = "user";

            _dalMoq.Setup(s => s.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(new List<User>());

            var inputUser = new User
            {
                Id = 0,
                UserName = name,
                Password = address,
                CreatedBy = user,
                CreatedDate = dateNow,
                ModifiedBy = user,
                ModifiedDate = dateNow
            };

            var isExists = _businessModel.Valid(inputUser);

            Assert.IsTrue(isExists);
        }

        [TestMethod]
        public void Delete_Test()
        {
            var name = "UserX";

            var inputUser = new User { UserName = name };

            _dalMoq.Setup(s => s.Delete(inputUser));

            _businessModel.Delete(inputUser);

            _dalMoq.VerifyAll();


        }

        [TestMethod]
        public void SaveModel_GivenModelIsNewValidFieldsUserNameNotExistsQueryHasNoResult_ResultSuccessfull()
        {
            _user.UserName = "UserX";

            _dalMoq.Setup(o => o.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(new List<User>());
            _dalMoq.Setup(o => o.SaveOrUpdate(It.IsAny<User>()));


            string response = _businessModel.Save(_user);

            Assert.AreEqual<string>("A new User has been added", response);

            _dalMoq.VerifyAll();
        }

        [TestMethod]
        public void SaveModel_GivenModelIsNewValidFieldsUserNameAlreadyExistsQueryHasResult_ResultUnsuccessfull()
        {
            _user.UserName = "UserX";

            var mockResultList = new List<User>();
            mockResultList.Add(new User { Id = 1, UserName = "UserX" });

            _dalMoq.Setup(o => o.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(mockResultList);

            string response = _businessModel.Save(_user);

            Assert.AreEqual<string>("UserX already exists", response);

            _dalMoq.VerifyAll();
        }

        [TestMethod]
        public void SaveModel_GivenModelExistsValidFieldsUserNameAlreadyExistsQueryHasResult_ResultSuccessfull()
        {
            _user.UserName = "UserX";
            _user.Id = 1;

            var mockResultList = new List<User>();
            mockResultList.Add(new User { Id = 1, UserName = "UserX" });

            _dalMoq.Setup(o => o.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(mockResultList);
            _dalMoq.Setup(o => o.SaveOrUpdate(It.IsAny<User>()));

            string response = _businessModel.Save(_user);

            Assert.AreEqual<string>("User has been updated", response);

            _dalMoq.VerifyAll();
        }

        [TestMethod]
        public void LogIn_GivenUserHasCorrectCredentials_ReturnUserModelObjectWhichIsNotNull()
        {
            var mockResultList = new List<User>();
            mockResultList.Add(new User {  UserName="sang",Password="123456",Name="Santos Ngo Jr"});


            _dalMoq.Setup(o => o.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(mockResultList);

            User user = _businessModel.LogIn("sang", "123456");

            Assert.IsNotNull(user);
            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void LogIn_GivenUserHasInCorrectCredentials_ReturnUserModelObjectWhichIsNull()
        {
            var mockResultList = new List<User>();

            _dalMoq.Setup(o => o.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(mockResultList);

            User user = _businessModel.LogIn("sang", "123456");

            Assert.IsNull(user);
            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void SelectByUserName_GivenUserNameIsValid_ReturnActualUser()
        {
            var userName= "sang";
            var mockObjReturn = new User { UserName = userName, Name = "Santos Ngo Jr", Password = "password", Roletype = 1, Id = 1 };

            _dalMoq.Setup(d => d.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(new List<User> { mockObjReturn });

            User user = _businessModel.SelectUserByUserName(userName);

            Assert.IsNotNull(user);

            _dalMoq.VerifyAll();
        }

        [TestMethod]
        public void SelectByUserName_GivenUserNameIsInValid_ReturnIsNull()
        {
            var userName = "sang";
            
            _dalMoq.Setup(d => d.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(new List<User> ());

            User user = _businessModel.SelectUserByUserName(userName);

            Assert.IsNull(user);

            _dalMoq.VerifyAll();
        }

      
    }
}
