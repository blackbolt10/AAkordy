namespace AstraAkodry.Konfiguracja.Ustawienia.Operatorzy
{
    partial class OperatorzyChangeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperatorzyChangeForm));
            this.imieLabel = new System.Windows.Forms.Label();
            this.imieTB = new System.Windows.Forms.TextBox();
            this.nazwiskoTB = new System.Windows.Forms.TextBox();
            this.nazwiskoLabel = new System.Windows.Forms.Label();
            this.uprawnieniaLabel = new System.Windows.Forms.Label();
            this.archiwalnyCB = new System.Windows.Forms.CheckBox();
            this.uprawnieniaCB = new System.Windows.Forms.ComboBox();
            this.akceptujButton = new System.Windows.Forms.Button();
            this.zamknijButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imieLabel
            // 
            this.imieLabel.AutoSize = true;
            this.imieLabel.Location = new System.Drawing.Point(12, 15);
            this.imieLabel.Name = "imieLabel";
            this.imieLabel.Size = new System.Drawing.Size(29, 13);
            this.imieLabel.TabIndex = 0;
            this.imieLabel.Text = "Imię:";
            // 
            // imieTB
            // 
            this.imieTB.Location = new System.Drawing.Point(87, 12);
            this.imieTB.Name = "imieTB";
            this.imieTB.Size = new System.Drawing.Size(185, 20);
            this.imieTB.TabIndex = 1;
            // 
            // nazwiskoTB
            // 
            this.nazwiskoTB.Location = new System.Drawing.Point(87, 38);
            this.nazwiskoTB.Name = "nazwiskoTB";
            this.nazwiskoTB.Size = new System.Drawing.Size(185, 20);
            this.nazwiskoTB.TabIndex = 2;
            // 
            // nazwiskoLabel
            // 
            this.nazwiskoLabel.AutoSize = true;
            this.nazwiskoLabel.Location = new System.Drawing.Point(12, 41);
            this.nazwiskoLabel.Name = "nazwiskoLabel";
            this.nazwiskoLabel.Size = new System.Drawing.Size(56, 13);
            this.nazwiskoLabel.TabIndex = 2;
            this.nazwiskoLabel.Text = "Nazwisko:";
            // 
            // uprawnieniaLabel
            // 
            this.uprawnieniaLabel.AutoSize = true;
            this.uprawnieniaLabel.Location = new System.Drawing.Point(12, 67);
            this.uprawnieniaLabel.Name = "uprawnieniaLabel";
            this.uprawnieniaLabel.Size = new System.Drawing.Size(69, 13);
            this.uprawnieniaLabel.TabIndex = 4;
            this.uprawnieniaLabel.Text = "Uprawnienia:";
            // 
            // archiwalnyCB
            // 
            this.archiwalnyCB.AutoSize = true;
            this.archiwalnyCB.Location = new System.Drawing.Point(15, 91);
            this.archiwalnyCB.Name = "archiwalnyCB";
            this.archiwalnyCB.Size = new System.Drawing.Size(77, 17);
            this.archiwalnyCB.TabIndex = 4;
            this.archiwalnyCB.Text = "Archiwalny";
            this.archiwalnyCB.UseVisualStyleBackColor = true;
            // 
            // uprawnieniaCB
            // 
            this.uprawnieniaCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uprawnieniaCB.FormattingEnabled = true;
            this.uprawnieniaCB.Items.AddRange(new object[] {
            "Wybierz uprawnienia",
            "Administrator",
            "Recepcja",
            "Produkcja"});
            this.uprawnieniaCB.Location = new System.Drawing.Point(87, 64);
            this.uprawnieniaCB.Name = "uprawnieniaCB";
            this.uprawnieniaCB.Size = new System.Drawing.Size(185, 21);
            this.uprawnieniaCB.TabIndex = 3;
            // 
            // akceptujButton
            // 
            this.akceptujButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.akceptujButton.Location = new System.Drawing.Point(116, 114);
            this.akceptujButton.Name = "akceptujButton";
            this.akceptujButton.Size = new System.Drawing.Size(75, 23);
            this.akceptujButton.TabIndex = 5;
            this.akceptujButton.Text = "&Zapisz";
            this.akceptujButton.UseVisualStyleBackColor = true;
            this.akceptujButton.Click += new System.EventHandler(this.akceptujButton_Click);
            // 
            // zamknijButton
            // 
            this.zamknijButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zamknijButton.Location = new System.Drawing.Point(197, 114);
            this.zamknijButton.Name = "zamknijButton";
            this.zamknijButton.Size = new System.Drawing.Size(75, 23);
            this.zamknijButton.TabIndex = 6;
            this.zamknijButton.Text = "&Anuluj";
            this.zamknijButton.UseVisualStyleBackColor = true;
            this.zamknijButton.Click += new System.EventHandler(this.zamknijButton_Click);
            // 
            // OperatorzyChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 145);
            this.Controls.Add(this.zamknijButton);
            this.Controls.Add(this.akceptujButton);
            this.Controls.Add(this.uprawnieniaCB);
            this.Controls.Add(this.archiwalnyCB);
            this.Controls.Add(this.uprawnieniaLabel);
            this.Controls.Add(this.nazwiskoTB);
            this.Controls.Add(this.nazwiskoLabel);
            this.Controls.Add(this.imieTB);
            this.Controls.Add(this.imieLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OperatorzyChangeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nowy operator";
            this.Shown += new System.EventHandler(this.OperatorzyChangeForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label imieLabel;
        private System.Windows.Forms.TextBox imieTB;
        private System.Windows.Forms.TextBox nazwiskoTB;
        private System.Windows.Forms.Label nazwiskoLabel;
        private System.Windows.Forms.Label uprawnieniaLabel;
        private System.Windows.Forms.CheckBox archiwalnyCB;
        private System.Windows.Forms.ComboBox uprawnieniaCB;
        private System.Windows.Forms.Button akceptujButton;
        private System.Windows.Forms.Button zamknijButton;
    }
}