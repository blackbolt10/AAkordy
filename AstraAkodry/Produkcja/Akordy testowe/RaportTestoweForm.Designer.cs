namespace AstraAkodry.Produkcja.Akordy_testowe
{
    partial class RaportTestoweForm
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
            this.zamknijButton = new System.Windows.Forms.Button();
            this.raportDGV = new System.Windows.Forms.DataGridView();
            this.dataOdLabel = new System.Windows.Forms.Label();
            this.kalendarzPoczMC = new System.Windows.Forms.MonthCalendar();
            this.dataDoLabel = new System.Windows.Forms.Label();
            this.kalendarzKonMC = new System.Windows.Forms.MonthCalendar();
            this.raportLabel = new System.Windows.Forms.Label();
            this.reloadButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.raportDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // zamknijButton
            // 
            this.zamknijButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zamknijButton.BackgroundImage = global::AstraAkodry.Properties.Resources.koniec_32x32;
            this.zamknijButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zamknijButton.Location = new System.Drawing.Point(556, 358);
            this.zamknijButton.Name = "zamknijButton";
            this.zamknijButton.Size = new System.Drawing.Size(32, 32);
            this.zamknijButton.TabIndex = 106;
            this.zamknijButton.UseVisualStyleBackColor = true;
            this.zamknijButton.Click += new System.EventHandler(this.zamknijButton_Click);
            // 
            // raportDGV
            // 
            this.raportDGV.AllowUserToAddRows = false;
            this.raportDGV.AllowUserToDeleteRows = false;
            this.raportDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.raportDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.raportDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.raportDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.raportDGV.Location = new System.Drawing.Point(302, 33);
            this.raportDGV.MultiSelect = false;
            this.raportDGV.Name = "raportDGV";
            this.raportDGV.ReadOnly = true;
            this.raportDGV.RowHeadersVisible = false;
            this.raportDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.raportDGV.Size = new System.Drawing.Size(286, 319);
            this.raportDGV.TabIndex = 105;
            // 
            // dataOdLabel
            // 
            this.dataOdLabel.AutoSize = true;
            this.dataOdLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataOdLabel.Location = new System.Drawing.Point(12, 11);
            this.dataOdLabel.Name = "dataOdLabel";
            this.dataOdLabel.Size = new System.Drawing.Size(48, 13);
            this.dataOdLabel.TabIndex = 104;
            this.dataOdLabel.Text = "Data od:";
            // 
            // kalendarzPoczMC
            // 
            this.kalendarzPoczMC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.kalendarzPoczMC.Location = new System.Drawing.Point(18, 33);
            this.kalendarzPoczMC.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.kalendarzPoczMC.MaxSelectionCount = 1;
            this.kalendarzPoczMC.MinDate = new System.DateTime(1901, 1, 1, 0, 0, 0, 0);
            this.kalendarzPoczMC.Name = "kalendarzPoczMC";
            this.kalendarzPoczMC.ShowToday = false;
            this.kalendarzPoczMC.ShowTodayCircle = false;
            this.kalendarzPoczMC.TabIndex = 103;
            this.kalendarzPoczMC.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.kalendarzPoczMC_DateChanged);
            // 
            // dataDoLabel
            // 
            this.dataDoLabel.AutoSize = true;
            this.dataDoLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataDoLabel.Location = new System.Drawing.Point(15, 206);
            this.dataDoLabel.Name = "dataDoLabel";
            this.dataDoLabel.Size = new System.Drawing.Size(48, 13);
            this.dataDoLabel.TabIndex = 108;
            this.dataDoLabel.Text = "Data do:";
            // 
            // kalendarzKonMC
            // 
            this.kalendarzKonMC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.kalendarzKonMC.Location = new System.Drawing.Point(21, 228);
            this.kalendarzKonMC.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.kalendarzKonMC.MaxSelectionCount = 1;
            this.kalendarzKonMC.MinDate = new System.DateTime(1901, 1, 1, 0, 0, 0, 0);
            this.kalendarzKonMC.Name = "kalendarzKonMC";
            this.kalendarzKonMC.ShowToday = false;
            this.kalendarzKonMC.ShowTodayCircle = false;
            this.kalendarzKonMC.TabIndex = 107;
            this.kalendarzKonMC.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.kalendarzKonMC_DateChanged);
            // 
            // raportLabel
            // 
            this.raportLabel.AutoSize = true;
            this.raportLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.raportLabel.Location = new System.Drawing.Point(299, 11);
            this.raportLabel.Name = "raportLabel";
            this.raportLabel.Size = new System.Drawing.Size(42, 13);
            this.raportLabel.TabIndex = 109;
            this.raportLabel.Text = "Raport:";
            // 
            // reloadButton
            // 
            this.reloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reloadButton.BackgroundImage = global::AstraAkodry.Properties.Resources.odswiez_32x32;
            this.reloadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.reloadButton.Location = new System.Drawing.Point(518, 358);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(32, 32);
            this.reloadButton.TabIndex = 110;
            this.reloadButton.UseVisualStyleBackColor = true;
            this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // RaportTestoweForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.reloadButton);
            this.Controls.Add(this.raportLabel);
            this.Controls.Add(this.dataDoLabel);
            this.Controls.Add(this.kalendarzKonMC);
            this.Controls.Add(this.zamknijButton);
            this.Controls.Add(this.raportDGV);
            this.Controls.Add(this.dataOdLabel);
            this.Controls.Add(this.kalendarzPoczMC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RaportTestoweForm";
            this.Text = "Raport \"Testowe\"";
            this.Shown += new System.EventHandler(this.RaportTestoweForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.raportDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button zamknijButton;
        private System.Windows.Forms.DataGridView raportDGV;
        private System.Windows.Forms.Label dataOdLabel;
        private System.Windows.Forms.MonthCalendar kalendarzPoczMC;
        private System.Windows.Forms.Label dataDoLabel;
        private System.Windows.Forms.MonthCalendar kalendarzKonMC;
        private System.Windows.Forms.Label raportLabel;
        private System.Windows.Forms.Button reloadButton;
    }
}