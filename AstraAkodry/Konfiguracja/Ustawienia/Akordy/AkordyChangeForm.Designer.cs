namespace AstraAkodry.Konfiguracja.Ustawienia.Akordy
{
    partial class AkordyChangeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AkordyChangeForm));
            this.zamknijButton = new System.Windows.Forms.Button();
            this.akceptujButton = new System.Windows.Forms.Button();
            this.archiwalnyCB = new System.Windows.Forms.CheckBox();
            this.normaTB = new System.Windows.Forms.TextBox();
            this.normaLabel = new System.Windows.Forms.Label();
            this.nazwaTB = new System.Windows.Forms.TextBox();
            this.nazwaLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // zamknijButton
            // 
            this.zamknijButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zamknijButton.Location = new System.Drawing.Point(197, 87);
            this.zamknijButton.Name = "zamknijButton";
            this.zamknijButton.Size = new System.Drawing.Size(75, 23);
            this.zamknijButton.TabIndex = 15;
            this.zamknijButton.Text = "&Anuluj";
            this.zamknijButton.UseVisualStyleBackColor = true;
            this.zamknijButton.Click += new System.EventHandler(this.zamknijButton_Click);
            // 
            // akceptujButton
            // 
            this.akceptujButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.akceptujButton.Location = new System.Drawing.Point(116, 87);
            this.akceptujButton.Name = "akceptujButton";
            this.akceptujButton.Size = new System.Drawing.Size(75, 23);
            this.akceptujButton.TabIndex = 14;
            this.akceptujButton.Text = "&Zapisz";
            this.akceptujButton.UseVisualStyleBackColor = true;
            this.akceptujButton.Click += new System.EventHandler(this.akceptujButton_Click);
            // 
            // archiwalnyCB
            // 
            this.archiwalnyCB.AutoSize = true;
            this.archiwalnyCB.Location = new System.Drawing.Point(15, 64);
            this.archiwalnyCB.Name = "archiwalnyCB";
            this.archiwalnyCB.Size = new System.Drawing.Size(77, 17);
            this.archiwalnyCB.TabIndex = 12;
            this.archiwalnyCB.Text = "Archiwalny";
            this.archiwalnyCB.UseVisualStyleBackColor = true;
            // 
            // normaTB
            // 
            this.normaTB.Location = new System.Drawing.Point(87, 38);
            this.normaTB.Name = "normaTB";
            this.normaTB.Size = new System.Drawing.Size(185, 20);
            this.normaTB.TabIndex = 9;
            this.normaTB.Text = "0.0";
            this.normaTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nazwiskoTB_KeyPress);
            // 
            // normaLabel
            // 
            this.normaLabel.AutoSize = true;
            this.normaLabel.Location = new System.Drawing.Point(12, 41);
            this.normaLabel.Name = "normaLabel";
            this.normaLabel.Size = new System.Drawing.Size(41, 13);
            this.normaLabel.TabIndex = 10;
            this.normaLabel.Text = "Norma:";
            // 
            // nazwaTB
            // 
            this.nazwaTB.Location = new System.Drawing.Point(87, 12);
            this.nazwaTB.Name = "nazwaTB";
            this.nazwaTB.Size = new System.Drawing.Size(185, 20);
            this.nazwaTB.TabIndex = 8;
            // 
            // nazwaLabel
            // 
            this.nazwaLabel.AutoSize = true;
            this.nazwaLabel.Location = new System.Drawing.Point(12, 15);
            this.nazwaLabel.Name = "nazwaLabel";
            this.nazwaLabel.Size = new System.Drawing.Size(43, 13);
            this.nazwaLabel.TabIndex = 7;
            this.nazwaLabel.Text = "Nazwa:";
            // 
            // AkordyChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 123);
            this.Controls.Add(this.zamknijButton);
            this.Controls.Add(this.akceptujButton);
            this.Controls.Add(this.archiwalnyCB);
            this.Controls.Add(this.normaTB);
            this.Controls.Add(this.normaLabel);
            this.Controls.Add(this.nazwaTB);
            this.Controls.Add(this.nazwaLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AkordyChangeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nowy akord";
            this.Shown += new System.EventHandler(this.AkordyChangeForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button zamknijButton;
        private System.Windows.Forms.Button akceptujButton;
        private System.Windows.Forms.CheckBox archiwalnyCB;
        private System.Windows.Forms.TextBox normaTB;
        private System.Windows.Forms.Label normaLabel;
        private System.Windows.Forms.TextBox nazwaTB;
        private System.Windows.Forms.Label nazwaLabel;
    }
}