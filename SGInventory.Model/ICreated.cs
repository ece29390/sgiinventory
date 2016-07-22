using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Model
{
    public interface ICreated
    {
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
