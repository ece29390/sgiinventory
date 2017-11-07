using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Presenters.Model
{
    public class SalesDisplayModel
    {
        public SalesDisplayModel()
        {
            DeleteDescription = "Delete";
        }

        public int Id { get; set; }

        public string Code { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

        public string Washing { get; set; }

        public int Quantity { get; set; }        
        public string DeleteDescription { get; private set; }
    }
}
