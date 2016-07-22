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
    public class CategoryDalTest
    {
        [TestMethod]
        public void SelectAllTest()
        {
            List<Category> categories = new List<Category>
                                            {
                                                new Category{Name="Tops",Description="All types of upper garment",CreatedBy="sgiuser",CreatedDate=DateTime.Now},
                                                new Category{Name="Bottom",Description="All types of lower garment",CreatedBy="sgiuser",CreatedDate=DateTime.Now}
                                            };

            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectAll<Category>()).Returns(categories);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            ICategoryDal abstractDal = new CategoryDal(sgiHelper.Object);
            List<Category> actualCategories = abstractDal.SelectAll();

            Assert.AreEqual(categories.Count,actualCategories.Count);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void SelectByPrimaryKey_GivenPrimaryKey_ReturnShouldNotBeNull()
        {

            var category = new Category { Name = "Tops", Description = "All types of upper garment", CreatedBy = "sgiuser", CreatedDate = DateTime.Now };
                                          

            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectPrimary<Category, int>(1)).Returns(category);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            ICategoryDal abstractDal = new CategoryDal(sgiHelper.Object);
            Category actualCategory = abstractDal.SelectPrimaryEntity<int>(1);

            Assert.IsNotNull(actualCategory);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();

        }

        [TestMethod]
        public void SelectBySp_GivenThereIsNoParameter_ReturnShouldBeInList()
        {
            List<Category> categories = new List<Category>
                                            {
                                                new Category{Name="Tops",Description="All types of upper garment",CreatedBy="sgiuser",CreatedDate=DateTime.Now},
                                                new Category{Name="Bottom",Description="All types of lower garment",CreatedBy="sgiuser",CreatedDate=DateTime.Now}
                                            };

            string spName = "spTest";
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectSp<Category>(spName)).Returns(categories);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            ICategoryDal abstractDal = new CategoryDal(sgiHelper.Object);

            List<Category> actualCategories = abstractDal.SelectBySpQuery(spName);

            Assert.AreEqual(categories.Count, actualCategories.Count);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void SelectBySp_GivenThereIsAParameter_ReturnShouldBeInList()
        {
            List<Category> categories = new List<Category>
                                            {
                                                new Category{Name="Tops",Description="All types of upper garment",CreatedBy="sgiuser",CreatedDate=DateTime.Now},
                                                new Category{Name="Bottom",Description="All types of lower garment",CreatedBy="sgiuser",CreatedDate=DateTime.Now}
                                            };

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"parameter1",1}
            };

            string spName = "spTest";

            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SelectSp<Category>(spName,parameters)).Returns(categories);

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);


            ICategoryDal abstractDal = new CategoryDal(sgiHelper.Object);

            List<Category> actualCategories = abstractDal.SelectBySpQuery(spName,parameters);

            Assert.AreEqual(categories.Count, actualCategories.Count);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void SaveOrUpdate()
        {
            var category = new Category { Name = "Tops", Description = "All types of upper garment", CreatedBy = "sgiuser", CreatedDate = DateTime.Now };

           
            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.SaveOrUpdate<Category>(category));

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);

            ICategoryDal abstractDal = new CategoryDal(sgiHelper.Object);

            abstractDal.SaveOrUpdate(category);
           
            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        [TestMethod]
        public void Delete()
        {
            var category = new Category { Name = "Tops", Description = "All types of upper garment", CreatedBy = "sgiuser", CreatedDate = DateTime.Now };


            var dataHelper = new Mock<IDataHelper>(MockBehavior.Strict);
            dataHelper.Setup(h => h.Delete<Category>(category));

            Mock<ISgiHelper> sgiHelper = new Mock<ISgiHelper>(MockBehavior.Strict);
            sgiHelper.SetupGet<IDataHelper>(s => s.DataHelper).Returns(dataHelper.Object);

            ICategoryDal abstractDal = new CategoryDal(sgiHelper.Object);

            abstractDal.Delete(category);

            dataHelper.VerifyAll();
            sgiHelper.VerifyAll();


        }

        

        
    }
}
