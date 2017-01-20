namespace AstraAkodry.Konfiguracja.Aplikacja
{
    partial class UstawieniaForm
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
            this.naglowekNazwaLabel = new System.Windows.Forms.Label();
            this.naglowekRozmiarLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.changeFontButton = new System.Windows.Forms.Button();
            this.rozmiarLabel = new System.Windows.Forms.Label();
            this.nazwaLabel = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.zamknijButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.zmienButton = new System.Windows.Forms.Button();
            this.noweHasloTB = new System.Windows.Forms.TextBox();
            this.noweHasloLabel = new System.Windows.Forms.Label();
            this.noweHaslo2TB = new System.Windows.Forms.TextBox();
            this.noweHaslo2Label = new System.Windows.Forms.Label();
            this.obecneHasloTB = new System.Windows.Forms.TextBox();
            this.obecneHasloLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // naglowekNazwaLabel
            // 
            this.naglowekNazwaLabel.AutoSize = true;
            this.naglowekNazwaLabel.Location = new System.Drawing.Point(6, 22);
            this.naglowekNazwaLabel.Name = "naglowekNazwaLabel";
            this.naglowekNazwaLabel.Size = new System.Drawing.Size(43, 13);
            this.naglowekNazwaLabel.TabIndex = 0;
            this.naglowekNazwaLabel.Text = "Nazwa:";
            // 
            // naglowekRozmiarLabel
            // 
            this.naglowekRozmiarLabel.AutoSize = true;
            this.naglowekRozmiarLabel.Location = new System.Drawing.Point(6, 48);
            this.naglowekRozmiarLabel.Name = "naglowekRozmiarLabel";
            this.naglowekRozmiarLabel.Size = new System.Drawing.Size(48, 13);
            this.naglowekRozmiarLabel.TabIndex = 1;
            this.naglowekRozmiarLabel.Text = "Rozmiar:";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.changeFontButton);
            this.groupBox1.Controls.Add(this.rozmiarLabel);
            this.groupBox1.Controls.Add(this.nazwaLabel);
            this.groupBox1.Controls.Add(this.naglowekNazwaLabel);
            this.groupBox1.Controls.Add(this.naglowekRozmiarLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 129);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Czcionka";
            // 
            // changeFontButton
            // 
            this.changeFontButton.AutoSize = true;
            this.changeFontButton.Location = new System.Drawing.Point(161, 87);
            this.changeFontButton.Name = "changeFontButton";
            this.changeFontButton.Size = new System.Drawing.Size(75, 23);
            this.changeFontButton.TabIndex = 8;
            this.changeFontButton.Text = "Zmień";
            this.changeFontButton.UseVisualStyleBackColor = true;
            this.changeFontButton.Click += new System.EventHandler(this.changeFontButton_Click);
            // 
            // rozmiarLabel
            // 
            this.rozmiarLabel.AutoSize = true;
            this.rozmiarLabel.Location = new System.Drawing.Point(60, 48);
            this.rozmiarLabel.Name = "rozmiarLabel";
            this.rozmiarLabel.Size = new System.Drawing.Size(21, 13);
            this.rozmiarLabel.TabIndex = 5;
            this.rozmiarLabel.Text = "XX";
            // 
            // nazwaLabel
            // 
            this.nazwaLabel.AutoSize = true;
            this.nazwaLabel.Location = new System.Drawing.Point(60, 22);
            this.nazwaLabel.Name = "nazwaLabel";
            this.nazwaLabel.Size = new System.Drawing.Size(97, 13);
            this.nazwaLabel.TabIndex = 4;
            this.nazwaLabel.Text = "Times New Roman";
            // 
            // zamknijButton
            // 
            this.zamknijButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zamknijButton.BackgroundImage = global::AstraAkodry.Properties.Resources.koniec_32x32;
            this.zamknijButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zamknijButton.Location = new System.Drawing.Point(556, 356);
            this.zamknijButton.Name = "zamknijButton";
            this.zamknijButton.Size = new System.Drawing.Size(32, 32);
            this.zamknijButton.TabIndex = 6;
            this.zamknijButton.UseVisualStyleBackColor = true;
            this.zamknijButton.Click += new System.EventHandler(this.zamknijButton_Click);
            // 
            // acceptButton
            // 
            this.acceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptButton.AutoSize = true;
            this.acceptButton.Enabled = false;
            this.acceptButton.Location = new System.Drawing.Point(475, 365);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 7;
            this.acceptButton.Text = "Zapisz";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.zmienButton);
            this.groupBox2.Controls.Add(this.noweHasloTB);
            this.groupBox2.Controls.Add(this.noweHasloLabel);
            this.groupBox2.Controls.Add(this.noweHaslo2TB);
            this.groupBox2.Controls.Add(this.noweHaslo2Label);
            this.groupBox2.Controls.Add(this.obecneHasloTB);
            this.groupBox2.Controls.Add(this.obecneHasloLabel);
            this.groupBox2.Location = new System.Drawing.Point(12, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 142);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hasło";
            // 
            // zmienButton
            // 
            this.zmienButton.AutoSize = true;
            this.zmienButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.zmienButton.Location = new System.Drawing.Point(161, 100);
            this.zmienButton.Name = "zmienButton";
            this.zmienButton.Size = new System.Drawing.Size(76, 23);
            this.zmienButton.TabIndex = 13;
            this.zmienButton.Text = "Zmień hasło";
            this.zmienButton.UseVisualStyleBackColor = true;
            this.zmienButton.Click += new System.EventHandler(this.zmienButton_Click);
            // 
            // noweHasloTB
            // 
            this.noweHasloTB.Location = new System.Drawing.Point(98, 48);
            this.noweHasloTB.Name = "noweHasloTB";
            this.noweHasloTB.PasswordChar = '*';
            this.noweHasloTB.Size = new System.Drawing.Size(138, 20);
            this.noweHasloTB.TabIndex = 12;
            // 
            // noweHasloLabel
            // 
            this.noweHasloLabel.AutoSize = true;
            this.noweHasloLabel.Location = new System.Drawing.Point(6, 51);
            this.noweHasloLabel.Name = "noweHasloLabel";
            this.noweHasloLabel.Size = new System.Drawing.Size(68, 13);
            this.noweHasloLabel.TabIndex = 11;
            this.noweHasloLabel.Text = "Nowe hasło:";
            // 
            // noweHaslo2TB
            // 
            this.noweHaslo2TB.Location = new System.Drawing.Point(98, 74);
            this.noweHaslo2TB.Name = "noweHaslo2TB";
            this.noweHaslo2TB.PasswordChar = '*';
            this.noweHaslo2TB.Size = new System.Drawing.Size(138, 20);
            this.noweHaslo2TB.TabIndex = 10;
            // 
            // noweHaslo2Label
            // 
            this.noweHaslo2Label.AutoSize = true;
            this.noweHaslo2Label.Location = new System.Drawing.Point(6, 77);
            this.noweHaslo2Label.Name = "noweHaslo2Label";
            this.noweHaslo2Label.Size = new System.Drawing.Size(86, 13);
            this.noweHaslo2Label.TabIndex = 9;
            this.noweHaslo2Label.Text = "Potwierdź hasło:";
            // 
            // obecneHasloTB
            // 
            this.obecneHasloTB.Location = new System.Drawing.Point(98, 22);
            this.obecneHasloTB.Name = "obecneHasloTB";
            this.obecneHasloTB.PasswordChar = '*';
            this.obecneHasloTB.Size = new System.Drawing.Size(138, 20);
            this.obecneHasloTB.TabIndex = 8;
            // 
            // obecneHasloLabel
            // 
            this.obecneHasloLabel.AutoSize = true;
            this.obecneHasloLabel.Location = new System.Drawing.Point(6, 25);
            this.obecneHasloLabel.Name = "obecneHasloLabel";
            this.obecneHasloLabel.Size = new System.Drawing.Size(78, 13);
            this.obecneHasloLabel.TabIndex = 7;
            this.obecneHasloLabel.Text = "Obecne hasło:";
            // 
            // UstawieniaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.zamknijButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UstawieniaForm";
            this.Text = "Ustawienia";
            this.Shown += new System.EventHandler(this.UstawieniaForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label naglowekNazwaLabel;
        private System.Windows.Forms.Label naglowekRozmiarLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Label rozmiarLabel;
        private System.Windows.Forms.Label nazwaLabel;
        private System.Windows.Forms.Button zamknijButton;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button changeFontButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button zmienButton;
        private System.Windows.Forms.TextBox noweHasloTB;
        private System.Windows.Forms.Label noweHasloLabel;
        private System.Windows.Forms.TextBox noweHaslo2TB;
        private System.Windows.Forms.Label noweHaslo2Label;
        private System.Windows.Forms.TextBox obecneHasloTB;
        private System.Windows.Forms.Label obecneHasloLabel;
    }
}