using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using banggongtong.entity;
using bangongtong.dal;

namespace 青鸟项目
{
    public partial class frmInsert : Form
    {
        frmMain fm = null;
        
        public frmInsert(frmMain fm)
        {
            InitializeComponent();
            this.fm = fm;
        }
        string path;
        DocumentsManager dm = new DocumentsManager();                            //初始化dm

        string documentType = null;

        //构造方法，传入文件路径
        public frmInsert(string path,frmMain fm)
        {
            InitializeComponent();
            this.path = path;
            this.fm = fm;
        }

        //关闭窗体
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //选择文件
        private void btnChoiceDocument_Click(object sender, EventArgs e)
        {
            //获取路径
            Object aa = openFileDialog1.ShowDialog();
            if (aa == null)
            {
                MessageBox.Show("文件不能为空！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtChoiceDocument.Focus();
                return;
            }
            //提取文件路径，并截取路径中的文件名
            string path = openFileDialog1.FileName.ToString();
            txtChoiceDocument.Text = path;
            int index = path.LastIndexOf("\\");
            string documentName = path.Substring(index + 1);
            txtDocumentName.Text = documentName;
            int documentType_index = path.LastIndexOf(".");
            documentType = path.Substring(documentType_index + 1);
        }

        //保存文件时操作
        private void btnDefine_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            Document doc = new Document();

            if (rdoPrivateDocumentYes.Checked)
            {
                doc.SafeLevel = true;               //登录人可见为true
            }
            else if (rdoPrivateDocumentNo.Checked)
            {
                doc.SafeLevel = false;              //来宾可见为false
            }

            if (verification())
            {
                doc.Type = cboDocumentType.Text;    //文件类型
                doc.Name = txtDocumentName.Text;        //文件名
                doc.Path = helpClass.yunxingPath+ "\\files\\MyDocument\\" + txtDocumentName.Text.ToString();      //文件地址
                doc.SaveTime = dt.ToString();   //保存时间
                doc.Character = documentType;   //文件后缀

                dm.LoadDocuments();
                bool delete = false;

                foreach (Document document in dm.Documents.Values)
                {
                    if (document.Name == doc.Name)
                    {
                        DialogResult result =  MessageBox.Show("已存在同名文件"+doc.Name+",是否替换此文件？","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
                        {
                            File.Delete(document.Path);
                            delete = true;
                        }
                        else
                        {
                            return;
                        }
                    }
                }

                if (delete)
                {
                    dm.Documents.Remove(doc.Name);
                    dm.SaveDocuments();
                    dm.LoadDocuments();
                }

                switch (doc.Character.ToUpper())
                {
                    case "PNG":
                    case "JPG":
                    case "BMP":
                    case "DOC":
                    case "DOCX":
                    case "XLS":
                    case "PPT":
                    case "PPTX":
                    case "TXT":
                    case "RAR":
                    case "ZIP":
                        dm.Documents.Add(doc.Name, doc);
                        break;
                    default:
                        MessageBox.Show("文件格式不支持", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }

                dm.SaveDocuments();             //添加文件到documents中
                
                    fm.Update_tvMain();


                    try
                    {

                    
                File.Copy(txtChoiceDocument.Text.ToString(), doc.Path, false);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("该文件已经存在，不能添加");
                        this.Close();
                    }
                this.Close();
            }
        }

        //添加文件类型
        private void btnDocumentType_Click(object sender, EventArgs e)
        {
            //添加文件按键不可用，同时显示所有添加文件类型的相应控件
            this.btnDocumentType.Enabled = false;
            this.txtDocumentType.Visible = true;
            this.btnDocumentTypeSave.Visible = true;
            this.btnDocumentTypeCancel.Visible = true;
        }

        //窗体加载
        private void frmInsert_Load(object sender, EventArgs e)
        {
            UpdateDocumentType();
            if (helpClass.control)
            {
                helpClass.control = false;
                txtChoiceDocument.Text = path;//显示文件地址
                txtDocumentName.Text = path.Substring(path.LastIndexOf('\\') + 1);//显示文件名
                cboDocumentType.Text = helpClass.documentType;
                int documentType_index = txtChoiceDocument.Text.LastIndexOf(".");
                documentType = txtChoiceDocument.Text.Substring(documentType_index + 1);
            }
        }

        //更新文件类型
        private void UpdateDocumentType()
        {
           dm.LoadDocumentType();
           this.cboDocumentType.DataSource = dm.DocumentType;//绑定数据源
        }

        //保存新添加的文件类型
        private void btnDocumentTypeSave_Click(object sender, EventArgs e)
        {
            if (txtDocumentType.Text.Length == 0)
            {
                MessageBox.Show("请选择文件夹","提示");
                txtDocumentType.Focus();
                return;
            }
            dm.DocumentType.Add(txtDocumentType.Text.Trim());//保存新添加的文件类型
            dm.SaveDocumentType();
            UpdateDocumentType();
            this.txtDocumentType.Visible = false;
            this.btnDocumentTypeSave.Visible = false;
            this.btnDocumentTypeCancel.Visible = false;
            this.btnDocumentType.Enabled = true;
        }

        //取消添加文件
        private void btnDocumentTypeCancel_Click(object sender, EventArgs e)
        {
            this.txtDocumentType.Visible = false;
            this.btnDocumentTypeSave.Visible = false;
            this.btnDocumentTypeCancel.Visible = false;
            this.btnDocumentType.Enabled = true;
        }

        //验证输入非空
        public bool verification()
        {
            if (txtChoiceDocument.Text.Length == 0)
            {
                MessageBox.Show("文件地址不能为空","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtChoiceDocument.Focus();
                return false;
            }
            if (txtDocumentName.Text.Length == 0)
            {
                MessageBox.Show("文件名不能为空","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtDocumentName.Focus();
                return false;
            }
            if (cboDocumentType.Text.Length == 0)
            {
                MessageBox.Show("文件夹不能为空","提示",MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboDocumentType.Focus();
                return false;
            }
            return true;
        }
    }
}
