using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGInventory.Helpers;
using Moq;
using SGInventory.Model;
using SGInventory.Dal;

namespace SGInventory.DAL.Test
{
    [TestClass]
    public class WashingDalTest
    {
        [TestMethod]
        public void SelectAllTest()
        {
            List<Washing> washings = new List<Washing>
                                            {
                                                new Washing{Code ="6",Name="ORDINARY WASH / RAW WASH / RINSE WASH",CreatedBy="sang",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,ModifiedBy="sang"},
                                                new Washing{Code ="7",Name="STONE WASH",CreatedBy="sang",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,ModifiedBy="sang"}
                                            };

            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectAll<Washing>()).Returns(washings);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            IWashingDal abstractDal = new WashingDal(sgiHelper.Object);
            List<Washing> actualCategories = abstractDal.SelectAll();

            Assert.AreEqual(washings.Count, actualCategories.Count);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void SelectByPrimaryKey_GivenPrimaryKey_ReturnShouldNotBeNull()
        {

            var washing = new Washing { Name = "ORDINARY WASH / RAW WASH / RINSE WASH", Code = "6", CreatedBy = "sgiwashing", CreatedDate = DateTime.Now };


            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectPrimary<Washing, string>(washing.Code)).Returns(washing);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            IWashingDal abstractDal = new WashingDal(sgiHelper.Object);
            Washing actualWashing = abstractDal.SelectPrimaryEntity<string>("6");

            Assert.IsNotNull(actualWashing);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();

        }

        [TestMethod]
        public void SelectBySp_GivenThereIsNoParameter_ReturnShouldBeInList()
        {
            List<Washing> washings = new List<Washing>
                                            {
                                                new Washing{Code ="6",Name="ORDINARY WASH / RAW WASH / RINSE WASH",CreatedBy="sang",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,ModifiedBy="sang"},
                                                new Washing{Code ="7",Name="STONE WASH",CreatedBy="sang",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,ModifiedBy="sang"}
                                            };

            string spName = "spTest";
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectSp<Washing>(spName)).Returns(washings);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            IWashingDal abstractDal = new WashingDal(sgiHelper.Object);

            List<Washing> actualCategories = abstractDal.SelectBySpQuery(spName);

            Assert.AreEqual(washings.Count, actualCategories.Count);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void SelectBySp_GivenThereIsAParameter_ReturnShouldBeInList()
        {
            List<Washing> washings = new List<Washing>
                                            {
                                                new Washing{Code = "6", Name = "ORDINARY WASH / RAW WASH / RINSE WASH",CreatedBy="sang",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,ModifiedBy="sang"},
                                                new Washing{Code ="7",Name="STONE WASH",CreatedBy="sang",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,ModifiedBy="sang"}
                                            };

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"parameter1",1}
            };

            string spName = "spTest";

            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectSp<Washing>(spName, parameters)).Returns(washings);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            IWashingDal abstractDal = new WashingDal(sgiHelper.Object);

            List<Washing> actualCategories = abstractDal.SelectBySpQuery(spName, parameters);

            Assert.AreEqual(washings.Count, actualCategories.Count);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void SaveOrUpdate()
        {
            var washing = new Washing { Name = "ORDINARY WASH / RAW WASH / RINSE WASH", Code = "6", CreatedBy = "sgiwashing", CreatedDate = DateTime.Now };

            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SaveOrUpdate<Washing>(washing));

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);

            IWashingDal abstractDal = new WashingDal(sgiHelper.Object);

            abstractDal.SaveOrUpdate(washing);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void Delete()
        {
            var washing = new Washing { Name = "ORDINARY WASH / RAW WASH / RINSE WASH", Code = "6", CreatedBy = "sgiwashing", CreatedDate = DateTime.Now };

            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.Delete<Washing>(washing));

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);

            IWashingDal abstractDal = new WashingDal(sgiHelper.Object);

            abstractDal.Delete(washing);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }
    }
}
