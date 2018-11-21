using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mangukool
{
    class Hinne
    {
        public static List<Hinne> Hinded = new List<Hinne>();

        public string Hindenumber;
        public string Hindesaaja;
        public string Hindepanija;
        public string Misaines;

        public Hinne(string hindenumber, string hindesaaja, string hindepanija, string misaine)
        {
            Hindenumber = hindenumber;
            Hindesaaja = hindesaaja;
            Hindepanija = hindepanija;
            Misaines = misaine;
            Hinded.Add(this);

        }




    }
}
