using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using 青鸟项目;
using bangongtong.dal;


namespace bangongtong.util
{
    class SendFile
    {
         string filePath;
         IPAddress ia;
         Thread fileSend;
         Thread fileReceive;
         TcpListener tl;
         frmMain fm;
         NetMemberManager nmm = new NetMemberManager();



         public SendFile(IPAddress ia, string filePath,frmMain fm)
         {
             this.ia = ia;
             this.filePath = filePath;
             this.fm = fm;
         
         }
         public SendFile(frmMain fm) {
             this.fm = fm;
         }


         public void startListener() {
             fileSend = new Thread(receiveFile);
             fileSend.Start();
         }

         public void stopFileListener() {
             tl.Stop();
             fileSend.Abort();
         }
         public void statyReceive() {
             fileReceive = new Thread(sendFile);
             fileReceive.Start();
         }

         #region 发送文件

         public void sendFile()
         {
             try
             {
                 string fileName = filePath.Substring(filePath.LastIndexOf('\\') + 1);
                 IPAddress addr = new IPAddress(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].Address);
                 string message = addr.ToString() + "*" + fileName + "*";
                 TcpClient tcp = new TcpClient(ia.ToString(), 6655);
                 NetworkStream tcpStream = tcp.GetStream();
                 Byte[] data1 = System.Text.Encoding.UTF8.GetBytes(message);
                 tcpStream.Write(data1, 0, data1.Length);
                 tcpStream.Close();
                 tcp.Close();


                 //传递文件
                 TcpClient client = new TcpClient();
                 client.Connect(ia, 6655);
                 FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                 BinaryReader binaryreader = new BinaryReader(file);
                 byte[] b = new byte[4098];
                 int data;
                 while ((data = binaryreader.Read(b, 0, 4098)) != 0) //将文件写成流的形式
                 {
                     client.Client.Send(b, data, SocketFlags.None); //发送文件流到目标机器
                 }

                 client.Client.Shutdown(SocketShutdown.Both);
                 binaryreader.Close();
                 file.Close();
             }
             catch (Exception)
             {

                 MessageBox.Show("对方拒绝了接收文件或对方不在线");
             }

         }

         
         #endregion
         #region 接收文件监听

         public void receiveFile()
         {
             tl = new TcpListener(6655);
             tl.Start();
             int name = 0;
             string[] temp;
             string fileName1 = "";
             try
             {


                 while (true)
                 {
                     Socket s = tl.AcceptSocket();
                     if (name == 0)
                     {
                         Byte[] stream = new Byte[512];
                         int i = s.Receive(stream);
                         string msg = System.Text.Encoding.UTF8.GetString(stream);
                         temp = msg.Split('*');
                         fileName1 = temp[1];
                         IPAddress iafrom = IPAddress.Parse(temp[0]);
                         nmm.load();
                         string names = nmm.MemberList[iafrom].Name;
                         if ((MessageBox.Show(names + "发来文件，文件名：" + temp[1] + "是否接收？", "文件写入提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information)) == DialogResult.Yes)
                         {
                             name = 1;
                         }
                         else
                         {
                             name = 2;
                         }

                     }
                     else if (name == 1)
                     {
                         FileStream fs = new FileStream(helpClass.yunxingPath + "\\files\\receiveFile\\" + fileName1, FileMode.Create, FileAccess.Write);
                         BinaryWriter binarywrite = new BinaryWriter(fs);
                         int count;
                         byte[] b = new byte[4098];
                         while ((count = s.Receive(b, 4098, SocketFlags.None)) != 0) //这个是接受文件流 
                         {
                             binarywrite.Write(b, 0, count); //将接收的流用写成文件 
                         }
                         binarywrite.Close();
                         fs.Close();
                         s.Close();



                         helpClass.path = helpClass.yunxingPath + "\\files\\receiveFile\\" + fileName1;
                         helpClass.documentName = fileName1;
                         helpClass.newFile = true;



                         name = 0;

                     }
                     else
                     {
                         name = 0;
                     }



                 }
             }
             catch (Exception)
             {
             }
         }
        
         #endregion
         
    }
}


    