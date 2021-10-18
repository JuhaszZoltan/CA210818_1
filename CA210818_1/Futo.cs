using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA210818_1
{
    class Futo
    {
        public string Nev { get; set; }
        public int RajtSzam { get; set; }
        public bool Kategoria { get; set; }
        public TimeSpan Eredmeny { get; set; }
        public int Szazalek { get; set; }
        public double IdoOraban => Eredmeny.TotalHours;

        public Futo(string r)
        {
            var t = r.Split(';');
            Nev = t[0];
            RajtSzam = int.Parse(t[1]);
            Kategoria = t[2] == "Ferfi";
            var ts = t[3].Split(':');
            Eredmeny = new TimeSpan(
                int.Parse(ts[0]),
                int.Parse(ts[1]),
                int.Parse(ts[2]));
            Szazalek = int.Parse(t[4]);
        }
    }
}
