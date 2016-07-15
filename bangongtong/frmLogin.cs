using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 青鸟项目;
using System.IO;
using System.Security.Cryptography;
using bangongtong.dal;

namespace DocumentManager
{
    public partial class frmLogin : Form
    {

        SetManager sm = new SetManager();

        public frmLogin()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = Environment.CurrentDirectory + @"\Page.ssk";//调用皮肤
        }

        /// <summary>
        /// 窗体移动代码
        /// </summary>
        int x, y, control;
        private void frmMian_MouseDown(object sender, MouseEventArgs e)
        {
            control = 1;
            x = e.X;
            y = e.Y;
        }
        private void frmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (control == 1)
            {
                Location = new Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));
            }
        }
        private void frmMain_MouseUp(object sender, MouseEventArgs e)
        {
            control = 0;
        }
        //点击私人图片登录操作
        private void picPrivaterLogin_Click(object sender, EventArgs e)
        {
            btnGuest.Visible = false;
            txtPassWord.Visible = true;
            btnPrivater.Visible = true;
        }
        //窗体加载操作
        private void frmLogin_Load(object sender, EventArgs e)
        {
            helpClass.yunxingPath = System.Environment.CurrentDirectory;

            txtPassWord.Visible = false;
            btnPrivater.Visible = false;
            btnGuest.Visible = false;




            if (!File.Exists(helpClass.yunxingPath + "\\files\\saveSetDate.bin"))
            {
                frmAdminName fan = new frmAdminName();
                fan.ShowDialog();
                if (!File.Exists(helpClass.yunxingPath + "\\files\\saveSetDate.bin"))
                {
                    Application.Exit();
                }
                sm.loadSet();
                lblPrivaterName.Text = sm.sd.AdminName;
            }
            else
            {
                sm.loadSet();
                lblPrivaterName.Text = sm.sd.AdminName;
            }
           



        }
        //点击窗体时操作
        private void frmLogin_Click(object sender, EventArgs e)
        {
            //部分控件可见度为false
            txtPassWord.Visible = false;
            btnPrivater.Visible = false;
            btnGuest.Visible = false;
           
        }
        //点击来宾图片登录操作
        private void picGuest_Click(object sender, EventArgs e)
        {
            txtPassWord.Visible = false;
            btnPrivater.Visible = false;
            btnGuest.Visible = true;
        }
        public static string GetMD5Hash(String input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] res = md5.ComputeHash(Encoding.Default.GetBytes(input), 0, input.Length);
            char[] temp = new char[res.Length];
            System.Array.Copy(res, temp, res.Length);
            return new String(temp);
        }         
        //点击私人登陆操作
        private void btnPrivater_Click(object sender, EventArgs e)
        {
            sm.loadSet();
            string pwdMd5 = GetMD5Hash(txtPassWord.Text.Trim());
            if (sm.sd.Password == pwdMd5)
            {
                frmMain frmMain = new frmMain();
                helpClass.admin = true;
                frmMain.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("密码错误","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtPassWord.Clear();
                txtPassWord.Focus();
                return;
            }
        }
        private void btnGuest_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain();
            helpClass.admin = false;
            frmMain.Show();
            this.Visible = false;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

    }
}
