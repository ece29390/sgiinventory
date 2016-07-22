using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Presenters.Model;

namespace SGInventory.Presenters
{
    public class DisplaySalesArg:EventArgs
    {
        public List<SalesDisplayModel> ListOfSalesForDisplay { get; private set; }

        public DisplaySalesArg(List<SalesDisplayModel> salesdisplaymodels)
        {
            ListOfSalesForDisplay = salesdisplaymodels;
        }
    }
}
