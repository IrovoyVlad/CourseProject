using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace auto
{
    interface ILoadManager
    {
        string ReadLine();
        IReadbleObject Read(IReadableObjectLoader loader);
    }

    interface IReadbleObject
    { }

    interface IReadableObjectLoader
    {
        IReadbleObject Load(ILoadManager man);
    }
    class LoadManager : ILoadManager
    {
        string file;
        StreamReader input;
        public event EventHandler<IReadbleObject> ObjectDidLoad;
        public event EventHandler<string> DidStartLoad;
        public event EventHandler<string> DidEndLoad;
        public LoadManager(string filename)
        {
            file = filename;
            input = null;
        }

        public IReadbleObject Read(IReadableObjectLoader loader)
        {
            var result = loader.Load(this);
            if (ObjectDidLoad != null)
                ObjectDidLoad.Invoke(this, result);
            return result;
        }

        public void BeginRead()
        {
            if (input != null)
                throw new IOException("Load Error");
            if (DidStartLoad != null)
                DidStartLoad.Invoke(this, file);
            input = new StreamReader(file);
            //ObjectDidLoad.Invoke(this,Read());
        }
        public bool IsLoading
        {
            get { return input != null && !input.EndOfStream; }
        }
        public string ReadLine()
        {
            if (input == null)
                throw new IOException("Load Error");

            string line = input.ReadLine();
            return line;
        }

        public void EndRead()
        {
           
            if (input == null)
                throw new IOException("Load Error");
            if (DidEndLoad != null)
                DidEndLoad.Invoke(this, file);

            input.Close();
        }
    }

}