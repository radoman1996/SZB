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
    public partial class IzvjestajOPacijentima : Form
    {
        public IzvjestajOPacijentima()
        {
            InitializeComponent();
        }

        private void IzvjestajOPacijentima_Load(object sender, EventArgs e)
        {
            CrystalReportSveOPacijentima crsp = new CrystalReportSveOPacijentima();
            crystalReportViewer1.ReportSource = crsp;
        }
    }
}
