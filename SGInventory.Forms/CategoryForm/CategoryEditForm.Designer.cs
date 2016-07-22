namespace SGInventory.CategoryForm
{
    partial class CategoryEditForm
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
            this.ucDescription1 = new SGInventory.UserControls.ucDescription();
            this.ucName1 = new SGInventory.UserControls.ucName();
            this.SuspendLayout();
            // 
            // ucSaveEditForm1
            // 
            this.ucSaveEditForm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucSaveEditForm1.Location = new System.Drawing.Point(347, 111);
            this.ucSaveEditForm1.Margin = new System.Windows.Forms.Padding(4);
            this.ucSaveEditForm1.Name = "ucSaveEditForm1";
            this.ucSaveEditForm1.Size = new System.Drawing.Size(82, 44);
            this.ucSaveEditForm1.TabIndex = 2;
            // 
            // ucDescription1
            // 
            this.ucDescription1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucDescription1.Location = new System.Drawing.Point(0, 27);
            this.ucDescription1.Name = "ucDescription1";
            this.ucDescription1.Size = new System.Drawing.Size(429, 89);
            this.ucDescription1.TabIndex = 1;
            // 
            // ucName1
            // 
            this.ucName1.Location = new System.Drawing.Point(0, 3);
            this.ucName1.Name = "ucName1";
            this.ucName1.Size = new System.Drawing.Size(429, 27);
            this.ucName1.TabIndex = 0;
            // 
            // CategoryEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 168);
            this.Controls.Add(this.ucSaveEditForm1);
            this.Controls.Add(this.ucDescription1);
            this.Controls.Add(this.ucName1);
            this.Name = "CategoryEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CategoryEditForm";
            this.Load += new System.EventHandler(this.CategoryEditForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucName ucName1;
        private UserControls.ucDescription ucDescription1;
        private UserControls.ucSaveEditForm ucSaveEditForm1;
    }
}