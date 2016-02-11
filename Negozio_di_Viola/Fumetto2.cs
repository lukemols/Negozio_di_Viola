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
    public partial class Fumetto2 : Form
    {
        int i = 0;
        public Fumetto2()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None; //Nascondi la barra della finestra
            WindowState = FormWindowState.Maximized; // massimizza a schermo intero

            CaricaImmagini();
            AdattamentoRisoluzione();
            CaricaTesto();
            SettaColori();
        }
        
        /// <summary>
        /// Metodo che carica il testo nel vari pulsanti e label
        /// </summary>
        void CaricaTesto()
        {

        }

        /// <summary>
        /// Metodo che carica le immagini nelle picturebox
        /// </summary>
        void CaricaImmagini()
        {
            NuvolettaPictureBox.Image = global::Negozio_di_Viola.Properties.Resources.nuvoletta;
            ViolaPictureBox.Image = global::Negozio_di_Viola.Properties.Resources.Viola;
        }

        /// <summary>
        /// Metodo che setta il colore di sfondo dei controlli
        /// </summary>
        void SettaColori()
        {
            //Colore di sfondo delle finestre
            this.BackColor = Color.FromName(Globals.PANEL_BACKGROUND);
            ViolaPictureBox.BackColor = Color.FromName(Globals.PANEL_BACKGROUND);
            NuvolettaPictureBox.BackColor = Color.FromName(Globals.PANEL_BACKGROUND);

            //Colore dei pulsanti
            MenuButton.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            AvantiButton.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            CalcolatriceButton.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            OkButton.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            NonSoButton.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
        }

        /// <summary>
        /// Metodo che adatta l'interfaccia alla risoluzione attuale
        /// </summary>
        void AdattamentoRisoluzione()
        {
            int screen_Height = Screen.PrimaryScreen.Bounds.Height;
            int screen_Width = Screen.PrimaryScreen.Bounds.Width;
            int fontsize = (screen_Width - 125) / 100;
            Font buttonFont = new Font("Verdana", fontsize, FontStyle.Bold);
            //Picture Box
            // Viola
            ViolaPictureBox.Height = screen_Height;
            ViolaPictureBox.Width = (int)(0.25 * screen_Width);
            ViolaPictureBox.Location = new Point((int)(0.75 * screen_Width), 0);
            ViolaPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            // Nuvoletta
            NuvolettaPictureBox.Height = (int)(0.85 * screen_Height);
            NuvolettaPictureBox.Width = (int)(0.75 * screen_Width);
            NuvolettaPictureBox.Location = new Point(0, 0);
            NuvolettaPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            //Pulsanti
            //Pulsante menu
            MenuButton.Height = screen_Height / 14;
            MenuButton.Width = screen_Width / 10;
            MenuButton.Location = new Point((int)(0.1 * screen_Width), (int)(0.85 * screen_Height));
            MenuButton.Font = buttonFont;
            //Pulsante avanti
            AvantiButton.Height = screen_Height / 14;
            AvantiButton.Width = screen_Width / 10;
            AvantiButton.Location = new Point((int)(0.3 * screen_Width), (int)(0.85 * screen_Height));
            AvantiButton.Font = buttonFont;
            //Pulsante calcolatrice
            CalcolatriceButton.Height = screen_Height / 14;
            CalcolatriceButton.Width = screen_Width / 10;
            CalcolatriceButton.Location = new Point((int)(0.1 * screen_Width), (int)(0.65 * screen_Height));
            CalcolatriceButton.Font = buttonFont;
            //Pulsante avanti
            OkButton.Height = screen_Height / 14;
            OkButton.Width = screen_Width / 10;
            OkButton.Location = new Point((int)(0.25 * screen_Width), (int)(0.65 * screen_Height));
            OkButton.Font = buttonFont;
            //Pulsante menu
            NonSoButton.Height = screen_Height / 14;
            NonSoButton.Width = screen_Width / 10;
            NonSoButton.Location = new Point((int)(0.4 * screen_Width), (int)(0.65 * screen_Height));
            NonSoButton.Font = buttonFont;

            //Testo nella nuvoletta
            //Label iniziale
            fontsize = (screen_Width + 125) / 100;
            Font labelFont = new Font("Verdana", fontsize, FontStyle.Bold);
            FumettoLabel1.Text = "Hai visto che non ho ancora fissato il prezzo delle scarpe?";
            FumettoLabel1.Location = new Point((int)(0.15 * screen_Width), (int)(0.15 * screen_Height));
            FumettoLabel1.Font = labelFont;
            FumettoLabel1.BackColor = Color.White;
            //Prima Label seconda riga
            int y = FumettoLabel1.Location.Y + FumettoLabel1.Height + 20;
            FumettoLabel21.Text = "(Se non hai visto, torna al ";
            FumettoLabel21.Location = new Point((int)(0.15 * screen_Width), y);
            FumettoLabel21.Font = labelFont;
            FumettoLabel21.BackColor = Color.White;
            //Pulsante Negozio
            int x = FumettoLabel21.Location.X + FumettoLabel21.Width + 10;
            NegozioButton.Height = FumettoLabel21.Height + 10;
            NegozioButton.Width = screen_Width / 10;
            NegozioButton.Text = "NEGOZIO";
            NegozioButton.Location = new Point(x, y - 5);
            NegozioButton.Font = buttonFont;
            //Seconda Label seconda riga
            x += NegozioButton.Width + 10;
            FumettoLabel22.Text = "per controllare).";
            FumettoLabel22.Location = new Point(x, y);
            FumettoLabel22.Font = labelFont;
            FumettoLabel22.BackColor = Color.White;
            //Label terza riga
            y += FumettoLabel21.Height + 20;
            FumettoLabel3.Text = "Voglio guadagnare " + "<<Numero da definire>>" + " €.";
            FumettoLabel3.Location = new Point((int)(0.15 * screen_Width), y);
            FumettoLabel3.Font = labelFont;
            FumettoLabel3.BackColor = Color.White;
            //Label quarta riga
            y += FumettoLabel3.Height + 20;
            FumettoLabel4.Text = "Quanto devo far pagare le scarpe? Aiutami tu!";
            FumettoLabel4.Location = new Point((int)(0.15 * screen_Width), y);
            FumettoLabel4.Font = labelFont;
            FumettoLabel4.BackColor = Color.White;

            //PictureBox dello smile
            y += FumettoLabel4.Height + 20;
            SmilePictureBox.Image = global::Negozio_di_Viola.Properties.Resources.SmileFelice;
            SmilePictureBox.Width = (int)(0.05 * screen_Width);
            SmilePictureBox.Height = SmilePictureBox.Width;
            SmilePictureBox.Location = new Point((int)(0.15 * screen_Width), y);
            SmilePictureBox.Visible = true;
            SmilePictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            //Textbox in cui scrivere il guadagno
            x = SmilePictureBox.Location.X + SmilePictureBox.Width + 20;
            GuadagnoTextBox.Width = (int)(0.1 * screen_Width);
            GuadagnoTextBox.Height = (int)(0.05 * screen_Height);
            GuadagnoTextBox.Location = new Point(x, y);
            GuadagnoTextBox.Font = labelFont;
        }


        #region Metodi dei click sui pulsanti

        private void CalcolatriceButton_Click(object sender, EventArgs e)
        {
            Calcolatrice calc = new Calcolatrice();
            calc.ShowDialog();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {

        }

        private void NonSoButton_Click(object sender, EventArgs e)
        {
            AssegnazioneGuadagno ass = new AssegnazioneGuadagno();
            ass.Show();
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            Globals.newGame = false;
            HomePage pagIniz = new HomePage();
            this.Close();
            pagIniz.ShowDialog();
        }

        private void AvantiButton_Click(object sender, EventArgs e)
        {

        }

        private void NegozioButton_Click(object sender, EventArgs e)
        {
            Negozio3 neg3 = new Negozio3();
            neg3.Show();
            this.Close();
        }

        private void GuadagnoTextBoxTextChanged(object sender, EventArgs e)
        {
            int len = GuadagnoTextBox.Text.Length;
            string txt = GuadagnoTextBox.Text;
            for (int i = 0; i < len; i++)
            {
                if (!Char.IsNumber(txt[i]) && txt[i] != ',')
                    GuadagnoTextBox.Text = txt.Replace(txt[i].ToString(), "");
            }
        }
        #endregion

    }
}
