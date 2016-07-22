using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.CustomEventArgs
{
    public class ScanCodeArgs:EventArgs
    {
        public bool IsBarCode { get;private set; }
        public string Code { get;private set; }

        public ScanCodeArgs(bool isBarcode, string code)
        {
            IsBarCode = isBarcode;
            Code = code;
        }

    }
}
