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
            this.recepcjaRibbonTab = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.wprowadzanieribbonButton = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.raportyRecepcjaribbonButton = new System.Windows.Forms.RibbonButton();
            this.konfiguracjaRibbonTab = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.pracownicyRibbonButton = new System.Windows.Forms.RibbonButton();
            this.akordyRibbonButton = new System.Windows.Forms.RibbonButton();
            this.operatorzyRibbonButton = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.hasloRibbonButton = new System.Windows.Forms.RibbonButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.wersjaTSSL = new System.Windows.Forms.ToolStripStatusLabel();
            this.oknaCB = new System.Windows.Forms.ComboBox();
            this.zmienOknoLabel = new System.Windows.Forms.Label();
            this.ribbonOrbMenuItem1 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.closeRibbonOrbMenuItem = new System.Windows.Forms.RibbonOrbMenuItem();
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
            this.ribbon1.OrbDropDown.MenuItems.Add(this.closeRibbonOrbMenuItem);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 116);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbon1.OrbText = "Astra";
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(584, 122);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.recepcjaRibbonTab);
            this.ribbon1.Tabs.Add(this.konfiguracjaRibbonTab);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 2, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // recepcjaRibbonTab
            // 
            this.recepcjaRibbonTab.Panels.Add(this.ribbonPanel1);
            this.recepcjaRibbonTab.Panels.Add(this.ribbonPanel2);
            this.recepcjaRibbonTab.Text = "Recepcja";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.wprowadzanieribbonButton);
            this.ribbonPanel1.Text = "Dodawanie";
            // 
            // wprowadzanieribbonButton
            // 
            this.wprowadzanieribbonButton.Image = global::AstraAkodry.Properties.Resources.greyGradient;
            this.wprowadzanieribbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("wprowadzanieribbonButton.SmallImage")));
            this.wprowadzanieribbonButton.Text = "Wprowadzanie akordów";
            this.wprowadzanieribbonButton.Click += new System.EventHandler(this.wprowadzanieribbonButton_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.raportyRecepcjaribbonButton);
            this.ribbonPanel2.Text = "Raporty";
            // 
            // raportyRecepcjaribbonButton
            // 
            this.raportyRecepcjaribbonButton.Image = global::AstraAkodry.Properties.Resources.greyGradient;
            this.raportyRecepcjaribbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("raportyRecepcjaribbonButton.SmallImage")));
            this.raportyRecepcjaribbonButton.Text = "Raport recepcja";
            this.raportyRecepcjaribbonButton.Click += new System.EventHandler(this.raportyRecepcjaribbonButton_Click);
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
            this.pracownicyRibbonButton.Image = global::AstraAkodry.Properties.Resources.greyGradient;
            this.pracownicyRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("pracownicyRibbonButton.SmallImage")));
            this.pracownicyRibbonButton.Text = "Pracownicy";
            this.pracownicyRibbonButton.Click += new System.EventHandler(this.pracownicyRibbonButton_Click);
            // 
            // akordyRibbonButton
            // 
            this.akordyRibbonButton.Image = global::AstraAkodry.Properties.Resources.greyGradient;
            this.akordyRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("akordyRibbonButton.SmallImage")));
            this.akordyRibbonButton.Text = "Akordy";
            this.akordyRibbonButton.Click += new System.EventHandler(this.akordyRibbonButton_Click);
            // 
            // operatorzyRibbonButton
            // 
            this.operatorzyRibbonButton.Image = global::AstraAkodry.Properties.Resources.greyGradient;
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
            this.hasloRibbonButton.Image = global::AstraAkodry.Properties.Resources.greyGradient;
            this.hasloRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("hasloRibbonButton.SmallImage")));
            this.hasloRibbonButton.Text = "Hasło";
            this.hasloRibbonButton.Click += new System.EventHandler(this.hasloRibbonButton_Click);
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
            // closeRibbonOrbMenuItem
            // 
            this.closeRibbonOrbMenuItem.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.closeRibbonOrbMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("closeRibbonOrbMenuItem.Image")));
            this.closeRibbonOrbMenuItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("closeRibbonOrbMenuItem.SmallImage")));
            this.closeRibbonOrbMenuItem.Text = "Zamknij";
            this.closeRibbonOrbMenuItem.Click += new System.EventHandler(this.closeRibbonOrbMenuItem_Click);
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
        private System.Windows.Forms.RibbonButton wprowadzanieribbonButton;
        private System.Windows.Forms.RibbonButton raportyRecepcjaribbonButton;
        private System.Windows.Forms.RibbonButton pracownicyRibbonButton;
        private System.Windows.Forms.RibbonButton akordyRibbonButton;
        private System.Windows.Forms.RibbonButton operatorzyRibbonButton;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonButton hasloRibbonButton;
        private System.Windows.Forms.ComboBox oknaCB;
        private System.Windows.Forms.Label zmienOknoLabel;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem1;
        private System.Windows.Forms.RibbonOrbMenuItem closeRibbonOrbMenuItem;
    }
}

