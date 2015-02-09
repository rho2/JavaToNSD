using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JavaToNSD;
using System.Runtime.Serialization.Formatters.Binary;

namespace JavaToNSD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Liste, zur Abspeicherung alles Schlüsselwörter
        List<Keyword> _wortListe;
        private void Form1_Load(object sender, EventArgs e)
        {
            loadWortListe();//aktualisiert die Liste an Schlüsselwörtern
        }
        //array für XML code zu speicherung eines Strukogramms
        string[] xmlSchema = new string[] { "<?xml version=\"1.0\" encoding=\"UTF-8\"?> \n <root text=\"Programm\" comment=\"\" color=\"ffffff\" type=\"program\" style=\"nice\">\n<children>\n",
                                            "\n</children>\n</root>",
                                            "\n<instruction text=\"",
                                            "\" comment=\"\" color=\"ffffff\" rotated=\"0\"></instruction>",
                                            "<alternative text=\"",
                                            "\" comment=\"\" color=\"ffffff\">\n<qTrue>\n</qTrue>\n<qFalse>\n</qFalse></alternative>"
                                           };
       
        


        private void optionenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //zeigt das Einstellungsfenster an
            Form Einstellungen = new formEinstellungen();
            Einstellungen.ShowDialog();
            //aktualisiert die Liste an Schlüsselwörtern
            loadWortListe();
        }
        private void anpassenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //zeigt das Anpassungsfenster an
            Form Anpassen = new Anpassen();
            Anpassen.ShowDialog();
        }


        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //setzt alles zuück
            rtbIN.Clear();
            rtbOut.Clear();
            lbIn.Items.Clear();
            tvOut.Nodes.Clear();
        }
        private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbIN.Clear();
            rtbOut.Clear();
            lbIn.Items.Clear();
            tvOut.Nodes.Clear();

            //Variable zum Speichern der Art der letzten Anweisung
            byte type = 0;

            //öffnet einen Dialog, in dem die zu öffnende Datei ausgewählt werden kann
            openFileDialog1.ShowDialog();

            //liest alle Zeilen aus der Quell-Code-Datei
            String[] zeilen = File.ReadAllLines(openFileDialog1.FileName,Encoding.UTF8);

            //setzt die Zeilen aus der Quelldatei in die Rich-Text-Box
            rtbIN.Lines = zeilen;

            //markiert alle schlüsselwörter
            ColorizeKeywords(rtbIN);

            //färbt Kommentare grün
            #region
            foreach (string s in rtbIN.Lines)
            {
                if (s.Contains("//") || s.Contains("/*") || s.Contains("*/"))
                {
                    int wortstart = rtbIN.Text.IndexOf(s, StringComparison.Ordinal);
                    rtbIN.Select(wortstart, s.Length);
                    rtbIN.SelectionColor = Color.DarkGreen;

                    rtbIN.Select(wortstart + s.Length, 0);
                    rtbIN.SelectionColor = Color.Black;
                }

            }
            #endregion

            //string, in dem der komplette xml code gespeichert wird
            string xml = xmlSchema[0];

            //geht alle zeilen der eingeladenen datei durch
            for (int i = 0; i < zeilen.Length; i++)
            {
                //entfernt vorangestellte und nachgestellte Leerzeichn
                zeilen[i] = zeilen[i].Trim();

                //falls die zeile unnötig ist wird sie entfernt
                if (zeilen[i].StartsWith(@"/") ||
                    zeilen[i].StartsWith(@"*") ||
                    zeilen[i].StartsWith(@"import") ||
                    zeilen[i].StartsWith(@"{") ||
                    zeilen[i].StartsWith(@"}"))
                {
                    zeilen[i] = "";
                }

                //wird nur ausgeführt, wenn die Zeile etwas enthält
                if (zeilen[i] != "")
                {
                    //macht alles schön bunt
                    Color col;
                    if (zeilen[i].StartsWith("if"))
                    {
                        col = Farben.Default.ifc;
                        type = 1;
                        xml += xmlSchema[4] + zeilen[i].Replace("\"", "") + xmlSchema[5];
                    }

                    else if (zeilen[i].StartsWith("switch"))
                    {
                        col = Farben.Default.casec;
                        type = 2;
                    }

                    else if (zeilen[i].StartsWith("for"))
                    {
                        col = Farben.Default.forc;
                        type = 3;
                    }

                    else if (zeilen[i].StartsWith("while"))
                    {
                        col = Farben.Default.whilec;
                        type = 4;
                    }

                    else
                    {
                        col = Farben.Default.anweisung;
                        type = 0;
                        xml += xmlSchema[2] + zeilen[i].Replace("\"", "").Replace("=", @"&#60;-") + xmlSchema[3];
                    }

                     //fügt zum ListView hinzu
                    lbIn.Items.Add(zeilen[i]).BackColor = col;

                    //fügt zum treeView hinzu
                    tvOut.Nodes.Add(zeilen[i]);
                    
                }

            }
            //legt den xml code in die Rich-Text-Box
            rtbOut.Text = xml;
            

            
        }
        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //öffnet einen Dialog zur Speicherung des STGs
            saveFileDialog1.ShowDialog();

            //schreibt das STG in die vorher ausgewählte Datei
            File.WriteAllText(saveFileDialog1.FileName, rtbOut.Text);
        }
        private void druckenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //drucken noch nicht implemntiert
        }
        private void seitenansichtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //auch noch nicht implementiert
        }
        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //schließt die Anwendung
            this.Close();
        }

        private void rückgängigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Rückgängig
            if (rtbIN.Focused)
            {
                rtbIN.Undo();
            }

            if (rtbOut.Focused)
            {
                rtbOut.Undo();
            }
            
        }
        private void wiederholenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Wiederhohlen
            if (rtbIN.Focused)
            {
                rtbIN.Redo();
            }
            if (rtbOut.Focused)
            {
                rtbOut.Redo();
            }
            
        }
        private void ausschneidenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Ausschneiden
            if (rtbIN.Focused)
            {
                rtbIN.Cut();
            }

            if (rtbOut.Focused)
            {
                rtbOut.Cut();
            }
        }
        private void kopierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Kopieren
            if (rtbIN.Focused)
            {
                rtbIN.Copy();
            }

            if (rtbOut.Focused)
            {
                rtbOut.Copy();
            }
        }
        private void einfügenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Einfügen
            if (rtbIN.Focused)
            {
                rtbIN.Paste();
            }

            if (rtbOut.Focused)
            {
                rtbOut.Paste();
            }
        }
        private void alleauswählenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Alles auswählen
            if (rtbIN.Focused)
            {
                rtbIN.SelectAll();
            }

            if (rtbOut.Focused)
            {
                rtbOut.SelectAll();
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //zeigt die Info-Box an
            Form about = new AboutBox1();

            about.ShowDialog();
        }
        private void suchenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void indexToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void inhaltToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void ColorizeKeywords(RichTextBox textbox)
        {
            //legt die Anfangsposition der Auswahl fest
            int selStart = textbox.SelectionStart;

            //legt die Farbe für die Auswahl fest
            Color selColor = textbox.SelectionColor;

            try
            {
                //geht alle Schlüssekwörter einzeln durch
                foreach (Keyword k in this._wortListe)
                {
                    int wortStartIndex = textbox.Text.IndexOf(k.wort, StringComparison.Ordinal);

                    while (wortStartIndex >= 0)
                    {
                        //wählt das derzeitige Schlüssekwort aus und färbt es
                        textbox.Select(wortStartIndex, k.lenght);
                        textbox.SelectionColor = k.foreColor;

                        //wählt das Zeichen nach dem Schlüsselwort aus
                        textbox.Select(wortStartIndex + k.lenght, 0);

                        //setzt die Farbe wieder auf schawrz
                        textbox.SelectionColor = Color.Black;

                        //verschiebt die Anfangspostion der Auswahl hinter das Wort
                        wortStartIndex = textbox.Text.IndexOf(k.wort, wortStartIndex + k.lenght, StringComparison.Ordinal);
                            
                    }
                }
            }
            catch (Exception)
            {
            }

        }

        private void loadWortListe()
        {
            //öffnet die Datei mit den Schhlüsselwörtern
            FileStream fs = new FileStream(@"keywords.syn", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                //versuch die Schlüsselwörter auszulesen und abzuspeichern
                _wortListe = (List<Keyword>)formatter.Deserialize(fs);
            }
            catch (Exception)
            {
                //falls das fehlschlägt wird eine Leere Liste verwendet
                _wortListe = new List<Keyword>();
            }
            //schließt die Datei wieder
            fs.Close();
        }

        
    }
}
