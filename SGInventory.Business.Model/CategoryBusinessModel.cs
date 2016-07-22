using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Dal;
using SGInventory.Model;
using SGInventory.Extensions;
using SGInventory.Helpers;
namespace SGInventory.Business.Model
{
    public class CategoryBusinessModel:ICategoryBusinessModel
    {
        private ICategoryDal _categoryDal;                                   

        public CategoryBusinessModel(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
            
        }

        public List<Category> SelectAll()
        {
            return _categoryDal.SelectAll();
        }

        public Category SelectByPrimaryId(int id)
        {
            return _categoryDal.SelectPrimaryEntity<int>(id);
        }

        public  bool Valid(Category model)
        {
            var isValid = true;

            var parameter=new Dictionary<string,object>();
            parameter.Add("categoryName", model.Name);

            var query = "CALL SelectCategoryByName(:categoryName)";
            var categories = _categoryDal.SelectBySpQuery(query, parameter).ToList<Category>();

            if (categories.Count > 0)
            {
                isValid = model.Id == categories[0].Id;
            }
            
            return isValid;
        }

        public void Delete(Category model)
        {
            _categoryDal.Delete(model);
        }

        public void CreateOrUpdate(Category model)
        {
            _categoryDal.SaveOrUpdate(model);
        }

        public string Save(Category category)
        {
            var modelName = "Category";
           
            var isValid = Valid(category);

            if (isValid)
            {
                var id = category.Id;
                CreateOrUpdate(category);
                return id == 0 ? string.Format(FormsHelper.CREATED_SUCCESSFULL, modelName) : string.Format(FormsHelper.UPDATED_SUCCCESSFULL, modelName);
            }

            return "Category already exists";
        }
    }
}
