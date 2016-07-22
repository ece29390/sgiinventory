namespace SGInventory.OutletForm
{
    partial class OutletSearchForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.ucAddDelete1 = new SGInventory.UserControls.ucAddDelete();
            this.ucNameAddress1 = new SGInventory.UserControls.ucNameAddress();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucNameAddress1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(779, 401);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ucAddDelete1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 324);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(779, 77);
            this.panel2.TabIndex = 1;
            // 
            // ucAddDelete1
            // 
            this.ucAddDelete1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucAddDelete1.Location = new System.Drawing.Point(533, 16);
            this.ucAddDelete1.Margin = new System.Windows.Forms.Padding(4);
            this.ucAddDelete1.Name = "ucAddDelete1";
            this.ucAddDelete1.Size = new System.Drawing.Size(242, 58);
            this.ucAddDelete1.TabIndex = 0;
            // 
            // ucNameAddress1
            // 
            this.ucNameAddress1.Location = new System.Drawing.Point(3, 43);
            this.ucNameAddress1.Name = "ucNameAddress1";
            this.ucNameAddress1.Size = new System.Drawing.Size(774, 275);
            this.ucNameAddress1.TabIndex = 0;
            // 
            // OutletSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 401);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "OutletSearchForm";
            this.Text = "OutletSearchForm";
            this.Load += new System.EventHandler(this.OutletSearchForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private UserControls.ucNameAddress ucNameAddress1;
        private System.Windows.Forms.Panel panel2;
        private UserControls.ucAddDelete ucAddDelete1;
    }
}