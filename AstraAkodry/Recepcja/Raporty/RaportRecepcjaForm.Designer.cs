namespace AstraAkodry.Recepcja.Raporty
{
    partial class RaportRecepcjaForm
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
            this.components = new System.ComponentModel.Container();
            this.akordyLabel = new System.Windows.Forms.Label();
            this.akordyLB = new System.Windows.Forms.ListBox();
            this.label27 = new System.Windows.Forms.Label();
            this.pracownicyLB = new System.Windows.Forms.ListBox();
            this.pracownicyCB = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.raportLabel = new System.Windows.Forms.Label();
            this.kalendarzMC = new System.Windows.Forms.MonthCalendar();
            this.raportDGV = new System.Windows.Forms.DataGridView();
            this.zamknijButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.reloadButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.raportDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // akordyLabel
            // 
            this.akordyLabel.AutoSize = true;
            this.akordyLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.akordyLabel.Location = new System.Drawing.Point(181, 9);
            this.akordyLabel.Name = "akordyLabel";
            this.akordyLabel.Size = new System.Drawing.Size(40, 13);
            this.akordyLabel.TabIndex = 74;
            this.akordyLabel.Text = "Akordy";
            // 
            // akordyLB
            // 
            this.akordyLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.akordyLB.FormattingEnabled = true;
            this.akordyLB.Location = new System.Drawing.Point(184, 25);
            this.akordyLB.Name = "akordyLB";
            this.akordyLB.Size = new System.Drawing.Size(156, 368);
            this.akordyLB.TabIndex = 73;
            this.akordyLB.SelectedIndexChanged += new System.EventHandler(this.akordyLB_SelectedIndexChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label27.Location = new System.Drawing.Point(12, 196);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(57, 13);
            this.label27.TabIndex = 72;
            this.label27.Text = "Pracownik";
            // 
            // pracownicyLB
            // 
            this.pracownicyLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pracownicyLB.FormattingEnabled = true;
            this.pracownicyLB.Location = new System.Drawing.Point(15, 245);
            this.pracownicyLB.Name = "pracownicyLB";
            this.pracownicyLB.Size = new System.Drawing.Size(157, 147);
            this.pracownicyLB.TabIndex = 70;
            this.pracownicyLB.SelectedIndexChanged += new System.EventHandler(this.pracownicyLB_SelectedIndexChanged);
            // 
            // pracownicyCB
            // 
            this.pracownicyCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.pracownicyCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.pracownicyCB.FormattingEnabled = true;
            this.pracownicyCB.Location = new System.Drawing.Point(15, 212);
            this.pracownicyCB.Name = "pracownicyCB";
            this.pracownicyCB.Size = new System.Drawing.Size(157, 21);
            this.pracownicyCB.TabIndex = 71;
            this.pracownicyCB.SelectedIndexChanged += new System.EventHandler(this.pracownicyCB_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(12, 9);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 13);
            this.label21.TabIndex = 69;
            this.label21.Text = "Miesiąc raportu";
            // 
            // raportLabel
            // 
            this.raportLabel.AutoSize = true;
            this.raportLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.raportLabel.Location = new System.Drawing.Point(346, 9);
            this.raportLabel.Name = "raportLabel";
            this.raportLabel.Size = new System.Drawing.Size(159, 13);
            this.raportLabel.TabIndex = 68;
            this.raportLabel.Text = "Raport wykonywanych akordów";
            // 
            // kalendarzMC
            // 
            this.kalendarzMC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.kalendarzMC.Location = new System.Drawing.Point(15, 25);
            this.kalendarzMC.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.kalendarzMC.MaxSelectionCount = 1;
            this.kalendarzMC.MinDate = new System.DateTime(1901, 1, 1, 0, 0, 0, 0);
            this.kalendarzMC.Name = "kalendarzMC";
            this.kalendarzMC.ShowToday = false;
            this.kalendarzMC.ShowTodayCircle = false;
            this.kalendarzMC.TabIndex = 67;
            this.kalendarzMC.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.kalendarzMC_DateChanged);
            // 
            // raportDGV
            // 
            this.raportDGV.AllowUserToAddRows = false;
            this.raportDGV.AllowUserToDeleteRows = false;
            this.raportDGV.AllowUserToResizeRows = false;
            this.raportDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.raportDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.raportDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.raportDGV.Location = new System.Drawing.Point(346, 25);
            this.raportDGV.MultiSelect = false;
            this.raportDGV.Name = "raportDGV";
            this.raportDGV.ReadOnly = true;
            this.raportDGV.RowHeadersVisible = false;
            this.raportDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.raportDGV.Size = new System.Drawing.Size(242, 325);
            this.raportDGV.TabIndex = 66;
            // 
            // zamknijButton
            // 
            this.zamknijButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zamknijButton.BackgroundImage = global::AstraAkodry.Properties.Resources.koniec;
            this.zamknijButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zamknijButton.Location = new System.Drawing.Point(556, 356);
            this.zamknijButton.Name = "zamknijButton";
            this.zamknijButton.Size = new System.Drawing.Size(32, 32);
            this.zamknijButton.TabIndex = 75;
            this.toolTip1.SetToolTip(this.zamknijButton, "Zamknij okno");
            this.zamknijButton.UseVisualStyleBackColor = true;
            this.zamknijButton.Click += new System.EventHandler(this.zamknijButton_Click);
            // 
            // reloadButton
            // 
            this.reloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reloadButton.BackgroundImage = global::AstraAkodry.Properties.Resources.odswiez_32x32;
            this.reloadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.reloadButton.Location = new System.Drawing.Point(518, 356);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(32, 32);
            this.reloadButton.TabIndex = 76;
            this.toolTip1.SetToolTip(this.reloadButton, "Zamknij okno");
            this.reloadButton.UseVisualStyleBackColor = true;
            this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // RaportRecepcjaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.reloadButton);
            this.Controls.Add(this.zamknijButton);
            this.Controls.Add(this.akordyLabel);
            this.Controls.Add(this.akordyLB);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.pracownicyLB);
            this.Controls.Add(this.pracownicyCB);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.raportLabel);
            this.Controls.Add(this.kalendarzMC);
            this.Controls.Add(this.raportDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "RaportRecepcjaForm";
            this.Text = "Raporty recepcja";
            this.Shown += new System.EventHandler(this.RaportRecepcjaForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.raportDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label akordyLabel;
        private System.Windows.Forms.ListBox akordyLB;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ListBox pracownicyLB;
        private System.Windows.Forms.ComboBox pracownicyCB;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label raportLabel;
        private System.Windows.Forms.MonthCalendar kalendarzMC;
        private System.Windows.Forms.DataGridView raportDGV;
        private System.Windows.Forms.Button zamknijButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button reloadButton;
    }
}