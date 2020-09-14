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
    public partial class IzborZaposlenogFrm : Form
    {
        //SqlConnection konekcija;
        Panel panel1, panel2, panel3;
        public IzborZaposlenogFrm(Panel p1, Panel p2, Panel p3)
        {
            //this.konekcija = conn;
            //this.panel = p;
            this.panel1 = p1;
            this.panel2 = p2;
            this.panel3 = p3;
            InitializeComponent();
        }

        private void btnIzborIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIzborDoktor_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel1.Visible = true;
            this.Close();
        }

        private void btnIzborMedSestra_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Visible = false;
            panel2.Visible = true;
            this.Close();
        }

        private void btnIzborVozac_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            this.Close();
        }
    }
}
