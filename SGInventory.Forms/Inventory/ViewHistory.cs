using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SGInventory.Model;
using SGInventory.Enums;

namespace SGInventory.Inventory
{
    public partial class ViewHistory : Form
    {
        public event EventHandler OnFormClosing;
        private readonly ProductInventoryView _productInventoryView;
        private BusinessModelContainer _container;       
        private Adjustment _adjustmentForm;
        public ViewHistory(ProductInventoryView productInventoryView, BusinessModelContainer container)
        {
            InitializeComponent();
            _productInventoryView = productInventoryView;
            _container = container;
            dgViewHistory.AutoGenerateColumns = false;
            
        }

        private void ViewHistory_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now.AddMonths(-3);
            dtpTo.Value = DateTime.Now;
            InitializeAdjustmentProductForm();
            Text = string.Format("{0} of Stock Number:[{1}] Color:[{2}] Size:[{3}]",
                Text
                ,_productInventoryView.StockNumber
                , _productInventoryView.ColorName
                , _productInventoryView.SizeName
                );
            LoadTransactionBySearchDate(dtpFrom.Value, dtpTo.Value);
        }

        public void InitializeAdjustmentProductForm()
        {            
            _adjustmentForm = new Adjustment(_productInventoryView.ProductDetailCode, _container);
            _adjustmentForm.OnDelete += new EventHandler(_adjustmentForm_OnDelete);
            _adjustmentForm.OnSave += new EventHandler(_adjustmentForm_OnSave);
        }

        void _adjustmentForm_OnSave(object sender, EventArgs e)
        {
            LoadTransactionBySearchDate(dtpFrom.Value, dtpTo.Value);
        }

        void _adjustmentForm_OnDelete(object sender, EventArgs e)
        {
            LoadTransactionBySearchDate(dtpFrom.Value, dtpTo.Value);
        }

        void _adjustmentProductForm_OnDelete(object sender, EventArgs e)
        {            
            LoadTransactionBySearchDate(dtpFrom.Value, dtpTo.Value);
        }

        void _adjustmentProductForm_OnSave(object sender, EventArgs e)
        {
            LoadTransactionBySearchDate(dtpFrom.Value, dtpTo.Value);
        }

        private void LoadTransactionBySearchDate(DateTime from, DateTime to)
        {
            var listOfViewHistoryReport = new List<ViewHistoryReport>();
            var historyReportSuppliers = new List<ViewHistoryReport>();
            var historyReportOutlets = new List<ViewHistoryReport>();

            var finalFrom = Convert.ToDateTime(string.Concat(from.ToShortDateString(), " ", "12:00:00 AM"));
            var finalTo = Convert.ToDateTime(string.Concat(to.ToShortDateString(), " ", "11:59:59 PM"));

            var deliveryFromSupplier = _container.DeliveryBusinessModel.GetDeliveryDetailBy(_productInventoryView.ProductDetailCode, finalFrom, finalTo, true);
            historyReportSuppliers = deliveryFromSupplier.Select(ds =>
                new ViewHistoryReport
                {
                    DeliveryDescription = ds.Quantity<0?ds.AdjustmentRemarks: BuildIncomingDescription(ds)
                    ,Entity = ds.Delivery!=null?ds.Delivery.Supplier.Name:ds.AdjustmentRemarks
                    ,Quantity = ds.Quantity
                    ,IsManuallyAdjusted = ds.AdjustmentDate.HasValue
                    ,TransactionDate = !ds.AdjustmentDate.HasValue ? ds.Delivery.DeliveryDate : ds.AdjustmentDate.Value
                    ,IsDeliveryIncoming = true     
                    ,EntityId = ds.Id
                }).ToList();

            var deliveryToOutlet = _container.DeliveryToOutletBusinessModel.GetDeliveryToOutletDetailBy(_productInventoryView.ProductDetailCode, finalFrom, finalTo, true);
            historyReportOutlets = deliveryToOutlet.Select(ds =>
                new ViewHistoryReport
                {
                    DeliveryDescription = ds.Quantity<0? ds.AdjustmentRemarks:"Delivery Sent"
                    ,
                    Entity = ds.DeliveryToOutlet!=null?ds.DeliveryToOutlet.Outlet.Name:ds.AdjustmentRemarks
                    ,Quantity = ds.Quantity
                    ,
                    TransactionDate = !ds.AdjustmentDate.HasValue?ds.DeliveryToOutlet.DeliveryDate:ds.AdjustmentDate.Value
                    ,IsManuallyAdjusted = ds.AdjustmentDate.HasValue
                    ,EntityId = ds.Id
                }).ToList();

            listOfViewHistoryReport.AddRange(historyReportSuppliers);
            listOfViewHistoryReport.AddRange(historyReportOutlets);
            listOfViewHistoryReport.Sort();

            dgViewHistory.DataSource = listOfViewHistoryReport;

        }

        private string BuildIncomingDescription(DeliveryDetail deliveryDetail)
        {
            var description = "Delivery Received;{0}";

            if (deliveryDetail.Status == 1)
            {
                var goodDescription = Enum.GetName(typeof(ProductStatus), ProductStatus.Goods);
                description = string.Format(description, goodDescription);
            }
            else
            {
                var badDescription = Enum.GetName(typeof(ProductStatus), ProductStatus.Damaged);
                description = string.Format(description, badDescription);
                var damageStatus = Enum.ToObject(typeof(Damage), deliveryDetail.Damage.Value);
                var damageDescription = Enum.GetName(typeof(Damage), damageStatus);
                description = string.Concat(description, "(", damageDescription, ")");
            }

            return description;
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            var rb = (RadioButton)sender;

            var enable = rb.Name == rbDateRange.Name;

            dtpFrom.Enabled = enable;
            dtpTo.Enabled = enable;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (dtpFrom.Value >= dtpTo.Value)
            {
                MessageBox.Show("To Date should be later than From Date");
                return;
            }

            DateTime from,to;

            from = rbSearch3Months.Checked ? DateTime.Now.AddMonths(-3) : dtpFrom.Value;
            to = rbSearch3Months.Checked ? DateTime.Now : dtpTo.Value;

            LoadTransactionBySearchDate(from, to);
        }

        

        private void dgViewHistory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgViewHistory.Rows)
            {
                var viewHistoryReport = (ViewHistoryReport)row.DataBoundItem;

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    row.Cells[i].Style.BackColor = viewHistoryReport.IsDeliveryIncoming ? System.Drawing.Color.Aqua :
                    System.Drawing.Color.Pink;
                    if (viewHistoryReport.IsManuallyAdjusted)
                    {
                        row.Cells[i].ToolTipText = "Click to edit the manually adjusted item";
                    }
                }                                
            }
        }
       
        private void dgViewHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var viewHistoryReport = (ViewHistoryReport)dgViewHistory.Rows[e.RowIndex].DataBoundItem;

                if (viewHistoryReport.IsManuallyAdjusted)
                {
                    if (viewHistoryReport.IsDeliveryIncoming)
                    {
                        _adjustmentForm
                            .AttachId(viewHistoryReport.EntityId)
                            .AttachDeliveryComing(viewHistoryReport.IsDeliveryIncoming)
                            .ShowDialog();
                    }
                    else
                    {
                        _adjustmentForm
                            .AttachId(viewHistoryReport.EntityId)
                            .AttachDeliveryComing(viewHistoryReport.IsDeliveryIncoming)
                            .ShowDialog();
                    }
                }
                                             
            }
        }

        private void ViewHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (OnFormClosing != null)
            {
                OnFormClosing(sender, e);
            }
        }

        private void adjustmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _adjustmentForm.ShowDialog();
        }
    }
}
