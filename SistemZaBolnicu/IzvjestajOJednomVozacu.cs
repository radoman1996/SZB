using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemZaBolnicu
{
    public partial class IzvjestajOJednomVozacu : Form
    {
        string jmbg;
        public IzvjestajOJednomVozacu(string jmbgVozaca)
        {
            this.jmbg = jmbgVozaca;
            InitializeComponent();
        }

        private void IzvjestajOJednomVozacu_Load(object sender, EventArgs e)
        {
            CrystalReportOJednomVozacu crjv = new CrystalReportOJednomVozacu();
            crjv.SetParameterValue("jmbgVozaca", this.jmbg);
            crystalReportViewer1.ReportSource = crjv;
        }
    }
}
