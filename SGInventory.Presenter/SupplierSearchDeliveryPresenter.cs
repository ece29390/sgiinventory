using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Business.Model.Exception;
using SGInventory.Helpers;
using SGInventory.Enums;
using SGInventory.Model;
using SGInventory.Views;

namespace SGInventory.Presenters
{
    public class SupplierSearchDeliveryPresenter
    {
        private ISupplierSearchDeliveryView _supplierSearchDeliveryView;      
        private Business.Model.ISupplierBusinessModel _supplierBusinessModel;
        private Business.Model.IDeliveryBusinessModel _deliveryBusinessModel;

        public SupplierSearchDeliveryPresenter(
            ISupplierSearchDeliveryView iSupplierSearchDeliveryView
            , Business.Model.ISupplierBusinessModel supplierBusinessModel
            , Business.Model.IDeliveryBusinessModel deliveryBusinessModel
            )
        {           
           _supplierSearchDeliveryView = iSupplierSearchDeliveryView;
           _supplierBusinessModel = supplierBusinessModel;
           _deliveryBusinessModel = deliveryBusinessModel;
        }
      
        public void InitialLoad()
        {
            var suppliers = _supplierBusinessModel.SelectAll();
            _supplierSearchDeliveryView.LoadSuppliers(suppliers);

            var searchModes = SgiHelper.ConvertEnumToList<SupplierSearchDeliveryMode>(
                                                        () => Enum.GetValues(typeof(SupplierSearchDeliveryMode)),
                                                        (enumItem) => (SupplierSearchDeliveryMode)enumItem);

            _supplierSearchDeliveryView.LoadSearchMode(searchModes);
        }

        public void Search()
        {
            try
            {
                var supplierSearchDeliveryMode = _supplierSearchDeliveryView.GetSearchMode();
                var searchLists = new List<Delivery>();

                switch (supplierSearchDeliveryMode)
                {
                    case SupplierSearchDeliveryMode.Supplier:
                        searchLists =
                            _deliveryBusinessModel.SelectBySupplier(_supplierSearchDeliveryView.GetSupplierName());
                        break;
                    case SupplierSearchDeliveryMode.DeliveryDate:
                        var dateFrom = _supplierSearchDeliveryView.GetDeliveryDateFrom();
                        DateTime dateTo = _supplierSearchDeliveryView.GetDeliveryDateTo();
                        if (dateFrom > dateTo)
                        {
                            _supplierSearchDeliveryView.ShowMessage(
                                "The Delivery Date From must be earlier than Delivery Date To");
                        }
                        else
                        {
                            searchLists = _deliveryBusinessModel.SelectByDeliveryDate(dateFrom, dateTo);
                        }
                        break;
                    case SupplierSearchDeliveryMode.Both:
                        searchLists = _deliveryBusinessModel.SelectByBoth(
                            _supplierSearchDeliveryView.GetSupplierName(),
                            _supplierSearchDeliveryView.GetDeliveryDateFrom());
                        break;
                }

                _supplierSearchDeliveryView.LoadSearchDeliveries(searchLists);
            }         
            catch (Exception ex)
            {
                _supplierSearchDeliveryView.ShowMessage(ex.Message);               
            }
            
        }

        public void LoadSelectedDelivery(int selectedIndex)
        {
            var delivery = _supplierSearchDeliveryView.GetSelectedDelivery(selectedIndex);
            _supplierSearchDeliveryView.OpenSupplierDeliveryEditForm(delivery);
        }

        public void OnSelectedSearchModeChange(SupplierSearchDeliveryMode supplierSearchDeliveryMode)
        {
            switch (supplierSearchDeliveryMode)
            {
                case SupplierSearchDeliveryMode.Both:
                case SupplierSearchDeliveryMode.Supplier:
                    _supplierSearchDeliveryView.EnableSearchButton(
                        string.IsNullOrEmpty(_supplierSearchDeliveryView.GetSupplierName()) ?
                        false
                        : true);
                    break;
                case SupplierSearchDeliveryMode.DeliveryDate:
                    _supplierSearchDeliveryView.EnableSearchButton(true);
                    break;
                                    
            }
        }
    }
}
