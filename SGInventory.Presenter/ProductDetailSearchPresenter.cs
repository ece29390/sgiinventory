using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Views;
using SGInventory.Business.Model;
using SGInventory.Model;
using System.Windows.Forms;
using SGInventory.Helpers;

namespace SGInventory.Presenters
{
    public class ProductDetailSearchPresenter : ISearchPresenter
    {
        private Views.IProductDetailSearchView _productDetailSearchView;
        private Business.Model.IProductDetailBusinessModel _productDetailBusinessModel;
        private SGInventory.Model.Product _product;
      
        public ProductDetailSearchPresenter(
            IProductDetailSearchView productDetailSearchView
            , IProductDetailBusinessModel productDetailBusinessModel
            , Product product
            )
            
        {
            
            this._productDetailSearchView = productDetailSearchView;
            this._productDetailBusinessModel = productDetailBusinessModel;
            this._product = product;
        }

        public void LoadModels()
        {                      
            _productDetailSearchView.LoadModel(_product.ProductDetails);
        }

        public void OpenEditForm()
        {
            _productDetailSearchView.OpenEditForm();
        }

        public void PopulateModelToEditForm(string columnName, object dataBoundItem)
        {
            var selectedModel = _productDetailSearchView.ConvertToModel(dataBoundItem);
            selectedModel.Product =_product;
            _productDetailSearchView.OpenEditForm(selectedModel);
        }

        public void DeleteSelectedModels()
        {
            var models = _productDetailSearchView.GetSelectedModels();

            if (models.Count == 0)
                return;

            DialogResult result = _productDetailSearchView.ConfirmationPopUpYesNo(FormsHelper.CONFIRMATION_DELETE_MODEL);

            if (result == DialogResult.Yes)
            {
                models.ForEach((model) => _productDetailBusinessModel.Delete(model));
                _productDetailSearchView.DeletedPopUpMessage(FormsHelper.SUCCESSFULL_DELETED_ITEMS);
                _productDetailSearchView.LoadModel(_productDetailBusinessModel.SelectByParent(_product));
            }
        }
    }
}
