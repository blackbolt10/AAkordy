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
            this.label2 = new System.Windows.Forms.Label();
            this.nazwaTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // zamknijButton
            // 
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Norma:";
            // 
            // nazwaTB
            // 
            this.nazwaTB.Location = new System.Drawing.Point(87, 12);
            this.nazwaTB.Name = "nazwaTB";
            this.nazwaTB.Size = new System.Drawing.Size(185, 20);
            this.nazwaTB.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nazwa:";
            // 
            // AkordyChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 123);
            this.Controls.Add(this.zamknijButton);
            this.Controls.Add(this.akceptujButton);
            this.Controls.Add(this.archiwalnyCB);
            this.Controls.Add(this.normaTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nazwaTB);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AkordyChangeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nowy akord";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button zamknijButton;
        private System.Windows.Forms.Button akceptujButton;
        private System.Windows.Forms.CheckBox archiwalnyCB;
        private System.Windows.Forms.TextBox normaTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nazwaTB;
        private System.Windows.Forms.Label label1;
    }
}