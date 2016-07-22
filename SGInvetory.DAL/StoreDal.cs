using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Dal
{
    public class StoreDal:IStoreDal
    {
        private Helpers.ISgiHelper _iSgiHelper;

        public StoreDal(Helpers.ISgiHelper iSgiHelper)
        {
            // TODO: Complete member initialization
            this._iSgiHelper = iSgiHelper;
        }

        public List<Model.Store> SelectAll()
        {
            return _iSgiHelper.DataHelper.SelectAll<Store>();
        }

        public Model.Store SelectPrimaryEntity<D>(D primaryValue)
        {
            return _iSgiHelper.DataHelper.SelectPrimary<Store, D>(primaryValue);
        }

        public List<Model.Store> SelectBySpQuery(string spName, Dictionary<string, object> parameters)
        {
            return _iSgiHelper.DataHelper.SelectSp<Store>(spName, parameters);
        }

        public void SaveOrUpdate(Model.Store entity)
        {
            _iSgiHelper.DataHelper.SaveOrUpdate(entity);
        }

        public List<Model.Store> SelectBySpQuery(string spName)
        {
            return _iSgiHelper.DataHelper.SelectSp<Store>(spName);
        }

        public void Delete(Model.Store model)
        {
            _iSgiHelper.DataHelper.Delete(model);
        }
    }
}
