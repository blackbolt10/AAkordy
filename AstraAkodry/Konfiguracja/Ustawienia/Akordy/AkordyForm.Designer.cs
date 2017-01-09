namespace AstraAkodry.Konfiguracja.Ustawienia.Akordy
{
    partial class AkordyForm
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
            this.archiwalneCHB = new System.Windows.Forms.CheckBox();
            this.akordyDGV = new System.Windows.Forms.DataGridView();
            this.addButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.delButton = new System.Windows.Forms.Button();
            this.zamknijButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.akordyDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // archiwalneCHB
            // 
            this.archiwalneCHB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.archiwalneCHB.AutoSize = true;
            this.archiwalneCHB.Location = new System.Drawing.Point(12, 365);
            this.archiwalneCHB.Name = "archiwalneCHB";
            this.archiwalneCHB.Size = new System.Drawing.Size(121, 17);
            this.archiwalneCHB.TabIndex = 2;
            this.archiwalneCHB.Text = "Pokaż archiwalnych";
            this.archiwalneCHB.UseVisualStyleBackColor = true;
            this.archiwalneCHB.CheckedChanged += new System.EventHandler(this.archiwalneCHB_CheckedChanged);
            // 
            // akordyDGV
            // 
            this.akordyDGV.AllowUserToAddRows = false;
            this.akordyDGV.AllowUserToDeleteRows = false;
            this.akordyDGV.AllowUserToResizeRows = false;
            this.akordyDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.akordyDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.akordyDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.akordyDGV.Location = new System.Drawing.Point(12, 12);
            this.akordyDGV.MultiSelect = false;
            this.akordyDGV.Name = "akordyDGV";
            this.akordyDGV.RowHeadersVisible = false;
            this.akordyDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.akordyDGV.Size = new System.Drawing.Size(576, 338);
            this.akordyDGV.TabIndex = 1;
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.BackgroundImage = global::AstraAkodry.Properties.Resources.dodaj;
            this.addButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addButton.Location = new System.Drawing.Point(442, 356);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(32, 32);
            this.addButton.TabIndex = 3;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.changeButton.BackgroundImage = global::AstraAkodry.Properties.Resources.zmien;
            this.changeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.changeButton.Location = new System.Drawing.Point(480, 356);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(32, 32);
            this.changeButton.TabIndex = 4;
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // delButton
            // 
            this.delButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.delButton.BackgroundImage = global::AstraAkodry.Properties.Resources.usun;
            this.delButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.delButton.Location = new System.Drawing.Point(518, 356);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(32, 32);
            this.delButton.TabIndex = 5;
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // zamknijButton
            // 
            this.zamknijButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zamknijButton.BackgroundImage = global::AstraAkodry.Properties.Resources.koniec;
            this.zamknijButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zamknijButton.Location = new System.Drawing.Point(556, 356);
            this.zamknijButton.Name = "zamknijButton";
            this.zamknijButton.Size = new System.Drawing.Size(32, 32);
            this.zamknijButton.TabIndex = 6;
            this.zamknijButton.UseVisualStyleBackColor = true;
            this.zamknijButton.Click += new System.EventHandler(this.zamknijButton_Click);
            // 
            // AkordyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.archiwalneCHB);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.zamknijButton);
            this.Controls.Add(this.akordyDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AkordyForm";
            this.Text = "Akordy - ustawienia";
            this.Shown += new System.EventHandler(this.AkordyForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.akordyDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox archiwalneCHB;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.Button zamknijButton;
        private System.Windows.Forms.DataGridView akordyDGV;
    }
}