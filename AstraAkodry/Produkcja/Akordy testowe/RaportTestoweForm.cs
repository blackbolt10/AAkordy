using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AstraAkodry.Produkcja.Akordy_testowe
{
    public partial class RaportTestoweForm : Form
    {
        public RaportTestoweForm()
        {
            InitializeComponent();

            ZaladujRaportDGV();
        }

        private void RaportTestoweForm_Shown(object sender, EventArgs e)
        {
            dataOdLabel.Font = MainForm.czcionka;
            dataDoLabel.Font = MainForm.czcionka;
            raportLabel.Font = MainForm.czcionka;
            raportDGV.Font = MainForm.czcionka;

            kalendarzPoczMC.Location = new Point(dataOdLabel.Location.X, dataOdLabel.Location.Y + dataOdLabel.Size.Height + 10);
            dataDoLabel.Location = new Point(dataOdLabel.Location.X, kalendarzPoczMC.Location.Y + kalendarzPoczMC.Size.Height + 10);
            kalendarzKonMC.Location = new Point(dataOdLabel.Location.X, dataDoLabel.Location.Y + dataDoLabel.Size.Height + 10);

            if(kalendarzPoczMC.Size.Width > dataOdLabel.Size.Width)
            {
                raportLabel.Location = new Point(kalendarzPoczMC.Location.X + kalendarzPoczMC.Size.Width + 10, raportLabel.Location.Y);
            }
            else
            {
                raportLabel.Location = new Point(dataOdLabel.Location.X + dataOdLabel.Size.Width + 10, raportLabel.Location.Y);
            }

            raportDGV.Location = new Point(raportLabel.Location.X, raportLabel.Location.Y + raportLabel.Size.Height + 10);
            raportDGV.Size = new Size(zamknijButton.Location.X + zamknijButton.Size.Width - raportDGV.Location.X, zamknijButton.Location.Y - raportDGV.Location.Y - 15);
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

        private void kalendarzPoczMC_DateChanged(object sender, DateRangeEventArgs e)
        {
            WyczyscRaportDGV();

            if(kalendarzKonMC.SelectionStart < kalendarzPoczMC.SelectionStart)
            {
                kalendarzPoczMC.SelectionStart = kalendarzKonMC.SelectionStart;
            }
        }

        private void kalendarzKonMC_DateChanged(object sender, DateRangeEventArgs e)
        {
            WyczyscRaportDGV();

            if(kalendarzPoczMC.SelectionStart > kalendarzKonMC.SelectionStart)
            {
                kalendarzKonMC.SelectionStart = kalendarzPoczMC.SelectionStart;
            }
        }

        private void WyczyscRaportDGV()
        {
            raportDGV.DataSource = null;
            raportDGV.Rows.Clear();
            raportDGV.Columns.Clear();

            raportLabel.Text = "Raport:";
        }

        private void ZaladujRaportDGV()
        {
            WyczyscRaportDGV();

            DBRepository db = new DBRepository();
            String result = "";
            DataTable pomDataTable = new DataTable();

            if(db.RaportTestoweForm_ZaladujRaportDGV(kalendarzPoczMC.SelectionStart.ToShortDateString(), kalendarzKonMC.SelectionStart.ToShortDateString(), ref pomDataTable, ref result))
            {
                raportDGV.DataSource = pomDataTable;

                if(raportDGV.Columns.Count>0)
                {
                    raportDGV.Columns["WAT_AkrId"].Visible = false;
                    raportDGV.Columns["AKT_Nazwa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    raportDGV.Columns["WAT_Wartosc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    raportDGV.Columns["WAT_Czas"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            else
            {
                MessageBox.Show("Wystąpił błąd wczytywania raportu:\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            ZaladujRaportDGV();
        }
    }
}
