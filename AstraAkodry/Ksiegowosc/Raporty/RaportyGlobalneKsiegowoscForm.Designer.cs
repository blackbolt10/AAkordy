namespace AstraAkodry.Ksiegowosc.Raporty
{
    partial class RaportyGlobalneKsiegowoscForm
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
            this.raportLabel1 = new System.Windows.Forms.Label();
            this.raportDGV = new System.Windows.Forms.DataGridView();
            this.miesiacLabel = new System.Windows.Forms.Label();
            this.kalendarzMC = new System.Windows.Forms.MonthCalendar();
            this.globalnyButton = new System.Windows.Forms.Button();
            this.zapiszButton = new System.Windows.Forms.Button();
            this.zamknijButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.raportDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // raportLabel1
            // 
            this.raportLabel1.AutoSize = true;
            this.raportLabel1.Location = new System.Drawing.Point(299, 11);
            this.raportLabel1.Name = "raportLabel1";
            this.raportLabel1.Size = new System.Drawing.Size(42, 13);
            this.raportLabel1.TabIndex = 103;
            this.raportLabel1.Text = "Raport:";
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
            this.raportDGV.TabIndex = 101;
            // 
            // miesiacLabel
            // 
            this.miesiacLabel.AutoSize = true;
            this.miesiacLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.miesiacLabel.Location = new System.Drawing.Point(12, 11);
            this.miesiacLabel.Name = "miesiacLabel";
            this.miesiacLabel.Size = new System.Drawing.Size(82, 13);
            this.miesiacLabel.TabIndex = 100;
            this.miesiacLabel.Text = "Miesiąc raportu:";
            // 
            // kalendarzMC
            // 
            this.kalendarzMC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.kalendarzMC.Location = new System.Drawing.Point(18, 33);
            this.kalendarzMC.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.kalendarzMC.MaxSelectionCount = 1;
            this.kalendarzMC.MinDate = new System.DateTime(1901, 1, 1, 0, 0, 0, 0);
            this.kalendarzMC.Name = "kalendarzMC";
            this.kalendarzMC.ShowToday = false;
            this.kalendarzMC.ShowTodayCircle = false;
            this.kalendarzMC.TabIndex = 99;
            this.kalendarzMC.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.kalendarzMC_DateChanged);
            // 
            // globalnyButton
            // 
            this.globalnyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.globalnyButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.globalnyButton.Location = new System.Drawing.Point(432, 363);
            this.globalnyButton.Name = "globalnyButton";
            this.globalnyButton.Size = new System.Drawing.Size(80, 23);
            this.globalnyButton.TabIndex = 98;
            this.globalnyButton.Text = "Globalny";
            this.globalnyButton.UseVisualStyleBackColor = true;
            this.globalnyButton.Click += new System.EventHandler(this.globalnyButton_Click);
            // 
            // zapiszButton
            // 
            this.zapiszButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zapiszButton.BackgroundImage = global::AstraAkodry.Properties.Resources.zapisz_32x32;
            this.zapiszButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zapiszButton.Enabled = false;
            this.zapiszButton.Location = new System.Drawing.Point(518, 358);
            this.zapiszButton.Name = "zapiszButton";
            this.zapiszButton.Size = new System.Drawing.Size(32, 32);
            this.zapiszButton.TabIndex = 104;
            this.zapiszButton.UseVisualStyleBackColor = true;
            this.zapiszButton.Click += new System.EventHandler(this.zapiszButton_Click);
            // 
            // zamknijButton
            // 
            this.zamknijButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zamknijButton.BackgroundImage = global::AstraAkodry.Properties.Resources.koniec_32x32;
            this.zamknijButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zamknijButton.Location = new System.Drawing.Point(556, 358);
            this.zamknijButton.Name = "zamknijButton";
            this.zamknijButton.Size = new System.Drawing.Size(32, 32);
            this.zamknijButton.TabIndex = 102;
            this.zamknijButton.UseVisualStyleBackColor = true;
            this.zamknijButton.Click += new System.EventHandler(this.zamknijButton_Click);
            // 
            // RaportyGlobalneKsiegowoscForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.zapiszButton);
            this.Controls.Add(this.raportLabel1);
            this.Controls.Add(this.zamknijButton);
            this.Controls.Add(this.raportDGV);
            this.Controls.Add(this.miesiacLabel);
            this.Controls.Add(this.kalendarzMC);
            this.Controls.Add(this.globalnyButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RaportyGlobalneKsiegowoscForm";
            this.Text = "Raporty globalne księgowość";
            this.Shown += new System.EventHandler(this.RaportyGlobalneKsiegowoscForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.raportDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label raportLabel1;
        private System.Windows.Forms.Button zamknijButton;
        private System.Windows.Forms.DataGridView raportDGV;
        private System.Windows.Forms.Label miesiacLabel;
        private System.Windows.Forms.MonthCalendar kalendarzMC;
        private System.Windows.Forms.Button globalnyButton;
        private System.Windows.Forms.Button zapiszButton;
    }
}