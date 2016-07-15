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
    public class DocumentsManager
    {
        private List<string> documentType = new List<string>();                             //文件类型
        private Dictionary<string, Document> documents = new Dictionary<string, Document>();  //所有文件
   

        public Dictionary<string, Document> Documents
        {
            get { return documents; }
            set { documents = value; }
        }

        public List<string> DocumentType
        {
            get { return documentType; }
            set { documentType = value; }
        }

        #region 序列化存储私人用户信息
        //序列化存储私人用户信息
        public void SaveDocumentType()
        {
            FileStream fs = new FileStream(helpClass.yunxingPath+"\\files\\documentType.bin", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, documentType);
            fs.Close();
        }
        
        #endregion
        #region 加载并返回私人用户信息
        //加载并返回私人用户信息
        public void LoadDocumentType()
        {
            if (File.Exists(helpClass.yunxingPath + "\\files\\documentType.bin"))
            {
                FileStream fs = new FileStream(helpClass.yunxingPath + "\\files\\documentType.bin", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                this.documentType = (List<string>)bf.Deserialize(fs);
                fs.Close();
            }
        } 
        #endregion

        #region 序列化存储私人用户信息
        //序列化存储私人用户信息
        public void SaveDocuments()
        {
            FileStream fs = new FileStream(helpClass.yunxingPath + "\\files\\documents.bin", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, documents);
            fs.Close();
        }
        
        #endregion
        #region 加载并返回私人用户信息
        //加载并返回私人用户信息
        public void LoadDocuments()
        {
            if (File.Exists(helpClass.yunxingPath + "\\files\\documents.bin"))
            {
                FileStream fs = new FileStream(helpClass.yunxingPath + "\\files\\documents.bin", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                this.documents = (Dictionary<string, Document>)bf.Deserialize(fs);
                fs.Close();
            }
        } 
        #endregion
    }
}
