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
    public partial class AkordyForm : Form
    {
        public AkordyForm()
        {
            InitializeComponent();
        }

        private void AkordyForm_Shown(object sender, EventArgs e)
        {
            ZaladujAkordyDGV();
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
            ZaladujAkordyDGV();
        }

        private void ZaladujAkordyDGV()
        {
            akordyDGV.DataSource = null;
            akordyDGV.Rows.Clear();
            akordyDGV.Columns.Clear();

            changeButton.Enabled = false;
            delButton.Enabled = false;

            DBRepository db = new DBRepository();
            String result = "";
            DataTable pomDataTable = new DataTable();

            if(db.AkordyForm_ZaladujAkordyDGV(ref pomDataTable, archiwalneCHB.Checked, ref result))
            {
                if(pomDataTable.Rows.Count > 0)
                {
                    akordyDGV.DataSource = pomDataTable;

                    akordyDGV.Columns["AKR_Id"].Visible = false;
                    akordyDGV.Columns["AKR_AKRId"].Visible = false;
                    akordyDGV.Columns["AKR_DataDodania"].Visible = false;
                    akordyDGV.Columns["AKR_Nazwa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    akordyDGV.Columns["AKR_Norma"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    akordyDGV.Columns["AKR_Archiwalny"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                    akordyDGV.CurrentCell = akordyDGV.Rows[0].Cells["AKR_Nazwa"];

                    changeButton.Enabled = true;
                    delButton.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Wystąpił błąd podczas wczytywania listy akordów: " + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            if(akordyDGV.CurrentCell != null)
            {
                String nazwaAkordu = akordyDGV.CurrentRow.Cells["AKR_Nazwa"].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz usunąć wskazany akord '" + nazwaAkordu + "'?", "Zapytanie", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if(dialogResult == DialogResult.OK)
                {
                    DBRepository db = new DBRepository();
                    String result = "";
                    if(db.AkordyForm_UsunAkord(akordyDGV.CurrentRow.Cells["AKR_Id"].Value.ToString(), ref result))
                    {
                        MessageBox.Show("Usunięto '" + nazwaAkordu + "'.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ZaladujAkordyDGV();
                    }
                    else
                    {
                        MessageBox.Show("Wystapił błąd podczas usuwania akordu '" + nazwaAkordu + "': " + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            if(akordyDGV.CurrentCell != null)
            {
                if(akordyDGV.CurrentRow.Cells["AKR_AkrId"].Value.ToString() != "0")
                {
                    String AKR_AkrId = akordyDGV.CurrentRow.Cells["AKR_AkrId"].Value.ToString();
                    String AKR_Nazwa = akordyDGV.CurrentRow.Cells["AKR_Nazwa"].Value.ToString();
                    String AKR_Norma = akordyDGV.CurrentRow.Cells["AKR_Norma"].Value.ToString();
                    String AKR_Archiwalny = akordyDGV.CurrentRow.Cells["AKR_Archiwalny"].Value.ToString();

                    AkordyChangeForm akrChangeForm = new AkordyChangeForm(AKR_AkrId, AKR_Nazwa, AKR_Norma, AKR_Archiwalny);
                    akrChangeForm.ShowDialog();

                    if(akrChangeForm.czyZmodyfikowano)
                    {
                        ZaladujAkordyDGV();
                    }
                }
                else
                {
                    MessageBox.Show("Czas pracy nie może zostać zmieniony.", "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AkordyChangeForm akrChangeForm = new AkordyChangeForm();
            akrChangeForm.ShowDialog();

            if(akrChangeForm.czyZmodyfikowano)
            {
                ZaladujAkordyDGV();
            }
        }
    }
}
