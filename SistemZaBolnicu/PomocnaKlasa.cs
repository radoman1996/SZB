using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemZaBolnicu
{
    

    class PomocnaKlasa
    {

        public void ponistiVozaca(TextBox t1, TextBox t2, TextBox t3, TextBox t4, TextBox t5, ComboBox c1, ComboBox c2, RadioButton r1, RadioButton r2,DateTimePicker dtp)
        {
            t1.Text = "";
            t2.Text = "";
            t3.Text = "";
            t4.Text = "";
            t5.Text = "";
            c1.SelectedIndex = -1;
            c2.SelectedIndex = -1;
            r1.Checked = false;
            r2.Checked = false;
            dtp.ResetText();
        }
        public void ponistiMS(TextBox t1, TextBox t2, TextBox t3, TextBox t4, TextBox t5, TextBox t6, TextBox t7, TextBox t8, ComboBox c1, ComboBox c2, ComboBox c3, RadioButton r1, RadioButton r2, DateTimePicker dtp)
        {
            t1.Text = "";
            t2.Text = "";
            t3.Text = "";
            t4.Text = "";
            t5.Text = "";
            t6.Text = "";
            t7.Text = "";
            t8.Text = "";
            c1.SelectedIndex = -1;
            c2.SelectedIndex = -1;
            c3.SelectedIndex = -1;
            r1.Checked = false;
            r2.Checked = false;
            dtp.ResetText();
        }
        public void ponistiDoktora(TextBox t1, TextBox t2, TextBox t3, TextBox t4, TextBox t5, TextBox t6, TextBox t7, TextBox t8, ComboBox c1, ComboBox c2, RadioButton r1, RadioButton r2, DateTimePicker dtp)
        {
            t1.Text = "";
            t2.Text = "";
            t3.Text = "";
            t4.Text = "";
            t5.Text = "";
            t6.Text = "";
            t7.Text = "";
            t8.Text = "";
            c1.SelectedIndex = -1;
            c2.SelectedIndex = -1;
            r1.Checked = false;
            r2.Checked = false;
            dtp.ResetText();
        }
        public void ponistiPacijenta(TextBox t1, TextBox t2, TextBox t3, TextBox t4, TextBox t5, ComboBox c1, ComboBox c2, ComboBox c3, RadioButton r1, RadioButton r2, DateTimePicker dtp)
        {
            t1.Text = "";
            t2.Text = "";
            t3.Text = "";
            t4.Text = "";
            t5.Text = "";
            c1.SelectedIndex = -1;
            c2.SelectedIndex = -1;
            c3.SelectedIndex = -1;
            r1.Checked = false;
            r2.Checked = false;
            dtp.ResetText();
        }

        public void popuniPadajucuListu(ComboBox c, String tabela, SqlConnection con)
        {
            String upit = "SELECT * FROM " + tabela;
            SqlCommand komanda = new SqlCommand();
            try
            {
                komanda.Connection = con;
                komanda.CommandText = upit;

                SqlDataReader procitaj = komanda.ExecuteReader();
                while (procitaj.Read())
                {
                    c.Items.Add(procitaj["naziv"]);
                }
                procitaj.Close();
                //MessageBox.Show("Uspjesno citanje iz baze u listu");
            }
            catch(Exception err)
            {
                MessageBox.Show("Nije uspjesno popunjavanje liste" + err);
            }
        }

        public void popuniPadajucuListuMSDR(ComboBox c, String tabela, SqlConnection con)
        {
            String upit = "SELECT * FROM " + tabela;
            SqlCommand komanda = new SqlCommand();
            try
            {
                komanda.Connection = con;
                komanda.CommandText = upit;

                SqlDataReader procitaj = komanda.ExecuteReader();
                while (procitaj.Read())
                {
                    PomocnaKlasa2 dodaj = new PomocnaKlasa2(procitaj["JMBG"].ToString(),procitaj["Ime"].ToString(), procitaj["Prezime"].ToString());
                    c.Items.Add(dodaj);
                    //String ime = procitaj["Ime"].ToString();

                }
                procitaj.Close();
                //MessageBox.Show("Uspjesno citanje iz baze u listu");
            }
            catch (Exception err)
            {
                MessageBox.Show("Nije uspjesno popunjavanje liste" + err);
            }
        }

        public void popuniPadajucuListuSoba(ComboBox c, String tabela, SqlConnection con)
        {
            String upit = "SELECT * FROM " + tabela;
            SqlCommand komanda = new SqlCommand();
            try
            {
                komanda.Connection = con;
                komanda.CommandText = upit;

                SqlDataReader citaj = komanda.ExecuteReader();
                while (citaj.Read())
                {
                    c.Items.Add(citaj["Broj"]);
                }
                citaj.Close();
            }
            catch(Exception err)
            {
                MessageBox.Show("Nije uspjelo popunjavanje sobe");
            }
        }

        public void popuniGridView(DataGridView dgv, String tabela, SqlConnection con, String []nizKolona)
        {
            DataTable table = new DataTable();

            String upit = "SELECT ";
            for(int i=0; i<nizKolona.Length; i++)
            {
                upit = upit + nizKolona[i];
            }
            upit = upit + " FROM " + tabela;
            if(tabela == "Doktor" || tabela == "MedicinskaSestra")
            {
                upit = upit + " WHERE Radi=1";
            }
            Console.WriteLine(upit);
            SqlCommand komanda = new SqlCommand();
            try
            {
                

                komanda.CommandText = upit;
                komanda.Connection = con;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = komanda;
                adapter.Fill(table);

                dgv.DataSource = table;
            }
            catch(Exception err)
            {
                MessageBox.Show("Nisu prikazani podaci " + err);
            }

        }

        public void prikaziOdredjenePacijente(DataGridView dgv, String tabela, SqlConnection con, String []nizKolona, String jmbgDoktora)
        {
            Console.WriteLine("Prvi put " + jmbgDoktora);
            DataTable table = new DataTable();
            //upit="SELECT * FROM Pacijent WHERE IzabraniDoktor=jmbgDoktora"
            String upit = "SELECT ";
            for(int i=0; i<nizKolona.Length; i++)
            {
                upit += nizKolona[i];
            }
            upit += " FROM " + tabela + " WHERE IzabraniDoktor='" + jmbgDoktora + "'";
            SqlCommand komanda = new SqlCommand();
            try
            {
                komanda.Connection = con;
                komanda.CommandText = upit;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = komanda;
                adapter.Fill(table);

                dgv.DataSource = table;

                Console.WriteLine(jmbgDoktora);

            }
            catch(Exception err)
            {
                MessageBox.Show("Nije uspjelo popunjavanja posebnih pacijenata " + err);
            }
        }

        public void prikaziPreglede(DataGridView dgv, String tabela1, String tabela2, SqlConnection con, String []nizKolona, String jmbgDoktora)
        {
            DataTable table = new DataTable();

            String upit = "SELECT ";    
            for(int i=0; i<nizKolona.Length; i++)
            {
                upit += nizKolona[i];
            }
            upit += " FROM " + tabela1 + " as t1," + tabela2 + " as t2 WHERE (t1.jmbgPacijenta=t2.JMBG) and (IzabraniDoktor='" + jmbgDoktora + "') and zavrseno=1";
            Console.WriteLine("Upit je " + upit);
            SqlCommand komanda = new SqlCommand();
            try
            {
                komanda.Connection = con;
                komanda.CommandText = upit;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = komanda;
                adapter.Fill(table);
                dgv.DataSource = table;
            }
            catch(Exception err)
            {
                MessageBox.Show("Ne valja.. " + err);
            }
        }

        public void prikaziPreglede2(DataGridView dgv, String tabela1, String tabela2, SqlConnection con, String[] nizKolona, String jmbgDoktora)
        {
            DataTable table = new DataTable();

            String upit = "SELECT ";
            for (int i = 0; i < nizKolona.Length; i++)
            {
                upit += nizKolona[i];
            }
            upit += " FROM " + tabela1 + " as t1," + tabela2 + " as t2 WHERE (t1.jmbgPacijenta=t2.JMBG) and (IzabraniDoktor='" + jmbgDoktora + "') and zavrseno=1";

            SqlCommand komanda = new SqlCommand();
            try
            {
                komanda.Connection = con;
                komanda.CommandText = upit;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = komanda;
                adapter.Fill(table);
                dgv.DataSource = table;
            }
            catch (Exception err)
            {
                MessageBox.Show("Ne valja.. " + err);
            }
        }
    }
}