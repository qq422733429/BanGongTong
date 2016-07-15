using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using bangongtong.dal;

namespace 青鸟项目
{
    public partial class frmSendFolder : Form
    {
      

        DocumentsManager dm = new DocumentsManager();
        string documentName = null;
        frmMain frmMain = null;
        #region 构造方法
        public frmSendFolder(string documentName, frmMain frmMain)
        {
            InitializeComponent();
            this.documentName = documentName;
            this.frmMain = frmMain;
        } 
        #endregion
        #region 窗体加载时工作
        //窗体加载时工作
        private void frmSendFolder_Load(object sender, EventArgs e)
        {
            dm.LoadDocumentType();
            cboFolder.DataSource = dm.DocumentType;
        } 
        #endregion
        #region 发送文件到指定文件夹

        //发送文件到指定文件夹
        private void btnSend_Click(object sender, EventArgs e)
        {
            dm.LoadDocuments();
            string documentSuffix = null;
            if (cboFolder.Text.Trim().Length == 0)
            {
                MessageBox.Show("请选择文件夹！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            foreach (string key in dm.Documents.Keys)
            {
                if (key == documentName)
                {
                    dm.Documents[key].Type = cboFolder.Text.Trim();
                    int documentSuffix_index = dm.Documents[key].Name.LastIndexOf(".");
                    documentSuffix = dm.Documents[key].Name.Substring(documentSuffix_index + 1);
                    if (dm.Documents[key].Type == helpClass.documentType)
                    {
                        frmMain.AddItems(documentSuffix, dm.Documents[key]);
                    }
                }
            }
            dm.SaveDocuments();
            this.Close();
        } 
        #endregion
        #region 关闭窗口
        //关闭窗口
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion
    }
}
