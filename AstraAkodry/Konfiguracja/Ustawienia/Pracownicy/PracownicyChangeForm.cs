using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AstraAkodry.Konfiguracja.Ustawienia.Pracownicy
{
    public partial class PracownicyChangeForm : Form
    {
        public Boolean czyZmodyfikowano = false;
        private String PRA_PracID;

        public PracownicyChangeForm()
        {
            InitializeComponent();
        }

        public PracownicyChangeForm(string pRA_PracID, string pRA_Imie, string pRA_Nazwisko, string pRA_Archiwalny)
        {
            InitializeComponent();

            this.Text = "Edytuj pracownika";

            PRA_PracID = pRA_PracID;
            imieTB.Text = pRA_Imie;
            nazwiskoTB.Text = pRA_Nazwisko;

            if(pRA_Archiwalny == "1")
            {
                archiwalnyCB.Checked = true;
            }

            akceptujButton.Click -= akceptujButton_Click;
            akceptujButton.Click += zmienButton_Click;
        }

        private void PracownicyChangeForm_Shown(object sender, EventArgs e)
        {
            imieLabel.Font = MainForm.czcionka;
            imieTB.Font = MainForm.czcionka;
            nazwiskoLabel.Font = MainForm.czcionka;
            nazwiskoTB.Font = MainForm.czcionka;
            archiwalnyCB.Font = MainForm.czcionka;

            imieTB.Location = new Point(nazwiskoLabel.Location.X + nazwiskoLabel.Size.Width + 10, imieTB.Location.Y);
            nazwiskoTB.Location = new Point(nazwiskoLabel.Location.X + nazwiskoLabel.Size.Width + 10, imieTB.Location.Y + imieTB.Size.Height + 10);

            nazwiskoLabel.Location = new Point(nazwiskoLabel.Location.X, nazwiskoTB.Location.Y);
            archiwalnyCB.Location = new Point(archiwalnyCB.Location.X, nazwiskoLabel.Location.Y + nazwiskoLabel.Size.Height + 10);

            this.Size = new Size(this.Width + 10, this.Height + zamknijButton.Size.Height + 10);
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

        private void akceptujButton_Click(object sender, EventArgs e)
        {
            if(imieTB.Text != "" && nazwiskoTB.Text != "")
            {
                DBRepository db = new DBRepository();
                String result = "";
                String archiwalny = "0";

                if(archiwalnyCB.Checked)
                {
                    archiwalny = "1";
                }

                if(db.PracownicyChangeForm_AddNewPracownik(imieTB.Text, nazwiskoTB.Text, archiwalny, ref result))
                {
                    czyZmodyfikowano = true;
                    MessageBox.Show("Nowy pracownik został dodany.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd podczas dodawnia nowego pracownika. Prosze spróbować ponownie.\n\nBłąd:" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Imię i nazwisko nie mogą być puste!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void zmienButton_Click(object sender, EventArgs e)
        {
            if(imieTB.Text != "" && nazwiskoTB.Text != "")
            {
                DBRepository db = new DBRepository();
                String result = "";
                String archiwalny = "0";

                if(archiwalnyCB.Checked)
                {
                    archiwalny = "1";
                }

                if(db.PracownicyChangeForm_ChangePracownik(PRA_PracID, imieTB.Text, nazwiskoTB.Text, archiwalny, ref result))
                {
                    czyZmodyfikowano = true;
                    MessageBox.Show("Pracownik został zmodyfikowany.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd podczas edycji pracownika. Prosze spróbować ponownie.\n\nBłąd:" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Imię i nazwisko nie mogą być puste!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
