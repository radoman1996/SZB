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
    public partial class IzvjestajOVozacima : Form
    {
        public IzvjestajOVozacima()
        {
            InitializeComponent();
        }

        private void IzvjestajOVozacima_Load(object sender, EventArgs e)
        {
            CrystalReportSveOVozacima crsv = new CrystalReportSveOVozacima();
            crystalReportViewer1.ReportSource = crsv;
        }
    }
}
