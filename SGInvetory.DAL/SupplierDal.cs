using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Dal
{
    public class SupplierDal:DalBase<Supplier>,ISupplierDal
    {     
        public SupplierDal(Helpers.ISgiHelper iSgiHelper):base(iSgiHelper)
        {
         
        }

        public  List<Supplier> SelectAll()
        {
            return _helper.DataHelper.SelectAll<Supplier>();
        }

        public  Supplier SelectPrimaryEntity<D>(D primaryValue)
        {
            return _helper.DataHelper.SelectPrimary<Supplier, D>(primaryValue);
        }

        public  List<Supplier> SelectBySpQuery(string spName, Dictionary<string, object> parameters)
        {
            return _helper.DataHelper.SelectSp<Supplier>(spName,parameters);
        }

        public  void SaveOrUpdate(Supplier entity)
        {
             _helper.DataHelper.SaveOrUpdate<Supplier>(entity);
        }

        public  List<Supplier> SelectBySpQuery(string spName)
        {
            return _helper.DataHelper.SelectSp<Supplier>(spName);
        }
      
        public  void Delete(Supplier model)
        {
             _helper.DataHelper.Delete<Supplier>(model);
        }
       
    }
}
