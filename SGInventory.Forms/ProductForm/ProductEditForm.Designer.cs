namespace SGInventory.ProductForm
{
    partial class ProductEditForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucSaveEditForm1 = new SGInventory.UserControls.ucSaveEditForm();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblAddress = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.lblWashing = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.CostControl = new SGInventory.UserControls.NumericControl();
            this.lblColor = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.markdownPriceControl = new SGInventory.UserControls.NumericControl();
            this.RegulaPriceControl = new SGInventory.UserControls.NumericControl();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkListboxSizes = new System.Windows.Forms.CheckedListBox();
            this.ucDescription1 = new SGInventory.UserControls.ucDescription();
            this.ucCode1 = new SGInventory.UserControls.ucCode();
            this.menuStripUpload = new System.Windows.Forms.MenuStrip();
            this.uploadPictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.priceHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStripUpload.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucSaveEditForm1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 535);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(436, 51);
            this.panel1.TabIndex = 0;
            // 
            // ucSaveEditForm1
            // 
            this.ucSaveEditForm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucSaveEditForm1.Location = new System.Drawing.Point(346, 4);
            this.ucSaveEditForm1.Margin = new System.Windows.Forms.Padding(4);
            this.ucSaveEditForm1.Name = "ucSaveEditForm1";
            this.ucSaveEditForm1.Size = new System.Drawing.Size(79, 44);
            this.ucSaveEditForm1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.ucDescription1);
            this.panel2.Controls.Add(this.ucCode1);
            this.panel2.Controls.Add(this.menuStripUpload);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(436, 535);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblAddress);
            this.panel3.Controls.Add(this.categoryComboBox);
            this.panel3.Controls.Add(this.lblWashing);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.CostControl);
            this.panel3.Controls.Add(this.lblColor);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.markdownPriceControl);
            this.panel3.Controls.Add(this.RegulaPriceControl);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 140);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(436, 163);
            this.panel3.TabIndex = 15;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(3, 3);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(78, 17);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "Category:";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(103, 6);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(321, 21);
            this.categoryComboBox.TabIndex = 3;
            // 
            // lblWashing
            // 
            this.lblWashing.AutoSize = true;
            this.lblWashing.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWashing.Location = new System.Drawing.Point(6, 58);
            this.lblWashing.Name = "lblWashing";
            this.lblWashing.Size = new System.Drawing.Size(75, 17);
            this.lblWashing.TabIndex = 6;
            this.lblWashing.Text = "Washing:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(101, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 17);
            this.label10.TabIndex = 8;
            this.label10.Text = "Cost:";
            // 
            // CostControl
            // 
            this.CostControl.Location = new System.Drawing.Point(232, 80);
            this.CostControl.Name = "CostControl";
            this.CostControl.Numeric = 0D;
            this.CostControl.Size = new System.Drawing.Size(106, 22);
            this.CostControl.TabIndex = 9;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.Location = new System.Drawing.Point(30, 30);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(51, 17);
            this.lblColor.TabIndex = 4;
            this.lblColor.Text = "Color:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(101, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 17);
            this.label11.TabIndex = 10;
            this.label11.Text = "Regular Price:";
            // 
            // markdownPriceControl
            // 
            this.markdownPriceControl.Location = new System.Drawing.Point(232, 135);
            this.markdownPriceControl.Name = "markdownPriceControl";
            this.markdownPriceControl.Numeric = 0D;
            this.markdownPriceControl.Size = new System.Drawing.Size(106, 22);
            this.markdownPriceControl.TabIndex = 13;
            // 
            // RegulaPriceControl
            // 
            this.RegulaPriceControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RegulaPriceControl.Location = new System.Drawing.Point(232, 108);
            this.RegulaPriceControl.Name = "RegulaPriceControl";
            this.RegulaPriceControl.Numeric = 0D;
            this.RegulaPriceControl.Size = new System.Drawing.Size(106, 22);
            this.RegulaPriceControl.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(99, 135);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 17);
            this.label12.TabIndex = 12;
            this.label12.Text = "Markdown Price:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkListboxSizes);
            this.groupBox1.Location = new System.Drawing.Point(0, 303);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 226);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sizes";
            // 
            // chkListboxSizes
            // 
            this.chkListboxSizes.CheckOnClick = true;
            this.chkListboxSizes.FormattingEnabled = true;
            this.chkListboxSizes.Location = new System.Drawing.Point(6, 19);
            this.chkListboxSizes.MultiColumn = true;
            this.chkListboxSizes.Name = "chkListboxSizes";
            this.chkListboxSizes.Size = new System.Drawing.Size(424, 199);
            this.chkListboxSizes.TabIndex = 15;
            // 
            // ucDescription1
            // 
            this.ucDescription1.Description = "";
            this.ucDescription1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucDescription1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucDescription1.Location = new System.Drawing.Point(0, 51);
            this.ucDescription1.Name = "ucDescription1";
            this.ucDescription1.Size = new System.Drawing.Size(436, 89);
            this.ucDescription1.TabIndex = 1;
            // 
            // ucCode1
            // 
            this.ucCode1.Code = "";
            this.ucCode1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucCode1.Location = new System.Drawing.Point(0, 24);
            this.ucCode1.Name = "ucCode1";
            this.ucCode1.Size = new System.Drawing.Size(436, 27);
            this.ucCode1.TabIndex = 0;
            // 
            // menuStripUpload
            // 
            this.menuStripUpload.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uploadPictureToolStripMenuItem,
            this.priceHistoryToolStripMenuItem});
            this.menuStripUpload.Location = new System.Drawing.Point(0, 0);
            this.menuStripUpload.Name = "menuStripUpload";
            this.menuStripUpload.Size = new System.Drawing.Size(436, 24);
            this.menuStripUpload.TabIndex = 16;
            this.menuStripUpload.Text = "Upload Picture";
            // 
            // uploadPictureToolStripMenuItem
            // 
            this.uploadPictureToolStripMenuItem.Name = "uploadPictureToolStripMenuItem";
            this.uploadPictureToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.uploadPictureToolStripMenuItem.Text = "Upload Picture";
            this.uploadPictureToolStripMenuItem.Click += new System.EventHandler(this.uploadPictureToolStripMenuItem_Click);
            // 
            // priceHistoryToolStripMenuItem
            // 
            this.priceHistoryToolStripMenuItem.Name = "priceHistoryToolStripMenuItem";
            this.priceHistoryToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.priceHistoryToolStripMenuItem.Text = "Price History";
            this.priceHistoryToolStripMenuItem.Click += new System.EventHandler(this.priceHistoryToolStripMenuItem_Click);
            // 
            // ProductEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 586);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStripUpload;
            this.Name = "ProductEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Edit";
            this.Load += new System.EventHandler(this.ProductEditForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.menuStripUpload.ResumeLayout(false);
            this.menuStripUpload.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private UserControls.ucSaveEditForm ucSaveEditForm1;
        private System.Windows.Forms.Panel panel2;
        private UserControls.ucDescription ucDescription1;
        private UserControls.ucCode ucCode1;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label lblAddress;
        private UserControls.NumericControl markdownPriceControl;
        private System.Windows.Forms.Label label12;
        private UserControls.NumericControl RegulaPriceControl;
        private System.Windows.Forms.Label label11;
        private UserControls.NumericControl CostControl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblWashing;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckedListBox chkListboxSizes;
        private System.Windows.Forms.MenuStrip menuStripUpload;
        private System.Windows.Forms.ToolStripMenuItem uploadPictureToolStripMenuItem;
        private UserControls.ucAutoComplete ucAutoCompleteWashing;
        private UserControls.ucAutoComplete ucAutoCompleteColor;
        private System.Windows.Forms.ToolStripMenuItem priceHistoryToolStripMenuItem;
    }
}