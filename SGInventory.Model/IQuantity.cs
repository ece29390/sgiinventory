using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Model
{
    public interface IQuantity
    {
        int QuantityOnHand { get; set; }
    }
}
