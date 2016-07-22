using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Presenters
{
    public class ScannerResponse: EventArgs
    {
        public string Message { get; set; }

        public string ItemCode { get; set; }
    }
}
