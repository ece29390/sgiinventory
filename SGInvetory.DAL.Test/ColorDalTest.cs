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
    public class ColorDalTest
    {
        [TestMethod]
        public void SelectAllTest()
        {
            List<Color> colors = new List<Color>
                                            {
                                                new Color{Code ="001",Name="Navy Blue",CreatedBy="sang",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,ModifiedBy="sang"},
                                                new Color{Code ="002",Name="Khaki",CreatedBy="sang",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,ModifiedBy="sang"}
                                            };

            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectAll<Color>()).Returns(colors);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            IColorDal abstractDal = new ColorDal(sgiHelper.Object);
            List<Color> actualCategories = abstractDal.SelectAll();

            Assert.AreEqual(colors.Count, actualCategories.Count);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void SelectByPrimaryKey_GivenPrimaryKey_ReturnShouldNotBeNull()
        {

            var color = new Color { Name = "Navy Blue", Code = "001", CreatedBy = "sgicolor", CreatedDate = DateTime.Now };


            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectPrimary<Color, string>(color.Code)).Returns(color);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            IColorDal abstractDal = new ColorDal(sgiHelper.Object);
            Color actualColor = abstractDal.SelectPrimaryEntity<string>("001");

            Assert.IsNotNull(actualColor);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();

        }

        [TestMethod]
        public void SelectBySp_GivenThereIsNoParameter_ReturnShouldBeInList()
        {
            List<Color> colors = new List<Color>
                                            {
                                                new Color{Code ="001",Name="Navy Blue",CreatedBy="sang",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,ModifiedBy="sang"},
                                                new Color{Code ="002",Name="Khaki",CreatedBy="sang",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,ModifiedBy="sang"}
                                            };

            string spName = "spTest";
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectSp<Color>(spName)).Returns(colors);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            IColorDal abstractDal = new ColorDal(sgiHelper.Object);

            List<Color> actualCategories = abstractDal.SelectBySpQuery(spName);

            Assert.AreEqual(colors.Count, actualCategories.Count);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void SelectBySp_GivenThereIsAParameter_ReturnShouldBeInList()
        {
            List<Color> colors = new List<Color>
                                            {
                                                new Color{Code ="001",Name="Navy Blue",CreatedBy="sang",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,ModifiedBy="sang"},
                                                new Color{Code ="002",Name="Khaki",CreatedBy="sang",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,ModifiedBy="sang"}
                                            };

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"parameter1",1}
            };

            string spName = "spTest";

            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectSp<Color>(spName, parameters)).Returns(colors);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            IColorDal abstractDal = new ColorDal(sgiHelper.Object);

            List<Color> actualCategories = abstractDal.SelectBySpQuery(spName, parameters);

            Assert.AreEqual(colors.Count, actualCategories.Count);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void SaveOrUpdate()
        {
            var color = new Color { Name = "Navy Blue", Code = "001", CreatedBy = "sgicolor", CreatedDate = DateTime.Now };

            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SaveOrUpdate<Color>(color));

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);

            IColorDal abstractDal = new ColorDal(sgiHelper.Object);

            abstractDal.SaveOrUpdate(color);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void Delete()
        {
            var color = new Color { Name = "Navy Blue", Code = "001", CreatedBy = "sgicolor", CreatedDate = DateTime.Now };

            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.Delete<Color>(color));

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);

            IColorDal abstractDal = new ColorDal(sgiHelper.Object);

            abstractDal.Delete(color);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }
    }
}
