namespace SGInventory.User
{
    partial class ChangePassword
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
            this.userNameLabel = new System.Windows.Forms.Label();
            this.userNameTextbox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.oldPasswordTextbox = new System.Windows.Forms.TextBox();
            this.newPasswordLabel = new System.Windows.Forms.Label();
            this.newPasswordTextbox = new System.Windows.Forms.TextBox();
            this.changePasswordButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLabel.Location = new System.Drawing.Point(1, 9);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(88, 17);
            this.userNameLabel.TabIndex = 0;
            this.userNameLabel.Text = "UserName:";
            // 
            // userNameTextbox
            // 
            this.userNameTextbox.Location = new System.Drawing.Point(124, 8);
            this.userNameTextbox.Name = "userNameTextbox";
            this.userNameTextbox.ReadOnly = true;
            this.userNameTextbox.Size = new System.Drawing.Size(305, 20);
            this.userNameTextbox.TabIndex = 1;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(1, 31);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(112, 17);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Old Password:";
            // 
            // oldPasswordTextbox
            // 
            this.oldPasswordTextbox.Location = new System.Drawing.Point(124, 31);
            this.oldPasswordTextbox.Name = "oldPasswordTextbox";
            this.oldPasswordTextbox.PasswordChar = '*';
            this.oldPasswordTextbox.Size = new System.Drawing.Size(305, 20);
            this.oldPasswordTextbox.TabIndex = 3;
            // 
            // newPasswordLabel
            // 
            this.newPasswordLabel.AutoSize = true;
            this.newPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPasswordLabel.Location = new System.Drawing.Point(1, 57);
            this.newPasswordLabel.Name = "newPasswordLabel";
            this.newPasswordLabel.Size = new System.Drawing.Size(117, 17);
            this.newPasswordLabel.TabIndex = 4;
            this.newPasswordLabel.Text = "New Password:";
            // 
            // newPasswordTextbox
            // 
            this.newPasswordTextbox.Location = new System.Drawing.Point(124, 56);
            this.newPasswordTextbox.Name = "newPasswordTextbox";
            this.newPasswordTextbox.PasswordChar = '*';
            this.newPasswordTextbox.Size = new System.Drawing.Size(305, 20);
            this.newPasswordTextbox.TabIndex = 5;
            // 
            // changePasswordButton
            // 
            this.changePasswordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changePasswordButton.Location = new System.Drawing.Point(318, 82);
            this.changePasswordButton.Name = "changePasswordButton";
            this.changePasswordButton.Size = new System.Drawing.Size(111, 37);
            this.changePasswordButton.TabIndex = 6;
            this.changePasswordButton.Text = "Change Password";
            this.changePasswordButton.UseVisualStyleBackColor = true;
            this.changePasswordButton.Click += new System.EventHandler(this.changePasswordButton_Click);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 125);
            this.Controls.Add(this.changePasswordButton);
            this.Controls.Add(this.newPasswordTextbox);
            this.Controls.Add(this.newPasswordLabel);
            this.Controls.Add(this.oldPasswordTextbox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.userNameTextbox);
            this.Controls.Add(this.userNameLabel);
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.TextBox userNameTextbox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox oldPasswordTextbox;
        private System.Windows.Forms.Label newPasswordLabel;
        private System.Windows.Forms.TextBox newPasswordTextbox;
        private System.Windows.Forms.Button changePasswordButton;
    }
}