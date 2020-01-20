using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using orzServer;
namespace orz
{
    public delegate void ResetPrizeList();
    public partial class DataView_Winners : Form
    {
        bool SelTheSame = false;
        orzServer.MoonServer Moon;
        DataTable dtWinners;

        public event ResetPrizeList ResetPrize;

        public DataView_Winners()
        {
            InitializeComponent();
            Moon = orzServer.MoonServer.GetServer();
            dtWinners = Moon.GetDTWinners();
        }

        private void DataView_Winners_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dtWinners;

            comboBox1.Items.Add("全、ALL");
            //comboBox1.Items.Add("123");
            comboBox1.SelectedItem = "全、ALL";
            foreach ( var item in Moon.GetPrizeCount() ) {
                if ( item.Value > 1 ) {
                    comboBox1.Items.Add(item.Key);
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)     //选择用户
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("奖品");
            dt.Columns.Add(dc);

            if ( comboBox1.SelectedItem.ToString() != "全、ALL" ) {
                string strSelect = "参与者 = '" + comboBox1.SelectedItem.ToString() + "'";
                var data = dtWinners.Select(strSelect);
                SelTheSame = true;
                foreach ( var row in data ) {
                    dt.Rows.Add(row[1]);
                }
                
                dataGridView1.DataSource = dt;
            } else {
                SelTheSame = false;
                dataGridView1.DataSource = dtWinners;
            }
        }
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ( SelTheSame ) {
                int selected = dataGridView1.CurrentRow.Index;      //获取选中行
                var sel = dataGridView1[0, selected];

                DialogResult Confirm= MessageBox.Show("选择后不能恢复", "选择提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if ( Confirm == DialogResult.OK ) {     //二次确认

                    DataRow[] dts = dtWinners.Select(string.Format("奖品 <> {0} and 参与者 = {1}", sel.Value.ToString(), comboBox1.SelectedItem.ToString()));        //获取未选择的奖品

                    Moon.SelectPrize(dts, comboBox1.SelectedItem.ToString());
                    dtWinners = Moon.GetDTWinners();

                    /*DataTable dt = new DataTable();
                    DataColumn dc = new DataColumn("奖品");
                    dt.Columns.Add(dc);
                    string strSelect = "参与者 = '" + comboBox1.SelectedItem.ToString() + "'";
                    var data = dtWinners.Select(strSelect);
                    SelTheSame = true;
                    foreach ( var row in data ) {
                        dt.Rows.Add(row[1]);
                    }*/
                    comboBox1.SelectedItem = "全、ALL";
                    dataGridView1.DataSource = dtWinners;
                }
            }
        }
        private void ExportInExcel_Click(object sender, EventArgs e)    //导出Excel
        {
            Moon.ExportWinnersList();
        }

        private void DataView_Winners_FormClosing(object sender, FormClosingEventArgs e)
        {
            //需要重置主界面 奖品combox
            ResetPrize();
        }
    }
}
