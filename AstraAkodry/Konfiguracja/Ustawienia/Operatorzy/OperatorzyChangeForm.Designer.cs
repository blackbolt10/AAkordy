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
            this.label1 = new System.Windows.Forms.Label();
            this.imieTB = new System.Windows.Forms.TextBox();
            this.nazwiskoTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.archiwalnyCB = new System.Windows.Forms.CheckBox();
            this.uprawnieniaCB = new System.Windows.Forms.ComboBox();
            this.akceptujButton = new System.Windows.Forms.Button();
            this.zamknijButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Imię:";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nazwisko:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Uprawnienia:";
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
            this.ClientSize = new System.Drawing.Size(284, 145);
            this.Controls.Add(this.zamknijButton);
            this.Controls.Add(this.akceptujButton);
            this.Controls.Add(this.uprawnieniaCB);
            this.Controls.Add(this.archiwalnyCB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nazwiskoTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.imieTB);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OperatorzyChangeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nowy operator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox imieTB;
        private System.Windows.Forms.TextBox nazwiskoTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox archiwalnyCB;
        private System.Windows.Forms.ComboBox uprawnieniaCB;
        private System.Windows.Forms.Button akceptujButton;
        private System.Windows.Forms.Button zamknijButton;
    }
}