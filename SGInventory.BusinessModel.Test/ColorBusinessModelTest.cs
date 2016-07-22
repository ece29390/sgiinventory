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
    public class ColorBusinessModelTest
    {
       private Mock<IColorDal> _dalMoq;
        private IColorBusinessModel _businessModel;
        private readonly SGInventory.Model.Color _color;

        public ColorBusinessModelTest()
        {
            _dalMoq = new Mock<IColorDal>(MockBehavior.Strict);
            _businessModel = new ColorBusinessModel(_dalMoq.Object);

            _color = new Color { Name = "Navy Blue", Code = "001", CreatedBy = "sgicolor", CreatedDate = DateTime.Now };
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
            _dalMoq.Setup(d => d.SelectAll()).Returns(new List<Color> { 
                {new Color { Name = "Navy Blue", Code = "001", CreatedBy = "sgicolor", CreatedDate = DateTime.Now }},
                 {new Color { Name = "Khaki", Code = "002", CreatedBy = "sgicolor", CreatedDate = DateTime.Now }},
                 {new Color { Name = "White", Code = "003", CreatedBy = "sgicolor", CreatedDate = DateTime.Now }},
            });

            List<Color> supplier = _businessModel.SelectAll();

            Assert.AreEqual(3, supplier.Count);

            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void SelectByPrimaryId_GivenTheId_Exists_ShouldReturnOneObjectTest()
        {
            var primaryId = "002";

            _dalMoq.Setup(d => d.SelectPrimaryEntity<string>(primaryId)).Returns(new Color { Name = "Navy Blue", Code = "002", CreatedBy = "sgicolor", CreatedDate = DateTime.Now });

            Color color = _businessModel.SelectByPrimaryId(primaryId);

            Assert.IsNotNull(color);

            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void SelectByPrimaryId_GivenTheIdNotExists_ShouldReturnEmptyCollectionTest()
        {
            var primaryId = "002";

            var expectedColor = new Color();

            _dalMoq.Setup(d => d.SelectPrimaryEntity<string>(primaryId)).Returns(expectedColor);

            var color = _businessModel.SelectByPrimaryId(primaryId);

            Assert.AreEqual<string>(expectedColor.Code, color.Code);

            _dalMoq.VerifyAll();

        }
                     
        [TestMethod]
        public void Delete_Test()
        {
            var code = "S1";

            var inputColor = new Color { Code = code };

            _dalMoq.Setup(s => s.Delete(inputColor));

            _businessModel.Delete(inputColor);

            _dalMoq.VerifyAll();


        }

        [TestMethod]
        public void SaveModel_GivenModelIsNewValidFieldsColorCodeAndNameNotExistsQueryHasNoResult_ResultSuccessfull()
        {
            _color.Code = "001";
            _color.Name = "Navy Blue";
            _dalMoq.SetupSequence(o => o.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
                .Returns(new List<Color>())
                .Returns(new List<Color>());            
            _dalMoq.Setup(o => o.SaveOrUpdate(It.IsAny<Color>()));

            string response = _businessModel.Save(_color);

            Assert.AreEqual<string>("A new Color has been added", response);

            _dalMoq.VerifyAll();
        }

        [TestMethod]
        public void SaveModel_GivenModelIsNewValidFieldsColorCodeNotExistsButNameExistsQueryHasNoResult_ResultSuccessfull()
        {
            _color.Code = "004";
            _color.Name = "Navy Blue";

            _dalMoq.SetupSequence(o => o.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
                .Returns(new List<Color>())
                .Returns(new List<Color> {new Color{Code="001",Name="navy blue"} });
            

            string response = _businessModel.Save(_color);

            Assert.AreEqual<string>("Name Already Exists!", response);

            _dalMoq.VerifyAll();
        }
             
        [TestMethod]
        public void SaveModel_GivenModelExistsValidFieldsColorNameNotExistsQueryHasResult_ResultSuccessfull()
        {
            _color.Code = "001";
            _color.Name = "Khaki";

            var mockResultList = new List<Color>();          
            _dalMoq.SetupSequence(o => o.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
               .Returns(new List<Color> { new Color { Name = "Navy BLue", Code = "001" } })
               .Returns(mockResultList);
            _dalMoq.Setup(o => o.SaveOrUpdate(It.IsAny<Color>()));

            string response = _businessModel.Save(_color);

            Assert.AreEqual<string>("Color has been updated", response);

            _dalMoq.VerifyAll();
        }

        [TestMethod]
        public void SaveModel_GivenModelExistsValidFieldsColorNameExistsAttachedToSameCodeQueryHasResult_ResultSuccessfull()
        {
            _color.Code = "001";
            _color.Name = "Khaki";

            var mockResultList = new List<Color>();
            _dalMoq.SetupSequence(o => o.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>()))
               .Returns(new List<Color> { new Color{Name=_color.Name,Code=_color.Code} })
               .Returns(new List<Color> { new Color{Name=_color.Name,Code=_color.Code}});
            _dalMoq.Setup(o => o.SaveOrUpdate(It.IsAny<Color>()));

            string response = _businessModel.Save(_color);

            Assert.AreEqual<string>("Color has been updated", response);

            _dalMoq.VerifyAll();
        }

        [TestMethod]
        public void SelectByProductDetailstTest()
        {
            var productDetailTestData = new ProductDetailTestData();
            var productDetails = productDetailTestData.GetEntities();

            var colors = _businessModel.SelectByProductDetails(productDetails);

            Assert.IsTrue(colors.Count == 1);
        }

        
    }
}
