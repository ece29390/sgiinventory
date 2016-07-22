using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Business.Model
{
    public class SupplierBusinessModel:ISupplierBusinessModel
    {
        private Dal.ISupplierDal _iSupplierDal;

        public SupplierBusinessModel(Dal.ISupplierDal iSupplierDal)
        {            
            this._iSupplierDal = iSupplierDal;
        }

        public List<SGInventory.Model.Supplier> SelectAll()
        {
            return _iSupplierDal.SelectAll();
        }

        public SGInventory.Model.Supplier SelectByPrimaryId(int primaryId)
        {
            return _iSupplierDal.SelectPrimaryEntity<int>(primaryId);
        }

        public bool Valid(SGInventory.Model.Supplier model)
        {
            var returnValue = true;
            var parameterName = "supplierName";

            var spQuery = string.Format("CALL SelectSupplierByName(:{0})",parameterName);

            var parameters = new Dictionary<string, object> { 
                {parameterName,model.Name}
            };

            var returnList = _iSupplierDal.SelectBySpQuery(spQuery, parameters);

            if (returnList.Count > 0)
            {
                returnValue = returnList[0].Id == model.Id;
            }

            return returnValue;
        }



        public void Delete(SGInventory.Model.Supplier model)
        {
            _iSupplierDal.Delete(model);
        }

        public void CreateOrUpdate(SGInventory.Model.Supplier model)
        {
            _iSupplierDal.SaveOrUpdate(model);
        }

        public string Save(SGInventory.Model.Supplier model)
        {
            if (Valid(model))
            {
                var previousId = model.Id;
                CreateOrUpdate(model);
                return previousId > 0 ? "Supplier has been updated" : "A new Supplier has been added";
            }

            return string.Format("{0} already exists", model.Name);
        }
    }
}
