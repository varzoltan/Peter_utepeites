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
        static void Main(string[] args)
        {
            List<Adat> lista = new List<Adat>();
            foreach(var i in File.ReadAllLines("forgalom.txt").Skip(1))
            {
                lista.Add(new Adat(i));
            }

            Console.ReadKey();
        }
    }
}
