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
            DataView_Grid dvg = new DataView_Grid(dt);
            dvg.Show();
        }

        //开始抽奖
        private void rbtnDiceRoller_Click(object sender, EventArgs e)
        {
            if ( strUsersList != null ) {
                start = !start;
                if ( start ) {      //开始
                    timer.Start();

                } else if ( ( !start ) && ( iLucyNum != -1 ) ) {     //结算
                    timer.Close();

                    string strLucy = strUsersList[iLucyNum];
                    string strTime = DateTime.Now.ToString("G");
                    Moon.AddWinners(strLucy, strTime);
                }
            } else {
                MessageBox.Show("你该不会连用户数据都没有吧，那直接写上碎月的名字好了！");
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
        private void 已中奖ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Msg> dictWinners = Moon.GetWinnersList();

            DataTable dtWinners = new DataTable();
            DataColumn dcUser = new DataColumn("参与者", System.Type.GetType("System.String"));
            DataColumn dcTime = new DataColumn("时间", System.Type.GetType("System.String"));
            dtWinners.Columns.Add(dcUser);
            dtWinners.Columns.Add(dcTime);

            foreach ( var data in dictWinners ) {
                DataRow dr = dtWinners.NewRow();
                dr[0] = data.strUserName;
                dr[1] = data.strDateTime;
                dtWinners.Rows.Add(dr);
            }

            DataView_Grid dwg = new DataView_Grid(dtWinners);
            dwg.ShowDialog();
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

    }
}
