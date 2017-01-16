using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;
using OfficeOpenXml;

namespace AstraAkodry.Ksiegowosc.Raporty
{
    public partial class RaportyGlobalneKsiegowoscForm : Form
    {
        public RaportyGlobalneKsiegowoscForm()
        {
            InitializeComponent();
        }

        private void RaportyGlobalneKsiegowoscForm_Shown(object sender, EventArgs e)
        {
            raportLabel1.Location = new Point(kalendarzMC.Location.X + kalendarzMC.Size.Width + 10, raportLabel1.Location.Y);
            raportDGV.Location = new Point(kalendarzMC.Location.X + kalendarzMC.Size.Width + 10, raportDGV.Location.Y);

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

        private void kalendarzMC_DateChanged(object sender, DateRangeEventArgs e)
        {
            WyczyscRaportDGV();
        }

        private void WyczyscRaportDGV()
        {
            raportDGV.DataSource = null;
            raportDGV.Rows.Clear();
            raportDGV.Columns.Clear();
            zapiszButton.Enabled = false;
        }

        private void globalnyButton_Click(object sender, EventArgs e)
        {
            WyczyscRaportDGV();

            DBRepository db = new DBRepository();
            DataTable pomDataTable = new DataTable();
            String result = "";

            if(db.RaportyGlobalneksiegowoscForm_ZaladujRaportGlobalny(kalendarzMC.SelectionStart, ref pomDataTable, ref result))
            {
                raportDGV.DataSource = pomDataTable;

                raportDGV.Columns["PRA_PracId"].Visible = false;
                raportDGV.Columns["Nazwisko"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                raportDGV.Columns["Imię"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                raportDGV.Columns["Wykonanie w %"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                raportDGV.Columns["Wypłata-Zlecenie"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                if(raportDGV.Rows.Count>0)
                {
                    zapiszButton.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Wystapił błąd podczas generowania raportu:\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void zapiszButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Plik Excel|.xlsx";
            saveDialog.FileName = "Raport za miesiac " + kalendarzMC.SelectionStart.Month + "-" + kalendarzMC.SelectionStart.Year;

            DialogResult result = saveDialog.ShowDialog();

            if(result == DialogResult.OK)
            {
                FileInfo newFile = new FileInfo(saveDialog.FileName);
                try
                {
                    using(ExcelPackage xlPackage = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets.Add("NowyArkusz");

                        worksheet.Cell(1, 1).Value = "Raport wykonania akordów w miesiącu " + kalendarzMC.SelectionStart.Month + "-" + kalendarzMC.SelectionStart.Year;
                        worksheet.Cell(2, 1).Value = "LP.";
                        worksheet.Cell(2, 2).Value = "Nazwisko";
                        worksheet.Cell(2, 3).Value = "Imię";
                        worksheet.Cell(2, 4).Value = "Wykonanie w %";
                        worksheet.Cell(2, 5).Value = "Wypłata Zlecenie";
                        
                        for(int i = 0; i < raportDGV.Rows.Count; i++)
                        {
                            int x = i + 4;
                            worksheet.Cell(x, 1).Value = (i + 1).ToString();
                            worksheet.Cell(x, 2).Value = raportDGV.Rows[i].Cells[1].Value.ToString();
                            worksheet.Cell(x, 3).Value = raportDGV.Rows[i].Cells[2].Value.ToString();
                            worksheet.Cell(x, 4).Value = raportDGV.Rows[i].Cells[3].Value.ToString();
                            worksheet.Cell(x, 5).Value = raportDGV.Rows[i].Cells[4].Value.ToString();
                        }

                        xlPackage.Save();
                    }
                }
                catch(Exception exc)
                {
                    MessageBox.Show("Wystąpił błąd generowania pliku excel :" + Environment.NewLine + exc.Message);
                    DBRepository db = new DBRepository();
                    db.ErrorReport("RaportyGlobalneKsiegowoscForm.zapiszButton_Click()", exc.Message);


                }

            }
        }
    }
}
