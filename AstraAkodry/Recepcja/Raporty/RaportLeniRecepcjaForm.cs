using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AstraAkodry.Recepcja.Raporty
{
    public partial class RaportLeniRecepcjaForm : Form
    {
        private DateTime dataOd;
        private DateTime dataDo;

        public RaportLeniRecepcjaForm()
        {
            InitializeComponent();
        }

        private void RaportLeniRecepcjaForm_Shown(object sender, EventArgs e)
        {
            dataDTP_ValueChanged(dataDTP, null);

            naglowekLabel.Font = MainForm.czcionka;
            dataLabel.Font = MainForm.czcionka;
            dataDTP.Font = MainForm.czcionka;
            raportDGV.Font = MainForm.czcionka;

            dataLabel.Location = new Point(dataLabel.Location.X, this.Height - dataLabel.Size.Height - 15);
            dataDTP.Location = new Point(dataLabel.Location.X+dataLabel.Size.Width+10, dataLabel.Location.Y);
            reloadButton.Location = new Point(dataDTP.Location.X + dataDTP.Size.Width + 10, dataLabel.Location.Y);

            raportDGV.Location = new Point(naglowekLabel.Location.X, naglowekLabel.Location.Y + naglowekLabel.Size.Height + 10);
            raportDGV.Size = new Size(raportDGV.Size.Width, dataDTP.Location.Y-raportDGV.Location.Y-10);
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

        private void dataDTP_ValueChanged(object sender, EventArgs e)
        {
            dataOd = new DateTime(dataDTP.Value.Year, dataDTP.Value.Month, 01);
            dataDo = new DateTime(dataDTP.Value.Year, dataDTP.Value.Month, DateTime.DaysInMonth(dataDTP.Value.Year, dataDTP.Value.Month));

            naglowekLabel.Text = "Raport \"leni\" za okres od "+ dataOd.ToShortDateString() + " do "+ dataDo.ToShortDateString();
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            raportDGV.DataSource = null;
            raportDGV.Rows.Clear();
            raportDGV.Columns.Clear();

            String result = "";
            DataTable pomDataTable = new DataTable();
            DBRepository db = new DBRepository();

            if(db.RaportLeniRecepcjaForm_ZaladujRaportDGV(dataOd.ToShortDateString(), dataDo.ToShortDateString(), ref pomDataTable, ref result))
            {
                if(pomDataTable != null)
                {
                    raportDGV.DataSource = pomDataTable;
                    raportDGV.Columns["Pracownik"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            else
            {
                MessageBox.Show("Wystąpił błąd podczas wczytywania raportu: " + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
