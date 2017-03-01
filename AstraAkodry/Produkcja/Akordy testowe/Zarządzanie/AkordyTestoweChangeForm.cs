using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AstraAkodry.Produkcja.Akordy_testowe.Zarządzanie
{
    public partial class AkordyTestoweChangeForm : Form
    {
        public bool czyZmodyfikowano;
        private string AKR_AkrId;

        public AkordyTestoweChangeForm()
        {
            InitializeComponent();
        }

        public AkordyTestoweChangeForm(string aKR_AkrId, string aKR_Nazwa, string aKR_Archiwalny)
        {
            InitializeComponent();

            this.Text = "Edytuj akord";

            this.AKR_AkrId = aKR_AkrId;
            nazwaTB.Text = aKR_Nazwa;

            if(aKR_Archiwalny == "1")
            {
                archiwalnyCB.Checked = true;
            }

            akceptujButton.Click -= akceptujButton_Click;
            akceptujButton.Click += zmienButton_Click;
        }

        private void zamknijButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void akceptujButton_Click(object sender, EventArgs e)
        {
            if(nazwaTB.Text != "")
            {
                DBRepository db = new DBRepository();
                String result = "";
                String archiwalny = "0";

                if(archiwalnyCB.Checked)
                {
                    archiwalny = "1";
                }

                if(db.AkordyTestoweChangeForm_AddAkord(nazwaTB.Text, archiwalny, ref result))
                {
                    czyZmodyfikowano = true;
                    MessageBox.Show("Nowy akord testowy został dodany.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd podczas dodawnia nowego akordu testowego. Prosze spróbować ponownie.\n\nBłąd:" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nazwa nie może być pusta!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void zmienButton_Click(object sender, EventArgs e)
        {
            if(nazwaTB.Text != "")
            {
                DBRepository db = new DBRepository();
                String result = "";
                String archiwalny = "0";

                if(archiwalnyCB.Checked)
                {
                    archiwalny = "1";
                }

                if(db.AkordyTestoweChangeForm_ChangeAkord(AKR_AkrId, nazwaTB.Text, archiwalny, ref result))
                {
                    czyZmodyfikowano = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd podczas edycji akordu testowego. Prosze spróbować ponownie.\n\nBłąd:" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nazwa nie może być pusta!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
