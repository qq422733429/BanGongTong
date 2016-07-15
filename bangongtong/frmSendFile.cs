using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using bangongtong.util;
using banggongtong.entity;
using bangongtong.dal;

namespace 青鸟项目
{
    public partial class frmSendFile : Form
    {
        IPAddress ia;
        NetMemberManager nmm = new NetMemberManager();
        List<string> netMemberList = new List<string>();
        
        string documentName = null;
        bool sendFile = true;            //是选中人发送还是选中文件发送
        DocumentsManager dm = new DocumentsManager();
        string path = null;
        frmMain fm;



        #region 构造方法

        public frmSendFile(IPAddress ia, frmMain fm)
        {
            InitializeComponent();
            this.ia = ia;
            this.sendFile = false;
            this.fm = fm;
        }
        
        #endregion
        #region 构造方法2
        public frmSendFile(string documentName, frmMain fm)
        {
            InitializeComponent();
            this.documentName = documentName;
            this.sendFile = true;
            this.fm = fm;
        } 
        #endregion
        #region 发送文件代码

        private void btnAccept_Click(object sender, EventArgs e)
        {

            if (cboFile.Text == "" && txtFileName.Text == "")
            {
                MessageBox.Show("请选择文件");
                return;
            }
            if (cboNetMember.Text == "" && txtReceiveMember.Text == "")
            {
                MessageBox.Show("请选择收件人");
                return;
            }
            IPAddress ia1 = null;

            foreach (NetMember item in nmm.MemberList.Values)
            {
                if (item.Name.Trim() == txtReceiveMember.Text || item.Name == cboNetMember.Text)
                {
                    ia1 = item.Ia;
                }
            }
            string path = "";
            foreach (Document item in dm.Documents.Values)
            {
                if (item.Name == cboFile.Text.Trim() || item.Name == txtFileName.Text.Trim())
                {
                    path = item.Path;
                }
            }
            SendFile sf = new SendFile(ia1, path, fm);
            sf.statyReceive();
            this.Close();

        }
        
        #endregion
        #region 窗体LOAD事件
        private void frmSendFile_Load(object sender, EventArgs e)
        {
            dm.LoadDocuments();
            if (sendFile)
            {
                cboFile.Visible = false;
                cboFolder.Visible = false;
                lblFile.Visible = false;
                lblFolder.Visible = false;
                txtReceiveMember.Visible = false;

                foreach (string key in dm.Documents.Keys)
                {
                    if (key == documentName)
                    {
                        txtFileName.Text = key;
                        path = dm.Documents[key].Path;
                    }
                }
                nmm.load();
                foreach (NetMember item in nmm.MemberList.Values)
                {
                    if (item.Status)
                    {
                        netMemberList.Add(item.Name);
                    }
                }
                cboNetMember.DataSource = netMemberList;
            }
            else
            {
                cboNetMember.Visible = false;
                lblFileName.Visible = false;
                txtFileName.Visible = false;
                nmm.load();
                txtReceiveMember.Text = nmm.MemberList[ia].Name;
                dm.LoadDocumentType();
                cboFolder.DataSource = dm.DocumentType;
            }
        } 
        #endregion
        #region 选择不同的文件夹代码



        private void cboFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> documentList = new List<string>();
            foreach (string key in dm.Documents.Keys)
            {
                if (dm.Documents[key].Type == cboFolder.Text.Trim())
                {
                    documentList.Add(dm.Documents[key].Name);
                }
            }
            cboFile.DataSource = documentList;
        }
        
        #endregion



       
    }
}
