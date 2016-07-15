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
    public partial class frmRemindSet : Form
    {
        SetManager sm = new SetManager();
        public frmRemindSet()
        {
            InitializeComponent();
        }
        #region 保存提醒设置
        private void btnaccept_Click(object sender, EventArgs e)
        {
            sm.loadSet();
            int aheadTime = Convert.ToInt32(cboAheadTime.Text);
            sm.sd.AheadTime = aheadTime;
            int frequency = Convert.ToInt32(cboFrequency.Text);
            sm.sd.Frequency = frequency;
            sm.saveToSet();
            this.Close();

        }
        
        #endregion
        #region load事件
        private void frmRemindSet_Load(object sender, EventArgs e)
        {
            cboFrequency.SelectedIndex = 0;
            cboAheadTime.SelectedIndex = 0;
        } 
        #endregion

    }
}
