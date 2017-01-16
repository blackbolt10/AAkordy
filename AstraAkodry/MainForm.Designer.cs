namespace AstraAkodry
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.logoutRibbonOrbMenuItem = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
            this.closeRibbonOrbMenuItem = new System.Windows.Forms.RibbonOrbMenuItem();
            this.recepcjaRibbonTab = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.wprowadzanieRibbonButton = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.raportyRecepcjaRibbonButton = new System.Windows.Forms.RibbonButton();
            this.rapLeniRibbonButton = new System.Windows.Forms.RibbonButton();
            this.produkcjaRibbonTab = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.prodGlobalneRibbonButton = new System.Windows.Forms.RibbonButton();
            this.prodPracownikaRibbonButton = new System.Windows.Forms.RibbonButton();
            this.ksiegowoscRibbonTab = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel6 = new System.Windows.Forms.RibbonPanel();
            this.konfiguracjaRibbonTab = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.pracownicyRibbonButton = new System.Windows.Forms.RibbonButton();
            this.akordyRibbonButton = new System.Windows.Forms.RibbonButton();
            this.operatorzyRibbonButton = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.hasloRibbonButton = new System.Windows.Forms.RibbonButton();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.wersjaTSSL = new System.Windows.Forms.ToolStripStatusLabel();
            this.oknaCB = new System.Windows.Forms.ComboBox();
            this.zmienOknoLabel = new System.Windows.Forms.Label();
            this.ribbonOrbMenuItem1 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ksiegGlobalneRibbonButton = new System.Windows.Forms.RibbonButton();
            this.ksiegPracownikaRibbonButton = new System.Windows.Forms.RibbonButton();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.BorderMode = System.Windows.Forms.RibbonWindowMode.InsideWindow;
            this.ribbon1.CaptionBarVisible = false;
            this.ribbon1.Cursor = System.Windows.Forms.Cursors.Default;
            this.ribbon1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.logoutRibbonOrbMenuItem);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonSeparator1);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.closeRibbonOrbMenuItem);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 163);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbon1.OrbText = "Astra";
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(584, 122);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.recepcjaRibbonTab);
            this.ribbon1.Tabs.Add(this.produkcjaRibbonTab);
            this.ribbon1.Tabs.Add(this.ksiegowoscRibbonTab);
            this.ribbon1.Tabs.Add(this.konfiguracjaRibbonTab);
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 2, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // logoutRibbonOrbMenuItem
            // 
            this.logoutRibbonOrbMenuItem.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.logoutRibbonOrbMenuItem.Image = global::AstraAkodry.Properties.Resources.password_32x32;
            this.logoutRibbonOrbMenuItem.SmallImage = global::AstraAkodry.Properties.Resources.password_32x32;
            this.logoutRibbonOrbMenuItem.Text = "Wyloguj";
            this.logoutRibbonOrbMenuItem.Click += new System.EventHandler(this.logoutRibbonOrbMenuItem_Click);
            // 
            // closeRibbonOrbMenuItem
            // 
            this.closeRibbonOrbMenuItem.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.closeRibbonOrbMenuItem.Image = global::AstraAkodry.Properties.Resources.koniec_32x32;
            this.closeRibbonOrbMenuItem.SmallImage = global::AstraAkodry.Properties.Resources.koniec_32x32;
            this.closeRibbonOrbMenuItem.Text = "Zamknij";
            this.closeRibbonOrbMenuItem.Click += new System.EventHandler(this.closeRibbonOrbMenuItem_Click);
            // 
            // recepcjaRibbonTab
            // 
            this.recepcjaRibbonTab.Panels.Add(this.ribbonPanel1);
            this.recepcjaRibbonTab.Panels.Add(this.ribbonPanel2);
            this.recepcjaRibbonTab.Text = "Recepcja";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.wprowadzanieRibbonButton);
            this.ribbonPanel1.Text = "Dodawanie";
            // 
            // wprowadzanieRibbonButton
            // 
            this.wprowadzanieRibbonButton.Image = global::AstraAkodry.Properties.Resources.lista_dodawanie_32x32;
            this.wprowadzanieRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("wprowadzanieRibbonButton.SmallImage")));
            this.wprowadzanieRibbonButton.Text = "Wprowadzanie akordów";
            this.wprowadzanieRibbonButton.Click += new System.EventHandler(this.wprowadzanieribbonButton_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.raportyRecepcjaRibbonButton);
            this.ribbonPanel2.Items.Add(this.rapLeniRibbonButton);
            this.ribbonPanel2.Text = "Raporty";
            // 
            // raportyRecepcjaRibbonButton
            // 
            this.raportyRecepcjaRibbonButton.Image = global::AstraAkodry.Properties.Resources.greyGradient;
            this.raportyRecepcjaRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("raportyRecepcjaRibbonButton.SmallImage")));
            this.raportyRecepcjaRibbonButton.Text = "Raport recepcja";
            this.raportyRecepcjaRibbonButton.Click += new System.EventHandler(this.raportyRecepcjaribbonButton_Click);
            // 
            // rapLeniRibbonButton
            // 
            this.rapLeniRibbonButton.Image = global::AstraAkodry.Properties.Resources.len_32x32;
            this.rapLeniRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("rapLeniRibbonButton.SmallImage")));
            this.rapLeniRibbonButton.Text = "Raport \"leni\"";
            this.rapLeniRibbonButton.Click += new System.EventHandler(this.rapLeniRibbonButton_Click);
            // 
            // produkcjaRibbonTab
            // 
            this.produkcjaRibbonTab.Panels.Add(this.ribbonPanel5);
            this.produkcjaRibbonTab.Text = "Produkcja";
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.Items.Add(this.prodGlobalneRibbonButton);
            this.ribbonPanel5.Items.Add(this.prodPracownikaRibbonButton);
            this.ribbonPanel5.Text = "Raporty";
            // 
            // prodGlobalneRibbonButton
            // 
            this.prodGlobalneRibbonButton.Image = global::AstraAkodry.Properties.Resources.greyGradient;
            this.prodGlobalneRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("prodGlobalneRibbonButton.SmallImage")));
            this.prodGlobalneRibbonButton.Text = "Globalne";
            this.prodGlobalneRibbonButton.Click += new System.EventHandler(this.globalneRibbonButton_Click);
            // 
            // prodPracownikaRibbonButton
            // 
            this.prodPracownikaRibbonButton.Image = global::AstraAkodry.Properties.Resources.greyGradient;
            this.prodPracownikaRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("prodPracownikaRibbonButton.SmallImage")));
            this.prodPracownikaRibbonButton.Text = "Pracownika";
            this.prodPracownikaRibbonButton.Click += new System.EventHandler(this.pracownikaRibbonButton_Click);
            // 
            // ksiegowoscRibbonTab
            // 
            this.ksiegowoscRibbonTab.Panels.Add(this.ribbonPanel6);
            this.ksiegowoscRibbonTab.Text = "Księgowość";
            // 
            // ribbonPanel6
            // 
            this.ribbonPanel6.Items.Add(this.ksiegGlobalneRibbonButton);
            this.ribbonPanel6.Items.Add(this.ksiegPracownikaRibbonButton);
            this.ribbonPanel6.Text = "Raporty";
            // 
            // konfiguracjaRibbonTab
            // 
            this.konfiguracjaRibbonTab.Panels.Add(this.ribbonPanel3);
            this.konfiguracjaRibbonTab.Panels.Add(this.ribbonPanel4);
            this.konfiguracjaRibbonTab.Text = "Konfiguracja";
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Items.Add(this.pracownicyRibbonButton);
            this.ribbonPanel3.Items.Add(this.akordyRibbonButton);
            this.ribbonPanel3.Items.Add(this.operatorzyRibbonButton);
            this.ribbonPanel3.Text = "Ustawienia";
            // 
            // pracownicyRibbonButton
            // 
            this.pracownicyRibbonButton.Image = global::AstraAkodry.Properties.Resources.Klienci_ustawienia_32x32;
            this.pracownicyRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("pracownicyRibbonButton.SmallImage")));
            this.pracownicyRibbonButton.Text = "Pracownicy";
            this.pracownicyRibbonButton.Click += new System.EventHandler(this.pracownicyRibbonButton_Click);
            // 
            // akordyRibbonButton
            // 
            this.akordyRibbonButton.Image = global::AstraAkodry.Properties.Resources.harmonogram_ustawienia_32x32;
            this.akordyRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("akordyRibbonButton.SmallImage")));
            this.akordyRibbonButton.Text = "Akordy";
            this.akordyRibbonButton.Click += new System.EventHandler(this.akordyRibbonButton_Click);
            // 
            // operatorzyRibbonButton
            // 
            this.operatorzyRibbonButton.Image = global::AstraAkodry.Properties.Resources.Operatorzy_ustawienia_32x32;
            this.operatorzyRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("operatorzyRibbonButton.SmallImage")));
            this.operatorzyRibbonButton.Text = "Operatorzy";
            this.operatorzyRibbonButton.Click += new System.EventHandler(this.operatorzyRibbonButton_Click);
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.Items.Add(this.hasloRibbonButton);
            this.ribbonPanel4.Text = "Zmiana hasła";
            // 
            // hasloRibbonButton
            // 
            this.hasloRibbonButton.Image = global::AstraAkodry.Properties.Resources.password_32x32;
            this.hasloRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("hasloRibbonButton.SmallImage")));
            this.hasloRibbonButton.Text = "Hasło";
            this.hasloRibbonButton.Click += new System.EventHandler(this.hasloRibbonButton_Click);
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Text = "ribbonTab1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wersjaTSSL});
            this.statusStrip1.Location = new System.Drawing.Point(0, 339);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(584, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // wersjaTSSL
            // 
            this.wersjaTSSL.Name = "wersjaTSSL";
            this.wersjaTSSL.Size = new System.Drawing.Size(69, 17);
            this.wersjaTSSL.Text = "Wersja X.XX";
            // 
            // oknaCB
            // 
            this.oknaCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.oknaCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.oknaCB.FormattingEnabled = true;
            this.oknaCB.Location = new System.Drawing.Point(404, 3);
            this.oknaCB.Name = "oknaCB";
            this.oknaCB.Size = new System.Drawing.Size(180, 21);
            this.oknaCB.TabIndex = 4;
            this.oknaCB.Visible = false;
            // 
            // zmienOknoLabel
            // 
            this.zmienOknoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zmienOknoLabel.AutoSize = true;
            this.zmienOknoLabel.Location = new System.Drawing.Point(335, 6);
            this.zmienOknoLabel.Name = "zmienOknoLabel";
            this.zmienOknoLabel.Size = new System.Drawing.Size(63, 13);
            this.zmienOknoLabel.TabIndex = 5;
            this.zmienOknoLabel.Text = "Zmień okno";
            this.zmienOknoLabel.Visible = false;
            // 
            // ribbonOrbMenuItem1
            // 
            this.ribbonOrbMenuItem1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.Image")));
            this.ribbonOrbMenuItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.SmallImage")));
            this.ribbonOrbMenuItem1.Text = "ribbonOrbMenuItem1";
            // 
            // ksiegGlobalneRibbonButton
            // 
            this.ksiegGlobalneRibbonButton.Image = global::AstraAkodry.Properties.Resources.greyGradient;
            this.ksiegGlobalneRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("ksiegGlobalneRibbonButton.SmallImage")));
            this.ksiegGlobalneRibbonButton.Text = "Globalne";
            this.ksiegGlobalneRibbonButton.Click += new System.EventHandler(this.ksiegGlobalneRibbonButton_Click);
            // 
            // ksiegPracownikaRibbonButton
            // 
            this.ksiegPracownikaRibbonButton.Image = global::AstraAkodry.Properties.Resources.greyGradient;
            this.ksiegPracownikaRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("ksiegPracownikaRibbonButton.SmallImage")));
            this.ksiegPracownikaRibbonButton.Text = "Pracownika";
            this.ksiegPracownikaRibbonButton.Click += new System.EventHandler(this.ksiegPracownikaRibbonButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.zmienOknoLabel);
            this.Controls.Add(this.oknaCB);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbon1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "Astra akordy";
            this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab recepcjaRibbonTab;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel wersjaTSSL;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonTab konfiguracjaRibbonTab;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton wprowadzanieRibbonButton;
        private System.Windows.Forms.RibbonButton raportyRecepcjaRibbonButton;
        private System.Windows.Forms.RibbonButton pracownicyRibbonButton;
        private System.Windows.Forms.RibbonButton akordyRibbonButton;
        private System.Windows.Forms.RibbonButton operatorzyRibbonButton;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonButton hasloRibbonButton;
        private System.Windows.Forms.ComboBox oknaCB;
        private System.Windows.Forms.Label zmienOknoLabel;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem1;
        private System.Windows.Forms.RibbonOrbMenuItem closeRibbonOrbMenuItem;
        private System.Windows.Forms.RibbonButton rapLeniRibbonButton;
        private System.Windows.Forms.RibbonOrbMenuItem logoutRibbonOrbMenuItem;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
        private System.Windows.Forms.RibbonTab produkcjaRibbonTab;
        private System.Windows.Forms.RibbonTab ksiegowoscRibbonTab;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonButton prodGlobalneRibbonButton;
        private System.Windows.Forms.RibbonPanel ribbonPanel6;
        private System.Windows.Forms.RibbonButton prodPracownikaRibbonButton;
        private System.Windows.Forms.RibbonButton ksiegGlobalneRibbonButton;
        private System.Windows.Forms.RibbonButton ksiegPracownikaRibbonButton;
    }
}

