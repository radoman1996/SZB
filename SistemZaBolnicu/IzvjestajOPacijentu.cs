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
    public partial class IzvjestajOPacijentu : Form
    {
        string jmbg;
        public IzvjestajOPacijentu(string jmbgPacijenta)
        {
            this.jmbg = jmbgPacijenta;
            InitializeComponent();
        }

        private void IzvjestajOPacijentu_Load(object sender, EventArgs e)
        {
            CrystalReportDetaljiOPacijentu crdp = new CrystalReportDetaljiOPacijentu();
            crdp.SetParameterValue("jmbgPacijenta", this.jmbg);
            crystalReportViewer1.ReportSource = crdp;
        }
    }
}
