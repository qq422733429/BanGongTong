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
    public class NoteManager
    {

        private Dictionary<int, WorkDailyRecord> noteList = new Dictionary<int, WorkDailyRecord>();
        int noteId = 1;

        public int NoteId
        {
            get { return noteId; }
            set { noteId = value; }
        }

        public Dictionary<int, WorkDailyRecord> NoteList
        {
            get { return noteList; }
            set { noteList = value; }
        }

        //序列化存储私人用户信息
        public void saveTo()
        {
            FileStream fs = new FileStream(helpClass.yunxingPath + "\\files\\noteSave.bin", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this.noteList);
            fs.Close();
        }

        //加载并返回私人用户信息
        public Dictionary<int, WorkDailyRecord> load()
        {
            if (File.Exists(helpClass.yunxingPath + "\\files\\noteSave.bin"))
            {
                FileStream fs = new FileStream(helpClass.yunxingPath + "\\files\\noteSave.bin", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                this.noteList = (Dictionary<int, WorkDailyRecord>)bf.Deserialize(fs);
                fs.Close();
                return this.noteList;
            }
            else
            {
                saveTo();
            }
            return null;
        }

        //存储noteId
        public void saveToId()
        {
            FileStream fs = new FileStream(helpClass.yunxingPath + "\\files\\saveNoteId.bin", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this.noteId);
            fs.Close();
        }

        //加载并返回私人用户信息
        public int loadId()
        {
            if (File.Exists(helpClass.yunxingPath + "\\files\\saveNoteId.bin"))
            {

                FileStream fs = new FileStream(helpClass.yunxingPath + "\\files\\saveNoteId.bin", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                this.noteId = (int)bf.Deserialize(fs);
                fs.Close();
                return this.noteId;
            }
            else
            {
                saveToId();
            }
            return 0;
        }

    }
}
