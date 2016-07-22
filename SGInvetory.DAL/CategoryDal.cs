using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Helpers;
using SGInventory.Model;
namespace SGInventory.Dal
{
    public class CategoryDal:DalBase<Category>,ICategoryDal
    {       
        public CategoryDal(ISgiHelper helper) : base(helper) { }    
   
        public  List<Category> SelectAll()
        {
            return _helper.DataHelper.SelectAll<Category>();
        }

        public  Category SelectPrimaryEntity<D>(D primaryValue)
        {
            return _helper.DataHelper.SelectPrimary<Category, D>(primaryValue);
        }

        public  List<Category> SelectBySpQuery(string spName)
        {
            return _helper.DataHelper.SelectSp<Category>(spName);
        }

        public  List<Category> SelectBySpQuery(string spName,Dictionary<string, object> parameters)
        {
            return _helper.DataHelper.SelectSp<Category>(spName,parameters);
        }

        public  void SaveOrUpdate(Category entity)
        {
            _helper.DataHelper.SaveOrUpdate<Category>(entity);
        }

        public  void Delete(Category model)
        {
            _helper.DataHelper.Delete<Category>(model);
        }

       
    }
}
