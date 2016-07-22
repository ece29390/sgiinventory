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
    public partial class ucNameAddress : UserControl
    {
        public event EventHandler<DataGridViewCellEventArgs> OnCellContentClick;
        public ucNameAddress()
        {
            InitializeComponent();
            NameAddressDataGridView.AutoGenerateColumns = false;
        }

        private void NameAddressDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (OnCellContentClick != null)
            {
                OnCellContentClick(this, e);
            }
        }

        public void LoadData<T>(List<T> models)
        {
            NameAddressDataGridView.DataSource = models;
        }

        public DataGridView NameAddressView
        {
            get{return this.NameAddressDataGridView;}
        }
    }

    
}
