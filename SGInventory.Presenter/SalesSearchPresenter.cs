using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Business.Model;
using SGInventory.Views;
using SGInventory.Presenters.Model;
using SGInventory.Model;
using AutoMapper;
using SGInventory.Extensions;

namespace SGInventory.Presenters
{
    public class SalesSearchPresenter
    {
        private ISalesBusinessModel _salesBusinessModel;        
        private IOutletBusinessModel _iOutletBusinessModel;
        private ISalesSearchView _view;
        
        public SalesSearchPresenter(
            ISalesBusinessModel salesbusinessmodel
            ,IOutletBusinessModel outletbusinessmodel
            ,ISalesSearchView view
            )
        {          
            _salesBusinessModel = salesbusinessmodel;
            _iOutletBusinessModel = outletbusinessmodel;
            _view = view;
        }

        public void Initialize()
        {
            var outlets = _iOutletBusinessModel.SelectAll();
            _view.LoadOutlets(outlets);

            var sales = new List<Sales>();
            _view.LoadSales(sales);

            var sale = new Sales();
            _view.LoadSales(sale);



        }

        public void Search()
        {
            Sales sales = _view.GetSales();
            List<Sales> existingSales = sales.Outlet != null ? _salesBusinessModel.SelectByOutletAndDateOfSales(sales) : _salesBusinessModel.SelectByDateOfSales(sales);                                
            _view.LoadSales(existingSales);
        }

        public List<SalesDisplayModel> ConvertToListOfSalesDisplayModel(List<Sales> sales)
        {
            var retValue = sales.ToSpecifiedTypeUsingAutoMapper<List<Sales>, List<SalesDisplayModel>>();
            return retValue;
        }
    }
}
