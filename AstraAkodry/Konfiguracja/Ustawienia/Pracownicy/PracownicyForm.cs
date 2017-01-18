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
    public partial class PracownicyForm : Form
    {
        public PracownicyForm()
        {
            InitializeComponent();

            ZaladujPracownicyDGV();
        }

        private void PracownicyForm_Shown(object sender, EventArgs e)
        {
            archiwalneCHB.Font = MainForm.czcionka;
            pracownicyDGV.Font = MainForm.czcionka;

            archiwalneCHB.Location = new Point(archiwalneCHB.Location.X, zamknijButton.Location.Y + zamknijButton.Size.Height - archiwalneCHB.Size.Height);
            pracownicyDGV.Size = new Size(pracownicyDGV.Size.Width, archiwalneCHB.Location.Y - 10);
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

        private void archiwalneCHB_CheckedChanged(object sender, EventArgs e)
        {
            ZaladujPracownicyDGV();
        }

        private void ZaladujPracownicyDGV()
        {
            pracownicyDGV.DataSource = null;
            pracownicyDGV.Rows.Clear();
            pracownicyDGV.Columns.Clear();

            changeButton.Enabled = false;
            delButton.Enabled = false;

            DBRepository db = new DBRepository();
            String result = "";
            DataTable pomDataTable = new DataTable();

            if(db.PracownicyForm_ZaladujPracownicyDGV(ref pomDataTable, archiwalneCHB.Checked, ref result))
            {
                if(pomDataTable.Rows.Count > 0)
                {
                    pracownicyDGV.DataSource = pomDataTable;

                    pracownicyDGV.Columns["PRA_PracID"].Visible = false;
                    pracownicyDGV.Columns["PRA_Imie"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    pracownicyDGV.Columns["PRA_Nazwisko"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    pracownicyDGV.Columns["PRA_DataZatrudnienia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    pracownicyDGV.Columns["PRA_Archiwalny"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                    pracownicyDGV.CurrentCell = pracownicyDGV.Rows[0].Cells["PRA_Imie"];

                    changeButton.Enabled = true;
                    delButton.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Wystąpił błąd podczas wczytywania listy pracowników: " + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            if(pracownicyDGV.CurrentCell != null)
            {
                String nazwaPracownika = pracownicyDGV.CurrentRow.Cells["PRA_Imie"].Value.ToString() +" "+ pracownicyDGV.CurrentRow.Cells["PRA_Nazwisko"].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz usunąć wskazany akord '" + nazwaPracownika + "'?", "Zapytanie", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if(dialogResult == DialogResult.OK)
                {
                    DBRepository db = new DBRepository();
                    String result = "";
                    if(db.PracownicyForm_UsunPracownika(pracownicyDGV.CurrentRow.Cells["PRA_PracID"].Value.ToString(), ref result))
                    {
                        MessageBox.Show("Usunięto '" + nazwaPracownika + "'.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ZaladujPracownicyDGV();
                    }
                    else
                    {
                        MessageBox.Show("Wystapił błąd podczas usuwania pracownika '" + nazwaPracownika + "': " + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            if(pracownicyDGV.CurrentCell != null)
            {
                String PRA_PracID = pracownicyDGV.CurrentRow.Cells["PRA_PracID"].Value.ToString();
                String PRA_Imie = pracownicyDGV.CurrentRow.Cells["PRA_Imie"].Value.ToString();
                String PRA_Nazwisko = pracownicyDGV.CurrentRow.Cells["PRA_Nazwisko"].Value.ToString();
                String PRA_Archiwalny = pracownicyDGV.CurrentRow.Cells["PRA_Archiwalny"].Value.ToString();

                PracownicyChangeForm praChangeForm = new PracownicyChangeForm(PRA_PracID, PRA_Imie, PRA_Nazwisko, PRA_Archiwalny);
                praChangeForm.ShowDialog();

                if(praChangeForm.czyZmodyfikowano)
                {
                    ZaladujPracownicyDGV();
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            PracownicyChangeForm praChangeForm = new PracownicyChangeForm();
            praChangeForm.ShowDialog();

            if(praChangeForm.czyZmodyfikowano)
            {
                ZaladujPracownicyDGV();
            }
        }
    }
}
