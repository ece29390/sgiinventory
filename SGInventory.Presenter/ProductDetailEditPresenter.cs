using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Views;
using SGInventory.Helpers;
using System.IO;

namespace SGInventory.Presenters
{
    public class ProductDetailEditPresenter : EditPresenterBase<ProductDetails>
    {
        private Views.IProductDetailEditView _productDetailEditView;
        private Business.Model.IProductDetailBusinessModel _productDetailBusinessModel;

        public List<Color> Colors { get; private set; }
        public List<Washing> Washings { get; private set; }
        public List<Size> Sizes { get; private set; }

        public ProductDetailEditPresenter(Views.IProductDetailEditView productDetailEditView
            , Business.Model.IProductDetailBusinessModel productDetailBusinessModel      
            ,ProductDetails model
            )
            :base("Product Detail")
        {
            
            base._model = model;
            _productDetailEditView = productDetailEditView;
            _productDetailBusinessModel = productDetailBusinessModel;

            Colors = new List<Color>();
            Washings = new List<Washing>();
            Sizes = new List<Size>();
        }

        public override void Save(Action<string, List<ProductDetails>> callBackAfterSaving)
        {
            var isNew = false;
            if (string.IsNullOrEmpty(_model.Code))
            {
                isNew = true;
                _model.Code = _productDetailEditView.GetCode();
                _model.CreatedBy = _productDetailEditView.GetUser();
                _model.CreatedDate = DateTime.Now;


            }
            else
            {
                _model.ModifiedDate = DateTime.Now;
                _model.ModifiedBy = _productDetailEditView.GetUser();
            }
         
            _model.Color = _productDetailEditView.GetColor();           
            _model.Size = _productDetailEditView.GetSize();
            _model.Washing = _productDetailEditView.GetWashing();
            var overrideCost = _productDetailEditView.GetOverrideCost();
            if (overrideCost.HasValue)
            {
                _model.OverrideCost = overrideCost.Value;
            }
            var quantityOnHand =_productDetailEditView.GetQuantityOnHand();
            _model.QuantityOnHand = quantityOnHand.HasValue ? quantityOnHand.Value : 0;
            
            var fileName = _productDetailEditView.GetFilePath();
            
            if (!string.IsNullOrEmpty(fileName))
            {
                _model.ImagePathName = _productDetailEditView.GetNewDestinationPath();
            }

            var response = "";

            if (isNew)
            {
               response= _productDetailBusinessModel.Save(_model);
            }
            else
            {
                _productDetailBusinessModel.CreateOrUpdate(_model);
                response = "A Product Detail has been saved";
            }

            if (!string.IsNullOrEmpty(_model.ImagePathName))
            {
                _productDetailEditView.CopyToNewDestinationPath(_model.ImagePathName);
            }

            if (callBackAfterSaving != null)
            {
                callBackAfterSaving(response, _productDetailBusinessModel.SelectByParent(_model.Product));
            }

        }

        public override void LoadModels(ProductDetails model)
        {
            _model = model;
            base.LoadEntity<IProductDetailEditView>(_productDetailEditView);
        }

        public override bool ShouldEnable()
        {
           
            var color = _productDetailEditView.GetColor();
            if (color == null)
            {
                return false;
            }

            var size = _productDetailEditView.GetSize();
            if (size == null)
            {
                return false;
            }

            var washing = _productDetailEditView.GetWashing();
            if (washing == null)
            {
                return false;
            }

            var quantity = _productDetailEditView.GetQuantityOnHand();

            if (!quantity.HasValue)
            {
                return false;
            }

            return true;
        }
        public void LoadSizes(Business.Model.ISizeBusinessModel iSizeBusinessModel)
        {
            Sizes = iSizeBusinessModel.SelectAll();
            _productDetailEditView.LoadSizes(Sizes);
        }

        public void LoadColors(Business.Model.IColorBusinessModel iColorBusinessModel)
        {
            Colors = iColorBusinessModel.SelectAll();
            _productDetailEditView.LoadColors(Colors);
        }

        public void LoadWashings(Business.Model.IWashingBusinessModel iWashingBusinessModel)
        {
            Washings = iWashingBusinessModel.SelectAll();
            _productDetailEditView.LoadWashings(Washings);
        }

        public void LoadSelectedModel<T>(List<T> list, string name, Action<T> loadAction) where T : class,SGInventory.Model.ICode, IName, new()
        {
            var selectedModel = SgiHelper.SelectModelByNameInTheCollection<T>(list, name);
            loadAction(selectedModel);

        }

        public void OpenFileDialog()
        {
            _productDetailEditView.ShowOpenFileDialog();
        }

        public void UploadToPictureBox()
        {
            var filePath = _productDetailEditView.GetFilePath();            
            _productDetailEditView.LoadImageToPictureBox(filePath);
        }
    }
}
