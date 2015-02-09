using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaToNSD
{
    [Serializable()]
    class Keyword
    {
        /// <summary>
        /// Konstruktor für ein Schlüsselwort, welches im Quelltext farbig markiert wird
        /// </summary>
        /// <param name="wort">Das Schlüssekwort, welches markiert werden soll</param>
        public Keyword(string wort)
        {
            this.wort = wort;
            this.foreColor = Color.CornflowerBlue;
        }
        /// <summary>
        /// Konstruktor für ein Schlüsselwort, welches im Quelltext mit der angegebenen Farbe markiert wird
        /// </summary>
        /// <param name="wort">Das Schlüssekwort, welches markiert werden soll</param>
        /// <param name="color">Die Farbe, die verwendet werden soll</param>
        public Keyword(string wort, Color color)
        {
            this.wort = wort;
            this.foreColor = color;
        }
        public Color foreColor { get; set; }
        public string wort { get; set; }
        public int lenght { get { return this.wort.Length; } }
    }
}
