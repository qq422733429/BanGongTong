using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using banggongtong.entity;
using bangongtong.dal;


namespace 青鸟项目
{
    public partial class frmChangeName : Form
    {
        Dictionary<IPAddress, NetMember> memberList = new Dictionary<IPAddress, NetMember>();
        NetMemberManager nmm = new NetMemberManager();
        IPAddress ia;
        frmMain fm;
        #region 构造方法
        public frmChangeName(IPAddress ia, frmMain fm)
        {
            InitializeComponent();
            this.ia = ia;
            this.fm = fm;
        } 
        #endregion
        #region 保存修改密码

        private void btnSave_Click(object sender, EventArgs e)
        {
            nmm.load();
            nmm.MemberList[ia].Name = txtChangeName.Text;
            nmm.saveTo();
            MessageBox.Show("修改成功");
            this.Close();
        }
        
        #endregion
        #region 关闭窗口
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        #endregion
        #region 调用主窗体刷新方法
        private void frmChangeName_FormClosed(object sender, FormClosedEventArgs e)
        {
            fm.UpdateTreeView();
        } 
        #endregion
    }
}
