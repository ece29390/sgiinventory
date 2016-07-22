using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGInventory.Model;
using SGInventory.Helpers;
using Moq;
using SGInventory.Dal;

namespace SGInventory.DAL.Test
{
    [TestClass]
    public class OutletTest
    {
        [TestMethod]
        public void SelectAllTest()
        {
            List<Outlet> outlets = new List<Outlet>
                                            {
                                                new Outlet{Name="OutletA",Address="Address of OutletA",CreatedBy="sgiuser",CreatedDate=DateTime.Now},
                                                new Outlet{Name="OutletB",Address="Address of OutletB",CreatedBy="sgiuser",CreatedDate=DateTime.Now},
                                            };

            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectAll<Outlet>()).Returns(outlets);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            IOutletDal abstractDal = new OutletDal(sgiHelper.Object);
            List<Outlet> actualCategories = abstractDal.SelectAll();

            Assert.AreEqual(outlets.Count, actualCategories.Count);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void SelectByPrimaryKey_GivenPrimaryKey_ReturnShouldNotBeNull()
        {

            var outlet = new Outlet { Name = "OutletA", Address = "Address of Outlet A", CreatedBy = "sgiuser", CreatedDate = DateTime.Now };


            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectPrimary<Outlet, int>(1)).Returns(outlet);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            IOutletDal abstractDal = new OutletDal(sgiHelper.Object);
            Outlet actualOutlet = abstractDal.SelectPrimaryEntity<int>(1);

            Assert.IsNotNull(actualOutlet);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();

        }

        [TestMethod]
        public void SelectBySp_GivenThereIsNoParameter_ReturnShouldBeInList()
        {
            List<Outlet> outlets = new List<Outlet>
                                            {
                                                new Outlet{Name="OutletA",Address="Address of OutletA",CreatedBy="sgiuser",CreatedDate=DateTime.Now},
                                                new Outlet{Name="OutletB",Address="Address of OutletB",CreatedBy="sgiuser",CreatedDate=DateTime.Now},
                                            };


            var spName = "spTest";
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectSp<Outlet>(spName)).Returns(outlets);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            IOutletDal abstractDal = new OutletDal(sgiHelper.Object);

            List<Outlet> actualCategories = abstractDal.SelectBySpQuery(spName);

            Assert.AreEqual(outlets.Count, actualCategories.Count);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void SelectBySp_GivenThereIsAParameter_ReturnShouldBeInList()
        {
            List<Outlet> outlets = new List<Outlet>
                                            {
                                                new Outlet{Name="OutletA",Address="Address of OutletA",CreatedBy="sgiuser",CreatedDate=DateTime.Now},
                                                new Outlet{Name="OutletB",Address="Address of OutletB",CreatedBy="sgiuser",CreatedDate=DateTime.Now},
                                            };


            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"parameter1",1}
            };
            string spName = "spTest";
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectSp<Outlet>(spName, parameters)).Returns(outlets);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            IOutletDal abstractDal = new OutletDal(sgiHelper.Object);

            List<Outlet> actualCategories = abstractDal.SelectBySpQuery(spName, parameters);

            Assert.AreEqual(outlets.Count, actualCategories.Count);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void SaveOrUpdate()
        {
            var outlet = new Outlet { Name = "OutletA", Address = "Address of Outlet A", CreatedBy = "sgiuser", CreatedDate = DateTime.Now };


            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SaveOrUpdate<Outlet>(outlet));

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);

            IOutletDal abstractDal = new OutletDal(sgiHelper.Object);

            abstractDal.SaveOrUpdate(outlet);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void Delete()
        {
            var outlet = new Outlet { Name = "OutletA", Address = "Address of Outlet A", CreatedBy = "sgiuser", CreatedDate = DateTime.Now };


            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.Delete<Outlet>(outlet));

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);

            IOutletDal abstractDal = new OutletDal(sgiHelper.Object);

            abstractDal.Delete(outlet);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

    }
}
