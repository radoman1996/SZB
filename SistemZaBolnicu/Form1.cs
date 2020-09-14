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
    public partial class Form1 : Form
    {
        String konekcioniString = "Server=KORISNIK\\SQLEXPRESS; Database=SistemZaBolnicu; Integrated Security = true";
        SqlConnection konekcija;
        PomocnaKlasa pomClass = new PomocnaKlasa();
        bool popunjen = false;
        bool popunjenPacijent = false;
        String[] koloneVozaca = { "*" };
        String[] koloneDoktora = { "Ime,", "ImeRoditelja,", "Prezime,", "JMBG,", "BrojTelefona,", "DatumRodjenja,", "Grad,", "Specijalizacija,", "Plata,", "Nalog" };
        String[] koloneMS = { "Ime,", "ImeRoditelja,", "Prezime,", "JMBG,", "BrojTelefona,", "DatumRodjenja,", "Pol,", "Grad,", "Plata,", "Nalog" };
        String[] kolonePacijent = { "Ime,", "ImeRoditelja,", "Prezime,", "JMBG,", "Datum,", "Pol,", "Grad" };
        //String[] kolonePregledi = { "DatumPregleda,", "jmbgPacijenta" };
        String[] kolonePregleda = { "Ime,", "ImeRoditelja,", "Prezime,", "JMBG,", "Telefon,", "Datum" };
        String plata;

        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                konekcija = new SqlConnection();
                konekcija.ConnectionString = konekcioniString;
                konekcija.Open();

                popuniListeIGW();

            }
            catch(Exception err)
            {
                MessageBox.Show("Konektovanje nije uspjelo " + err);
            }
            
        }
        #region POCETNA
        private void btnDirektor_Click(object sender, EventArgs e)
        {
            Login login = new Login(konekcija,3,panelDirektor);
            login.ShowDialog();
            lblNalogDirektor.Text = "Administrator";
        }

        private void btnDoktor_Click(object sender, EventArgs e)
        {
            Login login = new Login(konekcija, 2, panelDoktor, lblNalogDoktora, dataGridViewSpisakPacijenataDR);
            login.ShowDialog();
        }

        private void btnMedSestra_Click(object sender, EventArgs e)
        {
            Login login = new Login(konekcija, 1, panelMedicinskaSestra, dataGridViewTabelaPacijenata, dataGridViewSpisakPregleda, lblNalog);
            login.ShowDialog();
        }
        #endregion

        #region DIREKTOR PANEL

        private void btnDodajZaposlenog_Click(object sender, EventArgs e)
        {
            PanelFalse2(panelDirektor);
            IzborZaposlenogFrm forma = new IzborZaposlenogFrm(panelDodajDoktora,panelDodajMS,panelDodajVozaca);
            forma.ShowDialog();
            lblDR.Text = "Dodaj doktora";
            lblMS.Text = "Dodaj medicinsku sestru";
            lblVozac.Text = "Dodaj vozača";

            this.Width = 857;

            
            /*panelPrikaziDoktora.Visible = false;
            panelPrikaziMS.Visible = false;
            panelPrikaziVozaca.Visible = false;*/
            pomClass.ponistiVozaca(textBoxImeVozaca, textBoxPrezimeVozaca, textBoxImeRoditeljaVozaca, textBoxJMBGVozaca, textBoxBRTelVozaca, comboBoxGradVozaca, comboBoxKategorijaVozac, radioButtonMuskoVozac, radioButtonZenskoVozac, dateTimePickerVozaca);
            pomClass.ponistiMS(textBoxImeMS, textBoxPrezimeMS, textBoxImeRoditeljaMS, textBoxJMBGMS, textBoxBRTelMS, textBoxKorisnickoImeMS, textBoxEmailMS, textBoxSifraMS, comboBoxGradMS, comboBoxSpecijalizacijaMS, comboBoxIzaberiDoktora, radioButtonMuskoMS,radioButtonZenskoMS,dateTimePickerMS);
            pomClass.ponistiDoktora(textBoxImeDoktora, textBoxPrezimeDoktora, textBoxImeRoditeljaDoktora, textBoxJMBGDoktora, textBoxBRTelDoktora, textBoxKorisnickoImeDoktora, textBoxEMailDR, textBoxSifraDoktora, comboBoxGradDoktor, comboBoxSpecijalizacija, radioButtonMuskoDR, radioButtonZenskoDR, dateTimePickerDoktora);
            
        }

        private void btnPrikaziZaposlenog_Click(object sender, EventArgs e)
        {
            PanelFalse2(panelDirektor);
            IzborZaposlenogFrm forma = new IzborZaposlenogFrm(panelPrikaziDoktora, panelPrikaziMS, panelPrikaziVozaca);
            forma.ShowDialog();
            
            //this.Width = 1240; //mora se na kraju promjeniti..da bude prilagodljivo svakom obliku
            if(panelPrikaziVozaca.Visible == true)
            {
                this.Width = 1240;
            }
            else if(panelPrikaziMS.Visible == true)
            {
                this.Width = 1210;
            }
            else if(panelPrikaziDoktora.Visible == true)
            {
                this.Width = 1310;
            }
            panelPrikaziMS.Width = 1012;
            panelPrikaziDoktora.Width = 1115;
            panelPrikaziVozaca.Width = 1043;
            dataGridViewTabelaMS.Width = 1012;
            dataGridViewTabelaDoktora.Width = 1115;
            dataGridViewTabelaVozac.Width = 1043;
            /*panelPrikaziSvePacijente.Width = 700;
            dataGridViewSpisakPacijenataDR.Width = 730;*/

            pomClass.popuniGridView(dataGridViewTabelaDoktora, "Doktor", konekcija, koloneDoktora);
            pomClass.popuniGridView(dataGridViewTabelaMS, "MedicinskaSestra", konekcija, koloneMS);

            pomClass.popuniGridView(dataGridViewTabelaVozac, "Vozac", konekcija, koloneVozaca);

            
            /*panelDodajDoktora.Visible = false;
            panelDodajMS.Visible = false;
            panelDodajVozaca.Visible = false;*/
        }

        private void btnPrikaziPacijenta_Click(object sender, EventArgs e)
        {
            pomClass.popuniGridView(dataGridViewTabelaSvihPacijenata, "Pacijent", konekcija, kolonePacijent);
            PanelFalse(panelDirektor, panelPrikaziSvePacijente);
            panelPrikaziSvePacijente.Width = 663;
            dataGridViewTabelaSvihPacijenata.Width = 663;
            this.Width = 865;
            //panelPrikaziSvePacijente.Visible = true;
        }

        #endregion

        #region DODAJ VOZACA

        private void btnOtkaziVozaca_Click(object sender, EventArgs e)
        {
            pomClass.ponistiVozaca(textBoxImeVozaca, textBoxPrezimeVozaca, textBoxImeRoditeljaVozaca, textBoxJMBGVozaca, textBoxBRTelVozaca, comboBoxGradVozaca, comboBoxKategorijaVozac,radioButtonMuskoVozac,radioButtonZenskoVozac, dateTimePickerVozaca);
            PanelFalse2(panelDirektor);
            //panelDodajVozaca.Visible = false;
        }

        private void btnPonistiVozaca_Click(object sender, EventArgs e)
        {
            pomClass.ponistiVozaca(textBoxImeVozaca, textBoxPrezimeVozaca, textBoxImeRoditeljaVozaca, textBoxJMBGVozaca, textBoxBRTelVozaca, comboBoxGradVozaca, comboBoxKategorijaVozac, radioButtonMuskoVozac, radioButtonZenskoVozac, dateTimePickerVozaca);
        }

        private void btnSacuvajVozaca_Click(object sender, EventArgs e)
        {
            if(popunjen == false)
            {
                DodajVozaca();
            }
            else
            {
                AzurirajVozaca();
            }
        }

        #endregion

        #region DODAJ MEDICINSKU SESTRU
        private void btnSacuvajMS_Click(object sender, EventArgs e)
        {
            if(popunjen == false)
            {
                DodajMedicinskuSestru();
            }
            else
            {
                AzurirajMedicinskuSestru();
            }
        }

        private void btnPonistiMS_Click(object sender, EventArgs e)
        {
            pomClass.ponistiMS(textBoxImeMS, textBoxPrezimeMS, textBoxImeRoditeljaMS, textBoxJMBGMS, textBoxBRTelMS, textBoxKorisnickoImeMS, textBoxEmailMS, textBoxSifraMS, comboBoxGradMS, comboBoxSpecijalizacijaMS, comboBoxIzaberiDoktora, radioButtonMuskoMS, radioButtonZenskoMS, dateTimePickerMS);
        }

        private void btnOtkaziMS_Click(object sender, EventArgs e)
        {
            pomClass.ponistiMS(textBoxImeMS, textBoxPrezimeMS, textBoxImeRoditeljaMS, textBoxJMBGMS, textBoxBRTelMS, textBoxKorisnickoImeMS, textBoxEmailMS, textBoxSifraMS, comboBoxGradMS, comboBoxSpecijalizacijaMS, comboBoxIzaberiDoktora, radioButtonMuskoMS, radioButtonZenskoMS, dateTimePickerMS);
            PanelFalse2(panelDirektor);
            //panelDodajMS.Visible = false;
        }

        #endregion

        #region DODAJ DOKTORA
        private void btnDodajDoktora_Click(object sender, EventArgs e)
        {
            if(popunjen == false)
            {
                DodajDoktora();
            }
            else
            {
                AzurirajDoktora();
            }
        }

        private void btnPonistiCuvnjeDoktora_Click(object sender, EventArgs e)
        {
            pomClass.ponistiDoktora(textBoxImeDoktora, textBoxPrezimeDoktora, textBoxImeRoditeljaDoktora, textBoxJMBGDoktora, textBoxBRTelDoktora, textBoxKorisnickoImeDoktora, textBoxEMailDR, textBoxSifraDoktora, comboBoxGradDoktor, comboBoxSpecijalizacija, radioButtonMuskoDR, radioButtonZenskoDR, dateTimePickerDoktora);
        }

        private void buttonOtkaziCuvanjeDoktora_Click(object sender, EventArgs e)
        {
            PanelFalse2(panelDirektor);
            //panelDodajDoktora.Visible = false;
            pomClass.ponistiDoktora(textBoxImeDoktora, textBoxPrezimeDoktora, textBoxImeRoditeljaDoktora, textBoxJMBGDoktora, textBoxBRTelDoktora, textBoxKorisnickoImeDoktora, textBoxEMailDR, textBoxSifraDoktora, comboBoxGradDoktor, comboBoxSpecijalizacija, radioButtonMuskoDR, radioButtonZenskoDR, dateTimePickerDoktora);
        }

        #endregion


        #region PANEL PRIKAZI DOKTORA
        private void btnOtkaziDoktora_Click(object sender, EventArgs e)
        {
            //panelPrikaziDoktora.Visible = false;
            PanelFalse2(panelDirektor);
        }

        private void btnIzbrisiDoktora_Click(object sender, EventArgs e)
        {
            IzbrisiDoktora();
        }

        private void btnIzmjeniDoktora_Click(object sender, EventArgs e)
        {
            IzmjeniDoktora();
            lblDR.Text = "Izmjeni doktora";
        }

        #endregion

        #region PANEL PRIKAZI VOZACA
        private void btnIzmjeniVozaca_Click(object sender, EventArgs e)
        {
            IzmjeniVozaca();
            lblVozac.Text = "Izmjeni vozača";
        }

        private void btnIzbrisiVozaca_Click(object sender, EventArgs e)
        {
            IzbrisiVozaca();
        }

        private void btnOtkaziVozaca2_Click(object sender, EventArgs e)
        {
            PanelFalse2(panelDirektor);
            //panelPrikaziVozaca.Visible = false;
        }

        #endregion

        #region PANEL PRIKAZI MEDICINSKU SESTRU
        private void btnIzmjeniMS_Click(object sender, EventArgs e)
        {
            IzmjeniMedicinskuSestru();
            lblMS.Text = "Izmjeni medicinsku sestru";
        }

        private void btnIzbrisiMS_Click(object sender, EventArgs e)
        {
            IzbrisiMedicinskuSestru();
        }

        private void btnOtkaziMS2_Click(object sender, EventArgs e)
        {
            PanelFalse2(panelDirektor);
            //panelPrikaziMS.Visible = false;
        }
        #endregion



        #region METODE

        #region METODE ZA MEDICINSKE SESTRE
        public void IzbrisiMedicinskuSestru()
        {
            if (dataGridViewTabelaMS.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Potrebno je za izaberete medicinsku sestru za brisanje");
                return;
            }

            String izbor = dataGridViewTabelaMS.SelectedRows[0].Cells["JMBG"].Value.ToString();
            String nalog = dataGridViewTabelaMS.SelectedRows[0].Cells["Nalog"].Value.ToString();

            String upit1 = "UPDATE MedicinskaSestra SET Radi=@radiParam WHERE JMBG=@jmbgParam";
            String upit2 = "UPDATE KorisnickiNalozi SET Radi=@radiNalogParam WHERE korisnickoIme=@korisnickoImeParam";

            SqlCommand komanda = new SqlCommand();

            try
            {
                komanda.Connection = konekcija;
                komanda.CommandText = upit1;

                komanda.Parameters.Add("jmbgParam", SqlDbType.VarChar);
                komanda.Parameters.Add("radiParam", SqlDbType.Int);
                komanda.Parameters["jmbgParam"].Value = izbor;
                komanda.Parameters["radiParam"].Value = 0;

                komanda.ExecuteNonQuery();

                komanda.CommandText = upit2;

                komanda.Parameters.Add("korisnickoImeParam", SqlDbType.VarChar);
                komanda.Parameters.Add("radiNalogParam", SqlDbType.Int);
                komanda.Parameters["korisnickoImeParam"].Value = nalog;
                komanda.Parameters["radiNalogParam"].Value = 0;

                komanda.ExecuteNonQuery();

                pomClass.popuniGridView(dataGridViewTabelaMS, "MedicinskaSestra", konekcija, koloneMS);

                MessageBox.Show("Uspjesno ste izbrisali medicinsku sestru");
            }
            catch (Exception err)
            {
                MessageBox.Show("Brisanje medicinske sestre nije uspjesno " + err);
            }
        }

        public void DodajMedicinskuSestru()
        {
            if (textBoxImeMS.Text == "" || textBoxImeRoditeljaMS.Text == "" || textBoxPrezimeMS.Text == "" || textBoxEmailMS.Text == "" || textBoxKorisnickoImeMS.Text == "" || textBoxSifraMS.Text == "")
            {
                MessageBox.Show("Potrebno je da popunite sva polja");
                return;
            }

            String jmbg = textBoxJMBGMS.Text;
            if (jmbg.Length == 13)
            {
                long broj;
                bool provjera = Int64.TryParse(jmbg, out broj);
                if (provjera == false)
                {
                    MessageBox.Show("JMBG nije pravilan");
                    return;
                }
            }
            else
            {
                MessageBox.Show("JMBG nije pravilan");
                return;
            }

            String brTel = textBoxBRTelMS.Text;
            if (brTel.Length >= 9)
            {
                int broj;
                bool provjera = Int32.TryParse(brTel, out broj);
                if (provjera == false)
                {
                    MessageBox.Show("Broj telefona nije pravilan");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Broj telefona nije pravilan");
                return;
            }

            String pol = "";
            if (radioButtonMuskoMS.Checked)
            {
                pol = "Musko";
            }
            else if (radioButtonZenskoMS.Checked)
            {
                pol = "Zensko";
            }
            else
            {
                MessageBox.Show("Potrebno je da izaberete pol");
                return;
            }

            if (comboBoxGradMS.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite grad");
                return;
            }

            if (comboBoxSpecijalizacijaMS.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite specijalizaciju");
                return;
            }

            if(comboBoxIzaberiDoktora.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite doktora za medicinsku sestru");
                return;
            }

            String upit1 = "INSERT INTO MedicinskaSestra VALUES (@imeParam, @imeRoditeljaParam, @prezimeParam, @jmbgParam, @brTelParam, @datumParam, @polParam, @gradParam, @specijalizacijaParam, @nalogParam, @plataParam, @jmbgDoktoraParam, @radiParam)";
            String upit2 = "INSERT INTO KorisnickiNalozi VALUES (@korisnickoImeParam, @emailParam, @sifraParam, @prioritetParam, @radiNalogParam)";

            SqlCommand komanda = new SqlCommand();
            try
            {
                komanda.Connection = konekcija;
                komanda.CommandText = upit2;

                komanda.Parameters.Add("korisnickoImeParam", SqlDbType.VarChar);
                komanda.Parameters.Add("emailParam", SqlDbType.VarChar);
                komanda.Parameters.Add("sifraParam", SqlDbType.VarChar);
                komanda.Parameters.Add("prioritetParam", SqlDbType.Int);
                komanda.Parameters.Add("radiNalogParam", SqlDbType.Int);

                komanda.Parameters["korisnickoImeParam"].Value = textBoxKorisnickoImeMS.Text;
                komanda.Parameters["emailParam"].Value = textBoxEmailMS.Text;
                komanda.Parameters["sifraParam"].Value = textBoxSifraMS.Text;
                komanda.Parameters["prioritetParam"].Value = 1;
                komanda.Parameters["radiNalogParam"].Value = 1;

                komanda.ExecuteNonQuery();
                
                komanda.CommandText = upit1;

                komanda.Parameters.Add("imeParam", SqlDbType.VarChar);
                komanda.Parameters.Add("imeRoditeljaParam", SqlDbType.VarChar);
                komanda.Parameters.Add("prezimeParam", SqlDbType.VarChar);
                komanda.Parameters.Add("jmbgParam", SqlDbType.VarChar);
                komanda.Parameters.Add("brTelParam", SqlDbType.VarChar);
                komanda.Parameters.Add("datumParam", SqlDbType.Date);
                komanda.Parameters.Add("polParam", SqlDbType.VarChar);
                komanda.Parameters.Add("gradParam", SqlDbType.VarChar);
                komanda.Parameters.Add("specijalizacijaParam", SqlDbType.VarChar);
                komanda.Parameters.Add("nalogParam", SqlDbType.VarChar);
                komanda.Parameters.Add("plataParam", SqlDbType.Float);
                komanda.Parameters.Add("jmbgDoktoraParam", SqlDbType.VarChar);
                komanda.Parameters.Add("radiParam", SqlDbType.Int);

                komanda.Parameters["imeParam"].Value = textBoxImeMS.Text;
                komanda.Parameters["imeRoditeljaParam"].Value = textBoxImeRoditeljaMS.Text;
                komanda.Parameters["prezimeParam"].Value = textBoxPrezimeMS.Text;
                komanda.Parameters["jmbgParam"].Value = textBoxJMBGMS.Text;
                komanda.Parameters["brTelParam"].Value = textBoxBRTelMS.Text;
                
                komanda.Parameters["datumParam"].Value = dateTimePickerMS.Value;
                
                komanda.Parameters["polParam"].Value = pol;
                komanda.Parameters["gradParam"].Value = comboBoxGradMS.SelectedItem;
                
                komanda.Parameters["specijalizacijaParam"].Value = comboBoxSpecijalizacijaMS.SelectedItem;
                
                komanda.Parameters["nalogParam"].Value = textBoxKorisnickoImeMS.Text;

                komanda.Parameters["plataParam"].Value = 0;

                komanda.Parameters["jmbgDoktoraParam"].Value = (comboBoxIzaberiDoktora.SelectedItem as PomocnaKlasa2).kljuc;

                komanda.Parameters["radiParam"].Value = 1;

                komanda.ExecuteNonQuery();
                UnosPlateFrm forma = new UnosPlateFrm(konekcija, "MedicinskaSestra", jmbg, "0");
                forma.ShowDialog();
                MessageBox.Show("Uspjesno ste dodali medicinsku sestru");
                pomClass.ponistiMS(textBoxImeMS, textBoxPrezimeMS, textBoxImeRoditeljaMS, textBoxJMBGMS, textBoxBRTelMS, textBoxKorisnickoImeMS, textBoxEmailMS, textBoxSifraMS, comboBoxGradMS, comboBoxSpecijalizacijaMS, comboBoxIzaberiDoktora, radioButtonMuskoMS, radioButtonZenskoMS, dateTimePickerMS);

            }
            catch (Exception err)
            {
                String upit3 = "SELECT * FROM MedicinskaSestra WHERE JMBG=@jmbgSParam";
                komanda.Connection = konekcija;
                komanda.CommandText = upit3;

                komanda.Parameters.Add("jmbgSParam", SqlDbType.VarChar);
                komanda.Parameters["jmbgSParam"].Value = jmbg;

                SqlDataReader citaj = komanda.ExecuteReader();
                int brojac = 0;
                String nalog = "";
                while (citaj.Read())
                {
                    if (citaj["Radi"].ToString() == "0")
                    {
                        brojac = 1;
                        nalog = citaj["Nalog"].ToString();
                    }
                }
                citaj.Close();
                if (brojac == 0)
                {
                    MessageBox.Show("Unosenje medicinske sestre nije uspjelo " + err);
                    return;
                }
                else
                {
                    String upit4 = "UPDATE MedicinskaSestra SET Radi=@radiUPParam WHERE JMBG=@jmbgUPParam";
                    komanda.CommandText = upit4;

                    komanda.Parameters.Add("radiUPParam", SqlDbType.Int);
                    komanda.Parameters.Add("jmbgUPParam", SqlDbType.VarChar);

                    komanda.Parameters["jmbgUPParam"].Value = jmbg;
                    komanda.Parameters["radiUPParam"].Value = 1;

                    komanda.ExecuteNonQuery();

                    String upit5 = "UPDATE KorisnickiNalozi SET Radi=@radiNalogUPParam WHERE korisnickoIme=@korisnickoImeUPParam";

                    komanda.CommandText = upit5;

                    komanda.Parameters.Add("radiNalogUPParam", SqlDbType.Int);
                    komanda.Parameters.Add("korisnickoImeUPParam", SqlDbType.VarChar);

                    komanda.Parameters["korisnickoImeUPParam"].Value = nalog;
                    komanda.Parameters["radiNalogUPParam"].Value = 1;

                    komanda.ExecuteNonQuery();
                    MessageBox.Show("Uspjesno ste ponovo dodali medicinsku sestru");
                    pomClass.ponistiMS(textBoxImeMS, textBoxPrezimeMS, textBoxImeRoditeljaMS, textBoxJMBGMS, textBoxBRTelMS, textBoxKorisnickoImeMS, textBoxEmailMS, textBoxSifraMS, comboBoxGradMS, comboBoxSpecijalizacijaMS, comboBoxIzaberiDoktora, radioButtonMuskoMS, radioButtonZenskoMS, dateTimePickerMS);
                }
            }
        }

        public void IzmjeniMedicinskuSestru()
        {
            if (dataGridViewTabelaMS.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Potrebno je da izaberete medicinsku sestru za izmjenu");
                return;
            }
            String izbor = dataGridViewTabelaMS.SelectedRows[0].Cells["JMBG"].Value.ToString();
            String nalog = dataGridViewTabelaMS.SelectedRows[0].Cells["Nalog"].Value.ToString();

            String upit = "SELECT * FROM MedicinskaSestra WHERE JMBG=@jmbgParam";

            SqlCommand komanda = new SqlCommand();

            try
            {
                komanda.Connection = konekcija;
                komanda.CommandText = upit;

                komanda.Parameters.Add("jmbgParam", SqlDbType.VarChar);
                komanda.Parameters["jmbgParam"].Value = izbor;

                PanelFalse(panelDirektor, panelDodajMS);

                /*panelPrikaziMS.Visible = false;
                panelDodajMS.Visible = true;*/

                SqlDataReader citaj = komanda.ExecuteReader();
                citaj.Read();

                textBoxImeMS.Text = citaj["Ime"].ToString();
                textBoxImeRoditeljaMS.Text = citaj["ImeRoditelja"].ToString();
                textBoxPrezimeMS.Text = citaj["Prezime"].ToString();
                textBoxJMBGMS.Text = citaj["JMBG"].ToString();
                textBoxBRTelMS.Text = citaj["BrojTelefona"].ToString();
                dateTimePickerMS.Text = citaj["DatumRodjenja"].ToString();
                String pol = citaj["Pol"].ToString();
                if (pol == "Musko")
                {
                    radioButtonMuskoMS.Checked = true;
                }
                else
                {
                    radioButtonZenskoMS.Checked = true;
                }
                comboBoxGradMS.Text = citaj["Grad"].ToString();
                comboBoxSpecijalizacijaMS.Text = citaj["Specijalizacija"].ToString();

                textBoxKorisnickoImeMS.Text = citaj["Nalog"].ToString();

                plata = citaj["Plata"].ToString();
                String JMBGZaDR = citaj["JMBGDoktora"].ToString();
                citaj.Close();

                String noviUpit = "SELECT Ime, Prezime FROM Doktor WHERE JMBG=" + JMBGZaDR;
                komanda.CommandText = noviUpit;
                SqlDataReader citajPonovo = komanda.ExecuteReader();
                citajPonovo.Read();
                String popuni = citajPonovo["Ime"].ToString() + " " + citajPonovo["Prezime"].ToString();
                comboBoxIzaberiDoktora.Text = popuni;

                citajPonovo.Close();

                String upit2 = "SELECT * FROM KorisnickiNalozi WHERE korisnickoIme=@nalogParam";

                komanda.CommandText = upit2;

                komanda.Parameters.Add("nalogParam", SqlDbType.VarChar);
                komanda.Parameters["nalogParam"].Value = nalog;

                SqlDataReader citaj2 = komanda.ExecuteReader();
                citaj2.Read();
                textBoxEmailMS.Text = citaj2["email"].ToString();
                textBoxSifraMS.Text = citaj2["sifra"].ToString();

                citaj2.Close();

                popunjen = true;
            }
            catch (Exception err)
            {
                MessageBox.Show("Nije uspjelo popunjavanje polja iz baze " + err);
            }
        }

        public void AzurirajMedicinskuSestru()
        {
            if (textBoxImeMS.Text == "" || textBoxImeRoditeljaMS.Text == "" || textBoxPrezimeMS.Text == "" || textBoxEmailMS.Text == "" || textBoxKorisnickoImeMS.Text == "" || textBoxSifraMS.Text == "")
            {
                MessageBox.Show("Potrebno je da popunite sva polja");
                return;
            }

            String jmbg = textBoxJMBGMS.Text;
            if (jmbg.Length == 13)
            {
                long broj;
                bool provjera = Int64.TryParse(jmbg, out broj);
                if (provjera == false)
                {
                    MessageBox.Show("JMBG nije pravilan");
                    return;
                }
            }
            else
            {
                MessageBox.Show("JMBG nije pravilan");
                return;
            }

            String brTel = textBoxBRTelMS.Text;
            if (brTel.Length >= 9)
            {
                int broj;
                bool provjera = Int32.TryParse(brTel, out broj);
                if (provjera == false)
                {
                    MessageBox.Show("Broj telefona nije pravilan");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Broj telefona nije pravilan");
                return;
            }

            String pol = "";
            if (radioButtonMuskoMS.Checked)
            {
                pol = "Musko";
            }
            else if (radioButtonZenskoMS.Checked)
            {
                pol = "Zensko";
            }
            else
            {
                MessageBox.Show("Potrebno je da izaberete pol");
                return;
            }

            if (comboBoxGradMS.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite grad");
                return;
            }

            if (comboBoxSpecijalizacijaMS.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite specijalizaciju");
                return;
            }

            if (comboBoxIzaberiDoktora.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite doktora za medicinsku sestru");
                return;
            }

            String upit1 = "UPDATE MedicinskaSestra SET Ime=@imeParam, ImeRoditelja=@imeRoditeljaParam, Prezime=@prezimeParam, JMBG=@jmbgParam, BrojTelefona=@brTelParam, DatumRodjenja=@datumParam, Pol=@polParam, Grad=@gradParam, Specijalizacija=@specijalizacijaParam, Nalog=@nalogParam, Plata=@plataParam, JMBGDoktora=@jmbgDoktoraParam, Radi=@radiParam WHERE JMBG=@jmbgParam";
            String upit2 = "UPDATE KorisnickiNalozi SET korisnickoIme=@korisnickoImeParam, email=@emailParam, sifra=@sifraParam, prioritet=@prioritetParam, Radi=@radiNalogParam WHERE korisnickoIme=@korisnickoImeParam";

            SqlCommand komanda = new SqlCommand();
            try
            {
                komanda.Connection = konekcija;
                komanda.CommandText = upit2;

                komanda.Parameters.Add("korisnickoImeParam", SqlDbType.VarChar);
                komanda.Parameters.Add("emailParam", SqlDbType.VarChar);
                komanda.Parameters.Add("sifraParam", SqlDbType.VarChar);
                komanda.Parameters.Add("prioritetParam", SqlDbType.Int);
                komanda.Parameters.Add("radiNalogParam", SqlDbType.Int);

                komanda.Parameters["korisnickoImeParam"].Value = textBoxKorisnickoImeMS.Text;
                komanda.Parameters["emailParam"].Value = textBoxEmailMS.Text;
                komanda.Parameters["sifraParam"].Value = textBoxSifraMS.Text;
                komanda.Parameters["prioritetParam"].Value = 1;
                komanda.Parameters["radiNalogParam"].Value = 1;

                komanda.ExecuteNonQuery();
                
                komanda.CommandText = upit1;
                
                komanda.Parameters.Add("imeParam", SqlDbType.VarChar);
                komanda.Parameters.Add("imeRoditeljaParam", SqlDbType.VarChar);
                komanda.Parameters.Add("prezimeParam", SqlDbType.VarChar);
                komanda.Parameters.Add("jmbgParam", SqlDbType.VarChar);
                komanda.Parameters.Add("brTelParam", SqlDbType.VarChar);
                komanda.Parameters.Add("datumParam", SqlDbType.Date);
                komanda.Parameters.Add("polParam", SqlDbType.VarChar);
                komanda.Parameters.Add("gradParam", SqlDbType.VarChar);
                komanda.Parameters.Add("specijalizacijaParam", SqlDbType.VarChar);
                komanda.Parameters.Add("nalogParam", SqlDbType.VarChar);
                komanda.Parameters.Add("plataParam", SqlDbType.Float);
                komanda.Parameters.Add("jmbgDoktoraParam", SqlDbType.VarChar);
                komanda.Parameters.Add("radiParam", SqlDbType.Int);

                komanda.Parameters["imeParam"].Value = textBoxImeMS.Text;
                komanda.Parameters["imeRoditeljaParam"].Value = textBoxImeRoditeljaMS.Text;
                komanda.Parameters["prezimeParam"].Value = textBoxPrezimeMS.Text;

                komanda.Parameters["jmbgParam"].Value = jmbg;

                komanda.Parameters["brTelParam"].Value = brTel;
                
                komanda.Parameters["datumParam"].Value = dateTimePickerMS.Value;

                komanda.Parameters["polParam"].Value = pol;
                komanda.Parameters["gradParam"].Value = comboBoxGradMS.SelectedItem;
                komanda.Parameters["specijalizacijaParam"].Value = comboBoxSpecijalizacijaMS.SelectedItem;

                komanda.Parameters["nalogParam"].Value = textBoxKorisnickoImeMS.Text;

                komanda.Parameters["plataParam"].Value = 0;

                komanda.Parameters["jmbgDoktoraParam"].Value = (comboBoxIzaberiDoktora.SelectedItem as PomocnaKlasa2).kljuc;

                komanda.Parameters["radiParam"].Value = 1;

                komanda.ExecuteNonQuery();

                UnosPlateFrm forma = new UnosPlateFrm(konekcija, "MedicinskaSestra", jmbg, plata);
                forma.ShowDialog();
                MessageBox.Show("Uspjesno ste azurirali medicinsku sestru");
                pomClass.ponistiMS(textBoxImeMS, textBoxPrezimeMS, textBoxImeRoditeljaMS, textBoxJMBGMS, textBoxBRTelMS, textBoxKorisnickoImeMS, textBoxEmailMS, textBoxSifraMS, comboBoxGradMS, comboBoxSpecijalizacijaMS, comboBoxIzaberiDoktora, radioButtonMuskoMS, radioButtonZenskoMS, dateTimePickerMS);
                popunjen = false;
            }
            catch (Exception err)
            {
                MessageBox.Show("Azuriranje medicinske sestre nije uspjesno " + err);
            }

        }
        #endregion

        #region METODE ZA VOZACE
        public void IzbrisiVozaca()
        {
            if (dataGridViewTabelaVozac.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Potrebno je da izaberete vozaca");
                return;
            }

            String izbor = dataGridViewTabelaVozac.SelectedRows[0].Cells["JMBG"].Value.ToString();

            String upit = "DELETE FROM Vozac WHERE JMBG=@jmbgParam";

            SqlCommand komanda = new SqlCommand();

            try
            {
                komanda.Connection = konekcija;
                komanda.CommandText = upit;

                komanda.Parameters.Add("jmbgParam", SqlDbType.VarChar);
                komanda.Parameters["jmbgParam"].Value = izbor;

                komanda.ExecuteNonQuery();

                pomClass.popuniGridView(dataGridViewTabelaVozac, "Vozac", konekcija, koloneVozaca);

                MessageBox.Show("Uspjesno ste izbrisali vozaca");

            }
            catch (Exception err)
            {
                MessageBox.Show("Brisanje vozaca nije uspjesno");
            }
        }

        public void IzmjeniVozaca()
        {
            if (dataGridViewTabelaVozac.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Potrebno je da izaberete Vozaca");
                return;
            }
            String izbor = dataGridViewTabelaVozac.SelectedRows[0].Cells["JMBG"].Value.ToString();

            String upit = "SELECT * FROM Vozac WHERE JMBG=@jmbgParam";

            SqlCommand komanda = new SqlCommand();

            try
            {
                komanda.Connection = konekcija;
                komanda.CommandText = upit;
                komanda.Parameters.Add("jmbgParam", SqlDbType.VarChar);
                komanda.Parameters["jmbgParam"].Value = izbor;

                PanelFalse(panelDirektor, panelDodajVozaca);
                /*panelPrikaziVozaca.Visible = false;
                panelDodajVozaca.Visible = true;*/
                
                SqlDataReader citaj = komanda.ExecuteReader();
                citaj.Read();

                textBoxImeVozaca.Text = citaj["Ime"].ToString();
                textBoxImeRoditeljaVozaca.Text = citaj["ImeRoditelja"].ToString();
                textBoxPrezimeVozaca.Text = citaj["Prezime"].ToString();
                textBoxJMBGVozaca.Text = citaj["JMBG"].ToString();
                textBoxBRTelVozaca.Text = citaj["BrojTelefona"].ToString();
                dateTimePickerVozaca.Text = citaj["DatumRodjenja"].ToString();
                String pol = citaj["Pol"].ToString();
                if (pol == "Musko")
                {
                    radioButtonMuskoVozac.Checked = true;
                }
                else if (pol == "Zensko")
                {
                    radioButtonZenskoVozac.Checked = true;
                }
                comboBoxKategorijaVozac.Text = citaj["Kategorija"].ToString();
                comboBoxGradVozaca.Text = citaj["Grad"].ToString();

                plata = citaj["Plata"].ToString();
                
                citaj.Close();
                popunjen = true;
            }
            catch (Exception err)
            {
                MessageBox.Show("Nije uspjelo citanje vozaca iz baze" + err);
            }
        }

        public void DodajVozaca()
        {
            if(textBoxImeVozaca.Text == "" || textBoxImeRoditeljaVozaca.Text == "" || textBoxPrezimeVozaca.Text == "")
            {
                MessageBox.Show("Potrebno je da popunite sva polja");
                return;
            }

            String upit = "INSERT INTO Vozac VALUES (@ImeParam, @imeRoditeljaParam, @prezimeParam, @jmbgParam, @brTelParam, @datumParam, @polParam, @kategorijaParam, @gradParam, @plataParam)";
            SqlCommand komanda = new SqlCommand();
            try
            {
                komanda.Connection = konekcija;
                komanda.CommandText = upit;
                
                komanda.Parameters.Add("ImeParam", SqlDbType.VarChar);
                komanda.Parameters.Add("imeRoditeljaParam", SqlDbType.VarChar);
                komanda.Parameters.Add("prezimeParam", SqlDbType.VarChar);
                komanda.Parameters.Add("jmbgParam", SqlDbType.VarChar);
                komanda.Parameters.Add("brTelParam", SqlDbType.VarChar);
                komanda.Parameters.Add("datumParam", SqlDbType.Date);
                komanda.Parameters.Add("polParam", SqlDbType.VarChar);
                komanda.Parameters.Add("kategorijaParam", SqlDbType.VarChar);
                komanda.Parameters.Add("gradParam", SqlDbType.VarChar);
                komanda.Parameters.Add("plataParam", SqlDbType.Float);

                komanda.Parameters["ImeParam"].Value = textBoxImeVozaca.Text;
                komanda.Parameters["imeRoditeljaParam"].Value = textBoxImeRoditeljaVozaca.Text;
                komanda.Parameters["prezimeParam"].Value = textBoxPrezimeVozaca.Text;
                String jmbg = textBoxJMBGVozaca.Text;
                if (jmbg.Length == 13)
                {
                    long broj;
                    bool provjera = Int64.TryParse(jmbg, out broj);
                    if (provjera == true)
                    {
                        komanda.Parameters["jmbgParam"].Value = jmbg;
                    }
                    else
                    {
                        MessageBox.Show("JMBG nije pravilan");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("JMBG nije pravilan");
                    return;
                }
                String brTel = textBoxBRTelVozaca.Text;
                if (brTel.Length >= 9)
                {
                    int broj;
                    bool provjera = Int32.TryParse(brTel, out broj);
                    if (provjera == true)
                    {
                        komanda.Parameters["brTelParam"].Value = brTel;
                    }
                    else
                    {
                        MessageBox.Show("Broj telefona nije pravilan");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Broj telefona nije pravilan");
                    return;
                }
                komanda.Parameters["datumParam"].Value = dateTimePickerVozaca.Value;
                String pol = "";
                if (radioButtonMuskoVozac.Checked)
                {
                    pol = "Musko";
                }
                else if (radioButtonZenskoVozac.Checked)
                {
                    pol = "Zensko";
                }
                else
                {
                    MessageBox.Show("Izaberite pol");
                    return;
                }
                komanda.Parameters["polParam"].Value = pol;
                if (comboBoxKategorijaVozac.SelectedIndex != -1)
                {
                    komanda.Parameters["kategorijaParam"].Value = comboBoxKategorijaVozac.SelectedItem;
                }
                else
                {
                    MessageBox.Show("Izaberite kategoriju za vozaca");
                    return;
                }
                if (comboBoxGradVozaca.SelectedIndex != -1)
                {
                    komanda.Parameters["gradParam"].Value = comboBoxGradVozaca.SelectedItem;
                }
                else
                {
                    MessageBox.Show("Izaberite grad za vozaca");
                    return;
                }
                komanda.Parameters["plataParam"].Value = 0;

                komanda.ExecuteNonQuery();

                UnosPlateFrm forma = new UnosPlateFrm(konekcija, "Vozac", jmbg,"0");
                forma.ShowDialog();
                MessageBox.Show("Vozaca ste uspjesno dodali u bazu");
                pomClass.ponistiVozaca(textBoxImeVozaca, textBoxPrezimeVozaca, textBoxImeRoditeljaVozaca, textBoxJMBGVozaca, textBoxBRTelVozaca, comboBoxGradVozaca, comboBoxKategorijaVozac, radioButtonMuskoVozac, radioButtonZenskoVozac, dateTimePickerVozaca);
            }
            catch (Exception err)
            {
                MessageBox.Show("Nije uspjelo upisivanje vozaca u bazu" + err);
            }
        }

        public void AzurirajVozaca()
        {
            if (textBoxImeVozaca.Text == "" || textBoxImeRoditeljaVozaca.Text == "" || textBoxPrezimeVozaca.Text == "")
            {
                MessageBox.Show("Potrebno je da popunite sva polja");
                return;
            }

            String upit = "UPDATE Vozac SET Ime=@ImeParam, ImeRoditelja=@imeRoditeljaParam, Prezime=@prezimeParam, JMBG=@jmbgParam, BrojTelefona=@brTelParam, DatumRodjenja=@datumParam, Pol=@polParam, Kategorija=@kategorijaParam, Grad=@gradParam, Plata=@plataParam WHERE JMBG=@jmbgParam";
            
            SqlCommand komanda = new SqlCommand();
            try
            {
                komanda.Connection = konekcija;
                komanda.CommandText = upit;
                
                komanda.Parameters.Add("ImeParam", SqlDbType.VarChar);
                komanda.Parameters.Add("imeRoditeljaParam", SqlDbType.VarChar);
                komanda.Parameters.Add("prezimeParam", SqlDbType.VarChar);
                komanda.Parameters.Add("jmbgParam", SqlDbType.VarChar);
                komanda.Parameters.Add("brTelParam", SqlDbType.VarChar);
                komanda.Parameters.Add("datumParam", SqlDbType.Date);
                komanda.Parameters.Add("polParam", SqlDbType.VarChar);
                komanda.Parameters.Add("kategorijaParam", SqlDbType.VarChar);
                komanda.Parameters.Add("gradParam", SqlDbType.VarChar);
                komanda.Parameters.Add("plataParam", SqlDbType.Float);

                komanda.Parameters["ImeParam"].Value = textBoxImeVozaca.Text;
                komanda.Parameters["imeRoditeljaParam"].Value = textBoxImeRoditeljaVozaca.Text;
                komanda.Parameters["prezimeParam"].Value = textBoxPrezimeVozaca.Text;
                String jmbg = textBoxJMBGVozaca.Text;
                if (jmbg.Length == 13)
                {
                    long broj;
                    bool provjera = Int64.TryParse(jmbg, out broj);
                    if (provjera == true)
                    {
                        komanda.Parameters["jmbgParam"].Value = jmbg;
                    }
                    else
                    {
                        MessageBox.Show("JMBG nije pravilan");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("JMBG nije pravilan");
                    return;
                }
                String brTel = textBoxBRTelVozaca.Text;
                if (brTel.Length >= 9)
                {
                    int broj;
                    bool provjera = Int32.TryParse(brTel, out broj);
                    if (provjera == true)
                    {
                        komanda.Parameters["brTelParam"].Value = brTel;
                    }
                    else
                    {
                        MessageBox.Show("Broj telefona nije pravilan");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Broj telefona nije pravilan");
                    return;
                }
                komanda.Parameters["datumParam"].Value = dateTimePickerVozaca.Value;
                String pol = "";
                if (radioButtonMuskoVozac.Checked)
                {
                    pol = "Musko";
                }
                else if (radioButtonZenskoVozac.Checked)
                {
                    pol = "Zensko";
                }
                else
                {
                    MessageBox.Show("Potrebno je da izaberete pol");
                }
                komanda.Parameters["polParam"].Value = pol;
                if (comboBoxKategorijaVozac.SelectedIndex != -1)
                {
                    komanda.Parameters["kategorijaParam"].Value = comboBoxKategorijaVozac.SelectedItem;
                }
                else
                {
                    MessageBox.Show("Izaberite kategoriju za vozaca");
                    return;
                }
                if (comboBoxGradVozaca.SelectedIndex != -1)
                {
                    komanda.Parameters["gradParam"].Value = comboBoxGradVozaca.SelectedItem;
                }
                else
                {
                    MessageBox.Show("Izaberite grad za vozaca");
                    return;
                }
                komanda.Parameters["plataParam"].Value = 0;

                komanda.ExecuteNonQuery();

                UnosPlateFrm forma = new UnosPlateFrm(konekcija, "Vozac", jmbg, plata);
                forma.ShowDialog();

                MessageBox.Show("Vozaca ste uspjesno azurirali u bazu");
                pomClass.ponistiVozaca(textBoxImeVozaca, textBoxPrezimeVozaca, textBoxImeRoditeljaVozaca, textBoxJMBGVozaca, textBoxBRTelVozaca, comboBoxGradVozaca, comboBoxKategorijaVozac, radioButtonMuskoVozac, radioButtonZenskoVozac, dateTimePickerVozaca);
                popunjen = false;
            }
            catch (Exception err)
            {
                MessageBox.Show("Nije uspjelo azuriranje vozaca u bazu" + err);
            }
        }
        #endregion

        #region METODE ZA DOKTORE
        public void IzbrisiDoktora()
        {
            if (dataGridViewTabelaDoktora.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Potrebno je da izaberete doktora");
                return;
            }
            String izbor = dataGridViewTabelaDoktora.SelectedRows[0].Cells["JMBG"].Value.ToString();
            String nalog = dataGridViewTabelaDoktora.SelectedRows[0].Cells["Nalog"].Value.ToString();

            //String upit1 = "UPDATE Doktor SET Radi=@radiParam WHERE JMBG=@jmbgParam";
            String upit1 = "UPDATE Doktor SET Radi=0 WHERE JMBG=@jmbgParam";
            //String upit2 = "UPDATE KorisnickiNalozi SET Radi=@radiNalogParam WHERE korisnickoIme=@korisnickoImeParam";
            String upit2 = "UPDATE KorisnickiNalozi SET Radi=0 WHERE korisnickoIme=@korisnickoImeParam";

            SqlCommand komanda = new SqlCommand();

            try
            {
                komanda.Connection = konekcija;
                komanda.CommandText = upit1;
                komanda.Parameters.Add("jmbgParam", SqlDbType.VarChar);
                //komanda.Parameters.Add("radiParam", SqlDbType.Int);
                komanda.Parameters["jmbgParam"].Value = izbor;
                //komanda.Parameters["radiParam"].Value = 0;

                komanda.ExecuteNonQuery();

                komanda.CommandText = upit2;
                komanda.Parameters.Add("korisnickoImeParam", SqlDbType.VarChar);
                //komanda.Parameters.Add("radiNalogParam", SqlDbType.Int);
                komanda.Parameters["korisnickoImeParam"].Value = nalog;
                //komanda.Parameters["radiNalogParam"].Value = 0;

                komanda.ExecuteNonQuery();

                pomClass.popuniGridView(dataGridViewTabelaDoktora, "Doktor", konekcija, koloneDoktora);

                MessageBox.Show("Uspjesno ste izbrisali doktora");
            }
            catch (Exception err)
            {
                MessageBox.Show("Nije uspjelo brisanje doktora" + err);
            }
        }

        public void DodajDoktora()
        {
            if(textBoxImeDoktora.Text == "" || textBoxImeRoditeljaDoktora.Text == "" || textBoxPrezimeDoktora.Text == "" || textBoxEMailDR.Text == "" || textBoxKorisnickoImeDoktora.Text == "" || textBoxSifraDoktora.Text == "")
            {
                MessageBox.Show("Potrebno je da popunite sva polja");
                return;
            }

            String jmbg = textBoxJMBGDoktora.Text;
            if (jmbg.Length == 13)
            {
                long broj;
                bool provjera = Int64.TryParse(jmbg, out broj);
                if (provjera == false)
                {
                    MessageBox.Show("JMBG nije pravilan");
                    return;
                }
            }
            else
            {
                MessageBox.Show("JMBG nije pravilan");
                return;
            }

            String brTel = textBoxBRTelDoktora.Text;
            if (brTel.Length >= 9)
            {
                int broj;
                bool provjera = Int32.TryParse(brTel, out broj);
                if (provjera == false)
                {
                    MessageBox.Show("Broj telefona nije pravilan");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Broj telefona nije pravilan");
                return;
            }

            String pol = "";
            if (radioButtonMuskoDR.Checked)
            {
                pol = "Musko";
            }
            else if (radioButtonZenskoDR.Checked)
            {
                pol = "Zensko";
            }
            else
            {
                MessageBox.Show("Potrebno je da izaberete pol");
                return;
            }

            if (comboBoxGradDoktor.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite grad za doktora");
                return;
            }
            if (comboBoxSpecijalizacija.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite specijalizaciju za doktora");
                return;
            }

            String upit1 = "INSERT INTO Doktor VALUES (@imeParam, @imeRoditeljaParam, @prezimeParam, @jmbgParam, @brTelParam, @datumParam, @polParam, @gradParam, @specijalizacijaParam, @nalogParam, @plataParam, @radiParam)";
            String upit2 = "INSERT INTO KorisnickiNalozi VALUES (@korisnickoImeParam, @emailParam, @sifraParam, @prioritetParam, @radiNalogParam)";

            SqlCommand komanda = new SqlCommand();
            try
            {
                komanda.Connection = konekcija;
                komanda.CommandText = upit2;

                komanda.Parameters.Add("korisnickoImeParam", SqlDbType.VarChar);
                komanda.Parameters.Add("emailParam", SqlDbType.VarChar);
                komanda.Parameters.Add("sifraParam", SqlDbType.VarChar);
                komanda.Parameters.Add("prioritetParam", SqlDbType.Int);
                komanda.Parameters.Add("radiNalogParam", SqlDbType.Int);

                komanda.Parameters["korisnickoImeParam"].Value = textBoxKorisnickoImeDoktora.Text;
                komanda.Parameters["emailParam"].Value = textBoxEMailDR.Text;
                komanda.Parameters["sifraParam"].Value = textBoxSifraDoktora.Text;
                komanda.Parameters["prioritetParam"].Value = 2;
                komanda.Parameters["radiNalogParam"].Value = 1;

                komanda.ExecuteNonQuery();
                
                komanda.CommandText = upit1;
                
                komanda.Parameters.Add("imeParam", SqlDbType.VarChar);
                komanda.Parameters.Add("imeRoditeljaParam", SqlDbType.VarChar);
                komanda.Parameters.Add("prezimeParam", SqlDbType.VarChar);
                komanda.Parameters.Add("jmbgParam", SqlDbType.VarChar);
                komanda.Parameters.Add("brTelParam", SqlDbType.VarChar);
                komanda.Parameters.Add("datumParam", SqlDbType.Date);
                komanda.Parameters.Add("polParam", SqlDbType.VarChar);
                komanda.Parameters.Add("gradParam", SqlDbType.VarChar);
                komanda.Parameters.Add("specijalizacijaParam", SqlDbType.VarChar);
                komanda.Parameters.Add("nalogParam", SqlDbType.VarChar);
                komanda.Parameters.Add("plataParam", SqlDbType.Float);
                komanda.Parameters.Add("radiParam", SqlDbType.Int);

                komanda.Parameters["imeParam"].Value = textBoxImeDoktora.Text;
                komanda.Parameters["imeRoditeljaParam"].Value = textBoxImeRoditeljaDoktora.Text;
                komanda.Parameters["prezimeParam"].Value = textBoxPrezimeDoktora.Text;

                komanda.Parameters["jmbgParam"].Value = jmbg;

                komanda.Parameters["brTelParam"].Value = brTel;
                
                komanda.Parameters["datumParam"].Value = dateTimePickerDoktora.Value;
                
                komanda.Parameters["polParam"].Value = pol;
                komanda.Parameters["gradParam"].Value = comboBoxGradDoktor.SelectedItem;
                komanda.Parameters["specijalizacijaParam"].Value = comboBoxSpecijalizacija.SelectedItem;
                
                komanda.Parameters["nalogParam"].Value = textBoxKorisnickoImeDoktora.Text;

                komanda.Parameters["plataParam"].Value = 0;

                komanda.Parameters["radiParam"].Value = 1;

                komanda.ExecuteNonQuery();

                UnosPlateFrm forma = new UnosPlateFrm(konekcija, "Doktor", jmbg,"0");
                forma.ShowDialog();
                MessageBox.Show("Uspjesno ste dodali doktora");
                pomClass.ponistiDoktora(textBoxImeDoktora, textBoxPrezimeDoktora, textBoxImeRoditeljaDoktora, textBoxJMBGDoktora, textBoxBRTelDoktora, textBoxKorisnickoImeDoktora, textBoxEMailDR, textBoxSifraDoktora, comboBoxGradDoktor, comboBoxSpecijalizacija, radioButtonMuskoDR, radioButtonZenskoDR, dateTimePickerDoktora);
                popunjen = false;
            }
            catch (Exception err)
            {
                String upit3 = "SELECT * FROM Doktor WHERE JMBG=@jmbgSParam";
                komanda.Connection = konekcija;
                komanda.CommandText = upit3;

                komanda.Parameters.Add("jmbgSParam", SqlDbType.VarChar);
                komanda.Parameters["jmbgSParam"].Value = jmbg;

                SqlDataReader citaj = komanda.ExecuteReader();
                int brojac = 0;
                String nalog = "";
                while (citaj.Read())
                {
                    if(citaj["Radi"].ToString() == "0")
                    {
                        brojac = 1;
                        nalog = citaj["Nalog"].ToString();
                    }
                }
                citaj.Close();
                if(brojac == 0)
                {
                    MessageBox.Show("Unosenje doktora nije uspjelo " + err);
                    return;
                }
                else
                {
                    String upit4 = "UPDATE Doktor SET Radi=@radiUPParam WHERE JMBG=@jmbgUPParam";
                    komanda.CommandText = upit4;

                    komanda.Parameters.Add("radiUPParam", SqlDbType.Int);
                    komanda.Parameters.Add("jmbgUPParam", SqlDbType.VarChar);

                    komanda.Parameters["jmbgUPParam"].Value = jmbg;
                    komanda.Parameters["radiUPParam"].Value = 1;

                    komanda.ExecuteNonQuery();

                    String upit5 = "UPDATE KorisnickiNalozi SET Radi=@radiNalogUPParam WHERE korisnickoIme=@korisnickoImeUPParam";

                    komanda.CommandText = upit5;

                    komanda.Parameters.Add("radiNalogUPParam", SqlDbType.Int);
                    komanda.Parameters.Add("korisnickoImeUPParam", SqlDbType.VarChar);

                    komanda.Parameters["korisnickoImeUPParam"].Value = nalog;
                    komanda.Parameters["radiNalogUPParam"].Value = 1;

                    komanda.ExecuteNonQuery();
                    MessageBox.Show("Uspjesno ste ponovo dodali doktora");
                    pomClass.ponistiDoktora(textBoxImeDoktora, textBoxPrezimeDoktora, textBoxImeRoditeljaDoktora, textBoxJMBGDoktora, textBoxBRTelDoktora, textBoxKorisnickoImeDoktora, textBoxEMailDR, textBoxSifraDoktora, comboBoxGradDoktor, comboBoxSpecijalizacija, radioButtonMuskoDR, radioButtonZenskoDR, dateTimePickerDoktora);
                }
            }
        }

        public void IzmjeniDoktora()
        {
            if(dataGridViewTabelaDoktora.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Potrebno je da izaberete doktora za izmjenu");
                return;
            }
            String izbor = dataGridViewTabelaDoktora.SelectedRows[0].Cells["JMBG"].Value.ToString();
            String nalog = dataGridViewTabelaDoktora.SelectedRows[0].Cells["Nalog"].Value.ToString();

            String upit = "SELECT * FROM Doktor WHERE JMBG=@jmbgParam";

            SqlCommand komanda = new SqlCommand();

            try
            {
                komanda.Connection = konekcija;
                komanda.CommandText = upit;

                komanda.Parameters.Add("jmbgParam", SqlDbType.VarChar);
                komanda.Parameters["jmbgParam"].Value = izbor;

                PanelFalse(panelDirektor, panelDodajDoktora);

                /*panelPrikaziDoktora.Visible = false;
                panelDodajDoktora.Visible = true;*/

                SqlDataReader citaj = komanda.ExecuteReader();
                citaj.Read();

                textBoxImeDoktora.Text = citaj["Ime"].ToString();
                textBoxImeRoditeljaDoktora.Text = citaj["ImeRoditelja"].ToString();
                textBoxPrezimeDoktora.Text = citaj["Prezime"].ToString();
                textBoxJMBGDoktora.Text = citaj["JMBG"].ToString();
                textBoxBRTelDoktora.Text = citaj["BrojTelefona"].ToString();
                dateTimePickerDoktora.Text = citaj["DatumRodjenja"].ToString();
                String pol = citaj["Pol"].ToString();
                if(pol == "Musko")
                {
                    radioButtonMuskoDR.Checked = true;
                }
                else
                {
                    radioButtonZenskoDR.Checked = true;
                }
                comboBoxGradDoktor.Text = citaj["Grad"].ToString();
                comboBoxSpecijalizacija.Text = citaj["Specijalizacija"].ToString();
                textBoxKorisnickoImeDoktora.Text = citaj["Nalog"].ToString();

                plata = citaj["Plata"].ToString();

                citaj.Close();
                String upit2 = "SELECT * FROM KorisnickiNalozi WHERE korisnickoIme=@nalogParam";

                komanda.CommandText = upit2;

                komanda.Parameters.Add("nalogParam", SqlDbType.VarChar);
                komanda.Parameters["nalogParam"].Value = nalog;

                SqlDataReader citaj2 = komanda.ExecuteReader();
                citaj2.Read();
                textBoxEMailDR.Text = citaj2["email"].ToString();
                textBoxSifraDoktora.Text = citaj2["sifra"].ToString();

                citaj2.Close();

                popunjen = true;
            }
            catch(Exception err)
            {
                MessageBox.Show("Nije uspjelo popunjavanje polja iz baze " + err);
            }
        }

        public void AzurirajDoktora()
        {
            if (textBoxImeDoktora.Text == "" || textBoxImeRoditeljaDoktora.Text == "" || textBoxPrezimeDoktora.Text == "" || textBoxEMailDR.Text == "" || textBoxKorisnickoImeDoktora.Text == "" || textBoxSifraDoktora.Text == "")
            {
                MessageBox.Show("Potrebno je da popunite sva polja");
                return;
            }

            String jmbg = textBoxJMBGDoktora.Text;
            if (jmbg.Length == 13)
            {
                long broj;
                bool provjera = Int64.TryParse(jmbg, out broj);
                if (provjera == false)
                {
                    MessageBox.Show("JMBG nije pravilan");
                    return;
                }
            }
            else
            {
                MessageBox.Show("JMBG nije pravilan");
                return;
            }

            String brTel = textBoxBRTelDoktora.Text;
            if (brTel.Length >= 9)
            {
                int broj;
                bool provjera = Int32.TryParse(brTel, out broj);
                if (provjera == false)
                {
                    MessageBox.Show("Broj telefona nije pravilan");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Broj telefona nije pravilan");
                return;
            }

            String pol = "";
            if (radioButtonMuskoDR.Checked)
            {
                pol = "Musko";
            }
            else if (radioButtonZenskoDR.Checked)
            {
                pol = "Zensko";
            }
            else
            {
                MessageBox.Show("Potrebno je da izaberete pol");
                return;
            }

            if (comboBoxGradDoktor.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite grad za doktora");
                return;
            }
            if (comboBoxSpecijalizacija.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite specijalizaciju za doktora");
                return;
            }

            String upit1 = "UPDATE Doktor SET Ime=@imeParam, ImeRoditelja=@imeRoditeljaParam, Prezime=@prezimeParam, JMBG=@jmbgParam, BrojTelefona=@brTelParam, DatumRodjenja=@datumParam, Pol=@polParam, Grad=@gradParam, Specijalizacija=@specijalizacijaParam, Nalog=@nalogParam, Plata=@plataParam, Radi=@radiParam WHERE JMBG=@jmbgParam";
            String upit2 = "UPDATE KorisnickiNalozi SET korisnickoIme=@korisnickoImeParam, email=@emailParam, sifra=@sifraParam, prioritet=@prioritetParam, Radi=@radiNalogParam WHERE korisnickoIme=@korisnickoImeParam";

            SqlCommand komanda = new SqlCommand();
            try
            {
                komanda.Connection = konekcija;
                komanda.CommandText = upit2;

                komanda.Parameters.Add("korisnickoImeParam", SqlDbType.VarChar);
                komanda.Parameters.Add("emailParam", SqlDbType.VarChar);
                komanda.Parameters.Add("sifraParam", SqlDbType.VarChar);
                komanda.Parameters.Add("prioritetParam", SqlDbType.Int);
                komanda.Parameters.Add("radiNalogParam", SqlDbType.Int);

                komanda.Parameters["korisnickoImeParam"].Value = textBoxKorisnickoImeDoktora.Text;
                komanda.Parameters["emailParam"].Value = textBoxEMailDR.Text;
                komanda.Parameters["sifraParam"].Value = textBoxSifraDoktora.Text;
                komanda.Parameters["prioritetParam"].Value = 2;
                komanda.Parameters["radiNalogParam"].Value = 1;

                komanda.ExecuteNonQuery();

                komanda.CommandText = upit1;
                
                komanda.Parameters.Add("imeParam", SqlDbType.VarChar);
                komanda.Parameters.Add("imeRoditeljaParam", SqlDbType.VarChar);
                komanda.Parameters.Add("prezimeParam", SqlDbType.VarChar);
                komanda.Parameters.Add("jmbgParam", SqlDbType.VarChar);
                komanda.Parameters.Add("brTelParam", SqlDbType.VarChar);
                komanda.Parameters.Add("datumParam", SqlDbType.Date);
                komanda.Parameters.Add("polParam", SqlDbType.VarChar);
                komanda.Parameters.Add("gradParam", SqlDbType.VarChar);
                komanda.Parameters.Add("specijalizacijaParam", SqlDbType.VarChar);
                komanda.Parameters.Add("nalogParam", SqlDbType.VarChar);
                komanda.Parameters.Add("plataParam", SqlDbType.Float);
                komanda.Parameters.Add("radiParam", SqlDbType.Int);

                komanda.Parameters["imeParam"].Value = textBoxImeDoktora.Text;
                komanda.Parameters["imeRoditeljaParam"].Value = textBoxImeRoditeljaDoktora.Text;
                komanda.Parameters["prezimeParam"].Value = textBoxPrezimeDoktora.Text;

                komanda.Parameters["jmbgParam"].Value = jmbg;

                komanda.Parameters["brTelParam"].Value = brTel;
                
                komanda.Parameters["datumParam"].Value = dateTimePickerDoktora.Value;

                komanda.Parameters["polParam"].Value = pol;
                komanda.Parameters["gradParam"].Value = comboBoxGradDoktor.SelectedItem;
                komanda.Parameters["specijalizacijaParam"].Value = comboBoxSpecijalizacija.SelectedItem;

                komanda.Parameters["nalogParam"].Value = textBoxKorisnickoImeDoktora.Text;

                komanda.Parameters["plataParam"].Value = 0;

                komanda.Parameters["radiParam"].Value = 1;

                komanda.ExecuteNonQuery();

                UnosPlateFrm forma = new UnosPlateFrm(konekcija, "Doktor", jmbg, plata);
                forma.ShowDialog();
                MessageBox.Show("Uspjesno ste azurirali doktora");
                pomClass.ponistiDoktora(textBoxImeDoktora, textBoxPrezimeDoktora, textBoxImeRoditeljaDoktora, textBoxJMBGDoktora, textBoxBRTelDoktora, textBoxKorisnickoImeDoktora, textBoxEMailDR, textBoxSifraDoktora, comboBoxGradDoktor, comboBoxSpecijalizacija, radioButtonMuskoDR, radioButtonZenskoDR, dateTimePickerDoktora);
                popunjen = false;
            }
            catch (Exception err)
            {
                MessageBox.Show("Azuriranje doktora nije uspjesno " + err);
            }
        }
        
        #endregion

        #region METODE ZA PACIJENTA
        public void DodajPacijenta()
        {
            if(textBoxImePacijenta.Text == "" || textBoxImeRoditeljaPacijenta.Text == "" || textBoxPrezimePacijenta.Text == "")
            {
                MessageBox.Show("Potrebno je da popunite sva polja");
                return;
            }
            String jmbg = textBoxJMBGPacijenta.Text;
            if (jmbg.Length == 13)
            {
                long broj;
                bool provjera = Int64.TryParse(jmbg, out broj);
                if (provjera == false)
                {
                    MessageBox.Show("JMBG nije pravilan");
                    return;
                }
            }
            else
            {
                MessageBox.Show("JMBG nije pravilan");
                return;
            }

            String brTel = textBoxBrojTelefonaPacijenta.Text;
            if (brTel.Length >= 9)
            {
                int broj;
                bool provjera = Int32.TryParse(brTel, out broj);
                if (provjera == false)
                {
                    MessageBox.Show("Broj telefona nije pravilan");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Broj telefona nije pravilan");
                return;
            }

            String pol = "";
            if (radioButtonMuskoPacijent.Checked)
            {
                pol = "Musko";
            }
            else if (radioButtonZenskoPacijent.Checked)
            {
                pol = "Zensko";
            }
            else
            {
                MessageBox.Show("Potrebno je da izaberete pol");
                return;
            }

            if (comboBoxGradPacijenta.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite grad za pacijenta");
                return;
            }
            if (comboBoxSobaPacijenta.SelectedIndex == -1)
            {
                MessageBox.Show("Ako pacijentu nije potrebna soba izaberite vrijednost 0 (nula)");
                return;
            }
            if(comboBoxIzabraniDoktor.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite doktora za pacijenta");
                return;
            }

            String upit = "INSERT INTO Pacijent VALUES (@imeParam, @imeRoditeljaParam, @prezimeParam, @jmbgParam, @datumParam, @polParam, @gradParam, @doktorParam, @sobaParam, @telefonParam)";

            SqlCommand komanda = new SqlCommand();
            try
            {
                komanda.Connection = konekcija;
                komanda.CommandText = upit;

                komanda.Parameters.Add("imeParam", SqlDbType.VarChar);
                komanda.Parameters.Add("imeRoditeljaParam", SqlDbType.VarChar);
                komanda.Parameters.Add("prezimeParam", SqlDbType.VarChar);
                komanda.Parameters.Add("jmbgParam", SqlDbType.VarChar);
                komanda.Parameters.Add("datumParam", SqlDbType.Date);
                komanda.Parameters.Add("polParam", SqlDbType.VarChar);
                komanda.Parameters.Add("gradParam", SqlDbType.VarChar);
                komanda.Parameters.Add("doktorParam", SqlDbType.VarChar);
                komanda.Parameters.Add("sobaParam", SqlDbType.Int);
                komanda.Parameters.Add("telefonParam", SqlDbType.VarChar);

                komanda.Parameters["imeParam"].Value = textBoxImePacijenta.Text;
                komanda.Parameters["imeRoditeljaParam"].Value = textBoxImeRoditeljaPacijenta.Text;
                komanda.Parameters["prezimeParam"].Value = textBoxPrezimePacijenta.Text;
                komanda.Parameters["jmbgParam"].Value = jmbg;
                komanda.Parameters["datumParam"].Value = dateTimePickerDatumPacijenta.Value;
                komanda.Parameters["polParam"].Value = pol;
                komanda.Parameters["gradParam"].Value = comboBoxGradPacijenta.SelectedItem;
                komanda.Parameters["doktorParam"].Value = (comboBoxIzabraniDoktor.SelectedItem as PomocnaKlasa2).kljuc;
                komanda.Parameters["sobaParam"].Value = comboBoxSobaPacijenta.SelectedItem;
                komanda.Parameters["telefonParam"].Value = textBoxBrojTelefonaPacijenta.Text;

                komanda.ExecuteNonQuery();

                MessageBox.Show("Uspješno se dodali novog pacijenta");
            }
            catch(Exception err)
            {
                MessageBox.Show("Čuvanje pacijenta nije uspjelo " + err);
                return;
            }



        }

        public void IzmjeniPacijenta()
        {
            if(dataGridViewTabelaPacijenata.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Potrebno je da izaberete pacijenta");
                return;
            }

            String jmbg = dataGridViewTabelaPacijenata.SelectedRows[0].Cells["JMBG"].Value.ToString();

            String upit = "SELECT * FROM Pacijent WHERE JMBG=@jmbgParam";

            SqlCommand komanda = new SqlCommand();
            try
            {
                komanda.Connection = konekcija;
                komanda.CommandText = upit;

                komanda.Parameters.Add("jmbgParam", SqlDbType.VarChar);
                komanda.Parameters["jmbgParam"].Value = jmbg;

                PanelFalse(panelMedicinskaSestra, panelDodajPacijenta);

                /*panelPrikaziPacijenta.Visible = false;
                panelDodajPacijenta.Visible = true;*/

                SqlDataReader citaj = komanda.ExecuteReader();

                citaj.Read();
                textBoxImePacijenta.Text = citaj["Ime"].ToString();
                textBoxImeRoditeljaPacijenta.Text = citaj["ImeRoditelja"].ToString();
                textBoxPrezimePacijenta.Text = citaj["Prezime"].ToString();
                textBoxJMBGPacijenta.Text = jmbg;
                textBoxBrojTelefonaPacijenta.Text = citaj["Telefon"].ToString();
                dateTimePickerDatumPacijenta.Text = citaj["Datum"].ToString();
                String pol = citaj["Pol"].ToString();
                if(pol == "Musko")
                {
                    radioButtonMuskoPacijent.Checked = true;
                }
                else
                {
                    radioButtonZenskoPacijent.Checked = true;
                }
                comboBoxGradPacijenta.Text = citaj["Grad"].ToString();
                comboBoxSobaPacijenta.Text = citaj["Soba"].ToString();

                String jmbgDR = citaj["IzabraniDoktor"].ToString();
                citaj.Close();

                String upit2 = "SELECT * FROM Doktor WHERE JMBG=@jmbgDrParam";
                komanda.CommandText = upit2;

                komanda.Parameters.Add("jmbgDrParam", SqlDbType.VarChar);
                komanda.Parameters["jmbgDrParam"].Value = jmbgDR;

                SqlDataReader citaj2 = komanda.ExecuteReader();
                citaj2.Read();
                String konacno = citaj2["Ime"].ToString() + " " + citaj2["Prezime"].ToString();
                comboBoxIzabraniDoktor.Text = konacno;
                citaj2.Close();

                popunjenPacijent = true;

            }
            catch(Exception err)
            {
                MessageBox.Show("Neuspjesno popunjavanje polja za pacijenta " + err);
                return;
            }
        }

        public void AzurirajPacijenta()
        {
            if (textBoxImePacijenta.Text == "" || textBoxImeRoditeljaPacijenta.Text == "" || textBoxPrezimePacijenta.Text == "")
            {
                MessageBox.Show("Potrebno je da popunite sva polja");
                return;
            }
            String jmbg = textBoxJMBGPacijenta.Text;
            if (jmbg.Length == 13)
            {
                long broj;
                bool provjera = Int64.TryParse(jmbg, out broj);
                if (provjera == false)
                {
                    MessageBox.Show("JMBG nije pravilan");
                    return;
                }
            }
            else
            {
                MessageBox.Show("JMBG nije pravilan");
                return;
            }

            String brTel = textBoxBrojTelefonaPacijenta.Text;
            if (brTel.Length >= 9)
            {
                int broj;
                bool provjera = Int32.TryParse(brTel, out broj);
                if (provjera == false)
                {
                    MessageBox.Show("Broj telefona nije pravilan");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Broj telefona nije pravilan");
                return;
            }

            String pol = "";
            if (radioButtonMuskoPacijent.Checked)
            {
                pol = "Musko";
            }
            else if (radioButtonZenskoPacijent.Checked)
            {
                pol = "Zensko";
            }
            else
            {
                MessageBox.Show("Potrebno je da izaberete pol");
                return;
            }

            if (comboBoxGradPacijenta.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite grad za pacijenta");
                return;
            }
            if (comboBoxSobaPacijenta.SelectedIndex == -1)
            {
                MessageBox.Show("Ako pacijentu nije potrebna soba izaberite vrijednost 0 (nula)");
                return;
            }
            if (comboBoxIzabraniDoktor.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite doktora za pacijenta");
                return;
            }
            String upit = "UPDATE Pacijent SET Ime=@imeParam, ImeRoditelja=@imeRoditeljaParam, Prezime=@prezimeParam, JMBG=@jmbgParam, Datum=@datumParam, Pol=@polParam, Grad=@gradParam, IzabraniDoktor=@doktorParam, Soba=@sobaParam, Telefon=@telefonParam WHERE JMBG=@jmbgParam";

            SqlCommand komanda = new SqlCommand();
            try
            {
                komanda.Connection = konekcija;
                komanda.CommandText = upit;

                komanda.Parameters.Add("imeParam", SqlDbType.VarChar);
                komanda.Parameters.Add("imeRoditeljaParam", SqlDbType.VarChar);
                komanda.Parameters.Add("prezimeParam", SqlDbType.VarChar);
                komanda.Parameters.Add("jmbgParam", SqlDbType.VarChar);
                komanda.Parameters.Add("datumParam", SqlDbType.Date);
                komanda.Parameters.Add("polParam", SqlDbType.VarChar);
                komanda.Parameters.Add("gradParam", SqlDbType.VarChar);
                komanda.Parameters.Add("doktorParam", SqlDbType.VarChar);
                komanda.Parameters.Add("sobaParam", SqlDbType.Int);
                komanda.Parameters.Add("telefonParam", SqlDbType.VarChar);

                komanda.Parameters["imeParam"].Value = textBoxImePacijenta.Text;
                komanda.Parameters["imeRoditeljaParam"].Value = textBoxImeRoditeljaPacijenta.Text;
                komanda.Parameters["prezimeParam"].Value = textBoxPrezimePacijenta.Text;
                komanda.Parameters["jmbgParam"].Value = jmbg;
                komanda.Parameters["datumParam"].Value = dateTimePickerDatumPacijenta.Value;
                komanda.Parameters["polParam"].Value = pol;
                komanda.Parameters["gradParam"].Value = comboBoxGradPacijenta.SelectedItem;
                komanda.Parameters["doktorParam"].Value = (comboBoxIzabraniDoktor.SelectedItem as PomocnaKlasa2).kljuc;
                komanda.Parameters["sobaParam"].Value = comboBoxSobaPacijenta.SelectedItem;
                komanda.Parameters["telefonParam"].Value = textBoxBrojTelefonaPacijenta.Text;

                komanda.ExecuteNonQuery();

                MessageBox.Show("Uspješno se azurirali novog pacijenta");

                popunjenPacijent = false;
            }
            catch (Exception err)
            {
                MessageBox.Show("Azuriranje pacijenta nije uspjelo " + err);
                return;
            }
        }
        #endregion

        #endregion

        #region PANEL MEDICINSKA SESTRA - POCETNI PANEL
        private void btnDodajPacijenta_Click(object sender, EventArgs e)
        {
            //PrikaziJedanPanel(panelDodajPacijenta,panelMedicinskaSestra);
            /*panelPrikaziPacijenta.Visible = false;
            panelDodajPacijenta.Visible = true;*/
            lblDodajPacijenta.Text = "Dodaj pacijenta";
            PanelFalse(panelMedicinskaSestra, panelDodajPacijenta);
        }

        

        private void brnPrikaziPacijenta_Click(object sender, EventArgs e)
        {
            panelPrikaziPacijenta.Width = 663;
            dataGridViewTabelaPacijenata.Width = 663;
            this.Width = 865;
            PanelFalse(panelMedicinskaSestra, panelPrikaziPacijenta);

            /*panelDodajPacijenta.Visible = false;
            panelPrikaziPacijenta.Visible = true;*/
        }

        private void btnZakaziPregled_Click(object sender, EventArgs e)
        {
            ZakazivanjePregledaFrm pregled = new ZakazivanjePregledaFrm(konekcija, "", true);
            pregled.ShowDialog();
        }

        private void btnPrikaziDanasnjePreglede_Click(object sender, EventArgs e)
        {
            //panelSpisakZakazanihPregleda.Visible = true;


            String trazeniJmbg = vratiJMBGDR();
            pomClass.prikaziPreglede(dataGridViewSpisakPregleda, "Pregled", "Pacijent", konekcija, kolonePregleda, trazeniJmbg);
            PanelFalse(panelMedicinskaSestra, panelSpisakZakazanihPregleda);
        }
        #endregion

        #region DODAJ PACIJENTA PANEL
        private void btnSacuvajPacijenta_Click(object sender, EventArgs e)
        {
            if(popunjenPacijent == true)
            {
                AzurirajPacijenta();
            }
            else
            {
                DodajPacijenta();
            }
        }

        private void btnOtkaziCuvanjePacijenta_Click(object sender, EventArgs e)
        {
            pomClass.ponistiPacijenta(textBoxImePacijenta, textBoxImeRoditeljaPacijenta, textBoxPrezimePacijenta, textBoxJMBGPacijenta, textBoxBrojTelefonaPacijenta, comboBoxGradPacijenta, comboBoxIzabraniDoktor, comboBoxSobaPacijenta, radioButtonMuskoPacijent, radioButtonZenskoPacijent, dateTimePickerDatumPacijenta);
            PanelFalse2(panelMedicinskaSestra);
            //panelDodajPacijenta.Visible = false;
        }

        private void btnPonistiPacijenta_Click(object sender, EventArgs e)
        {
            pomClass.ponistiPacijenta(textBoxImePacijenta, textBoxImeRoditeljaPacijenta, textBoxPrezimePacijenta, textBoxJMBGPacijenta, textBoxBrojTelefonaPacijenta, comboBoxGradPacijenta, comboBoxIzabraniDoktor, comboBoxSobaPacijenta, radioButtonMuskoPacijent, radioButtonZenskoPacijent, dateTimePickerDatumPacijenta);
        }
        #endregion

        #region PANEL ZA PRIKAZ PACIJENTA
        private void btnIzmjeniPacijenta_Click(object sender, EventArgs e)
        {
            IzmjeniPacijenta();
            lblDodajPacijenta.Text = "Izmjeni pacijenta";
        }

        private void btnDetaljanIzvjestajPacijent_Click(object sender, EventArgs e)
        {
            /*
             * napisati kod za izvjestaje o pacijentima
             * treba da bude izvjestaj sa osnovnim podacima
             * datumi pregleda
             * istorija bolesti
             */
            if(dataGridViewTabelaPacijenata.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Potrebno je da izaberete pacijenta");
                return;
            }
            String jmbg = dataGridViewTabelaPacijenata.SelectedRows[0].Cells["JMBG"].Value.ToString();
            IzvjestajOPacijentu forma = new IzvjestajOPacijentu(jmbg);
            forma.ShowDialog();
            
        }

        private void btnZakaziPregledIzbor_Click(object sender, EventArgs e)
        {
            if(dataGridViewTabelaPacijenata.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Potrebno je da izaberete pacijenta");
                return;
            }

            String jmbg = dataGridViewTabelaPacijenata.SelectedRows[0].Cells["JMBG"].Value.ToString();
            ZakazivanjePregledaFrm pregled = new ZakazivanjePregledaFrm(konekcija, jmbg, false);
            pregled.ShowDialog();
        }

        #endregion

        private void btnPregledPacijenta_Click(object sender, EventArgs e)
        {
            if (dataGridViewSpisakPacijenataDR.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Potrebno je da izaberete pacijenta");
                return;
            }
            String jmbg = dataGridViewSpisakPacijenataDR.SelectedRows[0].Cells["JMBG"].Value.ToString();
            PregledPacijentaFrm forma = new PregledPacijentaFrm(konekcija, jmbg);
            forma.ShowDialog();
            //kod koji update-uje kolonu za pregled tj setuje je na 0 - pregled obavljen
        }

        private void btnOsvjeziListu_Click(object sender, EventArgs e)
        {
            //dodati kod za popunjavanje liste
            /*String trazeniJmbg = vratiJMBGDR();
            pomClass.prikaziPreglede(dataGridViewSpisakPregleda, "Pregled", "Pacijent", konekcija, kolonePregleda, trazeniJmbg);*/
            String trazeniJMBG = vratiJMBG();
            pomClass.prikaziPreglede(dataGridViewSpisakPacijenataDR, "Pregled", "Pacijent", konekcija, kolonePregleda, trazeniJMBG);
        }

        #region POMOCNE METODE

        public void PanelFalse(Panel p1, Panel p2)
        {
            Panel[] np = NizPanela();
            for(int i=0; i<np.Length; i++)
            {
                if(np[i] != p1 && np[i] != p2)
                {
                    np[i].Visible = false;
                }
            }
            p2.Visible = true;
        }
        public void PanelFalse2(Panel p1)
        {
            Panel[] np = NizPanela();
            for (int i = 0; i < np.Length; i++)
            {
                if (np[i] != p1)
                {
                    np[i].Visible = false;
                }
            }
        }
        public void PanelFalse3()
        {
            Panel[] np = NizPanela();
            for (int i = 0; i < np.Length; i++)
            {
                np[i].Visible = false;
            }
        }

        public Panel[] NizPanela()
        {
            Panel[] niz =
            {
                panelMedicinskaSestra,panelDirektor,panelDoktor,panelSpisakZakazanihPregleda,panelPrikaziPacijenta,panelDodajPacijenta,
                panelPrikaziSvePacijente,panelDodajMS,panelPrikaziDoktora,panelPrikaziMS,panelPrikaziVozaca,panelDodajDoktora,
                panelDodajVozaca,panelSpisakPacijenataDR
            };
            return niz;
        }

        public String vratiJMBGDR()
        {
            String jmbg = "";
            String upit = "SELECT JMBGDoktora FROM MedicinskaSestra WHERE NALOG='" + lblNalog.Text + "'";
            SqlCommand komanda = new SqlCommand();
            try
            {
                komanda.CommandText = upit;
                komanda.Connection = konekcija;

                SqlDataReader citaj = komanda.ExecuteReader();
                citaj.Read();
                jmbg = citaj["JMBGDoktora"].ToString();
                citaj.Close();
                return jmbg;
            }
            catch(Exception err)
            {
                MessageBox.Show("Ne radi jmbg nesta " + err);
                return jmbg;
            }
        }

        public String vratiJMBG()
        {
            String jmbg = "";
            String upit = "SELECT JMBG FROM Doktor WHERE NALOG='" + lblNalogDoktora.Text + "'";
            SqlCommand komanda = new SqlCommand();
            try
            {
                komanda.CommandText = upit;
                komanda.Connection = konekcija;

                SqlDataReader citaj = komanda.ExecuteReader();
                citaj.Read();
                jmbg = citaj["JMBG"].ToString();
                citaj.Close();
                return jmbg;
            }
            catch (Exception err)
            {
                MessageBox.Show("Ne radi jmbg nesta " + err);
                return jmbg;
            }
        }

        public void popuniListeIGW()
        {
            pomClass.popuniPadajucuListu(comboBoxKategorijaVozac, "Kategorija", konekcija);
            pomClass.popuniPadajucuListu(comboBoxGradVozaca, "Grad", konekcija);
            pomClass.popuniPadajucuListu(comboBoxGradMS, "Grad", konekcija);
            pomClass.popuniPadajucuListu(comboBoxGradDoktor, "Grad", konekcija);
            pomClass.popuniPadajucuListu(comboBoxSpecijalizacijaMS, "Specijalizacija", konekcija);
            pomClass.popuniPadajucuListu(comboBoxSpecijalizacija, "Specijalizacija", konekcija);
            pomClass.popuniPadajucuListuMSDR(comboBoxIzaberiDoktora, "Doktor", konekcija);
            pomClass.popuniPadajucuListuMSDR(comboBoxIzabraniDoktor, "Doktor", konekcija); //padajuca lista za izbor izabranog doktora kod pacijenta
            pomClass.popuniPadajucuListu(comboBoxGradPacijenta, "Grad", konekcija);
            pomClass.popuniPadajucuListuSoba(comboBoxSobaPacijenta, "Soba", konekcija);
            pomClass.popuniGridView(dataGridViewSpisakPacijenataDR, "Pacijent", konekcija, kolonePacijent);
        }

        #endregion

        private void btnLogOutDR_Click(object sender, EventArgs e)
        {
            PanelFalse3();
            this.Width = 857;
        }

        private void btnLogOutMS_Click(object sender, EventArgs e)
        {
            PanelFalse3();
            this.Width = 857;
        }

        private void btnLogOutDirektor_Click(object sender, EventArgs e)
        {
            PanelFalse3();
            this.Width = 857;
        }

        private void dataGridViewTabelaVozac_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelDodajPacijenta_Paint(object sender, PaintEventArgs e)
        {

        }

        //dio za izvjestaje

        private void btnReportDR_Click(object sender, EventArgs e)
        {
            IzvjestajODR forma = new IzvjestajODR();
            forma.ShowDialog();
        }

        private void btnReportMS_Click(object sender, EventArgs e)
        {
            IzvjestajOMS forma = new IzvjestajOMS();
            forma.ShowDialog();
        }

        private void btnReportVozaca_Click(object sender, EventArgs e)
        {
            IzvjestajOVozacima forma = new IzvjestajOVozacima();
            forma.ShowDialog();
        }

        private void btnReportPacijenata_Click(object sender, EventArgs e)
        {
            IzvjestajOPacijentima forma = new IzvjestajOPacijentima();
            forma.ShowDialog();
        }

        private void btnReportVozac1_Click(object sender, EventArgs e)
        {
            if(dataGridViewTabelaVozac.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Potrebno je da izaberete vozača");
                return;
            }
            String jmbg = dataGridViewTabelaVozac.SelectedRows[0].Cells["JMBG"].Value.ToString();
            IzvjestajOJednomVozacu forma = new IzvjestajOJednomVozacu(jmbg);
            forma.ShowDialog();
        }

        private void btnReportDR1_Click(object sender, EventArgs e)
        {
            if(dataGridViewTabelaDoktora.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Potrebno je da izaberete doktora");
                return;
            }
            String jmbg = dataGridViewTabelaDoktora.SelectedRows[0].Cells["JMBG"].Value.ToString();
            IzvjestajOJednomDR forma = new IzvjestajOJednomDR(jmbg);
            forma.ShowDialog();
        }

        private void btnReportMS1_Click(object sender, EventArgs e)
        {
            if(dataGridViewTabelaMS.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Potrebno je da izaberete medicinsku sestru");
                return;
            }
            String jmbg = dataGridViewTabelaMS.SelectedRows[0].Cells["JMBG"].Value.ToString();
            IzvjestajOJednojMS forma = new IzvjestajOJednojMS(jmbg);
            forma.ShowDialog();
        }
    }
}
