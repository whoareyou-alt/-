using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orzServer
{
    public class Msg
    {
        //DateTime.Now.ToString("G")
        public string time;
        public string msg;
    }
    interface IRecord
    {
        void Write(Msg msg);
        bool SaveInFile();
    }
}
