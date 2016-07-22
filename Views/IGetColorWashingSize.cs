using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Views
{
    public interface IGetColorWashingSize
    {
        string GetColorCode();

        string GetWashingCode();

        string GetSizeCode();
    }
}
