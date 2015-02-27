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
        public Uebersetzung(byte anzahl, string pattern, string start, List<string> texte, List<string> variablen)
        {
            this.pattern = pattern;
            this.start = start;
            this.texte = texte;
            this.variablen = variablen;
            this.anzahlVariablen = anzahl;
        }
        public string start;
        public string pattern;
        public byte anzahlVariablen;
        public List<string> texte;
        public List<string> variablen;
    }
}
