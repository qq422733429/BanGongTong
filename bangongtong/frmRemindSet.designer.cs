namespace 青鸟项目
{
    partial class frmRemindSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRemindSet));
            this.lblAheadTime = new System.Windows.Forms.Label();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.cboAheadTime = new System.Windows.Forms.ComboBox();
            this.cboFrequency = new System.Windows.Forms.ComboBox();
            this.btnaccept = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAheadTime
            // 
            this.lblAheadTime.AutoSize = true;
            this.lblAheadTime.Location = new System.Drawing.Point(12, 21);
            this.lblAheadTime.Name = "lblAheadTime";
            this.lblAheadTime.Size = new System.Drawing.Size(101, 12);
            this.lblAheadTime.TabIndex = 0;
            this.lblAheadTime.Text = "提前多少小时提醒";
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Location = new System.Drawing.Point(12, 61);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(101, 12);
            this.lblFrequency.TabIndex = 1;
            this.lblFrequency.Text = "每隔多少分钟提醒";
            // 
            // cboAheadTime
            // 
            this.cboAheadTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAheadTime.FormattingEnabled = true;
            this.cboAheadTime.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cboAheadTime.Location = new System.Drawing.Point(149, 18);
            this.cboAheadTime.Name = "cboAheadTime";
            this.cboAheadTime.Size = new System.Drawing.Size(121, 20);
            this.cboAheadTime.TabIndex = 1;
            // 
            // cboFrequency
            // 
            this.cboFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFrequency.FormattingEnabled = true;
            this.cboFrequency.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "40",
            "50",
            "60"});
            this.cboFrequency.Location = new System.Drawing.Point(149, 58);
            this.cboFrequency.Name = "cboFrequency";
            this.cboFrequency.Size = new System.Drawing.Size(121, 20);
            this.cboFrequency.TabIndex = 3;
            // 
            // btnaccept
            // 
            this.btnaccept.Location = new System.Drawing.Point(149, 110);
            this.btnaccept.Name = "btnaccept";
            this.btnaccept.Size = new System.Drawing.Size(75, 23);
            this.btnaccept.TabIndex = 4;
            this.btnaccept.Text = "保存";
            this.btnaccept.UseVisualStyleBackColor = true;
            this.btnaccept.Click += new System.EventHandler(this.btnaccept_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(245, 110);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 5;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            // 
            // frmRemindSet
            // 
            this.AcceptButton = this.btnaccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 145);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnaccept);
            this.Controls.Add(this.cboFrequency);
            this.Controls.Add(this.cboAheadTime);
            this.Controls.Add(this.lblFrequency);
            this.Controls.Add(this.lblAheadTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRemindSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提醒设置";
            this.Load += new System.EventHandler(this.frmRemindSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAheadTime;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.ComboBox cboAheadTime;
        private System.Windows.Forms.ComboBox cboFrequency;
        private System.Windows.Forms.Button btnaccept;
        private System.Windows.Forms.Button btnCancle;
    }
}