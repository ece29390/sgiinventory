namespace SGInventory.Inventory
{
    partial class AdjustmentDeliverySupplier
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.ucStatus1 = new SGInventory.UserControls.ucStatus();
            this.baseDeliveryUserControl1 = new SGInventory.UserControls.BaseDeliveryUserControl();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(280, 321);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(361, 321);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ucStatus1
            // 
            this.ucStatus1.Location = new System.Drawing.Point(-2, 90);
            this.ucStatus1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ucStatus1.Name = "ucStatus1";
            this.ucStatus1.Size = new System.Drawing.Size(442, 225);
            this.ucStatus1.TabIndex = 9;
            // 
            // baseDeliveryUserControl1
            // 
            this.baseDeliveryUserControl1.Location = new System.Drawing.Point(-2, 0);
            this.baseDeliveryUserControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.baseDeliveryUserControl1.Name = "baseDeliveryUserControl1";
            this.baseDeliveryUserControl1.Size = new System.Drawing.Size(442, 86);
            this.baseDeliveryUserControl1.TabIndex = 8;
            // 
            // AdjustmentDeliverySupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 356);
            this.Controls.Add(this.ucStatus1);
            this.Controls.Add(this.baseDeliveryUserControl1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AdjustmentDeliverySupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier Adjustment";
            this.Load += new System.EventHandler(this.AdjustmentProduct_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private UserControls.BaseDeliveryUserControl baseDeliveryUserControl1;
        private UserControls.ucStatus ucStatus1;
    }
}