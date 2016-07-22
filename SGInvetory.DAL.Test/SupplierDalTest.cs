using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SGInventory.Model;
using SGInventory.Helpers;
using SGInventory.Dal;

namespace SGInventory.DAL.Test
{
    [TestClass]
    public class SupplierDalTest
    {
        [TestMethod]
        public void SelectAllTest()
        {
            List<Supplier> suppliers = new List<Supplier>
                                            {
                                                new Supplier{Name="SupplierA",Address="Address of SupplierA",CreatedBy="sgiuser",CreatedDate=DateTime.Now},
                                                new Supplier{Name="SupplierB",Address="Address of SupplierB",CreatedBy="sgiuser",CreatedDate=DateTime.Now},
                                            };

            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectAll<Supplier>()).Returns(suppliers);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            ISupplierDal abstractDal = new SupplierDal(sgiHelper.Object);
            List<Supplier> actualCategories = abstractDal.SelectAll();

            Assert.AreEqual(suppliers.Count,actualCategories.Count);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void SelectByPrimaryKey_GivenPrimaryKey_ReturnShouldNotBeNull()
        {

            var supplier = new Supplier { Name = "SupplierA", Address = "Address of Supplier A", CreatedBy = "sgiuser", CreatedDate = DateTime.Now };
                                          

            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectPrimary<Supplier, int>(1)).Returns(supplier);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            ISupplierDal abstractDal = new SupplierDal(sgiHelper.Object);
            Supplier actualSupplier = abstractDal.SelectPrimaryEntity<int>(1);

            Assert.IsNotNull(actualSupplier);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();

        }

        [TestMethod]
        public void SelectBySp_GivenThereIsNoParameter_ReturnShouldBeInList()
        {
            List<Supplier> suppliers = new List<Supplier>
                                            {
                                                new Supplier{Name="SupplierA",Address="Address of SupplierA",CreatedBy="sgiuser",CreatedDate=DateTime.Now},
                                                new Supplier{Name="SupplierB",Address="Address of SupplierB",CreatedBy="sgiuser",CreatedDate=DateTime.Now},
                                            };


            var spName = "spTest";
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectSp<Supplier>(spName)).Returns(suppliers);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            ISupplierDal abstractDal = new SupplierDal(sgiHelper.Object);

            List<Supplier> actualCategories = abstractDal.SelectBySpQuery(spName);

            Assert.AreEqual(suppliers.Count, actualCategories.Count);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void SelectBySp_GivenThereIsAParameter_ReturnShouldBeInList()
        {
            List<Supplier> suppliers = new List<Supplier>
                                            {
                                                new Supplier{Name="SupplierA",Address="Address of SupplierA",CreatedBy="sgiuser",CreatedDate=DateTime.Now},
                                                new Supplier{Name="SupplierB",Address="Address of SupplierB",CreatedBy="sgiuser",CreatedDate=DateTime.Now},
                                            };


            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"parameter1",1}
            };
            string spName = "spTest";
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectSp<Supplier>(spName,parameters)).Returns(suppliers);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            ISupplierDal abstractDal = new SupplierDal(sgiHelper.Object);

            List<Supplier> actualCategories = abstractDal.SelectBySpQuery(spName,parameters);

            Assert.AreEqual(suppliers.Count, actualCategories.Count);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void SaveOrUpdate()
        {
            var supplier = new Supplier { Name = "SupplierA", Address = "Address of Supplier A", CreatedBy = "sgiuser", CreatedDate = DateTime.Now };

           
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SaveOrUpdate<Supplier>(supplier));

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);

            ISupplierDal abstractDal = new SupplierDal(sgiHelper.Object);

            abstractDal.SaveOrUpdate(supplier);
           
            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void Delete()
        {
            var supplier = new Supplier { Name = "SupplierA", Address = "Address of Supplier A", CreatedBy = "sgiuser", CreatedDate = DateTime.Now };


            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.Delete<Supplier>(supplier));

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);

            ISupplierDal abstractDal = new SupplierDal(sgiHelper.Object);

            abstractDal.Delete(supplier);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        

        
    }
}
