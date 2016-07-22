using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Drawing;
using System.Windows.Forms;
using SGInventory.Presenters;

namespace SGInventory.Presenters.Test
{
    [TestClass]
    public class ColorPresenterTest
    {
        private System.Windows.Forms.DataGridView dgvColors;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActualColor;

        public ColorPresenterTest()
        {
            this.dgvColors = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActualColor = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.dgvColors.AllowUserToAddRows = false;
            this.dgvColors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colActualColor});
            this.dgvColors.Location = new System.Drawing.Point(1, 3);
            this.dgvColors.Name = "dgvColors";
            this.dgvColors.RowHeadersVisible = false;
            this.dgvColors.Size = new System.Drawing.Size(732, 400);
            this.dgvColors.TabIndex = 0;
            
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 250;
            // 
            // colActualColor
            // 
            this.colActualColor.HeaderText = "";
            this.colActualColor.Name = "colActualColor";
            this.colActualColor.Width = 400;
            // 
        }

        [TestMethod]
        public void LoadAllColors_Test()
        {                                   
            var colorPresenter = new ColorPresenter();

            
            colorPresenter.LoadAllColors(dgvColors);

            var colors = Enum.GetValues(typeof(KnownColor));

            Assert.AreEqual(colors.Length + 1, dgvColors.RowCount);
            
        }
    }
}
