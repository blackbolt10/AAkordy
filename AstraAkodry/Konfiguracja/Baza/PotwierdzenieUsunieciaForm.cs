using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AstraAkodry.Konfiguracja.Baza
{
    public partial class PotwierdzenieUsunieciaForm : Form
    {
        public bool usun = false;

        public PotwierdzenieUsunieciaForm(String imie, String nazwisko)
        {
            InitializeComponent();

            usunCB.Text = "Usuń pracownika " + nazwisko + " " + imie;
        }

        private void comboboxUsun_CheckedChanged(object sender, EventArgs e)
        {
            if(usunCB.Checked && !checkBox1.Checked && !checkBox3.Checked)
            {
                potwierdzButton.Enabled = true;
            }
            else
            {
                potwierdzButton.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void potwierdzButton_Click(object sender, EventArgs e)
        {
            usun = true;
            this.Close();
        }
    }
}
