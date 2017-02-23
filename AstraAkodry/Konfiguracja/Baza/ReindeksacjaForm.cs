using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AstraAkodry.Konfiguracja.Baza
{
    public partial class ReindeksacjaForm : Form
    {
        System.Threading.Timer timer;
             
        public ReindeksacjaForm()
        {
            InitializeComponent();
        }

        private void ReindeksacjaForm_Shown(object sender, EventArgs e)
        {
            postepLabel.Font = MainForm.czcionka;

            progressBar1.Location = new Point(progressBar1.Location.X, postepLabel.Location.Y + postepLabel.Size.Height + 10);
            startButton.Location = new Point(startButton.Location.X, progressBar1.Location.Y + progressBar1.Size.Height + 10);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) //zamknięcie aktywnego okna
        {
            if(keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void zamknijButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            ThreadStart threadStart = new ThreadStart(startTimer);
            Thread thread = new Thread(threadStart);
            thread.Start();

            UruchomReindeksacje();
        }

        private void UruchomReindeksacje()
        {
            DBRepository db = new DBRepository();
            String result = "";

            if(db.ReindeksacjaForm_StartReindex(ref result))
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                MessageBox.Show("Reindeksacja zakończona sukcesem!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Wystąpił błąd w trakcie reindeksacji bazy.\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void startTimer()
        {
            timer = new System.Threading.Timer(_ => TimerTic(), null, 0, 10);
        }

        private void TimerTic()
        {
            progressBar1.BeginInvoke(
                (Action)(() => {
                    if(progressBar1.Value < progressBar1.Maximum-1)
                    {
                         progressBar1.Value++;               
                    }
                    else
                    {
                        progressBar1.Value = 0;
                    }
                }
            ));
        }
    }
}
