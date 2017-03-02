using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AstraAkodry.Recepcja
{
    public partial class RaportDziennyTestowychForm : Form
    {
        private DataTable akordyDT;

        public RaportDziennyTestowychForm()
        {
            InitializeComponent();

            ZaladujAkordyCB();
            ZaladujRaportDGV();
        }

        private void RaportDziennyTestowychForm_Shown(object sender, EventArgs e)
        {
            dataOdLabel.Font = MainForm.czcionka;

            kalendarzMC.Location = new Point(dataOdLabel.Location.X, dataOdLabel.Location.Y + dataOdLabel.Size.Height + 10);

            if(kalendarzMC.Size.Width > dataOdLabel.Size.Width)
            {
                raportLabel.Location = new Point(kalendarzMC.Location.X + kalendarzMC.Size.Width + 10, raportLabel.Location.Y);
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

        private void kalendarzMC_DateChanged(object sender, DateRangeEventArgs e)
        {
            ZaladujRaportDGV();
        }

        private void WyczyscRaportDGV()
        {
            raportDGV.DataSource = null;
            raportDGV.Rows.Clear();
            raportDGV.Columns.Clear();
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            ZaladujRaportDGV();
        }

        private void ZaladujAkordyCB()
        {
            akordCB.Items.Clear();

            DBRepository db = new DBRepository();
            String result = "";

            if(db.RaportDziennyForm_ZaladujAkordyCB(ref akordyDT, ref result))
            {
                for(int i = 0; i < akordyDT.Rows.Count; i++)
                {
                    akordCB.Items.Add(akordyDT.Rows[i]["AKT_Nazwa"].ToString());
                }

                if(akordCB.Items.Count>0)
                {
                    akordCB.SelectedIndex = 0;
                }
            }
            else  
            {
                MessageBox.Show("Wystąpił błąd wczytywania listy akordów:\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ZaladujRaportDGV()
        {
            WyczyscRaportDGV();

            DBRepository db = new DBRepository();
            String result = "";
            DataTable pomDataTable = new DataTable();
            String akr_AkrId = akordyDT.Rows[akordCB.SelectedIndex]["AKT_AkrId"].ToString();

            if(db.RaportDziennyForm_ZaladujRaportDGV(akr_AkrId, kalendarzMC.SelectionStart.ToShortDateString(), ref pomDataTable, ref result))
            {
                raportDGV.DataSource = pomDataTable;

                if(raportDGV.Columns.Count>0)
                {
                    raportDGV.Columns["Imię"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    raportDGV.Columns["Nazwisko"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    raportDGV.Columns["Nazwa akordu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    raportDGV.Columns["Wartość"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    raportDGV.Columns["Czas"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            else
            {
                MessageBox.Show("Wystąpił błąd wczytywania raportu:\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void akordCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZaladujRaportDGV();
        }
    }
}
