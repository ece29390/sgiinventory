using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Business.Model;
using SGInventory.Helpers;
using SGInventory.Views;
using SGInventory.Extensions;
namespace SGInventory.Presenters
{
    public class ProductEditPresenter:EditPresenterBase<Product>
    {
        private IProductEditView _view;
        private Business.Model.IProductBusinessModel _businessModel;
        private Washing _firstWashing;
        public ProductEditPresenter(Views.IProductEditView iProductEditView
            , IProductBusinessModel iProductBusinessModel

            ,Product model=null
            ):base("Product")
        {
            
            this._view = iProductEditView;
            this._businessModel = iProductBusinessModel;
            base._model = model;            
        }

                
        public override void Save(Action<string, List<Product>> callBackAfterSaving)
        {
            var description = _view.GetDescription();
           
            var color = _view.SelectedColor;          
            var washing = _view.SelectedWashing;

            
     
            var category = _view.GetGategory();
            var user = _view.GetUser();
            var response =string.Empty;
            Product dbModel = null;
            if (_model == null)
            {
                var newModel = new Product
                {
                    StockNumber = _view.GetCode(),
                    Description = description,
                    Category = category,
                    CreatedBy = user,
                    CreatedDate = DateTime.Now
                };
             
                dbModel = _businessModel.SelectByPrimaryId(newModel.StockNumber);
                                     
                _model = newModel;

                if (dbModel != null && dbModel.ProductDetails != null && dbModel.ProductDetails.Count > 0)
                {
                    _firstWashing = dbModel.ProductDetails.First().Washing;
                }

                if (
                _firstWashing != null &&
                !_firstWashing.Code.Equals(washing.Code, StringComparison.InvariantCultureIgnoreCase))
                {
                    _view.ShowMessage("Only one washing is allowed per stock number");
                    return;
                }
            }
            else
            {
                _model.Description = description;
                _model.Category = category;
                _model.ModifiedBy = user;
                _model.ModifiedDate = DateTime.Now;
                
            }
            _model.Cost = _view.GetCost();
            _model.MarkdownPrice = _view.GetMarkdownPrice();
            _model.RegularPrice = _view.GetRegularPrice();

            if (color != null && washing != null)
            {
                _model.ProductDetails = _view.AttachProductDetails(_model, color, washing);
            }
            
            string message = _businessModel.SaveUsingTransaction(base._modelName, _model, dbModel, color, washing); //_businessModel.SaveUsingTransaction(_model);

            if (callBackAfterSaving != null)
            {
                callBackAfterSaving(message, _businessModel.SelectAll());
            }

            _firstWashing = _view.SelectedWashing;
            
            _model = null;
        }


        

        public override void LoadModels(Product model)
        {
            _model = model;
            LoadEntity<IProductEditView>(_view);
        }

        public override bool ShouldEnable()
        {
            return !string.IsNullOrEmpty(_view.GetCode());
        }

        public void LoadAllReferenceModels()
        {                        
            _view.LoadAllCategories();
            _view.LoadAllColors();
            _view.LoadAllWashing();
            _view.LoadAllSizes();
        }

        public void LoadPriceHistory()
        {
            var productHistoryDetails = new List<ProductPricesHistory>();

            if (_model != null)
            {
                productHistoryDetails = _businessModel.GetProductHistoryByStockNumber(_model.StockNumber);
            }

            _view.LoadProductHistory(productHistoryDetails);
        }
    }
}
