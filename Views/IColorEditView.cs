using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Views
{
    public interface IColorEditView : ICode, IEventEditView<Color>, IEditViewName, IEditViewLoadData<Color>, IMessageBox, IEditViewUser, IOnModelUpdateSuccessful<Color>
    {
    }
}
