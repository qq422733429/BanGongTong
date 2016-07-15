using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using bangongtong.dal;

namespace bangongtong.util
{
    class FreshMember
    {
        Thread th1;
        UdpClient uc = new UdpClient();
        SetManager sm = new SetManager();
        #region 申明新线程

        public void startFreshFriends()
        {
            th1 = new Thread(GetAllLanIp);
            th1.Start();

        } 
        #endregion
        #region 终止线程
        public void stopFreshFriends()
        {

            th1.Abort();


        } 
        #endregion
        #region 遍历局域网所有用户

        public void GetAllLanIp()
        {
            //开始向全局域网发送上线信息
            sm.loadSet();
            string myName = sm.sd.AdminName;


            try
            {
                IPAddress addr = new IPAddress(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].Address);
                string localIp = addr.ToString(); //获取本机ip地址
                string prefixIp = localIp.Remove(localIp.LastIndexOf('.'));//获得末位数字
                for (int i = 1; i < 255; i++)
                {
                    IPAddress ia = IPAddress.Parse(prefixIp + "." + i.ToString());
                    IPEndPoint iep = new IPEndPoint(ia, 8888);
                    string temp = localIp + "*" + myName + "*CHECK_ON_LINE*"; //保存TextBox文本
                    byte[] b = System.Text.Encoding.UTF8.GetBytes(temp);
                    uc.Send(b, b.Length, ia.ToString(), 8888);
                }
            }
            catch (Exception)
            {
            }
        } 
        #endregion

    }
}
