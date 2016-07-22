using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Business.Model;
using SGInventory.Views;

namespace SGInventory.Presenters
{
    public class WashingSearchPresenter : SearchPresenterBase<Washing, IWashingBusinessModel, string>
    {

        public WashingSearchPresenter(IModelSearchView<Washing> iWashingSearchView
            , Business.Model.IWashingBusinessModel iWashingBusinessModel)
            :base(iWashingSearchView,iWashingBusinessModel)
        {
            
        }
    }
}
