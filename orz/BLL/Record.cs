using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace orzServer
{
    public class Record : IRecord
    {
        private static Record record;

        List<Msg> m_MsgList;
        private Record()
        {
            m_MsgList = new List<Msg>();
        }
        public static Record GetServer()
        {
            if ( record == null ) {
                record = new Record();
            }
            return record;
        }

        public void Write(Msg msg)
        {
            m_MsgList.Add(msg);
        }
        public bool SaveInFile()
        {
            if ( m_MsgList.Count > 0 ) {
                string strFileName = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                string strFileName2 = DateTime.Now.ToString("F").Replace(':', '-');
                using ( StreamWriter swSave = File.CreateText(strFileName + strFileName2 + ".txt") ) {

                    foreach ( Msg msg in m_MsgList ) {
                        swSave.WriteLine(msg.time);
                        swSave.WriteLine(msg.msg);
                    }
                }
            }
            return false;
        }
    }
}
