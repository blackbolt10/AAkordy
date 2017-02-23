using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AstraAkodry.Konfiguracja.Baza
{
    public partial class NieaktywPracForm : Form
    {
        public NieaktywPracForm()
        {
            InitializeComponent();

            ZaladujRaportDGV();
        }

        private void NieaktywPracForm_Shown(object sender, EventArgs e)
        {
            raportDGV.Font = MainForm.czcionka;
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

        private void ZaladujRaportDGV()
        {
            DataTable pomDataTable = new DataTable();
            String result = "";
            DBRepository db = new DBRepository();

            delButton.Enabled = false;

            if(db.NieaktywPracForm_ZaladujRaportDGV(ref pomDataTable, ref result))
            {
                raportDGV.DataSource = pomDataTable;

                if(raportDGV.Columns.Count>0)
                {
                    raportDGV.Columns["WAK_PracId"].Visible = false;
                    raportDGV.Columns["pra_Imie"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    raportDGV.Columns["pra_Nazwisko"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    raportDGV.Columns["Ostatnia data"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                if(raportDGV.Rows.Count>0)
                {
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
            if(raportDGV.CurrentCell != null)
            {
                PotwierdzenieUsunieciaForm potwierdzUsunForm = new PotwierdzenieUsunieciaForm(raportDGV.CurrentRow.Cells["pra_Imie"].Value.ToString(), raportDGV.CurrentRow.Cells["pra_Nazwisko"].Value.ToString());
                potwierdzUsunForm.ShowDialog();

                if(potwierdzUsunForm.usun)
                {
                    DBRepository db = new DBRepository();
                    String result = "";

                    if(db.NieaktywPracForm_UsunPracownika(raportDGV.CurrentRow.Cells["WAK_PracId"].Value.ToString(), ref result))
                    {
                        ZaladujRaportDGV();
                    }
                    else
                    {
                        MessageBox.Show("Wystąpił błąd podczas usuwania pracownika, proszę spróbować później.\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
