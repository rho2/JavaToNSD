using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaToNSD
{
    [Serializable()]
    public class Uebersetzung
    {
        public Uebersetzung()
        {

        }
        public Uebersetzung(string java, string vorA, string zwischenAundB, string nachB)
        {
            this.java = java;
            this.vorA = vorA;
            this.zwischenAB = zwischenAundB;
            this.nachB = nachB;
        }
        public Uebersetzung(string java, string vorA)
        {
            this.java = java;
            this.vorA = vorA;
            this.zwischenAB = "";
            this.nachB = "";
        }
        public string java;
        public string vorA;
        public string zwischenAB;
        public string nachB;
    }
}
