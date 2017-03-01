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
    public partial class ZarzadzanieTestowymiForm : Form
    {
        public ZarzadzanieTestowymiForm()
        {
            InitializeComponent();

            ZaladujAkordyDGV();
        }

        private void ZarzadzanieTestowymiForm_Shown(object sender, EventArgs e)
        {
            archiwalneCHB.Font = MainForm.czcionka;
            akordyDGV.Font = MainForm.czcionka;

            archiwalneCHB.Location = new Point(archiwalneCHB.Location.X, zamknijButton.Location.Y + zamknijButton.Size.Height - archiwalneCHB.Size.Height);
            akordyDGV.Size = new Size(akordyDGV.Size.Width, zamknijButton.Location.Y - 20);
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

            if(db.ZarzadzanieTestowymiForm_ZaladujAkordyDGV(ref pomDataTable, archiwalneCHB.Checked, ref result))
            {
                if(pomDataTable.Rows.Count > 0)
                {
                    akordyDGV.DataSource = pomDataTable;

                    akordyDGV.Columns["AKT_Id"].Visible = false;
                    akordyDGV.Columns["AKT_AKRId"].Visible = false;
                    akordyDGV.Columns["AKT_DataDodania"].Visible = false;
                    akordyDGV.Columns["AKT_Nazwa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    akordyDGV.Columns["AKT_Archiwalny"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                    akordyDGV.CurrentCell = akordyDGV.Rows[0].Cells["AKT_Nazwa"];

                    changeButton.Enabled = true;
                    delButton.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Wystąpił błąd podczas wczytywania listy akordów: " + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AkordyTestoweChangeForm akrTestChangeForm = new AkordyTestoweChangeForm();
            akrTestChangeForm.ShowDialog();

            if(akrTestChangeForm.czyZmodyfikowano)
            {
                ZaladujAkordyDGV();
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            if(akordyDGV.CurrentCell != null)
            {
                String AKR_AkrId = akordyDGV.CurrentRow.Cells["AKT_AkrId"].Value.ToString();
                String AKR_Nazwa = akordyDGV.CurrentRow.Cells["AKT_Nazwa"].Value.ToString();
                String AKR_Archiwalny = akordyDGV.CurrentRow.Cells["AKT_Archiwalny"].Value.ToString();

                AkordyTestoweChangeForm akrTestChangeForm = new AkordyTestoweChangeForm(AKR_AkrId, AKR_Nazwa, AKR_Archiwalny);
                akrTestChangeForm.ShowDialog();

                if(akrTestChangeForm.czyZmodyfikowano)
                {
                    ZaladujAkordyDGV();
                }
            }
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            if(akordyDGV.CurrentCell != null)
            {
                String nazwaAkordu = akordyDGV.CurrentRow.Cells["AKT_Nazwa"].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz usunąć wskazany akord '" + nazwaAkordu + "'?", "Zapytanie", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if(dialogResult == DialogResult.OK)
                {
                    DBRepository db = new DBRepository();
                    String result = "";
                    if(db.ZarzadzanieTestowymiForm_UsunAkord(akordyDGV.CurrentRow.Cells["AKT_Id"].Value.ToString(), ref result))
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
    }
}
