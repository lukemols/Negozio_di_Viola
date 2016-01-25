using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Timers;
using System.Threading;
using System.Collections;
using System.Diagnostics;

namespace Negozio_di_Viola
{

    public partial class Cliente : Form
    {
        Fabbrica fabbr;
        Guadagno gdn;
        Mappa mappa;
        HomePage home;
        public static Queue indexes = new Queue();    // Coda che contiene gli index.
        int index;                                    // Si riferisce al prodotto della lista Globals.listProdottiNegozio 
                                                      // desiderato dal cliente.
        int i, length;

        double widthFactor;
        double heightFactor;


        public Cliente()
        {
            int screen_Height = Screen.PrimaryScreen.Bounds.Height;
            int screen_Width = Screen.PrimaryScreen.Bounds.Width;

            //Globals.CreaLista();
            InitializeComponent();
            widthFactor = (double) screen_Width / this.Size.Width;
            heightFactor = (double) screen_Height / this.Size.Height;

            Visualizzazione();
            Adattamento_Risoluzione();
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
                c.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);
            }

            foreach (Control c in panelIstruzioni.Controls)
            {
                c.Width = (int)(c.Width * widthFactor);
                c.Height = (int)(c.Height * heightFactor);
                c.Location = new Point((int)(c.Location.X * widthFactor), (int)(c.Location.Y * heightFactor));
                c.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);
            }
        }

        void Visualizzazione()
        {
            int i = 0;

            if (ProdottiFiniti())
            {
                this.buttonAzione.Text = "Fabbrica";
                this.pbFumetto.Image = global::Negozio_di_Viola.Properties.Resources.fumMagazzino;
                this.pbCliente.Image = global::Negozio_di_Viola.Properties.Resources.Viola;
                this.pbBorsa.Hide();
                this.lbIstruzioni.Hide();
                this.pbProdottoScelto.Hide();
            }
            else
            {
                this.buttonAzione.Text = "Cliente";
                this.pbFumetto.Image = global::Negozio_di_Viola.Properties.Resources.fumetto;
                this.pbProdottoScelto.Show();

                //Visualizza cliente

                int r2 = Globals.global_rnd.Next(2);
                switch (r2)
                {
                    case 0: pbCliente.Image = global::Negozio_di_Viola.Properties.Resources.cliente1;
                        break;
                    case 1: pbCliente.Image = global::Negozio_di_Viola.Properties.Resources.cliente2;
                        break;
                }
            }

            pbCliente.SizeMode = PictureBoxSizeMode.Zoom;

            this.panelViola.BackColor = Color.FromName(Globals.PANEL_BACKGROUND);
            this.panelTasti.BackColor = Color.FromName(Globals.PANEL_BACKGROUND);
            this.panelPortafogli.BackColor = Color.FromName(Globals.PANEL_BACKGROUND);

            this.buttonAzione.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.buttonCalcolatrice.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.buttonMenu.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.buttonMappa.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);

            this.buttonAzione.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.buttonCalcolatrice.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.buttonMenu.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.buttonMappa.ForeColor = Color.FromName(Globals.BUTTON_TEXT);

            this.labelCassa.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.lbIstruzioni.ForeColor = Color.FromName(Globals.BUTTON_TEXT);

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
            this.lScaffale0.ForeColor = Color.FromName(Globals.BUTTON_TEXT);

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
            //Funzione che sceglie un prodotto random e lo evidenzia
            if (!ProdottiFiniti())
            {
                int nProd = 0;
                int riga = 0;

                do
                {
                    riga = Globals.global_rnd.Next(4);  // scegli riga
                    //controlla quanti oggetti sulla riga estratta
                    nProd = prodottiSuRiga(riga);
                } while (nProd == 0);

                // estrai oggetto random su riga
                int r = Globals.global_rnd.Next(nProd);
                foreach (Control c in panelScaffale.Controls)
                {
                    index = 4 * riga + r;
                    indexes.Enqueue(index);

                    //Globals.listProdottiNegozio[4 * riga + r].venduto = true;

                    if (c.Tag.ToString() == Convert.ToString(index))
                        if (c is System.Windows.Forms.PictureBox)
                        {
                            ((PictureBox)c).BackColor = Color.FromName(Globals.BUTTON_BACKGROUND); // Color.Yellow;
                            pbProdottoScelto.Image = ((PictureBox)c).Image;
                            Globals.pictureBoxacq.Image = pbProdottoScelto.Image;
                            ((PictureBox)c).Cursor = Cursors.Hand;
                        }
                        else if (c is System.Windows.Forms.Label)
                            ((Label)c).BackColor = Color.FromName(Globals.BUTTON_BACKGROUND); // Color.Yellow;
                }
            }
        }

        private int prodottiSuRiga(int riga)
        {
            int value = 0;
            switch (riga)
            {
                case 0:
                    for (int i = 0; i < 4; i++ )
                    {
                        if (!Globals.listProdottiNegozio[i].venduto)
                            value++;
                    }
                    break;
                case 1:
                    for (int i = 4; i < 8; i++)
                    {
                        if (!Globals.listProdottiNegozio[i].venduto)
                            value++;
                    }
                    break;
                case 2:
                    for (int i = 8; i < 12; i++)
                    {
                        if (!Globals.listProdottiNegozio[i].venduto)
                            value++;
                    }
                    break;
                case 3:
                    for (int i = 12; i < 16; i++)
                    {
                        if (!Globals.listProdottiNegozio[i].venduto)
                            value++;
                    }
                    break;
            }

            return value;
        }

        private void pagamentoCliente()
        {
            double costo = Globals.prezzo1;

            while (costo != 0)
            {
                if (costo > 50)
                    costo = costo - 50;
                else if
                    (costo > 20)
                    costo = costo - 20;
                else if
                    (costo > 10)
                    costo = costo - 10;
                else if
                    (costo > 5)
                    costo = costo - 5;
            }
        }

        private void buttonCalcolatrice_Click(object sender, EventArgs e)
        {
            Globals.calcolatrice.ShowDialog();
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            home = new HomePage();
            home.ShowDialog();
        }

        private void buttonProdotto_Click(object sender, EventArgs e)
        {
            if (((PictureBox)sender).BackColor == Color.FromName(Globals.BUTTON_BACKGROUND)) // Color.Yellow
            {
                ((PictureBox)sender).Visible = false;
                ((PictureBox)sender).Hide();

                foreach (Prodotto p in Globals.listProdottiNegozio)
                {
                    if (p.Immagine == ((PictureBox)sender).Image)
                    {
                        Globals.prAcquisto = p.PrezzoVendita.ToString("0.00") + "€";
                        Globals.prVendita = p.PrezzoAcquisto.ToString("0.00") + "€";
                        
                        stringa1 = p.PrezzoVendita.ToString();
                        stringa2 = p.PrezzoAcquisto.ToString();

                        Globals.prezzo1 = p.PrezzoVendita;
                        Globals.prezzo2 = p.PrezzoAcquisto;   
                    }
                }

                location = ((PictureBox)sender).Location;
                location.X = ((location.X) + (int)(362*widthFactor));
                location.Y = ((location.Y) + (int)(12*heightFactor));

                AddPicturebox2(location, ((PictureBox)sender));
                this.pictureBox1.BringToFront();
                muoviProdotto();

                lbIstruzioni.Text = "Ora clicca sulla borsa del cliente";
                pbBorsa.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND); // Color.Yellow;
                pbBorsa.Cursor = Cursors.Hand;
            }

/*            lbIstruzioni.Text = "Ora clicca sulla tua borsa";
            pbBorsa.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND); // Color.Yellow;
            pbBorsa.Cursor = Cursors.Hand;                          */
        }

        private void fAcquisto()
        {
            length = indexes.Count;

            for (i = 0; i < length; i++ )
            {
                index = (int)indexes.Dequeue();
                Globals.listProdottiNegozio[index].venduto = true;
            }

            gdn = new Guadagno();

            gdn.ShowDialog();

            this.Close();
        }

        private void buttonBorsa_Click(object sender, EventArgs e)
        {
            if (((PictureBox)sender).BackColor == Color.FromName(Globals.BUTTON_BACKGROUND)) // Color.Yellow;
            {
                muoviMonete();
                this.pictureBox1.Visible = false;
                fAcquisto();
            }
            else
            {
            }

        }


        private void buttonEsci_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonAzione_Click(object sender, EventArgs e)
        {
            if (Globals.listProdottiNegozio.Count == 0 || ProdottiFiniti())
            {
                this.Close();
                fabbr = new Fabbrica();
                fabbr.ShowDialog();
            }

            else
                MessageBox.Show("Vai a Cliente");
        }

        private void buttonMappa_Click(object sender, EventArgs e)
        {
            mappa = new Mappa();
            this.Close();
            mappa.ShowDialog();
        }


        public void AddPicturebox1()
        {
            
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Controls.Add(this.pictureBox1);
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;

            

             ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        }

        public void muoviProdotto()
        {

            while (location.X< (int)(1150*widthFactor))
                {

                    
                    location.X = (int)(location.X + 3 * Globals.speedFactor2 * widthFactor);
                    this.pictureBox1.Location = location;
                    //this.pictureBox1.BringToFront();
                    Thread.Sleep(5);
                    ((Form)this).Update();
                    
                }


            if (location.Y < (int)(460 * heightFactor))
                {
                    while (location.Y < 460 * heightFactor)
                    {
                        
                        location.Y = (int)(location.Y + 3 * Globals.speedFactor2 * heightFactor);

                        this.pictureBox1.Location = location;
                        ((Form)this).Update();
                        Thread.Sleep(2);

                    }
                }
                else
                {
                    while (location.Y > (int)(460 * heightFactor))
                    {
                        location.Y = (int)(location.Y - 3 * Globals.speedFactor2 * heightFactor);

                        this.pictureBox1.Location = location;
                        ((Form)this).Update();
                        Thread.Sleep(2);

                    }
                }

                this.pictureBox1.Visible = false;
            }




        public void muoviMonete()
        {

            Globals.CostruisciSequenzaVendita();

            for (int i = 0; i < Globals.nVendita; i++)
            {

                switch (Globals.seqVendita[i])
                {
                
                    case 0:			    

			this.pictureBox1.Image = global::Negozio_di_Viola.Properties.Resources._50euro;
			this.pictureBox1.Size = new System.Drawing.Size(120, 60);
			type = 1;
                        locDest = pb50euro.Location;
			break;

                    case 1:			    

			this.pictureBox1.Image = global::Negozio_di_Viola.Properties.Resources._20euro;
			this.pictureBox1.Size = new System.Drawing.Size(120, 60);
			type = 2;
                        locDest = pb20euro.Location;
			break;

                    case 2:			    

			this.pictureBox1.Image = global::Negozio_di_Viola.Properties.Resources._10euro;
			this.pictureBox1.Size = new System.Drawing.Size(120, 60);
			type = 3;
                        locDest = pb10euro.Location;
			break;

                    case 3:			    

			this.pictureBox1.Image = global::Negozio_di_Viola.Properties.Resources._5euro;
			this.pictureBox1.Size = new System.Drawing.Size(120, 60);
			type = 4;
                        locDest = pb5euro.Location;
			break;

                    case 4:			    

			this.pictureBox1.Image = global::Negozio_di_Viola.Properties.Resources._2euro;
			this.pictureBox1.Size = new System.Drawing.Size(60, 60);
			type = 5;
                        locDest = pb2euro.Location;
			break;

                    case 5:			    

			this.pictureBox1.Image = global::Negozio_di_Viola.Properties.Resources._1euro;
			this.pictureBox1.Size = new System.Drawing.Size(60, 60);
			type = 6;
                        locDest = pb1euro.Location;
			break;

                    case 6:			    

			this.pictureBox1.Image = global::Negozio_di_Viola.Properties.Resources._50cent;
			this.pictureBox1.Size = new System.Drawing.Size(60, 60);
			type = 7;
                        locDest = pb50cent.Location;
			break;

                    case 7:			    

			this.pictureBox1.Image = global::Negozio_di_Viola.Properties.Resources._20cent;
			this.pictureBox1.Size = new System.Drawing.Size(60, 60);
			type = 8;
                        locDest = pb20cent.Location;
			break;

                    case 8:			    

			this.pictureBox1.Image = global::Negozio_di_Viola.Properties.Resources._10cent;
			this.pictureBox1.Size = new System.Drawing.Size(60, 60);
			type = 9;
                        locDest = pb10cent.Location; 
			break;

                    case 9:			    

			this.pictureBox1.Image = global::Negozio_di_Viola.Properties.Resources._5cent;
			this.pictureBox1.Size = new System.Drawing.Size(60, 60);
			type = 10;
                        locDest = pb5cent.Location;
			break;

                    case 10:			    

			this.pictureBox1.Image = global::Negozio_di_Viola.Properties.Resources._2cent;
			this.pictureBox1.Size = new System.Drawing.Size(60, 60);
			type = 11;
                        locDest = pb2cent.Location;
			break;

                    case 11:			    

			this.pictureBox1.Image = global::Negozio_di_Viola.Properties.Resources._1cent;
			this.pictureBox1.Size = new System.Drawing.Size(60, 60);
			type = 12;
                        locDest = pb1cent.Location;
			break;
		}

                pictureBox1.Visible = true;
                location = new Point();
    
                location.X = (int)(1050 * widthFactor);
                location.Y = (int)(500 * heightFactor);
                AddPicturebox1();
                pictureBox1.BringToFront();
                ((Form)this).Update();
    
                            
                while (location.X > locDest.X+12)
                {                            
                    location.X = (int)(location.X - 4 * Globals.speedFactor2 * widthFactor);
   
                    this.pictureBox1.Location = location;
                    Thread.Sleep(2);
                    ((Form)this).Update();
                    Thread.Sleep(2);
                }
    
                while (location.Y > locDest.Y+10)
                {                            
                    location.Y = (int)(location.Y - 4 * Globals.speedFactor2 * heightFactor);
    
                    this.pictureBox1.Location = location;
                    Thread.Sleep(2);
                    ((Form)this).Update();
                    Thread.Sleep(2);
    
                }

                aggiornaCassa();
            }

            for (int i = 0; i < 12; i++)
            {
                Globals.pFase3[i] = Globals.portafogli[i];
            }

        }

 



        public void AddPicturebox2(Point locPb,PictureBox pb)
        {
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Controls.Add(this.pictureBox1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Image = pb.Image;
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.Location = locPb;

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        }

        public void aggiornaCassa()
        {
            if (type == 1)
            {
                if (Globals.portafogli[0] == 0)
                {
                    pb50euro.Show();
                    l50euro.Show();

                }
                Globals.portafogli[0] += 1;
                this.l50euro.Text = Globals.portafogli[0].ToString();
            }
            else if (type == 2)
            {
                if (Globals.portafogli[1] == 0)
                {
                    pb20euro.Show();
                    l20euro.Show();
                }
                Globals.portafogli[1] += 1;
                this.l20euro.Text = Globals.portafogli[1].ToString();
            }
            else if (type == 3)
            {
                if (Globals.portafogli[2] == 0)
                {
                    pb10euro.Show();
                    l10euro.Show();
                }
                Globals.portafogli[2] += 1;
                this.l10euro.Text = Globals.portafogli[2].ToString();
            }
            else if (type == 4)
            {
                if (Globals.portafogli[3] == 0)
                {
                    pb5euro.Show();
                    l5euro.Show();
                }
                Globals.portafogli[3] += 1;
                this.l5euro.Text = Globals.portafogli[3].ToString();
            }
            else if (type == 5)
            {
                if (Globals.portafogli[4] == 0)
                {
                    pb2euro.Show();
                    l2euro.Show();
                }
                Globals.portafogli[4] += 1;
                this.l2euro.Text = Globals.portafogli[4].ToString();
            }
            else if (type == 6)
            {
                if (Globals.portafogli[5] == 0)
                {
                    pb1euro.Show();
                    l1euro.Show();
                }
                Globals.portafogli[5] += 1;
                this.l1euro.Text = Globals.portafogli[5].ToString();
            }
            else if (type == 7)
            {
                if (Globals.portafogli[6] == 0)
                {
                    pb50cent.Show();
                    l50cent.Show();
                }
                Globals.portafogli[6] += 1;
                this.l50cent.Text = Globals.portafogli[6].ToString();
            }
            else if (type == 8)
            {
                if (Globals.portafogli[7] == 0)
                {
                    pb20cent.Show();
                    l20cent.Show();
                }
                Globals.portafogli[7] += 1;
                this.l20cent.Text = Globals.portafogli[7].ToString();
            }
            else if (type == 9)
            {
                if (Globals.portafogli[8] == 0)
                {
                    pb10cent.Show();
                    l10cent.Show();
                }
                Globals.portafogli[8] += 1;
                this.l10cent.Text = Globals.portafogli[8].ToString();
            }
            else if (type == 10)
            {
                if (Globals.portafogli[9] == 0)
                {
                    pb5cent.Show();
                    l5cent.Show();
                }
                Globals.portafogli[9] += 1;
                this.l5cent.Text = Globals.portafogli[9].ToString();
            }
            else if (type == 11)
            {
                if (Globals.portafogli[10] == 0)
                {
                    pb2cent.Show();
                    l2cent.Show();
                }
                Globals.portafogli[10] += 1;
                this.l2cent.Text = Globals.portafogli[10].ToString();
            }
            else if (type == 12)
            {
                if (Globals.portafogli[11] == 0)
                {
                    pb1cent.Show();
                    l1cent.Show();
                }
                Globals.portafogli[11] += 1;
                this.l1cent.Text = Globals.portafogli[11].ToString();
            }
        }

        private System.Windows.Forms.PictureBox pictureBox1 = new System.Windows.Forms.PictureBox();
        private Point location;
        private int type;
        private Point locDest;
        private string stringa1;
        private string stringa2;

        private void lScaffale6_Click(object sender, EventArgs e)
        {

        }
    }
}
