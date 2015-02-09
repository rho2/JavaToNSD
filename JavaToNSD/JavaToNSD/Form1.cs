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

namespace JavaToNSD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //array für XML code zu speicherung eines Strukogramms
        string[] xmlSchema = new string[] { "<?xml version=\"1.0\" encoding=\"UTF-8\"?> \n <root text=\"Programm\" comment=\"\" color=\"ffffff\" type=\"program\" style=\"nice\">\n<children>\n",
                                            "\n</children>\n</root>",
                                            "\n<instruction text=\"",
                                            "\" comment=\"\" color=\"ffffff\" rotated=\"0\"></instruction>",
                                            "<alternative text=\"",
                                            "\" comment=\"\" color=\"ffffff\">\n<qTrue>\n</qTrue>\n<qFalse>\n</qFalse></alternative>"
                                           };
        //liest alle schlüsselwörter ein
        String[] keywordsBlue = File.ReadAllLines(Application.StartupPath + @"\syntax.syn");


        private void optionenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //zeigt das Einstellungsfenset an
            Form Einstellungen = new formEinstellungen();
            Einstellungen.ShowDialog();
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
            byte type = 0;
            //öffner die ausgeählte Datei
            openFileDialog1.ShowDialog();
            String[] zeilen = File.ReadAllLines(openFileDialog1.FileName,Encoding.UTF8);
            rtbIN.Lines = zeilen;
            #region 
            //markiert alle schlüsselwörter
            foreach (string s in keywordsBlue)
            {
                int wortstart = rtbIN.Text.IndexOf(s,StringComparison.Ordinal);
                while (wortstart >= 0)
                {
                    rtbIN.Select(wortstart, s.Length);
                    rtbIN.SelectionColor = Color.Blue;

                    rtbIN.Select(wortstart + s.Length, 0);
                    rtbIN.SelectionColor = Color.Black;
                    
                    wortstart = rtbIN.Text.IndexOf(s, wortstart + s.Length,StringComparison.Ordinal);
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
                if (zeilen[i].StartsWith(@"/") || zeilen[i].StartsWith(@"*") || zeilen[i].StartsWith(@"import") || zeilen[i].StartsWith(@"{") || zeilen[i].StartsWith(@"}"))
                {
                    zeilen[i] = "";
                }
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
                     //fügt zur listbox hinzu
                    lbIn.Items.Add(zeilen[i]).BackColor = col;
                    //fügt zum treeView hinzu
                    tvOut.Nodes.Add(zeilen[i]);
                    //erweitert den xml-code
                    
                }

            }
            //legt den xml code in die rtf box
            rtbOut.Text = xml;
            

            
        }
        public void load()
        {
            byte type = 0;
            String[] zeilen;
            zeilen = rtbIN.Lines;
            rtbOut.Clear();
            lbIn.Items.Clear();
            tvOut.Nodes.Clear();
            #region
            //markiert alle schlüsselwörter
            foreach (string s in keywordsBlue)
            {
                int wortstart = rtbIN.Text.IndexOf(s, StringComparison.Ordinal);
                while (wortstart >= 0)
                {
                    rtbIN.Select(wortstart, s.Length);
                    rtbIN.SelectionColor = Color.Blue;

                    rtbIN.Select(wortstart + s.Length, 0);
                    rtbIN.SelectionColor = Color.Black;

                    wortstart = rtbIN.Text.IndexOf(s, wortstart + s.Length, StringComparison.Ordinal);
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
                if (zeilen[i].StartsWith(@"/") || zeilen[i].StartsWith(@"*") || zeilen[i].StartsWith(@"import") || zeilen[i].StartsWith(@"{") || zeilen[i].StartsWith(@"}"))
                {
                    zeilen[i] = "";
                }
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
                    //fügt zur listbox hinzu
                    lbIn.Items.Add(zeilen[i]).BackColor = col;
                    //fügt zum treeView hinzu
                    tvOut.Nodes.Add(zeilen[i]);
                    //erweitert den xml-code

                }

            }
            //legt den xml code in die rtf box
            rtbOut.Text = xml;
            
        }
        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            load();
        }
        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            File.WriteAllText(saveFileDialog1.FileName, rtbOut.Text);
        }
        private void druckenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void seitenansichtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rückgängigToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        

        
    }
}
