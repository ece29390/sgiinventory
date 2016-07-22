namespace SGInventory.StoreForm
{
    partial class StoreEditForm
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
            this.ucName1 = new SGInventory.UserControls.ucName();
            this.ucCode1 = new SGInventory.UserControls.ucCode();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ucSaveEditForm1 = new SGInventory.UserControls.ucSaveEditForm();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucName1);
            this.panel1.Controls.Add(this.ucCode1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 67);
            this.panel1.TabIndex = 0;
            // 
            // ucName1
            // 
            this.ucName1.Location = new System.Drawing.Point(0, 25);
            this.ucName1.Name = "ucName1";
            this.ucName1.Size = new System.Drawing.Size(429, 27);
            this.ucName1.TabIndex = 1;
            this.ucName1.UniqueName = "";
            // 
            // ucCode1
            // 
            this.ucCode1.Code = "";
            this.ucCode1.Location = new System.Drawing.Point(0, 0);
            this.ucCode1.Name = "ucCode1";
            this.ucCode1.Size = new System.Drawing.Size(429, 27);
            this.ucCode1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ucSaveEditForm1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(429, 51);
            this.panel2.TabIndex = 1;
            // 
            // ucSaveEditForm1
            // 
            this.ucSaveEditForm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucSaveEditForm1.Location = new System.Drawing.Point(345, 4);
            this.ucSaveEditForm1.Margin = new System.Windows.Forms.Padding(4);
            this.ucSaveEditForm1.Name = "ucSaveEditForm1";
            this.ucSaveEditForm1.Size = new System.Drawing.Size(80, 44);
            this.ucSaveEditForm1.TabIndex = 0;
            // 
            // StoreEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 118);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "StoreEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StoreEditForm";
            this.Load += new System.EventHandler(StoreEditForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }       
        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private UserControls.ucSaveEditForm ucSaveEditForm1;
        private UserControls.ucName ucName1;
        private UserControls.ucCode ucCode1;
    }
}