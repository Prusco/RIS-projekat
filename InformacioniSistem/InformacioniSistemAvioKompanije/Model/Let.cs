using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacioniSistemAvioKompanije.Model
{
    public class Let
    {
        public int IDLeta { get; set; }
        public Pilot PilotLeta { get; set; }
        public List<Stjuardese> StjuardeseLeta { get; set; }
        public Aerodrom AerodromPolaska { get; set; }
        public Aerodrom AerodromDolaska { get; set; }

        public string ImeLeta
        {
            get
            {
                // Check if AerodromPolaska and AerodromDolaska are not null before concatenating
                if (AerodromPolaska != null && AerodromDolaska != null)
                {
                    return $"{AerodromPolaska.Ime}---{AerodromDolaska.Ime}";
                }
                else
                {
                    // Handle the case when either AerodromPolaska or AerodromDolaska is null
                    return "N/A";
                }
            }
            /// <summary>
            /// Ovo je trebala da bude funcija za Dohvati duzinu Leta izmedju Polaznog Aerodroma i Dolaznog Aerodroma medutim nisma imao vremana da implemntiram jer za ovo je potrebno (langituta i longituda) tj lokacije oba Aerodroma
            /// </summary>
            ///   public static DateTime DohvatiDuzinuLeta
            ///   {
            ///       get
            ///       {
            ///
            ///       }
            ///}
        }
    }
}
