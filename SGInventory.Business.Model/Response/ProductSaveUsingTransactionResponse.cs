using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Business.Model.Response
{
    public class ProductSaveUsingTransactionResponse
    {
        public bool IsSuccessful { get; set; }

        public string Message { get; set; }
    }
}
