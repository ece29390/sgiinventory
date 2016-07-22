using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Inventory
{
    public class ViewHistoryReport:IComparable<ViewHistoryReport>
    {
        public int EntityId { get; set; }

        public int Quantity { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Entity { get; set; }

        public string DeliveryDescription { get; set; }

        public bool IsDeliveryIncoming { get; set; }

        public bool IsManuallyAdjusted { get; set; }

        public int CompareTo(ViewHistoryReport other)
        {
            return other.TransactionDate.CompareTo(TransactionDate);
        }
    }
}
