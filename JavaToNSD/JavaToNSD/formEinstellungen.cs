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
            _uebersetzungen.Clear();
            //lädt alle Einstellungen
            load();
            //fügt die Schlüsselwörter dem ListView hinzu
            foreach (var item in _wortListe)
            {
                listView1.Items.Add(item.wort).ForeColor = item.foreColor;
            }
            int index = 0;
            foreach (var item in _uebersetzungen)
            {
                index = listView2.Items.Add(item.java).Index;
                listView2.Items[index].SubItems.Add(item.vorA);
                listView2.Items[index].SubItems.Add(item.zwischenAB);
                listView2.Items[index].SubItems.Add(item.nachB);
            }

        }
        List<Keyword> _wortListe = new List<Keyword>();
        List<Uebersetzung> _uebersetzungen = new List<Uebersetzung>();

        private void button1_Click(object sender, EventArgs e)
        {
            //fügt ein neues Schlüsselwort hinzu
            listView1.Items.Add(textBox1.Text).ForeColor = colorDialog1.Color;
            //erstellt ein neues Keyword
            //_wortListe.Add(new Keyword(textBox1.Text, colorDialog1.Color));
            

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
            FileStream fs;
            fs = new FileStream(@"keywords.dat", FileMode.Open);
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


            fs = new FileStream(@"uebersetzungen.dat", FileMode.Open);
            try
            {
                //versucht die Übersetzungen auszulesen und abzuspeichern
                _uebersetzungen = (List<Uebersetzung>)formatter.Deserialize(fs);
            }
            catch (Exception)
            {
                //falls das fehlschlägt wird eine Leere Liste verwendet
                _uebersetzungen = new List<Uebersetzung>();
            }
            //schließt die Datei wieder
            fs.Close();



        }

        private void save()
        {
            _wortListe.Clear();
            _uebersetzungen.Clear();
            //speichert die Schlüsselwörter in einer Liste ab
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                _wortListe.Add(new Keyword(listView1.Items[i].SubItems[0].Text, listView1.Items[i].SubItems[0].ForeColor));
            }
            //speichert die Übersetzungen in einer Liste ab
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                _uebersetzungen.Add(new Uebersetzung(listView2.Items[i].Text,listView2.Items[i].SubItems[1].Text,listView2.Items[i].SubItems[2].Text,listView2.Items[i].SubItems[3].Text));
            }

            //speichert die Listen in Dateien ab
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs;
            fs = new FileStream(@"keywords.dat", FileMode.Create);
            bf.Serialize(fs, _wortListe);
            fs.Close();
            fs = new FileStream(@"uebersetzungen.dat", FileMode.Create);
            bf.Serialize(fs, _uebersetzungen);
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
        private void toolStripSplitButton3_ButtonClick(object sender, EventArgs e)
        {
            save();
        }
        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //löscht alle ausgewälten Schlüsselwörter
            foreach (ListViewItem eachItem in listView1.SelectedItems)
            {
                listView1.Items.Remove(eachItem);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //fügt eine Übersetzung dem ListView hinzu
            int index;
            index = listView2.Items.Add(textBox2.Text).Index;
            listView2.Items[index].SubItems.Add(textBox3.Text);
            listView2.Items[index].SubItems.Add(textBox4.Text);
            listView2.Items[index].SubItems.Add(textBox5.Text);

            textBox2.ResetText();
            textBox3.ResetText();
            textBox4.ResetText();
            textBox5.ResetText();
        }
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button6_Click(object sender, EventArgs e)
        {
            //entfernt alle ausgewählten Übersetzungen
            foreach (ListViewItem eachItem in listView2.SelectedItems)
            {
                listView2.Items.Remove(eachItem);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //löscht alle Übersetzungen
            listView2.Items.Clear();
        }

        
    }
}
