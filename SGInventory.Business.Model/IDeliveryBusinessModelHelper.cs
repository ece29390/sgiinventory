using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Enums;

namespace SGInventory.Business.Model
{
    public interface IDeliveryBusinessModelHelper
    {
        IDeliveryBusinessModel DeliveryBusinessModel { get; }

        IDeliveryToOutletBusinessModel DeliveryToOutletBusinessModel { get; }

        bool IsQuantityAvailable(string code, int quantity,ProductStatus status);

        bool IsAdjustedQuantityValid(string code, int oldQuantity, int newQuantity, ProductStatus status);
    }
}
