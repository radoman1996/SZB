using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemZaBolnicu
{
    public partial class PregledPacijentaFrm : Form
    {
        SqlConnection conn;
        String jmbg;
        public PregledPacijentaFrm(SqlConnection konekcija, String jmbgPacijenta)
        {
            this.conn = konekcija;
            this.jmbg = jmbgPacijenta;
            InitializeComponent();
        }

        private void PregledPacijentaFrm_Load(object sender, EventArgs e)
        {
            popuni();
        }

        #region METODE

        public void popuni()
        {
            String upit = "SELECT * FROM Pacijent WHERE JMBG=@jmbgParam";
            SqlCommand komanda = new SqlCommand();
            try
            {
                komanda.Connection = conn;
                komanda.CommandText = upit;

                komanda.Parameters.Add("jmbgParam", SqlDbType.VarChar);
                komanda.Parameters["jmbgParam"].Value = this.jmbg;

                SqlDataReader citaj = komanda.ExecuteReader();
                citaj.Read();
                textBoxIme.Text = citaj["ime"].ToString();
                textBoxImeRoditelja.Text = citaj["imeRoditelja"].ToString();
                textBoxPrezime.Text = citaj["prezime"].ToString();
                textBoxJMBG.Text = citaj["jmbg"].ToString();
                dateTimePickerDatumRodjenja.Text = citaj["datum"].ToString();
                citaj.Close();


            }
            catch(Exception err)
            {
                MessageBox.Show("Greska " + err);
            }
        }

        public void sacuvajPregled()
        {
            String upit = "INSERT INTO Karton VALUES (@opisParam,@jmbgParam,@datumParam)";
            String upit2 = "UPDATE Pregled SET zavrseno=0 WHERE jmbgPacijenta=@jmbg2Param";
            SqlCommand komanda = new SqlCommand();
            //Console.WriteLine(textBoxOpisProblema.Text);

            try
            {
                komanda.Connection = this.conn;
                komanda.CommandText = upit;

                komanda.Parameters.Add("jmbgParam", SqlDbType.VarChar);
                komanda.Parameters.Add("opisParam", SqlDbType.Text);
                komanda.Parameters.Add("datumParam", SqlDbType.DateTime);

                komanda.Parameters["jmbgParam"].Value = textBoxJMBG.Text;
                komanda.Parameters["opisParam"].Value = textBoxOpisProblema.Text;
                komanda.Parameters["datumParam"].Value = DateTime.Now.ToString();

                komanda.ExecuteNonQuery();

                komanda.CommandText = upit2;
                komanda.Parameters.Add("jmbg2Param", SqlDbType.VarChar);
                komanda.Parameters["jmbg2Param"].Value = textBoxJMBG.Text;

                komanda.ExecuteNonQuery();

                MessageBox.Show("Uspjesno cuvanje u kartonu ");

                this.Close();


            }
            catch(Exception err)
            {
                MessageBox.Show("Nije uspjelo čuvanje podataka u karton " + err);
            }
        }
        #endregion
        private void btnZavrsipregled_Click(object sender, EventArgs e)
        {
            sacuvajPregled();
            Console.WriteLine(DateTime.Now);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
