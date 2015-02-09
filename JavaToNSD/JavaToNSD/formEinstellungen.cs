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
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //fügt ein neues Schlüsselwort hinzu
            listBox1.Items.Add(textBox1.Text);
            textBox1.ResetText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //entfernt das ausgwählte element
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //öscht alle Elemente
            listBox1.Items.Clear();
        }

        public void save()
        {
            //speichert alle Schlüsselwörter ab
            List<string> synHigh = new List<string>();
            foreach (string s in listBox1.Items)
	        {
		        synHigh.Add(s);
	        }   
            File.WriteAllLines(Application.StartupPath + @"\syntax.syn",synHigh);
        }

        public void load()
        {
            try
            {
                //versucht die Datei mit den Schlüsselwörtern zu lesen
                List<string> synHigh = File.ReadAllLines(Application.StartupPath + @"\syntax.syn").ToList();
                foreach (string s in synHigh)
                {
                    listBox1.Items.Add(s);
                }
            }
            catch (FileNotFoundException)
            {
                //falls diese nicht existiert wird sie erstellt
                File.Create(Application.StartupPath + @"\syntax.syn");
            }
            
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            //speichert und schliesst
            save();
            this.Close();
        }

        
    }
}
