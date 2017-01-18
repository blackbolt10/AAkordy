namespace AstraAkodry.Produkcja.Raporty
{
    partial class RaportyGlobalneProdukcjaForm
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
            this.kalendarzKonMC = new System.Windows.Forms.MonthCalendar();
            this.dataPoczLabel = new System.Windows.Forms.Label();
            this.kalendarzPoczMC = new System.Windows.Forms.MonthCalendar();
            this.dataKonLabel = new System.Windows.Forms.Label();
            this.ponizejNormyButton = new System.Windows.Forms.Button();
            this.globalnyButton = new System.Windows.Forms.Button();
            this.lenieButton = new System.Windows.Forms.Button();
            this.raportLabel1 = new System.Windows.Forms.Label();
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
            this.zamknijButton.TabIndex = 96;
            this.zamknijButton.UseVisualStyleBackColor = true;
            this.zamknijButton.Click += new System.EventHandler(this.zamknijButton_Click);
            // 
            // raportDGV
            // 
            this.raportDGV.AllowUserToAddRows = false;
            this.raportDGV.AllowUserToDeleteRows = false;
            this.raportDGV.AllowUserToResizeRows = false;
            this.raportDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.raportDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
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
            this.raportDGV.TabIndex = 95;
            // 
            // kalendarzKonMC
            // 
            this.kalendarzKonMC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.kalendarzKonMC.Location = new System.Drawing.Point(18, 226);
            this.kalendarzKonMC.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.kalendarzKonMC.MaxSelectionCount = 1;
            this.kalendarzKonMC.MinDate = new System.DateTime(1901, 1, 1, 0, 0, 0, 0);
            this.kalendarzKonMC.Name = "kalendarzKonMC";
            this.kalendarzKonMC.ShowToday = false;
            this.kalendarzKonMC.ShowTodayCircle = false;
            this.kalendarzKonMC.TabIndex = 93;
            this.kalendarzKonMC.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.kalendarzKonMC_DateChanged);
            // 
            // dataPoczLabel
            // 
            this.dataPoczLabel.AutoSize = true;
            this.dataPoczLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataPoczLabel.Location = new System.Drawing.Point(12, 11);
            this.dataPoczLabel.Name = "dataPoczLabel";
            this.dataPoczLabel.Size = new System.Drawing.Size(94, 13);
            this.dataPoczLabel.TabIndex = 91;
            this.dataPoczLabel.Text = "Data początkowa:";
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
            this.kalendarzPoczMC.TabIndex = 90;
            this.kalendarzPoczMC.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.kalendarzPoczMC_DateChanged);
            // 
            // dataKonLabel
            // 
            this.dataKonLabel.AutoSize = true;
            this.dataKonLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataKonLabel.Location = new System.Drawing.Point(15, 204);
            this.dataKonLabel.Name = "dataKonLabel";
            this.dataKonLabel.Size = new System.Drawing.Size(80, 13);
            this.dataKonLabel.TabIndex = 92;
            this.dataKonLabel.Text = "Data końcowa:";
            // 
            // ponizejNormyButton
            // 
            this.ponizejNormyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ponizejNormyButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ponizejNormyButton.Location = new System.Drawing.Point(470, 363);
            this.ponizejNormyButton.Name = "ponizejNormyButton";
            this.ponizejNormyButton.Size = new System.Drawing.Size(80, 23);
            this.ponizejNormyButton.TabIndex = 89;
            this.ponizejNormyButton.Text = "Poniżej normy";
            this.ponizejNormyButton.UseVisualStyleBackColor = true;
            this.ponizejNormyButton.Click += new System.EventHandler(this.ponizejNormyButton_Click);
            // 
            // globalnyButton
            // 
            this.globalnyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.globalnyButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.globalnyButton.Location = new System.Drawing.Point(298, 363);
            this.globalnyButton.Name = "globalnyButton";
            this.globalnyButton.Size = new System.Drawing.Size(80, 23);
            this.globalnyButton.TabIndex = 88;
            this.globalnyButton.Text = "Globalny";
            this.globalnyButton.UseVisualStyleBackColor = true;
            this.globalnyButton.Click += new System.EventHandler(this.globalnyButton_Click);
            // 
            // lenieButton
            // 
            this.lenieButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lenieButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lenieButton.Location = new System.Drawing.Point(384, 363);
            this.lenieButton.Name = "lenieButton";
            this.lenieButton.Size = new System.Drawing.Size(80, 23);
            this.lenieButton.TabIndex = 87;
            this.lenieButton.Text = "\"Lenie\"";
            this.lenieButton.UseVisualStyleBackColor = true;
            this.lenieButton.Click += new System.EventHandler(this.lenieButton_Click);
            // 
            // raportLabel1
            // 
            this.raportLabel1.AutoSize = true;
            this.raportLabel1.Location = new System.Drawing.Point(299, 11);
            this.raportLabel1.Name = "raportLabel1";
            this.raportLabel1.Size = new System.Drawing.Size(42, 13);
            this.raportLabel1.TabIndex = 97;
            this.raportLabel1.Text = "Raport:";
            // 
            // RaportyGlobalneProdukcjaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.raportLabel1);
            this.Controls.Add(this.zamknijButton);
            this.Controls.Add(this.raportDGV);
            this.Controls.Add(this.kalendarzKonMC);
            this.Controls.Add(this.dataPoczLabel);
            this.Controls.Add(this.kalendarzPoczMC);
            this.Controls.Add(this.dataKonLabel);
            this.Controls.Add(this.ponizejNormyButton);
            this.Controls.Add(this.globalnyButton);
            this.Controls.Add(this.lenieButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RaportyGlobalneProdukcjaForm";
            this.Text = "Raporty globalne produkcja";
            this.Shown += new System.EventHandler(this.RaportyGlobalneProdukcjaForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.raportDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button zamknijButton;
        private System.Windows.Forms.DataGridView raportDGV;
        private System.Windows.Forms.MonthCalendar kalendarzKonMC;
        private System.Windows.Forms.Label dataPoczLabel;
        private System.Windows.Forms.MonthCalendar kalendarzPoczMC;
        private System.Windows.Forms.Label dataKonLabel;
        private System.Windows.Forms.Button ponizejNormyButton;
        private System.Windows.Forms.Button globalnyButton;
        private System.Windows.Forms.Button lenieButton;
        private System.Windows.Forms.Label raportLabel1;
    }
}