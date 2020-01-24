using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace auto
{
    
    interface IWritebleObject
    {
        void Write(SaveManager man);
    }
    interface ISaveManager
    {
        void WriteLine(string line);
        void WriteObject(IWritebleObject obj);
    }
    class SaveManager
    {
        FileInfo file;
        public SaveManager(string filename)
        {
            file = new FileInfo(filename+".txt");
            file.CreateText();
        }
        public void WriteLine(string line)
        {
            StreamWriter sw = file.AppendText();
            sw.WriteLine(line);
            sw.Close();
        }
        public void WriteObject(IWritebleObject obj)
        {
            obj.Write(this);
        }
    }
}
