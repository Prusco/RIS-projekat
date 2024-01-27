using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacioniSistemAvioKompanije.Model
{
    public class Aerodrom
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Grad {  get; set; }
        public int idDrzave {  get; set; }
        public Aerodrom() { }   
    }
}
