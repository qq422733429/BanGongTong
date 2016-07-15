using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace bangongtong.util
{
    class SenderMessage
    {
        TcpClient tcp=new TcpClient();


        #region 发送聊天信息的方法

        //发送聊天信息的方法
        public void SendMessage(string str, IPAddress ia)
        {
            IPAddress addr = new IPAddress(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].Address);
            try
            {
                string message = addr.ToString() + "*" + str + "*";
                tcp = new TcpClient(ia.ToString(), 5566);
                NetworkStream tcpStream = tcp.GetStream();
                Byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
                tcpStream.Write(data, 0, data.Length);
                tcpStream.Close();
                tcp.Close();

            }
            catch (Exception)
            {

            }
        } 
        #endregion
    }
}
