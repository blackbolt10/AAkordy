using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AstraAkodry.Konfiguracja.Ustawienia.Akordy
{
    public partial class AkordyChangeForm : Form
    {
        public Boolean czyZmodyfikowano = false;
        private string AKR_AkrId;

        public AkordyChangeForm()
        {
            InitializeComponent();
        }

        public AkordyChangeForm(string aKR_AkrId, string aKR_Nazwa, string aKR_Norma, string aKR_Archiwalny)
        {
            InitializeComponent();

            this.Text = "Edytuj akord";

            this.AKR_AkrId = aKR_AkrId;
            nazwaTB.Text = aKR_Nazwa;
            normaTB.Text = aKR_Norma;

            if(aKR_Archiwalny == "1")
            {
                archiwalnyCB.Checked = true;
            }

            akceptujButton.Click -= akceptujButton_Click;
            akceptujButton.Click += zmienButton_Click;
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

        private void nazwiskoTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void akceptujButton_Click(object sender, EventArgs e)
        {
            if(nazwaTB.Text != "" && normaTB.Text != "")
            {
                DBRepository db = new DBRepository();
                String result = "";
                String archiwalny = "0";

                if(archiwalnyCB.Checked)
                {
                    archiwalny = "1";
                }

                if(db.AkordyChangeForm_AddAkord( nazwaTB.Text, normaTB.Text, archiwalny, ref result))
                {
                    czyZmodyfikowano = true;
                    MessageBox.Show("Nowy akord został dodany.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd podczas dodawnia nowego akordu. Prosze spróbować ponownie.\n\nBłąd:" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nazwa i norma nie mogą być puste!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void zmienButton_Click(object sender, EventArgs e)
        {
            if(nazwaTB.Text != "" && normaTB.Text != "")
            {
                DBRepository db = new DBRepository();
                String result = "";
                String archiwalny = "0";

                if(archiwalnyCB.Checked)
                {
                    archiwalny = "1";
                }

                if(db.AkordyChangeForm_ChangeAkord(AKR_AkrId, nazwaTB.Text, normaTB.Text, archiwalny, ref result))
                {
                    czyZmodyfikowano = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd podczas edycji akordu. Prosze spróbować ponownie.\n\nBłąd:" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nazwa i norma nie mogą być puste!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
