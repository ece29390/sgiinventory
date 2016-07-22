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
    public class SizeDalTest
    {
        [TestMethod]
        public void SelectAllTest()
        {
            List<Size> sizes = new List<Size>
                                            {
                                                new Size{Code ="S3",Name="S",CreatedBy="sang",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,ModifiedBy="sang"},
                                                new Size{Code ="S4",Name="S",CreatedBy="sang",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,ModifiedBy="sang"}
                                            };

            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectAll<Size>()).Returns(sizes);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            ISizeDal abstractDal = new SizeDal(sgiHelper.Object);
            List<Size> actualCategories = abstractDal.SelectAll();

            Assert.AreEqual(sizes.Count, actualCategories.Count);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void SelectByPrimaryKey_GivenPrimaryKey_ReturnShouldNotBeNull()
        {

            var size = new Size { Name = "S", Code="S3", CreatedBy = "sgisize", CreatedDate = DateTime.Now };


            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectPrimary<Size, string>(size.Code)).Returns(size);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            ISizeDal abstractDal = new SizeDal(sgiHelper.Object);
            Size actualSize = abstractDal.SelectPrimaryEntity<string>("S3");

            Assert.IsNotNull(actualSize);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();

        }

        [TestMethod]
        public void SelectBySp_GivenThereIsNoParameter_ReturnShouldBeInList()
        {
            List<Size> sizes = new List<Size>
                                            {
                                                new Size{Code ="S3",Name="S",CreatedBy="sang",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,ModifiedBy="sang"},
                                                new Size{Code ="S4",Name="S",CreatedBy="sang",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,ModifiedBy="sang"}
                                            };

            string spName = "spTest";
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectSp<Size>(spName)).Returns(sizes);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            ISizeDal abstractDal = new SizeDal(sgiHelper.Object);

            List<Size> actualCategories = abstractDal.SelectBySpQuery(spName);

            Assert.AreEqual(sizes.Count, actualCategories.Count);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void SelectBySp_GivenThereIsAParameter_ReturnShouldBeInList()
        {
            List<Size> sizes = new List<Size>
                                            {
                                                new Size{Code ="S3",Name="S",CreatedBy="sang",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,ModifiedBy="sang"},
                                                new Size{Code ="S4",Name="S",CreatedBy="sang",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,ModifiedBy="sang"}
                                            };

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"parameter1",1}
            };

            string spName = "spTest";

            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectSp<Size>(spName, parameters)).Returns(sizes);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            ISizeDal abstractDal = new SizeDal(sgiHelper.Object);

            List<Size> actualCategories = abstractDal.SelectBySpQuery(spName, parameters);

            Assert.AreEqual(sizes.Count, actualCategories.Count);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void SaveOrUpdate()
        {
            var size = new Size { Name = "S", Code = "S3", CreatedBy = "sgisize", CreatedDate = DateTime.Now };

            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SaveOrUpdate<Size>(size));

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);

            ISizeDal abstractDal = new SizeDal(sgiHelper.Object);

            abstractDal.SaveOrUpdate(size);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void Delete()
        {
            var size = new Size { Name = "S", Code = "S3", CreatedBy = "sgisize", CreatedDate = DateTime.Now };

            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.Delete<Size>(size));

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);

            ISizeDal abstractDal = new SizeDal(sgiHelper.Object);

            abstractDal.Delete(size);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }
    }
}
