﻿using System;
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
    public partial class IzvjestajOMS : Form
    {
        public IzvjestajOMS()
        {
            InitializeComponent();
        }

        private void IzvjestajOMS_Load(object sender, EventArgs e)
        {
            CrystalReportSveMS crsm = new CrystalReportSveMS();
            crystalReportViewer1.ReportSource = crsm;
        }
    }
}
