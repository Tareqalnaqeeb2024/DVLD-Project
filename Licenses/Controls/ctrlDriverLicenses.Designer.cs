
namespace MyDVLD.Licenses.Controls
{
    partial class ctrlDriverLicensec
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tcDriverLicense = new System.Windows.Forms.TabControl();
            this.tpLocalLicense = new System.Windows.Forms.TabPage();
            this.lbLocalLicense = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvLocalDrivingLicense = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tpInternational = new System.Windows.Forms.TabPage();
            this.lbInternationalRecord = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvInternationalLicense = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tcDriverLicense.SuspendLayout();
            this.tpLocalLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicense)).BeginInit();
            this.tpInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicense)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tcDriverLicense);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1144, 301);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driving License";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // tcDriverLicense
            // 
            this.tcDriverLicense.Controls.Add(this.tpLocalLicense);
            this.tcDriverLicense.Controls.Add(this.tpInternational);
            this.tcDriverLicense.Location = new System.Drawing.Point(6, 29);
            this.tcDriverLicense.Name = "tcDriverLicense";
            this.tcDriverLicense.SelectedIndex = 0;
            this.tcDriverLicense.Size = new System.Drawing.Size(1113, 266);
            this.tcDriverLicense.TabIndex = 0;
            // 
            // tpLocalLicense
            // 
            this.tpLocalLicense.Controls.Add(this.lbLocalLicense);
            this.tpLocalLicense.Controls.Add(this.label5);
            this.tpLocalLicense.Controls.Add(this.dgvLocalDrivingLicense);
            this.tpLocalLicense.Controls.Add(this.label1);
            this.tpLocalLicense.Location = new System.Drawing.Point(4, 34);
            this.tpLocalLicense.Name = "tpLocalLicense";
            this.tpLocalLicense.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocalLicense.Size = new System.Drawing.Size(1105, 228);
            this.tpLocalLicense.TabIndex = 0;
            this.tpLocalLicense.Text = "Local";
            this.tpLocalLicense.UseVisualStyleBackColor = true;
            // 
            // lbLocalLicense
            // 
            this.lbLocalLicense.AutoSize = true;
            this.lbLocalLicense.Location = new System.Drawing.Point(106, 194);
            this.lbLocalLicense.Name = "lbLocalLicense";
            this.lbLocalLicense.Size = new System.Drawing.Size(34, 25);
            this.lbLocalLicense.TabIndex = 7;
            this.lbLocalLicense.Text = "##";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Record :";
            // 
            // dgvLocalDrivingLicense
            // 
            this.dgvLocalDrivingLicense.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalDrivingLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalDrivingLicense.Location = new System.Drawing.Point(3, 47);
            this.dgvLocalDrivingLicense.Name = "dgvLocalDrivingLicense";
            this.dgvLocalDrivingLicense.RowHeadersWidth = 51;
            this.dgvLocalDrivingLicense.RowTemplate.Height = 26;
            this.dgvLocalDrivingLicense.Size = new System.Drawing.Size(1088, 144);
            this.dgvLocalDrivingLicense.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Local Driving License :";
            // 
            // tpInternational
            // 
            this.tpInternational.Controls.Add(this.lbInternationalRecord);
            this.tpInternational.Controls.Add(this.label3);
            this.tpInternational.Controls.Add(this.dgvInternationalLicense);
            this.tpInternational.Controls.Add(this.label2);
            this.tpInternational.Location = new System.Drawing.Point(4, 34);
            this.tpInternational.Name = "tpInternational";
            this.tpInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tpInternational.Size = new System.Drawing.Size(1105, 224);
            this.tpInternational.TabIndex = 1;
            this.tpInternational.Text = "International";
            this.tpInternational.UseVisualStyleBackColor = true;
            // 
            // lbInternationalRecord
            // 
            this.lbInternationalRecord.AutoSize = true;
            this.lbInternationalRecord.Location = new System.Drawing.Point(115, 192);
            this.lbInternationalRecord.Name = "lbInternationalRecord";
            this.lbInternationalRecord.Size = new System.Drawing.Size(34, 25);
            this.lbInternationalRecord.TabIndex = 5;
            this.lbInternationalRecord.Text = "##";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Record :";
            // 
            // dgvInternationalLicense
            // 
            this.dgvInternationalLicense.BackgroundColor = System.Drawing.Color.White;
            this.dgvInternationalLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicense.Location = new System.Drawing.Point(3, 43);
            this.dgvInternationalLicense.Name = "dgvInternationalLicense";
            this.dgvInternationalLicense.RowHeadersWidth = 51;
            this.dgvInternationalLicense.RowTemplate.Height = 26;
            this.dgvInternationalLicense.Size = new System.Drawing.Size(1088, 146);
            this.dgvInternationalLicense.TabIndex = 3;
            this.dgvInternationalLicense.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "International Driving License :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // ctrlDriverLicensec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlDriverLicensec";
            this.Size = new System.Drawing.Size(1155, 308);
            this.Load += new System.EventHandler(this.ctrlDriverLicensec_Load);
            this.groupBox1.ResumeLayout(false);
            this.tcDriverLicense.ResumeLayout(false);
            this.tpLocalLicense.ResumeLayout(false);
            this.tpLocalLicense.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicense)).EndInit();
            this.tpInternational.ResumeLayout(false);
            this.tpInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicense)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tcDriverLicense;
        private System.Windows.Forms.TabPage tpLocalLicense;
        private System.Windows.Forms.DataGridView dgvLocalDrivingLicense;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tpInternational;
        private System.Windows.Forms.DataGridView dgvInternationalLicense;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbLocalLicense;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbInternationalRecord;
        private System.Windows.Forms.Label label3;
    }
}
