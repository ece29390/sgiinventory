using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SGInventory.Dal;
using SGInventory.Business.Model;
using SGInventory.Model;
using SGInventory.Test.Data;

namespace SGInventory.BusinessModel.Test
{
    [TestClass]
    public class SizeBusinessModelTest
    {
        private Mock<ISizeDal> _dalMoq;
        private ISizeBusinessModel _businessModel;
        private readonly Size _size;

        public SizeBusinessModelTest()
        {
            _dalMoq = new Mock<ISizeDal>(MockBehavior.Strict);
            _businessModel = new SizeBusinessModel(_dalMoq.Object);

            _size = new Size { Name = "S", Code = "S3", CreatedBy = "sgisize", CreatedDate = DateTime.Now };
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
            _dalMoq.Setup(d => d.SelectAll()).Returns(new List<Size> { 
                {new Size { Name = "M", Code = "S3", CreatedBy = "sgisize", CreatedDate = DateTime.Now }},
                 {new Size { Name = "S", Code = "S2", CreatedBy = "sgisize", CreatedDate = DateTime.Now }},
                 {new Size { Name = "XL", Code = "S5", CreatedBy = "sgisize", CreatedDate = DateTime.Now }},
            });

            List<Size> supplier = _businessModel.SelectAll();

            Assert.AreEqual(3, supplier.Count);

            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void SelectByPrimaryId_GivenTheId_Exists_ShouldReturnOneObjectTest()
        {
            var primaryId = "S2";

            _dalMoq.Setup(d => d.SelectPrimaryEntity<string>(primaryId)).Returns(new Size { Name = "S", Code = "S2", CreatedBy = "sgisize", CreatedDate = DateTime.Now });

            Size size = _businessModel.SelectByPrimaryId(primaryId);

            Assert.IsNotNull(size);

            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void SelectByPrimaryId_GivenTheIdNotExists_ShouldReturnEmptyCollectionTest()
        {
            var primaryId = "S2";

            var expectedSize = new Size();

            _dalMoq.Setup(d => d.SelectPrimaryEntity<string>(primaryId)).Returns(expectedSize);

            var size = _businessModel.SelectByPrimaryId(primaryId);

            Assert.AreEqual<string>(expectedSize.Code, size.Code);

            _dalMoq.VerifyAll();

        }
                     
        [TestMethod]
        public void Delete_Test()
        {
            var code = "S1";

            var inputSize = new Size { Code = code };

            _dalMoq.Setup(s => s.Delete(inputSize));

            _businessModel.Delete(inputSize);

            _dalMoq.VerifyAll();


        }

        [TestMethod]
        public void SaveModel_GivenModelIsNewValidFieldsSizeCodeAndNameNotExistsQueryHasNoResult_ResultSuccessfull()
        {
            _size.Code = "S1";
            _size.Name = "S";
            _dalMoq.SetupSequence(o => o.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
                .Returns(new List<Size>())
                .Returns(new List<Size>());            
            _dalMoq.Setup(o => o.SaveOrUpdate(It.IsAny<Size>()));

            string response = _businessModel.Save(_size);

            Assert.AreEqual<string>("A new Size has been added", response);

            _dalMoq.VerifyAll();
        }

        [TestMethod]
        public void SaveModel_GivenModelIsNewValidFieldsSizeCodeNotExistsButNameExistsQueryHasNoResult_ResultSuccessfull()
        {
            _size.Code = "S4";
            _size.Name = "S";

            _dalMoq.SetupSequence(o => o.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
                .Returns(new List<Size>())
                .Returns(new List<Size> {new Size{Code="S1",Name="s"} });
            

            string response = _businessModel.Save(_size);

            Assert.AreEqual<string>("Name Already Exists!", response);

            _dalMoq.VerifyAll();
        }
             
        [TestMethod]
        public void SaveModel_GivenModelExistsValidFieldsSizeNameNotExistsQueryHasResult_ResultSuccessfull()
        {
            _size.Code = "S1";
            _size.Name = "L";

            var mockResultList = new List<Size>();          
            _dalMoq.SetupSequence(o => o.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
               .Returns(new List<Size> { new Size { Name = "S", Code = "S1" } })
               .Returns(mockResultList);
            _dalMoq.Setup(o => o.SaveOrUpdate(It.IsAny<Size>()));

            string response = _businessModel.Save(_size);

            Assert.AreEqual<string>("Size has been updated", response);

            _dalMoq.VerifyAll();
        }

        [TestMethod]
        public void SaveModel_GivenModelExistsValidFieldsSizeNameExistsAttachedToSameCodeQueryHasResult_ResultSuccessfull()
        {
            _size.Code = "S1";
            _size.Name = "L";

            var mockResultList = new List<Size>();
            _dalMoq.SetupSequence(o => o.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
               .Returns(new List<Size> { new Size{Name=_size.Name,Code=_size.Code} })
               .Returns(new List<Size> { new Size{Name=_size.Name,Code=_size.Code}});
            _dalMoq.Setup(o => o.SaveOrUpdate(It.IsAny<Size>()));

            string response = _businessModel.Save(_size);

            Assert.AreEqual<string>("Size has been updated", response);

            _dalMoq.VerifyAll();
        }

        [TestMethod]
        public void SelectByProductDetailstTest()
        {
            var productDetailTestData = new ProductDetailTestData();
            var productDetails = productDetailTestData.GetEntities();

            var sizes = _businessModel.SelectByProductDetails(productDetails);

            Assert.IsTrue(sizes.Count == 1);
        }
       
       
    }
}
