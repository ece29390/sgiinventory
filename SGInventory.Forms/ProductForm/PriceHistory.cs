using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SGInventory.ProductForm
{
    public partial class PriceHistory : Form
    {
        private List<Model.ProductPricesHistory> _list;

        public PriceHistory()
        {
            InitializeComponent();
        }

        public PriceHistory(List<Model.ProductPricesHistory> list)
        {         
            this._list = list;
            InitializeComponent();
        }

        private void PriceHistory_Load(object sender, EventArgs e)
        {
            ucPriceHistory1.PutPriceHistoryCollectionToControl(_list);
        }


    }
}
