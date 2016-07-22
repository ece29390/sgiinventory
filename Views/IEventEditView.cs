using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.CustomEventArgs;

namespace SGInventory.Views
{
    public interface IEventEditView<T>
    {
        event EventHandler<ModelEventArgs<T>> OnModelUpdateSuccessful;
    }
}
