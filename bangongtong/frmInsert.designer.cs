namespace 青鸟项目
{
    partial class frmInsert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInsert));
            this.lblDocumentName = new System.Windows.Forms.Label();
            this.lblChoiceDocument = new System.Windows.Forms.Label();
            this.lblPrivateDocument = new System.Windows.Forms.Label();
            this.txtChoiceDocument = new System.Windows.Forms.TextBox();
            this.txtDocumentName = new System.Windows.Forms.TextBox();
            this.btnChoiceDocument = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.plInsert = new System.Windows.Forms.Panel();
            this.btnDocumentTypeCancel = new System.Windows.Forms.Button();
            this.btnDocumentTypeSave = new System.Windows.Forms.Button();
            this.txtDocumentType = new System.Windows.Forms.TextBox();
            this.plPrivateDocument = new System.Windows.Forms.Panel();
            this.rdoPrivateDocumentNo = new System.Windows.Forms.RadioButton();
            this.rdoPrivateDocumentYes = new System.Windows.Forms.RadioButton();
            this.btnDocumentType = new System.Windows.Forms.Button();
            this.lblDocumentTpye = new System.Windows.Forms.Label();
            this.cboDocumentType = new System.Windows.Forms.ComboBox();
            this.btnDefine = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.plInsert.SuspendLayout();
            this.plPrivateDocument.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDocumentName
            // 
            this.lblDocumentName.AutoSize = true;
            this.lblDocumentName.Location = new System.Drawing.Point(62, 47);
            this.lblDocumentName.Name = "lblDocumentName";
            this.lblDocumentName.Size = new System.Drawing.Size(41, 12);
            this.lblDocumentName.TabIndex = 0;
            this.lblDocumentName.Text = "文件名";
            // 
            // lblChoiceDocument
            // 
            this.lblChoiceDocument.AutoSize = true;
            this.lblChoiceDocument.Location = new System.Drawing.Point(50, 22);
            this.lblChoiceDocument.Name = "lblChoiceDocument";
            this.lblChoiceDocument.Size = new System.Drawing.Size(53, 12);
            this.lblChoiceDocument.TabIndex = 0;
            this.lblChoiceDocument.Text = "选择文件";
            // 
            // lblPrivateDocument
            // 
            this.lblPrivateDocument.AutoSize = true;
            this.lblPrivateDocument.Location = new System.Drawing.Point(50, 72);
            this.lblPrivateDocument.Name = "lblPrivateDocument";
            this.lblPrivateDocument.Size = new System.Drawing.Size(53, 12);
            this.lblPrivateDocument.TabIndex = 0;
            this.lblPrivateDocument.Text = "隐私文件";
            // 
            // txtChoiceDocument
            // 
            this.txtChoiceDocument.Location = new System.Drawing.Point(133, 17);
            this.txtChoiceDocument.Name = "txtChoiceDocument";
            this.txtChoiceDocument.Size = new System.Drawing.Size(195, 21);
            this.txtChoiceDocument.TabIndex = 1;
            // 
            // txtDocumentName
            // 
            this.txtDocumentName.Location = new System.Drawing.Point(133, 44);
            this.txtDocumentName.Name = "txtDocumentName";
            this.txtDocumentName.Size = new System.Drawing.Size(195, 21);
            this.txtDocumentName.TabIndex = 3;
            // 
            // btnChoiceDocument
            // 
            this.btnChoiceDocument.Location = new System.Drawing.Point(348, 17);
            this.btnChoiceDocument.Name = "btnChoiceDocument";
            this.btnChoiceDocument.Size = new System.Drawing.Size(86, 23);
            this.btnChoiceDocument.TabIndex = 2;
            this.btnChoiceDocument.TabStop = false;
            this.btnChoiceDocument.Text = "选 择 文 件";
            this.btnChoiceDocument.UseVisualStyleBackColor = true;
            this.btnChoiceDocument.Click += new System.EventHandler(this.btnChoiceDocument_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // plInsert
            // 
            this.plInsert.Controls.Add(this.btnDocumentTypeCancel);
            this.plInsert.Controls.Add(this.btnDocumentTypeSave);
            this.plInsert.Controls.Add(this.txtDocumentType);
            this.plInsert.Controls.Add(this.plPrivateDocument);
            this.plInsert.Controls.Add(this.btnDocumentType);
            this.plInsert.Controls.Add(this.lblDocumentTpye);
            this.plInsert.Controls.Add(this.cboDocumentType);
            this.plInsert.Controls.Add(this.lblChoiceDocument);
            this.plInsert.Controls.Add(this.btnChoiceDocument);
            this.plInsert.Controls.Add(this.lblDocumentName);
            this.plInsert.Controls.Add(this.txtDocumentName);
            this.plInsert.Controls.Add(this.lblPrivateDocument);
            this.plInsert.Controls.Add(this.txtChoiceDocument);
            this.plInsert.Location = new System.Drawing.Point(12, 45);
            this.plInsert.Name = "plInsert";
            this.plInsert.Size = new System.Drawing.Size(514, 239);
            this.plInsert.TabIndex = 5;
            // 
            // btnDocumentTypeCancel
            // 
            this.btnDocumentTypeCancel.Location = new System.Drawing.Point(429, 147);
            this.btnDocumentTypeCancel.Name = "btnDocumentTypeCancel";
            this.btnDocumentTypeCancel.Size = new System.Drawing.Size(75, 23);
            this.btnDocumentTypeCancel.TabIndex = 10;
            this.btnDocumentTypeCancel.Text = "取  消";
            this.btnDocumentTypeCancel.UseVisualStyleBackColor = true;
            this.btnDocumentTypeCancel.Visible = false;
            this.btnDocumentTypeCancel.Click += new System.EventHandler(this.btnDocumentTypeCancel_Click);
            // 
            // btnDocumentTypeSave
            // 
            this.btnDocumentTypeSave.Location = new System.Drawing.Point(348, 147);
            this.btnDocumentTypeSave.Name = "btnDocumentTypeSave";
            this.btnDocumentTypeSave.Size = new System.Drawing.Size(75, 23);
            this.btnDocumentTypeSave.TabIndex = 9;
            this.btnDocumentTypeSave.Text = "保  存";
            this.btnDocumentTypeSave.UseVisualStyleBackColor = true;
            this.btnDocumentTypeSave.Visible = false;
            this.btnDocumentTypeSave.Click += new System.EventHandler(this.btnDocumentTypeSave_Click);
            // 
            // txtDocumentType
            // 
            this.txtDocumentType.Location = new System.Drawing.Point(348, 120);
            this.txtDocumentType.Name = "txtDocumentType";
            this.txtDocumentType.Size = new System.Drawing.Size(156, 21);
            this.txtDocumentType.TabIndex = 8;
            this.txtDocumentType.Visible = false;
            // 
            // plPrivateDocument
            // 
            this.plPrivateDocument.Controls.Add(this.rdoPrivateDocumentNo);
            this.plPrivateDocument.Controls.Add(this.rdoPrivateDocumentYes);
            this.plPrivateDocument.Location = new System.Drawing.Point(133, 72);
            this.plPrivateDocument.Name = "plPrivateDocument";
            this.plPrivateDocument.Size = new System.Drawing.Size(128, 16);
            this.plPrivateDocument.TabIndex = 4;
            // 
            // rdoPrivateDocumentNo
            // 
            this.rdoPrivateDocumentNo.AutoSize = true;
            this.rdoPrivateDocumentNo.Location = new System.Drawing.Point(56, 0);
            this.rdoPrivateDocumentNo.Name = "rdoPrivateDocumentNo";
            this.rdoPrivateDocumentNo.Size = new System.Drawing.Size(35, 16);
            this.rdoPrivateDocumentNo.TabIndex = 5;
            this.rdoPrivateDocumentNo.Text = "否";
            this.rdoPrivateDocumentNo.UseVisualStyleBackColor = true;
            // 
            // rdoPrivateDocumentYes
            // 
            this.rdoPrivateDocumentYes.AutoSize = true;
            this.rdoPrivateDocumentYes.Checked = true;
            this.rdoPrivateDocumentYes.Location = new System.Drawing.Point(0, 0);
            this.rdoPrivateDocumentYes.Name = "rdoPrivateDocumentYes";
            this.rdoPrivateDocumentYes.Size = new System.Drawing.Size(35, 16);
            this.rdoPrivateDocumentYes.TabIndex = 4;
            this.rdoPrivateDocumentYes.TabStop = true;
            this.rdoPrivateDocumentYes.Text = "是";
            this.rdoPrivateDocumentYes.UseVisualStyleBackColor = true;
            // 
            // btnDocumentType
            // 
            this.btnDocumentType.Location = new System.Drawing.Point(348, 91);
            this.btnDocumentType.Name = "btnDocumentType";
            this.btnDocumentType.Size = new System.Drawing.Size(86, 23);
            this.btnDocumentType.TabIndex = 7;
            this.btnDocumentType.TabStop = false;
            this.btnDocumentType.Text = "添加文件夹";
            this.btnDocumentType.UseVisualStyleBackColor = true;
            this.btnDocumentType.Click += new System.EventHandler(this.btnDocumentType_Click);
            // 
            // lblDocumentTpye
            // 
            this.lblDocumentTpye.AutoSize = true;
            this.lblDocumentTpye.Location = new System.Drawing.Point(50, 96);
            this.lblDocumentTpye.Name = "lblDocumentTpye";
            this.lblDocumentTpye.Size = new System.Drawing.Size(41, 12);
            this.lblDocumentTpye.TabIndex = 6;
            this.lblDocumentTpye.Text = "文件夹";
            // 
            // cboDocumentType
            // 
            this.cboDocumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocumentType.FormattingEnabled = true;
            this.cboDocumentType.Location = new System.Drawing.Point(133, 93);
            this.cboDocumentType.Name = "cboDocumentType";
            this.cboDocumentType.Size = new System.Drawing.Size(195, 20);
            this.cboDocumentType.TabIndex = 6;
            // 
            // btnDefine
            // 
            this.btnDefine.Location = new System.Drawing.Point(360, 290);
            this.btnDefine.Name = "btnDefine";
            this.btnDefine.Size = new System.Drawing.Size(75, 23);
            this.btnDefine.TabIndex = 11;
            this.btnDefine.Text = "确  定";
            this.btnDefine.UseVisualStyleBackColor = true;
            this.btnDefine.Click += new System.EventHandler(this.btnDefine_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(451, 290);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "取  消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 325);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDefine);
            this.Controls.Add(this.plInsert);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmInsert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加文件";
            this.Load += new System.EventHandler(this.frmInsert_Load);
            this.plInsert.ResumeLayout(false);
            this.plInsert.PerformLayout();
            this.plPrivateDocument.ResumeLayout(false);
            this.plPrivateDocument.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDocumentName;
        private System.Windows.Forms.Label lblChoiceDocument;
        private System.Windows.Forms.Label lblPrivateDocument;
        private System.Windows.Forms.TextBox txtChoiceDocument;
        private System.Windows.Forms.TextBox txtDocumentName;
        private System.Windows.Forms.Button btnChoiceDocument;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel plInsert;
        private System.Windows.Forms.Button btnDefine;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDocumentTpye;
        private System.Windows.Forms.ComboBox cboDocumentType;
        private System.Windows.Forms.Button btnDocumentType;
        private System.Windows.Forms.Panel plPrivateDocument;
        private System.Windows.Forms.RadioButton rdoPrivateDocumentNo;
        private System.Windows.Forms.RadioButton rdoPrivateDocumentYes;
        private System.Windows.Forms.Button btnDocumentTypeCancel;
        private System.Windows.Forms.Button btnDocumentTypeSave;
        private System.Windows.Forms.TextBox txtDocumentType;
    }
}