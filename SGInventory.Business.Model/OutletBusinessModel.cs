using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Extensions;
using SGInventory.Helpers;
namespace SGInventory.Business.Model
{
    public class OutletBusinessModel : IOutletBusinessModel
    {
        private Dal.IOutletDal _iOutletDal;

        public OutletBusinessModel(Dal.IOutletDal iOutletDal)
        {
            this._iOutletDal = iOutletDal;
        }
        public void Delete(Outlet model)
        {
            _iOutletDal.Delete(model);
        }

        public void CreateOrUpdate(Outlet model)
        {
            _iOutletDal.SaveOrUpdate(model);
        }

        public bool Valid(Outlet model)
        {
            var returnValue = true;

            var spQuery = "CALL SelectOutletByName(:outletName)";

            var parameters = new Dictionary<string, object> { 
                {"outletName",model.Name}
            };

            var returnList = _iOutletDal.SelectBySpQuery(spQuery, parameters);

            if (returnList.Count > 0)
            {
                returnValue = returnList[0].Id == model.Id;
            }

            return returnValue;
        }

        public string Save(Outlet outlet)
        {            
            if (Valid(outlet))
            {
                var previousId = outlet.Id;
                CreateOrUpdate(outlet);
                return previousId > 0 ? "Outlet has been updated" : "A new Outlet has been added";
            }

            return string.Format("{0} already exists", outlet.Name);
        }

        public List<Outlet> SelectAll()
        {
            return _iOutletDal.SelectAll();
        }

        public Outlet SelectByPrimaryId(int id)
        {
            return _iOutletDal.SelectPrimaryEntity<int>(id);
        }

       
    }
}
