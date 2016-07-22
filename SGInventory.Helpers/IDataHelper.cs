using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace SGInventory.Helpers
{
    public interface IDataHelper
    {
        ISessionFactory SessionFactory { get;  }
        List<T> SelectAll<T>() where T:class,new();
        T SelectPrimary<T, D>(D primaryValue) where T : class,new();
        void SaveOrUpdate<T>(T entity) where T : class,new();
        List<T> SelectSp<T>(string spName) where T : class,new();
        List<T> SelectSp<T>(string spName, Dictionary<string, object> parameters) where T : class,new();
        void Delete<T>(T model);
    }
}
