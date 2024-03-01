using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAFicha1
{
    public partial class Form1 : Form
    {
        private DateTime contadorTempo;
        private bool isContadorRunning;

        public Form1()
        {
            InitializeComponent();
            this.contadorTempo = new DateTime(0);
            this.isContadorRunning = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void buttonAction_Click(object sender, EventArgs e)
        {
            if (this.isContadorRunning)
            {
                this.isContadorRunning = false;
                buttonAction.Text = "Run";
            } 
            else
            {
                this.isContadorRunning = true;
                buttonAction.Text = "Stop";
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            this.contadorTempo = new DateTime(0);
            this.isContadorRunning = false;
            buttonAction.Text = "Run";
            toolStripStatusContador.Text = "00:00:00.000";
            listCronometer.Items.Clear();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (isContadorRunning)
            {
                contadorTempo = contadorTempo.AddMilliseconds(10);
                toolStripStatusContador.Text = contadorTempo.ToString("HH:mm:ss.fff");
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            listCronometer.Items.Add(DateTime.Now.ToLongTimeString() + " @ " + this.contadorTempo.ToString("HH:mm:ss.fff"));
        }
    }
}
