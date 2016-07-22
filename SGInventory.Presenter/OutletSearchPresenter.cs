using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Business.Model;

namespace SGInventory.Presenters
{
    public class OutletSearchPresenter: SearchPresenterBase<Outlet,IOutletBusinessModel,int>
    {
       
        public OutletSearchPresenter(Views.IModelSearchView<Outlet> iOutletSearchView
            , Business.Model.IOutletBusinessModel iOutletBusinessModel):base(iOutletSearchView,iOutletBusinessModel)
        {
          
        
        }

       
    }
}
