using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemZaBolnicu
{
    class KlasaZaPozive
    {
        private String vrijednost = "";
        public KlasaZaPozive()
        {
            ProsledjivanjePodataka pp = new ProsledjivanjePodataka(vrijednost);
            this.vrijednost = pp.Jmbg;
        }

        public String Vrijednost
        {
            get
            {
                return this.vrijednost;
            }
            set
            {
                this.vrijednost = value;
            }
        }
    }
}
