using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AstraAkodry.Recepcja
{
    public partial class WprowadzanieAkordowForm : Form
    {
        private DataTable pracownicyDT;
        private string wartoscPoczatkowa;

        public WprowadzanieAkordowForm()
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
            pracownicyLabel.Location = new Point(kalendarzMC.Location.X + kalendarzMC.Size.Width + 10, dataLabel.Location.Y);

            pracownicyCB.Location = new Point(pracownicyLabel.Location.X, pracownicyLabel.Location.Y + pracownicyLabel.Size.Height + 10);

            if(MainForm.czcionka.Size > 20)
            {
                pracownicyCB.Size = new Size(kalendarzMC.Size.Width+50, pracownicyCB.Size.Height);
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

        private void pracownicyCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            pracownicyLB.SelectedIndex = pracownicyCB.SelectedIndex;
        }

        private void pracownicyLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            pracownicyCB.SelectedIndex = pracownicyLB.SelectedIndex;
            ZaladujListeAkordow();
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

                if(db.WprowadzanieAkordowForm_ZaladujListeAkordow(idPracownika, dataKalendarz, dataKalendarzZero, ref pomDataTable, ref result))
                {
                    akordyDGV.DataSource = pomDataTable;

                    if(akordyDGV.Columns.Count > 0)
                    {
                        akordyDGV.Columns["AKR_AkrId"].Visible = false;
                        akordyDGV.Columns["AKR_Nazwa"].ReadOnly = true;
                        akordyDGV.Columns["AKR_Nazwa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        akordyDGV.Columns["Wartość"].MinimumWidth = 220;
                    }

                    if(akordyDGV.Rows.Count > 0)
                    {
                        akordyDGV.CurrentCell = akordyDGV.Rows[0].Cells["Wartość"];
                        KolorujAkordyDGV();
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

            if(string.IsNullOrEmpty(akordyDGV.Rows[0].Cells["Wartość"].Value.ToString()) || akordyDGV.Rows[0].Cells["Wartość"].Value.ToString() == "0")
            {
                czyPracowal = false;
            }

            for(int i =0;i<akordyDGV.Rows.Count;i++)
            {                
                Int32 AKR_AkrId = Convert.ToInt32(akordyDGV.Rows[i].Cells["AKR_AkrID"].Value.ToString());

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
            akordyDGV.Rows[0].Visible = true;
            akordyDGV.CurrentCell = akordyDGV.Rows[0].Cells["Wartość"];
        }

        private void akordyDGV_KeyDown(object sender, KeyEventArgs e)
        {
            Int32 rowID = akordyDGV.CurrentCell.RowIndex;

            if(e.KeyCode == Keys.F2)
            {
                pracownicyCB.Focus();
                akordyDGV.EndEdit();
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

        private void pracownicyLB_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F2)
            {
                pracownicyCB.Focus();
            }
            else if(e.KeyCode == Keys.Enter)
            {
                akordyDGV.Focus();
            }
        }

        private void akordyDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(akordyDGV.Rows.Count>0)
            {
                akordyDGV.CurrentCell = akordyDGV.CurrentRow.Cells["Wartość"];
                akordyDGV.BeginEdit(true);
            }
        }

        private void akordyDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Int32 idAkordu = Convert.ToInt32(akordyDGV.CurrentRow.Cells["AKR_AkrId"].Value.ToString());
            String wartoscStringAkordu = akordyDGV.CurrentRow.Cells["Wartość"].Value.ToString();
            double wartoscAkordu = Convert.ToDouble(wartoscStringAkordu.Replace(',','.'));
            
            if(idAkordu == 0)
            {
                if(wartoscAkordu < 0 || wartoscAkordu >= 24)
                {
                    MessageBox.Show("Nie można zapisać wartości czasu pracy, ponieważ podana wartość jest mniejsza od 0 bądz większa od 24.", "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (wartoscAkordu == 0)
                {
                    if(SprawdzCzyUzupenionoInneAkordy())
                    {
                        MessageBox.Show("Nie można zapisać wartości czasu pracy, ponieważ są wprowadzone wartosci dla pracownika w danym dniu.", "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        ZapiszNowaWartosc(idAkordu, wartoscAkordu);
                    }
                }
                else
                {
                    ZapiszNowaWartosc(idAkordu, wartoscAkordu);
                }
            }
            else
            {
                ZapiszNowaWartosc(idAkordu, wartoscAkordu);
            }
            ZaladujListeAkordow();
        }

        private void ZapiszNowaWartosc(int idAkordu, double wartoscAkordu)
        {
            DBRepository db = new DBRepository();
            String IdPracownika = pracownicyDT.Rows[pracownicyLB.SelectedIndex]["PRA_PracId"].ToString();
            String result = "";

            if(db.WprowadzanieAkordowForm_ZapiszNowyAkord(IdPracownika, idAkordu, wartoscAkordu, kalendarzMC.SelectionStart, ref result))
            {

            }
            else
            {
                MessageBox.Show("Wystąpił błąd podczas zapisu:\n" + result + "\n\nProszę spróbowac ponownie", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool SprawdzCzyUzupenionoInneAkordy()
        {
            Boolean result = false;

            for(int i = 1; i<akordyDGV.Rows.Count;i++)
            {
                if(!string.IsNullOrEmpty(akordyDGV.Rows[i].Cells["Wartość"].Value.ToString()))
                {
                    if(akordyDGV.Rows[i].Cells["Wartość"].Value.ToString() != "0")
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
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
    }
}
