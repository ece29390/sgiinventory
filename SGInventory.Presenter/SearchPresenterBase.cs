using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Business.Model;
using SGInventory.Views;
using System.Windows.Forms;
using SGInventory.Helpers;
namespace SGInventory.Presenters
{
    public class SearchPresenterBase<M, B, P> : ISearchPresenter
        where B : ISelectAll<M>, ISelectByPrimary<M, P>, IValidate<M>, IBusinessTransact<M>, ISave<M>
    {
        protected IModelSearchView<M> _view;
        protected B _businessModel;

        protected SearchPresenterBase(IModelSearchView<M> view, B businessModel)
        {
            _view = view;
            _businessModel = businessModel;
        }

        public virtual void LoadModels()
        {
            var models = this._businessModel.SelectAll();

            _view.LoadModel(models);

        }

        public virtual void OpenEditForm()
        {
            
            _view.OpenEditForm();
        }

        public virtual void PopulateModelToEditForm(string columnName, object dataBoundItem)
        {           
            M selectedModel = _view.ConvertToModel(dataBoundItem);
            _view.OpenEditForm(selectedModel);            
        }


        public virtual void DeleteSelectedModels()
        {
            List<M> models = _view.GetSelectedModels();

            if (models.Count == 0)
                return;

            DialogResult result = _view.ConfirmationPopUpYesNo(FormsHelper.CONFIRMATION_DELETE_MODEL);

            if (result == DialogResult.Yes)
            {
                models.ForEach((model) => _businessModel.Delete(model));
                _view.DeletedPopUpMessage(FormsHelper.SUCCESSFULL_DELETED_ITEMS);
                _view.LoadModel(_businessModel.SelectAll());
            }
        }
    }
}
