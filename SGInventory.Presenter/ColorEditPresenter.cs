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
    public class ColorEditPresenter:EditPresenterBase<Color>
    {
        private Views.IColorEditView _colorEditView;
        private Business.Model.IColorBusinessModel _businessModel;

        public ColorEditPresenter(Views.IColorEditView colorEditView
            , Business.Model.IColorBusinessModel businessModel
            , Color model=null
            ):base("Color")
        {        
            this._colorEditView = colorEditView;
            this._businessModel = businessModel;
            _model = model;
        }

        public override void Save(Action<string, List<Color>> callBackAfterSaving)
        {
            if (_colorEditView.GetName().Trim().Length > FormsHelper.WASHINGNAME_MAXLENGTH ? true : false)
            {
                _colorEditView.ShowMessage(FormsHelper.NameValidationError);
                return;
            }

            if (_model == null)
            {
                if (_colorEditView.GetCode().Trim().Length > FormsHelper.CODE_MAXLENGTH ? true : false)
                {
                    _colorEditView.ShowMessage(FormsHelper.CodeValidationError);
                    return;
                }

                _model = new Color
                {
                    Code = _colorEditView.GetCode()
                    ,
                    Name = _colorEditView.GetName()
                    ,
                    CreatedDate = DateTime.Now
                    ,
                    CreatedBy = _colorEditView.GetUser()
                };


                var size = _businessModel.SelectByPrimaryId(_model.Code);


                if (size != null)
                {
                    _colorEditView.ShowMessage("Code Already Exists!");
                    _model = null;
                    return;
                }
            }
            else
            {
                _model.Name = _colorEditView.GetName();
                _model.ModifiedDate = DateTime.Now;
                _model.ModifiedBy = _colorEditView.GetUser();
            }

            PersistChanges<IColorBusinessModel>(_businessModel, callBackAfterSaving);
        }

        public override void LoadModels(Color model)
        {
            base._model = model;
            base.LoadEntity<IColorEditView>(_colorEditView);
        }

        public override bool ShouldEnable()
        {
            return base.ShouldEnable(_colorEditView.GetName()) && base.ShouldEnable(_colorEditView.GetCode());
        }
    }
}
