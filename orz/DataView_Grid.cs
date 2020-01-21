using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace orz
{
    public partial class DataView_Grid : Form
    {
        DataTable dtDetail;
        Dictionary<string, int> dictSimple;
        public DataView_Grid()
        {
            InitializeComponent();
        }
        public DataView_Grid(DataTable dt)
        {
            InitializeComponent();
            dtDetail = dt;
        }

        private void DataView_Grid_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dtDetail;
        }

        private void DataView_Grid_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridView1.DataSource = null;
        }
        //简略视图
        private void simpleView_Click(object sender, EventArgs e)
        {
            string strName;
            dictSimple = new Dictionary<string, int>();
            if ( dictSimple.Count < 1 ) {

                foreach ( DataRow dr in dtDetail.Rows ) {
                    strName = dr.ItemArray[0].ToString();
                    if ( dictSimple.ContainsKey(strName) ) {
                        dictSimple[strName] += 1;
                    } else {
                        dictSimple.Add(strName, 1);
                    }
                }
            }
            //dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = ( from dt in dictSimple
                                         select new {
                                             参与者 = dt.Key,
                                             个数 = dt.Value
                                         } ).ToArray();
        }

        private void detailView_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dtDetail;
        }
    }
}
