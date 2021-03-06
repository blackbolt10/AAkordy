﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AstraAkodry
{
    public partial class LoginForm : Form
    {
        private Panel loadPanel;
        private Label loadLabel;

        String wersjaProgramu = "3.1";
        String numerWersji = "a";

        private DataTable operatorzyDT;
        private String sciezkaRejestru = "Software\\Galsoft\\AstraAkordy\\LoginForm";

        public LoginForm(String[] args)
        {
            InitializeComponent();
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            CreateLoginScreen();

            loadLabel.Text += "Sprawdzanie połączenia z bazą danych...\n";

            DBRepository db = new DBRepository();
            String result = "";

            Boolean DBConnectResult = db.ConnectDataBase(ref result);

            if(DBConnectResult)
            {
                DateTime dataTeraz = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                String dateNowString = dataTeraz.ToShortDateString();

                String errorString = "";
                result = "";

                loadLabel.Text += "Sprawdzanie wersji programu...\n";

                if(db.GetAppVersion(ref result, ref errorString))
                {
                    if(wersjaProgramu == result)
                    {
                        loadLabel.Text += "Sprawdzanie daty serwera...\n";

                        String dataSerwer = "";
                        if(db.GetServerTime(ref dataSerwer))
                        {
                            if(dateNowString == dataSerwer)
                            {
                                wersjaTSSL.Text = "Wersja " + wersjaProgramu + numerWersji;

                                WczytajOperatorow();
                            }
                            else
                            {
                                MessageBox.Show("Data na komputerze jest niezgodna z datą serwera!\n\nProgram nie może zostać uruchomiony.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Wystapi błąd podczas sprawdzania daty serwera. Program zostanie zamkniety.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wersja programu jest inna niż bazy danych, proszę uaktualnić wersję!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Podczas pobierania wersji oprogramowania z bazy danych wystąpił błąd. Informacje o błędzie : " + errorString, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(result);
            }
            DeleteLoginScreen();
            passwordTB.Focus();
        }

        private void WczytajOperatorow()
        {
            loadLabel.Text += "Wczytywanie listy operatorów...\n";

            String result = "";
            DBRepository db = new DBRepository();            

            if(db.LoginForm_WczytajOperatorowDT(false, ref operatorzyDT, ref result))
            {
                if(operatorzyDT != null)
                {
                    for(int i = 0; i < operatorzyDT.Rows.Count; i++)
                    {
                        if(operatorzyDT.Rows[i]["OPR_Archiwalny"].ToString() != "1")
                        {
                            loginCB.Items.Add(operatorzyDT.Rows[i]["OPR_Nazwisko"] + " " + operatorzyDT.Rows[i]["OPR_Imie"]);
                        }
                    }

                    if(loginCB.Items.Count>0)
                    {
                        UstawLoginCB();
                    }
                }
            }
            else
            {
                MessageBox.Show("Wystąpił błąd podczas wczytywania listy operatorow: " + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UnhandledThreadExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            this.HandleUnhandledException(e.Exception);
        }

        public void HandleUnhandledException(Exception e)
        {
            DBRepository db;

            try
            {
                db = new DBRepository();
                db.ErrorReport("Aplikacja", "Błąd aplikacji " + e.TargetSite + " { koniec target site}" + e.HelpLink + " { koniec helplink}" + e.Message + "{ Koniec wiadomosci}");
            }
            catch(Exception) { }

            MessageBox.Show("Ups...\nWystąpił błąd aplikacji. \nRaport został przechwycony i przekazany obsłudze technicznej. " + Environment.NewLine + e.Message + "\nKontynuować?", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void CreateLoginScreen()
        {
            loadPanel = new Panel();
            loadLabel = new Label();

            loadLabel.AutoSize = true;
            loadLabel.Location = new Point(10, 10);
            loadLabel.Text = "Inicjalizacja obiektów...\n";

            loadPanel.Controls.Add(loadLabel);
            loadPanel.Location = new Point(5, 5);
            loadPanel.Size = new Size(this.Size.Width -25, this.Size.Height - 50);

            this.Controls.Add(loadPanel);
            loadPanel.BringToFront();
        }

        private void DeleteLoginScreen()
        {
            try
            {
                loadPanel.Dispose();
            }
            catch(Exception) { }
        }

        private string ZnajdzHasloOperatora()
        {
            String haslo = "";

            for(int i = 0; i < operatorzyDT.Rows.Count; i++)
            {
                String nazwa = operatorzyDT.Rows[i]["OPR_Nazwisko"].ToString() + " " + operatorzyDT.Rows[i]["OPR_Imie"].ToString();

                if(nazwa == loginCB.Items[loginCB.SelectedIndex].ToString())
                {
                    haslo = operatorzyDT.Rows[i]["OPR_Haslo"].ToString();
                    break;
                }
            }

            return haslo;
        }

        private void passwordTB_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Return)
            {
                loginButton.PerformClick();
            }
        }

        private void UstawLoginCB()
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(sciezkaRejestru);

            String IDOperatora = key.GetValue("OstatnioZalogowanyOperatorID", Location.X.ToString()).ToString();

            key.Close();
            int index = 0;

            if(IDOperatora != "" && operatorzyDT != null)
            {
                for(int i = 0; i < operatorzyDT.Rows.Count; i++)
                {
                    if(operatorzyDT.Rows[i]["OPR_OprId"].ToString() == IDOperatora)
                    {
                        index = i;
                    }
                }
            }

            loginCB.SelectedIndex = index;
        }

        private void ZapiszLoginID()
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(sciezkaRejestru);

            key.SetValue("OstatnioZalogowanyOperatorID", operatorzyDT.Rows[loginCB.SelectedIndex]["OPR_OprId"].ToString());

            key.Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if(passwordTB.Text != "" && loginCB.SelectedIndex != -1)
            {
                if(passwordTB.Text == ZnajdzHasloOperatora())
                {
                    ZapiszLoginID();

                    MainForm.IDOperatora = operatorzyDT.Rows[loginCB.SelectedIndex]["OPR_OprId"].ToString();
                    MainForm.UprawnieniaOperatora = Convert.ToInt32(operatorzyDT.Rows[loginCB.SelectedIndex]["OPR_Uprwnienia"].ToString());
                    MainForm.nazwaOperatora = loginCB.Items[loginCB.SelectedIndex].ToString();
                    MainForm.hasloOperatora = passwordTB.Text;

                    this.Hide();

                    MainForm main = new MainForm(wersjaTSSL.Text);
                    main.ShowDialog();

                    if(!main.czyWylogowano)
                    {
                        this.Close();
                    }
                    else
                    {
                        passwordTB.Text = "";
                        this.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Podane hasło jest nieprawidłowe.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    passwordTB.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano operatora lub nie wpisano hasła.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
