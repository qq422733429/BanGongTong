using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using banggongtong.entity;
using 青鸟项目;

namespace bangongtong.dal
{
    [Serializable]
    public class SetManager
    {
        public SetDate sd = new SetDate();
        //读取设置数据
        public void saveToSet()
        {
            FileStream fs = new FileStream(helpClass.yunxingPath + "\\files\\saveSetDate.bin", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this.sd);
            fs.Close();
        }

        //加载设置数据
        public SetDate loadSet()
        {
            if (File.Exists(helpClass.yunxingPath + "\\files\\saveSetDate.bin"))
            {
                FileStream fs = new FileStream(helpClass.yunxingPath + "\\files\\saveSetDate.bin", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                this.sd = (SetDate)bf.Deserialize(fs);
                fs.Close();
                return this.sd;
            }
            return null;
        }
    }
}
