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
    public partial class UnosPlateFrm : Form
    {
        SqlConnection konekcija;
        String naziv;
        String jmbg;
        String zarada;

        public UnosPlateFrm(SqlConnection conn, String table, String JMBG, String plata)
        {
            this.konekcija = conn;
            this.naziv = table;
            this.jmbg = JMBG;
            this.zarada = plata;
            InitializeComponent();
        }

        private void UnosPlateFrm_Load(object sender, EventArgs e)
        {
            textBoxJMBGZaposlenog.Text = jmbg;
            if(this.zarada != "0")
            {
                textBoxPlata.Text = this.zarada;
            }
        }

        private void btnSacuvajPlatu_Click(object sender, EventArgs e)
        {
            //String upit = "UPDATE " + naziv + " SET Plata=" + textBoxPlata.Text + " WHERE JMBG=" + jmbg;
            String upit = "UPDATE " + naziv + " SET Plata=@plataParam WHERE JMBG=@jmbgParam";

            SqlCommand komanda = new SqlCommand();
            try
            {
                komanda.Connection = konekcija;
                komanda.CommandText = upit;

                komanda.Parameters.Add("plataParam", SqlDbType.Float);
                komanda.Parameters.Add("jmbgParam", SqlDbType.VarChar);

                komanda.Parameters["jmbgParam"].Value = this.jmbg;
                komanda.Parameters["plataParam"].Value = textBoxPlata.Text;
                

                komanda.ExecuteNonQuery();

                this.Close();
            }
            catch(Exception err)
            {
                MessageBox.Show("Plata nije sacuvana" + err);
                return;
            }
        }
    }
}
