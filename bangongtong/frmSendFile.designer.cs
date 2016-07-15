namespace 青鸟项目
{
    partial class frmSendFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSendFile));
            this.lblFile = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblFolder = new System.Windows.Forms.Label();
            this.cboFolder = new System.Windows.Forms.ComboBox();
            this.cboNetMember = new System.Windows.Forms.ComboBox();
            this.lblPeople = new System.Windows.Forms.Label();
            this.cboFile = new System.Windows.Forms.ComboBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtReceiveMember = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(44, 98);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(53, 12);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "文件名：";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(260, 211);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "发送";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(44, 38);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(53, 12);
            this.lblFolder.TabIndex = 5;
            this.lblFolder.Text = "文件夹：";
            // 
            // cboFolder
            // 
            this.cboFolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFolder.FormattingEnabled = true;
            this.cboFolder.Location = new System.Drawing.Point(121, 33);
            this.cboFolder.Name = "cboFolder";
            this.cboFolder.Size = new System.Drawing.Size(214, 20);
            this.cboFolder.TabIndex = 6;
            this.cboFolder.SelectedIndexChanged += new System.EventHandler(this.cboFolder_SelectedIndexChanged);
            // 
            // cboNetMember
            // 
            this.cboNetMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNetMember.FormattingEnabled = true;
            this.cboNetMember.Location = new System.Drawing.Point(121, 156);
            this.cboNetMember.Name = "cboNetMember";
            this.cboNetMember.Size = new System.Drawing.Size(214, 20);
            this.cboNetMember.TabIndex = 7;
            // 
            // lblPeople
            // 
            this.lblPeople.AutoSize = true;
            this.lblPeople.Location = new System.Drawing.Point(44, 159);
            this.lblPeople.Name = "lblPeople";
            this.lblPeople.Size = new System.Drawing.Size(53, 12);
            this.lblPeople.TabIndex = 8;
            this.lblPeople.Text = "收件人：";
            // 
            // cboFile
            // 
            this.cboFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFile.FormattingEnabled = true;
            this.cboFile.Location = new System.Drawing.Point(121, 95);
            this.cboFile.Name = "cboFile";
            this.cboFile.Size = new System.Drawing.Size(214, 20);
            this.cboFile.TabIndex = 9;
            // 
            // txtFileName
            // 
            this.txtFileName.Enabled = false;
            this.txtFileName.Location = new System.Drawing.Point(121, 60);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(214, 21);
            this.txtFileName.TabIndex = 10;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(44, 63);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(53, 12);
            this.lblFileName.TabIndex = 0;
            this.lblFileName.Text = "文件名：";
            // 
            // txtReceiveMember
            // 
            this.txtReceiveMember.Enabled = false;
            this.txtReceiveMember.Location = new System.Drawing.Point(121, 155);
            this.txtReceiveMember.Name = "txtReceiveMember";
            this.txtReceiveMember.Size = new System.Drawing.Size(214, 21);
            this.txtReceiveMember.TabIndex = 11;
            // 
            // frmSendFile
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 261);
            this.Controls.Add(this.txtReceiveMember);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.cboFile);
            this.Controls.Add(this.lblPeople);
            this.Controls.Add(this.cboNetMember);
            this.Controls.Add(this.cboFolder);
            this.Controls.Add(this.lblFolder);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.lblFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSendFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "发送文件";
            this.Load += new System.EventHandler(this.frmSendFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.ComboBox cboFolder;
        private System.Windows.Forms.ComboBox cboNetMember;
        private System.Windows.Forms.Label lblPeople;
        private System.Windows.Forms.ComboBox cboFile;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtReceiveMember;
    }
}