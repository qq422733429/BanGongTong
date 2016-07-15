using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using banggongtong.entity;

namespace 青鸟项目
{
    public partial class frmWatchNote : Form
    {
        WorkDailyRecord wdr;
        public frmWatchNote(WorkDailyRecord wdr)
        {
            InitializeComponent();
            this.wdr = wdr;
        }

        #region load事件
        private void frmWatchNote_Load(object sender, EventArgs e)
        {
            lblTimer.Text = wdr.RemindTime.ToString();
            lblImportanceLevel.Text = wdr.ImportanceLevel;
            txtContent.Text = wdr.Content;
        }
        
        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
