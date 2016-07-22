using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Enums;
using SGInventory.Helpers;

namespace SGInventory.Presenters.Model
{
    public class DeliveryGridModel
    {
        public string SizeCode { get; set; }

        public string ColorCode { get; set; }

        public int Quantity { get; set; }

        public string StatusDescription { get; set; }

        public ProductStatus Status { get; set; }

        public override int GetHashCode()
        {
            return SgiHelper.GetHashCodeOfColorAndSize(ColorCode, SizeCode);
        }
        
    }
}
