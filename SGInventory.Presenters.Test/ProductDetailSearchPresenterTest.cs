using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGInventory.Presenters;
using Moq;
using SGInventory.Views;
using SGInventory.Business.Model;
using SGInventory.Test.Data;
using SGInventory.Model;
using System.Windows.Forms;
namespace SGInventory.Presenters.Test
{
    [TestClass]
    public class ProductDetailSearchPresenterTest
    {
        private ProductDetailSearchPresenter _searchPresenter;
        private Mock<IProductDetailSearchView> _searchView;
        private Mock<IProductDetailBusinessModel> _businessModel;
        private List<ProductDetails> _productDetails;
        
        public ProductDetailSearchPresenterTest()
        {
            _searchView = new Mock<IProductDetailSearchView>(MockBehavior.Strict);
            _businessModel = new Mock<IProductDetailBusinessModel>(MockBehavior.Strict);
            var product = new ProductTestData().GetEntity();
            _productDetails = new ProductDetailTestData().GetEntities();
            _searchPresenter = new ProductDetailSearchPresenter(_searchView.Object, _businessModel.Object, product);
        }

        [TestMethod]
        public void LoadAllModels_Test()
        {          
            _searchView.Setup(s => s.LoadModel(It.IsAny<List<ProductDetails>>()));

            _searchPresenter.LoadModels();

            _businessModel.VerifyAll();
            _searchView.VerifyAll();
        }

        [TestMethod]
        public void AddModel_Test()
        {
            _searchView.Setup(v => v.OpenEditForm());

            _searchPresenter.OpenEditForm();

            _searchView.VerifyAll();
        }

        [TestMethod]
        public void PopulateModelToEditForm_Test()
        {          
            _searchView.Setup(v => v.ConvertToModel(It.IsAny<object>())).Returns(_productDetails[0]);
            _searchView.Setup(v => v.OpenEditForm(It.IsAny<ProductDetails>()));
            _searchPresenter.PopulateModelToEditForm("colCode", _productDetails[0]);

            _searchView.VerifyAll();

        }

        [TestMethod]
        public void DeleteSelectedModels_GivenTheUserSayNo_Test()
        {
            _searchView.Setup(v => v.GetSelectedModels()).Returns(_productDetails);
            _searchView.Setup(v => v.ConfirmationPopUpYesNo(It.IsAny<string>())).Returns(DialogResult.No);
            _searchPresenter.DeleteSelectedModels();
            _searchView.VerifyAll();
            _businessModel.VerifyAll();
        }

        [TestMethod]
        public void DeleteSelectedModels_GivenTheUserSayYes_Test()
        {
            
            _searchView.Setup(v => v.GetSelectedModels()).Returns(_productDetails);
            _searchView.Setup(v => v.ConfirmationPopUpYesNo(It.IsAny<string>())).Returns(DialogResult.Yes);
            _businessModel.Setup(b => b.Delete(It.IsAny<ProductDetails>()));
            _searchView.Setup(v => v.DeletedPopUpMessage(It.IsAny<string>()));
            _businessModel.Setup(b => b.SelectByParent(It.IsAny<Product>())).Returns(new List<ProductDetails>());
            _searchView.Setup(v => v.LoadModel(It.IsAny<List<ProductDetails>>()));

            _searchPresenter.DeleteSelectedModels();

            _searchView.VerifyAll();
            _businessModel.Verify(b => b.Delete(It.IsAny<ProductDetails>()), Times.Exactly(_productDetails.Count));


        }

        [TestMethod]
        public void DeleteSelectedModels_GivenNoModelIsSelected_Test()
        {
            var productDetails = new List<ProductDetails>();

            _searchView.Setup(v => v.GetSelectedModels()).Returns(productDetails);

            _searchPresenter.DeleteSelectedModels();

            _searchView.VerifyAll();

        }
    }
}
