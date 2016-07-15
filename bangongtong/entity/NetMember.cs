using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace banggongtong.entity
{
    [Serializable]
    public class NetMember
    {
        private IPAddress ia;      //局域网内地址

        public IPAddress Ia
        {
            get { return ia; }
            set { ia = value; }
        }
        private string name;       //用户备注名

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private bool status;        //在线状态

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        private List<MessageNoet> messageLog = new List<MessageNoet>();

        internal List<MessageNoet> MessageLog
        {
            get { return messageLog; }
            set { messageLog = value; }
        }

    }
}
