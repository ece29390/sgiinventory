namespace SGInventory.User
{
    partial class UserEditForm
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
            this.fullNameTextbox = new System.Windows.Forms.TextBox();
            this.fullNameLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ucSaveEditForm1 = new SGInventory.UserControls.ucSaveEditForm();
            this.ucUserNamePassword1 = new SGInventory.UserControls.ucUserNamePassword();
            this.roleTypeLabel = new System.Windows.Forms.Label();
            this.roleTypeComboBox = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.roleTypeComboBox);
            this.panel1.Controls.Add(this.roleTypeLabel);
            this.panel1.Controls.Add(this.ucUserNamePassword1);
            this.panel1.Controls.Add(this.fullNameTextbox);
            this.panel1.Controls.Add(this.fullNameLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 123);
            this.panel1.TabIndex = 0;
            // 
            // fullNameTextbox
            // 
            this.fullNameTextbox.Location = new System.Drawing.Point(92, 54);
            this.fullNameTextbox.Name = "fullNameTextbox";
            this.fullNameTextbox.Size = new System.Drawing.Size(333, 20);
            this.fullNameTextbox.TabIndex = 5;
            this.fullNameTextbox.TextChanged += new System.EventHandler(this.fullNameTextbox_TextChanged);
            // 
            // fullNameLabel
            // 
            this.fullNameLabel.AutoSize = true;
            this.fullNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullNameLabel.Location = new System.Drawing.Point(1, 54);
            this.fullNameLabel.Name = "fullNameLabel";
            this.fullNameLabel.Size = new System.Drawing.Size(85, 17);
            this.fullNameLabel.TabIndex = 4;
            this.fullNameLabel.Text = "Full Name:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ucSaveEditForm1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(429, 45);
            this.panel2.TabIndex = 1;
            // 
            // ucSaveEditForm1
            // 
            this.ucSaveEditForm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucSaveEditForm1.Location = new System.Drawing.Point(346, 0);
            this.ucSaveEditForm1.Margin = new System.Windows.Forms.Padding(4);
            this.ucSaveEditForm1.Name = "ucSaveEditForm1";
            this.ucSaveEditForm1.Size = new System.Drawing.Size(79, 44);
            this.ucSaveEditForm1.TabIndex = 0;
            // 
            // ucUserNamePassword1
            // 
            this.ucUserNamePassword1.Location = new System.Drawing.Point(2, 7);
            this.ucUserNamePassword1.Name = "ucUserNamePassword1";
            this.ucUserNamePassword1.Size = new System.Drawing.Size(424, 47);
            this.ucUserNamePassword1.TabIndex = 6;
            // 
            // roleTypeLabel
            // 
            this.roleTypeLabel.AutoSize = true;
            this.roleTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleTypeLabel.Location = new System.Drawing.Point(3, 77);
            this.roleTypeLabel.Name = "roleTypeLabel";
            this.roleTypeLabel.Size = new System.Drawing.Size(87, 17);
            this.roleTypeLabel.TabIndex = 7;
            this.roleTypeLabel.Text = "Role Type:";
            // 
            // roleTypeComboBox
            // 
            this.roleTypeComboBox.FormattingEnabled = true;
            this.roleTypeComboBox.Location = new System.Drawing.Point(92, 77);
            this.roleTypeComboBox.Name = "roleTypeComboBox";
            this.roleTypeComboBox.Size = new System.Drawing.Size(325, 21);
            this.roleTypeComboBox.TabIndex = 8;
            // 
            // UserEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 168);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UserEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserEditForm";
            this.Load += new System.EventHandler(this.UserEditForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private UserControls.ucSaveEditForm ucSaveEditForm1;
        private System.Windows.Forms.TextBox fullNameTextbox;
        private System.Windows.Forms.Label fullNameLabel;
        private System.Windows.Forms.ComboBox roleTypeComboBox;
        private System.Windows.Forms.Label roleTypeLabel;
        private UserControls.ucUserNamePassword ucUserNamePassword1;
    }
}