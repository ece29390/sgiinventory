﻿namespace SGInventory.Inventory
{
    partial class Adjustment
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
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbDamageDetail = new System.Windows.Forms.GroupBox();
            this.cboDamageStatus = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.StatusDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtAdjustmentRemarks = new System.Windows.Forms.TextBox();
            this.baseDeliveryUserControl1 = new SGInventory.UserControls.BaseDeliveryUserControl();
            this.labelSupplierOrOutlet = new System.Windows.Forms.Label();
            this.ucAutoCompleteOutletOrSupplier = new SGInventory.UserControls.ucAutoComplete();
            this.gbDamageDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboStatus
            // 
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(159, 173);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(274, 26);
            this.cboStatus.TabIndex = 15;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Status:";
            // 
            // cboMode
            // 
            this.cboMode.FormattingEnabled = true;
            this.cboMode.Location = new System.Drawing.Point(159, 107);
            this.cboMode.Name = "cboMode";
            this.cboMode.Size = new System.Drawing.Size(274, 26);
            this.cboMode.TabIndex = 11;
            this.cboMode.SelectedIndexChanged += new System.EventHandler(this.cboMode_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "Mode:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 18);
            this.label5.TabIndex = 37;
            this.label5.Text = "Adjustment Remarks:";
            // 
            // gbDamageDetail
            // 
            this.gbDamageDetail.Controls.Add(this.cboDamageStatus);
            this.gbDamageDetail.Controls.Add(this.label9);
            this.gbDamageDetail.Controls.Add(this.StatusDescriptionTextbox);
            this.gbDamageDetail.Enabled = false;
            this.gbDamageDetail.Location = new System.Drawing.Point(0, 230);
            this.gbDamageDetail.Name = "gbDamageDetail";
            this.gbDamageDetail.Size = new System.Drawing.Size(445, 184);
            this.gbDamageDetail.TabIndex = 36;
            this.gbDamageDetail.TabStop = false;
            this.gbDamageDetail.Text = "Damage Details";
            // 
            // cboDamageStatus
            // 
            this.cboDamageStatus.FormattingEnabled = true;
            this.cboDamageStatus.Location = new System.Drawing.Point(136, 17);
            this.cboDamageStatus.Name = "cboDamageStatus";
            this.cboDamageStatus.Size = new System.Drawing.Size(303, 26);
            this.cboDamageStatus.TabIndex = 19;
            this.cboDamageStatus.SelectedIndexChanged += new System.EventHandler(this.cboDamageStatus_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 18);
            this.label9.TabIndex = 21;
            this.label9.Text = "Damage Status:";
            // 
            // StatusDescriptionTextbox
            // 
            this.StatusDescriptionTextbox.Enabled = false;
            this.StatusDescriptionTextbox.Location = new System.Drawing.Point(12, 49);
            this.StatusDescriptionTextbox.MaxLength = 500;
            this.StatusDescriptionTextbox.Multiline = true;
            this.StatusDescriptionTextbox.Name = "StatusDescriptionTextbox";
            this.StatusDescriptionTextbox.Size = new System.Drawing.Size(432, 100);
            this.StatusDescriptionTextbox.TabIndex = 21;
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(364, 420);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 25;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(283, 420);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAdjustmentRemarks
            // 
            this.txtAdjustmentRemarks.Location = new System.Drawing.Point(159, 202);
            this.txtAdjustmentRemarks.Name = "txtAdjustmentRemarks";
            this.txtAdjustmentRemarks.Size = new System.Drawing.Size(274, 24);
            this.txtAdjustmentRemarks.TabIndex = 17;
            // 
            // baseDeliveryUserControl1
            // 
            this.baseDeliveryUserControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.baseDeliveryUserControl1.Location = new System.Drawing.Point(0, 0);
            this.baseDeliveryUserControl1.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.baseDeliveryUserControl1.Name = "baseDeliveryUserControl1";
            this.baseDeliveryUserControl1.ProductDetailCode = "[lblProductCode]";
            this.baseDeliveryUserControl1.Quantity = 0;
            this.baseDeliveryUserControl1.Size = new System.Drawing.Size(445, 99);
            this.baseDeliveryUserControl1.TabIndex = 9;
            // 
            // labelSupplierOrOutlet
            // 
            this.labelSupplierOrOutlet.AutoSize = true;
            this.labelSupplierOrOutlet.Location = new System.Drawing.Point(15, 141);
            this.labelSupplierOrOutlet.Name = "labelSupplierOrOutlet";
            this.labelSupplierOrOutlet.Size = new System.Drawing.Size(52, 18);
            this.labelSupplierOrOutlet.TabIndex = 41;
            this.labelSupplierOrOutlet.Text = "label3";
            // 
            // ucAutoCompleteOutletOrSupplier
            // 
            this.ucAutoCompleteOutletOrSupplier.AutoCompleteValue = "";
            this.ucAutoCompleteOutletOrSupplier.Location = new System.Drawing.Point(159, 140);
            this.ucAutoCompleteOutletOrSupplier.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ucAutoCompleteOutletOrSupplier.Name = "ucAutoCompleteOutletOrSupplier";
            this.ucAutoCompleteOutletOrSupplier.Size = new System.Drawing.Size(272, 26);
            this.ucAutoCompleteOutletOrSupplier.TabIndex = 13;
            // 
            // Adjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 455);
            this.Controls.Add(this.ucAutoCompleteOutletOrSupplier);
            this.Controls.Add(this.labelSupplierOrOutlet);
            this.Controls.Add(this.txtAdjustmentRemarks);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gbDamageDetail);
            this.Controls.Add(this.cboMode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.baseDeliveryUserControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Adjustment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adjustment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Adjustment_FormClosing);
            this.Load += new System.EventHandler(this.Adjustment_Load);
            this.gbDamageDetail.ResumeLayout(false);
            this.gbDamageDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.BaseDeliveryUserControl baseDeliveryUserControl1;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbDamageDetail;
        private System.Windows.Forms.ComboBox cboDamageStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox StatusDescriptionTextbox;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtAdjustmentRemarks;
        private System.Windows.Forms.Label labelSupplierOrOutlet;
        private UserControls.ucAutoComplete ucAutoCompleteOutletOrSupplier;
    }
}