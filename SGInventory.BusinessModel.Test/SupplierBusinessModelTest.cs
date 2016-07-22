using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SGInventory.Dal;
using SGInventory.Model;
using SGInventory.Business.Model;

namespace SGInventory.BusinessModel.Test
{
    /// <summary>
    /// Summary description for SupplierDalTest
    /// </summary>
    [TestClass]
    public class SupplierBusinessModelTest
    {
        private Mock<ISupplierDal> _dalMoq;
        private ISupplierBusinessModel _businessModel;
        private readonly Supplier _supplier;

        public SupplierBusinessModelTest()
        {
            _dalMoq = new Mock<ISupplierDal>(MockBehavior.Strict);
            _businessModel = new SupplierBusinessModel(_dalMoq.Object);

            _supplier = new Supplier
            {
                Name = "Supplier X",
                Address = "Quezon City",
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
            _dalMoq.Setup(d => d.SelectAll()).Returns(new List<Supplier> { 
                {new Supplier{Name="SupplierX",Address="QC",CreatedDate=DateTime.Now,CreatedBy="user",Id=1}},
                 {new Supplier{Name="SupplierY",Address="Manila",CreatedDate=DateTime.Now,CreatedBy="user",Id=2}},
                 {new Supplier{Name="SupplierZ",Address="Mandaluyong",CreatedDate=DateTime.Now,CreatedBy="user",Id=3}},
            });

            List<Supplier> supplier = _businessModel.SelectAll();

            Assert.AreEqual(3, supplier.Count);

            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void SelectByPrimaryId_GivenTheId_Exists_ShouldReturnOneObjectTest()
        {
            var primaryId = 1;

            _dalMoq.Setup(d => d.SelectPrimaryEntity<int>(primaryId)).Returns(new Supplier { Name = "SupplierY", Address = "Manila", CreatedDate = DateTime.Now, CreatedBy = "user", Id = 1 });

            Supplier supplier = _businessModel.SelectByPrimaryId(primaryId);

            Assert.IsNotNull(supplier);

            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void SelectByPrimaryId_GivenTheIdNotExists_ShouldReturnEmptyCollectionTest()
        {


            var primaryId = 1;

            var expectedSupplier = new Supplier();

            _dalMoq.Setup(d => d.SelectPrimaryEntity<int>(primaryId)).Returns(expectedSupplier);

            var supplier = _businessModel.SelectByPrimaryId(primaryId);

            Assert.AreEqual<int>(expectedSupplier.Id, supplier.Id);

            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void Validate_GivenInAddModeAndTheNameAlreadyExists_ShouldReturnFalse()
        {
            var name = "SupplierX";
            var address = "QC";
            var dateNow = DateTime.Now;
            var user = "user";


            _dalMoq.Setup(s => s.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(new List<Supplier> { 
                {new Supplier{Name="SupplierX",Address="San Lazaro",CreatedDate=DateTime.Now,CreatedBy="user",Id=1}}                                 
            });

            var inputSupplier = new Supplier
            {
                Id = 0,
                Name = name,
                Address = address,
                CreatedBy = user,
                CreatedDate = dateNow,
                ModifiedBy = user,
                ModifiedDate = dateNow
            };

            var isValid = _businessModel.Valid(inputSupplier);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Validate_GivenInEditModeTheNameAlreadyExistsFromDifferentId_ShouldReturnFalse()
        {

            var name = "SupplierX";
            var address = "QC";
            var dateNow = DateTime.Now;
            var user = "user";

            var dictionary = new Dictionary<string, object>{
                        {"name",name}
            
            };

            _dalMoq.Setup(s => s.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(new List<Supplier> { 
                {new Supplier{Name="SupplierX",Address="QC",CreatedDate=DateTime.Now,CreatedBy="user",Id=2}}                                 
            });

            var inputSupplier = new Supplier
            {
                Id = 1,
                Name = name,
                Address = address,
                CreatedBy = user,
                CreatedDate = dateNow,
                ModifiedBy = user,
                ModifiedDate = dateNow
            };

            var isExists = _businessModel.Valid(inputSupplier);

            Assert.IsFalse(isExists);
        }

        [TestMethod]
        public void Validate_GivenInEditModeTheNameAlreadyExistsFromSameId_ShouldReturnTrue()
        {

            var name = "SupplierX";
            var address = "QC Edit";
            var dateNow = DateTime.Now;
            var user = "user";

            var dictionary = new Dictionary<string, object>{
                        {"name",name}
            
            };

            _dalMoq.Setup(s => s.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(new List<Supplier> { 
                {new Supplier{Name=name,Address="QC",CreatedDate=DateTime.Now,CreatedBy="user",Id=1}}                                 
            });

            var inputSupplier = new Supplier
            {
                Id = 1,
                Name = name,
                Address = address,
                CreatedBy = user,
                CreatedDate = dateNow,
                ModifiedBy = user,
                ModifiedDate = dateNow
            };

            var isExists = _businessModel.Valid(inputSupplier);

            Assert.IsTrue(isExists);
        }

        [TestMethod]
        public void Validate_GivenInNewModeTheNameNotExists_ShouldReturnTrue()
        {

            var name = "SupplierX";
            var address = "QC";
            var dateNow = DateTime.Now;
            var user = "user";

            _dalMoq.Setup(s => s.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(new List<Supplier>());

            var inputSupplier = new Supplier
            {
                Id = 0,
                Name = name,
                Address = address,
                CreatedBy = user,
                CreatedDate = dateNow,
                ModifiedBy = user,
                ModifiedDate = dateNow
            };

            var isExists = _businessModel.Valid(inputSupplier);

            Assert.IsTrue(isExists);
        }

        [TestMethod]
        public void Delete_Test()
        {
            var name = "SupplierX";

            var inputSupplier = new Supplier { Name = name };

            _dalMoq.Setup(s => s.Delete(inputSupplier));

            _businessModel.Delete(inputSupplier);

            _dalMoq.VerifyAll();


        }

        [TestMethod]
        public void SaveModel_GivenModelIsNewValidFieldsNameNotExistsQueryHasNoResult_ResultSuccessfull()
        {
            _supplier.Name = "SupplierX";

            _dalMoq.Setup(o => o.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(new List<Supplier>());
            _dalMoq.Setup(o => o.SaveOrUpdate(It.IsAny<Supplier>()));


            string response = _businessModel.Save(_supplier);

            Assert.AreEqual<string>("A new Supplier has been added", response);

            _dalMoq.VerifyAll();
        }

        [TestMethod]
        public void SaveModel_GivenModelIsNewValidFieldsNameAlreadyExistsQueryHasResult_ResultUnsuccessfull()
        {
            _supplier.Name = "SupplierX";

            var mockResultList = new List<Supplier>();
            mockResultList.Add(new Supplier { Id = 1, Name = "SupplierX" });

            _dalMoq.Setup(o => o.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(mockResultList);

            string response = _businessModel.Save(_supplier);

            Assert.AreEqual<string>("SupplierX already exists", response);

            _dalMoq.VerifyAll();
        }

        [TestMethod]
        public void SaveModel_GivenModelExistsValidFieldsNameAlreadyExistsQueryHasResult_ResultSuccessfull()
        {
            _supplier.Name = "SupplierX";
            _supplier.Id = 1;

            var mockResultList = new List<Supplier>();
            mockResultList.Add(new Supplier { Id = 1, Name = "SupplierX" });

            _dalMoq.Setup(o => o.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(mockResultList);
            _dalMoq.Setup(o => o.SaveOrUpdate(It.IsAny<Supplier>()));

            string response = _businessModel.Save(_supplier);

            Assert.AreEqual<string>("Supplier has been updated", response);

            _dalMoq.VerifyAll();
        }
        
    }
}
