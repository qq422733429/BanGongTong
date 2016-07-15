using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using banggongtong.entity;
using bangongtong.dal;

namespace 青鸟项目
{
    public partial class frmInsertNote : Form
    {
        frmMain fm;
        int xiugai=0;
        WorkDailyRecord wdrChange = new WorkDailyRecord();
        
        public frmInsertNote(frmMain fm)
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = Environment.CurrentDirectory + @"\Page.ssk";//调用皮肤
            this.fm = fm;
        }
        public frmInsertNote(frmMain fm,int a,WorkDailyRecord wdrChange)
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = Environment.CurrentDirectory + @"\Page.ssk";//调用皮肤
            this.fm = fm;
            this.xiugai = a;
            this.wdrChange = wdrChange;
        }
        NoteManager nm = new NoteManager();

        private void frmInsertNote_Load(object sender, EventArgs e)
        {
            if (xiugai!=0)
            {
                cboHour.Text = wdrChange.RemindTime.Hour.ToString();
                txtContent.Text = wdrChange.Content;
                if (wdrChange.ImportanceLevel=="提醒")
                {
                    rbYes.Select();
                }
                else
                {
                    rbNo.Select();
                }
            }
        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboHour.Text=="")
            {
                MessageBox.Show("请选择几点提醒");
                return;
            }
            if (txtContent.Text == "")
            {
                MessageBox.Show("日志内容不能为空");
                return;
            }
            
           

            
            WorkDailyRecord wdr = new WorkDailyRecord();
            DateTime date = dtpDate.Value;
            string datexianshi = date.ToLongDateString().ToString();
            string hour = cboHour.Text;
            string dateTime = datexianshi + " " + hour + ":00:00";
            DateTime dateLast = DateTime.Parse(dateTime); //最终处理完成的时间
            wdr.RemindTime = dateLast;
            if (rbYes.Checked)
            {
                wdr.ImportanceLevel = "提醒";
            }
            else
            {
                wdr.ImportanceLevel = "不提醒";
            }
            wdr.Content = txtContent.Text;
            nm.load();
            nm.loadId();
            if (xiugai != 0)
            {
                nm.NoteList.Remove(xiugai);
            }
            wdr.NoteId = nm.NoteId + 1;
            nm.NoteId++;
            nm.NoteList.Add(nm.NoteId, wdr);
            nm.saveToId();
            nm.saveTo();
            this.Close();
            

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInsertNote_FormClosed(object sender, FormClosedEventArgs e)
        {
            fm.fresh();
        }
    }
}
