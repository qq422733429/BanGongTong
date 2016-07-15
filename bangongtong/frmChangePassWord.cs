using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using bangongtong.dal;

namespace 青鸟项目
{
    public partial class frmChangePassWord : Form
    {
        public frmChangePassWord()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = Environment.CurrentDirectory + @"\Page.ssk";
        }
        SetManager sm = new SetManager();
       

        //关闭窗体
        private void 取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static string GetMD5Hash(String input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] res = md5.ComputeHash(Encoding.Default.GetBytes(input), 0, input.Length);
            char[] temp = new char[res.Length];
            System.Array.Copy(res, temp, res.Length);
            return new String(temp);
        }
        //点击确定保存新密码时操作
        private void btnDefine_Click(object sender, EventArgs e)
        {
            
            //输入非空验证
            if (txtOldPassWord.Text.Trim() == "")
            {
                MessageBox.Show("密码不能为空！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtOldPassWord.Focus();
                return;
            }
            if (txtNewPassWord.Text.Trim() == "")
            {
                MessageBox.Show("新密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNewPassWord.Focus();
                return;
            }
            if (txtDefinePassWprd.Text.Trim() == "")
            {
                MessageBox.Show("确认密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDefinePassWprd.Focus();
                return;
            }
            //导出读取的数据
            sm.loadSet();
            string oldpwd=GetMD5Hash(txtOldPassWord.Text.Trim());
            if (sm.sd.Password == oldpwd)
            {
                if (txtNewPassWord.Text.Trim() == txtDefinePassWprd.Text.Trim())
                {
                    string newPwd = GetMD5Hash(txtNewPassWord.Text.Trim());
                    sm.sd.Password = newPwd;
                    sm.saveToSet();
                    MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("两次密码输入不一致！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("密码输入错误！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
    }
}
