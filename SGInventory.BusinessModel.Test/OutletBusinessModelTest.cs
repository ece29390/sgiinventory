using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SGInventory.Model;
using SGInventory.Helpers;
using SGInventory.Dal;
using SGInventory.Business.Model;
namespace SGInventory.BusinessModel.Test
{
    [TestClass]
    public class OutletBusinessModelTest
    {
        private Mock<IOutletDal> _dalMoq;
        private IOutletBusinessModel _businessModel;
        private readonly Outlet _outlet;

        public OutletBusinessModelTest()
        {
            _dalMoq = new Mock<IOutletDal>(MockBehavior.Strict);
            _businessModel = new OutletBusinessModel(_dalMoq.Object);

            _outlet = new Outlet 
            {
                Name="SM Cebu",
                Address="Cebu City",
                CreatedDate=DateTime.Now,
                CreatedBy="user"
            };
        }

        [TestMethod]
        public void SelectAll_ShouldReturnList_Test()
        {


            _dalMoq.Setup(d => d.SelectAll()).Returns(new List<Outlet> { 
                {new Outlet{Name="SM City",Address="Cebu",CreatedDate=DateTime.Now,CreatedBy="user",Id=1}},
                 {new Outlet{Name="SM North",Address="QC",CreatedDate=DateTime.Now,CreatedBy="user",Id=2}},
                 {new Outlet{Name="SM Mega",Address="Mandaluyong",CreatedDate=DateTime.Now,CreatedBy="user",Id=3}},
            });

            List<Outlet> outlet = _businessModel.SelectAll();

            Assert.AreEqual(3, outlet.Count);

            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void SelectByPrimaryId_GivenTheId_Exists_ShouldReturnOneObjectTest()
        {


            var primaryId = 1;

            _dalMoq.Setup(d => d.SelectPrimaryEntity<int>(primaryId)).Returns(new Outlet { Name = "SM City", Address = "Manila", CreatedDate = DateTime.Now, CreatedBy = "user", Id = 1 });

            Outlet outlet = _businessModel.SelectByPrimaryId(primaryId);

            Assert.IsNotNull(outlet);

            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void SelectByPrimaryId_GivenTheIdNotExists_ShouldReturnEmptyCollectionTest()
        {


            var primaryId = 1;

            var expectedOutlet = new Outlet();

            _dalMoq.Setup(d => d.SelectPrimaryEntity<int>(primaryId)).Returns(expectedOutlet);

            var outlet = _businessModel.SelectByPrimaryId(primaryId);

            Assert.AreEqual<int>(expectedOutlet.Id, outlet.Id);

            _dalMoq.VerifyAll();

        }

        [TestMethod]
        public void Validate_GivenInAddModeAndTheNameAlreadyExists_ShouldReturnFalse()
        {
            var name = "SM City Cebu";
            var address = "Cebu";
            var dateNow = DateTime.Now;
            var user = "user";


            _dalMoq.Setup(s => s.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(new List<Outlet> { 
                {new Outlet{Name="SM City Cebu",Address="San Lazaro",CreatedDate=DateTime.Now,CreatedBy="user",Id=1}}                                 
            });

            var inputOutlet = new Outlet
            {
                Id = 0,
                Name = name,
                Address = address,
                CreatedBy = user,
                CreatedDate = dateNow,
                ModifiedBy = user,
                ModifiedDate = dateNow
            };

            var isValid = _businessModel.Valid(inputOutlet);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Validate_GivenInEditModeTheNameAlreadyExistsFromDifferentId_ShouldReturnFalse()
        {

            var name = "SM City Cebu";
            var address = "Cebu";
            var dateNow = DateTime.Now;
            var user = "user";

            var dictionary = new Dictionary<string, object>{
                        {"name",name}
            
            };

            _dalMoq.Setup(s => s.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(new List<Outlet> { 
                {new Outlet{Name="SM City Cebu",Address="San Lazaro",CreatedDate=DateTime.Now,CreatedBy="user",Id=2}}                                 
            });

            var inputOutlet = new Outlet
            {
                Id = 1,
                Name = name,
                Address = address,
                CreatedBy = user,
                CreatedDate = dateNow,
                ModifiedBy = user,
                ModifiedDate = dateNow
            };

            var isExists = _businessModel.Valid(inputOutlet);

            Assert.IsFalse(isExists);
        }

        [TestMethod]
        public void Validate_GivenInEditModeTheNameAlreadyExistsFromSameId_ShouldReturnTrue()
        {

            var name = "SM City Cebu";
            var address = "Cebu Edit";
            var dateNow = DateTime.Now;
            var user = "user";

            var dictionary = new Dictionary<string, object>{
                        {"name",name}
            
            };

            _dalMoq.Setup(s => s.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(new List<Outlet> { 
                {new Outlet{Name=name,Address="SM City",CreatedDate=DateTime.Now,CreatedBy="user",Id=1}}                                 
            });

            var inputOutlet = new Outlet
            {
                Id = 1,
                Name = name,
                Address = address,
                CreatedBy = user,
                CreatedDate = dateNow,
                ModifiedBy = user,
                ModifiedDate = dateNow
            };

            var isExists = _businessModel.Valid(inputOutlet);

            Assert.IsTrue(isExists);
        }

        [TestMethod]
        public void Validate_GivenInNewModeTheNameNotExists_ShouldReturnTrue()
        {

            var name = "SM City Cebu";
            var address = "Cebu";
            var dateNow = DateTime.Now;
            var user = "user";

            _dalMoq.Setup(s => s.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(new List<Outlet>());

            var inputOutlet = new Outlet
            {
                Id = 0,
                Name = name,
                Address = address,
                CreatedBy = user,
                CreatedDate = dateNow,
                ModifiedBy = user,
                ModifiedDate = dateNow
            };

            var isExists = _businessModel.Valid(inputOutlet);

            Assert.IsTrue(isExists);
        }

        [TestMethod]
        public void Delete_Test()
        {
            var name = "SM City";

            var inputOutlet = new Outlet { Name = name };

            _dalMoq.Setup(s => s.Delete(inputOutlet));

            _businessModel.Delete(inputOutlet);

            _dalMoq.VerifyAll();


        }
       
        [TestMethod]
        public void SaveModel_GivenModelIsNewValidFieldsNameNotExistsQueryHasNoResult_ResultSuccessfull()
        {
            _outlet.Name = "SM Makati";

            _dalMoq.Setup(o => o.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(new List<Outlet>());
            _dalMoq.Setup(o => o.SaveOrUpdate(It.IsAny<Outlet>()));


            string response = _businessModel.Save(_outlet);

            Assert.AreEqual<string>("A new Outlet has been added", response);

            _dalMoq.VerifyAll();
        }

        [TestMethod]
        public void SaveModel_GivenModelIsNewValidFieldsNameAlreadyExistsQueryHasResult_ResultUnsuccessfull()
        {
            _outlet.Name = "SM Makati";

            var mockResultList = new List<Outlet>();
            mockResultList.Add(new Outlet { Id = 1, Name = "SM Makati" });

            _dalMoq.Setup(o => o.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(mockResultList);
            
            string response = _businessModel.Save(_outlet);

            Assert.AreEqual<string>("SM Makati already exists", response);

            _dalMoq.VerifyAll();
        }

        [TestMethod]
        public void SaveModel_GivenModelExistsValidFieldsNameAlreadyExistsQueryHasResult_ResultSuccessfull()
        {
            _outlet.Name = "SM Makati";
            _outlet.Id = 1;

            var mockResultList = new List<Outlet>();
            mockResultList.Add(new Outlet { Id = 1, Name = "SM Makati" });

            _dalMoq.Setup(o => o.SelectBySpQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(mockResultList);
            _dalMoq.Setup(o => o.SaveOrUpdate(It.IsAny<Outlet>()));

            string response = _businessModel.Save(_outlet);

            Assert.AreEqual<string>("Outlet has been updated", response);

            _dalMoq.VerifyAll();
        }
    }
}
