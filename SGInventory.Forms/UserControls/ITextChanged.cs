using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.UserControls
{
    public interface ITextChanged
    {
        event EventHandler<EventArgs> OnTextChanged;
    }
}
