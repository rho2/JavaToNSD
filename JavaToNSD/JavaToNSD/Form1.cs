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

namespace JavaToNSD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] xmlSchema = new string[] { "<?xml version=\"1.0\" encoding=\"UTF-8\"?> \n <root text=\"Programm\" comment=\"\" color=\"ffffff\" type=\"program\" style=\"nice\">\n<children>\n",
                                            "\n</children>\n</root>",
                                            "\n<instruction text=\"",
                                            "\" comment=\"\" color=\"ffffff\" rotated=\"0\"></instruction>"
                                           };
        String[] keywordsBlue = File.ReadAllLines(Application.StartupPath + @"\syntax.syn");


        private void optionenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Einstellungen = new formEinstellungen();
            Einstellungen.ShowDialog();
        }
        private void anpassenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Anpassen = new Anpassen();
            Anpassen.ShowDialog();
        }


        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbIN.Clear();
            rtbOut.Clear();
            lbIn.Items.Clear();
            tvOut.Nodes.Clear();
        }
        private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            String[] zeilen = File.ReadAllLines(openFileDialog1.FileName,Encoding.UTF8);
            rtbIN.Lines = zeilen;
            #region 
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

            string xml = xmlSchema[0];
            for (int i = 0; i < zeilen.Length; i++)
            {
                zeilen[i] = zeilen[i].Trim();
                if (zeilen[i].StartsWith(@"/") || zeilen[i].StartsWith(@"*") || zeilen[i].StartsWith(@"import") || zeilen[i].StartsWith(@"{") || zeilen[i].StartsWith(@"}"))
                {
                    zeilen[i] = "";
                }
                if (zeilen[i] != "")
                {
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
                        
                    lbIn.Items.Add(zeilen[i]).BackColor = col;

                    tvOut.Nodes.Add(zeilen[i]);

                    xml += xmlSchema[2] + zeilen[i].Replace("\"","") + xmlSchema[3];
                }

            }
            rtbOut.Text = xml;
            

            
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
