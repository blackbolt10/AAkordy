namespace AstraAkodry.Recepcja
{
    partial class WprowadzanieAkordowTesotwychForm
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
            this.akordyLabel = new System.Windows.Forms.Label();
            this.akordyDGV = new System.Windows.Forms.DataGridView();
            this.pracownicyLabel = new System.Windows.Forms.Label();
            this.dataLabel = new System.Windows.Forms.Label();
            this.pracownicyCB = new System.Windows.Forms.ComboBox();
            this.kalendarzMC = new System.Windows.Forms.MonthCalendar();
            this.pracownicyLB = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.akordyDGV)).BeginInit();
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
            this.zamknijButton.TabIndex = 78;
            this.zamknijButton.UseVisualStyleBackColor = true;
            this.zamknijButton.Click += new System.EventHandler(this.zamknijButton_Click);
            // 
            // akordyLabel
            // 
            this.akordyLabel.AutoSize = true;
            this.akordyLabel.Location = new System.Drawing.Point(479, 11);
            this.akordyLabel.Name = "akordyLabel";
            this.akordyLabel.Size = new System.Drawing.Size(43, 13);
            this.akordyLabel.TabIndex = 77;
            this.akordyLabel.Text = "Akordy:";
            // 
            // akordyDGV
            // 
            this.akordyDGV.AllowUserToAddRows = false;
            this.akordyDGV.AllowUserToDeleteRows = false;
            this.akordyDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.akordyDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.akordyDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.akordyDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.akordyDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.akordyDGV.Location = new System.Drawing.Point(482, 33);
            this.akordyDGV.MultiSelect = false;
            this.akordyDGV.Name = "akordyDGV";
            this.akordyDGV.RowHeadersVisible = false;
            this.akordyDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.akordyDGV.Size = new System.Drawing.Size(106, 319);
            this.akordyDGV.TabIndex = 76;
            this.akordyDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.akordyDGV_CellClick);
            this.akordyDGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.akordyDGV_CellValueChanged);
            this.akordyDGV.CurrentCellChanged += new System.EventHandler(this.akordyDGV_CurrentCellChanged);
            this.akordyDGV.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.akordyDGV_EditingControlShowing);
            this.akordyDGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.akordyDGV_KeyDown);
            // 
            // pracownicyLabel
            // 
            this.pracownicyLabel.AutoSize = true;
            this.pracownicyLabel.Location = new System.Drawing.Point(293, 11);
            this.pracownicyLabel.Name = "pracownicyLabel";
            this.pracownicyLabel.Size = new System.Drawing.Size(60, 13);
            this.pracownicyLabel.TabIndex = 75;
            this.pracownicyLabel.Text = "Pracownik:";
            // 
            // dataLabel
            // 
            this.dataLabel.AutoSize = true;
            this.dataLabel.Location = new System.Drawing.Point(12, 11);
            this.dataLabel.Name = "dataLabel";
            this.dataLabel.Size = new System.Drawing.Size(33, 13);
            this.dataLabel.TabIndex = 74;
            this.dataLabel.Text = "Data:";
            // 
            // pracownicyCB
            // 
            this.pracownicyCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.pracownicyCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.pracownicyCB.FormattingEnabled = true;
            this.pracownicyCB.Location = new System.Drawing.Point(296, 33);
            this.pracownicyCB.Name = "pracownicyCB";
            this.pracownicyCB.Size = new System.Drawing.Size(180, 21);
            this.pracownicyCB.TabIndex = 73;
            this.pracownicyCB.SelectedIndexChanged += new System.EventHandler(this.pracownicyCB_SelectedIndexChanged);
            this.pracownicyCB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pracownicyCB_KeyDown);
            // 
            // kalendarzMC
            // 
            this.kalendarzMC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.kalendarzMC.Location = new System.Drawing.Point(15, 33);
            this.kalendarzMC.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.kalendarzMC.MaxSelectionCount = 1;
            this.kalendarzMC.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.kalendarzMC.Name = "kalendarzMC";
            this.kalendarzMC.ScrollChange = 1;
            this.kalendarzMC.TabIndex = 72;
            this.kalendarzMC.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.kalendarzMC_DateChanged);
            // 
            // pracownicyLB
            // 
            this.pracownicyLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pracownicyLB.FormattingEnabled = true;
            this.pracownicyLB.Location = new System.Drawing.Point(296, 60);
            this.pracownicyLB.Name = "pracownicyLB";
            this.pracownicyLB.Size = new System.Drawing.Size(180, 329);
            this.pracownicyLB.TabIndex = 71;
            this.pracownicyLB.SelectedIndexChanged += new System.EventHandler(this.pracownicyLB_SelectedIndexChanged);
            this.pracownicyLB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pracownicyLB_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 75);
            this.label1.TabIndex = 79;
            this.label1.Text = "W oknie wprowadzane są \r\nwartości i czas \r\nakordów testowych";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WprowadzanieAkordowTesotwychForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zamknijButton);
            this.Controls.Add(this.akordyLabel);
            this.Controls.Add(this.akordyDGV);
            this.Controls.Add(this.pracownicyLabel);
            this.Controls.Add(this.dataLabel);
            this.Controls.Add(this.pracownicyCB);
            this.Controls.Add(this.kalendarzMC);
            this.Controls.Add(this.pracownicyLB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WprowadzanieAkordowTesotwychForm";
            this.Text = "Wprowadzanie akordow tesotwych";
            this.Shown += new System.EventHandler(this.WprowadzanieAkordowForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.akordyDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button zamknijButton;
        private System.Windows.Forms.Label akordyLabel;
        private System.Windows.Forms.DataGridView akordyDGV;
        private System.Windows.Forms.Label pracownicyLabel;
        private System.Windows.Forms.Label dataLabel;
        private System.Windows.Forms.ComboBox pracownicyCB;
        private System.Windows.Forms.MonthCalendar kalendarzMC;
        private System.Windows.Forms.ListBox pracownicyLB;
        private System.Windows.Forms.Label label1;
    }
}