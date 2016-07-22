using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace SGInventory.Presenters
{
    public class ColorPresenter
    {
        public void LoadAllColors(System.Windows.Forms.DataGridView dataGridView)
        {
            Array knownColors = Enum.GetValues(typeof(KnownColor));

            Color color;
            var rowIndex = 0;
            foreach (var knownColor in knownColors)
            {
                color = Color.FromKnownColor((KnownColor)knownColor);                
                dataGridView.Rows.Add(color.Name);
                dataGridView.Rows[rowIndex].Cells[1].Style.BackColor = color;
                rowIndex++;
            }

            dataGridView.Rows.Add("Others");

       }
    }
}
