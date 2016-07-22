using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Model;
using Microsoft.Reporting.WinForms;

namespace SGInventory.Delivery
{
    public partial class DeliveryToOutletPrintForm : Form
    {
        private BusinessModelContainer _container;
        private int _deliveryToOutletId;

        public DeliveryToOutletPrintForm(
            BusinessModelContainer container, 
            int deliveryToOutletId)
        {
            InitializeComponent();

            _container = container;
            _deliveryToOutletId = deliveryToOutletId;
        }

        private void DeliveryToOutletPrintForm_Load(object sender, EventArgs e)
        {
            var deliveryToOutlet = _container.DeliveryToOutletBusinessModel.SelectByPrimaryId(_deliveryToOutletId);

            var deliveryToOutletReportModelList = (from d in deliveryToOutlet.DeliveryToOutletDetails
                                                   group d by new { d.ProductDetail.Product.StockNumber,d.SuggestedRetailPrice } into dGroup
                                                   select new DeliveryToOutletReport 
                                                   { 
                                                       StockNumber = dGroup.Key.StockNumber
                                                       ,Quantity = dGroup.Sum(dOut=>dOut.Quantity)
                                                       ,Price = dGroup.Key.SuggestedRetailPrice
                                                   }).ToList();
           
            var reportParameters = new List<ReportParameter>
            {
                new ReportParameter("outlet_param")
                ,new ReportParameter("transaction_date_param")
                ,new ReportParameter("outlet_address_param")
            };

            reportParameters[0].Values.Add(deliveryToOutlet.Outlet.Name);
            reportParameters[1].Values.Add(deliveryToOutlet.DeliveryDate.ToShortDateString());
            reportParameters[2].Values.Add(deliveryToOutlet.Outlet.Address);
            
            reportViewer1.LocalReport.ReportEmbeddedResource = "SGInventory.Delivery.DeliveryToOutletReport.rdlc";
            reportViewer1.LocalReport.SetParameters(reportParameters);
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource
                {
                    Name = "DeliveryToOutletDs"
                    ,
                    Value = deliveryToOutletReportModelList
                });

            this.reportViewer1.RefreshReport();
        }
    }
}
