namespace SGInventory.ProductForm
{
    partial class ProductDetailEditForm
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
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.QuantityTextbox = new System.Windows.Forms.TextBox();
            this.ucSaveEditForm1 = new SGInventory.UserControls.ucSaveEditForm();
            this.ColorAutoComplete = new SGInventory.UserControls.ucAutoComplete();
            this.WashingAutoComplete = new SGInventory.UserControls.ucAutoComplete();
            this.SizeAutoComplete = new SGInventory.UserControls.ucAutoComplete();
            this.pictureBoxProductDetail = new System.Windows.Forms.PictureBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.numericControl1 = new SGInventory.UserControls.NumericControl();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStockNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProductDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Color:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Washing:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Size:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 138);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(138, 17);
            this.label13.TabIndex = 23;
            this.label13.Text = "Quantity on hand:";
            // 
            // QuantityTextbox
            // 
            this.QuantityTextbox.Location = new System.Drawing.Point(139, 138);
            this.QuantityTextbox.Name = "QuantityTextbox";
            this.QuantityTextbox.Size = new System.Drawing.Size(257, 20);
            this.QuantityTextbox.TabIndex = 17;
            this.QuantityTextbox.TextChanged += new System.EventHandler(this.QuantityTextbox_TextChanged);
            this.QuantityTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.QuantityTextbox_KeyPress);
            // 
            // ucSaveEditForm1
            // 
            this.ucSaveEditForm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucSaveEditForm1.Location = new System.Drawing.Point(316, 433);
            this.ucSaveEditForm1.Margin = new System.Windows.Forms.Padding(4);
            this.ucSaveEditForm1.Name = "ucSaveEditForm1";
            this.ucSaveEditForm1.Size = new System.Drawing.Size(79, 44);
            this.ucSaveEditForm1.TabIndex = 19;
            // 
            // ColorAutoComplete
            // 
            this.ColorAutoComplete.AutoCompleteValue = "";
            this.ColorAutoComplete.Location = new System.Drawing.Point(87, 35);
            this.ColorAutoComplete.Name = "ColorAutoComplete";
            this.ColorAutoComplete.Size = new System.Drawing.Size(318, 21);
            this.ColorAutoComplete.TabIndex = 9;
            // 
            // WashingAutoComplete
            // 
            this.WashingAutoComplete.AutoCompleteValue = "";
            this.WashingAutoComplete.Location = new System.Drawing.Point(87, 63);
            this.WashingAutoComplete.Name = "WashingAutoComplete";
            this.WashingAutoComplete.Size = new System.Drawing.Size(313, 21);
            this.WashingAutoComplete.TabIndex = 11;
            // 
            // SizeAutoComplete
            // 
            this.SizeAutoComplete.AutoCompleteValue = "";
            this.SizeAutoComplete.Location = new System.Drawing.Point(87, 89);
            this.SizeAutoComplete.Name = "SizeAutoComplete";
            this.SizeAutoComplete.Size = new System.Drawing.Size(313, 21);
            this.SizeAutoComplete.TabIndex = 13;
            // 
            // pictureBoxProductDetail
            // 
            this.pictureBoxProductDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxProductDetail.Location = new System.Drawing.Point(9, 167);
            this.pictureBoxProductDetail.Name = "pictureBoxProductDetail";
            this.pictureBoxProductDetail.Size = new System.Drawing.Size(300, 317);
            this.pictureBoxProductDetail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProductDetail.TabIndex = 28;
            this.pictureBoxProductDetail.TabStop = false;
            // 
            // btnUpload
            // 
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Location = new System.Drawing.Point(315, 167);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 39);
            this.btnUpload.TabIndex = 17;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 29;
            this.label1.Text = "Cost:";
            // 
            // numericControl1
            // 
            this.numericControl1.Location = new System.Drawing.Point(87, 113);
            this.numericControl1.Name = "numericControl1";
            this.numericControl1.Numeric = 0D;
            this.numericControl1.Size = new System.Drawing.Size(109, 22);
            this.numericControl1.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 30;
            this.label2.Text = "Stock#:";
            // 
            // lblStockNumber
            // 
            this.lblStockNumber.AutoSize = true;
            this.lblStockNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockNumber.Location = new System.Drawing.Point(84, 9);
            this.lblStockNumber.Name = "lblStockNumber";
            this.lblStockNumber.Size = new System.Drawing.Size(0, 17);
            this.lblStockNumber.TabIndex = 31;
            // 
            // ProductDetailEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 489);
            this.Controls.Add(this.lblStockNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.pictureBoxProductDetail);
            this.Controls.Add(this.SizeAutoComplete);
            this.Controls.Add(this.WashingAutoComplete);
            this.Controls.Add(this.ColorAutoComplete);
            this.Controls.Add(this.ucSaveEditForm1);
            this.Controls.Add(this.QuantityTextbox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Name = "ProductDetailEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductDetailEditForm";
            this.Load += new System.EventHandler(this.ProductDetailEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProductDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox QuantityTextbox;
        private UserControls.ucSaveEditForm ucSaveEditForm1;
        private UserControls.ucAutoComplete ColorAutoComplete;
        private UserControls.ucAutoComplete WashingAutoComplete;
        private UserControls.ucAutoComplete SizeAutoComplete;
        private System.Windows.Forms.PictureBox pictureBoxProductDetail;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private UserControls.NumericControl numericControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStockNumber;
    
    }
}