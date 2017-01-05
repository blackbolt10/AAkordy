namespace AstraAkodry.Konfiguracja.Ustawienia.Operatorzy
{
    partial class OperatorzyForm
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
            this.operatorzyDGV = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.archiwalniCHB = new System.Windows.Forms.CheckBox();
            this.addButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.delButton = new System.Windows.Forms.Button();
            this.zamknijButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.operatorzyDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // operatorzyDGV
            // 
            this.operatorzyDGV.AllowUserToAddRows = false;
            this.operatorzyDGV.AllowUserToDeleteRows = false;
            this.operatorzyDGV.AllowUserToResizeRows = false;
            this.operatorzyDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.operatorzyDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.operatorzyDGV.Location = new System.Drawing.Point(12, 12);
            this.operatorzyDGV.MultiSelect = false;
            this.operatorzyDGV.Name = "operatorzyDGV";
            this.operatorzyDGV.RowHeadersVisible = false;
            this.operatorzyDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.operatorzyDGV.Size = new System.Drawing.Size(576, 338);
            this.operatorzyDGV.TabIndex = 1;
            // 
            // archiwalniCHB
            // 
            this.archiwalniCHB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.archiwalniCHB.AutoSize = true;
            this.archiwalniCHB.Location = new System.Drawing.Point(12, 365);
            this.archiwalniCHB.Name = "archiwalniCHB";
            this.archiwalniCHB.Size = new System.Drawing.Size(121, 17);
            this.archiwalniCHB.TabIndex = 2;
            this.archiwalniCHB.Text = "Pokaż archiwalnych";
            this.toolTip1.SetToolTip(this.archiwalniCHB, "Wyświetla operatorów archiwalnych");
            this.archiwalniCHB.UseVisualStyleBackColor = true;
            this.archiwalniCHB.CheckedChanged += new System.EventHandler(this.archiwalniCHB_CheckedChanged);
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
            this.toolTip1.SetToolTip(this.addButton, "Dodaj nowego operatora");
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
            this.toolTip1.SetToolTip(this.changeButton, "Zmień zaznaczonego operatora");
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
            this.toolTip1.SetToolTip(this.delButton, "Usuń zaznacznonego operatora");
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
            this.toolTip1.SetToolTip(this.zamknijButton, "Zamknij okno");
            this.zamknijButton.UseVisualStyleBackColor = true;
            this.zamknijButton.Click += new System.EventHandler(this.zamknijButton_Click);
            // 
            // OperatorzyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.archiwalniCHB);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.zamknijButton);
            this.Controls.Add(this.operatorzyDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OperatorzyForm";
            this.Text = "Operatorzy - ustawienia";
            this.Shown += new System.EventHandler(this.OperatorzyForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.operatorzyDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView operatorzyDGV;
        private System.Windows.Forms.Button zamknijButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.CheckBox archiwalniCHB;
    }
}