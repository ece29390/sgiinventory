using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Views;
using SGInventory.Helpers;
using SGInventory.Enums;
using SGInventory.Model;

namespace SGInventory.Presenters
{
    public class DeliveryToOutletSearchPresenter
    {
        private IDeliveryToOutletSearchView _deliveryToOutletSearchView;
        private Business.Model.IOutletBusinessModel _outletBusinessModel;
        private Business.Model.IDeliveryToOutletBusinessModel _deliverytoOutletBusinessModel;

        public DeliveryToOutletSearchPresenter(
            IDeliveryToOutletSearchView deliveryToOutletSearchView
            , Business.Model.IOutletBusinessModel outletBusinessModel
            , Business.Model.IDeliveryToOutletBusinessModel deliveryToOutletBusinessModel
            )
        {           
           _deliveryToOutletSearchView = deliveryToOutletSearchView;
           _outletBusinessModel = outletBusinessModel;
           _deliverytoOutletBusinessModel = deliveryToOutletBusinessModel;
        }
      
        public void InitialLoad()
        {
            var outlets = _outletBusinessModel.SelectAll();
            _deliveryToOutletSearchView.LoadOutlets(outlets);

            var searchModes = SgiHelper.ConvertEnumToList<DeliveryToOutletSearchMode>(
                                                        () => Enum.GetValues(typeof(DeliveryToOutletSearchMode)),
                                                        (enumItem) => (DeliveryToOutletSearchMode)enumItem);

            _deliveryToOutletSearchView.LoadSearchMode(searchModes);
        }

        public void Search()
        {
            var deliveryToOutletSearchMode = _deliveryToOutletSearchView.GetSearchMode();
            var searchLists = new List<DeliveryToOutlet>();
            string validationMessage = string.Empty;
            Outlet outlet;
            DateTime dateFrom;
            DateTime dateTo;
            switch (deliveryToOutletSearchMode)
            {
                case DeliveryToOutletSearchMode.Outlet:
                    validationMessage = VerifyOutlet(out outlet);
                    if (string.IsNullOrEmpty(validationMessage))
                    {
                        searchLists = _deliverytoOutletBusinessModel.SelectByOutlet(_deliveryToOutletSearchView.GetOutlet());
                    }                    
                    break;
                case DeliveryToOutletSearchMode.DeliveryDate:
                    validationMessage = VerifyDateRange(out dateFrom, out dateTo);

                    if (string.IsNullOrEmpty(validationMessage))
                    {
                        searchLists = _deliverytoOutletBusinessModel.SelectByDeliveryDate(dateFrom, dateTo);
                    }                                                            
                    break;
                case DeliveryToOutletSearchMode.Both:
                    validationMessage = VerifyAll(out outlet, out dateFrom, out dateTo);

                    if (string.IsNullOrEmpty(validationMessage))
                    {
                        searchLists = _deliverytoOutletBusinessModel.SelectByBoth(
                        _deliveryToOutletSearchView.GetOutlet(),
                        _deliveryToOutletSearchView.GetDeliveryDateFrom()
                        , _deliveryToOutletSearchView.GetDeliveryDateTo());
                    }
                    
                    break;
            }

            if (string.IsNullOrEmpty(validationMessage))
            {
                _deliveryToOutletSearchView.LoadSearchDeliveries(searchLists);
            }
            else
            {
                _deliveryToOutletSearchView.ShowMessage(validationMessage);
            }
            
        }

        private string VerifyOutlet(out Outlet outlet)
        {
            var retValue = string.Empty;

            outlet = _deliveryToOutletSearchView.GetOutlet();

            if (outlet == null)
            {
                retValue = "Invalid Outlet";
            }

            return retValue;
        }

        private string VerifyDateRange(out DateTime dateFrom, out DateTime dateTo)
        {
            var retValue=string.Empty;

            dateFrom = _deliveryToOutletSearchView.GetDeliveryDateFrom();
            dateTo = _deliveryToOutletSearchView.GetDeliveryDateTo();

            if (dateFrom > dateTo)
            {
                retValue = "The Delivery Date From must be earlier than Delivery Date To";
            }
            return retValue;
        }

        private string VerifyAll(out Outlet outlet, out DateTime dateFrom, out DateTime dateTo)
        {
            var outletVerification = VerifyOutlet(out outlet);
            var dateRangeVerification = VerifyDateRange(out dateFrom, out dateTo);

            var message = !string.IsNullOrEmpty(outletVerification)||!string.IsNullOrEmpty(dateRangeVerification)? "At least one invalid input":string.Empty;

            return message;
        }

        public void LoadSelectedDelivery(int selectedIndex,bool useScanner)
        {
            var deliveryToOutlet = _deliveryToOutletSearchView.GetSelectedDeliveryToOutlet(selectedIndex);
            var productStatus = (ProductStatus)Enum.ToObject(typeof(ProductStatus), deliveryToOutlet.DeliveryToOutletDetails.First().Status);
            _deliveryToOutletSearchView.OpenDeliveryToOutletEditForm(deliveryToOutlet, useScanner, productStatus);
        }

        public void OnSelectedSearchModeChange(DeliveryToOutletSearchMode deliveryToOutletMode)
        {
            switch (deliveryToOutletMode)
            {
                case DeliveryToOutletSearchMode.Both:
                case DeliveryToOutletSearchMode.Outlet:
                    var outlet = _deliveryToOutletSearchView.GetOutlet();
                    _deliveryToOutletSearchView.EnableSearchButton(
                        outlet==null ?
                        false
                        : true);
                    break;
                case DeliveryToOutletSearchMode.DeliveryDate:
                    _deliveryToOutletSearchView.EnableSearchButton(true);
                    break;
                                    
            }
        }
    }
}
