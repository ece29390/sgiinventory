using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Views;

namespace SGInventory.UserControls
{
    public partial class UcDateRangeFilter : UserControl,IDateRangeFilter
    {
        public UcDateRangeFilter()
        {
            InitializeComponent();
        }

        public DateTime GetDeliveryDateFrom()
        {
            return dtpDeliveryDate.Value;
        }

        public DateTime GetDeliveryDateTo()
        {
            return dtpDateTo.Value;
        }
    }
}
