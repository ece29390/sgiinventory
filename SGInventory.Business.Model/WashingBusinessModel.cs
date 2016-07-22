using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Helpers;

namespace SGInventory.Business.Model
{
    public class WashingBusinessModel:IWashingBusinessModel
    {
        private Dal.IWashingDal _iWashingDal;

        public WashingBusinessModel(Dal.IWashingDal iWashingDal)
        {
            
            this._iWashingDal = iWashingDal;
        }

        public List<SGInventory.Model.Washing> SelectAll()
        {
            return _iWashingDal.SelectAll();
        }

        public SGInventory.Model.Washing SelectByPrimaryId(string id)
        {
            return _iWashingDal.SelectPrimaryEntity<string>(id);
        }

        public bool Valid(SGInventory.Model.Washing model)
        {
            return true;
        }

        public void Delete(SGInventory.Model.Washing model)
        {
            _iWashingDal.Delete(model);
        }

        public void CreateOrUpdate(SGInventory.Model.Washing model)
        {
            _iWashingDal.SaveOrUpdate(model);
        }

        public string Save(SGInventory.Model.Washing model)
        {
            var modelName = "Washing";
            //var parameters = new Dictionary<string, object>();
            //parameters["washingCode"] = model.Code;


            //var query = "CALL SelectWashingByCode(:washingCode)";
            //var modelByCode = _iWashingDal.SelectBySpQuery(query, parameters);

            //var newModel = modelByCode.Count == 0 ? true : false;


            //parameters.Clear();
            //parameters["washingName"] = model.Name;

            //query = "CALL SelectWashingByName(:washingName)";
            //var modelByName = _iWashingDal.SelectBySpQuery(query, parameters);

            //if (modelByName.Count > 0)
            //{
            //    if (!modelByName[0].Code.Equals(model.Code, StringComparison.InvariantCultureIgnoreCase))
            //    {
            //        return "Name Already Exists!";
            //    }
            //}

            var washingsByCode = _iWashingDal.SelectBy("Code",model.Code);

            var newModel = washingsByCode.Count == 0 ? true : false;

            var washingsByName = _iWashingDal.SelectBy("Name", model.Name);

            if (washingsByName.Count > 0)
            {
                if (!washingsByName[0].Code.Equals(model.Code, StringComparison.InvariantCultureIgnoreCase))
                {
                    return "Name Already Exists!";
                }
            }

            CreateOrUpdate(model);
            return newModel ? string.Format("A new {0} has been added", modelName) : string.Format("{0} has been updated", modelName);                        
        }

        public List<Washing> SelectByProductDetails(List<ProductDetails> list)
        {
            return list.Select(p => p.Washing).Distinct(new WashingComparer()).ToList<Washing>();                           
        }
    }
}
