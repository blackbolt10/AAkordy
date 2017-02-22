using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OfficeOpenXml;
using System.IO;

namespace AstraAkodry.Produkcja.Raporty
{
    public partial class RaportyPracownikaProdukcjaForm : Form
    {
        private DataTable pracownicyDT;
        private Int32 idRaportu;
        private Int32 rozmiarTekstu;


        public RaportyPracownikaProdukcjaForm()
        {
            InitializeComponent();

            idRaportu = -1;

            ZaladujPracownicyDT();
        }

        private void RaportyPracownikaProdukcjaForm_Shown(object sender, EventArgs e)
        {
            dataPoczLabel.Font = MainForm.czcionka;
            dataKonLabel.Font = MainForm.czcionka;
            pracownicyLabel.Font = MainForm.czcionka;
            pracownicyCB.Font = MainForm.czcionka;
            pracownicyLB.Font = MainForm.czcionka;
            raportLabel.Font = MainForm.czcionka;
            raportDGV.Font = MainForm.czcionka;

            kalendarzPoczMC.Location = new Point(dataPoczLabel.Location.X, dataPoczLabel.Location.Y + dataPoczLabel.Size.Height + 10);
            dataKonLabel.Location = new Point(dataPoczLabel.Location.X, kalendarzPoczMC.Location.Y + kalendarzPoczMC.Size.Height + 10);
            kalendarzKonMC.Location = new Point(dataPoczLabel.Location.X, dataKonLabel.Location.Y + dataKonLabel.Size.Height + 10);

            if(kalendarzPoczMC.Size.Width > dataPoczLabel.Size.Width)
            {
                pracownicyLabel.Location = new Point(kalendarzPoczMC.Location.X + kalendarzPoczMC.Size.Width + 10, pracownicyLabel.Location.Y);
            }
            else
            {
                pracownicyLabel.Location = new Point(dataPoczLabel.Location.X + dataPoczLabel.Size.Width + 10, pracownicyLabel.Location.Y);
            }

            pracownicyCB.Location = new Point(pracownicyLabel.Location.X, pracownicyLabel.Location.Y+ pracownicyLabel.Size.Height+10);
            pracownicyCB.DropDownHeight = this.Height - pracownicyCB.Location.Y;
            pracownicyLB.Location = new Point(pracownicyLabel.Location.X, pracownicyCB.Location.Y + pracownicyCB.Size.Height + 10);
            pracownicyCB.Size = new Size((Int32)(rozmiarTekstu * MainForm.czcionka.Size * 0.75), pracownicyLabel.Size.Height + 10);
            pracownicyLB.Size = new Size((Int32)(rozmiarTekstu * MainForm.czcionka.Size * 0.75), zamknijButton.Location.Y - pracownicyLB.Location.Y - 15);

            raportLabel.Location = new Point(pracownicyCB.Location.X + pracownicyCB.Size.Width + 10, raportLabel.Location.Y);
            raportDGV.Location = new Point(raportLabel.Location.X, raportLabel.Location.Y+ raportLabel.Size.Height+10);
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

                            if(pracownicyCB.Items[i].ToString().Length>rozmiarTekstu)
                            {
                                rozmiarTekstu = pracownicyCB.Items[i].ToString().Length;
                            }
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
            saveButton.Enabled = false;

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


                if(raportDGV.Rows.Count > 0)
                {
                    saveButton.Enabled = true;
                }
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
                raportDGV.Columns["Nazwisko"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                raportDGV.Columns["Imię"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                if(raportDGV.Rows.Count > 0)
                {
                    saveButton.Enabled = true;
                }
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

                if(raportDGV.Rows.Count > 0)
                {
                    saveButton.Enabled = true;
                }
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Plik Excel|.xlsx";
            saveDialog.FileName = "Raport za okres od " + kalendarzPoczMC.SelectionStart.ToShortDateString() + " do " + kalendarzKonMC.SelectionStart.ToShortDateString();

            DialogResult result = saveDialog.ShowDialog();

            if(result == DialogResult.OK)
            {
                FileInfo newFile = new FileInfo(saveDialog.FileName);
                try
                {
                    using(ExcelPackage xlPackage = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets.Add("NowyArkusz");

                        switch(idRaportu)
                        {
                            case 0:
                                worksheet.Cell(1, 1).Value = "Wylicz % normy dla pracownika " + pracownicyCB.Items[pracownicyCB.SelectedIndex].ToString();
                                worksheet.Cell(2, 1).Value = "Za okres od " + kalendarzPoczMC.SelectionStart.ToShortDateString() + " do " + kalendarzKonMC.SelectionStart.ToShortDateString();
                                worksheet.Cell(4, 1).Value = "Wartość";
                                worksheet.Cell(5, 1).Value = raportDGV.Rows[0].Cells[0].Value.ToString();
                            break;

                            case 1:
                                worksheet.Cell(1, 1).Value = "Raport szczegółowy ";
                                worksheet.Cell(2, 1).Value = "Za okres od " + kalendarzPoczMC.SelectionStart.ToShortDateString() + " do " + kalendarzKonMC.SelectionStart.ToShortDateString();
                                worksheet.Cell(4, 1).Value = "Nazwisko";
                                worksheet.Cell(4, 2).Value = "Imię";
                                worksheet.Cell(4, 3).Value = "Wykonanie w %";

                                for(int i = 0; i < raportDGV.Rows.Count; i++)
                                {
                                    int x = i + 5;
                                    worksheet.Cell(x, 1).Value = raportDGV.Rows[i].Cells[1].Value.ToString();
                                    worksheet.Cell(x, 2).Value = raportDGV.Rows[i].Cells[2].Value.ToString();
                                    worksheet.Cell(x, 3).Value = raportDGV.Rows[i].Cells[3].Value.ToString();
                                }
                            break;

                            case 2:
                                worksheet.Cell(1, 1).Value = "Raport zbiorczy ";
                                worksheet.Cell(2, 1).Value = "Za okres od " + kalendarzPoczMC.SelectionStart.ToShortDateString() + " do " + kalendarzKonMC.SelectionStart.ToShortDateString();
                                worksheet.Cell(4, 1).Value = "Nazwa akordu";
                                worksheet.Cell(4, 2).Value = "Suma wartości";

                                for(int i = 0; i < raportDGV.Rows.Count; i++)
                                {
                                    int x = i + 5;
                                    worksheet.Cell(x, 1).Value = raportDGV.Rows[i].Cells[0].Value.ToString();
                                    worksheet.Cell(x, 2).Value = raportDGV.Rows[i].Cells[1].Value.ToString();
                                }
                            break;
                        }

                        xlPackage.Save();
                    }
                }
                catch(Exception exc)
                {
                    MessageBox.Show("Wystąpił błąd generowania pliku excel :" + Environment.NewLine + exc.Message);
                    DBRepository db = new DBRepository();
                    db.ErrorReport("RaportyPracownikaProdukcjaForm.saveButton_Click()", exc.Message);
                }
            }
        }
    }
}
