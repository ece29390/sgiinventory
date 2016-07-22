using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Common.Interfaces
{
    public interface ISelectByParent<T,C>
    {
        List<C> SelectByParent(T parentEntity);
    }
}
