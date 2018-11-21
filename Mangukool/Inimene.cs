using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mangukool
{
    class Inimene
    {
        public static List<Inimene> Inimesed = new List<Inimene>();

        public string Isikukood;
        public string Nimi;
        public string Klasskusopib;
        public string Ainemidaopetab;
        public string LapseIK;

        public Inimene(string isikukood, string nimi, string klasskusopib, string ainemidaopetab, string lapseIK)
        {
            Isikukood = isikukood;
            Nimi = nimi;
            Klasskusopib = klasskusopib;
            Ainemidaopetab = ainemidaopetab;
            LapseIK = lapseIK;
            Inimesed.Add(this);

        }
        
    }


}
