using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Business.Model
{
    public interface ISave<T>
    {
        string Save(T model);
    }
}
