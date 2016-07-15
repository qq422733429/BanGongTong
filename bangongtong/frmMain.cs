using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Diagnostics;
using banggongtong.entity;
using bangongtong.util;
using bangongtong.dal;

namespace 青鸟项目
{
    public partial class frmMain : Form
    {
        #region 各种申请实例对象
        NoteManager nm = new NoteManager();                                                                  //创建noteManager实例
        public NetMemberManager nmm = new NetMemberManager();                                              //创建NetMemberManager实例
        SetManager sm = new SetManager();                                                                  //创建SetManager实例
        DocumentsManager dm = new DocumentsManager();                                                      //创建DocumentsManager实例
        FreshMember freshm = new FreshMember();                                                            //创建SetManager实例
        Dictionary<int, WorkDailyRecord> list = new Dictionary<int, WorkDailyRecord>();                     //创建Dictionary实例
        List<WorkDailyRecord> noteList = new List<WorkDailyRecord>();                                      //创建List实例
        Dictionary<IPAddress, NetMember> nmb = new Dictionary<IPAddress, NetMember>();                      //创建Dictionary实例
        Listener lis;                                                                                        //监听类对象
        public Dictionary<IPAddress, frmChat> chatFromList = new Dictionary<IPAddress, frmChat>();         //创建SetManager实例
        List<int> selectindex = new List<int>();                                                            //定义一个int型的泛型
        bool newMessage = false;                                                                           //判断是否有新消息
        bool exit = false;                                                                                 //判断是否退出程序
        UpMemberDate umd = new UpMemberDate();                                                              //创建UpMemberDate实例
        SendFile sf;                                                                                        //申明SendFile
        
        #endregion
        #region 构造函数
        public frmMain()
        {
            InitializeComponent();
        } 
        #endregion
        #region load函数

        //窗体加载时的操作
        private void frmMain_Load(object sender, EventArgs e)
        {
            Update_tvMain();
            nm.load();//读取bin文件
            list = nm.NoteList;//将数据放入Dictionary<int, WorkDailyRecord>中
            foreach (WorkDailyRecord item in list.Values)
            {
                noteList.Add(item);//数据放入 List<WorkDailyRecord>中，方便显示
            }
            dgvNote.DataSource = noteList;//绑定数据源


            //启动监听程序消息
            lis = new Listener(this);
            lis.StartListen();

            listenMember lm = new listenMember();
            lm.startlistenMenber();


            //启动文件传输监听
            sf = new SendFile(this);
            sf.startListener();


            //开始更新全局域网用户
            upMemberDate();

            if (!helpClass.admin)
            {
                TabPage tp = tbcMain.TabPages[1];

                tbcMain.TabPages.Remove(tp);
                timRemind.Enabled = false;
            }
        }
        
        #endregion
        #region 窗体移动代码

        int x, y, control;
        private void frmMian_MouseDown(object sender, MouseEventArgs e)
        {
            control = 1;
            x = e.X;
            y = e.Y;
        }

        private void frmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (control == 1)
            {
                Location = new Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));
            }
        }

        private void frmMain_MouseUp(object sender, MouseEventArgs e)
        {
            control = 0;
        }
        #endregion
        #region 判断主窗体若为关闭窗口，则让其隐藏
        //判断若为关闭窗口，则让其隐藏
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exit)
            {
                this.Hide();
                e.Cancel = true;
            }
        }
        #endregion
        #region 最小托盘代码全部代码
        //托盘右键菜单退出程序
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认退出？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                lis.Stop();
                sf.stopFileListener();
                freshm.stopFreshFriends();
                this.notifyIcon1.Dispose();
                exit = true;
                downState();
                Application.Exit();
            }

        }
        //托盘右键菜单显示主窗体
        private void tsmiShowMainFrom_Click(object sender, EventArgs e)
        {
            this.Visible = true;
        }
        //双击托盘图标
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
        }



        #endregion
        #region 退出按钮
        private void btnExit_Click(object sender, EventArgs e)
        {

            tsmiExit_Click(sender, e);

        }

        #endregion
        #region 退出按钮2

        private void button1_Click(object sender, EventArgs e)
        {
            tsmiExit_Click(sender, e);
        }

        #endregion
        #region 退出按钮3
        private void btnExit3_Click(object sender, EventArgs e)
        {
            tsmiExit_Click(sender, e);
        } 
        #endregion
        #region 修改私人用户密码

        //修改私人用户密码
        private void btnChangPwd_Click(object sender, EventArgs e)
        {
            //弹出修改密码窗体
            frmChangePassWord frmChangePassWord = new frmChangePassWord();
            frmChangePassWord.ShowDialog();
        }
        #endregion


        #region 工作日志的全部代码


        #region 修改提醒设置
        private void btnRemind_Click(object sender, EventArgs e)
        {
            frmRemindSet frs = new frmRemindSet();
            frs.ShowDialog();
        }

        #endregion
        #region 添加日志

        //添加日志
        private void btnInsert_Click(object sender, EventArgs e)
        {
            frmInsertNote fin = new frmInsertNote(this);
            DialogResult result = fin.ShowDialog();
            if (result.ToString() == "Abort")
            {
                fresh();
            }
        }
        #endregion
        #region 刷新所有的日志列表并在控件显示
        //刷新
        public void fresh()
        {
            Dictionary<int, WorkDailyRecord> list1 = new Dictionary<int, WorkDailyRecord>();
            List<WorkDailyRecord> noteList1 = new List<WorkDailyRecord>();
            nm.load();//读取bin文件
            list1 = nm.NoteList;//将数据放入Dictionary<int, WorkDailyRecord>中
            foreach (WorkDailyRecord item in list1.Values)
            {
                noteList1.Add(item);//数据放入 List<WorkDailyRecord>中，方便显示
            }
            dgvNote.DataSource = noteList1;//绑定数据源


        }
        #endregion
        #region 查看日志
        //查看日志
        private void btnWatch_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dgvr = dgvNote.SelectedRows[0];
                int noteID = Convert.ToInt32(dgvr.Cells["noteId"].Value.ToString());
                nm.load();//读取bin文件
                list = nm.NoteList;//将数据放入Dictionary<int, WorkDailyRecord>中
                frmWatchNote fwn = new frmWatchNote(list[noteID]);
                fwn.ShowDialog();
                fresh();
            }
            catch (Exception)
            {

                MessageBox.Show("请选择一条日志");
            }
        }
        #endregion
        #region 删除日志
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dgvr = dgvNote.SelectedRows[0];
                int noteID = Convert.ToInt32(dgvr.Cells["noteId"].Value.ToString());
                nm.load();//读取bin文件
                nm.NoteList.Remove(noteID);
                nm.saveTo();
                fresh();
            }
            catch (Exception)
            {

                MessageBox.Show("请选择一条日志");
            }
        }
        #endregion
        #region 修改日志
        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dgvr = dgvNote.SelectedRows[0];
                int noteID = Convert.ToInt32(dgvr.Cells["noteId"].Value.ToString());
                nm.load();//读取bin文件
                frmInsertNote frn = new frmInsertNote(this, noteID, nm.NoteList[noteID]);
                frn.ShowDialog();
            }
            catch (Exception)
            {

                MessageBox.Show("请选择一条日志");
            }
        }
        #endregion
        #region 日志列表的右键菜单各个按钮的代码

        private void tsmiFreshFriends_Click(object sender, EventArgs e)
        {
            fresh();
        }

        private void tsmiAddNote_Click(object sender, EventArgs e)
        {
            btnInsert_Click(sender, e);
        }
        private void tmsiWatchNote_Click(object sender, EventArgs e)
        {
            btnWatch_Click(sender, e);
        }

        private void tmsiChangeNote_Click(object sender, EventArgs e)
        {
            btnChange_Click(sender, e);
        }
        private void tmsiDeleteNote_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender, e);
        }
        private void tmsiRemindSet_Click(object sender, EventArgs e)
        {
            btnRemind_Click(sender, e);
        }

     
        #endregion
        #region 日期控件所选择的日期变化时，根据所选的日期，搜索所有日志中符合条件的，并在控件中显示
        //日期变化，搜索功能
        private void mcTimer_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDatatime = mcTimer.SelectionStart;
            int selectYear = selectedDatatime.Year;
            int selectMonth = selectedDatatime.Month;
            int selectDay = selectedDatatime.Day;
            nm.load();
            Dictionary<int, WorkDailyRecord> searchDictionary = nm.NoteList;
            List<WorkDailyRecord> searchList = new List<WorkDailyRecord>();
            foreach (WorkDailyRecord item in searchDictionary.Values)
            {
                DateTime searchDatatime = item.RemindTime;
                int year = searchDatatime.Year;
                int month = searchDatatime.Month;
                int day = searchDatatime.Day;
                if (selectDay == day && selectMonth == month && selectYear == year)
                {
                    searchList.Add(item);
                }
            }
            dgvNote.DataSource = searchList;

        }

        #endregion
        #region 右键点击时，选中鼠标所在行，同时弹出右键菜单，右键菜单判断显示那些选项
        //右键dgv选中
        private void dgvNote_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dgvNote.Rows[e.RowIndex].Selected == false)
                    {
                        dgvNote.ClearSelection();
                        dgvNote.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dgvNote.SelectedRows.Count == 1)
                    {
                        dgvNote.CurrentCell = dgvNote.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //弹出操作菜单
                    cmsDgv.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }
        #endregion
        #region 日志列表双击查看日志
        //双击查看日志
        private void dgvNote_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnWatch_Click(sender, e);
        }
        #endregion
        #region 显示全部日志按钮
        //显示全部日志
        private void btnFresh_Click(object sender, EventArgs e)
        {
            fresh();
        }

        #endregion
        #region timer控件遍历工作日志，看是否有需要提示的
        private void timer1_Tick(object sender, EventArgs e)
        {

            DateTime selectedDatatime = DateTime.Now;
            int selectYear = selectedDatatime.Year;
            int selectMonth = selectedDatatime.Month;
            int selectDay = selectedDatatime.Day;
            int selectHour = selectedDatatime.Hour;
            nm.load();
            sm.loadSet();
            timRemind.Interval = sm.sd.Frequency * 60000;
            Dictionary<int, WorkDailyRecord> searchDictionary = nm.NoteList;
            foreach (WorkDailyRecord item in searchDictionary.Values)
            {
                DateTime searchDatatime = item.RemindTime;
                int year = searchDatatime.Year;
                int month = searchDatatime.Month;
                int day = searchDatatime.Day;
                int hour = searchDatatime.Hour;
                int daan = selectHour - hour;
                if (selectDay == day && selectMonth == month && selectYear == year && daan <= sm.sd.AheadTime && item.ImportanceLevel == "提醒")
                {
                    frmWarning frmShowWarning = new frmWarning(item.NoteId, this);
                    Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - frmShowWarning.Width, Screen.PrimaryScreen.WorkingArea.Height);
                    frmShowWarning.PointToScreen(p);
                    frmShowWarning.Location = p;
                    frmShowWarning.Show();
                    for (int i = 0; i <= frmShowWarning.Height; i++)
                    {
                        frmShowWarning.Location = new Point(p.X, p.Y - i);
                    }
                }
            }
        }


        #endregion

        
        #endregion
        #region 文件传输全部代码

        #region 判断主窗体是否选中了文件传输
        //判断主窗体是否选中了文件传输
        private void tbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                UpdateTreeView();
            
        }
        #endregion
        #region 刷新好友TREEVIEW
        //刷新TREEVIEW
        public void UpdateTreeView()
        {
            nmm.load();
            this.tvFriends.Nodes.Clear();
            TreeNode nodeFirstLevel = new TreeNode("所有同事");
            tvFriends.Nodes.Add(nodeFirstLevel);
            foreach (NetMember item in nmm.MemberList.Values)
            {
                TreeNode node = new TreeNode();
                if (!item.Status)
                {
                    node.ImageIndex = 0;
                    node.Text = item.Name + "     (不在线)";
                }
                else
                {
                    node.ImageIndex = 1;
                    node.Text = item.Name + "     (在线)";
                }
                node.Tag = item.Ia;
                node.ImageIndex = 1;
                this.tvFriends.Nodes[0].Nodes.Add(node);
            }
            tvFriends.ExpandAll();
        }
        #endregion
        #region 好友列表右键选中时
        //好友列表右键选中时
        private void tvFriends_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tsmiChangeName.Enabled = true;
                tsmiMessage.Enabled = true;
                tsmiSendFile.Enabled = true;

                tvFriends.SelectedNode = tvFriends.GetNodeAt(e.X, e.Y);
                if (tvFriends.GetNodeAt(e.X, e.Y) == null)
                {
                    tsmiChangeName.Enabled = false;
                    tsmiMessage.Enabled = false;
                    tsmiSendFile.Enabled = false;
                }
            }
        }
        #endregion
        #region 修改备注名
        //修改备注名
        private void tsmiChangeName_Click(object sender, EventArgs e)
        {
            if (tvFriends.SelectedNode.Level != 0)
            {
                IPAddress ia = (IPAddress)tvFriends.SelectedNode.Tag;
                frmChangeName fcn = new frmChangeName(ia, this);
                fcn.ShowDialog();
            }

        }
        #endregion
        #region 右键刷新好友列表

        private void timFreshFreiends_Tick(object sender, EventArgs e)
        {
            if (helpClass.newPoeple && !cmsFriends.Visible && chatFromList==null)
            {
                UpdateTreeView();
            }
        }
        //右键刷新好友列表
        private void tsmiFresh_Click(object sender, EventArgs e)
        {
            UpdateTreeView();
        }
        #endregion
        #region 下线提示

        private void downState()
        {
            UdpClient uc = new UdpClient();
            IPAddress addr = new IPAddress(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].Address);
            string localIp = addr.ToString(); //获取本机ip地址
            string prefixIp = localIp.Remove(localIp.LastIndexOf('.'));//获得末位数字
            try
            {
                nmm.load();
                foreach (NetMember item in nmm.MemberList.Values)
                {
                    if (item.Status)
                    {
                        IPEndPoint iep = new IPEndPoint(item.Ia, 8888);
                        string temp = localIp + "*DOWN_STATE*"; //保存TextBox文本
                        byte[] b = System.Text.Encoding.UTF8.GetBytes(temp);
                        uc.Send(b, b.Length, iep);
                    }
                }
            }
            catch (Exception)
            {


            }

        }

        #endregion
        #region 搜索全局域网用户，并判断是否在线
        //创建第二线程刷新局域网内其他用户
        private void upMemberDate()
        {
            if (File.Exists(helpClass.yunxingPath + "\\files\\friendSave.bin"))
            {
                umd.load();
                foreach (NetMember item in umd.MemberList.Values)
                {
                    item.Status = false;
                }
                umd.saveTo();
            }
            else
            {
                umd.saveTo();
            }
            freshm.startFreshFriends();

        }
        #endregion
        #region 点击发送即时消息按钮

        //点击发送即时消息
        private void tsmiMessage_Click(object sender, EventArgs e)
        {
            if (tvFriends.SelectedNode.Level != 0)
            {
                IPAddress ia = (IPAddress)this.tvFriends.SelectedNode.Tag;
                bool old = false;
                foreach (IPAddress item in chatFromList.Keys)
                {
                    if (item.ToString() == ia.ToString())
                    {
                        old = true;
                        break;
                    }
                    else
                    {
                        old = false;
                    }
                }
                if (!old)
                {
                    frmChat fc = new frmChat(ia, this);
                    chatFromList.Add(ia, fc);
                    fc.Show();
                }
                else
                {
                    this.WindowState = FormWindowState.Minimized;
                    chatFromList[ia].Show();
                }
            }


          

        }
        #endregion
        #region 用于从listen线程获得新信息，同时创建窗口
        public void iaPressMethod(IPAddress ia)
        {
            bool old = false;
            foreach (IPAddress item in chatFromList.Keys)
            {
                if (item.ToString() == ia.ToString())
                {
                    old = true;
                    break;
                }
                else
                {
                    old = false;
                }
            }
            if (!old)
            {
                frmChat fc = new frmChat(ia, this);
                chatFromList.Add(ia, fc);
            }
            newMessage = true;
        }
        #endregion
        #region 有新消息时打开窗口
        private void timNewMessage_Tick(object sender, EventArgs e)
        {
            foreach (frmChat item in chatFromList.Values)
            {
                if (item.Visible == true)
                {
                    item.fresh();
                }
                else
                {
                    item.Show();
                }
            }
            UpdateTreeView();
            newMessage = false;


        }
        #endregion
        #region 判断时候有新消息
        private void timCheckNewMessage_Tick(object sender, EventArgs e)
        {
            if (newMessage)
            {
                timNewMessage.Enabled = true;
            }
            else
            {
                timNewMessage.Enabled = false;
            }
        }
        #endregion
        #region 双击用户姓名

        private void tvFriends_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (tvFriends.SelectedNode.Level!=0)
            {
                IPAddress ia = (IPAddress)this.tvFriends.SelectedNode.Tag;
                bool old = false;
                foreach (IPAddress item in chatFromList.Keys)
                {
                    if (item.ToString() == ia.ToString())
                    {
                        old = true;
                        break;
                    }
                    else
                    {
                        old = false;
                    }
                }
                if (!old)
                {
                    frmChat fc = new frmChat(ia, this);

                    chatFromList.Add(ia, fc);


                    fc.Show();
                }
                else
                {
                    this.WindowState = FormWindowState.Minimized;
                    chatFromList[ia].Show();
                }
            }
            

        }
        #endregion
        #region 对指定人发送文件

        private void tsmiSendFile_Click(object sender, EventArgs e)
        {

            if (tvFriends.SelectedNode.Level != 0)
            {
                IPAddress ia = (IPAddress)this.tvFriends.SelectedNode.Tag;
                frmSendFile fsf = new frmSendFile(ia, this);
                fsf.ShowDialog();
            }
            
            
        }
        #endregion
        #region 发送选中文件

        //发送选中的文件
        private void tsmiSendFiles_Click(object sender, EventArgs e)
        {
            if (lvMain.SelectedItems.Count != 0)
            {
                string documentName = lvMain.SelectedItems[0].Text;
                frmSendFile frmSendFile = new frmSendFile(documentName, this);
                frmSendFile.Show();
            }
            else
            {
                MessageBox.Show("请选中一个文件！");
            }
        }
        #endregion
        #region 判断是否收到新文件
        //
        private void timNewFile_Tick(object sender, EventArgs e)
        {
            if (helpClass.newFile)
            {
                helpClass.newFile = false;
                helpClass.control = true;
                string path = helpClass.path;
                frmInsert fi = new frmInsert(path, this);
                fi.ShowDialog();

            }

        }
        #endregion
        #region 局域网同事按钮事件

        private void btnFreshFriends_Click(object sender, EventArgs e)
        {
            UpdateTreeView();
        }



        private void btnreName_Click(object sender, EventArgs e)
        {
            if (tvFriends.SelectedNode != null)
            {
                if (tvFriends.SelectedNode.Level==0)
                {
                    MessageBox.Show("请选择一个好友");
                }
                else
                {
                    tsmiChangeName_Click(sender, e);
                }
                
            }
            else
            {
                MessageBox.Show("请选择一个好友进行操作");
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (tvFriends.SelectedNode != null)
            {
                if (tvFriends.SelectedNode.Level == 0)
                {
                    MessageBox.Show("请选择一个好友");
                }
                else
                {
                    tsmiMessage_Click(sender, e);
                }
                
            }
            else
            {
                MessageBox.Show("请选择一个好友进行操作");
            }
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            if (tvFriends.SelectedNode != null)
            {
                if (tvFriends.SelectedNode.Level == 0)
                {
                    MessageBox.Show("请选择一个好友");
                }
                else
                {
                    tsmiSendFile_Click(sender, e);
                }
                
            }
            else
            {
                MessageBox.Show("请选择一个好友进行操作");
            }
        }
        #endregion

        
        #endregion
        #region 文件管理全部代码

        #region 搜索查找文件

        //搜索查找文件
        private void tsbSearch_Click(object sender, EventArgs e)
        {
            frmSelectFolder frmSelectFolder = new frmSelectFolder(this);
            lvMain.Clear();
            frmSelectFolder.ShowDialog();
        }
        #endregion
        #region 判断删除文件夹按键是否可用
        //判断删除文件夹按键是否可用
        private void cmsTvMain_Opening(object sender, CancelEventArgs e)
        {
            if (helpClass.documentType != null)
            {
                if (helpClass.admin)
                {
                    tsmiDeleteFolder.Enabled = true;
                }
                else
                {
                    tsmiDeleteFolder.Enabled = false;
                }

            }
            else
            {
                tsmiDeleteFolder.Enabled = false;
            }
        }
        #endregion
        #region 右键删除文件夹类型
        //右键删除文件夹类型
        private void tsmiDeleteFolder_Click(object sender, EventArgs e)
        {
            dm.LoadDocuments();
            DialogResult result = MessageBox.Show("删除文件夹" + helpClass.documentType + "会同时删除文件夹内所有文件，你确定要删除吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                foreach (string key in new List<string>(dm.Documents.Keys))
                {
                    if (dm.Documents[key].Type == helpClass.documentType)
                    {
                        File.Delete(dm.Documents[key].Path);
                        dm.Documents.Remove(key);
                    }
                }
                dm.SaveDocuments();
                dm.DocumentType.Remove(helpClass.documentType);
                dm.SaveDocumentType();
                Update_tvMain();
                lvMain.Clear();
            }
        }
        #endregion
        #region 发送文件到指定文件夹

        //发送文件到指定文件夹
        private void tsmiSend_Click(object sender, EventArgs e)
        {
            dm.LoadDocuments();
            string documentName = lvMain.SelectedItems[0].Text;
            frmSendFolder frmSendFolder = new frmSendFolder(documentName, this);
            lvMain.Clear();
            frmSendFolder.Show();
        }

        #endregion
        #region 判断是否选中了lv中的子项文件
        //判断是否选中了lv中的子项文件
        private void cmsLvMain_Opening(object sender, CancelEventArgs e)
        {
            //没有选中，按键不可用
            if (lvMain.SelectedItems.Count > 0)
            {
                tsmiSend.Enabled = true;
                tsmiDelete.Enabled = true;
                tsmiCopy.Enabled = true;
                tsmiSendFiles.Enabled = true;
                tsmiRename.Enabled = true;
            }
            else
            {
                tsmiSend.Enabled = false;
                tsmiDelete.Enabled = false;
                tsmiCopy.Enabled = false;
                tsmiSendFiles.Enabled = false;
                tsmiRename.Enabled = false;
            }
        }
        #endregion
        #region 删除文件

        //删除文件
        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            string documentName = "";
            try
            {

                documentName = lvMain.SelectedItems[0].Text;

            }
            catch (Exception)
            {

                MessageBox.Show("请选中一个文件");
                return;
            }
            DialogResult result = MessageBox.Show("确定要删除文件" + documentName + "吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                dm.LoadDocuments();
                foreach (string key in new List<string>(dm.Documents.Keys))
                {
                    if (key == documentName)
                    {
                        File.Delete(dm.Documents[key].Path);
                        dm.Documents.Remove(key);
                    }
                }
                dm.SaveDocuments();
                Update_tvMain();
                lvMain.Clear();
            }
        }
        #endregion
        #region 复制到桌面

        //复制到桌面
        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            string documentName = lvMain.SelectedItems[0].Text;
            foreach (string key in dm.Documents.Keys)
            {
                try
                {
                    if (key == documentName)
                    {
                        string deskPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        string newFile = deskPath + "\\" + key;
                        System.IO.File.Copy(dm.Documents[key].Path, newFile);
                        System.IO.FileInfo f = new System.IO.FileInfo(dm.Documents[key].Path);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("桌面存在同名文件,请修改文件名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        #endregion
        #region 文件夹刷新
        //更新节点
        public void Update_tvMain()
        {
            this.tvMain.Nodes.Clear();
            dm.LoadDocumentType();
            dm.LoadDocuments();
            TreeNode nodeFirstLevel = new TreeNode("我的文档");
            this.tvMain.Nodes.Add(nodeFirstLevel);

            foreach (string type in dm.DocumentType)
            {
                TreeNode node = new TreeNode();
                node.Text = type;
                this.tvMain.Nodes[0].Nodes.Add(node);
            }
            tvMain.ExpandAll();

        }
        #endregion
        #region 选择文件夹变化
        //单击节点事件
        private void tvMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            dm.LoadDocuments();
            helpClass.documentType = null;
            string documentSuffix = null;
            this.lvMain.Clear();
            if (this.tvMain.SelectedNode.Level != 0)
            {
                //提取节点名
                helpClass.documentType = e.Node.Text;
                foreach (Document document in dm.Documents.Values)
                {
                    if (helpClass.admin)
                    {
                        int documentSuffix_index = document.Name.LastIndexOf(".");
                        documentSuffix = document.Name.Substring(documentSuffix_index + 1);
                        if (document.Type == helpClass.documentType)
                        {
                            AddItems(documentSuffix, document);
                        }
                    }
                    else
                    {
                        if (helpClass.admin == document.SafeLevel)
                        {
                            int documentSuffix_index = document.Name.LastIndexOf(".");
                            documentSuffix = document.Name.Substring(documentSuffix_index + 1);
                            if (document.Type == helpClass.documentType)
                            {
                                AddItems(documentSuffix, document);
                            }
                        }
                    }

                }
            }
        }
        #endregion
        #region 判断文件类型
        //加载文件
        public void AddItems(string documentSuffix, Document document)
        {
            ListViewItem lviDocument = new ListViewItem(document.Name);
            switch (documentSuffix.ToUpper())
            {
                case "PNG":
                case "JPG":
                case "BMP":
                    lvMain.Items.Add(document.Name, 3);
                    break;
                case "DOC":
                case "DOCX":
                    lvMain.Items.Add(document.Name, 0);
                    break;
                case "XLS":
                    lvMain.Items.Add(document.Name, 1);
                    break;
                case "PPT":
                case "PPTX":
                    lvMain.Items.Add(document.Name, 2);
                    break;
                case "TXT":
                    lvMain.Items.Add(document.Name, 4);
                    break;
                case "RAR":
                case "ZIP":
                    lvMain.Items.Add(document.Name, 5);
                    break;
                default:
                    break;
            }

            lviDocument.SubItems.AddRange(new string[] { document.Character, document.Type, document.SaveTime, document.Path });
        }

        #endregion
        #region 文件拖入控件边框时操作

        //文件拖入控件边框时操作
        private void lvMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
        #endregion
        #region 文件拖入控件松开鼠标时操作
        //文件拖入控件松开鼠标时操作
        private void lvMain_DragDrop(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {

                string str = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
                helpClass.control = true;
                frmInsert fi = new frmInsert(str, this);
                fi.Show();

            }

        }

        #endregion
        #region 点击添加按钮

        //点击添加按钮
        private void tsbInsert_Click(object sender, EventArgs e)
        {
            frmInsert fi = new frmInsert(this);
            helpClass.control = false;//判断是否是拖入的
            fi.ShowDialog();

        }

        #endregion
        #region 打开各种文件

        private void lvMain_DoubleClick_1(object sender, EventArgs e)
        {
            if (lvMain.SelectedItems.Count != -1)
                Process.Start(helpClass.yunxingPath + "\\files\\MyDocument\\" + lvMain.SelectedItems[0].Text);
        }

        #endregion
        #region 文件夹列表右键菜单打开事件

        private void tvMain_MouseDown(object sender, MouseEventArgs e)
        {
            tvMain.SelectedNode = tvMain.GetNodeAt(e.X, e.Y);

            if (e.Button == MouseButtons.Right)
            {
                tvMain.SelectedNode = tvMain.GetNodeAt(e.X, e.Y);
                try
                {


                    if (tvMain.SelectedNode.Level == 0)
                    {
                        tsmiDeleteFolder.Enabled = false;

                    }
                    else
                    {
                        tsmiDeleteFolder.Enabled = true;
                    }

                    tsmiAddFolder.Enabled = true;
                    tvMain.SelectedNode = tvMain.GetNodeAt(e.X, e.Y);

                    if (tvMain.GetNodeAt(e.X, e.Y) == null)
                    {
                        tsmiDeleteFolder.Enabled = false;
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("请选中一个文件夹");
                }
            }

        }
        #endregion
        #region 删除文件按钮
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            tsmiDelete_Click(sender, e);
        }
        #endregion
        #region 发送文件

        private void tsbSend_Click(object sender, EventArgs e)
        {
            tsmiSendFiles_Click(sender, e);
        }
        #endregion
        #region 添加文件夹
        private void tsmiAddFolder_Click(object sender, EventArgs e)
        {
            frmAddFolder faf = new frmAddFolder(this);
            faf.ShowDialog();
        }
        #endregion
        #region 文件重命名

        //文件重命名
        private void tsmiRename_Click(object sender, EventArgs e)
        {
            if (lvMain.SelectedItems.Count != 0)
            {
                lvMain.SelectedItems[0].BeginEdit();
                helpClass.oldName = lvMain.SelectedItems[0].Text;
                helpClass.flog = true;
            }
            else
            {
                MessageBox.Show("请选中一个文件！");
            }
        }


        #endregion
        #region 添加文件夹按钮

        private void btnAddfloder_Click(object sender, EventArgs e)
        {
            tsmiAddFolder_Click(sender, e);
        }
        #endregion
        #region 删除文件夹按钮

        private void btnDeleteDolder_Click(object sender, EventArgs e)
        {
            if (tvMain.SelectedNode != null)
            {
                if (tvMain.SelectedNode.Level == 0)
                {
                    MessageBox.Show("不能删除此文件夹！");
                }
                else
                {
                    tsmiDeleteFolder_Click(sender, e);
                }


            }
            else
            {
                MessageBox.Show("请选择一个文件夹后，点击删除！（不能删除“我的文档”文件夹）");
            }

        }

        #endregion
        #region 点空白处保存修改的文件名
        //点空白处保存修改的文件名
        private void lvMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (lvMain.HitTest(x, y).Item == null) //点击空白处
            {
                dm.LoadDocuments();
                if (helpClass.flog)
                {
                    string name;
                    Document document = new Document();
                    name = lvMain.SelectedItems[0].Text;
                    int documentType_index = name.LastIndexOf(".");
                    string character = name.Substring(documentType_index + 1);
                    switch (character.ToUpper())
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
                            break;
                        default:
                            MessageBox.Show("文件格式不支持，请确认您输入的格式后缀无误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            helpClass.flog = false;
                            Update_tvMain();
                            lvMain.Clear();
                            return;
                    }

                    if (name != helpClass.oldName)
                    {
                        foreach (string key in new List<string>(dm.Documents.Keys))
                        {
                            if (key == helpClass.oldName)
                            {

                                dm.Documents[key].Name = name;
                                System.IO.File.Move(dm.Documents[key].Path, helpClass.yunxingPath + "\\files\\MyDocument\\" + name);
                                dm.Documents[key].Path = helpClass.yunxingPath + "\\files\\MyDocument\\" + name;
                                dm.Documents.Add(name, dm.Documents[key]);
                                dm.Documents.Remove(key);
                            }
                        }
                    }
                    helpClass.flog = false;
                }
                dm.SaveDocuments();
            }
        } 
        #endregion

        #endregion

        

        

    }
}
