using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Model
{
    public interface IModified
    {
        string ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
    }
}
