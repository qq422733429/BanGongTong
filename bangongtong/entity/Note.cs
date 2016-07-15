using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using banggongtong.entity;

namespace banggongtong.entity
{
    [Serializable]
    public class WorkDailyRecord
    {
        private int noteId;                     //日志id
        private DateTime remindTime;            //提醒时间
        private string importanceLevel;            //重要性
        private string content;                 //日志内容



        public int NoteId
        {
            get { return noteId; }
            set { noteId = value; }
        }
        //提醒时间封装
        public DateTime RemindTime
        {
            get { return remindTime; }
            set { remindTime = value; }
        }
        
        //日志内容封装
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        //重要性封装
        public string ImportanceLevel
        {
            get { return importanceLevel; }
            set { importanceLevel = value; }
        }
      
    }
}
