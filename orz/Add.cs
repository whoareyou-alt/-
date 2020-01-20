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
    public enum OpenMode {
        AddUser = 0, AddPrize = 1
    }
    public partial class Add : Form
    {
        int OpenMode;

        orzServer.MoonServer Moon;
        orzServer.Record record;
        public Add(int Mode)
        {
            InitializeComponent();
            OpenMode = Mode;
        }

        private void Add_Load(object sender, EventArgs e)
        {
            switch ( OpenMode ) {
                case (int)orz.OpenMode.AddUser:

                    break;
                case (int)orz.OpenMode.AddPrize:

                    break;
            }

            Moon = orzServer.MoonServer.GetServer();
            record = orzServer.Record.GetServer();
        }
    }
}
