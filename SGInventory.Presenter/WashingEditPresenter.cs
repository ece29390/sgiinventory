using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Helpers;
using SGInventory.Business.Model;
using SGInventory.Views;

namespace SGInventory.Presenters
{
    public class WashingEditPresenter : EditPresenterBase<Washing>
    {
        private Views.IWashingEditView _iWashingEditView;
        private Business.Model.IWashingBusinessModel _iWashingBusinessModel;
        private IWashingEditView iWashingEditView;
       
        private IWashingBusinessModel iWashingBusinessModel;

        public WashingEditPresenter(Views.IWashingEditView iWashingEditView
            , Business.Model.IWashingBusinessModel iWashingBusinessModel
            , Washing model= null
            )
            :base("Washing")
        {
           
            this._iWashingEditView = iWashingEditView;
            this._iWashingBusinessModel = iWashingBusinessModel;
            base._model = model;
        }

      
        public override void Save(Action<string, List<Washing>> callBackAfterSaving)
        {
            
            var dateNow = DateTime.Now;
            var name = _iWashingEditView.GetName();
            var code = _iWashingEditView.GetCode();


            if (name.Trim().Length > FormsHelper.WASHINGNAME_MAXLENGTH)
            {
                _iWashingEditView.ShowMessage(FormsHelper.WashingNameValidationError);
                return;
            }

            if (base._model == null)
            {
                if(code.Trim().Length>FormsHelper.CODE_MAXLENGTH)
                {
                    _iWashingEditView.ShowMessage(FormsHelper.CodeValidationError);
                    return;
                }

                base._model = new Washing
                {
                    Name = name,
                    Code=code,
                    CreatedDate = dateNow,
                    CreatedBy = _iWashingEditView.GetUser()
                };

                var model = _iWashingBusinessModel.SelectByPrimaryId(code);

                if (model != null)
                {
                    _iWashingEditView.ShowMessage("Code Already Exists!");
                    _model = null;
                    return;
                }
            }
            else
            {
                base._model.Name = name;
                base._model.ModifiedBy = _iWashingEditView.GetUser();
                base._model.ModifiedDate = DateTime.Now;
            }
                      
            base.PersistChanges<IWashingBusinessModel>(this._iWashingBusinessModel, callBackAfterSaving);
        }

        public override void LoadModels(Washing model)
        {
            base._model = model;
            base.LoadEntity<IWashingEditView>(this._iWashingEditView);
        }

        public override bool ShouldEnable()
        {
            return base.ShouldEnable(_iWashingEditView.GetName()) && base.ShouldEnable(_iWashingEditView.GetCode());
        }
    }
}
