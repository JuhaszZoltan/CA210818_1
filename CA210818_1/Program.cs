using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA210818_1
{
    class Program
    {
        static List<Futo> futok = new List<Futo>();
        static void Main()
        {
            Beolvasas();
            Console.WriteLine($"3. feladat: Egyéni indulók: {futok.Count} fő");
            var cens = futok.Count(x => !x.Kategoria && x.Szazalek == 100);
            Console.WriteLine($"4. feladat: Célba érkező női sportolók: {cens} fő");
            Console.Write("5. feladat: Kérem a sportoló nevét: ");
            var nev = Console.ReadLine();
            var ker = futok.Where(x => x.Nev == nev).FirstOrDefault();
            Console.WriteLine($"\tIndult egyéniben a sportoló? {(ker != null ? "Igen" : "Nem")}");
            Console.WriteLine($"\tTeljesítette a teljes távot? {(ker != null && ker.Szazalek == 100 ? "Igen" : "Nem")}");
            var atlag = futok.Where(x => x.Kategoria && x.Szazalek == 100).Average(x => x.IdoOraban);
            Console.WriteLine($"7. feladat: Átlagos idő: {atlag} óra");
            Console.WriteLine("8. feladat: Verseny győztesei:");
            var ngy = futok
                .Where(x => !x.Kategoria && x.Szazalek == 100)
                .OrderBy(x => x.Eredmeny)
                .First();
            Console.WriteLine($"\tNők: {ngy.Nev} ({ngy.RajtSzam}.) - {ngy.Eredmeny}");
            var ffgy = futok
                .Where(x => x.Kategoria && x.Szazalek == 100)
                .OrderBy(x => x.Eredmeny)
                .First();
            Console.WriteLine($"\tFérfiak: {ffgy.Nev} ({ffgy.RajtSzam}.) - {ffgy.Eredmeny}");
            Console.ReadKey(true);
        }

        private static void Beolvasas()
        {
            using (var sr = new StreamReader(@"..\..\res\ub2017egyeni.txt", Encoding.UTF8))
            {
                sr.ReadLine();
                while (!sr.EndOfStream) futok.Add(new Futo(sr.ReadLine()));
            }
        }
    }
}
