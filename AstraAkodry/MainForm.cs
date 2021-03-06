﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AstraAkodry
{
    public partial class MainForm : Form
    {
        private List<Form> listaMdiChildForm = new List<Form>();
        
        private Konfiguracja.Ustawienia.Akordy.AkordyForm akordyForm;
        private Konfiguracja.Ustawienia.Operatorzy.OperatorzyForm operatorzyForm;
        private Konfiguracja.Baza.ReindeksacjaForm reindeksacjaForm;
        private Konfiguracja.Baza.NieaktywPracForm nieaktywPracForm;
        private Konfiguracja.Ustawienia.Pracownicy.PracownicyForm pracownicyForm;
        private Konfiguracja.Aplikacja.UstawieniaForm ustawieniaForm;
        private Recepcja.Raporty.RaportRecepcjaForm raportRecepcjaForm;
        private Recepcja.Raporty.RaportLeniRecepcjaForm raportLeniRecepcjaForm;
        private Recepcja.WprowadzanieAkordowForm wprowadzanieAkordowForm;
        private Recepcja.WprowadzanieAkordowTesotwychForm wprowadzanieAkordowTesotwychForm;
        private Recepcja.RaportDziennyTestowychForm raportDziennyTestowychForm;
        private Produkcja.Raporty.RaportyGlobalneProdukcjaForm raportGlobalneProdukcjaForm;
        private Produkcja.Raporty.RaportyPracownikaProdukcjaForm raportPracownikaProdukcjaForm;
        private Produkcja.Akordy_testowe.RaportTestoweForm raportTestoweForm;
        private Produkcja.Akordy_testowe.Zarządzanie.ZarzadzanieTestowymiForm zarzadzanieTestowymiForm;
        private Ksiegowosc.Raporty.RaportyPracownikaKsiegowoscForm raportPracownikaKsiegowoscForm;
        private Ksiegowosc.Raporty.RaportyGlobalneKsiegowoscForm raportGlobalneKsiegowoscForm;


        private String sciezkaRejestru = "Software\\Galsoft\\AstraAkordy\\MainForm";
        public Boolean czyWylogowano = false;

        public static String IDOperatora;
        public static Int32 UprawnieniaOperatora;
        public static String nazwaOperatora;
        public static String hasloOperatora;
        public static Font czcionka;


        public MainForm(String wersja)
        {
            InitializeComponent();
            wersjaTSSL.Text = wersja;

            ZaladujAktualnaCzcionke();
            ZablokujDostep();
        }

        private void ZablokujDostep()
        {
            switch(UprawnieniaOperatora)
            {
                case 0:
                    ribbon1.ActiveTab = ksiegowoscRibbonTab;
                break;

                case 1:
                    produkcjaRibbonTab.Visible = false;
                    ksiegowoscRibbonTab.Visible = false;
                    ustawieniaRibbonPanel.Visible = false;
                    bazaRibbonPanel.Visible = false;
                    ribbon1.ActiveTab = recepcjaRibbonTab;
                break;

                case 2:
                    recepcjaRibbonTab.Visible = false;
                    ksiegowoscRibbonTab.Visible = false;
                    ustawieniaRibbonPanel.Visible = false;
                    bazaRibbonPanel.Visible = false;
                    ribbon1.ActiveTab = produkcjaRibbonTab;
                break;
            }
        }

        private void closeRibbonOrbMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(sciezkaRejestru);

            SetDesktopLocation(Convert.ToInt16(key.GetValue("Location.X", Location.X.ToString())), Convert.ToInt16(key.GetValue("Location.Y", Location.Y.ToString())));

            Size = new Size(Convert.ToInt16(key.GetValue("Size.Width", Size.Width.ToString())), Convert.ToInt16(key.GetValue("Size.Height", Size.Height.ToString())));

            key.Close();
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(sciezkaRejestru);

            if(WindowState != FormWindowState.Minimized)
            {
                key.SetValue("Location.X", Location.X.ToString());
                key.SetValue("Location.Y", Location.Y.ToString());

                // this.Size.Height .Width
                key.SetValue("Size.Width", Size.Width.ToString());
                key.SetValue("Size.Height", Size.Height.ToString());
            }
            key.Close();
        }

        private void ZaladujAktualnaCzcionke()
        {
            DBRepository db = new DBRepository();
            String nazwa = "";
            String rozmiar = "";
            String result = "";

            if(db.MainForm_ZaladujCzcionke(ref nazwa, ref rozmiar, ref result))
            {
                FontFamily fontFamily = new FontFamily(nazwa);
                czcionka = new Font(fontFamily, float.Parse(rozmiar), FontStyle.Regular, GraphicsUnit.Pixel);
            }
            else
            {
                FontFamily fontFamily = new FontFamily(nazwa);
                czcionka = new Font(fontFamily, float.Parse(rozmiar), FontStyle.Regular, GraphicsUnit.Pixel);

                MessageBox.Show("Wystąpił błąd podczas odczytywania czcionki:\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void zamknijRibbonOrbMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz zamknąć program?", "Zapytanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void logoutRibbonOrbMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz się wylogować?", "Zapytanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                czyWylogowano = true;
                this.Close();
            }
        }

        private void mdiChild_Activate(object sender, EventArgs e)
        {
            Form form = (Form)sender;

            if(listaMdiChildForm.Contains(form))
            {
                listaMdiChildForm.Remove(form);
            }

            listaMdiChildForm.Add(form);

            aktualizujListeMdiChild();
        }

        private void mdiChild_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form form = (Form)sender;

            if(listaMdiChildForm.Contains(form))
            {
                listaMdiChildForm.Remove(form);
            }

            aktualizujListeMdiChild();
        }

        private void aktualizujListeMdiChild()
        {
            oknaCB.Items.Clear();

            for(int i = 0; i < listaMdiChildForm.Count; i++)
            {
                oknaCB.Items.Add(listaMdiChildForm[i].Text);
            }

            if(oknaCB.Items.Count > 0)
            {
                listaMdiChildForm[listaMdiChildForm.Count - 1].Activate();
                oknaCB.SelectedIndex = oknaCB.Items.Count - 1;

                zmienOknoLabel.Visible = true;
                oknaCB.Visible = true;
            }
            else
            {
                zmienOknoLabel.Visible = false;
                oknaCB.Visible = false;
            }
        }

        private void oknaCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(oknaCB.Items.Count > 0)
            {
                listaMdiChildForm[oknaCB.SelectedIndex].Focus();
            }
        }

        private void wprowadzanieribbonButton_Click(object sender, EventArgs e)
        {
            if(wprowadzanieAkordowForm == null || wprowadzanieAkordowForm.IsDisposed)
            {
                wprowadzanieAkordowForm = new Recepcja.WprowadzanieAkordowForm();
                wprowadzanieAkordowForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(mdiChild_FormClosing);
                wprowadzanieAkordowForm.Shown += new System.EventHandler(mdiChild_Activate);
                wprowadzanieAkordowForm.MdiParent = this;
                wprowadzanieAkordowForm.Dock = DockStyle.Fill;
                wprowadzanieAkordowForm.Show();
            }
            else
            {
                wprowadzanieAkordowForm.Activate();
            }
        }

        private void raportyRecepcjaribbonButton_Click(object sender, EventArgs e)
        {
            if(raportRecepcjaForm == null || raportRecepcjaForm.IsDisposed)
            {
                raportRecepcjaForm = new Recepcja.Raporty.RaportRecepcjaForm();
                raportRecepcjaForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(mdiChild_FormClosing);
                raportRecepcjaForm.Shown += new System.EventHandler(mdiChild_Activate);
                raportRecepcjaForm.MdiParent = this;
                raportRecepcjaForm.Dock = DockStyle.Fill;
                raportRecepcjaForm.Show();
            }
            else
            {
                raportRecepcjaForm.Activate();
            }
        }

        private void pracownicyRibbonButton_Click(object sender, EventArgs e)
        {
            if(pracownicyForm == null || pracownicyForm.IsDisposed)
            {
                pracownicyForm = new Konfiguracja.Ustawienia.Pracownicy.PracownicyForm();
                pracownicyForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(mdiChild_FormClosing);
                pracownicyForm.Shown += new System.EventHandler(mdiChild_Activate);
                pracownicyForm.MdiParent = this;
                pracownicyForm.Dock = DockStyle.Fill;
                pracownicyForm.Show();
            }
            else
            {
                pracownicyForm.Activate();
            }
        }

        private void operatorzyRibbonButton_Click(object sender, EventArgs e)
        {
            if(operatorzyForm == null || operatorzyForm.IsDisposed)
            {
                operatorzyForm = new Konfiguracja.Ustawienia.Operatorzy.OperatorzyForm();
                operatorzyForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(mdiChild_FormClosing);
                operatorzyForm.Shown += new System.EventHandler(mdiChild_Activate);
                operatorzyForm.MdiParent = this;
                operatorzyForm.Dock = DockStyle.Fill;
                operatorzyForm.Show();
            }
            else
            {
                operatorzyForm.Activate();
            }
        }

        private void akordyRibbonButton_Click(object sender, EventArgs e)
        {
            if(akordyForm == null || akordyForm.IsDisposed)
            {
                akordyForm = new Konfiguracja.Ustawienia.Akordy.AkordyForm();
                akordyForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(mdiChild_FormClosing);
                akordyForm.Shown += new System.EventHandler(mdiChild_Activate);
                akordyForm.MdiParent = this;
                akordyForm.Dock = DockStyle.Fill;
                akordyForm.Show();
            }
            else
            {
                akordyForm.Activate();
            }
        }

        private void rapLeniRibbonButton_Click(object sender, EventArgs e)
        {
            if(raportLeniRecepcjaForm == null || raportLeniRecepcjaForm.IsDisposed)
            {
                raportLeniRecepcjaForm = new Recepcja.Raporty.RaportLeniRecepcjaForm();
                raportLeniRecepcjaForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(mdiChild_FormClosing);
                raportLeniRecepcjaForm.Shown += new System.EventHandler(mdiChild_Activate);
                raportLeniRecepcjaForm.MdiParent = this;
                raportLeniRecepcjaForm.Dock = DockStyle.Fill;
                raportLeniRecepcjaForm.Show();
            }
            else
            {
                raportLeniRecepcjaForm.Activate();
            }
        }

        private void globalneRibbonButton_Click(object sender, EventArgs e)
        {
            if(raportGlobalneProdukcjaForm == null || raportGlobalneProdukcjaForm.IsDisposed)
            {
                raportGlobalneProdukcjaForm = new Produkcja.Raporty.RaportyGlobalneProdukcjaForm();
                raportGlobalneProdukcjaForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(mdiChild_FormClosing);
                raportGlobalneProdukcjaForm.Shown += new System.EventHandler(mdiChild_Activate);
                raportGlobalneProdukcjaForm.MdiParent = this;
                raportGlobalneProdukcjaForm.Dock = DockStyle.Fill;
                raportGlobalneProdukcjaForm.Show();
            }
            else
            {
                raportGlobalneProdukcjaForm.Activate();
            }
        }

        private void pracownikaRibbonButton_Click(object sender, EventArgs e)
        {
            if(raportPracownikaProdukcjaForm == null || raportPracownikaProdukcjaForm.IsDisposed)
            {
                raportPracownikaProdukcjaForm = new Produkcja.Raporty.RaportyPracownikaProdukcjaForm();
                raportPracownikaProdukcjaForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(mdiChild_FormClosing);
                raportPracownikaProdukcjaForm.Shown += new System.EventHandler(mdiChild_Activate);
                raportPracownikaProdukcjaForm.MdiParent = this;
                raportPracownikaProdukcjaForm.Dock = DockStyle.Fill;
                raportPracownikaProdukcjaForm.Show();
            }
            else
            {
                raportPracownikaProdukcjaForm.Activate();
            }
        }

        private void ksiegGlobalneRibbonButton_Click(object sender, EventArgs e)
        {
            if(raportGlobalneKsiegowoscForm == null || raportGlobalneKsiegowoscForm.IsDisposed)
            {
                raportGlobalneKsiegowoscForm = new Ksiegowosc.Raporty.RaportyGlobalneKsiegowoscForm();
                raportGlobalneKsiegowoscForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(mdiChild_FormClosing);
                raportGlobalneKsiegowoscForm.Shown += new System.EventHandler(mdiChild_Activate);
                raportGlobalneKsiegowoscForm.MdiParent = this;
                raportGlobalneKsiegowoscForm.Dock = DockStyle.Fill;
                raportGlobalneKsiegowoscForm.Show();
            }
            else
            {
                raportGlobalneKsiegowoscForm.Activate();
            }
        }

        private void ksiegPracownikaRibbonButton_Click(object sender, EventArgs e)
        {
            if(raportPracownikaKsiegowoscForm == null || raportPracownikaKsiegowoscForm.IsDisposed)
            {
                raportPracownikaKsiegowoscForm = new Ksiegowosc.Raporty.RaportyPracownikaKsiegowoscForm();
                raportPracownikaKsiegowoscForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(mdiChild_FormClosing);
                raportPracownikaKsiegowoscForm.Shown += new System.EventHandler(mdiChild_Activate);
                raportPracownikaKsiegowoscForm.MdiParent = this;
                raportPracownikaKsiegowoscForm.Dock = DockStyle.Fill;
                raportPracownikaKsiegowoscForm.Show();
            }
            else
            {
                raportPracownikaKsiegowoscForm.Activate();
            }
        }

        private void ustawieniaRibbonButton_Click(object sender, EventArgs e)
        {
            if(ustawieniaForm == null || ustawieniaForm.IsDisposed)
            {
                ustawieniaForm = new Konfiguracja.Aplikacja.UstawieniaForm();
                ustawieniaForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(mdiChild_FormClosing);
                ustawieniaForm.Shown += new System.EventHandler(mdiChild_Activate);
                ustawieniaForm.MdiParent = this;
                ustawieniaForm.Dock = DockStyle.Fill;
                ustawieniaForm.Show();
            }
            else
            {
                ustawieniaForm.Activate();
            }
        }

        private void niekatywPracRibbonButton_Click(object sender, EventArgs e)
        {
            if(nieaktywPracForm == null || nieaktywPracForm.IsDisposed)
            {
                nieaktywPracForm = new Konfiguracja.Baza.NieaktywPracForm();
                nieaktywPracForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(mdiChild_FormClosing);
                nieaktywPracForm.Shown += new System.EventHandler(mdiChild_Activate);
                nieaktywPracForm.MdiParent = this;
                nieaktywPracForm.Dock = DockStyle.Fill;
                nieaktywPracForm.Show();
            }
            else
            {
                nieaktywPracForm.Activate();
            }
        }

        private void reindeksacjaRibbonButton_Click(object sender, EventArgs e)
        {
            if(reindeksacjaForm == null || reindeksacjaForm.IsDisposed)
            {
                reindeksacjaForm = new Konfiguracja.Baza.ReindeksacjaForm();
                reindeksacjaForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(mdiChild_FormClosing);
                reindeksacjaForm.Shown += new System.EventHandler(mdiChild_Activate);
                reindeksacjaForm.MdiParent = this;
                reindeksacjaForm.Dock = DockStyle.Fill;
                reindeksacjaForm.Show();
            }
            else
            {
                reindeksacjaForm.Activate();
            }
        }

        private void raportAkorTestRibbonButton_Click(object sender, EventArgs e)
        {
            if(raportTestoweForm == null || raportTestoweForm.IsDisposed)
            {
                raportTestoweForm = new Produkcja.Akordy_testowe.RaportTestoweForm();
                raportTestoweForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(mdiChild_FormClosing);
                raportTestoweForm.Shown += new System.EventHandler(mdiChild_Activate);
                raportTestoweForm.MdiParent = this;
                raportTestoweForm.Dock = DockStyle.Fill;
                raportTestoweForm.Show();
            }
            else
            {
                raportTestoweForm.Activate();
            }
        }

        private void zarzadzenieTestoweRibbonButton_Click(object sender, EventArgs e)
        {
            if(zarzadzanieTestowymiForm == null || zarzadzanieTestowymiForm.IsDisposed)
            {
                zarzadzanieTestowymiForm = new Produkcja.Akordy_testowe.Zarządzanie.ZarzadzanieTestowymiForm();
                zarzadzanieTestowymiForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(mdiChild_FormClosing);
                zarzadzanieTestowymiForm.Shown += new System.EventHandler(mdiChild_Activate);
                zarzadzanieTestowymiForm.MdiParent = this;
                zarzadzanieTestowymiForm.Dock = DockStyle.Fill;
                zarzadzanieTestowymiForm.Show();
            }
            else
            {
                zarzadzanieTestowymiForm.Activate();
            }
        }

        private void wprowadzanieTestowychRibbonButton_Click(object sender, EventArgs e)
        {
            if(wprowadzanieAkordowTesotwychForm == null || wprowadzanieAkordowTesotwychForm.IsDisposed)
            {
                wprowadzanieAkordowTesotwychForm = new Recepcja.WprowadzanieAkordowTesotwychForm();
                wprowadzanieAkordowTesotwychForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(mdiChild_FormClosing);
                wprowadzanieAkordowTesotwychForm.Shown += new System.EventHandler(mdiChild_Activate);
                wprowadzanieAkordowTesotwychForm.MdiParent = this;
                wprowadzanieAkordowTesotwychForm.Dock = DockStyle.Fill;
                wprowadzanieAkordowTesotwychForm.Show();
            }
            else
            {
                wprowadzanieAkordowTesotwychForm.Activate();
            }
        }

        private void wprowadzanieTestProdRibbonButton_Click(object sender, EventArgs e)
        {
            if(wprowadzanieAkordowTesotwychForm == null || wprowadzanieAkordowTesotwychForm.IsDisposed)
            {
                wprowadzanieAkordowTesotwychForm = new Recepcja.WprowadzanieAkordowTesotwychForm();
                wprowadzanieAkordowTesotwychForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(mdiChild_FormClosing);
                wprowadzanieAkordowTesotwychForm.Shown += new System.EventHandler(mdiChild_Activate);
                wprowadzanieAkordowTesotwychForm.MdiParent = this;
                wprowadzanieAkordowTesotwychForm.Dock = DockStyle.Fill;
                wprowadzanieAkordowTesotwychForm.Show();
            }
            else
            {
                wprowadzanieAkordowTesotwychForm.Activate();
            }
        }

        private void raportDziennyRibbonButton_Click(object sender, EventArgs e)
        {
            if(raportDziennyTestowychForm == null || raportDziennyTestowychForm.IsDisposed)
            {
                raportDziennyTestowychForm = new Recepcja.RaportDziennyTestowychForm();
                raportDziennyTestowychForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(mdiChild_FormClosing);
                raportDziennyTestowychForm.Shown += new System.EventHandler(mdiChild_Activate);
                raportDziennyTestowychForm.MdiParent = this;
                raportDziennyTestowychForm.Dock = DockStyle.Fill;
                raportDziennyTestowychForm.Show();
            }
            else
            {
                raportDziennyTestowychForm.Activate();
            }
        }

        private void raportDziennyProdRibbonButton_Click(object sender, EventArgs e)
        {
            if(raportDziennyTestowychForm == null || raportDziennyTestowychForm.IsDisposed)
            {
                raportDziennyTestowychForm = new Recepcja.RaportDziennyTestowychForm();
                raportDziennyTestowychForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(mdiChild_FormClosing);
                raportDziennyTestowychForm.Shown += new System.EventHandler(mdiChild_Activate);
                raportDziennyTestowychForm.MdiParent = this;
                raportDziennyTestowychForm.Dock = DockStyle.Fill;
                raportDziennyTestowychForm.Show();
            }
            else
            {
                raportDziennyTestowychForm.Activate();
            }
        }
    }
}
