using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Model;

namespace SGInventory.UserControls
{
    public partial class ucPriceHistory : UserControl
    {
        public ucPriceHistory()
        {
            InitializeComponent();
        }

        internal void PutPriceHistoryCollectionToControl<TPriceHistory>(IList<TPriceHistory> priceHistories) where TPriceHistory: ICreated,IPrices
        {
            var prices = priceHistories.ToList<TPriceHistory>();
            prices.ForEach(p => 
            {
                txtBoxPriceHistory.AppendText(
                    string.Format("Cost:{0}, Regular Price:{1}, Markdown Price:{2} by {3} on {4} {5}"
                    , p.Cost
                    , p.RegularPrice
                    , p.MarkdownPrice
                    , p.CreatedBy
                    , p.CreatedDate
                    , Environment.NewLine
                    ));
                    
            });
        }
    }
}
