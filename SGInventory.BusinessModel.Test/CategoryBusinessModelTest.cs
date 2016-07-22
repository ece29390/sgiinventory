using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SGInventory.Dal;
using SGInventory.Model;
using SGInventory.Helpers;
namespace SGInventory.Business.Model
{
    [TestClass]
    public class CategoryBusinessModelTest
    {
        private readonly ICategoryBusinessModel _businessModel;
        private readonly Mock<ICategoryDal> _dalMoq;
        public CategoryBusinessModelTest()
        {         
            _dalMoq = new Mock<ICategoryDal>(MockBehavior.Strict);
            _businessModel = new CategoryBusinessModel(_dalMoq.Object);
        }


        [TestMethod]
        public void SelectAll_ShouldReturnList_Test()
        {


            _dalMoq.Setup(d => d.SelectAll()).Returns(new List<Category> { 
                {new Category{Name="Tops",Description="Upper Garments",CreatedDate=DateTime.Now,CreatedBy="user",Id=1}},
                 {new Category{Name="Bottoms",Description="Lower Garments",CreatedDate=DateTime.Now,CreatedBy="user",Id=2}},
                 {new Category{Name="Jersey",Description="Atheletic shirts",CreatedDate=DateTime.Now,CreatedBy="user",Id=3}},
            });

            List<Category> categories = _businessModel.SelectAll();

            Assert.AreEqual(3, categories.Count);

            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void SelectByPrimaryId_GivenTheId_Exists_ShouldReturnOneObjectTest()
        {
           

            var primaryId = 1;

            _dalMoq.Setup(d => d.SelectPrimaryEntity<int>(primaryId)).Returns(new Category { Name = "Tops", Description = "Upper Garments", CreatedDate = DateTime.Now, CreatedBy = "user", Id = 1 });

            Category category = _businessModel.SelectByPrimaryId(primaryId);

            Assert.IsNotNull(category);

            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void SelectByPrimaryIdCategory__GivenTheIdNotExists_ShouldReturnEmptyCollectionTest()
        {
           

            var primaryId = 1;

            Category expectedCategory = new Category();

            _dalMoq.Setup(d => d.SelectPrimaryEntity<int>(primaryId)).Returns(expectedCategory);

            Category category = _businessModel.SelectByPrimaryId(primaryId);

            Assert.AreEqual<int>(expectedCategory.Id, category.Id);

            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void Validate_GivenTheNameAlreadyExistsCategoryIsNewAndMaxLengthNotExceedsTheLimit_ShouldReturnFalse()
        {
            var name = "Tops";
            var description = "Upper Garment";
            var dateNow = DateTime.Now;
            var user = "user";


            _dalMoq.Setup(s => s.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(new List<Category> { 
                {new Category{Name="Tops",Description="Upper Garments",CreatedDate=DateTime.Now,CreatedBy="user",Id=1}}                                 
            });

            var inputCategory = new Category
            {
                Id = 0,
                Name = name,
                Description = description,
                CreatedBy = user,
                CreatedDate = dateNow,
                ModifiedBy = user,
                ModifiedDate = dateNow
            };

            var isValid = _businessModel.Valid(inputCategory);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Validate_GivenTheNameAlreadyExistsFromDifferentIdCategoryAlreadyExistsAndMaxLengthNotExceedsTheLimit_ShouldReturnFalse()
        {

            var name = "Tops";
            var description = "Upper Garment";
            var dateNow = DateTime.Now;
            var user = "user";

            var dictionary = new Dictionary<string, object>{
                        {"name",name}
            
            };

            _dalMoq.Setup(s => s.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(new List<Category> { 
                {new Category{Name="Tops",Description="Upper Garments",CreatedDate=DateTime.Now,CreatedBy="user",Id=2}}                                 
            });

            var inputCategory = new Category
            {
                Id = 1,
                Name = name,
                Description = description,
                CreatedBy = user,
                CreatedDate = dateNow,
                ModifiedBy = user,
                ModifiedDate = dateNow
            };

            var isExists = _businessModel.Valid(inputCategory);

            Assert.IsFalse(isExists);
        }

        [TestMethod]
        public void Validate_GivenTheNameAlreadyExistsFromSameIdCategoryAlreadyExistsAndMaxLengthNotExceedsTheLimit_ShouldReturnTrue()
        {

            var name = "Tops";
            var description = "Upper Garment";
            var dateNow = DateTime.Now;
            var user = "user";

            var dictionary = new Dictionary<string, object>{
                        {"name",name}
            
            };

            _dalMoq.Setup(s => s.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(new List<Category> { 
                {new Category{Name="Tops",Description="Upper Garments",CreatedDate=DateTime.Now,CreatedBy="user",Id=1}}                                 
            });

            var inputCategory = new Category
            {
                Id = 1,
                Name = name,
                Description = description,
                CreatedBy = user,
                CreatedDate = dateNow,
                ModifiedBy = user,
                ModifiedDate = dateNow
            };

            var isExists = _businessModel.Valid(inputCategory);

            Assert.IsTrue(isExists);
        }

        [TestMethod]
        public void Validate_GivenTheNameNotExistsCategoryIsNewAndMaxLengthNotExceedsTheLimit_ShouldReturnTrue()
        {

            var name = "Tops";
            var description = "Upper Garment";
            var dateNow = DateTime.Now;
            var user = "user";
           
            _dalMoq.Setup(s => s.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string,object>>())).Returns(new List<Category>());

            var inputCategory = new Category
            {
                Id = 0,
                Name = name,
                Description = description,
                CreatedBy = user,
                CreatedDate = dateNow,
                ModifiedBy = user,
                ModifiedDate = dateNow
            };

            var isExists = _businessModel.Valid(inputCategory);

            Assert.IsTrue(isExists);
        }
       
        [TestMethod]
        public void Delete_Test()
        {           
            var name = "Tops";

            var inputCategory = new Category { Name = name };

            _dalMoq.Setup(s => s.Delete(inputCategory));

            _businessModel.Delete(inputCategory);

            _dalMoq.VerifyAll();
           
           
        }
   
        [TestMethod]
        public void SaveCategory_GivenTheNameNotExistsCreateNew_ResultSuccessfull()
        {
            var category = new Category { Name = "Tops", Description = "Upper Garment", CreatedDate = DateTime.Now, CreatedBy = "user" };
                                  
            var mockResult = new List<Category>();
            _dalMoq.Setup(s => s.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(mockResult);
            _dalMoq.Setup(s => s.SaveOrUpdate(category));

            var actualResult = _businessModel.Save(category);

            Assert.AreEqual<string>("A new Category has been added", actualResult);

            _dalMoq.VerifyAll();
            
        }

        [TestMethod]
        public void SaveCategory_GivenTheNameAlreadyExistsCreateNew_ResultNotSuccessfull()
        {
            var category = new Category {Id=0, Name = "Tops", Description = "Upper Garment", CreatedDate = DateTime.Now, CreatedBy = "user" };
         
            var mockResult = new List<Category>();
            mockResult.Add(new Category {Id=1, Name = "Tops", Description = "Upper Garment", CreatedDate = DateTime.Now, CreatedBy = "user" });
            _dalMoq.Setup(s => s.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(mockResult);
           

            var actualResult = _businessModel.Save(category);

            Assert.AreEqual<string>("Category already exists", actualResult);

            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void SaveCategory_GivenTheNameAlreadyExistsFromTheDifferentIdUpdateExisting_ResultNotSuccessfull()
        {
            var category = new Category {Id=1, Name = "Tops", Description = "Upper Garment", CreatedDate = DateTime.Now, CreatedBy = "user" };
            
            var mockResult = new List<Category>();
            mockResult.Add(new Category { Id = 2, Name = "Tops", Description = "Upper Garment", CreatedDate = DateTime.Now, CreatedBy = "user" });
            _dalMoq.Setup(s => s.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string,object>>())).Returns(mockResult);


            var actualResult = _businessModel.Save(category);

            Assert.AreEqual<string>("Category already exists", actualResult);

            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void SaveCategory_GivenTheNameNotExistsUpdate_ResultSuccessfull()
        {
            var category = new Category {Id=1, Name = "Tops", Description = "Upper Garment", CreatedDate = DateTime.Now, CreatedBy = "user" };           
            var mockResult = new List<Category>();
            _dalMoq.Setup(s => s.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(mockResult);
            _dalMoq.Setup(s => s.SaveOrUpdate(It.IsAny<Category>()));

            var actualResult = _businessModel.Save(category);

            Assert.AreEqual<string>("Category has been updated", actualResult);

            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void SaveCategory_GivenTheNameExistsOnSameIdUpdate_ResultSuccessfull()
        {
            var category = new Category { Id = 1, Name = "Tops", Description = "Upper Garment", CreatedDate = DateTime.Now, CreatedBy = "user" };
            var mockResult = new List<Category>();
            mockResult.Add(category);
            _dalMoq.Setup(s => s.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(mockResult);
            _dalMoq.Setup(s => s.SaveOrUpdate(It.IsAny<Category>()));

            var actualResult = _businessModel.Save(category);

            Assert.AreEqual<string>("Category has been updated", actualResult);

            _dalMoq.VerifyAll();

        }

       
    }
}