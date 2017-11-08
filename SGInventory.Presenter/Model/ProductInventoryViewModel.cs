using SGInventory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Presenters
{
    public class ProductInventoryViewModel:ProductInventoryView
    {       
        public string ViewHistory
        { get {
                return "View History";
            } }  
    }
}
