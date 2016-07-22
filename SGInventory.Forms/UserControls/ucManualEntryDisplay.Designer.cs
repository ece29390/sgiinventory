namespace SGInventory.UserControls
{
    partial class ucManualEntryDisplay
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkBarcodeOrStockNumber = new System.Windows.Forms.CheckBox();
            this.StockNumberComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblStockOrBarcode = new System.Windows.Forms.Label();
            this.ColorAutoComplete = new SGInventory.UserControls.ucAutoComplete();
            this.WashingAutoComplete = new SGInventory.UserControls.ucAutoComplete();
            this.SizeAutoComplete = new SGInventory.UserControls.ucAutoComplete();
            this.SuspendLayout();
            // 
            // chkBarcodeOrStockNumber
            // 
            this.chkBarcodeOrStockNumber.AutoSize = true;
            this.chkBarcodeOrStockNumber.Checked = true;
            this.chkBarcodeOrStockNumber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBarcodeOrStockNumber.Location = new System.Drawing.Point(3, 3);
            this.chkBarcodeOrStockNumber.Name = "chkBarcodeOrStockNumber";
            this.chkBarcodeOrStockNumber.Size = new System.Drawing.Size(124, 17);
            this.chkBarcodeOrStockNumber.TabIndex = 28;
            this.chkBarcodeOrStockNumber.Text = "Search By Barcode?";
            this.chkBarcodeOrStockNumber.UseVisualStyleBackColor = true;
            this.chkBarcodeOrStockNumber.CheckedChanged += new System.EventHandler(this.chkBarcodeOrStockNumber_CheckedChanged);
            // 
            // StockNumberComboBox
            // 
            this.StockNumberComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.StockNumberComboBox.FormattingEnabled = true;
            this.StockNumberComboBox.Location = new System.Drawing.Point(116, 30);
            this.StockNumberComboBox.Name = "StockNumberComboBox";
            this.StockNumberComboBox.Size = new System.Drawing.Size(205, 72);
            this.StockNumberComboBox.Sorted = true;
            this.StockNumberComboBox.TabIndex = 32;
            this.StockNumberComboBox.SelectedIndexChanged += new System.EventHandler(this.StockNumberComboBox_SelectedIndexChanged);
            this.StockNumberComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StockNumberComboBox_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(-1, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 17);
            this.label8.TabIndex = 31;
            this.label8.Text = "Color:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 17);
            this.label7.TabIndex = 29;
            this.label7.Text = "Washing:";
            this.label7.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 27;
            this.label6.Text = "Size:";
            // 
            // lblStockOrBarcode
            // 
            this.lblStockOrBarcode.AutoSize = true;
            this.lblStockOrBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockOrBarcode.Location = new System.Drawing.Point(3, 30);
            this.lblStockOrBarcode.Name = "lblStockOrBarcode";
            this.lblStockOrBarcode.Size = new System.Drawing.Size(73, 17);
            this.lblStockOrBarcode.TabIndex = 26;
            this.lblStockOrBarcode.Text = "Barcode:";
            // 
            // ColorAutoComplete
            // 
            this.ColorAutoComplete.AutoCompleteValue = "";
            this.ColorAutoComplete.Location = new System.Drawing.Point(116, 108);
            this.ColorAutoComplete.Name = "ColorAutoComplete";
            this.ColorAutoComplete.Size = new System.Drawing.Size(205, 21);
            this.ColorAutoComplete.TabIndex = 33;
            this.ColorAutoComplete.Leave += new System.EventHandler(this.ColorAutoComplete_Leave);
            // 
            // WashingAutoComplete
            // 
            this.WashingAutoComplete.AutoCompleteValue = "";
            this.WashingAutoComplete.Location = new System.Drawing.Point(115, 162);
            this.WashingAutoComplete.Name = "WashingAutoComplete";
            this.WashingAutoComplete.Size = new System.Drawing.Size(205, 21);
            this.WashingAutoComplete.TabIndex = 35;
            this.WashingAutoComplete.Visible = false;
            this.WashingAutoComplete.Leave += new System.EventHandler(this.WashingAutoComplete_Leave);
            // 
            // SizeAutoComplete
            // 
            this.SizeAutoComplete.AutoCompleteValue = "";
            this.SizeAutoComplete.Location = new System.Drawing.Point(115, 135);
            this.SizeAutoComplete.Name = "SizeAutoComplete";
            this.SizeAutoComplete.Size = new System.Drawing.Size(205, 21);
            this.SizeAutoComplete.TabIndex = 34;
            this.SizeAutoComplete.Leave += new System.EventHandler(this.SizeAutoComplete_Leave);
            // 
            // ucManualEntryDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkBarcodeOrStockNumber);
            this.Controls.Add(this.StockNumberComboBox);
            this.Controls.Add(this.ColorAutoComplete);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.WashingAutoComplete);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SizeAutoComplete);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblStockOrBarcode);
            this.Name = "ucManualEntryDisplay";
            this.Size = new System.Drawing.Size(325, 185);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkBarcodeOrStockNumber;
        private System.Windows.Forms.ComboBox StockNumberComboBox;
        private ucAutoComplete ColorAutoComplete;
        private System.Windows.Forms.Label label8;
        private ucAutoComplete WashingAutoComplete;
        private System.Windows.Forms.Label label7;
        private ucAutoComplete SizeAutoComplete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblStockOrBarcode;
    }
}
