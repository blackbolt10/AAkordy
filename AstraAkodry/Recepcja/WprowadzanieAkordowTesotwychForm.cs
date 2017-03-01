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
    public partial class WprowadzanieAkordowTesotwychForm : Form
    {
        private DataTable pracownicyDT;

        public WprowadzanieAkordowTesotwychForm()
        {
            InitializeComponent();

            ZaladujListePracownikow();
        }

        private void WprowadzanieAkordowForm_Shown(object sender, EventArgs e)
        {
            dataLabel.Font = MainForm.czcionka;
            pracownicyLabel.Font = MainForm.czcionka;
            akordyLabel.Font = MainForm.czcionka;
            pracownicyCB.Font = MainForm.czcionka;
            pracownicyLB.Font = MainForm.czcionka;
            akordyDGV.Font = MainForm.czcionka;

            kalendarzMC.Location = new Point(dataLabel.Location.X, dataLabel.Location.Y + dataLabel.Size.Height + 10);

            if(kalendarzMC.Size.Width > label1.Size.Width)
            {
                pracownicyLabel.Location = new Point(kalendarzMC.Location.X + kalendarzMC.Size.Width + 10, dataLabel.Location.Y);
            }
            else
            {
                pracownicyLabel.Location = new Point(label1.Location.X + label1.Size.Width + 10, dataLabel.Location.Y);
            }

            pracownicyCB.Location = new Point(pracownicyLabel.Location.X, pracownicyLabel.Location.Y + pracownicyLabel.Size.Height + 10);

            if(MainForm.czcionka.Size > 20)
            {
                pracownicyCB.Size = new Size(kalendarzMC.Size.Width + 50, pracownicyCB.Size.Height);
            }
            else
            {
                pracownicyCB.Size = new Size(kalendarzMC.Size.Width, pracownicyCB.Size.Height);
            }

            pracownicyLB.Location = new Point(pracownicyCB.Location.X, pracownicyCB.Location.Y + pracownicyCB.Size.Height + 10);
            pracownicyLB.Size = new Size(pracownicyCB.Size.Width, zamknijButton.Location.Y + zamknijButton.Size.Height - pracownicyLB.Location.Y);

            akordyLabel.Location = new Point(pracownicyCB.Location.X + pracownicyCB.Size.Width + 10, dataLabel.Location.Y);
            akordyDGV.Location = new Point(akordyLabel.Location.X, akordyLabel.Location.Y + akordyLabel.Size.Height + 10);
            akordyDGV.Size = new Size(zamknijButton.Location.X + zamknijButton.Size.Width - akordyDGV.Location.X, zamknijButton.Location.Y - akordyDGV.Location.Y - 10);

            ZaladujListeAkordow();
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

        private void ZaladujListePracownikow()
        {
            pracownicyCB.Items.Clear();
            pracownicyLB.Items.Clear();

            DBRepository db = new DBRepository();
            String result = "";
            pracownicyDT = new DataTable();

            if(db.WprowadzanieAkordowForm_ZaladujListePracownikow(ref pracownicyDT, ref result))
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
                MessageBox.Show("Wystąpił błąd podczas wczytywania listy pracowników: \n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pracownicyCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            pracownicyLB.SelectedIndex = pracownicyCB.SelectedIndex;

            if(akordyDGV.CurrentCell != null)
            {
                akordyDGV.Focus();
                akordyDGV.BeginEdit(true);
            }
        }

        private void pracownicyLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            pracownicyCB.SelectedIndex = pracownicyLB.SelectedIndex;
            ZaladujListeAkordow();
        }

        private void akordyDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            String idWiersza= akordyDGV.CurrentRow.Cells["WAT_WatId"].Value.ToString();
            Int32 idAkordu = Convert.ToInt32(akordyDGV.CurrentRow.Cells["AKT_AkrId"].Value.ToString());
            String wartoscStringAkordu = akordyDGV.CurrentRow.Cells["Wartość"].Value.ToString();
            if(wartoscStringAkordu == "")
            {
                wartoscStringAkordu = "0";
            }
            double wartoscAkordu = Convert.ToDouble(wartoscStringAkordu);

            String czasStringAkordu = akordyDGV.CurrentRow.Cells["Czas"].Value.ToString();
            if(czasStringAkordu == "")
            {
                czasStringAkordu = "0";
            }
            double czasAkordu = Convert.ToDouble(czasStringAkordu);

            ZapiszNowaWartosc(idWiersza, idAkordu, wartoscAkordu, czasAkordu);
            ZaladujListeAkordow();
        }

        private void ZapiszNowaWartosc(String idWiersza, int idAkordu, double wartoscAkordu, double czasAkordu)
        {
            DBRepository db = new DBRepository();
            String IdPracownika = pracownicyDT.Rows[pracownicyLB.SelectedIndex]["PRA_PracId"].ToString();
            String result = "";

            if(db.WprowadzanieAkordowTestowychForm_ZapiszNowyAkord(idWiersza, IdPracownika, idAkordu, wartoscAkordu, czasAkordu, kalendarzMC.SelectionStart, ref result))
            {

            }
            else
            {
                MessageBox.Show("Wystąpił błąd podczas zapisu:\n" + result + "\n\nProszę spróbowac ponownie", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        

        private void akordyDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(akordyDGV.Rows.Count > 0)
            {
                if(akordyDGV.CurrentCell.ColumnIndex >2)
                {
                    akordyDGV.CurrentCell = akordyDGV.CurrentRow.Cells["Czas"];
                }
                else
                {
                    akordyDGV.CurrentCell = akordyDGV.CurrentRow.Cells["Wartość"];
                }
                akordyDGV.BeginEdit(true);
            }
        }

        private void akordyDGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;
            if(tb != null)
            {
                tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                tb.KeyDown += Tb_KeyDown;
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void Tb_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F2)
            {
                pracownicyCB.Focus();
            }
            else if(e.KeyCode == Keys.F3)
            {
                pracownicyLB.Focus();
            }

        }

        private void akordyDGV_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F2)
            {
                pracownicyCB.Focus();
            }
        }

        private void pracownicyLB_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F2)
            {
                pracownicyCB.Focus();
            }
            else if(e.KeyCode == Keys.Enter)
            {
                akordyDGV.Focus();
                akordyDGV.BeginEdit(true);
            }
        }

        private void pracownicyCB_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F3)
            {
                pracownicyLB.Focus();
            }
            else if(e.KeyCode == Keys.Enter)
            {
                akordyDGV.Focus();
            }
        }

        private void kalendarzMC_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime dataKalendarz = kalendarzMC.SelectionStart;
            DateTime dataMargines = generujDateMargines();

            if(dataMargines <= dataKalendarz)
            {
                if(dataKalendarz <= DateTime.Now)
                {
                    if(pracownicyLB.SelectedIndex != -1)
                    {
                        ZaladujListeAkordow();
                    }
                }
                else
                {
                    MessageBox.Show("Ten dzień jeszcze nie nastał.\n\nNie bądź jasnowidzem...", "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    kalendarzMC.SetDate(DateTime.Now);
                }
            }
            else
            {
                MessageBox.Show("Brak możliwości edytowania zamkniętego miesiąca.\n Poprzedni miesiac można edytować do 10 dnia aktualnego miesiaca.", "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                kalendarzMC.SetDate(DateTime.Now);
            }
        }

        private DateTime generujDateMargines()
        {
            DateTime dataMargines = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01);

            if(DateTime.Now.Day < 10)
            {
                dataMargines = dataMargines.AddMonths(-1);
            }

            return dataMargines;
        }
        private void ZaladujListeAkordow()
        {
            if(pracownicyDT.Rows.Count > 0 && pracownicyLB.SelectedIndex != -1 && pracownicyLB.SelectedIndex < pracownicyDT.Rows.Count)
            {
                akordyDGV.DataSource = null;
                akordyDGV.Rows.Clear();
                akordyDGV.Columns.Clear();

                String idPracownika = pracownicyDT.Rows[pracownicyLB.SelectedIndex]["PRA_PracID"].ToString();
                DateTime dataKalendarz = new DateTime(kalendarzMC.SelectionStart.Year, kalendarzMC.SelectionStart.Month, kalendarzMC.SelectionStart.Day, 23, 59, 59);
                DateTime dataKalendarzZero = new DateTime(kalendarzMC.SelectionStart.Year, kalendarzMC.SelectionStart.Month, kalendarzMC.SelectionStart.Day, 0, 0, 0);
                DBRepository db = new DBRepository();
                DataTable pomDataTable = new DataTable();
                String result = "";

                if(db.WprowadzanieAkordowTestowychForm_ZaladujListeAkordow(idPracownika, dataKalendarz, dataKalendarzZero, ref pomDataTable, ref result))
                {
                    pomDataTable = poprawKolejnoscAkordow(pomDataTable);

                    akordyDGV.DataSource = pomDataTable;

                    if(akordyDGV.Columns.Count > 0)
                    {
                        akordyDGV.Columns["WAT_WatId"].Visible = false;
                        akordyDGV.Columns["AKt_AkrId"].Visible = false;
                        akordyDGV.Columns["AKt_Nazwa"].ReadOnly = true;
                        akordyDGV.Columns["AKt_Nazwa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        akordyDGV.Columns["Wartość"].MinimumWidth = 220;
                    }

                    if(akordyDGV.Rows.Count > 0)
                    {
                        KolorujAkordyDGV();
                        akordyDGV.CurrentCell = akordyDGV.Rows[0].Cells["Wartość"];
                        akordyDGV.BeginEdit(true);
                    }
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd podczas pobierania listy akordów:\n)" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void KolorujAkordyDGV()
        {
            akordyDGV.CurrentCell = null;
            Boolean czyPracowal = true;
            /*
            if(string.IsNullOrEmpty(akordyDGV.Rows[0].Cells["Wartość"].Value.ToString()) || akordyDGV.Rows[0].Cells["Wartość"].Value.ToString() == "0")
            {
                czyPracowal = false;
            }

            for(int i = 0; i < akordyDGV.Rows.Count; i++)
            {
                Int32 AKR_AkrId = Convert.ToInt32(akordyDGV.Rows[i].Cells["AKT_AkrID"].Value.ToString());

                if(AKR_AkrId == 0)
                {
                    akordyDGV.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                }
                else if(AKR_AkrId < 100 && AKR_AkrId > 0)
                {
                    akordyDGV.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.DarkOrange;
                }
                else if(AKR_AkrId >= 100)
                {
                    akordyDGV.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
                }

                akordyDGV.Rows[i].Visible = czyPracowal;
            }
            akordyDGV.Rows[0].Visible = true;*/
            akordyDGV.CurrentCell = akordyDGV.Rows[0].Cells["Wartość"];
        }

        private DataTable poprawKolejnoscAkordow(DataTable lista)
        {
            DataTable dt1 = lista.Clone();
            DataTable dt2 = lista.Clone();

            for(int i = 0; i < lista.Rows.Count; i++)
            {
                int pomAkrID = Convert.ToInt32(lista.Rows[i]["AKT_AkrId"].ToString());
                if(pomAkrID < 100)
                {
                    dt1.Rows.Add(lista.Rows[i].ItemArray);
                }
                else
                {
                    dt2.Rows.Add(lista.Rows[i].ItemArray);
                }
            }

            DataView dv = dt2.DefaultView;
            dv.Sort = "akt_nazwa asc";
            dt2 = dv.ToTable();

            lista = new DataTable();
            lista = dt1.Copy();
            lista.Merge(dt2);

            return lista;
        }

        private void akordyDGV_CurrentCellChanged(object sender, EventArgs e)
        {
            if(akordyDGV.CurrentCell != null)
            {
                akordyDGV.BeginEdit(true);
            }
        }
    }
}
