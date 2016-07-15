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
    public partial class frmAddFolder : Form
    {
        frmMain frmMain;
        DocumentsManager dm = new DocumentsManager();
        //构造方法
        public frmAddFolder()
        {
            InitializeComponent();
        }
        //构造方法2
        public frmAddFolder(frmMain frmMain)
        {
            InitializeComponent();
            this.frmMain = frmMain;
        }

       
        #region 添加文件夹

        //添加文件夹
        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            dm.LoadDocumentType();
            if (txtAddFolder.Text.Length == 0)
            {
                MessageBox.Show("请输入文件夹名", "提示");
                txtAddFolder.Focus();
                return;
            }
            dm.DocumentType.Add(txtAddFolder.Text.Trim());//保存新添加的文件类型
            dm.SaveDocumentType();
            frmMain.Update_tvMain();
            this.Close();
        }
        
        #endregion
        #region 取消
        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        private void frmAddFolder_Load(object sender, EventArgs e)
        {

        }
    }
}
