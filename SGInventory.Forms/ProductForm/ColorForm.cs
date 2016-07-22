using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Presenters;

namespace SGInventory.ProductForm
{
    public partial class ColorForm : Form
    {
        ColorPresenter _colorPresenter;
        public string SelectedColor { get; private set; }

        public ColorForm()
        {
            InitializeComponent();
            _colorPresenter = new ColorPresenter();
        }

        private void dgvColors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var name = dgvColors.Rows[e.RowIndex].Cells[0].Value.ToString();
            SelectedColor = name;
            this.Close();
        }

        private void ColorForm_Load(object sender, EventArgs e)
        {
            _colorPresenter.LoadAllColors(this.dgvColors);
        }

        private void dgvColors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var name = dgvColors.Rows[e.RowIndex].Cells[0].Value.ToString();
            SelectedColor = name;
            this.Close();
        }
    }
}
