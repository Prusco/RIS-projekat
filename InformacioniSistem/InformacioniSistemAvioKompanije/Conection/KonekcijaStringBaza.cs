using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacioniSistemAvioKompanije.Conection
{
    public class KonekcijaStringBaza
    {
        public static string GetConnectionString()
        {
            return "Server=localhost; Port=3306; Database=informacionisistemak; User Id=root; Password=root";
        }
    }
}
