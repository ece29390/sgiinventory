using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;

namespace SGInventory.UserControls
{
    public partial class ucItemEditMenu : UserControl
    {
        public event EventHandler OnDeleteToolStripMenuItem,
                                  OnUpdateToolStripMenuItem,
                                  OnCancelToolStripMenuItem;
        public ucItemEditMenu()
        {
            InitializeComponent();
        }

        
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OnDeleteToolStripMenuItem != null)
            {
                OnDeleteToolStripMenuItem(sender, e);
            }
        }

        
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OnUpdateToolStripMenuItem != null)
            {
                OnUpdateToolStripMenuItem(sender, e);
            }
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OnCancelToolStripMenuItem != null)
            {
                OnCancelToolStripMenuItem(sender, e);
            }
        }

        private void EnableToolStripMenuItem(ToolStripMenuItem menuItem, bool shouldEnable)
        {
            menuItem.Enabled = shouldEnable;
        }

        public void EnableDeleteMenuItem(bool shouldEnable)
        {
            EnableToolStripMenuItem(deleteToolStripMenuItem, shouldEnable);
        }

        public void EnableEditMenuItem(bool shouldEnable)
        {
            EnableToolStripMenuItem(updateToolStripMenuItem, shouldEnable);
        }

        public void CancelMenuItem(bool shouldEnable)
        {
            EnableToolStripMenuItem(cancelToolStripMenuItem, shouldEnable);
        }
    }
}
