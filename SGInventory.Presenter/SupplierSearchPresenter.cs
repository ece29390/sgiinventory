using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Business.Model;

namespace SGInventory.Presenters
{
    public class SupplierSearchPresenter : SearchPresenterBase<Supplier, ISupplierBusinessModel, int>
    {
     

        public SupplierSearchPresenter(Views.ISupplierSearchView iSupplierSearchView
            , Business.Model.ISupplierBusinessModel iSupplierBusinessModel)
            :base(iSupplierSearchView,iSupplierBusinessModel)
        {
            
         
        }

      
    }
}
