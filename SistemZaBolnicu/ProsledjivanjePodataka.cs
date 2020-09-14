using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemZaBolnicu
{
    class ProsledjivanjePodataka
    {
        private String jmbg = "";


        public ProsledjivanjePodataka(String vr)
        {
            this.jmbg = vr;
        }


        /*public String GetJMBG()
        {
            return this.jmbg;
        }
        public void SetJMBG(String jmbg2)
        {
            this.jmbg = jmbg2;
        }*/

        public String Jmbg
        {
            get { return jmbg; }
            set { this.jmbg = value; }
        }
    }
}
