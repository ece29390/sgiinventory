using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Enums;

namespace SGInventory.Business.Model
{
    public class DeliveryBusinessModelHelper : IDeliveryBusinessModelHelper
    {
        private IDeliveryBusinessModel _deliveryModel;
        private IDeliveryToOutletBusinessModel _deliveryToOutletModel;
        public DeliveryBusinessModelHelper(
            IDeliveryBusinessModel deliveryModel
            , IDeliveryToOutletBusinessModel deliveryToOutletModel)
        {
            _deliveryModel = deliveryModel;
            _deliveryToOutletModel = deliveryToOutletModel;
        }
        public bool IsQuantityAvailable(string code, int quantity, ProductStatus status, int deliverytoOutletId)
        {
            var overallAvailableQuantity = GetBalanceBetweenIncomingSupplyAndOutgoingSupply(code, status);
            var totalQuantityOfDeliveryToOutlet = _deliveryToOutletModel.GetDeliveryDetailToOutletTotalQuantityByCodeAndStatusAndDeliveryToOutletId(code, status, deliverytoOutletId);
            var remainingQuantity = overallAvailableQuantity + totalQuantityOfDeliveryToOutlet;
            return remainingQuantity >= quantity;
        }
        public bool IsQuantityAvailable(string code,int quantity,ProductStatus status)
        {
            var availableQuantity = GetBalanceBetweenIncomingSupplyAndOutgoingSupply(code, status);

            return availableQuantity >= quantity;
        }

        private int GetBalanceBetweenIncomingSupplyAndOutgoingSupply(string code,ProductStatus status)
        {
            var totalQuantityReceived = _deliveryModel.GetDeliveryDetailTotalQuantityByCode(code, status);
            var totalQuantityDelivered = _deliveryToOutletModel.GetDeliveryDetailToOutletTotalQuantityByCodeAndStatus(code, status);

            var availableQuantity = totalQuantityReceived - totalQuantityDelivered;
            return availableQuantity;
        }
       

        public IDeliveryBusinessModel DeliveryBusinessModel
        {
            get { return _deliveryModel; }
        }

        public IDeliveryToOutletBusinessModel DeliveryToOutletBusinessModel
        {
            get { return _deliveryToOutletModel; }
        }       
    }
}
