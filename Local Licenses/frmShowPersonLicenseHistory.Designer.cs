namespace DVLD_Project.Local_Licenses
{
    partial class frmShowPersonLicenseHistory
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
            this.ctrFilterPerson1 = new DVLD_Project.Controls.ctrFilterPerson();
            this.ctrDriverLicenses1 = new DVLD_Project.Local_Licenses.ctrDriverLicenses();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrFilterPerson1
            // 
            this.ctrFilterPerson1.BackColor = System.Drawing.Color.Transparent;
            this.ctrFilterPerson1.FilterEnable = true;
            this.ctrFilterPerson1.Location = new System.Drawing.Point(30, 45);
            this.ctrFilterPerson1.Name = "ctrFilterPerson1";
            this.ctrFilterPerson1.ShowAddPerson = true;
            this.ctrFilterPerson1.Size = new System.Drawing.Size(997, 462);
            this.ctrFilterPerson1.TabIndex = 0;
            // 
            // ctrDriverLicenses1
            // 
            this.ctrDriverLicenses1.Location = new System.Drawing.Point(22, 480);
            this.ctrDriverLicenses1.Name = "ctrDriverLicenses1";
            this.ctrDriverLicenses1.Size = new System.Drawing.Size(1107, 426);
            this.ctrDriverLicenses1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(901, 871);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 37);
            this.btnClose.TabIndex = 184;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowPersonLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1160, 971);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrDriverLicenses1);
            this.Controls.Add(this.ctrFilterPerson1);
            this.Name = "frmShowPersonLicenseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Person License History";
            this.Load += new System.EventHandler(this.frmShowPersonLicenseHistory_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DVLD_Project.Controls.ctrFilterPerson ctrFilterPerson1;
        private ctrDriverLicenses ctrDriverLicenses1;
        private System.Windows.Forms.Button btnClose;
    }
}