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

namespace bangongtong.dal
{
    [Serializable]

    public class NetMemberManager 
    {
        private Dictionary<IPAddress, NetMember> memberList = new Dictionary<IPAddress, NetMember>(); //局域网内所有用户字典

        internal Dictionary<IPAddress, NetMember> MemberList
        {
            get { return memberList; }
            set { memberList = value; }
        }
        //保存用户信息
        public void saveTo()
        {
            try
            {
            FileStream fs = new FileStream(helpClass.yunxingPath + "\\files\\friendSave.bin", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this.memberList);
            fs.Close();
            }
            catch (Exception)
            {
                Thread.Sleep(200);
                saveTo();
            }
        }
        //加载并返回私人用户信息
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
