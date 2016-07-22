using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SGInventory.UserControls
{
    public partial class ucAddDelete : UserControl
    {
        public event EventHandler<EventArgs> DeleteButtonClick;
        public event EventHandler<EventArgs> AddButtonClick;
        public ucAddDelete()
        {
            InitializeComponent();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (DeleteButtonClick != null)
            {
                DeleteButtonClick(sender, e);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (AddButtonClick != null)
            {
                AddButtonClick(sender, e);
            }
        }
    }
}
