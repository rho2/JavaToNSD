﻿using System;
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
using JavaToNSD.Properties;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace JavaToNSD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            if (File.Exists(Application.StartupPath + @"\keywords.dat"))
            {
                
            }
            else
            {
                using (FileStream f = File.Create(Application.StartupPath + @"\keywords.dat"))
                {
                    
                } 
            }
            if (File.Exists(Application.StartupPath + @"\uebersetzungen.dat"))
            {

            }
            else
            {
                using (FileStream f = File.Create(Application.StartupPath + @"\uebersetzungen.dat"))
                {
                    
                }
                
            }
            InitializeComponent();
            this.rtbIN.AllowDrop = true;
            this.rtbIN.DragEnter += rtbIN_DragEnter;
            this.rtbIN.DragDrop += rtbIN_DragDrop;       
        }
        
       

        void rtbIN_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] path = (string[])e.Data.GetData(DataFormats.FileDrop);
                openFile(path[0]);       
            }
        }

        void rtbIN_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        //Liste, zur Abspeicherung alles Schlüsselwörter
        List<Keyword> _wortListe;
        List<Uebersetzung> _uebersetungen;
        #region Array mit dem ABC
        string[] abc = new string[] 
        { 
            "Q", "W", "E", "R", "T", "Z", "U", "I", "O", "P", "A", "S", "D", "F", "G", "H", "J", "K", "L", "Y", "X", "C", "V", "B", "N", "M",
            "q", "w", "e", "r", "t", "z", "u", "i", "o", "p", "a", "s", "d", "f", "g", "h", "j", "k", "l", "y", "x", "c", "v", "b", "n", "m"
        };
        #endregion
        #region Deklerationen für AutoComplete
        bool listShowAC1 = false;
        bool listShownAC1 = false;
        string keyword1 = "";

        int countAC1;

        bool listShowAC2 = false;
        bool listShownAC2 = false;
        string keyword2 = "";

        int countAC2;
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            loadWortListe();//aktualisiert die Liste an Schlüsselwörtern
            loadUebersetzungen();
        }
 
        private void optionenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //zeigt das Einstellungsfenster an
            Form Einstellungen = new formEinstellungen();
            Einstellungen.ShowDialog();
            //aktualisiert die Liste an Schlüsselwörtern
            loadWortListe();
            loadUebersetzungen();
        }
        private void anpassenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //zeigt das Anpassungsfenster an
            Form Anpassen = new Anpassen();
            Anpassen.ShowDialog();

            rtbIN.Font = Settings.Default.FontCodeEditor;
            rtbOut.Font = Settings.Default.FontXMLEditor;
            lbIn.Font = Settings.Default.FontListView;
            tvOut.Font = Settings.Default.FontTreeView;
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

            //öffnet einen Dialog, in dem die zu öffnende Datei ausgewählt werden kann
            openFileDialog1.ShowDialog();

            openFile(openFileDialog1.FileName);

        }
        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //öffnet einen Dialog zur Speicherung des STGs
            saveFileDialog1.ShowDialog();
            //schreibt das STG in die vorher ausgewählte Datei
            try
            {
                File.WriteAllText(saveFileDialog1.FileName, rtbOut.Text);
            }
            catch (Exception)
            {

            }
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
            if (rtbIN.Focused)
            {
                
            }
            if (rtbOut.Focused)
            {
                
            }
        }
        private void indexToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void inhaltToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //öffnet den Link mit dem Standart-Browser
            System.Diagnostics.Process.Start("https://javansd.codeplex.com/discussions");
        }

        public void ColorizeKeywords()
        {
            //legt die Anfangsposition der Auswahl fest
            int selStart = rtbIN.SelectionStart;

            //legt die Farbe für die Auswahl fest
            Color selColor = rtbIN.SelectionColor;

            try
            {
                //geht alle Schlüssekwörter einzeln durch
                foreach (Keyword k in this._wortListe)
                {
                    int wortStartIndex = rtbIN.Text.IndexOf(k.wort, StringComparison.Ordinal);

                    while (wortStartIndex >= 0)
                    {
                        //wählt das derzeitige Schlüssekwort aus und färbt es
                        rtbIN.Select(wortStartIndex, k.lenght);
                        rtbIN.SelectionColor = k.foreColor;

                        //wählt das Zeichen nach dem Schlüsselwort aus
                        rtbIN.Select(wortStartIndex + k.lenght, 0);

                        //setzt die Farbe wieder auf schawrz
                        rtbIN.SelectionColor = Color.Black;

                        //verschiebt die Anfangspostion der Auswahl hinter das Wort
                        wortStartIndex = rtbIN.Text.IndexOf(k.wort, wortStartIndex + k.lenght, StringComparison.Ordinal);

                    }
                }
            }
            catch (Exception)
            {
            }

        }

        private void ColorizeComments()
        {
            foreach (string s in rtbIN.Lines)
            {
                rtbIN.DeselectAll();
                if (s.Contains("//") || s.Contains("/*") || s.Contains("*/") || s.StartsWith(" *"))
                {
                    int wortstart = rtbIN.Text.IndexOf(s, StringComparison.Ordinal);
                    rtbIN.Select(wortstart, s.Length);
                    rtbIN.SelectionColor = Color.DarkGreen;

                    rtbIN.Select(wortstart + s.Length, 0);
                    rtbIN.SelectionColor = Color.Black;
                }

            }
            rtbIN.DeselectAll();
        }

        private void loadWortListe()
        {
            //öffnet die Datei mit den Schhlüsselwörtern
            FileStream fs = new FileStream(@"keywords.dat", FileMode.Open);
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

        private void loadUebersetzungen()
        {
            //öffnet die Datei mit den Übersetzungen
            FileStream fs = new FileStream(@"uebersetzungen.dat", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                //versuch die Übersetzungen auszulesen und abzuspeichern
               _uebersetungen = (List<Uebersetzung>)formatter.Deserialize(fs);
            }
            catch (Exception)
            {
                //falls das fehlschlägt wird eine Leere Liste verwendet
                _uebersetungen = new List<Uebersetzung>();
            }
            //schließt die Datei wieder
            fs.Close();
        }
        
        private string[] convertWords(string[] Lines)
        {
            string[] l = Lines;

            string a = "";
            List<string> b = new List<string>();
            for (int i = 0; i < Lines.Length; i++)
            {
                a = "";
                foreach (Uebersetzung u in _uebersetungen)
                {
                    foreach (Match m in Regex.Matches(Lines[i], u.pattern))
                    {
                        a = u.start;
                        switch (u.anzahlVariablen)
                        {
                            case 1:

                                a += m.Groups[u.variablen[0]].Value + u.texte[0];
                                break;
                            case 2:
                                a += m.Groups[u.variablen[0]].Value + u.texte[0];
                                a += m.Groups[u.variablen[1]].Value + u.texte[1];
                                break;
                            case 3:
                                a += m.Groups[u.variablen[0]].Value + u.texte[0];
                                a += m.Groups[u.variablen[1]].Value + u.texte[1];
                                a += m.Groups[u.variablen[2]].Value + u.texte[2];
                                break;
                            case 4:
                                a += m.Groups[u.variablen[0]].Value + u.texte[0];
                                a += m.Groups[u.variablen[1]].Value + u.texte[1];
                                a += m.Groups[u.variablen[2]].Value + u.texte[2];
                                a += m.Groups[u.variablen[3]].Value + u.texte[3];
                                break;
                        }
                        l[i] = a;
                    }
                }
            }
                    
            return l;
        }
        #region Schemas für XML
        string[] xmlSchema = new string[] 
        { 
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>",
            "<root text=\"Programm\" comment=\"\" color=\"ffffff\" type=\"program\" style=\"nice\">",
            "<children>",
            "</children>",
            "</root>"
        };

        string[] xmlSchemaIf = new string[] 
        { 
          "<alternative text=\"",
          "\" comment=\"\" color=\"ffffff\">",
           "<qTrue>",
           "",
           "</qTrue>",
           "<qFalse>",
           "",
           "</qFalse>",
           "</alternative>"
        };
        string[] xmlSchemaAnweisungen = new string[]
        {
                "\n<instruction text=\"",
                "\" comment=\"\" color=\"ffffff\" rotated=\"0\"></instruction>"                                       
        };
        #endregion
        private void makeXML()
        {
            string s = "";
            List<string> l = new List<string>();
            l.Add(xmlSchema[0]);
            l.Add(xmlSchema[1]);
            l.Add(xmlSchema[2]);
            for (int i = 0; i < tvOut.Nodes.Count; i++)
            {
                s = tvOut.Nodes[i].Text;
                s = s.Replace("<-", "&#60;-");

                if (s.StartsWith("if"))
                {
                    l.Add(xmlSchemaIf[0] + s + xmlSchemaIf[1]);
                    l.Add(xmlSchemaIf[2]);
                    l.Add(xmlSchemaIf[3]);
                    l.Add(xmlSchemaIf[4]);
                    l.Add(xmlSchemaIf[5]);
                    l.Add(xmlSchemaIf[6]);
                    l.Add(xmlSchemaIf[7]);
                    l.Add(xmlSchemaIf[8]);
                }

                else if (s.StartsWith("switch"))
                {

                }

                else if (s.StartsWith("for"))
                {

                }

                else if (s.StartsWith("while"))
                {

                }

                else
                {
                    l.Add(xmlSchemaAnweisungen[0] + s + xmlSchemaAnweisungen[1]);
                }

            }
            l.Add(xmlSchema[3]);
            l.Add(xmlSchema[4]);
            rtbOut.Lines = l.ToArray();
        }

        private void openFile(string filename)
        {
            //liest alle Zeilen aus der Quell-Code-Datei
            String[] zeilen;
            try
            {
                zeilen = File.ReadAllLines(filename, Encoding.ASCII);
            }
            catch (Exception)
            {
                zeilen = new string[] { };
            }

            //setzt die Zeilen aus der Quelldatei in die Rich-Text-Box
            rtbIN.Lines = zeilen;

            //wandelt die Zeilen um
            zeilen = convertWords(zeilen);

            //markiert alle schlüsselwörter
            ColorizeKeywords();

            //färbt Kommentare grün
            ColorizeComments();

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
                    }

                    else if (zeilen[i].StartsWith("switch"))
                    {
                        col = Farben.Default.casec;
                    }

                    else if (zeilen[i].StartsWith("for"))
                    {
                        col = Farben.Default.forc;
                    }

                    else if (zeilen[i].StartsWith("while"))
                    {
                        col = Farben.Default.whilec;
                    }

                    else
                    {
                        col = Farben.Default.anweisung;
                    }

                    //fügt zum ListView hinzu
                    lbIn.Items.Add(rtbIN.Lines[i]).BackColor = col;

                    //fügt zum treeView hinzu
                    tvOut.Nodes.Add(zeilen[i].Replace("\"",""));
                }

            }
            makeXML();
        }

        #region AutoComplete für rtbIN
        private void macheListe1(string keyword)
        {
            listBox1.Items.Clear();
            foreach (var item in _wortListe)
            {
                if (item.wort.StartsWith(keyword))
                {
                    listBox1.Items.Add(item.wort);
                }
            }
        }

        private void rtbIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            listShownAC1 = true;
            if (listShowAC1)
            {
                keyword1 += e.KeyChar;

                countAC1++;
                Point p = this.rtbIN.GetPositionFromCharIndex(rtbIN.SelectionStart);
                p.Y += (int)Math.Ceiling(this.rtbIN.Font.GetHeight());
                listBox1.Location = p;
                macheListe1(keyword1);

                listBox1.Show();

                if (listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = listBox1.FindString(keyword1);
                }
                rtbIN.Focus();
                listShownAC1 = false;
            }
            if (abc.Contains(e.KeyChar.ToString()) && listShownAC1)
            {
                listShowAC1 = true;
                keyword1 += e.KeyChar;
                countAC1++;
                Point p = this.rtbIN.GetPositionFromCharIndex(rtbIN.SelectionStart);
                p.Y += (int)Math.Ceiling(this.rtbIN.Font.GetHeight());

                listBox1.Location = p;
                macheListe1(keyword1);

                listBox1.Show();
                if (listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = listBox1.FindString(keyword1);
                }
                rtbIN.Focus();
            }
        }

        private void rtbIN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                countAC1 = 0;
                keyword1 = "";
                listShowAC1 = false;
                listBox1.Hide();
            }
            if (listShowAC1)
            {
                if (e.KeyCode == Keys.Up)
                {
                    listBox1.Focus();
                    if (listBox1.SelectedIndex != 0)
                    {
                        listBox1.SelectedIndex -= 1;
                    }
                    else
                    {
                        listBox1.SelectedIndex = 0;
                    }
                    rtbIN.Focus();
                }
                else if (e.KeyCode == Keys.Down)
                {
                    listBox1.Focus();
                    try
                    {
                        listBox1.SelectedIndex += 1;
                    }
                    catch (Exception)
                    {
                    }
                    rtbIN.Focus();
                }
                if (e.KeyCode == Keys.ControlKey)
                {
                    string autoText = listBox1.SelectedItem.ToString();

                    int beginPlace = rtbIN.SelectionStart - countAC1;

                    rtbIN.Select(beginPlace, countAC1);

                    rtbIN.SelectedText = autoText;

                    rtbIN.Focus();

                    listShowAC1 = false;

                    listBox1.Hide();

                    int endPlace = autoText.Length + beginPlace;

                    rtbIN.SelectionStart = endPlace;

                    countAC1 = 0;
                }
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            string autoText = listBox1.SelectedItem.ToString();
            int beginPlace = rtbIN.SelectionStart - countAC1;
            
            rtbIN.Select(beginPlace, countAC1);
            rtbIN.SelectedText = autoText;
            rtbIN.Focus();
            listShowAC1 = false;
            listBox1.Hide();
            int endPlace = autoText.Length + beginPlace;
            rtbIN.SelectionStart = endPlace;
            countAC1 = 0;
        }
        #endregion


        #region AutoComplete für rtbOut
        //ein Array, mit allen XML-tags, die in einem STG verwendet werden
        String[] _xmlListe = new String[] 
        { 
           "<?xml version=\"1.0\" encoding=\"UTF-8\"?>",
           "<root text=\"Programm\" comment=\"\" color=\"ffffff\" type=\"program\" style=\"nice\">",
           "<children>",
           "</children>",
           "</root>",
           "<alternative text=\"\" comment=\"\" color=\"ffffff\">",
           "<qTrue>",
           "</qTrue>",
           "<qFalse>",
           "</qFalse>",
           "</alternative>",
           "<instruction text=\"\" comment=\"\" color=\"ffffff\" rotated=\"0\"></instruction>"
        };
        
        //legt alle Elemente aus _xmlListe in die ListBox, die mit dem Schlüsselwort starten 
        private void macheListe2(string keyword)
        {
            listBox2.Items.Clear();
            foreach (var item in _xmlListe)
            {
                if (item.StartsWith(keyword))
                {
                    listBox2.Items.Add(item);
                }
            }
        }
        
        private void rtbOut_KeyPress(object sender, KeyPressEventArgs e)
        {
            listShownAC2 = true;
            if (listShowAC2)
            {
                keyword2 += e.KeyChar;
                countAC2++;
                //holt die Position, an der die ListBox später angezeigt werden soll
                Point p = this.rtbOut.GetPositionFromCharIndex(rtbOut.SelectionStart);
                p.Y += (int)Math.Ceiling(this.rtbOut.Font.GetHeight());
                listBox2.Location = p;
                macheListe2(keyword2);
                listBox2.Show();

                if (listBox2.Items.Count > 0)
                {
                    listBox2.SelectedIndex = listBox2.FindString(keyword2);
                }
                rtbOut.Focus();
                listShownAC2 = false;
            }
            if ((abc.Contains(e.KeyChar.ToString()) || e.KeyChar == '<') && listShownAC2)
            {
                listShowAC2 = true;
                keyword2 += e.KeyChar;
                countAC2++;
                Point p = this.rtbOut.GetPositionFromCharIndex(rtbOut.SelectionStart);
                p.Y += (int)Math.Ceiling(this.rtbOut.Font.GetHeight());

                listBox2.Location = p;
                macheListe2(keyword2);

                listBox2.Show();
                if (listBox2.Items.Count > 0)
                {
                    listBox2.SelectedIndex = listBox2.FindString(keyword2);
                }
                rtbOut.Focus();
            }
        }

        private void rtbOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                countAC2 = 0;
                keyword2 = "";
                listShowAC2 = false;
                listBox2.Hide();
            }
            if (listShowAC2)
            {
                if (e.KeyCode == Keys.Up)
                {
                    listBox2.Focus();
                    if (listBox2.SelectedIndex != 0)
                    {
                        listBox2.SelectedIndex -= 1;
                    }
                    else
                    {
                        listBox2.SelectedIndex = 0;
                    }
                    rtbOut.Focus();
                }
                else if (e.KeyCode == Keys.Down)
                {
                    listBox2.Focus();
                    try
                    {
                        listBox2.SelectedIndex += 1;
                    }
                    catch (Exception)
                    {
                    }
                    rtbOut.Focus();
                }
                if (e.KeyCode == Keys.ControlKey)
                {
                    string autoText = listBox2.SelectedItem.ToString();

                    int beginPlace = rtbOut.SelectionStart - countAC2;

                    rtbOut.Select(beginPlace, countAC2);

                    rtbOut.SelectedText = autoText;

                    rtbOut.Focus();

                    listShowAC2 = false;

                    listBox2.Hide();

                    int endPlace = autoText.Length + beginPlace;

                    rtbOut.SelectionStart = endPlace;

                    countAC2 = 0;
                }
            }
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            string autoText = listBox2.SelectedItem.ToString();

            int beginPlace = rtbOut.SelectionStart - countAC2;

            rtbOut.Select(beginPlace, countAC2);

            rtbOut.SelectedText = autoText;

            rtbOut.Focus();

            listShowAC2 = false;

            listBox2.Hide();

            int endPlace = autoText.Length + beginPlace;

            rtbOut.SelectionStart = endPlace;

            countAC2 = 0;
        }
        #endregion

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            //leert die Steuerelemente
            rtbOut.Clear();
            lbIn.Items.Clear();
            tvOut.Nodes.Clear();

            //setzt die Zeilen aus der Quelldatei in die Rich-Text-Box
            string[] zeilen = rtbIN.Lines;

            //wandelt die Zeilen um
            zeilen = convertWords(zeilen);

            //markiert alle schlüsselwörter
            ColorizeKeywords();

            //färbt Kommentare grün
            ColorizeComments();

            //geht alle zeilen der eingeladenen datei durch
            for (int i = 0; i < zeilen.Length; i++)
            {
                //entfernt vorangestellte und nachgestellte Leerzeichn
                zeilen[i] = zeilen[i].Trim();

                //falls die zeile unnötig ist, wird sie entfernt
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
                    }

                    else if (zeilen[i].StartsWith("switch"))
                    {
                        col = Farben.Default.casec;
                    }

                    else if (zeilen[i].StartsWith("for"))
                    {
                        col = Farben.Default.forc;
                    }

                    else if (zeilen[i].StartsWith("while"))
                    {
                        col = Farben.Default.whilec;
                    }

                    else
                    {
                        col = Farben.Default.anweisung;
                    }

                    //fügt zum ListView hinzu
                    lbIn.Items.Add(rtbIN.Lines[i]).BackColor = col;

                    //fügt zum treeView hinzu
                    tvOut.Nodes.Add(zeilen[i].Replace("\"", ""));
                }

            }
            //erstellt den XML-Code für das STG
            makeXML();
        }

        private void fehlerMeldenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fehlertext = "";
            //legt den Text für die E-Mail auf den markierten Inhalt im Fenster
            if (rtbIN.Focus() && rtbIN.SelectedText != null)
            {
                fehlertext = rtbIN.SelectedText;
            }
            if (rtbOut.Focus() && rtbOut.SelectedText != null)
            {
                fehlertext = rtbOut.SelectedText;
            }
            if (lbIn.Focus() && lbIn.SelectedItems != null)
            {
                foreach (ListViewItem item in lbIn.SelectedItems)
                {
                    fehlertext += item.Text;
                    fehlertext += " ";
                }
            }
            if (tvOut.Focus() && tvOut.SelectedNode.Text != null)
            {
                fehlertext = tvOut.SelectedNode.Text;
            }
            //zeigt das Mail-Senden Fenster an
            Form m = new Mail(fehlertext);
            m.ShowDialog();
            //falls OK geklickt wurde
            if (m.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                //sendet die E-Mail mit dem eingegeben Inhalt und Betreff
                sendMail(m.Tag.ToString(), m.Text);
            }
        }

        /// <summary>
        /// Sendet eine E-Mail
        /// </summary>
        /// <param name="inhalt">der Inhalt der E-Mail</param>
        /// <param name="betreff">der Betreff der E-Mail</param>
        private void sendMail(string inhalt, string betreff)
        {
            //Erzeugt eine neue Mail
            MailMessage mail = new MailMessage();
            //legt den Absender der Mail auf die gespeicherte E-Mailadresse
            mail.From = new MailAddress(Settings.Default.MailName);
            //fügt einen Empfänger hinzu
            mail.To.Add("javansd@outlook.de");
            //legt den Betreff fest
            mail.Subject = betreff;
            //legt den Inhalt fest
            mail.Body = inhalt;
            //neuer SMTP-Client mit dem gespeicherten Mail-Server und gespeicherten Port
            SmtpClient client = new SmtpClient(Settings.Default.MailServer, Settings.Default.MailPort);
            //versucht eine Mail zu senden
            try
            {
                //erstellt neue Anmeldeinformationen
                client.Credentials = new System.Net.NetworkCredential(Settings.Default.MailName, Settings.Default.MailPass);
                //aktiviert ssl
                client.EnableSsl = true;
                //sendet die Mail
                client.Send(mail);
                MessageBox.Show("E-Mail gesendet");
            }
            catch (Exception ex)
            {
                //gibt den Fehler aus
                MessageBox.Show("Fehler beim Senden der Mail:\n" + ex.Message);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Kopieren des Textes in der ausgewählten Textbox
            if (rtbIN.Focused)
            {
                rtbIN.Copy();
            }

            if (rtbOut.Focused)
            {
                rtbOut.Copy();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Einfügen des Textes in der ausgewählten Textbox
            if (rtbIN.Focused)
            {
                rtbIN.Paste();
            }

            if (rtbOut.Focused)
            {
                rtbOut.Paste();
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //Ausschneiden des Textes in der ausgewählten Textbox
            if (rtbIN.Focused)
            {
                rtbIN.Cut();
            }

            if (rtbOut.Focused)
            {
                rtbOut.Cut();
            }
        }
    }
}
