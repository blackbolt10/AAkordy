namespace AstraAkodry.Recepcja
{
    partial class RaportDziennyTestowychForm
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
            this.raportLabel = new System.Windows.Forms.Label();
            this.raportDGV = new System.Windows.Forms.DataGridView();
            this.dataOdLabel = new System.Windows.Forms.Label();
            this.kalendarzMC = new System.Windows.Forms.MonthCalendar();
            this.reloadButton = new System.Windows.Forms.Button();
            this.zamknijButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.akordCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.raportDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // raportLabel
            // 
            this.raportLabel.AutoSize = true;
            this.raportLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.raportLabel.Location = new System.Drawing.Point(299, 11);
            this.raportLabel.Name = "raportLabel";
            this.raportLabel.Size = new System.Drawing.Size(42, 13);
            this.raportLabel.TabIndex = 115;
            this.raportLabel.Text = "Raport:";
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
            this.raportDGV.TabIndex = 113;
            // 
            // dataOdLabel
            // 
            this.dataOdLabel.AutoSize = true;
            this.dataOdLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataOdLabel.Location = new System.Drawing.Point(12, 11);
            this.dataOdLabel.Name = "dataOdLabel";
            this.dataOdLabel.Size = new System.Drawing.Size(48, 13);
            this.dataOdLabel.TabIndex = 112;
            this.dataOdLabel.Text = "Data od:";
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
            this.kalendarzMC.TabIndex = 111;
            this.kalendarzMC.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.kalendarzMC_DateChanged);
            // 
            // reloadButton
            // 
            this.reloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reloadButton.BackgroundImage = global::AstraAkodry.Properties.Resources.odswiez_32x32;
            this.reloadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.reloadButton.Location = new System.Drawing.Point(518, 358);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(32, 32);
            this.reloadButton.TabIndex = 116;
            this.reloadButton.UseVisualStyleBackColor = true;
            this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // zamknijButton
            // 
            this.zamknijButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zamknijButton.BackgroundImage = global::AstraAkodry.Properties.Resources.koniec_32x32;
            this.zamknijButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zamknijButton.Location = new System.Drawing.Point(556, 358);
            this.zamknijButton.Name = "zamknijButton";
            this.zamknijButton.Size = new System.Drawing.Size(32, 32);
            this.zamknijButton.TabIndex = 114;
            this.zamknijButton.UseVisualStyleBackColor = true;
            this.zamknijButton.Click += new System.EventHandler(this.zamknijButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.akordCB);
            this.groupBox1.Location = new System.Drawing.Point(18, 319);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 69);
            this.groupBox1.TabIndex = 117;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parametry";
            // 
            // akordCB
            // 
            this.akordCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.akordCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.akordCB.FormattingEnabled = true;
            this.akordCB.Location = new System.Drawing.Point(6, 39);
            this.akordCB.Name = "akordCB";
            this.akordCB.Size = new System.Drawing.Size(257, 21);
            this.akordCB.TabIndex = 0;
            this.akordCB.SelectedIndexChanged += new System.EventHandler(this.akordCB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 118;
            this.label1.Text = "Akord:";
            // 
            // RaportDziennyTestowychForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reloadButton);
            this.Controls.Add(this.raportLabel);
            this.Controls.Add(this.zamknijButton);
            this.Controls.Add(this.raportDGV);
            this.Controls.Add(this.dataOdLabel);
            this.Controls.Add(this.kalendarzMC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RaportDziennyTestowychForm";
            this.Text = "Raport dzienny";
            this.Shown += new System.EventHandler(this.RaportDziennyTestowychForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.raportDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button reloadButton;
        private System.Windows.Forms.Label raportLabel;
        private System.Windows.Forms.Button zamknijButton;
        private System.Windows.Forms.DataGridView raportDGV;
        private System.Windows.Forms.Label dataOdLabel;
        private System.Windows.Forms.MonthCalendar kalendarzMC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox akordCB;
    }
}