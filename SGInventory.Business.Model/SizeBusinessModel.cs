using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Business.Model
{
    public class SizeBusinessModel:ISizeBusinessModel
    {
        private Dal.ISizeDal _iSizeDal;

        public SizeBusinessModel(Dal.ISizeDal sizeDal)
        {          
            this._iSizeDal = sizeDal;
        }

        public void Delete(SGInventory.Model.Size model)
        {
             _iSizeDal.Delete(model);
        }

        public void CreateOrUpdate(SGInventory.Model.Size model)
        {
            _iSizeDal.SaveOrUpdate(model);
        }

      

        public string Save(SGInventory.Model.Size model)
        {
            var modelName = "Size";
            var parameters = new Dictionary<string, object>();
            parameters["sizeCode"] = model.Code;

            
            var query = "CALL SelectSizeByCode(:sizeCode)";
            var modelByCode = _iSizeDal.SelectBySpQuery(query, parameters);

            var newModel = modelByCode.Count == 0 ? true : false;
           
          
            parameters.Clear();
            parameters["sizeName"] = model.Name;

            query = "CALL SelectSizeByName(:sizeName)";
            var modelByName = _iSizeDal.SelectBySpQuery(query, parameters);

            if (modelByName.Count > 0)
            {
                if (!modelByName[0].Code.Equals(model.Code, StringComparison.InvariantCultureIgnoreCase))
                {
                    return "Name Already Exists!";
                }
            }

            CreateOrUpdate(model);
            return newModel ? string.Format("A new {0} has been added", modelName) : string.Format("{0} has been updated",modelName);                        
        }

        public List<SGInventory.Model.Size> SelectAll()
        {
            return _iSizeDal.SelectAll();
        }

        public SGInventory.Model.Size SelectByPrimaryId(string id)
        {
            return _iSizeDal.SelectPrimaryEntity<string>(id);
        }

        public bool Valid(SGInventory.Model.Size model)
        {
           return true;
        }

        public List<Size> SelectByProductDetails(List<SGInventory.Model.ProductDetails> list)
        {
            return list.Select(p => p.Size).Distinct(new SizeComparer()).ToList<Size>();
        }
    }
}
