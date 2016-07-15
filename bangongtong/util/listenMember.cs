using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Windows.Forms;
using banggongtong.entity;
using bangongtong.dal;
using 青鸟项目;

namespace bangongtong.util
{
    class listenMember
    {
        UdpClient uc = null; //声明UDPClient
        IPAddress ia1 = null;
        NetMemberManager nmm = new NetMemberManager();
        SetManager sm = new SetManager();
        #region 启动监听线程

        public void startlistenMenber()
        {

            //注意此处端口号要与发送方相同

            uc = new UdpClient(8888);

            //开一线程

            Thread th = new Thread(new ThreadStart(listen));

            //设置为后台

            th.IsBackground = true;

            th.Start();


        } 
        #endregion
        #region 监听方法

        private void listen()
        {

            //声明终结点

            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("111.15.222.0"), 8888);
            IPAddress addr = new IPAddress(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].Address);

            sm.loadSet();
            string myName = sm.sd.AdminName;

            while (true)
            {

                //获得Form1发送过来的数据包

                string text = System.Text.Encoding.UTF8.GetString(uc.Receive(ref iep));
                string[] temp = text.Split('*');
                ia1 = IPAddress.Parse(temp[0]);
                if (temp[2] == "CHECK_ON_LINE")
                {
                    nmm.load();
                    bool old = false;
                    foreach (NetMember item in nmm.MemberList.Values)
                    {
                        if (item.Ia.ToString() == temp[0])
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
                        NetMember nm = new NetMember();
                        nm.Ia = ia1;
                        nm.Name = temp[1];
                        nm.Status = true;
                        nmm.MemberList.Add(ia1, nm);
                        helpClass.newPoeple = true;
                    }
                    else
                    {
                        nmm.MemberList[ia1].Status = true;
                        helpClass.newPoeple = true;
                    }

                    nmm.saveTo();


                    IPEndPoint iep1 = new IPEndPoint(ia1, 8888);
                    string ed = addr.ToString() + "*" + myName + "*CHECK_ON_LINED*"; 
                    byte[] s = System.Text.Encoding.UTF8.GetBytes(ed);
                    uc.Send(s, s.Length, iep1);
                }
                if (temp[2] == "CHECK_ON_LINED")
                {
                    nmm.load();
                    bool old = false;
                    foreach (NetMember item in nmm.MemberList.Values)
                    {
                        if (item.Ia.ToString() == temp[0])
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
                        NetMember nm = new NetMember();
                        nm.Ia = ia1;
                        nm.Name = temp[1];
                        nm.Status = true;
                        nmm.MemberList.Add(ia1, nm);
                        helpClass.newPoeple = true;
                    }
                    else
                    {
                        nmm.MemberList[ia1].Status = true;
                        helpClass.newPoeple = true;
                    }

                    nmm.saveTo();
                }
                if (temp[1] == "DOWN_STATE")
                {
                    nmm.load();
                    nmm.MemberList[ia1].Status = false;
                    MessageBox.Show(nmm.MemberList[ia1].Name + "下线");
                    helpClass.newPoeple = true;
                    nmm.saveTo();
                }

            }





        } 
        #endregion
    }
}
