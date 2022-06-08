using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Peter_utepeites
{
    internal class Program
    {
        struct Adat
        {
            public TimeSpan ido { get; set; }
            public int masodperc { get; set; }
            public string varos { get; set; }
            public Adat (string sor)
            {
                string[] db = sor.Split(' ');
                ido = TimeSpan.Parse(db[0] + ":" + db[1] + ":" + db[2]);
                masodperc = int.Parse(db[3]);
                varos = db[4];
            }

        }

        /*static List<Adat> lista = new List<Adat>();
        static void Beolvas()//Eljárás
        {
            foreach (var i in File.ReadAllLines("forgalom.txt").Skip(1))
            {
                lista.Add(new Adat(i));
            }
        }*/
        static void Main(string[] args)
        {
            /*Beolvas();
            Console.WriteLine("1.feladat: beolvas kész!");
            foreach(var i in lista.Take(10))
            {
                Console.WriteLine($"{i.ido} {i.masodperc} {i.varos}");
            }*/

            //1.feladat
            List<Adat> lista = new List<Adat>();
            foreach(var i in File.ReadAllLines("forgalom.txt").Skip(1))
            {
                lista.Add(new Adat(i));
            }
            Console.WriteLine("1.feladat: beolvas kész!");

            //2.feladat
            Console.WriteLine("\n2.feladat");
            Console.Write("Adja meg hogy hanyadik autót szeretné: ");
            int n=int.Parse(Console.ReadLine()) - 1;
            if (lista[n].varos == "F")
            {
                Console.WriteLine($"Az \"n\"-dik jármű Alsó város felé halad!");
            }
            else
            {
                Console.WriteLine($"Az \"n\"-dik jármű Felső város felé halad!");
            }

            //3.feladat
            Console.WriteLine("\n3.feladat");
            var kulonbseg = lista.Where(x => x.varos == "A").OrderByDescending(x => x.ido);
            /*foreach (var i in kulonbseg)
            {
                Console.WriteLine($"{i.ido} {i.masodperc} {i.varos}");
            }*/
            double kulonbozet = kulonbseg.First().ido.TotalSeconds - kulonbseg.ElementAt(1).ido.TotalSeconds;
            Console.WriteLine($"Két jármű {kulonbozet} másodperc különbséggel érte el az útszakasz kezdetét!");

            //4.feladat
            Console.WriteLine("\n4.feladat");
            //int elsoora = lista.First().ido.Hours;
            //int utolsoora = lista.Last().ido.Hours;
            Console.WriteLine("idő Alsó Felső");
            for (int i = lista.First().ido.Hours;i<=lista.Last().ido.Hours;i++)
            {
                int Also= 0,Felso = 0;
                for (int j = 0;j<lista.Count;j++)
                {
                    if (i == lista[j].ido.Hours)
                    {
                        if (lista[j].varos=="F") Felso++;
                        else Also++;
                    }
                }
                Console.WriteLine($"{i:5}óra {Also:5}db {Felso:5}db");
            }

            //5.feladat
            Console.WriteLine("\n4.feladat");
            var leggyorsabb = lista.OrderBy(x => x.masodperc);
            Console.ReadKey();
        }
    }
}
