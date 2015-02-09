using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JavaToNSD;
using System.Runtime.Serialization.Formatters.Binary;

namespace JavaToNSD
{
    public partial class formEinstellungen : Form
    {
        public formEinstellungen()
        {
            InitializeComponent();
        }
        private void formEinstellungen_Load(object sender, EventArgs e)
        {
            //setzt die Liste mit den Schlüsselwörtern zurück
            _wortListe.Clear();
            //lädt alle Einstellungen
            load();
            //fügt die Schlüsselwörter dem ListView hinzu
            foreach (var item in _wortListe)
            {
                listView1.Items.Add(item.wort).ForeColor = item.foreColor;
            }
        }
        List<Keyword> _wortListe = new List<Keyword>();

        private void button1_Click(object sender, EventArgs e)
        {
            //fügt ein neues Schlüsselwort hinzu
            listView1.Items.Add(textBox1.Text).ForeColor = colorDialog1.Color;
            //erstellt ein neues Keyword
            _wortListe.Add(new Keyword(textBox1.Text, colorDialog1.Color));

            textBox1.ResetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //öscht alle Elemente
            listView1.Items.Clear();
            _wortListe.Clear();
        }

        private void load()
        {
            //öffnet die Schlüsselwort-Datei
            FileStream fs = new FileStream(@"keywords.syn", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                _wortListe = (List<Keyword>)formatter.Deserialize(fs);
            }
            catch (Exception)
            {
                _wortListe = new List<Keyword>();
            }
            fs.Close();
        }

        private void save()
        {
            //speichert die Datei ab
            FileStream fs = new FileStream(@"keywords.syn", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, _wortListe);
            fs.Close();
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            //speichert und schliesst
            save();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            button4.BackColor = colorDialog1.Color;
        }
        
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        
    }
}
