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
    public partial class RaportRecepcjaForm : Form
    {
        private DataTable pracownicyDT;
        private DataTable akordyDT;

        public RaportRecepcjaForm()
        {
            InitializeComponent();
        }

        private void RaportRecepcjaForm_Shown(object sender, EventArgs e)
        {
            miesiacLabel.Font = MainForm.czcionka;
            pracownikLabel.Font = MainForm.czcionka;
            akordyLabel.Font = MainForm.czcionka; 
            raportLabel.Font = MainForm.czcionka;
            raportDGV.Font = MainForm.czcionka;
            akordyLB.Font = MainForm.czcionka;
            pracownicyCB.Font = MainForm.czcionka;
            pracownicyLB.Font = MainForm.czcionka;

            kalendarzMC.Location = new Point(miesiacLabel.Location.X, miesiacLabel.Location.Y + miesiacLabel.Size.Height + 10);
            pracownikLabel.Location = new Point(miesiacLabel.Location.X, kalendarzMC.Location.Y + kalendarzMC.Size.Height + 10);
            pracownicyCB.Location = new Point(miesiacLabel.Location.X, pracownikLabel.Location.Y + pracownikLabel.Size.Height + 10);
            pracownicyLB.Location = new Point(miesiacLabel.Location.X, pracownicyCB.Location.Y + pracownicyCB.Size.Height + 10);
            
            pracownicyCB.Size = new Size(kalendarzMC.Size.Width, pracownicyCB.Size.Height);
            pracownicyLB.Size = new Size(kalendarzMC.Size.Width, this.Size.Height - pracownicyLB.Location.Y - 20);

            akordyLB.Location = new Point(akordyLabel.Location.X, akordyLabel.Location.Y + akordyLabel.Size.Height + 10);
            akordyLB.Size = new Size(pracownicyLB.Size.Width, this.Size.Height - akordyLB.Location.Y - 10);
            

            DopasujDoKalendarza();



            reloadButton_Click(reloadButton, null);
        }

        private void DopasujDoKalendarza()
        {
            akordyLabel.Location = new Point(kalendarzMC.Location.X + kalendarzMC.Size.Width + 10, akordyLabel.Location.Y);
            akordyLB.Location = new Point(kalendarzMC.Location.X + kalendarzMC.Size.Width + 10, akordyLB.Location.Y);

            raportLabel.Location = new Point(akordyLB.Location.X +akordyLB.Size.Width + 10, akordyLabel.Location.Y);
            raportDGV.Location = new Point(raportLabel.Location.X, akordyLB.Location.Y);
            raportDGV.Size = new Size(zamknijButton.Location.X+zamknijButton.Size.Width- raportDGV.Location.X, zamknijButton.Location.Y - raportDGV.Location.Y - 10);
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

        private void reloadButton_Click(object sender, EventArgs e)
        {
            ZaladujListePracownikow();
            ZaladujListeAkordow();
        }

        private void ZaladujListeAkordow()
        {
            akordyLB.Items.Clear();

            DBRepository db = new DBRepository();
            String result = "";
            akordyDT = new DataTable();

            if(db.RaportRecepcjaForm_ZaladujListeAkordow(ref akordyDT, ref result))
            {
                if(akordyDT.Rows.Count > 0)
                {
                    for(int i = 0; i < akordyDT.Rows.Count; i++)
                    {
                        if(akordyDT.Rows[i]["AKR_Archiwalny"].ToString() != "1")
                        {
                            akordyLB.Items.Add(akordyDT.Rows[i]["AKR_Nazwa"]);
                        }
                    }
                    akordyLB.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("Wystąpił błąd podczas wczytywania listy akordów: \n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ZaladujListePracownikow()
        {
            pracownicyCB.Items.Clear();
            pracownicyLB.Items.Clear();

            DBRepository db = new DBRepository();
            String result = "";
            pracownicyDT = new DataTable();

            if(db.RaportRecepcjaForm_ZaladujListePracownikow(ref pracownicyDT, ref result))
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
                }
            }
            else
            {
                MessageBox.Show("Wystąpił błąd podczas wczytywania listy pracowników: \n"+result,"Błąd",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void pracownicyLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            pracownicyCB.SelectedIndex = pracownicyLB.SelectedIndex;

            if(akordyLB.Items.Count > 0)
            {
                akordyLB.SelectedIndex = 0;
                ZaladujRaportDGV();
            }
        }

        private void pracownicyCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            pracownicyLB.SelectedIndex = pracownicyCB.SelectedIndex;

            if(akordyLB.Items.Count > 0)
            {
                akordyLB.SelectedIndex = 0;
                ZaladujRaportDGV();
            }
        }

        private void akordyLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZaladujRaportDGV();
        }

        private void kalendarzMC_DateChanged(object sender, DateRangeEventArgs e)
        {
            ZaladujRaportDGV();
        }

        private void ZaladujRaportDGV()
        {
            raportDGV.DataSource = null;
            raportDGV.Rows.Clear();
            raportDGV.Columns.Clear();
            raportLabel.Text = "Raport wykonywanych akordów za miesiac "+kalendarzMC.SelectionStart.Month.ToString()+"-"+ kalendarzMC.SelectionStart.Year.ToString();

            if(akordyLB.SelectedIndex>-1 && pracownicyLB.SelectedIndex>-1)
            {
                DBRepository db = new DBRepository();
                DataTable pomDataTable = new DataTable();
                String result = "";

                DateTime dataPoczatkowa = new DateTime(kalendarzMC.SelectionStart.Year, kalendarzMC.SelectionStart.Month, 01, 00, 00, 00);
                DateTime dataKoncowa = new DateTime(kalendarzMC.SelectionStart.Year, kalendarzMC.SelectionStart.Month, DateTime.DaysInMonth(kalendarzMC.SelectionStart.Year, kalendarzMC.SelectionStart.Month), 23, 59, 59);
                String idPracownika = pracownicyDT.Rows[pracownicyLB.SelectedIndex]["PRA_PracId"].ToString();
                String idAkordu = akordyDT.Rows[akordyLB.SelectedIndex]["akr_akrid"].ToString();

                if(db.RaportRecepcjaForm_ZaladujRaportDGV(idPracownika, idAkordu, dataPoczatkowa.ToShortDateString(), dataKoncowa.ToShortDateString(), ref pomDataTable, ref result))
                {
                    raportDGV.DataSource = pomDataTable;
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd podczas wczytywania danych:\n"+result, "Błąd", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }
    }
}
