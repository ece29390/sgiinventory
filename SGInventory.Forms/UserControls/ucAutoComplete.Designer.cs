namespace SGInventory.UserControls
{
    partial class ucAutoComplete
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
            this.AutoCompleteTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AutoCompleteTextbox
            // 
            this.AutoCompleteTextbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.AutoCompleteTextbox.Location = new System.Drawing.Point(0, 0);
            this.AutoCompleteTextbox.Name = "AutoCompleteTextbox";
            this.AutoCompleteTextbox.Size = new System.Drawing.Size(310, 20);
            this.AutoCompleteTextbox.TabIndex = 0;
            this.AutoCompleteTextbox.TextChanged += new System.EventHandler(this.AutoCompleteTextbox_TextChanged);
            this.AutoCompleteTextbox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ucAutoComplete_KeyUp);
            // 
            // ucAutoComplete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AutoCompleteTextbox);
            this.Name = "ucAutoComplete";
            this.Size = new System.Drawing.Size(313, 21);
            this.Leave += new System.EventHandler(this.ucAutoComplete_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AutoCompleteTextbox;
    }
}
