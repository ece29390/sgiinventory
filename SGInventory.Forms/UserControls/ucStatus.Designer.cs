namespace SGInventory.UserControls
{
    partial class ucStatus
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbDamageDetail = new System.Windows.Forms.GroupBox();
            this.cboDamageStatus = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.StatusDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.StatusComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbDamageDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDamageDetail
            // 
            this.gbDamageDetail.Controls.Add(this.cboDamageStatus);
            this.gbDamageDetail.Controls.Add(this.label9);
            this.gbDamageDetail.Controls.Add(this.StatusDescriptionTextbox);
            this.gbDamageDetail.Enabled = false;
            this.gbDamageDetail.Location = new System.Drawing.Point(3, 44);
            this.gbDamageDetail.Name = "gbDamageDetail";
            this.gbDamageDetail.Size = new System.Drawing.Size(331, 147);
            this.gbDamageDetail.TabIndex = 33;
            this.gbDamageDetail.TabStop = false;
            this.gbDamageDetail.Text = "Damage Details";
            // 
            // cboDamageStatus
            // 
            this.cboDamageStatus.FormattingEnabled = true;
            this.cboDamageStatus.Location = new System.Drawing.Point(136, 17);
            this.cboDamageStatus.Name = "cboDamageStatus";
            this.cboDamageStatus.Size = new System.Drawing.Size(188, 21);
            this.cboDamageStatus.TabIndex = 33;
            this.cboDamageStatus.SelectedIndexChanged += new System.EventHandler(this.cboDamageStatus_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "Damage Status:";
            // 
            // StatusDescriptionTextbox
            // 
            this.StatusDescriptionTextbox.Enabled = false;
            this.StatusDescriptionTextbox.Location = new System.Drawing.Point(7, 44);
            this.StatusDescriptionTextbox.MaxLength = 500;
            this.StatusDescriptionTextbox.Multiline = true;
            this.StatusDescriptionTextbox.Name = "StatusDescriptionTextbox";
            this.StatusDescriptionTextbox.Size = new System.Drawing.Size(318, 100);
            this.StatusDescriptionTextbox.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 17);
            this.label5.TabIndex = 35;
            this.label5.Text = "Status Description:";
            // 
            // StatusComboBox
            // 
            this.StatusComboBox.FormattingEnabled = true;
            this.StatusComboBox.Location = new System.Drawing.Point(120, 0);
            this.StatusComboBox.Name = "StatusComboBox";
            this.StatusComboBox.Size = new System.Drawing.Size(204, 21);
            this.StatusComboBox.TabIndex = 36;
            this.StatusComboBox.SelectedIndexChanged += new System.EventHandler(this.StatusComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 34;
            this.label4.Text = "Status:";
            // 
            // ucStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.StatusComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gbDamageDetail);
            this.Name = "ucStatus";
            this.Size = new System.Drawing.Size(338, 195);
            this.gbDamageDetail.ResumeLayout(false);
            this.gbDamageDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDamageDetail;
        private System.Windows.Forms.ComboBox cboDamageStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox StatusDescriptionTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox StatusComboBox;
        private System.Windows.Forms.Label label4;

    }
}
