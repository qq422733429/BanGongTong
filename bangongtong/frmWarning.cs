using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using banggongtong.entity;
using bangongtong.dal;

namespace 青鸟项目
{
    public partial class frmWarning : Form
    {

        WorkDailyRecord wdr = new WorkDailyRecord();
        int noteId = 0;
        frmMain fm;
        NoteManager nm = new NoteManager();
        #region 构造函数

        public frmWarning(int noteId, frmMain fm)
        {
            InitializeComponent();
            this.noteId = noteId;
            this.fm = fm;
        } 
        #endregion
        #region 窗体load事件
        public void frmWarning_Load(object sender, EventArgs e)
        {
            nm.load();
            wdr = nm.NoteList[noteId];
            lblTimer.Text = "提醒时间： " + wdr.RemindTime.ToString();
            int length = wdr.Content.Length;
            char[] a = wdr.Content.ToCharArray();
            StringBuilder sb = new StringBuilder();
            int temp = 0;
            for (int i = 0; i < length; i++)
            {
                temp++;
                if (temp == 14)
                {
                    sb.Append("\r\n");
                    temp = 0;
                }
                sb.Append(a[i]);
            }
            lblContent.Text = sb.ToString();
        }
	#endregion
        #region 不再提醒事件

        private void btnWarning_Click(object sender, EventArgs e)
        {
            nm.load();
            nm.NoteList[noteId].ImportanceLevel = "不再提醒";
            nm.saveTo();
            fm.fresh();
            this.Close();

        }

        
        #endregion

    }
}
