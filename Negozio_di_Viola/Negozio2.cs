using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading;
using System.Windows.Forms;

namespace Negozio_di_Viola
{
    public partial class Negozio2 : Form
    {
        Mappa mappa;
        HomePage home;
        Fumetto dialogo;
        System.Timers.Timer timer;
        

        public Negozio2()
        {
            //Globals.CreaLista();

            if (!Globals.wallet_exists)

                Globals.CreaPortafogli();

            InitializeComponent();
            Visualizzazione();
            Adattamento_Risoluzione();

            if(Globals.visualizzaDialogo && Globals.Livello == 1 && Globals.statoGioco == 4 && !dialogoVisualizzato)
            {
                timer = new System.Timers.Timer(Globals.msTimer);
                timer.Elapsed += new ElapsedEventHandler(OnTimerEvent);
                timer.Enabled = true;
            }
        }

        public void OnTimerEvent(object source, ElapsedEventArgs e)
        {
            timer.Stop();
            Negozio2.enabledClick = true;
            //this.Close();
            VisualizzaDialogo();
        }

        bool ProdottiFiniti()
        {
            int i = 0;
            foreach (Prodotto p in Globals.listProdottiNegozio)
            {
                if (p.venduto == true)
                    i++;
            }
            return (i == Globals.listProdottiNegozio.Count);
        }

        void Adattamento_Risoluzione()
        {
            int screen_Height = Screen.PrimaryScreen.Bounds.Height;
            int screen_Width = Screen.PrimaryScreen.Bounds.Width;

            double widthFactor = (double) screen_Width / this.Size.Width;
            double heightFactor = (double) screen_Height / this.Size.Height;

            foreach (Panel p in this.Controls)
            {
                p.Width = (int)(p.Width * widthFactor);
                p.Height = (int)(p.Height * heightFactor);
                p.Location = new Point((int)(p.Location.X * widthFactor), (int)(p.Location.Y * heightFactor));
            }
            foreach (Control c in panelPortafogli.Controls)
            {
                c.Width = (int)(c.Width * widthFactor);
                c.Height = (int)(c.Height * heightFactor);
                c.Location = new Point((int)(c.Location.X * widthFactor), (int)(c.Location.Y * heightFactor));
                c.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);
            }
            foreach (Control c in panelScaffale.Controls)
            {
                c.Width = (int)(c.Width * widthFactor);
                c.Height = (int)(c.Height * heightFactor);
                c.Location = new Point((int)(c.Location.X * widthFactor), (int)(c.Location.Y * heightFactor));
                c.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);
            }
            foreach (Control c in panelTasti.Controls)
            {
                c.Width = (int)(c.Width * widthFactor);
                c.Height = (int)(c.Height * heightFactor);
                c.Location = new Point((int)(c.Location.X * widthFactor), (int)(c.Location.Y * heightFactor));
                c.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);
            }
            foreach (Control c in panelViola.Controls)
            {
                c.Width = (int)(c.Width * widthFactor);
                c.Height = (int)(c.Height * heightFactor);
                c.Location = new Point((int)(c.Location.X * widthFactor), (int)(c.Location.Y * heightFactor));
                c.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Regular);
            }

            textBox.Text = GetText();  //ADD da designer
        }

        string GetText()
        {
            if (Globals.listProdottiNegozio.Count == 0 || ProdottiFiniti())
                return Globals.fumMagazzino;
            else
                return Globals.fumChiamaCliente;
        }

        void Visualizzazione()
        {
            if (Globals.listProdottiNegozio.Count == 0 || ProdottiFiniti())
            {
                this.buttonAzione.Text = "Fabbrica";
            }

            else
            {
                this.buttonAzione.Text = "Cliente";
            }
            
            this.pbFumetto.Image = global::Negozio_di_Viola.Properties.Resources.fumetto;

            this.panelViola.BackColor = Color.FromName(Globals.PANEL_BACKGROUND);
            this.panelTasti.BackColor = Color.FromName(Globals.PANEL_BACKGROUND);

            this.buttonAzione.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.buttonCalcolatrice.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.buttonMenu.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);

            this.buttonAzione.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.buttonCalcolatrice.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.buttonMenu.ForeColor = Color.FromName(Globals.BUTTON_TEXT);

            this.l5euro.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.l10euro.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.l20euro.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.l50euro.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.l1cent.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.l2cent.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.l5cent.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.l1euro.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.l10cent.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.l20cent.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.l50cent.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.l2euro.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.labelPortafogli.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.textBox.ForeColor = Color.FromName(Globals.BUTTON_TEXT);

            this.lScaffale15.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.lScaffale14.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.lScaffale13.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.lScaffale12.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.lScaffale11.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.lScaffale10.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.lScaffale9.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.lScaffale8.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.lScaffale7.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.lScaffale6.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.lScaffale5.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.lScaffale4.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.lScaffale3.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.lScaffale2.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.lScaffale1.ForeColor = Color.FromName(Globals.BUTTON_TEXT);

	//ADD da designer
            if(enabledClick)
                this.buttonAzione.Click += new System.EventHandler(this.buttonAzione_Click);


            //////////////////////////////////////////////////////////////////////////////
            // Visualizzazione soldi
            if (Globals.portafogli[0] == 0)
            {
                pb50euro.Hide();
                l50euro.Hide();
            }
            else
            {
                l50euro.Text = Globals.portafogli[0].ToString();
            }

            if (Globals.portafogli[1] == 0)
            {
                pb20euro.Hide();
                l20euro.Hide();
            }
            else
            {
                l20euro.Text = Globals.portafogli[1].ToString();
            }

            if (Globals.portafogli[2] == 0)
            {
                pb10euro.Hide();
                l10euro.Hide();
            }
            else
            {
                l10euro.Text = Globals.portafogli[2].ToString();
            }

            if (Globals.portafogli[3] == 0)
            {
                pb5euro.Hide();
                l5euro.Hide();
            }
            else
            {
                l5euro.Text = Globals.portafogli[3].ToString();
            }

            if (Globals.portafogli[4] == 0)
            {
                pb2euro.Hide();
                l2euro.Hide();
            }
            else
            {
                l2euro.Text = Globals.portafogli[4].ToString();
            }

            if (Globals.portafogli[5] == 0)
            {
                pb1euro.Hide();
                l1euro.Hide();
            }
            else
            {
                l1euro.Text = Globals.portafogli[5].ToString();
            }

            if (Globals.portafogli[6] == 0)
            {
                pb50cent.Hide();
                l50cent.Hide();
            }
            else
            {
                l50cent.Text = Globals.portafogli[6].ToString();
            }

            if (Globals.portafogli[7] == 0)
            {
                pb20cent.Hide();
                l20cent.Hide();
            }
            else
            {
                l20cent.Text = Globals.portafogli[7].ToString();
            }

            if (Globals.portafogli[8] == 0)
            {
                pb10cent.Hide();
                l10cent.Hide();
            }
            else
            {
                l10cent.Text = Globals.portafogli[8].ToString();
            }

            if (Globals.portafogli[9] == 0)
            {
                pb5cent.Hide();
                l5cent.Hide();
            }
            else
            {
                l5cent.Text = Globals.portafogli[9].ToString();
            }

            if (Globals.portafogli[10] == 0)
            {
                pb2cent.Hide();
                l2cent.Hide();
            }
            else
            {
                l2cent.Text = Globals.portafogli[10].ToString();
            }

            if (Globals.portafogli[11] == 0)
            {
                pb1cent.Hide();
                l1cent.Hide();
            }
            else
            {
                l1cent.Text = Globals.portafogli[11].ToString();
            }

            this.panelPortafogli.BackColor = Color.FromName(Globals.PANEL_BACKGROUND);
            //////////////////////////////////////////////////////////////////////////////
            // VISUALIZZA OGGETTI IN SCAFFALE
   
            int i = 0;

            foreach (Prodotto p in Globals.listProdottiNegozio)
            {
                if (p.venduto == false)
                {
                    foreach (Control c in panelScaffale.Controls)
                    {
                        if (c.Tag.ToString() == i.ToString())
                            if (c is System.Windows.Forms.PictureBox)
                                ((PictureBox)c).Image = p.Immagine;
                            else if (c is System.Windows.Forms.Label)
                                ((Label)c).Text = p.PrezzoVendita.ToString("0.00") + "€";                      
                    }
                }
                else
                {
                    foreach (Control c in panelScaffale.Controls)
                    {
                        if (c.Tag.ToString() == i.ToString())
                            c.Hide();
                    }
                }
                i++;
            }
        }


        private void buttonCalcolatrice_Click(object sender, EventArgs e)
        {
            Globals.calcolatrice.ShowDialog();
        }

        private void buttonEsci_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonAzione_Click(object sender, EventArgs e)
        {
            if (Globals.listProdottiNegozio.Count == 0 || ProdottiFiniti())
            {
                Globals.statoGioco = 1;

                /*if (Globals.Livello == 1)

                    Negozio2.enabledClick = false;*/

                mappa = new Mappa();
                this.Close();
                mappa.ShowDialog();
                //mappa.animazioneFabbricaDaFuori();
                /*mgz = new Magazzino();
                this.Close();
                mgz.ShowDialog();*/
            }
            else
            {
                Globals.statoGioco = 3;
                mappa = new Mappa();
                this.Close();       //chiude il negozio
                mappa.ShowDialog();

                /*cln = new Cliente();
                this.Close();
                cln.ShowDialog();*/

            }
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
// codice con buttonMappa
/*          if (Globals.statoGioco != 3)
            {
                if (Globals.listProdottiNegozio.Count == 0 || ProdottiFiniti())
                    Globals.statoGioco = 1;
                else
                    Globals.statoGioco = 2;
            }
            
            //Globals.stampaProdottiNegozio();

            this.Close();
            mappa = new Mappa();
            mappa.ShowDialog();
*/

	    home = new HomePage();
	    this.Close();
	    home.ShowDialog();
        }

        private void lScaffale0_Click(object sender, EventArgs e)
        {

        }

        private void VisualizzaDialogo()
        {
            dialogo = new Fumetto(1);
            dialogo.ShowDialog();
        }

        private void l2euro_Click(object sender, EventArgs e)
        {

        }
    }
}
