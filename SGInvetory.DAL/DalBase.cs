using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Helpers;

namespace SGInventory.Dal
{
    public abstract class DalBase<T>
    {
        protected ISgiHelper _helper;

        protected DalBase(ISgiHelper helper)
        {
            _helper = helper;
        }

       
        
    }

}
