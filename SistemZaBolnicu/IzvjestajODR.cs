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
    public partial class IzvjestajODR : Form
    {
        public IzvjestajODR()
        {
            InitializeComponent();
        }

        private void IzvjestajODR_Load(object sender, EventArgs e)
        {
            CrystalReportSviDr crsd = new CrystalReportSviDr();
            crystalReportViewer1.ReportSource = crsd;
        }
    }
}
