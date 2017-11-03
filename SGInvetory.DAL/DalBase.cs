using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Helpers;

namespace SGInventory.Dal
{
    /// <summary>
    /// base class for datalayer classes
    /// </summary>
    /// <typeparam name="T">the model class</typeparam>
    public abstract class DalBase<T> where T:class,new()
    {
        protected ISgiHelper _helper;

        protected DalBase(ISgiHelper helper)
        {
            _helper = helper;
        }
        protected List<T> ExecuteSpQuery(Func<string> getQueryName, Func<Dictionary<string, object>> getParameters)
        {
            var query = getQueryName();
            var parameters = getParameters();
            return _helper.DataHelper.SelectSp<T>(query, parameters).ToList();
        }
        
    }

}
