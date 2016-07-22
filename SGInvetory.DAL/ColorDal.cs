using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Dal
{
    public class ColorDal : DalBase<Color>,IColorDal
    {       
        public ColorDal(Helpers.ISgiHelper sgiHelper):base(sgiHelper)
        {         
         
        }

        public List<Color> SelectAll()
        {
            return _helper.DataHelper.SelectAll<Color>();
        }

        public Color SelectPrimaryEntity<D>(D primaryValue)
        {
            return _helper.DataHelper.SelectPrimary<Color, D>(primaryValue);
        }

        public List<Color> SelectBySpQuery(string spName, Dictionary<string, object> parameters)
        {
            if (parameters != null)
            {
                return _helper.DataHelper.SelectSp<Color>(spName, parameters);
            }
            else
            {
                return _helper.DataHelper.SelectSp<Color>(spName);
            }
            
        }

        public void SaveOrUpdate(Color entity)
        {
            _helper.DataHelper.SaveOrUpdate<Color>(entity);
        }

        public List<Color> SelectBySpQuery(string spName)
        {
            return SelectBySpQuery(spName, null);
        }

        public void Delete(Color model)
        {
            _helper.DataHelper.Delete<Color>(model);
        }
    }
}
