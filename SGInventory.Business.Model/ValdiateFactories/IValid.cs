using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Business.Model.ValdiateFactories
{
    public interface IValid
    {
        string Validate(List<object> arguments);
    }
}
