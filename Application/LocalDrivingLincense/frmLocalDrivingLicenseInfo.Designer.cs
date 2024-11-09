
namespace MyDVLD.Application.LocalDrivingLincense
{
    partial class frmLocalDrivingLicenseInfo
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
            this.ctrlLocalDrivingLincenseCard1 = new MyDVLD.Application.LocalDrivingLincense.ctrlLocalDrivingLincenseCard();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlLocalDrivingLincenseCard1
            // 
            this.ctrlLocalDrivingLincenseCard1.Location = new System.Drawing.Point(12, 52);
            this.ctrlLocalDrivingLincenseCard1.Name = "ctrlLocalDrivingLincenseCard1";
            this.ctrlLocalDrivingLincenseCard1.Size = new System.Drawing.Size(933, 396);
            this.ctrlLocalDrivingLincenseCard1.TabIndex = 0;
            this.ctrlLocalDrivingLincenseCard1.Load += new System.EventHandler(this.ctrlLocalDrivingLincenseCard1_Load);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::MyDVLD.Properties.Resources.Close_321;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(743, 439);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 49);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmLocalDrivingLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(947, 500);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlLocalDrivingLincenseCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLocalDrivingLicenseInfo";
            this.Text = "frmLocalDrivingLicenseInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlLocalDrivingLincenseCard ctrlLocalDrivingLincenseCard1;
        private System.Windows.Forms.Button btnClose;
    }
}