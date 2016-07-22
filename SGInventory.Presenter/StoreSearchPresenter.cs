using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Business.Model;

namespace SGInventory.Presenters
{
    public class StoreSearchPresenter : SearchPresenterBase<Store, IStoreBusinessModel, string>
    {       
        public StoreSearchPresenter(Views.IStoreSearchView iStoreSearchView, Business.Model.IStoreBusinessModel iStoreBusinessModel):
            base(iStoreSearchView,iStoreBusinessModel)
        {
          
        }
    }
}
