using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;    // ovo je za datatable - bez toga nemamo tu funkciju
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4_9_prva
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable ucenik = new DataTable();
            string conectionstring = "Data source= INF_4_04\\SQLPBG; initial catalog= MilosP49; Integrated security= true";                              // jednu kosu crtu menjamo sa dve - to je c ovski nacin (kod data source)
        }
    }
}
