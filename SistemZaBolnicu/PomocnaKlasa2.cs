using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemZaBolnicu
{

    class PomocnaKlasa2
    {
        public String kljuc; //jmbg
        String ime; //ime doktora
        String prezime; //prezime doktora
        String konacno;

        public PomocnaKlasa2(String k, String i, String p)
        {
            this.kljuc = k;
            this.ime = i;
            this.prezime = p;
            this.konacno = this.ime + " " +  this.prezime;
        }

        public override string ToString()
        {
            return this.konacno;
        }

    }
}
