using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Views;
using SGInventory.Business.Model;
using SGInventory.Model;
using SGInventory.Helpers;

namespace SGInventory.Presenters
{
    public class SizeEditPresenter:EditPresenterBase<Size>
    {
        private ISizeEditView _sizeEditView;
        private ISizeBusinessModel _sizeBusinessModel;

        public SizeEditPresenter(ISizeEditView sizeEditView, ISizeBusinessModel sizeBusinessModel,Size model=null)
            :base("Size")
        {
            
            _sizeEditView = sizeEditView;
            _sizeBusinessModel = sizeBusinessModel;
            _model = model;
        }

        public override void Save(Action<string, List<Size>> callBackAfterSaving)
        {            
            if (_sizeEditView.GetName().Trim().Length > FormsHelper.NAME_MAXLENGTH ? true : false)
            {
                _sizeEditView.ShowMessage(FormsHelper.NameValidationError);
                return;
            }

            if (_model == null)
            {
                if (_sizeEditView.GetCode().Trim().Length > FormsHelper.CODE_MAXLENGTH ? true : false)
                {
                    _sizeEditView.ShowMessage(FormsHelper.CodeValidationError);
                    return;
                }

                _model = new Size
                {
                    Code = _sizeEditView.GetCode()
                    ,
                    Name = _sizeEditView.GetName()
                    ,
                    CreatedDate = DateTime.Now
                    ,
                    CreatedBy = _sizeEditView.GetUser()
                };


                var size = _sizeBusinessModel.SelectByPrimaryId(_model.Code);

               
                if (size!=null)
                {
                    _sizeEditView.ShowMessage("Code Already Exists!");
                    _model = null;
                    return;
                }
            }
            else
            {
                _model.Name = _sizeEditView.GetName();
                _model.ModifiedDate = DateTime.Now;
                _model.ModifiedBy = _sizeEditView.GetUser();
            }
           
            PersistChanges<ISizeBusinessModel>(_sizeBusinessModel, callBackAfterSaving);
        }

        public override void LoadModels(Size model)
        {
            base._model = model;
            base.LoadEntity<ISizeEditView>(this._sizeEditView);
        }

        public override bool ShouldEnable()
        {
            return base.ShouldEnable(_sizeEditView.GetName()) && base.ShouldEnable(_sizeEditView.GetCode());
        }
    }
}
