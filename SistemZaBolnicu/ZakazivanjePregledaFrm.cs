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
    public partial class ZakazivanjePregledaFrm : Form
    {
        SqlConnection conn;
        String jmbgP;
        bool vidljivost;

        public ZakazivanjePregledaFrm(SqlConnection konekcija, String jmbgPacijenta, bool vidljivost)
        {
            this.conn = konekcija;
            this.jmbgP = jmbgPacijenta;
            this.vidljivost = vidljivost;

            InitializeComponent();
        }

        private void ZakazivanjePregledaFrm_Load(object sender, EventArgs e)
        {
            ProvjeraVidljivosti();
        }

        #region ZAKAZIVANJE PREGLEDA
        private void btnOtkaziPregled_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnZakaziPregled_Click(object sender, EventArgs e)
        {
            DodajPregled();
        }
        #endregion

        #region METODE

        public void ProvjeraVidljivosti()
        {
            if(this.vidljivost == true)
            {
                textBoxImePacijentaPregled.ReadOnly = false;
                textBoxImeRoditeljaPacijentaPregled.ReadOnly = false;
                textBoxPrezimePacijentaPregled.ReadOnly = false;
                textBoxJMBGPacijentaPregled.ReadOnly = false;
            }
            else
            {
                PopuniPolja();
            }
        }

        public void DodajPregled()
        {
            if(textBoxImePacijentaPregled.Text == "" || textBoxImeRoditeljaPacijentaPregled.Text == "" || textBoxPrezimePacijentaPregled.Text == "" || textBoxJMBGPacijentaPregled.Text == "")
            {
                MessageBox.Show("Sva polja treba da su popunjena");
                return;
            }

            String upit = "INSERT INTO Pregled VALUES (@datumParam, @jmbgPacijentaParam, @zavrsenParam)";
            SqlCommand komanda = new SqlCommand();
            try
            {
                komanda.Connection = this.conn;
                komanda.CommandText = upit;

                komanda.Parameters.Add("datumParam", SqlDbType.Date);
                komanda.Parameters.Add("jmbgPacijentaParam", SqlDbType.VarChar);
                komanda.Parameters.Add("zavrsenParam", SqlDbType.Int);

                komanda.Parameters["datumParam"].Value = dateTimePickerDatumZakazivanjaPregleda.Value;
                komanda.Parameters["jmbgPacijentaParam"].Value = textBoxJMBGPacijentaPregled.Text;
                komanda.Parameters["zavrsenParam"].Value = 1; //ako je 1 onda pregled nije obavljen ako je 0 onda jeste

                komanda.ExecuteNonQuery();
                MessageBox.Show("Uspješno ste zakazali pregled");
                this.Close();
            }
            catch(Exception err)
            {
                MessageBox.Show("Nije uspjelo zakazivanje pregleda " + err);
            }
        }

        public void PopuniPolja()
        {
            String upit = "SELECT * FROM Pacijent WHERE JMBG=@jmbgParam";

            SqlCommand komanda = new SqlCommand();

            try
            {
                komanda.Connection = this.conn;
                komanda.CommandText = upit;

                komanda.Parameters.Add("jmbgParam", SqlDbType.VarChar);
                komanda.Parameters["jmbgParam"].Value = this.jmbgP;

                SqlDataReader citaj = komanda.ExecuteReader();
                citaj.Read();

                textBoxImePacijentaPregled.Text = citaj["Ime"].ToString();
                textBoxImeRoditeljaPacijentaPregled.Text = citaj["ImeRoditelja"].ToString();
                textBoxPrezimePacijentaPregled.Text = citaj["Prezime"].ToString();
                textBoxJMBGPacijentaPregled.Text = this.jmbgP;

                citaj.Close();
            }
            catch(Exception err)
            {
                MessageBox.Show("Nije uspjelo popunjavanje polja za pregled " + err);
            }
        }

        #endregion
    }
}
