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
    public class MoonServer : IMoonServer 
    {
        private List<string> m_strUsersList;  //用户列表
        private List<string> m_strPizesList;  //奖品列表

        private Dictionary<string, int> m_dictPirzeCount;
        DataTable m_dtWinners;

        static int m_iUsersCount;

        private static MoonServer Moon;

        private MoonServer()    //仅允许有一个实例
        {
            m_strUsersList = new List<string>();
            m_strPizesList = new List<string>();

            m_dictPirzeCount = new Dictionary<string, int>();

            m_dtWinners = new DataTable();
            DataColumn user = new DataColumn("参与者", System.Type.GetType("System.String"));
            m_dtWinners.Columns.Add(user);
            DataColumn prize = new DataColumn("奖品", System.Type.GetType("System.String"));
            m_dtWinners.Columns.Add(prize);

            LoadTest();     //仅测试用
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
            if ( m_iUsersCount <= 0 ) {
                throw new MoonException("参与人数为0");
            } else {
                int lucy = 0;

                Random r = new Random();
                byte[] buffer = Guid.NewGuid().ToByteArray();
                int iSeed = BitConverter.ToInt32(buffer, 0);
                r = new Random(iSeed);
                lucy = r.Next(1, m_iUsersCount);

                return lucy;
            }
        }
        /*******************************/
        public void ImportUsersList()
        {
            m_strUsersList.Clear();
            //string strFileName = SelectFilePath();
            string strFileName = "D:\\测试集.xlsx";    //仅测试时候使用！！！！
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

            m_iUsersCount = m_strUsersList.Count;
        }
        public List<string> GetUsersList()
        {
            return m_strUsersList;
        }
        public void AddWinner(string strUserName, string strPrize)
        {
            if ( m_dictPirzeCount.Keys.Contains(strUserName) ) {
                m_dictPirzeCount[strUserName] += 1;
            } else {
                m_dictPirzeCount.Add(strUserName, 1);
            }

            DataRow Winner = m_dtWinners.NewRow();
            Winner[0] = strUserName;    Winner[1] = strPrize;
            m_dtWinners.Rows.Add(Winner);
        }
        public DataTable GetDTWinners()
        {
            return m_dtWinners;
        }
        public Dictionary<string, int> GetPrizeCount()
        {
            return m_dictPirzeCount;
        }
        public void SelectPrize(DataRow[] rows, string strUserName, int iPrizeCount = 1)     
        {
            
            foreach ( DataRow row in rows ) {       //删除指定的行
                m_strPizesList.Add(row[0].ToString());
                m_dtWinners.Rows.Remove(row);
            }

            m_dictPirzeCount[strUserName] = iPrizeCount;

        }
        /*******************************/
        public void ImportPizesList()
        {
            m_strPizesList.Clear();
            //string strFileName = SelectFilePath();      //获取所选文件路径
            string strFileName = "D:\\测试集_奖品.xlsx";       //仅测试时候使用
            if ( strFileName == null ) {
                throw new MoonException("未选择文件！！");
            }
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(strFileName);
            Worksheet sheet = workbook.Worksheets[0];   //获取第一个工作表

            DataTable dt = sheet.ExportDataTable();
            foreach ( DataRow row in dt.Rows ) {        //获取该工作表第一列数据
                m_strPizesList.Add(row.ItemArray[0].ToString());
            }
        }
        public List<string> GetPizesList()
        {
            return m_strPizesList;
        }
        public void DeletePrize(string strPrizeName)
        {
            m_strPizesList.Remove(strPrizeName);
        }
        /*******************************/
        public void ExportWinnersList() //未测试
        {
            string strFileName = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string strFileName1 = DateTime.Now.ToString("F").Replace(':', '-');      //保存文件名
            Workbook book = new Workbook();
            Worksheet sheet = book.Worksheets[0];

            DataTable dtWinners = m_dtWinners;

            sheet.InsertDataTable(dtWinners, true, 1, 1);
            sheet.Name = "sheet1";
            book.SaveToFile(strFileName + strFileName1);
        }
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

        private void LoadTest()
        {
            m_strPizesList.Clear();
            //string strFileName = SelectFilePath();      //获取所选文件路径
            string strFileName = "D:\\测试集_奖品选择.xlsx";       //仅测试时候使用
            if ( strFileName == null ) {
                throw new MoonException("未选择文件！！");
            }
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(strFileName);
            Worksheet sheet = workbook.Worksheets[0];   //获取第一个工作表

            m_dtWinners = sheet.ExportDataTable();
        }
    }
}
