using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AstraAkodry.Konfiguracja
{
    public partial class HasloForm : Form
    {
        public HasloForm()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) //zamknięcie aktywnego okna
        {
            if(keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void zamknijButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void zmienButton_Click(object sender, EventArgs e)
        {
            if(obecneHasloTB.Text == MainForm.hasloOperatora)
            {
                if(noweHasloTB.Text == noweHaslo2TB.Text)
                {
                    DBRepository db = new DBRepository();
                    String result = "";

                    if(db.HasloForm_ZmienHaslo(noweHasloTB.Text, ref result))
                    {
                        MainForm.hasloOperatora = noweHasloTB.Text;
                        obecneHasloTB.Text = "";
                        noweHasloTB.Text = "";
                        noweHaslo2TB.Text = "";

                        MessageBox.Show("Hasło zostało zmienione", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Wystąpił błąd podczas zmiany hasła : "+result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Nowe hasło jest niezgodne z powtórzonym.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Obecne hasło jest nieprawidłowe!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
