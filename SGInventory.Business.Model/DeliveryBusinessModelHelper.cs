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

        public bool IsQuantityAvailable(string code,int quantity,ProductStatus status)
        {
            var totalQuantityReceived = _deliveryModel.GetDeliveryDetailTotalQuantityByCode(code,status);
            var totalQuantityDelivered = _deliveryToOutletModel.GetDeliveryDetailToOutletTotalQuantityByCode(code,status);

            var availableQuantity = totalQuantityReceived - totalQuantityDelivered;

            return availableQuantity >= quantity;
        }

        public bool IsAdjustedQuantityValid(string code, int oldQuantity, int newQuantity,ProductStatus status)
        {
            var totalQuantityReceived = _deliveryModel.GetDeliveryDetailTotalQuantityByCode(code, status);
            var totalQuantityDelivered = _deliveryToOutletModel.GetDeliveryDetailToOutletTotalQuantityByCode(code, status);

            totalQuantityDelivered -= oldQuantity;

            var availableQuantity = totalQuantityReceived - totalQuantityDelivered;

            return availableQuantity >= newQuantity;
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
