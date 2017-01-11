using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AstraAkodry.Produkcja.Raporty
{
    public partial class RaportyPracownikaProdukcjaForm : Form
    {
        public RaportyPracownikaProdukcjaForm()
        {
            InitializeComponent();
        }

        private void RaportyPracownikaProdukcjaForm_Shown(object sender, EventArgs e)
        {
        }

        private void zamknijButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
