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

            AdattamentoRisoluzione();
            CaricaImmagini();
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
        }

        /// <summary>
        /// Metodo che adatta l'interfaccia alla risoluzione attuale
        /// </summary>
        void AdattamentoRisoluzione()
        {
            int screen_Height = Screen.PrimaryScreen.Bounds.Height;
            int screen_Width = Screen.PrimaryScreen.Bounds.Width;
            //Picture Box
            // Viola
            ViolaPictureBox.Height = screen_Height;
            ViolaPictureBox.Width = (int)(0.3 * screen_Width);
            ViolaPictureBox.Location = new Point((int)(0.7 * screen_Width), 0);
            ViolaPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            // Nuvoletta
            NuvolettaPictureBox.Height = (int)(0.8 * screen_Height);
            NuvolettaPictureBox.Width = (int)(0.7 * screen_Width);
            NuvolettaPictureBox.Location = new Point(0, 0);
            NuvolettaPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            //Pulsanti
            //Pulsante menu
            MenuButton.Height = screen_Height / 14;
            MenuButton.Width = screen_Width / 10;
            MenuButton.Location = new Point((int)(0.1 * screen_Width), (int)(0.85 * screen_Height));
            //Pulsante avanti
            AvantiButton.Height = screen_Height / 14;
            AvantiButton.Width = screen_Width / 10;
            AvantiButton.Location = new Point((int)(0.3 * screen_Width), (int)(0.85 * screen_Height));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AssegnazioneGuadagno ass = new AssegnazioneGuadagno();
            ass.Show();
        }
    }
}
