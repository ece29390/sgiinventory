using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Helpers;
using SGInventory.Business.Model;

namespace SGInventory.Presenters
{
    public class StoreEditPresenter : EditPresenterBase<Store>
    {
        private IStoreEditView _iStoreEditView;
        private Business.Model.IStoreBusinessModel _iStoreBusinessModel;
        
        public StoreEditPresenter(
            IStoreEditView iStoreEditView
            , Business.Model.IStoreBusinessModel iStoreBusinessModel
            , Store model = null
            )
            :base("Store")
        {
            // TODO: Complete member initialization
            this._iStoreEditView = iStoreEditView;
            this._iStoreBusinessModel = iStoreBusinessModel;
            base._model = model;
        }
        public override void Save(Action<string, List<Store>> callBackAfterSaving)
        {
            if (_iStoreEditView.GetName().Trim().Length > FormsHelper.WASHINGNAME_MAXLENGTH ? true : false)
            {
                _iStoreEditView.ShowMessage(FormsHelper.NameValidationError);
                return;
            }

            if (_model == null)
            {
                if (_iStoreEditView.GetCode().Trim().Length > FormsHelper.CODE_MAXLENGTH ? true : false)
                {
                    _iStoreEditView.ShowMessage(FormsHelper.CodeValidationError);
                    return;
                }

                _model = new Store
                {
                    Code = _iStoreEditView.GetCode()
                    ,
                    Name = _iStoreEditView.GetName()
                    ,
                    CreatedDate = DateTime.Now
                    ,
                    CreatedBy = _iStoreEditView.GetUser()
                };


                var size = _iStoreBusinessModel.SelectByPrimaryId(_model.Code);


                if (size != null)
                {
                    _iStoreEditView.ShowMessage("Code Already Exists!");
                    _model = null;
                    return;
                }
            }
            else
            {
                _model.Name = _iStoreEditView.GetName();
                _model.ModifiedDate = DateTime.Now;
                _model.ModifiedBy = _iStoreEditView.GetUser();
            }

            PersistChanges<IStoreBusinessModel>(_iStoreBusinessModel,callBackAfterSaving);
        }

        public override void LoadModels(Store model)
        {
            base._model = model;
            base.LoadEntity<IStoreEditView>(_iStoreEditView);
        }

        public override bool ShouldEnable()
        {
            return base.ShouldEnable(_iStoreEditView.GetName()) && base.ShouldEnable(_iStoreEditView.GetCode());
        }

    }
}
