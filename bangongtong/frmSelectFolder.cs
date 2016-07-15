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
    public partial class frmSelectFolder : Form
    {
        public frmSelectFolder(frmMain frmMain)
        {
            InitializeComponent();
            this.fm = frmMain;
        }

        frmMain fm = null;
        DocumentsManager dm = new DocumentsManager();
        #region 查找文件

        //查找文件
        private void btnSelect_Click(object sender, EventArgs e)
        {
            string documentSuffix = null;
            dm.LoadDocuments();
            string folerInfo = txtSelectFolder.Text.Trim();
            foreach (string key in dm.Documents.Keys)
            {
                if (helpClass.admin)
                {
                    int i = 0;
                    while (i + folerInfo.Length < dm.Documents[key].Name.Length)
                    {
                        if (dm.Documents[key].Name.Substring(i, folerInfo.Length) == folerInfo)
                        {
                            int documentSuffix_index = dm.Documents[key].Name.LastIndexOf(".");
                            documentSuffix = dm.Documents[key].Name.Substring(documentSuffix_index + 1);
                            fm.AddItems(documentSuffix, dm.Documents[key]);
                            break;
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
                else
                {
                    if (helpClass.admin == dm.Documents[key].SafeLevel)
                    {
                        int i = 0;
                        while (i + folerInfo.Length < dm.Documents[key].Name.Length)
                        {
                            if (dm.Documents[key].Name.Substring(i, folerInfo.Length) == folerInfo)
                            {
                                int documentSuffix_index = dm.Documents[key].Name.LastIndexOf(".");
                                documentSuffix = dm.Documents[key].Name.Substring(documentSuffix_index + 1);
                                fm.AddItems(documentSuffix, dm.Documents[key]);
                                break;
                            }
                            else
                            {
                                i++;
                            }
                        }
                    }
                }
            }
            this.Close();
        } 
        #endregion
        #region 取消关闭窗体

        //取消关闭窗体
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion
    }
}
