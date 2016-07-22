using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Business.Model
{
    public class ColorBusinessModel:IColorBusinessModel
    {
        private Dal.IColorDal _colorDal;

        public ColorBusinessModel(Dal.IColorDal colorDal)
        {
          
           _colorDal = colorDal;
        }

        public void Delete(SGInventory.Model.Color model)
        {
            _colorDal.Delete(model);
        }

        public void CreateOrUpdate(SGInventory.Model.Color model)
        {
            _colorDal.SaveOrUpdate(model);
        }

        public string Save(SGInventory.Model.Color model)
        {
            var modelName = "Color";
            var parameters = new Dictionary<string, object>();
            parameters["colorCode"] = model.Code;


            var query = "CALL SelectColorByCode(:colorCode)";
            var modelByCode = _colorDal.SelectBySpQuery(query, parameters);

            var newModel = modelByCode.Count == 0 ? true : false;


            parameters.Clear();
            parameters["colorName"] = model.Name;

            query = "CALL SelectColorByName(:colorName)";
            var modelByName = _colorDal.SelectBySpQuery(query, parameters);

            if (modelByName.Count > 0)
            {
                if (!modelByName[0].Code.Equals(model.Code, StringComparison.InvariantCultureIgnoreCase))
                {
                    return "Name Already Exists!";
                }
            }

            CreateOrUpdate(model);
            return newModel ? string.Format("A new {0} has been added", modelName) : string.Format("{0} has been updated", modelName);                        
        }

        public List<SGInventory.Model.Color> SelectAll()
        {
            return _colorDal.SelectAll();
        }

        public SGInventory.Model.Color SelectByPrimaryId(string id)
        {
            return _colorDal.SelectPrimaryEntity<string>(id);
        }

        public bool Valid(SGInventory.Model.Color model)
        {
            return true;
        }

        public List<Color> SelectByProductDetails(List<ProductDetails> list)
        {
            return list.Select(p => p.Color).Distinct(new ColorComparer()).ToList<Color>();
        }
    }
}
