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
    public partial class HomePage : Form
    {
        Mappa mappa;
        Settings settings;

        public static bool newGame = true;

        public HomePage()
        {
            InitializeComponent();
            ResetGame();
            configurazione();
            visualizzazione();

            if (Globals.newGame)
            {
                this.Controls.Add(this.bCont);
                this.bGioca.Location = new System.Drawing.Point(390, 440);
                this.bEsci.Location = new System.Drawing.Point(390, 560);
            }

            Adattamento_Risoluzione();
        }
        
        private void ResetGame()
        {
            newGame = true;
            Globals.statoGioco = 0;
            Globals.newLevel = true;
            Globals.wallet_exists = false;
            Globals.listProdottiNegozio = new List<Prodotto>(16);
            Globals.portafogli = new int[12];
            Globals.listProdottiTutti = new List<Prodotto>();
            Globals.visualizzaDialogo = false;
            Globals.pFase1 = new int[12];
            Globals.pFase2 = new int[12];
            Globals.pFase3 = new int[12];
            Globals.casellaP2 = new List<int>();

            for(int i = 0; i < 12; i++)
            {
                Globals.pFase1[i] = 0;
                Globals.pFase2[i] = 0;
                Globals.pFase3[i] = 0;
            }
        }

        private void configurazione()
        {
            try
            {
                string str;
                string[] s;
                StreamReader sr = new StreamReader("config.ini");

                do str = sr.ReadLine(); while (str == "" || str[0] == ';');	// sfondo
                s = str.Split(new Char[] { '=' });
                if (s[1].Trim() != "") Globals.PANEL_BACKGROUND = s[1]; else Globals.PANEL_BACKGROUND = Globals.PANEL_BACKGROUND_DEF;

                do str = sr.ReadLine(); while (str == "" || str[0] == ';');	// sfondo pulsanti
                s = str.Split(new Char[] { '=' });
                if (s[1].Trim() != "") Globals.BUTTON_BACKGROUND = s[1]; else Globals.BUTTON_BACKGROUND = Globals.BUTTON_BACKGROUND_DEF;

                do str = sr.ReadLine(); while (str == "" || str[0] == ';');	// sfondo pulsanti ok
                s = str.Split(new Char[] { '=' });
                if (s[1].Trim() != "") Globals.BUTTON_BACKGROUND_OK = s[1]; else Globals.BUTTON_BACKGROUND_OK = Globals.BUTTON_BACKGROUND_OK_DEF;

                do str = sr.ReadLine(); while (str == "" || str[0] == ';');	// testo pulsanti
                s = str.Split(new Char[] { '=' });
                if (s[1].Trim() != "") Globals.BUTTON_TEXT = s[1]; else Globals.BUTTON_TEXT = Globals.BUTTON_TEXT_DEF;

                do str = sr.ReadLine(); while (str == "" || str[0] == ';');	// sfondo attivo
                s = str.Split(new Char[] { '=' });
                if (s[1].Trim() != "") Globals.ACTIVE_BACKGROUND = s[1]; else Globals.ACTIVE_BACKGROUND = Globals.ACTIVE_BACKGROUND_DEF;

                do str = sr.ReadLine(); while (str == "" || str[0] == ';');	// sfondo inattivo
                s = str.Split(new Char[] { '=' });
                if (s[1].Trim() != "") Globals.INACTIVE_BACKGROUND = s[1]; else Globals.INACTIVE_BACKGROUND = Globals.INACTIVE_BACKGROUND_DEF;

                do str = sr.ReadLine(); while (str == "" || str[0] == ';');	//selezione
                s = str.Split(new Char[] { '=' });
                if (s[1].Trim() != "") Globals.SELECTION = s[1]; else Globals.SELECTION = Globals.SELECTION_DEF;

                do str = sr.ReadLine(); while (str == "" || str[0] == ';');	// livello gioco
                s = str.Split(new Char[] { '=' });
                if (s[1].Trim() != "") Globals.Livello = Convert.ToInt32(s[1]); else Globals.Livello = Globals.Livello_DEF;

                do str = sr.ReadLine(); while (str == "" || str[0] == ';');	// tipo => tipo
                s = str.Split(new Char[] { '=' });
                if (s[1].Trim() != "") Globals.Tipo = s[1]; else Globals.Tipo = Globals.Tipo_DEF;

                do str = sr.ReadLine(); while (str == "" || str[0] == ';');	// lingua => lingua
                s = str.Split(new Char[] { '=' });
                if (s[1].Trim() != "") Globals.Lingua = s[1]; else Globals.Lingua = Globals.Lingua_DEF;

                sr.Close();
            }
            catch (Exception IOException)
            {
                Globals.PANEL_BACKGROUND = Globals.PANEL_BACKGROUND_DEF;
                Globals.BUTTON_BACKGROUND = Globals.BUTTON_BACKGROUND_DEF;
                Globals.BUTTON_BACKGROUND_OK = Globals.BUTTON_BACKGROUND_OK_DEF;
                Globals.BUTTON_TEXT = Globals.BUTTON_TEXT_DEF;
                Globals.ACTIVE_BACKGROUND = Globals.ACTIVE_BACKGROUND_DEF;
                Globals.INACTIVE_BACKGROUND = Globals.INACTIVE_BACKGROUND_DEF;
                Globals.SELECTION = Globals.SELECTION_DEF;
                Globals.Livello = Globals.Livello_DEF;
                Globals.Tipo = Globals.Tipo_DEF;
                Globals.Lingua = Globals.Lingua_DEF;		
            }
        }

        private void mappa_Click(object sender, EventArgs e)
        {
            Globals.statoGioco = 0;
	    Globals.global_rnd = new Random(Environment.TickCount);
            mappa = new Mappa();
            mappa.ShowDialog();
            Globals.newGame = false;
            this.Close();
        }

        private void riprendi_Click(object sender, EventArgs e)
        {
	    Globals.global_rnd = new Random(Environment.TickCount);
            mappa = new Mappa();
            mappa.ShowDialog();
            Globals.newGame = false;
            this.Close();
        }

        private void esci_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settings_Click(object sender, EventArgs e)
        {
            Globals.statoGioco = 0;
            settings = new Settings();
            settings.ShowDialog();
            Globals.newGame = false;
            //this.Close();
        }

        private void bHelp_Click(object sender, EventArgs e)
        {
            Info win_info = new Info();
            win_info.ShowDialog();
        }

        void visualizzazione()
        {
            this.BackColor = Color.FromName(Globals.PANEL_BACKGROUND);

            this.Titolo.BackColor = Color.FromName(Globals.PANEL_BACKGROUND);
            this.Sottotitolo.BackColor = Color.FromName(Globals.PANEL_BACKGROUND);
            this.bHelp.BackColor = Color.FromName(Globals.PANEL_BACKGROUND);
            this.bEsci.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.bGioca.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.bSettings.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);

            this.Sottotitolo.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.Titolo.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.bEsci.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.bGioca.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.bSettings.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.bHelp.ForeColor = Color.FromName(Globals.BUTTON_BACKGROUND);

            this.Titolo.Text = Globals.Titolo_Text;
	    this.Sottotitolo.Text = Globals.Sottotitolo_Text;
        }

        void Adattamento_Risoluzione()
        {
            int screen_Height = Screen.PrimaryScreen.Bounds.Height;
            int screen_Width = Screen.PrimaryScreen.Bounds.Width;

            double widthFactor = (double) screen_Width / this.Size.Width;
            double heightFactor = (double) screen_Height / this.Size.Height;

            bEsci.Width = (int)(bEsci.Width * widthFactor);
            bEsci.Height = (int)(bEsci.Height * heightFactor);
            bEsci.Location = new Point((int)(bEsci.Location.X * widthFactor), (int)(bEsci.Location.Y * heightFactor));
            bEsci.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            bGioca.Width = (int)(bGioca.Width * widthFactor);
            bGioca.Height = (int)(bGioca.Height * heightFactor);
            bGioca.Location = new Point((int)(bGioca.Location.X * widthFactor), (int)(bGioca.Location.Y * heightFactor));
            bGioca.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            bSettings.Width = (int)(bSettings.Width * widthFactor);
            bSettings.Height = (int)(bSettings.Height * heightFactor);
            bSettings.Location = new Point((int)(bSettings.Location.X * widthFactor), (int)(bSettings.Location.Y * heightFactor));
            bSettings.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            if (newGame)
            {
                bCont.Width = (int)(bCont.Width * widthFactor);
                bCont.Height = (int)(bCont.Height * heightFactor);
                bCont.Location = new Point((int)(bCont.Location.X * widthFactor), (int)(bCont.Location.Y * heightFactor));
                bCont.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);
         //BY   this.Controls.Remove(this.bHelp);
            }

            bHelp.Width = (int)(bHelp.Width * widthFactor);
            bHelp.Height = (int)(bHelp.Height * heightFactor);
            bHelp.Location = new Point((int)(bHelp.Location.X * widthFactor), (int)(bHelp.Location.Y * heightFactor));
            bHelp.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            Titolo.Width = (int)(Titolo.Width * widthFactor);
            Titolo.Height = (int)(Titolo.Height * heightFactor);
            Titolo.Location = new Point((int)(Titolo.Location.X * widthFactor), (int)(Titolo.Location.Y * heightFactor));
            Titolo.Font = new Font("Verdana", (float)widthFactor * 48F, FontStyle.Bold);

            Sottotitolo.Width = (int)(Sottotitolo.Width * widthFactor);
            Sottotitolo.Height = (int)(Sottotitolo.Height * heightFactor);
            Sottotitolo.Location = new Point((int)(Sottotitolo.Location.X * widthFactor), (int)(Sottotitolo.Location.Y * heightFactor));
            Sottotitolo.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void Titolo_Click(object sender, EventArgs e)
        {

        }
    }
}
