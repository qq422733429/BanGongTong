using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace banggongtong.entity
{
    [Serializable]
    public class MessageNoet
    {
        private bool poeple=false;

        public bool Poeple
        {
            get { return poeple; }
            set { poeple = value; }
        }
        
        private string message;

        public string Message1
        {
            get { return message; }
            set { message = value; }
        }
        private DateTime dateTime;

        public DateTime DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }


    }
}
