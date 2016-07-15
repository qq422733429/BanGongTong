using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using bangongtong;
using bangongtong.dal;

namespace 青鸟项目
{
    public partial class frmAdminName : Form
    {
        SetManager sm = new SetManager();
        //构造方法
        public frmAdminName()
        {
            InitializeComponent();
        }
        #region 确认保存信息

        private void btnAccept_Click(object sender, EventArgs e)
        {
            sm.sd.AdminName = txtName.Text.Trim();
            sm.sd.Password = GetMD5Hash(txtPassword.Text.Trim());
            sm.sd.AheadTime = 1;
            sm.sd.Frequency = 10;
            sm.saveToSet();
            MessageBox.Show("信息保存成功！");
            this.Close();
        }
        
        #endregion
        #region MD5加密

        public static string GetMD5Hash(String input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] res = md5.ComputeHash(Encoding.Default.GetBytes(input), 0, input.Length);
            char[] temp = new char[res.Length];
            System.Array.Copy(res, temp, res.Length);
            return new String(temp);
        } 
        #endregion
        #region 退出程序

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }  
        #endregion
    }
}
