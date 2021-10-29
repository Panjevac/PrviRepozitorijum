using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;    // ovo je za datatable - bez toga nemamo tu funkciju
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _4_9_prva
{
    public partial class Form1 : Form
    {
        public int red = 0;
        DataTable ucenik = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void Funkcija()
        {  
            txt_id.Text = ucenik.Rows[red]["id"].ToString();                      //prva rows[0] znaci 0 vrsta, a rows[0][1] nam je ovde isto sto i rows[0][ime] jer smo u adapteru naveli ime na drugom mestu
            txt_ime.Text = ucenik.Rows[red]["ime"].ToString();
            txt_prezime.Text = ucenik.Rows[red]["prezime"].ToString();
            txt_ocena.Text = ucenik.Rows[red]["ocena"].ToString();

            if (red==ucenik.Rows.Count-1)
            {
                btn_next.Enabled = false;
                btn_end.Enabled = false;
            }
            else
            {
                btn_next.Enabled = true;
                btn_end.Enabled = true;
            }

            if (red == 0)
            {
                btn_previous.Enabled = false;
                btn_begining.Enabled = false;                          // moze i btn_previous.enabled=(red!=0);
            }
            else
            {
                btn_previous.Enabled = true;
                btn_begining.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            string conectionstring = "Data source= INF_4_04\\SQLPBG; initial catalog= MilosP49; Integrated security= true";                              // jednu kosu crtu menjamo sa dve - to je c ovski nacin (kod data source)
            SqlConnection veza = new SqlConnection(conectionstring);

            SqlDataAdapter adapter = new SqlDataAdapter("select id, ime, prezime,ocena from ucenik", veza);
            adapter.Fill(ucenik);

            //MessageBox.Show(ucenik.Rows.Count.ToString());

            Funkcija();


        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            red++;
            Funkcija();
        }
    }
}
