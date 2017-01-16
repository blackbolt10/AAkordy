namespace AstraAkodry.Produkcja.Raporty
{
    partial class RaportyPracownikaProdukcjaForm
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
            this.kalendarzKonMC = new System.Windows.Forms.MonthCalendar();
            this.label18 = new System.Windows.Forms.Label();
            this.kalendarzPoczMC = new System.Windows.Forms.MonthCalendar();
            this.label19 = new System.Windows.Forms.Label();
            this.pracownicyLabel = new System.Windows.Forms.Label();
            this.pracownicyLB = new System.Windows.Forms.ListBox();
            this.pracownicyCB = new System.Windows.Forms.ComboBox();
            this.zamknijButton = new System.Windows.Forms.Button();
            this.raportLabel = new System.Windows.Forms.Label();
            this.raportDGV = new System.Windows.Forms.DataGridView();
            this.zbiorczyButton = new System.Windows.Forms.Button();
            this.szczegolowyButton = new System.Windows.Forms.Button();
            this.procentNormyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.raportDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // kalendarzKonMC
            // 
            this.kalendarzKonMC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.kalendarzKonMC.Location = new System.Drawing.Point(15, 224);
            this.kalendarzKonMC.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.kalendarzKonMC.MaxSelectionCount = 1;
            this.kalendarzKonMC.MinDate = new System.DateTime(1901, 1, 1, 0, 0, 0, 0);
            this.kalendarzKonMC.Name = "kalendarzKonMC";
            this.kalendarzKonMC.ShowToday = false;
            this.kalendarzKonMC.ShowTodayCircle = false;
            this.kalendarzKonMC.TabIndex = 55;
            this.kalendarzKonMC.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.kalendarzKonMC_DateChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(12, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(91, 13);
            this.label18.TabIndex = 53;
            this.label18.Text = "Data początkowa";
            // 
            // kalendarzPoczMC
            // 
            this.kalendarzPoczMC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.kalendarzPoczMC.Location = new System.Drawing.Point(15, 31);
            this.kalendarzPoczMC.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.kalendarzPoczMC.MaxSelectionCount = 1;
            this.kalendarzPoczMC.MinDate = new System.DateTime(1901, 1, 1, 0, 0, 0, 0);
            this.kalendarzPoczMC.Name = "kalendarzPoczMC";
            this.kalendarzPoczMC.ShowToday = false;
            this.kalendarzPoczMC.ShowTodayCircle = false;
            this.kalendarzPoczMC.TabIndex = 52;
            this.kalendarzPoczMC.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.kalendarzPoczMC_DateChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(12, 202);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 13);
            this.label19.TabIndex = 54;
            this.label19.Text = "Data końcowa";
            // 
            // pracownicyLabel
            // 
            this.pracownicyLabel.AutoSize = true;
            this.pracownicyLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pracownicyLabel.Location = new System.Drawing.Point(294, 9);
            this.pracownicyLabel.Name = "pracownicyLabel";
            this.pracownicyLabel.Size = new System.Drawing.Size(57, 13);
            this.pracownicyLabel.TabIndex = 63;
            this.pracownicyLabel.Text = "Pracownik";
            // 
            // pracownicyLB
            // 
            this.pracownicyLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pracownicyLB.FormattingEnabled = true;
            this.pracownicyLB.Location = new System.Drawing.Point(297, 58);
            this.pracownicyLB.Name = "pracownicyLB";
            this.pracownicyLB.Size = new System.Drawing.Size(180, 303);
            this.pracownicyLB.TabIndex = 61;
            this.pracownicyLB.SelectedIndexChanged += new System.EventHandler(this.pracownicyLB_SelectedIndexChanged);
            // 
            // pracownicyCB
            // 
            this.pracownicyCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.pracownicyCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.pracownicyCB.FormattingEnabled = true;
            this.pracownicyCB.Location = new System.Drawing.Point(296, 31);
            this.pracownicyCB.Name = "pracownicyCB";
            this.pracownicyCB.Size = new System.Drawing.Size(181, 21);
            this.pracownicyCB.TabIndex = 62;
            this.pracownicyCB.SelectedIndexChanged += new System.EventHandler(this.pracownicyCB_SelectedIndexChanged);
            // 
            // zamknijButton
            // 
            this.zamknijButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zamknijButton.BackgroundImage = global::AstraAkodry.Properties.Resources.koniec_32x32;
            this.zamknijButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zamknijButton.Location = new System.Drawing.Point(556, 356);
            this.zamknijButton.Name = "zamknijButton";
            this.zamknijButton.Size = new System.Drawing.Size(32, 32);
            this.zamknijButton.TabIndex = 64;
            this.zamknijButton.UseVisualStyleBackColor = true;
            this.zamknijButton.Click += new System.EventHandler(this.zamknijButton_Click);
            // 
            // raportLabel
            // 
            this.raportLabel.AutoSize = true;
            this.raportLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.raportLabel.Location = new System.Drawing.Point(483, 9);
            this.raportLabel.Name = "raportLabel";
            this.raportLabel.Size = new System.Drawing.Size(42, 13);
            this.raportLabel.TabIndex = 65;
            this.raportLabel.Text = "Raport:";
            // 
            // raportDGV
            // 
            this.raportDGV.AllowUserToAddRows = false;
            this.raportDGV.AllowUserToDeleteRows = false;
            this.raportDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.raportDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.raportDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.raportDGV.Location = new System.Drawing.Point(486, 31);
            this.raportDGV.MultiSelect = false;
            this.raportDGV.Name = "raportDGV";
            this.raportDGV.ReadOnly = true;
            this.raportDGV.RowHeadersVisible = false;
            this.raportDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.raportDGV.Size = new System.Drawing.Size(102, 319);
            this.raportDGV.TabIndex = 66;
            // 
            // zbiorczyButton
            // 
            this.zbiorczyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zbiorczyButton.Enabled = false;
            this.zbiorczyButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.zbiorczyButton.Location = new System.Drawing.Point(486, 365);
            this.zbiorczyButton.Name = "zbiorczyButton";
            this.zbiorczyButton.Size = new System.Drawing.Size(64, 23);
            this.zbiorczyButton.TabIndex = 69;
            this.zbiorczyButton.Text = "Zbiorczy";
            this.zbiorczyButton.UseVisualStyleBackColor = true;
            this.zbiorczyButton.Click += new System.EventHandler(this.zbiorczyButton_Click);
            // 
            // szczegolowyButton
            // 
            this.szczegolowyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.szczegolowyButton.Enabled = false;
            this.szczegolowyButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.szczegolowyButton.Location = new System.Drawing.Point(387, 365);
            this.szczegolowyButton.Name = "szczegolowyButton";
            this.szczegolowyButton.Size = new System.Drawing.Size(90, 23);
            this.szczegolowyButton.TabIndex = 68;
            this.szczegolowyButton.Text = "Szczegółowy";
            this.szczegolowyButton.UseVisualStyleBackColor = true;
            this.szczegolowyButton.Click += new System.EventHandler(this.szczegolowyButton_Click);
            // 
            // procentNormyButton
            // 
            this.procentNormyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.procentNormyButton.Enabled = false;
            this.procentNormyButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.procentNormyButton.Location = new System.Drawing.Point(291, 365);
            this.procentNormyButton.Name = "procentNormyButton";
            this.procentNormyButton.Size = new System.Drawing.Size(90, 23);
            this.procentNormyButton.TabIndex = 67;
            this.procentNormyButton.Text = "Wylicz % normy";
            this.procentNormyButton.UseVisualStyleBackColor = true;
            this.procentNormyButton.Click += new System.EventHandler(this.procentNormyButton_Click);
            // 
            // RaportyPracownikaProdukcjaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.zbiorczyButton);
            this.Controls.Add(this.szczegolowyButton);
            this.Controls.Add(this.procentNormyButton);
            this.Controls.Add(this.raportDGV);
            this.Controls.Add(this.raportLabel);
            this.Controls.Add(this.zamknijButton);
            this.Controls.Add(this.pracownicyLabel);
            this.Controls.Add(this.pracownicyLB);
            this.Controls.Add(this.pracownicyCB);
            this.Controls.Add(this.kalendarzKonMC);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.kalendarzPoczMC);
            this.Controls.Add(this.label19);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RaportyPracownikaProdukcjaForm";
            this.Text = "Raporty pracownika produkcja";
            this.Shown += new System.EventHandler(this.RaportyPracownikaProdukcjaForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.raportDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar kalendarzKonMC;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.MonthCalendar kalendarzPoczMC;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label pracownicyLabel;
        private System.Windows.Forms.ListBox pracownicyLB;
        private System.Windows.Forms.ComboBox pracownicyCB;
        private System.Windows.Forms.Button zamknijButton;
        private System.Windows.Forms.Label raportLabel;
        private System.Windows.Forms.DataGridView raportDGV;
        private System.Windows.Forms.Button zbiorczyButton;
        private System.Windows.Forms.Button szczegolowyButton;
        private System.Windows.Forms.Button procentNormyButton;
    }
}