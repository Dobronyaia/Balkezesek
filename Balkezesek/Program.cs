using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace balkezesek
{
    class Balkezesek
    {
        public Balkezesek(string sor)
        {
            string[] sorelemek = sor.Split(';');
            this.Nev = sorelemek[0];
            this.Elso = Convert.ToDateTime(sorelemek[1]);
            this.Utolso = Convert.ToDateTime(sorelemek[2]);
            this.Suly = Convert.ToInt32(sorelemek[3]);
            this.Magassag = Convert.ToInt32(sorelemek[4]);
        }

        public string Nev { get; set; }
        public DateTime Elso { get; set; }
        public DateTime Utolso { get; set; }
        public int Suly { get; set; }
        public int Magassag { get; set; }
    }
    class Program
    {
        public static List<Balkezesek> adatok = new List<Balkezesek>();
        static void Main(string[] args)
        {
            StreamReader olvas = new StreamReader("balkezesek.csv", Encoding.UTF8);
            string fejlec = olvas.ReadLine();
            while (!olvas.EndOfStream)
            {
                adatok.Add(new Balkezesek(olvas.ReadLine()));
            }
            int i, j;
            int adatokszama = adatok.Count;

            Console.WriteLine("3. feladat: {0}", adatokszama);

            Console.WriteLine("4. feladat:");
            for (i = 0; i < adatokszama; i++)
                if (adatok[i].Utolso.Year == 1999 && adatok[i].Utolso.Month == 10)
                    Console.WriteLine("\t{0}, {1} cm",
                   adatok[i].Nev, Math.Round(adatok[i].Magassag * 2.54, 1));

            Console.WriteLine("5.feladat:");
            Console.Write("Kérek egy 1990 és 1999 közötti évszámot!: ");
            int evszam = Convert.ToInt32(Console.ReadLine());
            while (!(evszam >= 1990 && evszam <= 1999))
            {
                Console.Write("Hibás adat, kérek egy 1990 és 1999 közötti évszámot!:");
               
                evszam = Convert.ToInt32(Console.ReadLine());

                double atlagsuly = 0;
                int db = 0;

                for (i = 0; i < adatokszama; i++)
                    if (evszam >= adatok[i].Elso.Year && evszam <= adatok[i].Utolso.Year)
                    {
                        atlagsuly += adatok[i].Suly;
                        db++;
                    }
                Console.WriteLine("6. feladat: {0} font", Math.Round(atlagsuly / db, 2));

                Console.ReadKey();
            }

        }
    }
}