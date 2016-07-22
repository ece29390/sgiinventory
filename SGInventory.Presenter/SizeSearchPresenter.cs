using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Business.Model;

namespace SGInventory.Presenters
{
    public class SizeSearchPresenter:SearchPresenterBase<Size,ISizeBusinessModel,string>
    {
       
        public SizeSearchPresenter(Views.ISizeSearchView sizeSearchView, Business.Model.ISizeBusinessModel businessModel)
            :base(sizeSearchView,businessModel)
        {
          
        }

       
    }
}
