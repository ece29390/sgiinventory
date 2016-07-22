using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Business.Model;
using SGInventory.Model;
using SGInventory.Views;
using SGInventory.Helpers;

namespace SGInventory.Presenters
{
    public class CategoryEditPresenter:EditPresenterBase<Category>
    {
    
        private ICategoryBusinessModel _categoryBusinessModel;
        private ICategoryEditView _iCategoryEditView;
       
       
              
        public CategoryEditPresenter(
            ICategoryEditView iCategoryEditView
            , ICategoryBusinessModel iCategoryBusinessModel
            ,Category category=null
            ):base("Category")
        {
            
            this._iCategoryEditView = iCategoryEditView;
            this._categoryBusinessModel = iCategoryBusinessModel;
            base._model = category;
            
        }
       
        public override void Save(Action<string,List<Category>> callBackAfterSaving)
        {
            var user = _iCategoryEditView.GetUser();
            var dateNow=DateTime.Now;
            var name =_iCategoryEditView.GetName();
            if (base._model == null)
            {
                base._model = new Category
                {
                    Name = name,
                    Description = _iCategoryEditView.GetDescription(),
                    CreatedDate = dateNow,
                    CreatedBy = user,
                    ModifiedDate = dateNow,
                    ModifiedBy = user,
                };
            }
            else
            {
                base._model.Name = name;
                base._model.Description = _iCategoryEditView.GetDescription();
                base._model.ModifiedBy = user;
                base._model.ModifiedDate = DateTime.Now;
            }
            if (name.Trim().Length > FormsHelper.NAME_MAXLENGTH ? true : false)
            {
                _iCategoryEditView.ShowMessage(FormsHelper.NameValidationError);
                return;
            }

            var inputValiadtionFailed = _iCategoryEditView.GetDescription().Trim().Length > FormsHelper.DESC_MAXLENGTH ? true : false;
            if (inputValiadtionFailed)
            {
                _iCategoryEditView.ShowMessage(FormsHelper.DescriptionValidationError);
                return;
            }

            base.PersistChanges<ICategoryBusinessModel>(this._categoryBusinessModel, callBackAfterSaving);
                      
        }
      
        public override void LoadModels(Category model)
        {
            base._model = model;
            base.LoadEntity<ICategoryEditView>(this._iCategoryEditView);
        }

        public override bool ShouldEnable()
        {
            return base.ShouldEnable(_iCategoryEditView.GetName());
        }
    }
}
