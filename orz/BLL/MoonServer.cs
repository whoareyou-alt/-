using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Spire.Xls;
namespace orzServer {
    public class MoonException : Exception
    {
        public MoonException() : base("Exception")
        {

        }
        public MoonException(string msg) : base(msg)
        {

        }
        public MoonException(string msg, Exception inner) : base(msg, inner)
        {

        }
    }
    public class Msg
    {
        public string strUserName;
        public string strDateTime;
        public Msg() { }
        public Msg(string strUserName, string strDateTime)
        {
            this.strUserName = strUserName;
            this.strDateTime = strDateTime;
        }
    }
    public class MoonServer : IMoonServer 
    {
        private List<string> m_strUsersList;  //用户列表
        private List<Msg> m_msgWinnersList;

        private static MoonServer Moon;

        private MoonServer()    //仅允许有一个实例
        {
            m_strUsersList = new List<string>();
            m_msgWinnersList = new List<Msg>();
        }    
        public static MoonServer GetServer()    //获取实例
        {
            if ( Moon == null ) {
                Moon = new MoonServer();
            }
            return Moon;
        }

        /*******************************/
        public int DiceRoller()
        {
            if ( m_strUsersList.Count() <= 0 ) {
                throw new MoonException("参与人数为0");
            } else {
                int lucy = 0;

                Random r = new Random();
                byte[] buffer = Guid.NewGuid().ToByteArray();
                int iSeed = BitConverter.ToInt32(buffer, 0);
                r = new Random(iSeed);
                lucy = r.Next(1, m_strUsersList.Count);

                return lucy;
            }
        }
        /*******************************/
        public void ImportUsersList()
        {
            m_strUsersList.Clear();
            string strFileName = SelectFilePath();
            //string strFileName = "D:\\测试集.xlsx";    //仅测试时候使用！！！！
            if ( strFileName == null ) {
                throw new MoonException("未选择文件！！");
            }
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(strFileName);
            Worksheet sheet = workbook.Worksheets[0];   //获取第一个工作表

            DataTable dt = sheet.ExportDataTable();
            foreach ( DataRow row in dt.Rows ) {
                m_strUsersList.Add(row.ItemArray[0].ToString());
            }
        }
        public List<string> GetUsersList()
        {
            return m_strUsersList;
        }
        public void AddWinners(string strUserName, string strDate)
        {
            m_msgWinnersList.Add(new Msg(strUserName, strDate));
        }
        public List<Msg> GetWinnersList()
        {
            return m_msgWinnersList;
        }
        /*******************************/
        private string SelectFilePath()
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.Title = "请选择Excel文件";
            //ofd.Filter= "(*.xlsx)|*.xlsx|(*.xls)|*.xls";
            ofd.Filter = "(*.xlsx;*.xls)|*.xlsx;*.xls";
            if ( ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK ) {
                return ofd.FileName;
            }
            return null;
        }
    }
}
