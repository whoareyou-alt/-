using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using orzServer;
namespace orz {
    public partial class FrmMain : Form
    {

        private orzServer.MoonServer Moon;      //
        private orzServer.Record record;        //

        List<string> strUsersList;              //用户列表
        private bool start = false;             //开始、结束 抽奖 标识
        int iLucyNum = -1;
        //Thread Dice;

        System.Timers.Timer timer = new System.Timers.Timer(interval: 1); // 定时器
        
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Moon = orzServer.MoonServer.GetServer();
            record = orzServer.Record.GetServer();

            timer.Elapsed += Timer_Elapsed;
        }

        //导入用户数据
        private void ImportUsersList_Click(object sender, EventArgs e)
        {
            try {
                Moon.ImportUsersList();     //导入用户数据
                MessageBox.Show("导入成功！！", "这是提示");

                strUsersList = Moon.GetUsersList();
            } catch( MoonException ex ) {
                MessageBox.Show(ex.Message, "Error");
            } finally {

            }
        }

        //查看用户
        private void UsersList_Click(object sender, EventArgs e)
        {
            List<string> strUsersList = Moon.GetUsersList();    //获取用户列表
            DataTable dt = new DataTable("Table_Users");        

            DataColumn dc = new DataColumn("参与者", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);

            //把用户数据保存到DataTable
            foreach ( string str in strUsersList ) {    
                dt.Rows.Add(str);
            }
            //在新窗口显示用户列表
            DataView_Grid dvg = new DataView_Grid(dt, (int)DataType.UserList);
            dvg.Show();
        }
        //查看获奖名单
        private void WinnersList_Click(object sender, EventArgs e)
        {
            DataTable dtWinners = Moon.GetDTWinners();
            DataView_Winners dvw = new DataView_Winners();
            dvw.ResetPrize += new ResetPrizeList(orz_ResetPrizeList);
            dvw.ShowDialog();
        }
        private void ImportPrizesList_Click(object sender, EventArgs e)
        {
            try {
                Moon.ImportPizesList();     //导入奖品列表
                MessageBox.Show("导入成功！！", "这是提示");

                cbPrizeList.DataSource = Moon.GetPizesList();   //把奖品列表加载到控件中
                cbPrizeList.SelectedIndex = 0;
            } catch ( MoonException ex ) {
                MessageBox.Show(ex.Message, "出错啦");
            } finally {
            }
        }

        //查看奖品
        private void PrizesList_Click(object sender, EventArgs e)
        {
            List<string> strUsersList = Moon.GetPizesList();    //获取奖品列表
            DataTable dt = new DataTable("Table_Pizes");

            DataColumn dc1 = new DataColumn("奖品", System.Type.GetType("System.String"));
            dt.Columns.Add(dc1);

            //把奖品数据保存到DataTable
            foreach ( string str in strUsersList ) {
                dt.Rows.Add(str);
            }
            //在新窗口显示奖品列表
            DataView_Grid dvg = new DataView_Grid(dt, (int)DataType.PrizeList);
            dvg.Show();
        }

        //开始抽奖
        private void rbtnDiceRoller_Click(object sender, EventArgs e)
        {
            start = !start;
            if ( start ) {      //开始
                timer.Start();

            } else if( (!start) && (iLucyNum != -1) ) {     //结算
                timer.Close();

                Moon.AddWinner(strUsersList[iLucyNum], cbPrizeList.SelectedItem.ToString());
                Moon.DeletePrize(cbPrizeList.SelectedItem.ToString());
                cbPrizeList.DataSource = Moon.GetPizesList();   //刷新控件中奖品列表

                //添加记录
                Msg msg = new Msg { time = DateTime.Now.ToString("G") };
                string strMessage;
                strMessage = strUsersList[iLucyNum] + "  抽到了  " + cbPrizeList.SelectedItem.ToString();
                msg.msg = strMessage;
                record.Write(msg);      
            }
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if ( start ) {
                iLucyNum = Moon.DiceRoller();
                Action action = delegate () {
                    label1.Text = strUsersList[iLucyNum];
                };
                Invoke(action);
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            record.SaveInFile();
        }

        void orz_ResetPrizeList()
        {
            cbPrizeList.DataSource = Moon.GetPizesList();
        }
    }
}
