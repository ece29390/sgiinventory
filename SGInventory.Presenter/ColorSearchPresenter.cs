using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Business.Model;

namespace SGInventory.Presenters
{
    public class ColorSearchPresenter : SearchPresenterBase<Color, IColorBusinessModel, string>
    {
        
        public ColorSearchPresenter(Views.IColorSearchView colorSearchView, Business.Model.IColorBusinessModel businessModel)
            :base(colorSearchView,businessModel)
        {
                       
        }
    }
}
