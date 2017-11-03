﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Dal;

namespace SGInventory.Business.Model
{
    public class SalesBusinessModel:ISalesBusinessModel
    {
        private ISalesDal _salesDal;
        public SalesBusinessModel(ISalesDal salesdal)
        {
            _salesDal = salesdal;
        }

        public Sales SelectBy(int salesid)
        {
            var sales = _salesDal.SelectPrimaryEntity(salesid);
            return sales;
        }

        public void Save(Sales sales)
        {
            _salesDal.SaveOrUpdate(sales);
        }


        public List<Sales> SelectByOutletAndDateOfSales(Sales sales)
        {
            var listOfSales = _salesDal.SelectBy(sales.DateOfSales, sales.Outlet);
            return listOfSales;
        }

        public Sales SelectByOutletDateOfSalesProductDetail(Sales sales)
        {
            var retSales = _salesDal.SelectBy(sales.DateOfSales, sales.Outlet, sales.ProductDetail);
            return retSales;
        }

        public void Delete(Sales sales)
        {
            _salesDal.Delete(sales);
        }


        public List<Sales> SelectByDateOfSales(Sales sales)
        {
           return _salesDal.SelectBy(sales.DateOfSales);
        }
        public int GetTotalQuantityPerOutlet(int outletId)
        {
            var listOfSales = _salesDal.SelectBy(outletId);
            var totalQuantity = listOfSales.Sum(s => s.Quantity);
            return totalQuantity;
        }
    }
}
