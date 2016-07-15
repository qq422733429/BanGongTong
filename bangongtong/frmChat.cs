using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using bangongtong.util;
using banggongtong.entity;
using bangongtong.dal;

namespace 青鸟项目
{
    public partial class frmChat : Form
    {
        private IPAddress ia;
        NetMember nm = new NetMember();
        NetMemberManager nmm = new NetMemberManager();
 
        private SenderMessage sm = new SenderMessage();
        frmMain fm;

        #region 构造方法

        public frmChat(IPAddress ia, frmMain fm)
        {
            InitializeComponent();
            this.ia = ia;
            this.fm = fm;
        } 
        #endregion
        #region 窗体LOAD事件

        private void frmChat_Load(object sender, EventArgs e)
        {
            nmm.load();
            nm = nmm.MemberList[ia];
            this.Text = "与 " + nm.Name + "聊天中";
            fresh();


        } 
        #endregion
        #region 聊天内容更新

        public void fresh()
        {
            nmm.load();
            string text = "";
            foreach (MessageNoet item in nmm.MemberList[ia].MessageLog)
            {
                if (item.Poeple)
                {
                    text += "   " + nmm.MemberList[ia].Name + "\t\t时间:" + item.DateTime.ToString() + "\r\n   " + item.Message1 + "\r\n\r\n\r\n";
                }
                else
                {
                    text += "   我" + "\t\t时间:" + item.DateTime.ToString() + "\r\n   " + item.Message1 + "\r\n\r\n\r\n";
                }

            }
            txtReceive.Text = text;
            txtReceive.AppendText("  ");

        } 
        #endregion


        #region 发送输入的信息

        private void vtnSend_Click(object sender, EventArgs e)
        {
            nmm.load();
            if (txtSend.Text == "")
            {

                MessageBox.Show("请输入要发送的内容!");
                return;
            }
            else
            {
                MessageNoet ms = new MessageNoet();
                ms.DateTime = DateTime.Now;
                ms.Message1 = txtSend.Text;
                nmm.MemberList[ia].MessageLog.Add(ms);
                nmm.saveTo();
                sm.SendMessage(txtSend.Text, ia);
                txtSend.Text = "";
                fresh();
            }
        }
        
        #endregion

        private void timFresh_Tick(object sender, EventArgs e)
        {
            fresh();
        }

        private void frmChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            fm.chatFromList.Remove(ia);
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
    


