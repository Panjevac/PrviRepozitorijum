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
        string conectionstring = "Data source= INF_4_04\\SQLPBG; initial catalog= MilosP49; Integrated security= true";                              // jednu kosu crtu menjamo sa dve - to je c ovski nacin (kod data source)
        public int red = 0;
        DataTable ucenik1 = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void Funkcija()
        {
            if (ucenik1.Rows.Count == 0)
            {
                txt_id.Text = "";
                txt_ime.Text = "";
                txt_prezime.Text = "";
                txt_ocena.Text = "";
                btn_next.Enabled = false;
                btn_previous.Enabled = false;
                btn_end.Enabled = false;
                btn_begining.Enabled = false;
            }
            else
            {

                txt_id.Text = ucenik1.Rows[red]["id"].ToString();                      //prva rows[0] znaci 0 vrsta, a rows[0][1] nam je ovde isto sto i rows[0][ime] jer smo u adapteru naveli ime na drugom mestu
                txt_ime.Text = ucenik1.Rows[red]["ime"].ToString();
                txt_prezime.Text = ucenik1.Rows[red]["prezime"].ToString();
                txt_ocena.Text = ucenik1.Rows[red]["ocena"].ToString();

                if (red == ucenik1.Rows.Count - 1)
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            SqlConnection veza = new SqlConnection(conectionstring);

            SqlDataAdapter adapter = new SqlDataAdapter("select id, ime, prezime,ocena from ucenik", veza);
            adapter.Fill(ucenik1);

            //MessageBox.Show(ucenik.Rows.Count.ToString());

            Funkcija();


        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            red++;
            Funkcija();
        }

        private void btn_previous_Click(object sender, EventArgs e)
        {
            red--;
            Funkcija();
        }

        private void btn_begining_Click(object sender, EventArgs e)
        {
            red=0;
            Funkcija();
        }

        private void btn_end_Click(object sender, EventArgs e)
        {
            red=ucenik1.Rows.Count-1;
            Funkcija();
        }

        private void btn_dodaj_Click(object sender, EventArgs e)
        {
            string privremeno = "insert into ucenik (ime, prezime, ocena) values ( '" + txt_ime.Text + "','" + txt_prezime.Text + "'," + txt_ocena.Text + ")";
            //MessageBox.Show(privremeno);

            SqlConnection veza = new SqlConnection(conectionstring);
            SqlCommand naredba = new SqlCommand(privremeno, veza);

            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("select id, ime, prezime,ocena from ucenik order by id", veza);
            ucenik1.Clear();
            adapter.Fill(ucenik1);
            red = ucenik1.Rows.Count - 1;
            Funkcija();
        }

        private void btn_obrisi_Click(object sender, EventArgs e)
        {
            string pomocni = "delete from ucenik where id=" + txt_id.Text;

            SqlConnection veza = new SqlConnection(conectionstring);
            SqlCommand naredba = new SqlCommand(pomocni, veza);

            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("select id, ime, prezime,ocena from ucenik order by id", veza);
            ucenik1.Clear();
            adapter.Fill(ucenik1);
            if (red>ucenik1.Rows.Count-1)
            {
                red = ucenik1.Rows.Count - 1;
            }
            Funkcija();
        }

        private void btn_izmeni_Click(object sender, EventArgs e)
        {
            string pomocni = "update ucenik set ime='" + txt_ime.Text + "',prezime='" + txt_prezime.Text + "', ocena=" + txt_ocena.Text + "where id=" + txt_id.Text ;

            SqlConnection veza = new SqlConnection(conectionstring);
            SqlCommand naredba = new SqlCommand(pomocni, veza);

            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("select id, ime, prezime,ocena from ucenik order by id", veza);
            ucenik1.Clear();
            adapter.Fill(ucenik1);
            Funkcija();
        }
    }
}
