using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Dal
{
    public class OutletDal:DalBase<Outlet>,IOutletDal
    {
      
        public OutletDal(Helpers.ISgiHelper iSgiHelper):base(iSgiHelper)
        {
           
        }
        
        public  List<Outlet> SelectAll()
        {
            return _helper.DataHelper.SelectAll<Outlet>();
        }

        public  Outlet SelectPrimaryEntity<D>(D primaryValue)
        {
            return _helper.DataHelper.SelectPrimary<Outlet,D>(primaryValue);
        }

        public  List<Outlet> SelectBySpQuery(string spName, Dictionary<string, object> parameters)
        {
            return _helper.DataHelper.SelectSp<Outlet>(spName,parameters);
        }

        public  void SaveOrUpdate(Outlet entity)
        {
            _helper.DataHelper.SaveOrUpdate<Outlet>(entity);
        }

        public  List<Outlet> SelectBySpQuery(string spName)
        {
            return _helper.DataHelper.SelectSp<Outlet>(spName);
        }

        public  void Delete(Outlet model)
        {
            _helper.DataHelper.Delete<Outlet>(model);
        }
    }
}
