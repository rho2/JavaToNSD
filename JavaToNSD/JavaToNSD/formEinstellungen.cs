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
            listView2.Items.Clear();
            writeListView();

            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();

            foreach (string s in ClassesKeywords.a)
            {
                ac.Add(s);
            }

            textBox2.AutoCompleteCustomSource = ac;
        }
        List<Keyword> _wortListe = new List<Keyword>();
        List<Uebersetzung> _uebersetzungen = new List<Uebersetzung>();

        byte anzahlVariablen;
        List<string> text ;
        List<string> variablen;

        private void button1_Click(object sender, EventArgs e)
        {
            //fügt ein neues Schlüsselwort hinzu
            foreach (string s in textBox1.Lines)
            {
                listView1.Items.Add(s).ForeColor = colorDialog1.Color;
            }
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
                string start;
                string pattern;
                byte anzahlVariablen;
                variablen = new List<string>();
                text = new List<string>();

                pattern = listView2.Items[i].Text;
                start = listView2.Items[i].SubItems[1].Text;

                variablen.Add(listView2.Items[i].SubItems[2].Text);
                variablen.Add(listView2.Items[i].SubItems[4].Text);
                variablen.Add(listView2.Items[i].SubItems[6].Text);
                variablen.Add(listView2.Items[i].SubItems[8].Text);

                text.Add(listView2.Items[i].SubItems[3].Text);
                text.Add(listView2.Items[i].SubItems[5].Text);
                text.Add(listView2.Items[i].SubItems[7].Text);
                text.Add(listView2.Items[i].SubItems[9].Text);

                anzahlVariablen = Convert.ToByte(listView2.Items[i].SubItems[10].Text);
                //MessageBox.Show(anzahlVariablen.ToString() + listView2.Items[i].SubItems[2].Text);
                _uebersetzungen.Add(new Uebersetzung(anzahlVariablen, pattern, start, text, variablen));
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
            int index = listView2.Items.Add(textBox2.Text).Index;
            //MessageBox.Show(anzahlVariablen.ToString());
            switch (anzahlVariablen)
            {
                case 1:
                    listView2.Items[index].SubItems.Add(textBox3.Text);
                    listView2.Items[index].SubItems.Add(textBox4.Text);
                    listView2.Items[index].SubItems.Add(textBox5.Text);
                    listView2.Items[index].SubItems.Add("");
                    listView2.Items[index].SubItems.Add("");
                    listView2.Items[index].SubItems.Add("");
                    listView2.Items[index].SubItems.Add("");
                    listView2.Items[index].SubItems.Add("");
                    listView2.Items[index].SubItems.Add("");
                    listView2.Items[index].SubItems.Add(anzahlVariablen.ToString());
                    break;
                case 2:
                    listView2.Items[index].SubItems.Add(textBox3.Text);
                    listView2.Items[index].SubItems.Add(textBox4.Text);
                    listView2.Items[index].SubItems.Add(textBox5.Text);
                    listView2.Items[index].SubItems.Add(textBox6.Text);
                    listView2.Items[index].SubItems.Add(textBox7.Text);
                    listView2.Items[index].SubItems.Add("");
                    listView2.Items[index].SubItems.Add("");
                    listView2.Items[index].SubItems.Add("");
                    listView2.Items[index].SubItems.Add("");
                    listView2.Items[index].SubItems.Add(anzahlVariablen.ToString());
                    break;
                case 3:
                    listView2.Items[index].SubItems.Add(textBox3.Text);
                    listView2.Items[index].SubItems.Add(textBox4.Text);
                    listView2.Items[index].SubItems.Add(textBox5.Text);
                    listView2.Items[index].SubItems.Add(textBox6.Text);
                    listView2.Items[index].SubItems.Add(textBox7.Text);
                    listView2.Items[index].SubItems.Add(textBox8.Text);
                    listView2.Items[index].SubItems.Add(textBox9.Text);
                    listView2.Items[index].SubItems.Add("");
                    listView2.Items[index].SubItems.Add("");
                    listView2.Items[index].SubItems.Add(anzahlVariablen.ToString());
                    break;
                case 4:
                    listView2.Items[index].SubItems.Add(textBox3.Text);
                    listView2.Items[index].SubItems.Add(textBox4.Text);
                    listView2.Items[index].SubItems.Add(textBox5.Text);
                    listView2.Items[index].SubItems.Add(textBox6.Text);
                    listView2.Items[index].SubItems.Add(textBox7.Text);
                    listView2.Items[index].SubItems.Add(textBox8.Text);
                    listView2.Items[index].SubItems.Add(textBox9.Text);
                    listView2.Items[index].SubItems.Add(textBox10.Text);
                    listView2.Items[index].SubItems.Add(textBox11.Text);
                    listView2.Items[index].SubItems.Add(anzahlVariablen.ToString());
                    break;
            }
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

        private void button8_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            FileStream fs;
            fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
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


            writeListView();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            //öffnet die Schlüsselwort-Datei
            FileStream fs;
            fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
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

            foreach (var item in _wortListe)
            {
                listView1.Items.Add(item.wort).ForeColor = item.foreColor;
            }
        }

        #region radioButtons
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                textBox11.Enabled = false;
                anzahlVariablen = 1;
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                textBox11.Enabled = false;
                anzahlVariablen = 2;
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                textBox8.Enabled = true;
                textBox9.Enabled = true;
                textBox10.Enabled = false;
                textBox11.Enabled = false;
                anzahlVariablen = 3;
            }
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                textBox8.Enabled = true;
                textBox9.Enabled = true;
                textBox10.Enabled = true;
                textBox11.Enabled = true;
                anzahlVariablen = 4;
            }
        }
        #endregion

        private void writeListView()
        {
            int index = 0;
            foreach (Uebersetzung item in _uebersetzungen)
            {
                index = listView2.Items.Add(item.pattern).Index;
                switch (item.anzahlVariablen)
                {

                    case 1:
                        listView2.Items[index].SubItems.Add(item.start);
                        listView2.Items[index].SubItems.Add(item.variablen[0]);
                        listView2.Items[index].SubItems.Add(item.texte[0]);
                        listView2.Items[index].SubItems.Add("");
                        listView2.Items[index].SubItems.Add("");
                        listView2.Items[index].SubItems.Add("");
                        listView2.Items[index].SubItems.Add("");
                        listView2.Items[index].SubItems.Add("");
                        listView2.Items[index].SubItems.Add("");
                        listView2.Items[index].SubItems.Add("1");
                        break;
                    case 2:
                        listView2.Items[index].SubItems.Add(item.start);
                        listView2.Items[index].SubItems.Add(item.variablen[0]);
                        listView2.Items[index].SubItems.Add(item.texte[0]);
                        listView2.Items[index].SubItems.Add(item.variablen[1]);
                        listView2.Items[index].SubItems.Add(item.texte[1]);
                        listView2.Items[index].SubItems.Add("");
                        listView2.Items[index].SubItems.Add("");
                        listView2.Items[index].SubItems.Add("");
                        listView2.Items[index].SubItems.Add("");
                        listView2.Items[index].SubItems.Add("2");
                        break;
                    case 3:
                        listView2.Items[index].SubItems.Add(item.start);
                        listView2.Items[index].SubItems.Add(item.variablen[0]);
                        listView2.Items[index].SubItems.Add(item.texte[0]);
                        listView2.Items[index].SubItems.Add(item.variablen[1]);
                        listView2.Items[index].SubItems.Add(item.texte[1]);
                        listView2.Items[index].SubItems.Add(item.variablen[2]);
                        listView2.Items[index].SubItems.Add(item.texte[2]);
                        listView2.Items[index].SubItems.Add("");
                        listView2.Items[index].SubItems.Add("");
                        listView2.Items[index].SubItems.Add("3");
                        break;
                    case 4:
                        listView2.Items[index].SubItems.Add(item.start);
                        listView2.Items[index].SubItems.Add(item.variablen[0]);
                        listView2.Items[index].SubItems.Add(item.texte[0]);
                        listView2.Items[index].SubItems.Add(item.variablen[1]);
                        listView2.Items[index].SubItems.Add(item.texte[1]);
                        listView2.Items[index].SubItems.Add(item.variablen[2]);
                        listView2.Items[index].SubItems.Add(item.texte[2]);
                        listView2.Items[index].SubItems.Add(item.variablen[3]);
                        listView2.Items[index].SubItems.Add(item.texte[3]);
                        listView2.Items[index].SubItems.Add("4");
                        break;
                }

            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listView2.SelectedItems[0].Index;
            textBox2.Text = listView2.Items[index].Text;
            textBox3.Text = listView2.Items[index].SubItems[1].Text;
            textBox4.Text = listView2.Items[index].SubItems[2].Text;
            textBox5.Text = listView2.Items[index].SubItems[3].Text;
            textBox6.Text = listView2.Items[index].SubItems[4].Text;
            textBox7.Text = listView2.Items[index].SubItems[5].Text;
            textBox8.Text = listView2.Items[index].SubItems[6].Text;
            textBox9.Text = listView2.Items[index].SubItems[7].Text;
            textBox10.Text = listView2.Items[index].SubItems[8].Text;
            textBox11.Text = listView2.Items[index].SubItems[9].Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text.Insert(textBox2.SelectionStart, @"(?<>.*)");
            if (radioButton1.Checked)
            {
                radioButton2.Checked = true;
            }
            else if (radioButton2.Checked)
            {
                radioButton3.Checked = true;
            }
            else if (radioButton3.Checked)
            {
                radioButton4.Checked = true;
            }
        }

    }
}
