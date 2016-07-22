namespace SGInventory.SupplierForm
{
    partial class SupplierEditForm
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
            this.ucSaveEditForm1 = new SGInventory.UserControls.ucSaveEditForm();
            this.ucAddress1 = new SGInventory.UserControls.ucAddress();
            this.ucName1 = new SGInventory.UserControls.ucName();
            this.SuspendLayout();
            // 
            // ucSaveEditForm1
            // 
            this.ucSaveEditForm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucSaveEditForm1.Location = new System.Drawing.Point(349, 109);
            this.ucSaveEditForm1.Margin = new System.Windows.Forms.Padding(4);
            this.ucSaveEditForm1.Name = "ucSaveEditForm1";
            this.ucSaveEditForm1.Size = new System.Drawing.Size(79, 44);
            this.ucSaveEditForm1.TabIndex = 2;
            // 
            // ucAddress1
            // 
            this.ucAddress1.Address = "";
            this.ucAddress1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucAddress1.Location = new System.Drawing.Point(-1, 23);
            this.ucAddress1.Name = "ucAddress1";
            this.ucAddress1.Size = new System.Drawing.Size(429, 89);
            this.ucAddress1.TabIndex = 1;
            // 
            // ucName1
            // 
            this.ucName1.Location = new System.Drawing.Point(-1, 0);
            this.ucName1.Name = "ucName1";
            this.ucName1.Size = new System.Drawing.Size(429, 27);
            this.ucName1.TabIndex = 0;
            this.ucName1.UniqueName = "";
            // 
            // SupplierEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 247);
            this.Controls.Add(this.ucSaveEditForm1);
            this.Controls.Add(this.ucAddress1);
            this.Controls.Add(this.ucName1);
            this.Name = "SupplierEditForm";
            this.Text = "SupplierEditForm";
            this.Load += new System.EventHandler(this.SupplierEditForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucName ucName1;
        private UserControls.ucAddress ucAddress1;
        private UserControls.ucSaveEditForm ucSaveEditForm1;
    }
}