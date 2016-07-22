using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGInventory.Business.Model;
using Moq;
using SGInventory.Dal;
using SGInventory.Model;
using SGInventory.Test.Data;

namespace SGInventory.BusinessModel.Test
{
    [TestClass]
    public class WashingBusinessModelTest
    {
        private Mock<IWashingDal> _dalMoq;
        private IWashingBusinessModel _businessModel;
        private readonly Washing _washing;

        public WashingBusinessModelTest()
        {
            _dalMoq = new Mock<IWashingDal>(MockBehavior.Strict);
            _businessModel = new WashingBusinessModel(_dalMoq.Object);

            _washing = new Washing { Name = "STONE WASHING", Code = "7", CreatedBy = "sgiwashing", CreatedDate = DateTime.Now };
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
            _dalMoq.Setup(d => d.SelectAll()).Returns(new List<Washing> { 
                {new Washing { Name = "STONE WASHING", Code = "7", CreatedBy = "sgiwashing", CreatedDate = DateTime.Now }},
                 {new Washing { Name = "Urban Blue", Code = "A", CreatedBy = "sgiwashing", CreatedDate = DateTime.Now }},
                 {new Washing { Name = "Enzyme", Code = "N", CreatedBy = "sgiwashing", CreatedDate = DateTime.Now }},
            });

            List<Washing> supplier = _businessModel.SelectAll();

            Assert.AreEqual(3, supplier.Count);

            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void SelectByPrimaryId_GivenTheId_Exists_ShouldReturnOneObjectTest()
        {
            var primaryId = "7";

            _dalMoq.Setup(d => d.SelectPrimaryEntity<string>(primaryId)).Returns(new Washing { Name = "S", Code = "S2", CreatedBy = "sgiwashing", CreatedDate = DateTime.Now });

            Washing washing = _businessModel.SelectByPrimaryId(primaryId);

            Assert.IsNotNull(washing);

            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void SelectByPrimaryId_GivenTheIdNotExists_ShouldReturnEmptyCollectionTest()
        {
            var primaryId = "7";

            var expectedWashing = new Washing();

            _dalMoq.Setup(d => d.SelectPrimaryEntity<string>(primaryId)).Returns(expectedWashing);

            var washing = _businessModel.SelectByPrimaryId(primaryId);

            Assert.AreEqual<string>(expectedWashing.Code, washing.Code);

            _dalMoq.VerifyAll();

        }
                     
        [TestMethod]
        public void Delete_Test()
        {
            var code = "7";

            var inputWashing = new Washing { Code = code };

            _dalMoq.Setup(s => s.Delete(inputWashing));

            _businessModel.Delete(inputWashing);

            _dalMoq.VerifyAll();


        }

        [TestMethod]
        public void SaveModel_GivenModelIsNewValidFieldsWashingCodeAndNameNotExistsQueryHasNoResult_ResultSuccessfull()
        {
            _washing.Code = "7";
            _washing.Name = "STONE WASHING";
            _dalMoq.SetupSequence(o => o.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
                .Returns(new List<Washing>())
                .Returns(new List<Washing>());            
            _dalMoq.Setup(o => o.SaveOrUpdate(It.IsAny<Washing>()));

            string response = _businessModel.Save(_washing);

            Assert.AreEqual<string>("A new Washing has been added", response);

            _dalMoq.VerifyAll();
        }

        [TestMethod]
        public void SaveModel_GivenModelIsNewValidFieldsWashingCodeNotExistsButNameExistsQueryHasNoResult_ResultSuccessfull()
        {
            _washing.Code = "7";
            _washing.Name = "STONE WASHING";

            _dalMoq.SetupSequence(o => o.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
                .Returns(new List<Washing>())
                .Returns(new List<Washing> { new Washing { Code = "6", Name = "STONE WASHING" } });
            

            string response = _businessModel.Save(_washing);

            Assert.AreEqual<string>("Name Already Exists!", response);

            _dalMoq.VerifyAll();
        }
             
        [TestMethod]
        public void SaveModel_GivenModelExistsValidFieldsWashingNameNotExistsQueryHasResult_ResultSuccessfull()
        {
            _washing.Code = "6";
            _washing.Name = "STONE WASHING";

            var mockResultList = new List<Washing>();          
            _dalMoq.SetupSequence(o => o.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
               .Returns(new List<Washing> { new Washing { Name = "S", Code = "6" } })
               .Returns(mockResultList);
            _dalMoq.Setup(o => o.SaveOrUpdate(It.IsAny<Washing>()));

            string response = _businessModel.Save(_washing);

            Assert.AreEqual<string>("Washing has been updated", response);

            _dalMoq.VerifyAll();
        }

        [TestMethod]
        public void SaveModel_GivenModelExistsValidFieldsWashingNameExistsAttachedToSameCodeQueryHasResult_ResultSuccessfull()
        {
            _washing.Code = "7";
            _washing.Name = "STONE WASHING";

            var mockResultList = new List<Washing>();
            _dalMoq.SetupSequence(o => o.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
               .Returns(new List<Washing> { new Washing{Name=_washing.Name,Code=_washing.Code} })
               .Returns(new List<Washing> { new Washing{Name=_washing.Name,Code=_washing.Code}});
            _dalMoq.Setup(o => o.SaveOrUpdate(It.IsAny<Washing>()));

            string response = _businessModel.Save(_washing);

            Assert.AreEqual<string>("Washing has been updated", response);

            _dalMoq.VerifyAll();
        }

        [TestMethod]
        public void SelectByProductDetailstTest()
        {
            var productDetailTestData = new ProductDetailTestData();
            var productDetails = productDetailTestData.GetEntities();

           var washings =_businessModel.SelectByProductDetails(productDetails);

           Assert.IsTrue(washings.Count == 1);
        }
    }
}
