namespace AstraAkodry.Recepcja
{
    partial class WprowadzanieAkordowForm
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
            this.pracownicyCB = new System.Windows.Forms.ComboBox();
            this.kalendarzMC = new System.Windows.Forms.MonthCalendar();
            this.pracownicyLB = new System.Windows.Forms.ListBox();
            this.dataLabel = new System.Windows.Forms.Label();
            this.pracownicyLabel = new System.Windows.Forms.Label();
            this.akordyDGV = new System.Windows.Forms.DataGridView();
            this.akordyLabel = new System.Windows.Forms.Label();
            this.zamknijButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.akordyDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // pracownicyCB
            // 
            this.pracownicyCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.pracownicyCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.pracownicyCB.FormattingEnabled = true;
            this.pracownicyCB.Location = new System.Drawing.Point(296, 31);
            this.pracownicyCB.Name = "pracownicyCB";
            this.pracownicyCB.Size = new System.Drawing.Size(180, 21);
            this.pracownicyCB.TabIndex = 34;
            this.pracownicyCB.SelectedIndexChanged += new System.EventHandler(this.pracownicyCB_SelectedIndexChanged);
            this.pracownicyCB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pracownicyCB_KeyDown);
            // 
            // kalendarzMC
            // 
            this.kalendarzMC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.kalendarzMC.Location = new System.Drawing.Point(15, 31);
            this.kalendarzMC.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.kalendarzMC.MaxSelectionCount = 1;
            this.kalendarzMC.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.kalendarzMC.Name = "kalendarzMC";
            this.kalendarzMC.ScrollChange = 1;
            this.kalendarzMC.TabIndex = 33;
            this.kalendarzMC.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.kalendarzMC_DateChanged);
            // 
            // pracownicyLB
            // 
            this.pracownicyLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pracownicyLB.FormattingEnabled = true;
            this.pracownicyLB.Location = new System.Drawing.Point(296, 58);
            this.pracownicyLB.Name = "pracownicyLB";
            this.pracownicyLB.Size = new System.Drawing.Size(180, 329);
            this.pracownicyLB.TabIndex = 32;
            this.pracownicyLB.SelectedIndexChanged += new System.EventHandler(this.pracownicyLB_SelectedIndexChanged);
            this.pracownicyLB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pracownicyLB_KeyDown);
            // 
            // dataLabel
            // 
            this.dataLabel.AutoSize = true;
            this.dataLabel.Location = new System.Drawing.Point(12, 9);
            this.dataLabel.Name = "dataLabel";
            this.dataLabel.Size = new System.Drawing.Size(33, 13);
            this.dataLabel.TabIndex = 35;
            this.dataLabel.Text = "Data:";
            // 
            // pracownicyLabel
            // 
            this.pracownicyLabel.AutoSize = true;
            this.pracownicyLabel.Location = new System.Drawing.Point(293, 9);
            this.pracownicyLabel.Name = "pracownicyLabel";
            this.pracownicyLabel.Size = new System.Drawing.Size(60, 13);
            this.pracownicyLabel.TabIndex = 36;
            this.pracownicyLabel.Text = "Pracownik:";
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
            this.akordyDGV.Location = new System.Drawing.Point(482, 31);
            this.akordyDGV.MultiSelect = false;
            this.akordyDGV.Name = "akordyDGV";
            this.akordyDGV.RowHeadersVisible = false;
            this.akordyDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.akordyDGV.Size = new System.Drawing.Size(106, 319);
            this.akordyDGV.TabIndex = 68;
            this.akordyDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.akordyDGV_CellClick);
            this.akordyDGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.akordyDGV_CellValueChanged);
            this.akordyDGV.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.akordyDGV_EditingControlShowing);
            this.akordyDGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.akordyDGV_KeyDown);
            // 
            // akordyLabel
            // 
            this.akordyLabel.AutoSize = true;
            this.akordyLabel.Location = new System.Drawing.Point(479, 9);
            this.akordyLabel.Name = "akordyLabel";
            this.akordyLabel.Size = new System.Drawing.Size(43, 13);
            this.akordyLabel.TabIndex = 69;
            this.akordyLabel.Text = "Akordy:";
            // 
            // zamknijButton
            // 
            this.zamknijButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zamknijButton.BackgroundImage = global::AstraAkodry.Properties.Resources.koniec_32x32;
            this.zamknijButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zamknijButton.Location = new System.Drawing.Point(556, 356);
            this.zamknijButton.Name = "zamknijButton";
            this.zamknijButton.Size = new System.Drawing.Size(32, 32);
            this.zamknijButton.TabIndex = 70;
            this.zamknijButton.UseVisualStyleBackColor = true;
            this.zamknijButton.Click += new System.EventHandler(this.zamknijButton_Click);
            // 
            // WprowadzanieAkordowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.zamknijButton);
            this.Controls.Add(this.akordyLabel);
            this.Controls.Add(this.akordyDGV);
            this.Controls.Add(this.pracownicyLabel);
            this.Controls.Add(this.dataLabel);
            this.Controls.Add(this.pracownicyCB);
            this.Controls.Add(this.kalendarzMC);
            this.Controls.Add(this.pracownicyLB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WprowadzanieAkordowForm";
            this.Text = "Wprowadzanie akordow";
            this.Shown += new System.EventHandler(this.WprowadzanieAkordowForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.akordyDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox pracownicyCB;
        private System.Windows.Forms.MonthCalendar kalendarzMC;
        private System.Windows.Forms.ListBox pracownicyLB;
        private System.Windows.Forms.Label dataLabel;
        private System.Windows.Forms.Label pracownicyLabel;
        private System.Windows.Forms.DataGridView akordyDGV;
        private System.Windows.Forms.Label akordyLabel;
        private System.Windows.Forms.Button zamknijButton;
    }
}