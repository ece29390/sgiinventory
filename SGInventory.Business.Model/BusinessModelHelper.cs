using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Dal;
namespace SGInventory.Business.Model
{
    internal static class BusinessModelHelper
    {
        public static string SaveModelWithCodeName<TModel>(
            TModel model, 
            string modelName,          
            string queryByCode,
            ICrud<TModel> crud,
            string codeKey,
            string nameKey,
            string queryByName,
            Action<TModel> createOrUpdate
            ) where TModel : ICode, IName
        {

            var parameters = new Dictionary<string, object>();
            parameters[codeKey] = model.Code;
            
            var modelByCode = crud.SelectBySpQuery(queryByCode, parameters);

            var newModel = modelByCode.Count == 0 ? true : false;


            parameters.Clear();
            parameters[nameKey] = model.Name;

            var modelByName = crud.SelectBySpQuery(queryByName, parameters);

            if (modelByName.Count > 0)
            {
                if (!modelByName[0].Code.Equals(model.Code, StringComparison.InvariantCultureIgnoreCase))
                {
                    return "Name Already Exists!";
                }
            }

            createOrUpdate(model);
            return newModel ? string.Format("A new {0} has been added", modelName) : string.Format("{0} has been updated", modelName);                        
        }
    
    }
}
