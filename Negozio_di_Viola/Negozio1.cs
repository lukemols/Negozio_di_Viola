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
    public partial class Negozio1 : Form
    {
        HomePage home;
        Fumetto dialogo;
        System.Timers.Timer timer;


        public Negozio1()
        {
            //Globals.CreaLista();

            InitializeComponent();
            Visualizzazione();
            Adattamento_Risoluzione();

            /*if (Globals.visualizzaDialogo && Globals.livello == 1 && Globals.statoGioco == 4 && !dialogoVisualizzato)
            {
                timer = new System.Timers.Timer(Globals.msTimer);
                timer.Elapsed += new ElapsedEventHandler(OnTimerEvent);
                timer.Enabled = true;
            }*/
        }

        public void OnTimerEvent(object source, ElapsedEventArgs e)
        {
            timer.Stop();
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

	    textBox.Text = Globals.fumSperoCliente; //ADD da designer
        }

        void Visualizzazione()
        {
            int i = 0;

            this.pbFumetto.Image = global::Negozio_di_Viola.Properties.Resources.fumetto;

            this.panelViola.BackColor = Color.FromName(Globals.PANEL_BACKGROUND);
            this.panelTasti.BackColor = Color.FromName(Globals.PANEL_BACKGROUND);

            this.Avanti.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.Avanti.ForeColor = Color.FromName(Globals.BUTTON_TEXT);

            this.buttonMenu.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
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
            i = 0;
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

        private void onClick(object sender, EventArgs e)
        {
            VisualizzaDialogo();
        }

        private void VisualizzaDialogo()
        {
            this.Close();
            dialogo = new Fumetto(1);
            dialogo.ShowDialog();
        }

        private delegate void itemDelegate();

        private void RemoveItem()
        {
            if (this.InvokeRequired)
            {
                itemDelegate sd = new itemDelegate(RemoveItem);
                this.Invoke(sd, new object[] { });
            }
            else
            {
                this.Close();
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

    }
}
