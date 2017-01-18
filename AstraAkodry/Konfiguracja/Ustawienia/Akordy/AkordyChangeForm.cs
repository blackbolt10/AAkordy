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

        private void AkordyChangeForm_Shown(object sender, EventArgs e)
        {
            nazwaLabel.Font = MainForm.czcionka;
            nazwaTB.Font = MainForm.czcionka;
            normaLabel.Font = MainForm.czcionka;
            normaTB.Font = MainForm.czcionka;
            archiwalnyCB.Font = MainForm.czcionka;

            if(nazwaLabel.Text.Length>normaLabel.Text.Length)
            {
                nazwaTB.Location = new Point(nazwaLabel.Location.X + nazwaLabel.Size.Width + 10, nazwaTB.Location.Y);
            }
            else
            {
                nazwaTB.Location = new Point(normaLabel.Location.X + normaLabel.Size.Width + 10, nazwaTB.Location.Y);
            }

            normaLabel.Location = new Point(normaLabel.Location.X, nazwaTB.Location.Y + nazwaTB.Size.Height + 10);

            if(nazwaLabel.Text.Length > normaLabel.Text.Length)
            {
                normaTB.Location = new Point(nazwaLabel.Location.X + nazwaLabel.Size.Width + 10, normaLabel.Location.Y);
            }
            else
            {
                normaTB.Location = new Point(normaLabel.Location.X + normaLabel.Size.Width + 10, normaLabel.Location.Y);
            }

            archiwalnyCB.Location = new Point(archiwalnyCB.Location.X, normaTB.Location.Y + normaTB.Size.Height + 10);

            this.Size = new Size(this.Size.Width+10, this.Size.Height + zamknijButton.Size.Height + 10);

            zamknijButton.Location = new Point(zamknijButton.Location.X, archiwalnyCB.Location.Y + archiwalnyCB.Size.Height + 5);
            akceptujButton.Location = new Point(akceptujButton.Location.X, archiwalnyCB.Location.Y + archiwalnyCB.Size.Height + 5);
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
