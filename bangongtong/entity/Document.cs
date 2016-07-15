using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace banggongtong.entity
    
{
    [Serializable]
    public class Document
    {
        private string name;                //文件名
        private string type;                //文件夹
        private string character;           //文件类型（后缀名）
        private string saveTime;            //存储时间 
        private bool safeLevel;             //安全等级
        private string path;                //文件路径

        //文件路径封装
        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        //文件名封装
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        //文件类型封装
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        
        //文件性质封装
        public string Character
        {
            get { return character; }
            set { character = value; }
        }
        
        //储存时间封装
        public string SaveTime
        {
            get { return saveTime; }
            set { saveTime = value; }
        }
       
        //文件安全等级封装
        public bool SafeLevel
        {
            get { return safeLevel; }
            set { safeLevel = value; }
        }
    }
}
