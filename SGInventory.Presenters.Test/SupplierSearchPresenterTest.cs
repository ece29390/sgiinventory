using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGInventory.Presenters;
using Moq;
using SGInventory.Views;
using SGInventory.Business.Model;
using SGInventory.Model;
using System.Windows.Forms;

namespace SGInventory.Presenters.Test
{
    [TestClass]
    public class SupplierSearchPresenterTest
    {
        private SupplierSearchPresenter _supplierSearchPresenter;
        private Mock<ISupplierSearchView> _supplierSearchView;
        private Mock<ISupplierBusinessModel> _supplierBusinessModel;
        private List<Supplier> _suppliers;
        private Supplier _supplier;
        public SupplierSearchPresenterTest()
        {
            _supplierSearchView = new Mock<ISupplierSearchView>(MockBehavior.Strict);
            _supplierBusinessModel = new Mock<ISupplierBusinessModel>(MockBehavior.Strict);
            _supplierSearchPresenter = new SupplierSearchPresenter(_supplierSearchView.Object, _supplierBusinessModel.Object);

            _suppliers = new List<Supplier>
            {
                new Supplier
                {
                    Id=1,
                    Name="SupplierX",
                    Address="QC",
                    CreatedDate=DateTime.Now,
                    CreatedBy="user",
                    ModifiedDate=DateTime.Now,
                    ModifiedBy="user"
                },
                   new Supplier
                {
                    Id=2,
                    Name="SupplierY",
                    Address="Ermita Manila",
                    CreatedDate=DateTime.Now,
                    CreatedBy="user",
                    ModifiedDate=DateTime.Now,
                    ModifiedBy="user"
                }
            };

            _supplier = new Supplier
            {
                Id = 2,
                Name = "SupplierZ",
                Address = "Tayuman, San Lazaro",
                CreatedDate = DateTime.Now,
                CreatedBy = "user",
                ModifiedDate = DateTime.Now,
                ModifiedBy = "user"
            };
        }

        [TestMethod]
        public void LoadAll_GivenAllAreSelected_Test()
        {
            
            _supplierBusinessModel.Setup(b => b.SelectAll()).Returns(_suppliers);
            _supplierSearchView.Setup(s => s.LoadModel(It.IsAny<List<Supplier>>()));

            _supplierSearchPresenter.LoadModels();

            _supplierBusinessModel.VerifyAll();
            _supplierSearchView.VerifyAll();
        }

        [TestMethod]
        public void AddModel_Test()
        {
            _supplierSearchView.Setup(v => v.OpenEditForm());

            _supplierSearchPresenter.OpenEditForm();

            _supplierSearchView.VerifyAll();
        }

        [TestMethod]
        public void PopulateModelToEditForm_Test()
        {
            

            _supplierSearchView.Setup(v => v.ConvertToModel(It.IsAny<object>())).Returns(_supplier);
            _supplierSearchView.Setup(v => v.OpenEditForm(It.IsAny<Supplier>()));

            _supplierSearchPresenter.PopulateModelToEditForm("colName", null);

            _supplierSearchView.VerifyAll();

        }

        [TestMethod]
        public void DeleteSelectedModels_GivenTheUserSayYes_Test()
        {
            
            _supplierSearchView.Setup(v => v.GetSelectedModels()).Returns(_suppliers);
            _supplierSearchView.Setup(v => v.ConfirmationPopUpYesNo(It.IsAny<string>())).Returns(DialogResult.Yes);
            _supplierBusinessModel.Setup(b => b.Delete(It.IsAny<Supplier>()));
            _supplierSearchView.Setup(v => v.DeletedPopUpMessage(It.IsAny<string>()));
            _supplierBusinessModel.Setup(b => b.SelectAll()).Returns(new List<Supplier>());
            _supplierSearchView.Setup(v => v.LoadModel(It.IsAny<List<Supplier>>()));

            _supplierSearchPresenter.DeleteSelectedModels();

            _supplierSearchView.VerifyAll();
            _supplierBusinessModel.Verify(b => b.Delete(It.IsAny<Supplier>()), Times.Exactly(_suppliers.Count));


        }

        [TestMethod]
        public void DeleteSelectedModels_GivenNothingIsSelected_Test()
        {
            var _supplier = new List<Supplier>();

            _supplierSearchView.Setup(v => v.GetSelectedModels()).Returns(_supplier);

            _supplierSearchPresenter.DeleteSelectedModels();

            _supplierSearchView.VerifyAll();



        }

        [TestMethod]
        public void DeleteSelectedModels_GivenTheUserSayNo_Test()
        {
            
            _supplierSearchView.Setup(v => v.GetSelectedModels()).Returns(_suppliers);
            _supplierSearchView.Setup(v => v.ConfirmationPopUpYesNo(It.IsAny<string>())).Returns(DialogResult.No);


            _supplierSearchPresenter.DeleteSelectedModels();

            _supplierSearchView.VerifyAll();
            _supplierBusinessModel.VerifyAll();


        }
    }
}
