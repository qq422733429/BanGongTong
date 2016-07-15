namespace DocumentManager
{
    partial class frmLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.picPrivaterLogin = new System.Windows.Forms.PictureBox();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.lblPrivaterName = new System.Windows.Forms.Label();
            this.btnGuest = new System.Windows.Forms.Button();
            this.lblGuestLogin = new System.Windows.Forms.Label();
            this.picGuestLogin = new System.Windows.Forms.PictureBox();
            this.ilPlBackGroundImage = new System.Windows.Forms.ImageList(this.components);
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.btnPrivater = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPrivaterLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGuestLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // picPrivaterLogin
            // 
            this.picPrivaterLogin.BackColor = System.Drawing.Color.Transparent;
            this.picPrivaterLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picPrivaterLogin.BackgroundImage")));
            this.picPrivaterLogin.Location = new System.Drawing.Point(561, 207);
            this.picPrivaterLogin.Name = "picPrivaterLogin";
            this.picPrivaterLogin.Size = new System.Drawing.Size(47, 47);
            this.picPrivaterLogin.TabIndex = 0;
            this.picPrivaterLogin.TabStop = false;
            this.picPrivaterLogin.Click += new System.EventHandler(this.picPrivaterLogin_Click);
            // 
            // txtPassWord
            // 
            this.txtPassWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassWord.Location = new System.Drawing.Point(624, 233);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(115, 21);
            this.txtPassWord.TabIndex = 1;
            // 
            // lblPrivaterName
            // 
            this.lblPrivaterName.BackColor = System.Drawing.Color.Transparent;
            this.lblPrivaterName.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPrivaterName.Location = new System.Drawing.Point(620, 207);
            this.lblPrivaterName.Name = "lblPrivaterName";
            this.lblPrivaterName.Size = new System.Drawing.Size(132, 23);
            this.lblPrivaterName.TabIndex = 1;
            this.lblPrivaterName.Text = "Administrator";
            this.lblPrivaterName.Click += new System.EventHandler(this.picPrivaterLogin_Click);
            // 
            // btnGuest
            // 
            this.btnGuest.BackColor = System.Drawing.Color.Transparent;
            this.btnGuest.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuest.Location = new System.Drawing.Point(758, 310);
            this.btnGuest.Name = "btnGuest";
            this.btnGuest.Size = new System.Drawing.Size(50, 47);
            this.btnGuest.TabIndex = 2;
            this.btnGuest.Text = "登 录";
            this.btnGuest.UseVisualStyleBackColor = false;
            this.btnGuest.Click += new System.EventHandler(this.btnGuest_Click);
            // 
            // lblGuestLogin
            // 
            this.lblGuestLogin.BackColor = System.Drawing.Color.Transparent;
            this.lblGuestLogin.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGuestLogin.Location = new System.Drawing.Point(620, 310);
            this.lblGuestLogin.Name = "lblGuestLogin";
            this.lblGuestLogin.Size = new System.Drawing.Size(132, 23);
            this.lblGuestLogin.TabIndex = 1;
            this.lblGuestLogin.Text = "来宾账户";
            this.lblGuestLogin.Click += new System.EventHandler(this.picGuest_Click);
            // 
            // picGuestLogin
            // 
            this.picGuestLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picGuestLogin.BackgroundImage")));
            this.picGuestLogin.Location = new System.Drawing.Point(561, 310);
            this.picGuestLogin.Name = "picGuestLogin";
            this.picGuestLogin.Size = new System.Drawing.Size(47, 47);
            this.picGuestLogin.TabIndex = 0;
            this.picGuestLogin.TabStop = false;
            this.picGuestLogin.Click += new System.EventHandler(this.picGuest_Click);
            // 
            // ilPlBackGroundImage
            // 
            this.ilPlBackGroundImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilPlBackGroundImage.ImageStream")));
            this.ilPlBackGroundImage.TransparentColor = System.Drawing.Color.Transparent;
            this.ilPlBackGroundImage.Images.SetKeyName(0, "登录账户背景xx.jpg");
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
            // btnPrivater
            // 
            this.btnPrivater.BackColor = System.Drawing.Color.Transparent;
            this.btnPrivater.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrivater.Location = new System.Drawing.Point(758, 207);
            this.btnPrivater.Name = "btnPrivater";
            this.btnPrivater.Size = new System.Drawing.Size(50, 47);
            this.btnPrivater.TabIndex = 2;
            this.btnPrivater.Text = "登 录";
            this.btnPrivater.UseVisualStyleBackColor = false;
            this.btnPrivater.Click += new System.EventHandler(this.btnPrivater_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold);
            this.btnExit.Location = new System.Drawing.Point(931, 554);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(57, 52);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "退  出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1000, 618);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnGuest);
            this.Controls.Add(this.btnPrivater);
            this.Controls.Add(this.lblGuestLogin);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.picGuestLogin);
            this.Controls.Add(this.picPrivaterLogin);
            this.Controls.Add(this.lblPrivaterName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "办公通 1.0";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.Click += new System.EventHandler(this.frmLogin_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMian_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.picPrivaterLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGuestLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPrivaterLogin;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label lblPrivaterName;
        private System.Windows.Forms.Label lblGuestLogin;
        private System.Windows.Forms.PictureBox picGuestLogin;
        private System.Windows.Forms.ImageList ilPlBackGroundImage;
        private System.Windows.Forms.Button btnGuest;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.Button btnPrivater;
        private System.Windows.Forms.Button btnExit;
    }
}