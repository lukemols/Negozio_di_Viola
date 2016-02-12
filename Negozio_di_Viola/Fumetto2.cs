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
        bool indovinato; //Dice se l'utente ha inserito il prezzo corretto
        double guadagno; //Guadagno
        double prezzoBase; //Costo delle scarpe in fabbrica
        double prezzoFinale; //Prezzo al cliente

        public Fumetto2()
        {
            InitializeComponent();
            //Ottieni i valori dei prezzi 
            prezzoBase = Globals.scarpe.PrezzoAcquisto;
            prezzoFinale = Globals.scarpe.PrezzoVendita;
            guadagno = prezzoFinale - prezzoBase;
            indovinato = false; //Per ora non ha indovinato

            FormBorderStyle = FormBorderStyle.None; //Nascondi la barra della finestra
            WindowState = FormWindowState.Maximized; // massimizza a schermo intero
            this.AcceptButton = OkButton; //Se l'utente preme INVIO è come se avesse premuto OKBUTTON
            this.CancelButton = MenuButton; //Se l'utente preme ESC è come se avesse premuto MENUBUTTON

            CaricaImmagini();
            AdattamentoRisoluzione();
            SettaColori();
            this.SizeChanged += Fumetto2_SizeChanged; //Se dovesse cambiare la risoluzione adatta la schermata
        }

        /// <summary>
        /// Metodo chiamato quando si modificano le dimensioni del form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Fumetto2_SizeChanged(object sender, EventArgs e)
        {
            AdattamentoRisoluzione();
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
            //Ottieni altezza e lunghezza
            int screen_Height = this.Height;
            int screen_Width = this.Width;
            int fontsize = (screen_Width - 125) / 100; //Font lineare con la lunghezza della finestra
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
            /* Per mettere bene i vari testi si parte dalla prima label (posizionata nella prima riga) e
            si spaziano in modo ricorsivo gli altri controlli di modo che siano sempre distanziati
            dallo stesso numero di pixel. Per la spaziatura orizzontale (es seconda riga) si attua un
            procedimento simile.*/
            //Label iniziale
            int space = screen_Height / 32;
            fontsize = (screen_Width + 125) / 100;
            Font labelFont = new Font("Verdana", fontsize, FontStyle.Bold);
            FumettoLabel1.Text = "Hai visto che non ho ancora fissato il prezzo delle scarpe?";
            FumettoLabel1.Location = new Point((int)(0.15 * screen_Width), (int)(0.15 * screen_Height));
            FumettoLabel1.Font = labelFont;
            FumettoLabel1.BackColor = Color.White;
            //Prima Label seconda riga
            int y = FumettoLabel1.Location.Y + FumettoLabel1.Height + space;
            FumettoLabel21.Text = "(Se non hai visto, torna al";
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
            y += FumettoLabel21.Height + space;
            FumettoLabel3.Text = "Voglio guadagnare " + guadagno.ToString("F2") + "€.";
            FumettoLabel3.Location = new Point((int)(0.15 * screen_Width), y);
            FumettoLabel3.Font = labelFont;
            FumettoLabel3.BackColor = Color.White;
            //Label quarta riga
            y += FumettoLabel3.Height + space;
            FumettoLabel4.Text = "Se ho pagato le scarpe " + prezzoBase.ToString("F2") + "€ in fabbrica, quanto devo farle pagare? Aiutami tu!";
            FumettoLabel4.Location = new Point((int)(0.08 * screen_Width), y);
            FumettoLabel4.Font = labelFont;
            FumettoLabel4.BackColor = Color.White;

            //PictureBox dello smile
            y += FumettoLabel4.Height + space;
            SmilePictureBox.Image = global::Negozio_di_Viola.Properties.Resources.SmileFelice;
            SmilePictureBox.Width = (int)(0.05 * screen_Width);
            SmilePictureBox.Height = SmilePictureBox.Width;
            SmilePictureBox.Location = new Point((int)(0.15 * screen_Width), y);
            SmilePictureBox.Visible = false;
            SmilePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            SmilePictureBox.BackColor = Color.White;

            //Textbox in cui scrivere il guadagno
            x = SmilePictureBox.Location.X + SmilePictureBox.Width + 20;
            GuadagnoTextBox.Width = (int)(0.1 * screen_Width);
            GuadagnoTextBox.Height = (int)(0.05 * screen_Height);
            GuadagnoTextBox.Location = new Point(x, y);
            GuadagnoTextBox.Font = labelFont;
            GuadagnoTextBox.TextAlign = HorizontalAlignment.Right;
        }

        /// <summary>
        /// Metodo che si occupa di mostrare lo smile nella picturebox.
        /// </summary>
        /// <param name="tipo">Scrivere Felice (di default) per lo smile felice, altrimenti verrà mostrato quello triste</param>
        void MostraSmile(string tipo = "Felice")
        {
            if (tipo == "Felice")
                SmilePictureBox.Image = global::Negozio_di_Viola.Properties.Resources.SmileFelice;
            else
                SmilePictureBox.Image = global::Negozio_di_Viola.Properties.Resources.SmileTriste;
            SmilePictureBox.Visible = true;
        }

        #region Metodi dei click sui pulsanti

        /// <summary>
        /// Il click sul pulsante calcolatrice mostra il form "Calcolatrice"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalcolatriceButton_Click(object sender, EventArgs e)
        {
            Calcolatrice calc = new Calcolatrice();
            calc.ShowDialog();
        }

        /// <summary>
        /// Metodo che controlla il risultato dell'azione dell'utente quando preme ok.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            //Prova a convertire il testo in un double
            try
            {
                double valoreInserito = Convert.ToDouble(GuadagnoTextBox.Text);
                if (valoreInserito == prezzoFinale) //Se il prezzo finale inserito è corretto
                {
                    MostraSmile("Felice"); //Mostra la faccina felice e poni a true indovinato
                    indovinato = true;
                }
                else
                {
                    MostraSmile("Triste");// altrimenti mostra la faccina triste
                    indovinato = false;
                }
            }
            catch(FormatException)
            {
                GuadagnoTextBox.Text = "";//Se c'è un errore di conversione cancella il testo
                SmilePictureBox.Visible = false;//e nascondi la faccina
            }
        }

        /// <summary>
        /// Metodo che apre la finestra "AssegnazioneGuadagno" per far ragionare l'utente nel caso non conosca la risposta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NonSoButton_Click(object sender, EventArgs e)
        {
            AssegnazioneGuadagno ass = new AssegnazioneGuadagno();
            ass.Show();
        }

        /// <summary>
        /// Metodo che fa ritornare al menu principale dopo il click su Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuButton_Click(object sender, EventArgs e)
        {
            Globals.newGame = false;
            HomePage pagIniz = new HomePage();
            this.Close();
            pagIniz.ShowDialog();
        }

        /// <summary>
        /// Metodo che gestisce il click su Avanti
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AvantiButton_Click(object sender, EventArgs e)
        {
            //Vai avanti solo se l'utente ha indovinato
            if (indovinato)
            {
                Globals.statoGioco = 3;
                Negozio2.enabledClick = true;
                Globals.visualizzaDialogo = false;
                Negozio2 negozio = new Negozio2();
                negozio.ShowDialog();
                this.Close();
            }
        }

        /// <summary>
        /// Se l'utente clicca su Negozio fai tornare alla schermata precedente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NegozioButton_Click(object sender, EventArgs e)
        {
            Negozio3 neg3 = new Negozio3();
            neg3.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Metodo che gestisce il cambio del testo nella textbox Guadagno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuadagnoTextBoxTextChanged(object sender, EventArgs e)
        {
            //Accetta l'inserimento di numeri e virgole. Altri caratteri vengono cancellati
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
