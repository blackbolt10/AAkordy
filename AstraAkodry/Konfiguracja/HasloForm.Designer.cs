namespace AstraAkodry.Konfiguracja
{
    partial class HasloForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.obecneHasloTB = new System.Windows.Forms.TextBox();
            this.noweHaslo2TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.noweHasloTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.zmienButton = new System.Windows.Forms.Button();
            this.zamknijButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Obecne hasło:";
            // 
            // obecneHasloTB
            // 
            this.obecneHasloTB.Location = new System.Drawing.Point(104, 12);
            this.obecneHasloTB.Name = "obecneHasloTB";
            this.obecneHasloTB.PasswordChar = '*';
            this.obecneHasloTB.Size = new System.Drawing.Size(150, 20);
            this.obecneHasloTB.TabIndex = 1;
            // 
            // noweHaslo2TB
            // 
            this.noweHaslo2TB.Location = new System.Drawing.Point(104, 64);
            this.noweHaslo2TB.Name = "noweHaslo2TB";
            this.noweHaslo2TB.PasswordChar = '*';
            this.noweHaslo2TB.Size = new System.Drawing.Size(150, 20);
            this.noweHaslo2TB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Potwierdź hasło:";
            // 
            // noweHasloTB
            // 
            this.noweHasloTB.Location = new System.Drawing.Point(104, 38);
            this.noweHasloTB.Name = "noweHasloTB";
            this.noweHasloTB.PasswordChar = '*';
            this.noweHasloTB.Size = new System.Drawing.Size(150, 20);
            this.noweHasloTB.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nowe hasło:";
            // 
            // zmienButton
            // 
            this.zmienButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.zmienButton.Location = new System.Drawing.Point(98, 90);
            this.zmienButton.Name = "zmienButton";
            this.zmienButton.Size = new System.Drawing.Size(75, 23);
            this.zmienButton.TabIndex = 6;
            this.zmienButton.Text = "Zmień hasło";
            this.zmienButton.UseVisualStyleBackColor = true;
            this.zmienButton.Click += new System.EventHandler(this.zmienButton_Click);
            // 
            // zamknijButton
            // 
            this.zamknijButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.zamknijButton.Location = new System.Drawing.Point(179, 90);
            this.zamknijButton.Name = "zamknijButton";
            this.zamknijButton.Size = new System.Drawing.Size(75, 23);
            this.zamknijButton.TabIndex = 7;
            this.zamknijButton.Text = "Anuluj";
            this.zamknijButton.UseVisualStyleBackColor = true;
            this.zamknijButton.Click += new System.EventHandler(this.zamknijButton_Click);
            // 
            // HasloForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.zamknijButton);
            this.Controls.Add(this.zmienButton);
            this.Controls.Add(this.noweHasloTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.noweHaslo2TB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.obecneHasloTB);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HasloForm";
            this.Text = "Haslo - ustawienia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox obecneHasloTB;
        private System.Windows.Forms.TextBox noweHaslo2TB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox noweHasloTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button zmienButton;
        private System.Windows.Forms.Button zamknijButton;
    }
}