using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AstraAkodry.Konfiguracja.Ustawienia.Operatorzy
{
    public partial class OperatorzyChangeForm : Form
    {
        public Boolean czyZmodyfikowano = false;
        private String OPR_OprId;

        public OperatorzyChangeForm()
        {
            InitializeComponent();
            uprawnieniaCB.SelectedIndex = 0;
        }

        public OperatorzyChangeForm(String opr_OprId, String opr_Imie, String opr_Nazwisko, String opr_Uprawnienia, String opr_Archiwalny)
        {
            InitializeComponent();

            this.Text = "Edytuj operatora";

            OPR_OprId = opr_OprId;
            imieTB.Text = opr_Imie;
            nazwiskoTB.Text = opr_Nazwisko;

            uprawnieniaCB.SelectedIndex = 0;
            AktualizujUprawnieniaCB(opr_Uprawnienia);

            if(opr_Archiwalny == "1")
            {
                archiwalnyCB.Checked = true;
            }

            akceptujButton.Click -= akceptujButton_Click;
            akceptujButton.Click += zmienButton_Click;
        }

        private void OperatorzyChangeForm_Shown(object sender, EventArgs e)
        {
            imieLabel.Font = MainForm.czcionka;
            imieTB.Font = MainForm.czcionka;
            nazwiskoLabel.Font = MainForm.czcionka;
            nazwiskoTB.Font = MainForm.czcionka;
            uprawnieniaLabel.Font = MainForm.czcionka;
            uprawnieniaCB.Font = MainForm.czcionka;
            archiwalnyCB.Font = MainForm.czcionka;

            imieTB.Location = new Point(uprawnieniaLabel.Location.X + uprawnieniaLabel.Size.Width + 10, imieTB.Location.Y);
            nazwiskoTB.Location = new Point(uprawnieniaLabel.Location.X + uprawnieniaLabel.Size.Width + 10, imieTB.Location.Y+ imieTB.Size.Height+10);
            uprawnieniaCB.Location = new Point(uprawnieniaLabel.Location.X + uprawnieniaLabel.Size.Width + 10, nazwiskoTB.Location.Y + nazwiskoTB.Size.Height + 10);

            nazwiskoLabel.Location = new Point(nazwiskoLabel.Location.X, nazwiskoTB.Location.Y);
            uprawnieniaLabel.Location = new Point(uprawnieniaLabel.Location.X, uprawnieniaCB.Location.Y);

            archiwalnyCB.Location = new Point(archiwalnyCB.Location.X, uprawnieniaCB.Location.Y + uprawnieniaCB.Size.Height + 10);

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

        private void AktualizujUprawnieniaCB(string opr_Uprawnienia)
        {
            try
            {
                Int32 uprawnieniaID = Convert.ToInt32(opr_Uprawnienia);
                if(uprawnieniaID>-1&&uprawnieniaID<3)
                {
                    uprawnieniaCB.SelectedIndex = uprawnieniaID+1;
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show("Wystapił błąd podczas wczytywania pola uprawnienia. Proszę o wskazanie uprawnień ręcznie.\n\nBłąd:" + exc.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                if(db.OperatorzyChangeForm_AddNewOperator(imieTB.Text,nazwiskoTB.Text,(uprawnieniaCB.SelectedIndex-1), archiwalny, ref result))
                {
                    czyZmodyfikowano = true;
                    MessageBox.Show("Nowy operator został dodany. Logowanie odbywa się bez podawania hasła.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd podczas dodawnia nowego operatora. Prosze spróbować ponownie.\n\nBłąd:"+result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                if(db.OperatorzyChangeForm_ChangeOperator(OPR_OprId, imieTB.Text, nazwiskoTB.Text, (uprawnieniaCB.SelectedIndex - 1), archiwalny, ref result))
                {
                    czyZmodyfikowano = true;
                    MessageBox.Show("Operator został zmodyfikowany.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd podczas edycji operatora. Prosze spróbować ponownie.\n\nBłąd:" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Imię i nazwisko nie mogą być puste!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
