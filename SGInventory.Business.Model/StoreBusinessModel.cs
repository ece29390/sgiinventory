using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Business.Model
{
    public class StoreBusinessModel : IStoreBusinessModel
    {
        private Dal.IStoreDal _iStoreDal;

        public StoreBusinessModel(Dal.IStoreDal iStoreDal)
        {
            // TODO: Complete member initialization
            this._iStoreDal = iStoreDal;
        }

        public void Delete(SGInventory.Model.Store model)
        {
            _iStoreDal.Delete(model);
        }

        public void CreateOrUpdate(SGInventory.Model.Store model)
        {
            _iStoreDal.SaveOrUpdate(model);
        }

        public string Save(SGInventory.Model.Store model)
        {
            return BusinessModelHelper.SaveModelWithCodeName<Store>(
                model,
                "Store",
                "CALL SelectStoreByCode(:storeCode)",
                _iStoreDal,
                "storeCode",
                "storeName",
                 "CALL SelectStoreByName(:storeName)",
                CreateOrUpdate);

        }

        public List<SGInventory.Model.Store> SelectAll()
        {
            return _iStoreDal.SelectAll();
        }

        public SGInventory.Model.Store SelectByPrimaryId(string id)
        {
            return _iStoreDal.SelectPrimaryEntity(id);
        }

        public bool Valid(SGInventory.Model.Store model)
        {
            throw new NotImplementedException();
        }
       
    }
}
