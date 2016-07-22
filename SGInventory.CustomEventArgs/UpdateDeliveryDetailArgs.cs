using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.CustomEventArgs
{
    public class UpdateDeliveryDetailArgs:EventArgs
    {
        public DeliveryDetail PreviousSelectedDeliveryDetail { get; private set; }
        public DeliveryDetail CurrentSelectedDeliveryDetail { get; private set; }

        public UpdateDeliveryDetailArgs(DeliveryDetail previousSelectedDeliveryDetail, DeliveryDetail currentSelectedDeliveryDetail)
        {
            PreviousSelectedDeliveryDetail = previousSelectedDeliveryDetail;
            CurrentSelectedDeliveryDetail = currentSelectedDeliveryDetail;
        }
    }
}
