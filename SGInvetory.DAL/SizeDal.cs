using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Dal
{
    public class SizeDal:DalBase<Size>,ISizeDal
    {
        
        public SizeDal(Helpers.ISgiHelper iSgiHelper):base(iSgiHelper)
        {
         
        }

        public List<Size> SelectAll()
        {
            return _helper.DataHelper.SelectAll<Size>();
        }

        public Size SelectPrimaryEntity<D>(D primaryValue)
        {
            return _helper.DataHelper.SelectPrimary<Size, D>(primaryValue);
        }

        public List<Size> SelectBySpQuery(string spName, Dictionary<string, object> parameters)
        {
            return _helper.DataHelper.SelectSp<Size>(spName, parameters);
        }

        public void SaveOrUpdate(Size entity)
        {
            _helper.DataHelper.SaveOrUpdate<Size>(entity);
        }

        public List<Size> SelectBySpQuery(string spName)
        {
            return _helper.DataHelper.SelectSp<Size>(spName);
        }

        public void Delete(Size model)
        {
            _helper.DataHelper.Delete<Size>(model);
        }
    }
}
