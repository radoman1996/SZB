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
    public partial class IzvjestajOJednojMS : Form
    {
        string jmbg;
        public IzvjestajOJednojMS(string jmbgMS)
        {
            this.jmbg = jmbgMS;
            InitializeComponent();
        }

        private void IzvjestajOJednojMS_Load(object sender, EventArgs e)
        {
            CrystalReportOJednojMS crjms = new CrystalReportOJednojMS();
            crjms.SetParameterValue("jmbgMS", this.jmbg);
            crystalReportViewer1.ReportSource = crjms;
        }
    }
}
