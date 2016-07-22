using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Model
{
    public interface IPrices
    {
        double Cost { get; set; }

        double RegularPrice { get; set; }

        double MarkdownPrice { get; set; }
    }
}
