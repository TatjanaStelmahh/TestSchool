using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mangukool
{
    class Klass
    {
        public static List<Klass> Klassid = new List<Klass>();

        public string Jark;
        public string KlassijuhatajaIK;
        public string[] Oppeained;
 
        public Klass(string jark, string klassijuhatajaIK, string[] oppeained)
        {
            Jark = jark;
            KlassijuhatajaIK = klassijuhatajaIK;
            Oppeained = oppeained;
            Klassid.Add(this);

        }

    }
}
