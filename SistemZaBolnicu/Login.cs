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
    public partial class Login : Form
    {
        PomocnaKlasa pom = new PomocnaKlasa();
        //Form1 f1 = new Form1();
        private String forward = "";
        //ProsledjivanjePodataka pp = new ProsledjivanjePodataka();
        SqlConnection konekcija;
        int prioritet;
        Panel panel;
        DataGridView dgv, dgv2, dgvDR;
        String[] kolonePacijent = { "Ime,", "ImeRoditelja,", "Prezime,", "JMBG,", "Datum,", "Pol,", "Grad" };
        String[] kolonePregleda = { "Ime,", "ImeRoditelja,", "Prezime,", "JMBG,", "Telefon,", "Datum" };
        Label lab;

        public Login(SqlConnection conn, int prioritet, Panel p, Label nalog, DataGridView dgvDR2)
        {
            this.konekcija = conn;
            this.prioritet = prioritet;
            this.panel = p;
            this.lab = nalog;
            this.dgvDR = dgvDR2;
            InitializeComponent();
        }

        public Login(SqlConnection conn, int prioritet, Panel p)
        {
            this.konekcija = conn;
            this.prioritet = prioritet;
            this.panel = p;
            
            InitializeComponent();
        }
        public Login(SqlConnection conn, int prioritet, Panel p, DataGridView grid1, DataGridView grid2, Label nalog)
        {
            this.konekcija = conn;
            this.prioritet = prioritet;
            this.panel = p;
            this.dgv = grid1;
            this.dgv2 = grid2;
            this.lab = nalog;
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            String upit = "SELECT * FROM KorisnickiNalozi WHERE Prioritet=@prioritetParam and (Radi=@radiParam or Radi=2)";
            try
            {
                SqlCommand komanda = new SqlCommand();
                komanda.Connection = konekcija;
                komanda.CommandText = upit;
                komanda.Parameters.Add("prioritetParam", SqlDbType.Int);
                komanda.Parameters.Add("radiParam", SqlDbType.Int);
                komanda.Parameters["prioritetParam"].Value = this.prioritet;
                komanda.Parameters["radiParam"].Value = 1;

                SqlDataReader procitaj = komanda.ExecuteReader();
                while (procitaj.Read())
                {
                    comboBoxUsersLogin.Items.Add(procitaj["KorisnickoIme"]);
                }
                procitaj.Close();

                //Console.WriteLine("iz osnovne klase " + pp.Jmbg);
            }
            catch(Exception err)
            {
                MessageBox.Show("nije uspjelo citanje iz tabele" + err);
            }
        }

        private void btnPrijaviSeLogin_Click(object sender, EventArgs e)
        {
            //srediti provjeru sifre pa tek onda prikazivati panel
            //String korIme = comboBoxUsersLogin.SelectedItem.ToString();

            if(this.prioritet == 1)
            {
                int vr = postaviVrijednost();
                if(vr == 1)
                {
                    return;
                }
                if(provjeraPodataka() == true)
                {
                    pom.prikaziOdredjenePacijente(this.dgv, "Pacijent", this.konekcija, kolonePacijent, this.forward);
                    pom.prikaziPreglede(this.dgv2, "Pregled", "Pacijent", this.konekcija, kolonePregleda, this.forward);
                    this.panel.Visible = true;
                }
                else
                {
                    MessageBox.Show("Podaci nisu ispravni");
                    return;
                }
                
                //Console.WriteLine("iz login " + pp.GetJMBG());

            }
            else if(this.prioritet == 3)
            {
                if (provjeraPodataka() == true)
                {
                    this.panel.Visible = true;
                }
                else
                {
                    MessageBox.Show("Podaci nisu ispravni");
                    return;
                }
                
            }
            else if(this.prioritet == 2)
            {
                int vr = postaviVrijednostDR();
                if (vr == 1)
                {
                    return;
                }
                if (provjeraPodataka() == true)
                {
                    pom.prikaziPreglede(this.dgvDR, "Pregled", "Pacijent", this.konekcija, kolonePregleda, this.forward);
                    this.panel.Visible = true;
                }
                else
                {
                    MessageBox.Show("Podaci nisu ispravni");
                    return;
                }
                
            }

            //postaviVrijednost();
            
            //this.panel.Visible = true;

            this.Close();
        }

        private void btnOtkaziLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int postaviVrijednost()
        {
            if(comboBoxUsersLogin.SelectedIndex == -1)
            {
                MessageBox.Show("Potrebno je da izaberete Vaše korisničko ime");
                return 1; //nije ispravno
            }
            String korIme = comboBoxUsersLogin.SelectedItem.ToString();
            String upit = "SELECT JMBGDoktora, Ime, Prezime FROM MedicinskaSestra WHERE nalog=@nalogParam";

            SqlCommand komanda = new SqlCommand();
            try
            {
                komanda.CommandText = upit;
                komanda.Connection = this.konekcija;

                komanda.Parameters.Add("nalogParam", SqlDbType.VarChar);
                komanda.Parameters["nalogParam"].Value = korIme;

                SqlDataReader citaj = komanda.ExecuteReader();
                citaj.Read();
                String trazeniJMBG = citaj["JMBGDoktora"].ToString();
                String trazeniPodaci = citaj["Ime"].ToString();// + " " + citaj["Prezime"].ToString();
                //Console.WriteLine("trazeni " + trazeniJMBG);
                citaj.Close();
                //pp.SetJMBG(trazeniJMBG);
                //pp.Jmbg = trazeniJMBG;
                //f1.JMBGPodatak = trazeniJMBG;
                //MessageBox.Show("Podaci uspjesno proslijedjeni");
                KlasaZaPozive kp = new KlasaZaPozive();
                kp.Vrijednost = trazeniJMBG;
                this.forward = trazeniJMBG;
                this.lab.Text = korIme;
                return 0; //ispravno
            }
            catch(Exception err)
            {
                MessageBox.Show("Nije uspjelo prijavljivanje. Greska je " + err);
                return 1;
            }
        }

        public int postaviVrijednostDR()
        {
            if (comboBoxUsersLogin.SelectedIndex == -1)
            {
                MessageBox.Show("Potrebno je da izaberete Vaše korisničko ime");
                return 1; //nije ispravno
            }
            String korIme = comboBoxUsersLogin.SelectedItem.ToString();
            String upit = "SELECT JMBG FROM Doktor WHERE nalog=@nalogParam";

            SqlCommand komanda = new SqlCommand();
            try
            {
                komanda.CommandText = upit;
                komanda.Connection = this.konekcija;

                komanda.Parameters.Add("nalogParam", SqlDbType.VarChar);
                komanda.Parameters["nalogParam"].Value = korIme;

                SqlDataReader citaj = komanda.ExecuteReader();
                citaj.Read();
                String trazeniJMBG = citaj["JMBG"].ToString();
                //String trazeniPodaci = citaj["Ime"].ToString();// + " " + citaj["Prezime"].ToString();
                //Console.WriteLine("trazeni " + trazeniJMBG);
                citaj.Close();
                //pp.SetJMBG(trazeniJMBG);
                //pp.Jmbg = trazeniJMBG;
                //f1.JMBGPodatak = trazeniJMBG;
                //MessageBox.Show("Podaci uspjesno proslijedjeni");
                KlasaZaPozive kp = new KlasaZaPozive();
                kp.Vrijednost = trazeniJMBG;
                this.forward = trazeniJMBG;
                this.lab.Text = korIme;
                return 0; //ispravno
            }
            catch (Exception err)
            {
                MessageBox.Show("Nije uspjelo prijavljivanje. Greska je " + err);
                return 1;
            }
        }

        public String Forward
        {
            get
            {
                return this.forward;
            }
        }

        public bool provjeraPodataka()
        {
            if(comboBoxUsersLogin.SelectedIndex == -1)
            {
                MessageBox.Show("Potrebno je da izaberete nalog");
                return false;
            }
            String user = comboBoxUsersLogin.SelectedItem.ToString();
            String pass = textBoxPasswordLogin.Text;

            String upit = "SELECT * FROM KorisnickiNalozi WHERE korisnickoIme=@nalogParam";
            SqlCommand komanda = new SqlCommand();
            try
            {
                komanda.Connection = konekcija;
                komanda.CommandText = upit;

                komanda.Parameters.Add("nalogParam", SqlDbType.VarChar);
                komanda.Parameters["nalogParam"].Value = user;

                SqlDataReader citaj = komanda.ExecuteReader();
                citaj.Read();
                if(citaj["sifra"].ToString() == pass)
                {
                    citaj.Close();
                    return true;
                }
                else
                {
                    citaj.Close();
                    return false;
                }
                
            }
            catch(Exception err)
            {
                MessageBox.Show("Prijavljivalje nije moguće " + err);
                return false;
            }
        }
    }
}
