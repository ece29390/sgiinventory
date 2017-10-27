using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Views;
using SGInventory.Business.Model;
using SGInventory.Model;
using SGInventory.Helpers;
using SGInventory.Enums;

namespace SGInventory.Presenters
{
    public class DeliveryToOutletDetailEditPresenter
    {
        private IDeliveryToOutletEditView _view;
        private IDeliveryToOutletBusinessModel _deliveryBusinessModel;
        private IDeliveryBusinessModelHelper _deliveryHelper;
        public bool EditMode { get; private set; }

        public DeliveryToOutletDetailEditPresenter(
            IDeliveryToOutletEditView view
            , IDeliveryToOutletBusinessModel deliveryBusinessModel
            , IDeliveryBusinessModelHelper deliveryHelper
            )
        {
            _view = view;
            _deliveryBusinessModel = deliveryBusinessModel;
            _deliveryHelper = deliveryHelper;            
        }


        public void LoadDeliveryToOutletDetail(SGInventory.Model.DeliveryToOutletDetail deliveryToOutletDetail)
        {
            SelectedDeliveryToOutletDetail = deliveryToOutletDetail;
            _view.DisplayDeliveryDetail(deliveryToOutletDetail);
        }

        public void LoadDeliveryToOutlet(DeliveryToOutlet deliveryToOutlet)
        {
            EditMode = deliveryToOutlet.Id > 0;       
            DeliveryToOutlet = deliveryToOutlet;
            _view.LoadDisplayDeliveryDetailList(DeliveryToOutlet.DeliveryToOutletDetails);
            _view.RefreshControls();
        }

        public SGInventory.Model.DeliveryToOutletDetail SelectedDeliveryToOutletDetail { get; set; }

        public void SaveDeliveryToOutletDetail()
        {
            var validate = ValidateQuantity(_view.GetQuantity());

            if (!validate)
            {
                _view.ShowMessage("Quantity exceeds the available quantity");
                return;
            }

            SelectedDeliveryToOutletDetail.Quantity = _view.GetQuantity();
            SelectedDeliveryToOutletDetail.Remarks = _view.GetRemarks();

            var deliveryToOutlet = SelectedDeliveryToOutletDetail.DeliveryToOutlet;

            ProcessDeliveryToOutletForSaving(deliveryToOutlet);            
        }

        private bool ValidateQuantity(int quantity)
        {
            var retValue = true;

            var productStatus = (ProductStatus)Enum.ToObject(typeof(ProductStatus), SelectedDeliveryToOutletDetail.Status);
            retValue = 
                SelectedDeliveryToOutletDetail.Id==0?
                _deliveryHelper.IsQuantityAvailable(SelectedDeliveryToOutletDetail.ProductDetail.Code               
                , quantity
                , productStatus)
                :_deliveryHelper.IsQuantityAvailable(SelectedDeliveryToOutletDetail.ProductDetail.Code
                ,quantity
                , productStatus
                ,SelectedDeliveryToOutletDetail.DeliveryToOutlet.Id)
                ;

            return retValue;
        }

        public SGInventory.Model.DeliveryToOutlet DeliveryToOutlet { get; set; }

        public void DeactivateDeliveryToOutletDetail()
        {
            SelectedDeliveryToOutletDetail.IsActive = 0;

            if(!EditMode)
            {
                SelectedDeliveryToOutletDetail.DeliveryToOutlet
                    .DeliveryToOutletDetails = SelectedDeliveryToOutletDetail.DeliveryToOutlet
                    .DeliveryToOutletDetails.Where(dd => dd.IsActive == 1).ToList();
            }

            ProcessDeliveryToOutletForSaving(SelectedDeliveryToOutletDetail.DeliveryToOutlet);
           
        }

        private void ProcessDeliveryToOutletForSaving(DeliveryToOutlet deliveryToOutlet)
        {
            if(EditMode)
            {
                var message = _deliveryBusinessModel.SaveDeliveryToOutlet(deliveryToOutlet);
                _view.ShowMessage(message);
            }

            _view.RefreshControls();
            _view.LoadDisplayDeliveryDetailList(deliveryToOutlet.DeliveryToOutletDetails);
        }
    }
}
