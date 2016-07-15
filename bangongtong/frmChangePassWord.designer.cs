namespace 青鸟项目
{
    partial class frmChangePassWord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePassWord));
            this.txtOldPassWord = new System.Windows.Forms.TextBox();
            this.txtNewPassWord = new System.Windows.Forms.TextBox();
            this.txtDefinePassWprd = new System.Windows.Forms.TextBox();
            this.lblOldPassWord = new System.Windows.Forms.Label();
            this.lblNewPassWord = new System.Windows.Forms.Label();
            this.lblDefinePassWord = new System.Windows.Forms.Label();
            this.btnDefine = new System.Windows.Forms.Button();
            this.取消 = new System.Windows.Forms.Button();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.SuspendLayout();
            // 
            // txtOldPassWord
            // 
            this.txtOldPassWord.Location = new System.Drawing.Point(92, 12);
            this.txtOldPassWord.Name = "txtOldPassWord";
            this.txtOldPassWord.PasswordChar = '*';
            this.txtOldPassWord.Size = new System.Drawing.Size(166, 21);
            this.txtOldPassWord.TabIndex = 0;
            // 
            // txtNewPassWord
            // 
            this.txtNewPassWord.Location = new System.Drawing.Point(92, 43);
            this.txtNewPassWord.Name = "txtNewPassWord";
            this.txtNewPassWord.PasswordChar = '*';
            this.txtNewPassWord.Size = new System.Drawing.Size(166, 21);
            this.txtNewPassWord.TabIndex = 1;
            // 
            // txtDefinePassWprd
            // 
            this.txtDefinePassWprd.Location = new System.Drawing.Point(92, 74);
            this.txtDefinePassWprd.Name = "txtDefinePassWprd";
            this.txtDefinePassWprd.PasswordChar = '*';
            this.txtDefinePassWprd.Size = new System.Drawing.Size(166, 21);
            this.txtDefinePassWprd.TabIndex = 2;
            // 
            // lblOldPassWord
            // 
            this.lblOldPassWord.AutoSize = true;
            this.lblOldPassWord.Location = new System.Drawing.Point(27, 15);
            this.lblOldPassWord.Name = "lblOldPassWord";
            this.lblOldPassWord.Size = new System.Drawing.Size(41, 12);
            this.lblOldPassWord.TabIndex = 6;
            this.lblOldPassWord.Text = "旧密码";
            // 
            // lblNewPassWord
            // 
            this.lblNewPassWord.AutoSize = true;
            this.lblNewPassWord.Location = new System.Drawing.Point(27, 46);
            this.lblNewPassWord.Name = "lblNewPassWord";
            this.lblNewPassWord.Size = new System.Drawing.Size(41, 12);
            this.lblNewPassWord.TabIndex = 6;
            this.lblNewPassWord.Text = "新密码";
            // 
            // lblDefinePassWord
            // 
            this.lblDefinePassWord.AutoSize = true;
            this.lblDefinePassWord.Location = new System.Drawing.Point(15, 77);
            this.lblDefinePassWord.Name = "lblDefinePassWord";
            this.lblDefinePassWord.Size = new System.Drawing.Size(53, 12);
            this.lblDefinePassWord.TabIndex = 6;
            this.lblDefinePassWord.Text = "确认密码";
            // 
            // btnDefine
            // 
            this.btnDefine.Location = new System.Drawing.Point(63, 119);
            this.btnDefine.Name = "btnDefine";
            this.btnDefine.Size = new System.Drawing.Size(75, 23);
            this.btnDefine.TabIndex = 3;
            this.btnDefine.Text = "确定";
            this.btnDefine.UseVisualStyleBackColor = true;
            this.btnDefine.Click += new System.EventHandler(this.btnDefine_Click);
            // 
            // 取消
            // 
            this.取消.Location = new System.Drawing.Point(168, 119);
            this.取消.Name = "取消";
            this.取消.Size = new System.Drawing.Size(75, 23);
            this.取消.TabIndex = 4;
            this.取消.Text = "取消";
            this.取消.UseVisualStyleBackColor = true;
            this.取消.Click += new System.EventHandler(this.取消_Click);
            // 
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // frmChangePassWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 154);
            this.Controls.Add(this.取消);
            this.Controls.Add(this.btnDefine);
            this.Controls.Add(this.lblDefinePassWord);
            this.Controls.Add(this.lblNewPassWord);
            this.Controls.Add(this.lblOldPassWord);
            this.Controls.Add(this.txtDefinePassWprd);
            this.Controls.Add(this.txtNewPassWord);
            this.Controls.Add(this.txtOldPassWord);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmChangePassWord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOldPassWord;
        private System.Windows.Forms.TextBox txtNewPassWord;
        private System.Windows.Forms.TextBox txtDefinePassWprd;
        private System.Windows.Forms.Label lblOldPassWord;
        private System.Windows.Forms.Label lblNewPassWord;
        private System.Windows.Forms.Label lblDefinePassWord;
        private System.Windows.Forms.Button btnDefine;
        private System.Windows.Forms.Button 取消;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
    }
}