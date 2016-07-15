using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using banggongtong.entity;
using 青鸟项目;
using bangongtong.dal;

namespace bangongtong.util
{
    class Listener
    {
        private Thread th;  //申明一条线程，用来监听
        private TcpListener tcp1;       //申明TCP实例
        public bool listenerRun = true;     //判断是否继续监听
        frmMain fm;         //主窗体发送
        public delegate void OutDelegate(IPAddress ia1);        //申明委托
        IPAddress ia1;          //用来储存发送来信息的用户的IP


        //构造方法
        public Listener(frmMain fm){
            this.fm = fm;
        }

        //new线程，启动监听
        public void StartListen()
        {
            th = new Thread(new ThreadStart(Listene));
            
            th.Start();//启动监听
        }

        //停止监听
        
        public void Stop()
        {
            tcp1.Stop();
            th.Abort();
        }

        //调用frmMaind的方法用来提示有消息
        public void OutText(IPAddress ia)
        {
            fm.iaPressMethod(ia);
        }


        #region 监听方法
        //监听方法

        private void Listene()
        {
            NetMemberManager nmm = new NetMemberManager();
            try
            {
                IPAddress addr = new IPAddress(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].Address);//ho获取本地地址
                IPEndPoint ipLocalEndPoint = new IPEndPoint(addr, 5566);
                tcp1 = new TcpListener(ipLocalEndPoint);
                tcp1.Start();
                while (0 == 0)
                {
                    Socket s = tcp1.AcceptSocket();
                    Byte[] stream = new Byte[512];
                    int i = s.Receive(stream);
                    string msg = System.Text.Encoding.UTF8.GetString(stream);
                    string[] temp = msg.Split('*');


                    //若接收的是CHECK_ON_LINE，添加新用户
                    ia1 = IPAddress.Parse(temp[0]);


                    //接收新信息

                    if (temp[1] != "CHECK_ON_LINE" && temp[1] != "CHECK_ON_LINED")
                    {
                        nmm.load();
                        MessageNoet ms = new MessageNoet();
                        ms.Message1 = temp[1];
                        ms.DateTime = DateTime.Now;
                        ms.Poeple = true;
                        nmm.MemberList[ia1].MessageLog.Add(ms);
                        nmm.saveTo();

                        OutDelegate outdelegate = new OutDelegate(OutText);
                        outdelegate.Invoke(ia1);//委托调用frmmian的iapress方法

                    }
                }
            }
            catch (System.Security.SecurityException)
            {
                System.Windows.Forms.MessageBox.Show("防火墙禁止连接");

            }
            catch (Exception)
            {
            }

        } 
        #endregion

        
    }
}
