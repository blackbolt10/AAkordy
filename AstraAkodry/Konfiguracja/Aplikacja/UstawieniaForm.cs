using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AstraAkodry.Konfiguracja.Aplikacja
{
    public partial class UstawieniaForm : Form
    {
        private Font czcionka;

        public UstawieniaForm()
        {
            InitializeComponent();
        }

        private void UstawieniaForm_Shown(object sender, EventArgs e)
        {
            AktualizujOkno();

            nazwaLabel.Text = MainForm.czcionka.Name;
            rozmiarLabel.Text = MainForm.czcionka.Size.ToString();
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
            if(acceptButton.Enabled)
            {
                DialogResult result = MessageBox.Show("Czy chcesz zapisać zmiany?", "Zapytanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(result == DialogResult.Yes)
                {
                    acceptButton_Click(acceptButton, null);
                }
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void changeFontButton_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = MainForm.czcionka;
            DialogResult result = fontDialog1.ShowDialog();

            if(result == DialogResult.OK)
            {
                czcionka = fontDialog1.Font;

                nazwaLabel.Text = czcionka.Name;
                rozmiarLabel.Text = czcionka.Size.ToString();

                nazwaLabel.Font = czcionka;
                rozmiarLabel.Font = czcionka;
                
                acceptButton.Enabled = true;

                AktualizujOkno();
            }
        }

        private void AktualizujOkno()
        {
            acceptButton.Font = MainForm.czcionka;

            groupBox1.Font = MainForm.czcionka;
            groupBox1.Location = new Point(10, 10);

            naglowekNazwaLabel.Location = new Point(10, Convert.ToInt32(naglowekNazwaLabel.Font.Size+10));
            nazwaLabel.Location = new Point(naglowekNazwaLabel.Location.X+naglowekNazwaLabel.Size.Width+10, naglowekNazwaLabel.Location.Y);

            naglowekRozmiarLabel.Location = new Point(naglowekNazwaLabel.Location.X, nazwaLabel.Location.Y + nazwaLabel.Size.Height + 10);
            rozmiarLabel.Location = new Point(naglowekRozmiarLabel.Location.X+naglowekRozmiarLabel.Size.Width+10, naglowekRozmiarLabel.Location.Y);
            
            if(nazwaLabel.Size.Width > rozmiarLabel.Size.Width)
            {
                changeFontButton.Location = new Point(groupBox1.Size.Width-changeFontButton.Size.Width-10, rozmiarLabel.Location.Y + rozmiarLabel.Size.Height + 10);
            }
            else
            {
                changeFontButton.Location = new Point(groupBox1.Size.Width - changeFontButton.Size.Width - 10, rozmiarLabel.Location.Y + rozmiarLabel.Size.Height + 10);
            }

            groupBox1.Size = new Size(changeFontButton.Location.X + changeFontButton.Size.Width + 10, changeFontButton.Location.Y + changeFontButton.Size.Height - Convert.ToInt32(changeFontButton.Font.Size));

            AktualizujGroupBox2();
        }

        private void AktualizujGroupBox2()
        {
            groupBox2.Font = MainForm.czcionka;
            groupBox2.Location = new Point(10, groupBox1.Location.Y+groupBox1.Size.Height+10);

            obecneHasloLabel.Location = new Point(obecneHasloLabel.Location.X, Convert.ToInt32(naglowekNazwaLabel.Font.Size + 10));

            obecneHasloTB.Location = new Point(noweHaslo2Label.Location.X + noweHaslo2Label.Size.Width + 10, Convert.ToInt32(naglowekNazwaLabel.Font.Size + 10));
            noweHasloTB.Location = new Point(obecneHasloTB.Location.X, obecneHasloTB.Location.Y + obecneHasloTB.Size.Height + 10);
            noweHaslo2TB.Location = new Point(obecneHasloTB.Location.X, noweHasloTB.Location.Y + noweHasloTB.Size.Height + 10);

            noweHasloLabel.Location = new Point(obecneHasloLabel.Location.X, noweHasloTB.Location.Y);
            noweHaslo2Label.Location = new Point(obecneHasloLabel.Location.X, noweHaslo2TB.Location.Y);

            zmienButton.Location = new Point(groupBox2.Size.Width - zmienButton.Size.Width - 5, noweHaslo2TB.Location.Y + noweHaslo2TB.Size.Height + 10);
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = DialogResult.Yes;

            if(czcionka.Size>25)
            {
                dialogResult = MessageBox.Show("Rozmiar czcionki może powodować problemy z wyświetlaniem niektórych elementów aplikacji. \nZalecany rozmiar czcionki powinien być mniejszy niż 15.\n\nCzy mimo to chcesz zapisać?", "Zapytanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if(dialogResult == DialogResult.Yes)
            {
                DBRepository db = new DBRepository();
                String result = "";

                if(db.UstawieniaForm_ZapiszCzcionke(czcionka.Name, czcionka.Size, ref result))
                {
                    MessageBox.Show("Zapisano!\n\nZmiany wymagają ponownego uruchomienia aplikacji.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    acceptButton.Enabled = false;
                    MainForm.czcionka = this.czcionka;
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd podczas zapisywania czcionki:\n"+result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void zmienButton_Click(object sender, EventArgs e)
        {
            if(obecneHasloTB.Text == MainForm.hasloOperatora)
            {
                if(noweHasloTB.Text == noweHaslo2TB.Text)
                {
                    DBRepository db = new DBRepository();
                    String result = "";

                    if(db.UstawieniaForm_ZmienHaslo(noweHasloTB.Text, ref result))
                    {
                        MainForm.hasloOperatora = noweHasloTB.Text;
                        obecneHasloTB.Text = "";
                        noweHasloTB.Text = "";
                        noweHaslo2TB.Text = "";

                        MessageBox.Show("Hasło zostało zmienione", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Wystąpił błąd podczas zmiany hasła : " + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Nowe hasło jest niezgodne z powtórzonym.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    noweHasloTB.Focus();
                }
            }
            else
            {
                MessageBox.Show("Obecne hasło jest nieprawidłowe!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                obecneHasloTB.Focus();
            }
        }
    }
}
