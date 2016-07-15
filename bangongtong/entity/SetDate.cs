using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using banggongtong.entity;

namespace banggongtong.entity
{
    [Serializable]
    public class SetDate
    {
        private int aheadTime; //提前多少小时提醒

        public int AheadTime
        {
            get { return aheadTime; }
            set { aheadTime = value; }
        }
        private int frequency; //多长时间提醒一次

        public int Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }
        private string password;

        public string Password//密码
        {
            get { return password; }
            set { password = value; }
        }
        private string adminName;//主人姓名

        public string AdminName
        {
            get { return adminName; }
            set { adminName = value; }
        }
    }
}
