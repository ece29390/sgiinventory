namespace SGInventory.SupplierForm
{
    partial class SupplierSearchForm
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
            this.ucNameAddress1 = new SGInventory.UserControls.ucNameAddress();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucAddDelete1 = new SGInventory.UserControls.ucAddDelete();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucNameAddress1
            // 
            this.ucNameAddress1.Location = new System.Drawing.Point(-1, 33);
            this.ucNameAddress1.Name = "ucNameAddress1";
            this.ucNameAddress1.Size = new System.Drawing.Size(774, 275);
            this.ucNameAddress1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucAddDelete1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 314);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(773, 76);
            this.panel1.TabIndex = 1;
            // 
            // ucAddDelete1
            // 
            this.ucAddDelete1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucAddDelete1.Location = new System.Drawing.Point(527, 4);
            this.ucAddDelete1.Margin = new System.Windows.Forms.Padding(4);
            this.ucAddDelete1.Name = "ucAddDelete1";
            this.ucAddDelete1.Size = new System.Drawing.Size(242, 58);
            this.ucAddDelete1.TabIndex = 0;
            // 
            // SupplierSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 390);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ucNameAddress1);
            this.Name = "SupplierSearchForm";
            this.Text = "SupplierSearchForm";
            this.Load += new System.EventHandler(this.SupplierSearchForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucNameAddress ucNameAddress1;
        private System.Windows.Forms.Panel panel1;
        private UserControls.ucAddDelete ucAddDelete1;

    }
}