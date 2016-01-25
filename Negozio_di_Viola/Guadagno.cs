using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Negozio_di_Viola
{
    public partial class Guadagno : Form
    {
        Cliente cln;
        NonSo nonSo;
        Fumetto bravo;

        public Guadagno()
        {
            InitializeComponent();
            Adattamento_Risoluzione();
            this.lbPrezzoAcq.Text = Globals.prAcquisto;
            this.lbPrezzoVend.Text = Globals.prVendita;
            this.buttonCalcolatrice.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.btEsci.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.btOk.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.buttonNonSo.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.pbProdotto.Image = Globals.pictureBoxacq.Image;           
        }

        void Adattamento_Risoluzione()
        {
            int screen_Height = Screen.PrimaryScreen.Bounds.Height;
            int screen_Width = Screen.PrimaryScreen.Bounds.Width;

            double widthFactor = (double) screen_Width / (double)(2*this.Size.Width);
            double heightFactor = (double) screen_Height / (double)(2*this.Size.Height);

 //DEBUG   MessageBox.Show("screen (W/H) + form (W/H) + Factor (W/H):  " + screen_Width + ' ' + screen_Height + ' ' + this.Size.Width + ' ' + this.Size.Height + ' ' + widthFactor + ' ' + heightFactor); 

            this.Width = (int)(this.Width * widthFactor);
            this.Height = (int)(this.Height * heightFactor);
            this.Location = new Point((int)(this.Location.X * widthFactor), (int)(this.Location.Y * heightFactor));

            foreach (SplitContainer p in this.Controls)
            {
                p.Width = (int)(p.Width * widthFactor);
                p.Height = (int)(p.Height * heightFactor);
                p.Location = new Point((int)(p.Location.X * widthFactor), (int)(p.Location.Y * heightFactor));
                p.Font = new Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            }

            foreach (Control p in this.splitContainer1.Panel1.Controls)
            {
                p.Width = (int)(p.Width * widthFactor);
                p.Height = (int)(p.Height * heightFactor);
                p.Location = new Point((int)(p.Location.X * widthFactor), (int)(p.Location.Y * heightFactor));
                p.Font = new Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            }

            foreach (Control p in this.splitContainer1.Panel2.Controls)
            {
                p.Width = (int)(p.Width * widthFactor);
                p.Height = (int)(p.Height * heightFactor);
                p.Location = new Point((int)(p.Location.X * widthFactor), (int)(p.Location.Y * heightFactor));
                p.Font = new Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            }
        }
        
        private void Guadagno_Load(object sender, EventArgs e)
        {

        }

        private void buttonNonSo_Click(object sender, System.EventArgs e)
        {
            nonSo = new NonSo(1);
            nonSo.ShowDialog();
        }

        private void buttonEsci_Click(object sender, EventArgs e)
        {
            this.Close();
            cln = new Cliente();
            cln.ShowDialog();

        }

        private void buttonCalcolatrice_Click(object sender, EventArgs e)
        {
            Globals.calcolatrice.ShowDialog();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string text = tbGuadagno.Text;
            
            if(text != "")
            {
                if ((Globals.prezzo1 - Globals.prezzo2) == Convert.ToDouble(text))
                {
                    pbSmile3.Visible = false;
                    pbSmile1.Visible = true;
                    btEsci.Visible = true;
                    this.Close();
                    bravo = new Fumetto(100);
                    bravo.ShowDialog();
                }

                else
                {
                    pbSmile3.Visible = true;
                }
            }
        }
    }
}
