using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Helpers;

namespace SGInventory.Dal
{
    public interface ICrud<T>
    {
         List<T> SelectAll();
         T SelectPrimaryEntity<D>(D primaryValue);
         List<T> SelectBySpQuery(string spName, Dictionary<string, object> parameters);
         void SaveOrUpdate(T entity);
         List<T> SelectBySpQuery(string spName);
         void Delete(T model);
       
    }
}
