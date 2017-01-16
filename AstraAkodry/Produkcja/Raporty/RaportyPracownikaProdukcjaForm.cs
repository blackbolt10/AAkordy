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
    public partial class RaportyPracownikaProdukcjaForm : Form
    {
        private DataTable pracownicyDT;
        private Int32 idRaportu;


        public RaportyPracownikaProdukcjaForm()
        {
            InitializeComponent();

            idRaportu = -1;

            ZaladujPracownicyDT();
        }

        private void RaportyPracownikaProdukcjaForm_Shown(object sender, EventArgs e)
        {
            pracownicyLabel.Location = new Point(kalendarzPoczMC.Location.X+kalendarzPoczMC.Size.Width+10, pracownicyLabel.Location.Y);
            pracownicyCB.Location = new Point(kalendarzPoczMC.Location.X + kalendarzPoczMC.Size.Width + 10, pracownicyCB.Location.Y);
            pracownicyLB.Location = new Point(kalendarzPoczMC.Location.X + kalendarzPoczMC.Size.Width + 10, pracownicyLB.Location.Y);

            raportLabel.Location = new Point(pracownicyCB.Location.X + pracownicyCB.Size.Width + 10, raportLabel.Location.Y);
            raportDGV.Location = new Point(raportLabel.Location.X, raportDGV.Location.Y);
            raportDGV.Size = new Size(zamknijButton.Location.X + zamknijButton.Size.Width - raportDGV.Location.X, raportDGV.Size.Height);
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

            raportLabel.Text = "Raport:";
        }

        private void ZaladujPracownicyDT()
        {
            procentNormyButton.Enabled = false;
            szczegolowyButton.Enabled = false;
            zbiorczyButton.Enabled = false;

            pracownicyCB.Items.Clear();
            pracownicyLB.Items.Clear();

            DBRepository db = new DBRepository();
            String result = "";
            pracownicyDT = new DataTable();

            if(db.RaportyPracownikaProdukcjaForm_ZaladujListePracownikow(ref pracownicyDT, ref result))
            {
                if(pracownicyDT.Rows.Count > 0)
                {
                    for(int i = 0; i < pracownicyDT.Rows.Count; i++)
                    {
                        if(pracownicyDT.Rows[i]["PRA_Archiwalny"].ToString() != "1")
                        {
                            pracownicyCB.Items.Add(pracownicyDT.Rows[i]["PRA_Nazwisko"] + " " + pracownicyDT.Rows[i]["PRA_Imie"]);
                            pracownicyLB.Items.Add(pracownicyDT.Rows[i]["PRA_Nazwisko"] + " " + pracownicyDT.Rows[i]["PRA_Imie"]);
                        }
                    }
                    pracownicyLB.SelectedIndex = 0;

                    procentNormyButton.Enabled = true;
                    szczegolowyButton.Enabled = true;
                    zbiorczyButton.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Wystąpił błąd podczas wczytywania listy pracowników: \n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pracownicyCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            pracownicyLB.SelectedIndex = pracownicyCB.SelectedIndex;
            ZaladujRaportDGV();
        }

        private void pracownicyLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            pracownicyCB.SelectedIndex = pracownicyLB.SelectedIndex;
            ZaladujRaportDGV();
        }

        private void ZaladujRaportDGV()
        {
            if(pracownicyLB.SelectedIndex > -1)
            {
                switch(idRaportu)
                {
                    case 0:
                    WyliczProcentNormy();
                    break;

                    case 1:
                    GenerujRaportSzczegolowy();
                    break;

                    case 2:
                    GenerujRaportZbiorczy();
                    break;
                }
            }
        }

        private void WyliczProcentNormy()
        {
            Cursor.Current = Cursors.WaitCursor;
            WyczyscRaportDGV();

            DBRepository db = new DBRepository();
            String idPracownika = pracownicyDT.Rows[pracownicyLB.SelectedIndex]["PRA_PracId"].ToString();
            String result = "";

            if(db.RaportyPracownikaProdukcjaForm_WyliczProcentNormy(idPracownika, kalendarzPoczMC.SelectionStart.ToShortDateString(), kalendarzKonMC.SelectionStart.ToShortDateString(), ref result))
            {
                raportLabel.Text = "Procent normy:";

                raportDGV.Columns.Add("Procent", "Procent");
                raportDGV.Rows.Add();
                raportDGV.Rows[0].Cells[0].Value = result;
                raportDGV.Columns["Procent"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            else
            {
                MessageBox.Show("Wystapił błąd podczas generowania raportu:\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private void GenerujRaportSzczegolowy()
        {
            Cursor.Current = Cursors.WaitCursor;
            WyczyscRaportDGV();

            DBRepository db = new DBRepository();
            DataTable pomDataTable = new DataTable();
            String idPracownika = pracownicyDT.Rows[pracownicyLB.SelectedIndex]["PRA_PracId"].ToString();
            String result = "";

            if(db.RaportyPracownikaProdukcjaForm_ZaladujRaportSzczegolowy(idPracownika, kalendarzPoczMC.SelectionStart.ToShortDateString(), kalendarzKonMC.SelectionStart.ToShortDateString(), ref pomDataTable, ref result))
            {
                raportDGV.DataSource = pomDataTable;
                raportLabel.Text = "Raport szczegółowy:";

                raportDGV.Columns["PRA_PracId"].Visible = false;
                raportDGV.Columns["Nazwisko"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                raportDGV.Columns["Imię"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                MessageBox.Show("Wystapił błąd podczas generowania raportu:\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private void GenerujRaportZbiorczy()
        {
            Cursor.Current = Cursors.WaitCursor;
            WyczyscRaportDGV();

            DBRepository db = new DBRepository();
            DataTable pomDataTable = new DataTable();
            String idPracownika = pracownicyDT.Rows[pracownicyLB.SelectedIndex]["PRA_PracId"].ToString();
            String result = "";

            if(db.RaportyPracownikaProdukcjaForm_ZaladujRaportZbiorczy(idPracownika, kalendarzPoczMC.SelectionStart.ToShortDateString(), kalendarzKonMC.SelectionStart.ToShortDateString(), ref pomDataTable, ref result))
            {
                raportDGV.DataSource = pomDataTable;
                raportLabel.Text = "Raport zbiorczy:";

                raportDGV.Columns["Nazwa akordu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                MessageBox.Show("Wystapił błąd podczas generowania raportu:\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private void procentNormyButton_Click(object sender, EventArgs e)
        {
            idRaportu = 0;
            WyliczProcentNormy();
        }

        private void szczegolowyButton_Click(object sender, EventArgs e)
        {
            idRaportu = 1;
            GenerujRaportSzczegolowy();
        }

        private void zbiorczyButton_Click(object sender, EventArgs e)
        {
            idRaportu = 2;
            GenerujRaportZbiorczy();
        }
    }
}
