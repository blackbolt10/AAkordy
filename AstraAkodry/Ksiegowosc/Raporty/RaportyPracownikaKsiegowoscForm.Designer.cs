namespace AstraAkodry.Ksiegowosc.Raporty
{
    partial class RaportyPracownikaKsiegowoscForm
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
            this.lenieButton = new System.Windows.Forms.Button();
            this.szczegolowyButton = new System.Windows.Forms.Button();
            this.raportPoprawekButton = new System.Windows.Forms.Button();
            this.raportDGV = new System.Windows.Forms.DataGridView();
            this.raportLabel = new System.Windows.Forms.Label();
            this.pracownicyLabel = new System.Windows.Forms.Label();
            this.pracownicyLB = new System.Windows.Forms.ListBox();
            this.pracownicyCB = new System.Windows.Forms.ComboBox();
            this.kalendarzKonMC = new System.Windows.Forms.MonthCalendar();
            this.label18 = new System.Windows.Forms.Label();
            this.kalendarzPoczMC = new System.Windows.Forms.MonthCalendar();
            this.label19 = new System.Windows.Forms.Label();
            this.zamknijButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.raportDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // lenieButton
            // 
            this.lenieButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lenieButton.Enabled = false;
            this.lenieButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lenieButton.Location = new System.Drawing.Point(486, 367);
            this.lenieButton.Name = "lenieButton";
            this.lenieButton.Size = new System.Drawing.Size(64, 23);
            this.lenieButton.TabIndex = 82;
            this.lenieButton.Text = "\"Lenie\"";
            this.lenieButton.UseVisualStyleBackColor = true;
            this.lenieButton.Click += new System.EventHandler(this.lenieButton_Click);
            // 
            // szczegolowyButton
            // 
            this.szczegolowyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.szczegolowyButton.Enabled = false;
            this.szczegolowyButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.szczegolowyButton.Location = new System.Drawing.Point(387, 367);
            this.szczegolowyButton.Name = "szczegolowyButton";
            this.szczegolowyButton.Size = new System.Drawing.Size(90, 23);
            this.szczegolowyButton.TabIndex = 81;
            this.szczegolowyButton.Text = "Szczegółowy";
            this.szczegolowyButton.UseVisualStyleBackColor = true;
            this.szczegolowyButton.Click += new System.EventHandler(this.szczegolowyButton_Click);
            // 
            // raportPoprawekButton
            // 
            this.raportPoprawekButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.raportPoprawekButton.Enabled = false;
            this.raportPoprawekButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.raportPoprawekButton.Location = new System.Drawing.Point(291, 367);
            this.raportPoprawekButton.Name = "raportPoprawekButton";
            this.raportPoprawekButton.Size = new System.Drawing.Size(90, 23);
            this.raportPoprawekButton.TabIndex = 80;
            this.raportPoprawekButton.Text = "Poprawki";
            this.raportPoprawekButton.UseVisualStyleBackColor = true;
            this.raportPoprawekButton.Click += new System.EventHandler(this.raportPoprawekButton_Click);
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
            this.raportDGV.Location = new System.Drawing.Point(486, 33);
            this.raportDGV.MultiSelect = false;
            this.raportDGV.Name = "raportDGV";
            this.raportDGV.ReadOnly = true;
            this.raportDGV.RowHeadersVisible = false;
            this.raportDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.raportDGV.Size = new System.Drawing.Size(102, 319);
            this.raportDGV.TabIndex = 79;
            // 
            // raportLabel
            // 
            this.raportLabel.AutoSize = true;
            this.raportLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.raportLabel.Location = new System.Drawing.Point(483, 11);
            this.raportLabel.Name = "raportLabel";
            this.raportLabel.Size = new System.Drawing.Size(42, 13);
            this.raportLabel.TabIndex = 78;
            this.raportLabel.Text = "Raport:";
            // 
            // pracownicyLabel
            // 
            this.pracownicyLabel.AutoSize = true;
            this.pracownicyLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pracownicyLabel.Location = new System.Drawing.Point(294, 11);
            this.pracownicyLabel.Name = "pracownicyLabel";
            this.pracownicyLabel.Size = new System.Drawing.Size(57, 13);
            this.pracownicyLabel.TabIndex = 76;
            this.pracownicyLabel.Text = "Pracownik";
            // 
            // pracownicyLB
            // 
            this.pracownicyLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pracownicyLB.FormattingEnabled = true;
            this.pracownicyLB.Location = new System.Drawing.Point(297, 60);
            this.pracownicyLB.Name = "pracownicyLB";
            this.pracownicyLB.Size = new System.Drawing.Size(180, 303);
            this.pracownicyLB.TabIndex = 74;
            this.pracownicyLB.SelectedIndexChanged += new System.EventHandler(this.pracownicyLB_SelectedIndexChanged);
            // 
            // pracownicyCB
            // 
            this.pracownicyCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.pracownicyCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.pracownicyCB.FormattingEnabled = true;
            this.pracownicyCB.Location = new System.Drawing.Point(296, 33);
            this.pracownicyCB.Name = "pracownicyCB";
            this.pracownicyCB.Size = new System.Drawing.Size(181, 21);
            this.pracownicyCB.TabIndex = 75;
            this.pracownicyCB.SelectedIndexChanged += new System.EventHandler(this.pracownicyCB_SelectedIndexChanged);
            // 
            // kalendarzKonMC
            // 
            this.kalendarzKonMC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.kalendarzKonMC.Location = new System.Drawing.Point(15, 226);
            this.kalendarzKonMC.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.kalendarzKonMC.MaxSelectionCount = 1;
            this.kalendarzKonMC.MinDate = new System.DateTime(1901, 1, 1, 0, 0, 0, 0);
            this.kalendarzKonMC.Name = "kalendarzKonMC";
            this.kalendarzKonMC.ShowToday = false;
            this.kalendarzKonMC.ShowTodayCircle = false;
            this.kalendarzKonMC.TabIndex = 73;
            this.kalendarzKonMC.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.kalendarzKonMC_DateChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(12, 11);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(91, 13);
            this.label18.TabIndex = 71;
            this.label18.Text = "Data początkowa";
            // 
            // kalendarzPoczMC
            // 
            this.kalendarzPoczMC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.kalendarzPoczMC.Location = new System.Drawing.Point(15, 33);
            this.kalendarzPoczMC.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.kalendarzPoczMC.MaxSelectionCount = 1;
            this.kalendarzPoczMC.MinDate = new System.DateTime(1901, 1, 1, 0, 0, 0, 0);
            this.kalendarzPoczMC.Name = "kalendarzPoczMC";
            this.kalendarzPoczMC.ShowToday = false;
            this.kalendarzPoczMC.ShowTodayCircle = false;
            this.kalendarzPoczMC.TabIndex = 70;
            this.kalendarzPoczMC.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.kalendarzPoczMC_DateChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(12, 204);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 13);
            this.label19.TabIndex = 72;
            this.label19.Text = "Data końcowa";
            // 
            // zamknijButton
            // 
            this.zamknijButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zamknijButton.BackgroundImage = global::AstraAkodry.Properties.Resources.koniec_32x32;
            this.zamknijButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zamknijButton.Location = new System.Drawing.Point(556, 358);
            this.zamknijButton.Name = "zamknijButton";
            this.zamknijButton.Size = new System.Drawing.Size(32, 32);
            this.zamknijButton.TabIndex = 77;
            this.zamknijButton.UseVisualStyleBackColor = true;
            this.zamknijButton.Click += new System.EventHandler(this.zamknijButton_Click);
            // 
            // RaportyPracownikaKsiegowoscForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.lenieButton);
            this.Controls.Add(this.szczegolowyButton);
            this.Controls.Add(this.raportPoprawekButton);
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
            this.Name = "RaportyPracownikaKsiegowoscForm";
            this.Text = "Raporty pracownika księgowość";
            this.Shown += new System.EventHandler(this.RaportyPracownikaKsiegowoscForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.raportDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button lenieButton;
        private System.Windows.Forms.Button szczegolowyButton;
        private System.Windows.Forms.Button raportPoprawekButton;
        private System.Windows.Forms.DataGridView raportDGV;
        private System.Windows.Forms.Label raportLabel;
        private System.Windows.Forms.Button zamknijButton;
        private System.Windows.Forms.Label pracownicyLabel;
        private System.Windows.Forms.ListBox pracownicyLB;
        private System.Windows.Forms.ComboBox pracownicyCB;
        private System.Windows.Forms.MonthCalendar kalendarzKonMC;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.MonthCalendar kalendarzPoczMC;
        private System.Windows.Forms.Label label19;
    }
}