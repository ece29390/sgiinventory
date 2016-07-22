using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Views
{
    public interface IEditViewLoadData<T>
    {
        void LoadData(T model);
    }
}
