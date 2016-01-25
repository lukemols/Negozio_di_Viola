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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            visualizzazione();
            Adattamento_Risoluzione();
        }

        void visualizzazione()
        {
            System.Drawing.Color color = Color.FromName(Globals.BUTTON_BACKGROUND_OK);

            this.bIndietro.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.BackColor = Color.FromName(Globals.PANEL_BACKGROUND);

            if(Globals.Livello == 1)
                this.lev1.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND_OK);
	    else
                this.lev1.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            if(Globals.Livello == 2)
                this.lev2.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND_OK);
	    else
                this.lev2.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            if(Globals.Livello == 3)
                this.lev3.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND_OK);
	    else
                this.lev3.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            if(Globals.Livello == 4)
                this.lev4.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND_OK);
	    else
                this.lev4.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            if(Globals.Livello == 5)
                this.lev5.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND_OK);
	    else
                this.lev5.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            if(Globals.Livello == 6)
                this.lev6.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND_OK);
	    else
                this.lev6.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
        }

        void Adattamento_Risoluzione()
        {
            int screen_Height = Screen.PrimaryScreen.Bounds.Height;
            int screen_Width = Screen.PrimaryScreen.Bounds.Width;

            double widthFactor = (double) screen_Width / this.Size.Width;
            double heightFactor = (double) screen_Height / this.Size.Height;

      //    double widthFactor = Globals.widthFactor;
      //    double heightFactor = Globals.heightFactor;

            bIndietro.Width = (int)(bIndietro.Width * widthFactor);
            bIndietro.Height = (int)(bIndietro.Height * heightFactor);
            bIndietro.Location = new Point((int)(bIndietro.Location.X * widthFactor), (int)(bIndietro.Location.Y * heightFactor));
            bIndietro.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            lev1.Width = (int)(lev1.Width * widthFactor);
            lev1.Height = (int)(lev1.Height * heightFactor);
            lev1.Location = new Point((int)(lev1.Location.X * widthFactor), (int)(lev1.Location.Y * heightFactor));
            lev1.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            lev2.Width = (int)(lev2.Width * widthFactor);
            lev2.Height = (int)(lev2.Height * heightFactor);
            lev2.Location = new Point((int)(lev2.Location.X * widthFactor), (int)(lev2.Location.Y * heightFactor));
            lev2.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            lev3.Width = (int)(lev3.Width * widthFactor);
            lev3.Height = (int)(lev3.Height * heightFactor);
            lev3.Location = new Point((int)(lev3.Location.X * widthFactor), (int)(lev3.Location.Y * heightFactor));
            lev3.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            lev4.Width = (int)(lev4.Width * widthFactor);
            lev4.Height = (int)(lev4.Height * heightFactor);
            lev4.Location = new Point((int)(lev4.Location.X * widthFactor), (int)(lev4.Location.Y * heightFactor));
            lev4.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            lev5.Width = (int)(lev5.Width * widthFactor);
            lev5.Height = (int)(lev5.Height * heightFactor);
            lev5.Location = new Point((int)(lev5.Location.X * widthFactor), (int)(lev5.Location.Y * heightFactor));
            lev5.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            lev6.Width = (int)(lev6.Width * widthFactor);
            lev6.Height = (int)(lev6.Height * heightFactor);
            lev6.Location = new Point((int)(lev6.Location.X * widthFactor), (int)(lev6.Location.Y * heightFactor));
            lev6.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            Titolo.Width = (int)(Titolo.Width * widthFactor);
            Titolo.Height = (int)(Titolo.Height * heightFactor);
            Titolo.Location = new Point((int)(Titolo.Location.X * widthFactor), (int)(Titolo.Location.Y * heightFactor));
            Titolo.Font = new Font("Verdana", (float)widthFactor * 60F, FontStyle.Bold);

            Testo1.Width = (int)(Testo1.Width * widthFactor);
            Testo1.Height = (int)(Testo1.Height * heightFactor);
            Testo1.Location = new Point((int)(Testo1.Location.X * widthFactor), (int)(Testo1.Location.Y * heightFactor));
            Testo1.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

        }

        private void onClick(object sender, EventArgs e)
        {
            Globals.mode = Globals.MODE.auto;

            System.Drawing.Color color = Color.FromName(Globals.BUTTON_BACKGROUND_OK);

            if(sender is Button)
            {
                switch(((Button)sender).Name)
                {
                    
                    case "lev1":

                        this.lev2.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.lev3.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.lev4.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.lev5.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.lev6.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.bIndietro.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        lev1.BackColor = color;
                        Globals.Livello = 1;

                        break;

                    case "lev2":

                        this.lev1.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.lev3.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.lev4.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.lev5.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.lev6.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.bIndietro.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        lev2.BackColor = color;
                        Globals.Livello = 2;
                        
                        break;

                    case "lev3":

                        this.lev1.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.lev2.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.lev4.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.lev5.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.lev6.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.bIndietro.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        lev3.BackColor = color;
                        Globals.Livello = 3;
                        
                        break;

                    case "lev4":

                        this.lev1.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.lev2.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.lev3.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.lev5.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.lev6.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.bIndietro.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        lev4.BackColor = color;
                        Globals.Livello = 4;

                        break;

                    case "lev5":

                        this.lev1.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.lev2.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.lev3.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.lev4.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.lev6.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.bIndietro.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        lev5.BackColor = color;
                        Globals.Livello = 5;

                        break;

                    case "lev6":

                        this.lev1.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.lev2.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.lev3.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.lev4.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.lev5.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        this.lev6.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
                        lev6.BackColor = color;
                        Globals.Livello = 6;

                        break;

                    case "bIndietro":

                        bIndietro.BackColor = color;
                        this.Close();

                        break;
                }
            }
        }

        private void SettingsPage_Load(object sender, EventArgs e)
        {

        }

        private void Titolo_Click(object sender, EventArgs e)
        {

        }
    }
}
