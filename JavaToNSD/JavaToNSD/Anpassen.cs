using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JavaToNSD;
using JavaToNSD.Properties;
namespace JavaToNSD
{
    public partial class Anpassen : Form
    {
        public Anpassen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //macht Farbe für Anweisung
            colorDialog1.ShowDialog();
            Button b = (Button)sender;
            b.BackColor = colorDialog1.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //macht Farbe für IF
            colorDialog1.ShowDialog();
            Button b = (Button)sender;
            b.BackColor = colorDialog1.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //macht Farbe für Case
            colorDialog1.ShowDialog();
            Button b = (Button)sender;
            b.BackColor = colorDialog1.Color;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //macht Farbe für For
            colorDialog1.ShowDialog();
            Button b = (Button)sender;
            b.BackColor = colorDialog1.Color;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //macht Farbe für While
            colorDialog1.ShowDialog();
            Button b = (Button)sender;
            b.BackColor = colorDialog1.Color;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            //speichert
            save();
        }

        public void save()
        {
            // speichert alle Farben
            Farben.Default.anweisung = button1.BackColor;
            Farben.Default.ifc = button2.BackColor;
            Farben.Default.casec = button3.BackColor;
            Farben.Default.forc = button4.BackColor;
            Farben.Default.whilec = button5.BackColor;
            //speichert die Einstellungen ab
            Farben.Default.Save();

            Settings.Default.FontCodeEditor = label7.Font;
            Settings.Default.FontListView = label8.Font; 
            Settings.Default.FontTreeView = label10.Font;
            Settings.Default.FontXMLEditor = label12.Font;
            Settings.Default.Save();
        }

        private void Anpassen_Load(object sender, EventArgs e)
        {
            //lädt alle Farben
            button1.BackColor = Farben.Default.anweisung ;
            button2.BackColor = Farben.Default.ifc;
            button3.BackColor = Farben.Default.casec;
            button4.BackColor = Farben.Default.forc;
            button5.BackColor = Farben.Default.whilec;

            label7.Font = Settings.Default.FontCodeEditor;
            label8.Font = Settings.Default.FontListView;
            label10.Font = Settings.Default.FontTreeView;
            label12.Font = Settings.Default.FontXMLEditor;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            //Speichert und schließt
            this.save();
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            //schließt
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            label7.Font = fontDialog1.Font;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            label8.Font = fontDialog1.Font;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            label10.Font = fontDialog1.Font;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            label12.Font = fontDialog1.Font;
        }
    }
}
