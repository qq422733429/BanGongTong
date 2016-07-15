using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using banggongtong.entity;
using 青鸟项目;


namespace bangongtong.util
{
    class UpMemberDate

    {
        private Dictionary<IPAddress, NetMember> memberList = new Dictionary<IPAddress, NetMember>(); //局域网内所有用户字典

        public Dictionary<IPAddress, NetMember> MemberList
        {
            get { return memberList; }
            set { memberList = value; }
        }

        //程序第一次开始运行时会调用一次
        public void saveTo()
        {
            FileStream fs = new FileStream(helpClass.yunxingPath + "\\files\\friendSave.bin", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this.memberList);
            fs.Close();
        }

        //程序每次开始运行时会调用一次
        public Dictionary<IPAddress, NetMember> load()
        {
            try
            {

                if (File.Exists(helpClass.yunxingPath + "\\files\\friendSave.bin"))
                {
                    FileStream fs = new FileStream(helpClass.yunxingPath + "\\files\\friendSave.bin", FileMode.Open);
                    BinaryFormatter bf = new BinaryFormatter();
                    this.memberList = (Dictionary<IPAddress, NetMember>)bf.Deserialize(fs);
                    fs.Close();
                    return this.memberList;
                }

            }
            catch (Exception)
            {
            }
            return null;
        }

    }
}
