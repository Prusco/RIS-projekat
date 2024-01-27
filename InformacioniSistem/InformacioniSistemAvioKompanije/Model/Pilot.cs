using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacioniSistemAvioKompanije.Model
{
    public class Pilot
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int godineIskustva {  get; set; }

        public Pilot()
        {

        }
    }
}
