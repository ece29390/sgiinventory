using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SGInventory.Presenters;
using SGInventory.Views;
using SGInventory.Business.Model;
using SGInventory.Model;
using SGInventory.Test.Data;
using System.Windows.Forms;

namespace SGInventory.Presenters.Test
{
    [TestClass]
    public class ProductSearchPresenterTest
    {
       private ProductSearchPresenter _productSearchPresenter;
        private Mock<IProductSearchView> _productSearchView;
        private Mock<IProductBusinessModel> _productBusinessModel;

        private readonly List<Product> _models;
        private readonly Product _model;

        public ProductSearchPresenterTest()
        {
            _productSearchView = new Mock<IProductSearchView>(MockBehavior.Strict);
            _productBusinessModel = new Mock<IProductBusinessModel>(MockBehavior.Strict);

            _productSearchPresenter = new ProductSearchPresenter(_productSearchView.Object, _productBusinessModel.Object);

            var productTestData = new ProductTestData();
            _models = productTestData.GetEntities();
            _model = productTestData.GetEntity();
        }

        [TestMethod]
        public void LoadAllModels_Test()
        {
            _productBusinessModel.Setup(b => b.SelectAll()).Returns(_models);
            _productSearchView.Setup(s => s.LoadModel(It.IsAny<List<Product>>()));

            _productSearchPresenter.LoadModels();

            _productBusinessModel.VerifyAll();
            _productSearchView.VerifyAll();
        }

        [TestMethod]
        public void AddModel_Test()
        {
            _productSearchView.Setup(v => v.OpenEditForm());

            _productSearchPresenter.OpenEditForm();

            _productSearchView.VerifyAll();
        }

        [TestMethod]
        public void PopulateModelToEditForm_Test()
        {
        
            _productSearchView.Setup(v => v.ConvertToModel(It.IsAny<object>())).Returns(_model);
            _productSearchView.Setup(v => v.OpenEditForm(It.IsAny<Product>()));

            _productSearchPresenter.PopulateModelToEditForm("colStockNumber", null);

            _productSearchView.VerifyAll();

        }

        [TestMethod]
        public void DeleteSelectedModels_GivenTheUserSayYes_Test()
        {
            
            _productSearchView.Setup(v => v.GetSelectedModels()).Returns(_models);
            _productSearchView.Setup(v => v.ConfirmationPopUpYesNo(It.IsAny<string>())).Returns(DialogResult.Yes);
            _productBusinessModel.Setup(b => b.Delete(It.IsAny<Product>()));
            _productSearchView.Setup(v => v.DeletedPopUpMessage(It.IsAny<string>()));
            _productBusinessModel.Setup(b => b.SelectAll()).Returns(new List<Product>());
            _productSearchView.Setup(v => v.LoadModel(It.IsAny<List<Product>>()));

            _productSearchPresenter.DeleteSelectedModels();

            _productSearchView.VerifyAll();
            _productBusinessModel.Verify(b => b.Delete(It.IsAny<Product>()), Times.Exactly(_models.Count));


        }

        [TestMethod]
        public void DeleteSelectedModels_GivenNoModelIsSelected_Test()
        {
            var models = new List<Product>();

            _productSearchView.Setup(v => v.GetSelectedModels()).Returns(models);

            _productSearchPresenter.DeleteSelectedModels();

            _productSearchView.VerifyAll();



        }

        [TestMethod]
        public void DeleteSelectedModels_GivenTheUserSayNo_Test()
        {
            

            _productSearchView.Setup(v => v.GetSelectedModels()).Returns(_models);
            _productSearchView.Setup(v => v.ConfirmationPopUpYesNo(It.IsAny<string>())).Returns(DialogResult.No);


            _productSearchPresenter.DeleteSelectedModels();

            _productSearchView.VerifyAll();
            _productBusinessModel.VerifyAll();


        }
    }
}
