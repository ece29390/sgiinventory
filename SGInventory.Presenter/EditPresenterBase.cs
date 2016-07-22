using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Helpers;
using SGInventory.Business.Model;
using SGInventory.Views;
using SGInventory.Model;

namespace SGInventory.Presenters
{
    public abstract class EditPresenterBase<T>
    {
        protected T _model;
        protected readonly string _modelName;

        public string SuccessfullMessageInCreateModel
        {
            get { return string.Format(FormsHelper.CREATED_SUCCESSFULL, _modelName); }
        }

        public string SuccessfullMessageInUpdatingModel
        {
            get { return string.Format(FormsHelper.UPDATED_SUCCCESSFULL, _modelName); }
        }
        
        protected EditPresenterBase(string modelName)
        {
            _modelName = modelName;
        }

        public abstract void Save(Action<string,List<T>> callBackAfterSaving);

        public abstract void LoadModels(T model);

        protected void PersistChanges<B>(B businessModel,Action<string, List<T>> callBackAfterSaving) where B:ISave<T>,ISelectAll<T>
        {
            var response = businessModel.Save(_model);

            var isSuccessfull = response == SuccessfullMessageInCreateModel ||
                                response == SuccessfullMessageInUpdatingModel;

            List<T> returnList = null;
            if (isSuccessfull)
            {
                returnList = businessModel.SelectAll();
            }

            callBackAfterSaving(response, returnList);
        }

        protected void LoadEntity<V>(V view) where V : IEditViewLoadData<T>
        {
            if (_model != null)
            {
                view.LoadData(_model);
            }
        }

        protected bool ShouldEnable(string stringValue)
        {
            return stringValue.Trim().Length > 0 ? true : false;
        }

        public abstract bool ShouldEnable();

    }
}
