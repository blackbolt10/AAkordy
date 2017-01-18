using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AstraAkodry.Produkcja.Raporty
{
    public partial class RaportyGlobalneProdukcjaForm : Form
    {
        public RaportyGlobalneProdukcjaForm()
        {
            InitializeComponent();
        }

        private void RaportyGlobalneProdukcjaForm_Shown(object sender, EventArgs e)
        {
            dataPoczLabel.Font = MainForm.czcionka;
            dataKonLabel.Font = MainForm.czcionka;
            raportLabel1.Font = MainForm.czcionka;
            raportDGV.Font = MainForm.czcionka;
            
            kalendarzPoczMC.Location = new Point(dataPoczLabel.Location.X, dataPoczLabel.Location.Y + dataPoczLabel.Size.Height + 10);
            dataKonLabel.Location = new Point(dataPoczLabel.Location.X, kalendarzPoczMC.Location.Y + kalendarzPoczMC.Size.Height + 10);
            kalendarzKonMC.Location = new Point(dataPoczLabel.Location.X, dataKonLabel.Location.Y + dataKonLabel.Size.Height + 10);

            if(kalendarzPoczMC.Size.Width > dataPoczLabel.Size.Width)
            {
                raportLabel1.Location = new Point(kalendarzPoczMC.Location.X + kalendarzPoczMC.Size.Width + 10, raportLabel1.Location.Y);
            }
            else
            {
                raportLabel1.Location = new Point(dataPoczLabel.Location.X + dataPoczLabel.Size.Width + 10, raportLabel1.Location.Y);
            }

            raportDGV.Location = new Point(raportLabel1.Location.X, raportLabel1.Location.Y + raportLabel1.Size.Height + 10);
            raportDGV.Size = new Size(zamknijButton.Location.X + zamknijButton.Size.Width - raportDGV.Location.X, zamknijButton.Location.Y - raportDGV.Location.Y-15);
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
            AktualizujKalendarzKonMC();
        }

        private void kalendarzKonMC_DateChanged(object sender, DateRangeEventArgs e)
        {
            WyczyscRaportDGV();
            AktualizujKalendarzPoczMC();
        }

        private void AktualizujKalendarzKonMC()
        {
            if(kalendarzPoczMC.SelectionStart > kalendarzKonMC.SelectionStart)
            {
                kalendarzKonMC.SelectionStart = kalendarzPoczMC.SelectionStart;
            }
        }

        private void AktualizujKalendarzPoczMC()
        {
            if(kalendarzKonMC.SelectionStart < kalendarzPoczMC.SelectionStart)
            {
                kalendarzPoczMC.SelectionStart = kalendarzKonMC.SelectionStart;
            }
        }

        private void WyczyscRaportDGV()
        {
            raportDGV.DataSource = null;
            raportDGV.Rows.Clear();
            raportDGV.Columns.Clear();

            raportLabel1.Text = "Raport:";
        }

        private void ponizejNormyButton_Click(object sender, EventArgs e)
        {
            WyczyscRaportDGV();

            DBRepository db = new DBRepository();
            DataTable pomDataTable = new DataTable();
            String result = "";

            if(db.RaportyGlobalneProdukcjaForm_ZaladujRaportPonizejNormy(kalendarzPoczMC.SelectionStart.ToShortDateString(), kalendarzKonMC.SelectionStart.ToShortDateString(), ref pomDataTable, ref result))
            {
                raportDGV.DataSource = pomDataTable;
                raportLabel1.Text = "Raport poniżej 100% normy:";

                raportDGV.Columns["PRA_PracId"].Visible = false;
                raportDGV.Columns["Nazwisko"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                raportDGV.Columns["Imię"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                MessageBox.Show("Wystapił błąd podczas generowania raportu:\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lenieButton_Click(object sender, EventArgs e)
        {
            WyczyscRaportDGV();

            DBRepository db = new DBRepository();
            DataTable pomDataTable = new DataTable();
            String result = "";

            if(db.RaportyGlobalneProdukcjaForm_ZaladujRaportLeni(kalendarzPoczMC.SelectionStart.ToShortDateString(), kalendarzKonMC.SelectionStart.ToShortDateString(), ref pomDataTable, ref result))
            {
                raportDGV.DataSource = pomDataTable;
                raportLabel1.Text = "Raport \"leni\":";
                raportDGV.Columns["Pracownik"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                MessageBox.Show("Wystapił błąd podczas generowania raportu:\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void globalnyButton_Click(object sender, EventArgs e)
        {
            WyczyscRaportDGV();

            DBRepository db = new DBRepository();
            DataTable pomDataTable = new DataTable();
            String result = "";

            if(db.RaportyGlobalneProdukcjaForm_ZaladujRaportGlobalny(kalendarzPoczMC.SelectionStart.ToShortDateString(), kalendarzKonMC.SelectionStart.ToShortDateString(), ref pomDataTable, ref result))
            {
                raportDGV.DataSource = pomDataTable;
                raportLabel1.Text = "Raport globalny:";

                raportDGV.Columns["PRA_PracId"].Visible = false;
                raportDGV.Columns["Nazwisko"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                raportDGV.Columns["Imię"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                MessageBox.Show("Wystapił błąd podczas generowania raportu:\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
