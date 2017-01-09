namespace AstraAkodry.Recepcja.Raporty
{
    partial class RaportLeniRecepcjaForm
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
            this.raportDGV = new System.Windows.Forms.DataGridView();
            this.naglowekLabel = new System.Windows.Forms.Label();
            this.dataDTP = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.reloadButton = new System.Windows.Forms.Button();
            this.zamknijButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.raportDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // raportDGV
            // 
            this.raportDGV.AllowUserToAddRows = false;
            this.raportDGV.AllowUserToDeleteRows = false;
            this.raportDGV.AllowUserToResizeRows = false;
            this.raportDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.raportDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.raportDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.raportDGV.Location = new System.Drawing.Point(12, 25);
            this.raportDGV.MultiSelect = false;
            this.raportDGV.Name = "raportDGV";
            this.raportDGV.RowHeadersVisible = false;
            this.raportDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.raportDGV.Size = new System.Drawing.Size(576, 325);
            this.raportDGV.TabIndex = 2;
            // 
            // naglowekLabel
            // 
            this.naglowekLabel.AutoSize = true;
            this.naglowekLabel.Location = new System.Drawing.Point(12, 9);
            this.naglowekLabel.Name = "naglowekLabel";
            this.naglowekLabel.Size = new System.Drawing.Size(101, 13);
            this.naglowekLabel.TabIndex = 9;
            this.naglowekLabel.Text = "Raport leni za okres";
            // 
            // dataDTP
            // 
            this.dataDTP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dataDTP.Location = new System.Drawing.Point(90, 360);
            this.dataDTP.Name = "dataDTP";
            this.dataDTP.Size = new System.Drawing.Size(125, 20);
            this.dataDTP.TabIndex = 10;
            this.dataDTP.ValueChanged += new System.EventHandler(this.dataDTP_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Wybierz datę:";
            // 
            // reloadButton
            // 
            this.reloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.reloadButton.BackgroundImage = global::AstraAkodry.Properties.Resources.odswiez_32x32;
            this.reloadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.reloadButton.Location = new System.Drawing.Point(221, 356);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(32, 32);
            this.reloadButton.TabIndex = 7;
            this.reloadButton.UseVisualStyleBackColor = true;
            this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // zamknijButton
            // 
            this.zamknijButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zamknijButton.BackgroundImage = global::AstraAkodry.Properties.Resources.koniec;
            this.zamknijButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zamknijButton.Location = new System.Drawing.Point(556, 356);
            this.zamknijButton.Name = "zamknijButton";
            this.zamknijButton.Size = new System.Drawing.Size(32, 32);
            this.zamknijButton.TabIndex = 8;
            this.zamknijButton.UseVisualStyleBackColor = true;
            this.zamknijButton.Click += new System.EventHandler(this.zamknijButton_Click);
            // 
            // RaportLeniRecepcjaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataDTP);
            this.Controls.Add(this.naglowekLabel);
            this.Controls.Add(this.reloadButton);
            this.Controls.Add(this.zamknijButton);
            this.Controls.Add(this.raportDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RaportLeniRecepcjaForm";
            this.Text = "Recepcja - Raport leni";
            this.Shown += new System.EventHandler(this.RaportLeniRecepcjaForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.raportDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView raportDGV;
        private System.Windows.Forms.Button reloadButton;
        private System.Windows.Forms.Button zamknijButton;
        private System.Windows.Forms.Label naglowekLabel;
        private System.Windows.Forms.DateTimePicker dataDTP;
        private System.Windows.Forms.Label label2;
    }
}