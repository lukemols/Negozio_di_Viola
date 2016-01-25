using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Negozio_di_Viola
{
    public partial class Fumetto : Form
    {
        Fumetto fumetto;
        Negozio2 negozio;
        Negozio1 negozio1;

        double widthFactor;
        double heightFactor;

        public Fumetto(int n)
        {
            Negozio2.dialogoVisualizzato = true;
            
            int screen_Height = Screen.PrimaryScreen.Bounds.Height;
            int screen_Width = Screen.PrimaryScreen.Bounds.Width;

            widthFactor = 1.0; //XXXXXXX Globals.widthFactor;
            heightFactor = 1.0; //XXXXXXX Globals.heightFactor;

            InitializeComponent(n);

        //  widthFactor = (double) screen_Width / this.Size.Width;
        //  heightFactor = (double) screen_Height / this.Size.Height;

            visualizzazione();
            Adattamento_Risoluzione();
        }

        private void onClick(object sender, EventArgs e)
        {
            if(sender is Button)
            {
                System.Drawing.Color color = Color.FromName(Globals.BUTTON_BACKGROUND_OK);

                switch(((Button)sender).Name)
                {
                    case "bOpt1":

                        risUtente = 1;
                        
                        bOpt1.BackColor = color;
                        bOpt2.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        bOpt3.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);

                        break;

                    case "bOpt2":

                        risUtente = 2;
                        
                        bOpt2.BackColor = color;
                        bOpt1.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        bOpt3.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);

                        break;

                    case "bOpt3":

                        risUtente = 3;
                        
                        bOpt3.BackColor = color;
                        bOpt1.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        bOpt2.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        
                        break;
                    
                    case "ok":

                        if(risUtente == risCorretta)
                        {                            
                            smile.Image = global::Negozio_di_Viola.Properties.Resources.SmileFelice;
                            bOpt1.Click -= new System.EventHandler(this.onClick);
                            bOpt2.Click -= new System.EventHandler(this.onClick);
                            bOpt3.Click -= new System.EventHandler(this.onClick);
                            this.avanti.Click += new System.EventHandler(this.onClick);
                        }

                        else
                        {
                            if(pagina == 1)

                                this.avanti.Click -= new System.EventHandler(this.onClick);
                            
                            else if (pagina == 2)
                            {
                                bOpt1.Click -= new System.EventHandler(this.onClick);
                                bOpt2.Click -= new System.EventHandler(this.onClick);
                                bOpt3.Click -= new System.EventHandler(this.onClick);
                            }
                            
                            smile.Image = global::Negozio_di_Viola.Properties.Resources.SmileTriste;
                        }

                        break;

                    case "avanti":
                        {
                            this.Close();

                            if (pagina == 1)
                            {
                                if (risUtente == risCorretta)

                                    fumetto = new Fumetto(2);

                                else

                                    fumetto = new Fumetto(22);

                                fumetto.ShowDialog();
                                this.Close();
                            }

                            else if (pagina == 22)
                            {
                                fumetto = new Fumetto(2);
                                fumetto.ShowDialog();
                                this.Close();
                            }

                            else if (pagina == 2 && risUtente != risCorretta)
                            {
                                Globals.statoGioco = 3;
                                fumetto = new Fumetto(3);
                                fumetto.ShowDialog();
                                this.Close();
                            }

                            else if(pagina == 2 && risUtente == risCorretta)
                            {
                                Globals.statoGioco = 3;
                                fumetto = new Fumetto(4);
                                fumetto.ShowDialog();
                                this.Close();
                            }

                            else
                            {
                                Globals.statoGioco = 3;
                                Negozio2.enabledClick = true;
                                Globals.visualizzaDialogo = false;
                                negozio = new Negozio2();
                                negozio.ShowDialog();
                                this.Close();
                            }

                            break;
                        }

                    case "indietro":

                        negozio1 = new Negozio1();
                        negozio1.ShowDialog();
                        this.Close();

                        break;

                    case "menu":

                        Globals.newGame = false;
                        HomePage pagIniz = new HomePage();
                        this.Close();
                        pagIniz.ShowDialog();

                        break;

                    case "esci":

                        Application.Exit();

                        break;
                }
            }
        }

        void visualizzazione()
        {
            this.ok.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.avanti.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.menu.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.esci.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.bOpt1.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.bOpt2.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.bOpt3.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.viola.BackColor = Color.FromName(Globals.PANEL_BACKGROUND);
            this.BackColor = Color.FromName(Globals.PANEL_BACKGROUND);
        }

        void Adattamento_Risoluzione()
        {
            ok.Width = (int)(ok.Width * widthFactor);
            ok.Height = (int)(ok.Height * heightFactor);
            ok.Location = new Point((int)(ok.Location.X * widthFactor), (int)(ok.Location.Y * heightFactor));
            ok.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            esci.Width = (int)(esci.Width * widthFactor);
            esci.Height = (int)(esci.Height * heightFactor);
            esci.Location = new Point((int)(esci.Location.X * widthFactor), (int)(esci.Location.Y * heightFactor));
            esci.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            avanti.Width = (int)(avanti.Width * widthFactor);
            avanti.Height = (int)(avanti.Height * heightFactor);
            avanti.Location = new Point((int)(avanti.Location.X * widthFactor), (int)(avanti.Location.Y * heightFactor));
            avanti.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            menu.Width = (int)(menu.Width * widthFactor);
            menu.Height = (int)(menu.Height * heightFactor);
            menu.Location = new Point((int)(menu.Location.X * widthFactor), (int)(menu.Location.Y * heightFactor));
            menu.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            bOpt1.Width = (int)(bOpt1.Width * widthFactor);
            bOpt1.Height = (int)(bOpt1.Height * heightFactor);
            bOpt1.Location = new Point((int)(bOpt1.Location.X * widthFactor), (int)(bOpt1.Location.Y * heightFactor));
            bOpt1.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            bOpt2.Width = (int)(bOpt2.Width * widthFactor);
            bOpt2.Height = (int)(bOpt2.Height * heightFactor);
            bOpt2.Location = new Point((int)(bOpt2.Location.X * widthFactor), (int)(bOpt2.Location.Y * heightFactor));
            bOpt2.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            bOpt3.Width = (int)(bOpt3.Width * widthFactor);
            bOpt3.Height = (int)(bOpt3.Height * heightFactor);
            bOpt3.Location = new Point((int)(bOpt3.Location.X * widthFactor), (int)(bOpt3.Location.Y * heightFactor));
            bOpt3.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            viola.Width = (int)(viola.Width * widthFactor);
            viola.Height = (int)(viola.Height * heightFactor);
            viola.Location = new Point((int)(viola.Location.X * widthFactor), (int)(viola.Location.Y * heightFactor));

            testo.Width = (int)(testo.Width * widthFactor);
            testo.Height = (int)(testo.Height * heightFactor);
            testo.Location = new Point((int)(testo.Location.X * widthFactor), (int)(testo.Location.Y * heightFactor));

            tOpt1.Width = (int)(tOpt1.Width * widthFactor);
            tOpt1.Height = (int)(tOpt1.Height * heightFactor);
            tOpt1.Location = new Point((int)(tOpt1.Location.X * widthFactor), (int)(tOpt1.Location.Y * heightFactor));

            tOpt2.Width = (int)(tOpt2.Width * widthFactor);
            tOpt2.Height = (int)(tOpt2.Height * heightFactor);
            tOpt2.Location = new Point((int)(tOpt2.Location.X * widthFactor), (int)(tOpt2.Location.Y * heightFactor));

            tOpt3.Width = (int)(tOpt3.Width * widthFactor);
            tOpt3.Height = (int)(tOpt3.Height * heightFactor);
            tOpt3.Location = new Point((int)(tOpt3.Location.X * widthFactor), (int)(tOpt3.Location.Y * heightFactor));

            panel.Width = (int)(panel.Width * widthFactor);
            panel.Height = (int)(panel.Height * heightFactor);
            panel.Location = new Point((int)(panel.Location.X * widthFactor), (int)(panel.Location.Y * heightFactor));

            panelViola.Width = (int)(panelViola.Width * widthFactor);
            panelViola.Height = (int)(panelViola.Height * heightFactor);
            panelViola.Location = new Point((int)(panelViola.Location.X * widthFactor), (int)(panelViola.Location.Y * heightFactor));

            this.Width = (int)(this.Width * widthFactor);
            this.Height = (int)(this.Height * heightFactor);
            this.Location = new Point((int)(this.Location.X * widthFactor), (int)(this.Location.Y * heightFactor));
        }

        private void Fumetto_Load(object sender, EventArgs e)
        {
            
        }
    }
}
