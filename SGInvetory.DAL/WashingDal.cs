using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using NHibernate.Criterion;

namespace SGInventory.Dal
{
    public class WashingDal:DalBase<Washing>, IWashingDal
    {
        

        public WashingDal(Helpers.ISgiHelper iSgiHelper):base(iSgiHelper)
        {
            
        }

        public List<Model.Washing> SelectAll()
        {
            return base._helper.DataHelper.SelectAll<Washing>();
        }

        public Model.Washing SelectPrimaryEntity<D>(D primaryValue)
        {
            return _helper.DataHelper.SelectPrimary<Washing, D>(primaryValue);
        }

        public List<Model.Washing> SelectBySpQuery(string spName, Dictionary<string, object> parameters)
        {
            return _helper.DataHelper.SelectSp<Washing>(spName, parameters);
        }

        public void SaveOrUpdate(Model.Washing entity)
        {
            _helper.DataHelper.SaveOrUpdate<Washing>(entity);
        }

        public List<Model.Washing> SelectBySpQuery(string spName)
        {
            return _helper.DataHelper.SelectSp<Washing>(spName);
        }

        public void Delete(Model.Washing model)
        {
            _helper.DataHelper.Delete<Washing>(model);
        }

        public List<Washing> SelectBy(string columnName, string criteria)
        {
            var ret = new List<Washing>();

            using (var session = _helper.DataHelper.SessionFactory.OpenSession())
            {
                ret = session.CreateCriteria<Washing>()
                    .Add(
                    Expression.Eq(columnName, criteria)
                    )
                    .List<Washing>().ToList<Washing>();
            }

            return ret;
        }
    }
}
