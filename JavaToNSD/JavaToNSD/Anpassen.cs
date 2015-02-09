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

            Farben.Default.Save();
        }

        private void Anpassen_Load(object sender, EventArgs e)
        {
            //lädt alle Farben
            button1.BackColor = Farben.Default.anweisung ;
            button2.BackColor = Farben.Default.ifc;
            button3.BackColor = Farben.Default.casec;
            button4.BackColor = Farben.Default.forc;
            button5.BackColor = Farben.Default.whilec;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            this.save();
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
