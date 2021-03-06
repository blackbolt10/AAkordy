﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AstraAkodry.Ksiegowosc.Raporty
{
    public partial class RaportyPracownikaKsiegowoscForm : Form
    {
        private DataTable pracownicyDT;
        private Int32 idRaportu;
        private Int32 rozmiarTekstu;


        public RaportyPracownikaKsiegowoscForm()
        {
            InitializeComponent();

            idRaportu = -1;

            ZaladujPracownicyDT();
        }

        private void RaportyPracownikaKsiegowoscForm_Shown(object sender, EventArgs e)
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

            pracownicyCB.Location = new Point(pracownicyLabel.Location.X, pracownicyLabel.Location.Y + pracownicyLabel.Size.Height + 10);
            pracownicyCB.DropDownHeight = this.Height - pracownicyCB.Location.Y;
            pracownicyLB.Location = new Point(pracownicyLabel.Location.X, pracownicyCB.Location.Y + pracownicyCB.Size.Height + 10);
            pracownicyCB.Size = new Size((Int32)(rozmiarTekstu * MainForm.czcionka.Size * 0.75), pracownicyLabel.Size.Height + 10);
            pracownicyLB.Size = new Size((Int32)(rozmiarTekstu * MainForm.czcionka.Size * 0.75), zamknijButton.Location.Y - pracownicyLB.Location.Y - 15);

            raportLabel.Location = new Point(pracownicyCB.Location.X + pracownicyCB.Size.Width + 10, raportLabel.Location.Y);
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
            raportPoprawekButton.Enabled = false;
            szczegolowyButton.Enabled = false;
            lenieButton.Enabled = false;

            pracownicyCB.Items.Clear();
            pracownicyLB.Items.Clear();

            DBRepository db = new DBRepository();
            String result = "";
            pracownicyDT = new DataTable();

            if(db.RaportyPracownikaKsiegowoscForm_ZaladujListePracownikow(ref pracownicyDT, ref result))
            {
                if(pracownicyDT.Rows.Count > 0)
                {
                    for(int i = 0; i < pracownicyDT.Rows.Count; i++)
                    {
                        if(pracownicyDT.Rows[i]["PRA_Archiwalny"].ToString() != "1")
                        {
                            pracownicyCB.Items.Add(pracownicyDT.Rows[i]["PRA_Nazwisko"] + " " + pracownicyDT.Rows[i]["PRA_Imie"]);
                            pracownicyLB.Items.Add(pracownicyDT.Rows[i]["PRA_Nazwisko"] + " " + pracownicyDT.Rows[i]["PRA_Imie"]);

                            if(pracownicyCB.Items[i].ToString().Length > rozmiarTekstu)
                            {
                                rozmiarTekstu = pracownicyCB.Items[i].ToString().Length;
                            }
                        }
                    }
                    pracownicyLB.SelectedIndex = 0;

                    raportPoprawekButton.Enabled = true;
                    szczegolowyButton.Enabled = true;
                    lenieButton.Enabled = true;
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
                    GenerujRaportPoprawek();
                    break;

                    case 1:
                    GenerujRaportSzczegolowy();
                    break;

                    case 2:
                    GenerujRaportLeni();
                    break;
                }
            }
        }

        private void raportPoprawekButton_Click(object sender, EventArgs e)
        {
            idRaportu = 0;
            GenerujRaportPoprawek();
        }

        private void szczegolowyButton_Click(object sender, EventArgs e)
        {
            idRaportu = 1;
            GenerujRaportSzczegolowy();
        }

        private void lenieButton_Click(object sender, EventArgs e)
        {
            idRaportu = 2;
            GenerujRaportLeni();
        }

        private void GenerujRaportPoprawek()
        {
            Cursor.Current = Cursors.WaitCursor;
            WyczyscRaportDGV();

            DBRepository db = new DBRepository();
            String idPracownika = pracownicyDT.Rows[pracownicyLB.SelectedIndex]["PRA_PracId"].ToString();
            String result = "";
            DataTable pomDataTable = new DataTable();

            if(db.RaportyPracownikaKsiegowoscForm_RaportPoprawek(idPracownika, kalendarzPoczMC.SelectionStart.ToShortDateString(), kalendarzKonMC.SelectionStart.ToShortDateString(), ref pomDataTable, ref result))
            {
                raportDGV.DataSource = pomDataTable;

                raportLabel.Text = "Raport poprawek:";
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
            String idPracownika = pracownicyDT.Rows[pracownicyLB.SelectedIndex]["PRA_PracId"].ToString();
            String result = "";
            DataTable pomDataTable = new DataTable();

            if(db.RaportyPracownikaKsiegowoscForm_RaportSzczegolowy(idPracownika, kalendarzPoczMC.SelectionStart.ToShortDateString(), kalendarzKonMC.SelectionStart.ToShortDateString(), ref pomDataTable, ref result))
            {
                raportDGV.DataSource = pomDataTable;

                raportLabel.Text = "Raport szczegółowy:";
            }
            else
            {
                MessageBox.Show("Wystapił błąd podczas generowania raportu:\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }


        private void GenerujRaportLeni()
        {
            Cursor.Current = Cursors.WaitCursor;
            WyczyscRaportDGV();

            DBRepository db = new DBRepository();
            String result = "";
            DataTable pomDataTable = new DataTable();

            if(db.RaportyPracownikaKsiegowoscForm_RaportLeni(kalendarzPoczMC.SelectionStart.ToShortDateString(), kalendarzKonMC.SelectionStart.ToShortDateString(), ref pomDataTable, ref result))
            {
                raportDGV.DataSource = pomDataTable;

                raportLabel.Text = "Raport \"leni\":";
                raportDGV.Columns["Pracownik"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                MessageBox.Show("Wystapił błąd podczas generowania raportu:\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
