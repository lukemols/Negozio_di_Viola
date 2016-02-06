using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;

using Negozio_di_Viola;

namespace Negozio_di_Viola
{
    public partial class Fabbrica : Form 
    {
        Mappa mappa;
        HomePage home;
        Calcolatrice calc;


        // variabili Portafogli e banconote 
        int slot_liberi_banconote = 1;
        int slot_liberi_monete = 1;
        double soldi_spostati = 0;
        double costo_scarpe_selezionate = 0;
        int imm_da_rimuovere;
        
        // Variabili pannello camion
        int slot_liberi_camion1 = 1;
        int slot_liberi_camion2 = 1;
        int slot_liberi_camion3 = 1;
        int slot_liberi_camion4 = 1;

        int Prodotti_tipo1 = 0;
        int Prodotti_tipo2 = 0;
        int Prodotti_tipo3 = 0;
        int Prodotti_tipo4 = 0;

        int[] row_index = new int[4];

        bool[] row_iniz = new bool[4];      // Ogni elemento è false se la riga corrispondente nello scaffale non è ancora
                                            // stata inizializzata, è true altrimenti.

        public Fabbrica()
        {
            /*if (!Globals.wallet_exists)

                CreaPortafogli();*/

            Globals.soldiPrima = Globals.GetSoldiPortafoglio();

            InitializeComponent();

            Adattamento_alla_Risoluzione_Schermo();
	    Visualizzazione();
            Inizializza_Portafoglio();
            Inizializza_Scaffali();

            textInfo.Text = "Carica sul furgone una scatola";           
        }

            
	public void Visualizzazione()
        {
	    button_Menu.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND); 
	    button_TornaNegozio.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND); 
	    calcolatrice.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND); 
	    okCompratore.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND); 

	    button_Menu.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
	    button_TornaNegozio.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
	    calcolatrice.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
	    okCompratore.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 

            Label_10e.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            Label_10ec.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            Label_1e.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            Label_1ec.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            Label_20e.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            Label_20ec.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            Label_2e.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            Label_2ec.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            Label_50e.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            Label_50ec.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            Label_5e.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            Label_5ec.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 

            SimboloEuro.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            Text_Box_Soldi_Pagati.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            Txt_Box_Portafoglio.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            Txt_Box_Scaffale.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            importoCompratore.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            textInfo.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 

            label1.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            label2.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            label22.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            label23.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            label24.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            label25.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            label26.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            label27.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            label28.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            label29.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            label3.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            label30.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            label31.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            label32.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            label33.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            label34.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            label35.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            label36.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            label37.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            label4.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            label5.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 

        }


        private void Inizializza_Pagina()
        {
        }
        

        private void Inizializza_Portafoglio()
        {
            if (Globals.portafogli[0] == 0)
            {
                PictureBox_50e.Hide();
                Label_50e.Hide();
            }
            
            else
            {
                   Label_50e.Text = Globals.portafogli[0].ToString();
                   Label_50e.Show();
                   PictureBox_50e.Show();
            }

            if (Globals.portafogli[1] == 0)
            {
                PictureBox_20e.Hide();
                Label_20e.Hide();
            }

            else
            {
                Label_20e.Text = Globals.portafogli[1].ToString();
                Label_20e.Show();
                PictureBox_20e.Show();
            }

            if (Globals.portafogli[2] == 0)
            {
                PictureBox_10e.Hide();
                Label_10e.Hide();
            }

            else
            {
                Label_10e.Text = Globals.portafogli[2].ToString();
                Label_10e.Show();
                PictureBox_10e.Show();
            }

            if (Globals.portafogli[3] == 0)
            {
                PictureBox_5e.Hide();
                Label_5e.Hide();
            }

            else
            {
                Label_5e.Text = Globals.portafogli[3].ToString();
                Label_5e.Show();
                PictureBox_5e.Show();
            }


            if (Globals.portafogli[4] == 0)
            {
                PictureBox_2e.Hide();
                Label_2e.Hide();
            }

            else
            {
                Label_2e.Text = Globals.portafogli[4].ToString();
                Label_2e.Show();
                PictureBox_2e.Show();
            }

            if (Globals.portafogli[5] == 0)
            {
                PictureBox_1e.Hide();
                Label_1e.Hide();
            }

            else
            {
                Label_1e.Text = Globals.portafogli[5].ToString();
                Label_1e.Show();
                PictureBox_1e.Show();
            }

            if (Globals.portafogli[6] == 0)
            {
                PictureBox_50ec.Hide();
                Label_50ec.Hide();
            }

            else
            {
                Label_50ec.Text = Globals.portafogli[6].ToString();
                Label_50ec.Show();
                PictureBox_50ec.Show();
            }

            if (Globals.portafogli[7] == 0)
            {
                PictureBox_20ec.Hide();
                Label_20ec.Hide();
            }

            else
            {
                Label_20ec.Text = Globals.portafogli[7].ToString();
                Label_20ec.Show();
                PictureBox_20ec.Show();
            }

            if (Globals.portafogli[8] == 0)
            {
                PictureBox_10ec.Hide();
                Label_10ec.Hide();
            }

            else
            {
                Label_10ec.Text = Globals.portafogli[8].ToString();
                Label_10ec.Show();
                PictureBox_10ec.Show();
            }

            if (Globals.portafogli[9] == 0)
            {
                PictureBox_5ec.Hide();
                Label_5ec.Hide();
            }

            else
            {
                Label_5ec.Text = Globals.portafogli[9].ToString();
                Label_5ec.Show();
                PictureBox_5ec.Show();
            }

            if (Globals.portafogli[10] == 0)
            {
                PictureBox_2ec.Hide();
                Label_2ec.Hide();
            }

            else
            {
                Label_2ec.Text = Globals.portafogli[10].ToString();
                Label_2ec.Show();
                PictureBox_2ec.Show();
            }

            if (Globals.portafogli[11] == 0)
            {
                PictureBox_1ec.Hide();
                Label_1ec.Hide();
            }

            else
            {
                Label_1ec.Text = Globals.portafogli[11].ToString();
                Label_1ec.Show();
                PictureBox_1ec.Show();
            }
        }

        private int CheckListaProdottiNegozio(int indexProdotto)
        {
            int value = 0;
            for (int i = 0; i < Globals.listProdottiNegozio.Count; i++)
            {
                //if (Globals.listProdottiNegozio.ElementAt(i) == Globals.listProdottiNegozio.ElementAt(indexProdotto))
                if(Globals.listProdottiNegozio[i].venduto == false)
                    value++;
            }

            return value;
        }

        private void Inizializza_Scaffali()
        {
            row_iniz[0] = false;
            row_iniz[1] = false;
            row_iniz[2] = false;
            row_iniz[3] = false;

            
            switch(Globals.Livello)
            {
                case 1:

                    for (int row = 0; row < 4; row++) //-----
                    {
                        if(row == Globals.indice_scarpe)
                            row_index[row] = 4*Globals.indice_scarpe;
		        else
                            row_index[row] = 4*row;

                        Inizializza_Scaffale(row+1);
                    } //-----
// MessageBox.Show("indice_scarpe => row_index[0-3]  " + Globals.indice_scarpe + " => " +  row_index[0] + ' ' +  row_index[1] + ' ' +  row_index[2] + ' ' +  row_index[3] );  // DEBUG
                    break;

                case 2:

                    break;

                case 3:

                    break;

                case 4:

                    break;

                case 5:

                    break;

                case 6:
                    ///MESSO PER PROVARE IL LIVELLO
                    for (int row = 0; row < 4; row++) //-----
                    {
                        if (row == Globals.indice_scarpe)
                            row_index[row] = 4 * Globals.indice_scarpe;
                        else
                            row_index[row] = 4 * row;

                        Inizializza_Scaffale(row + 1);
                    } //-----
                      // MessageBox.Show("indice_scarpe => row_index[0-3]  " + Globals.indice_scarpe + " => " +  row_index[0] + ' ' +  row_index[1] + ' ' +  row_index[2] + ' ' +  row_index[3] );  // DEBUG
                    break;
            }
        }

        private void Inizializza_Scaffale(int n)
        {
            switch(n)
            {
                case 1:

                    Prodotti_tipo1 = CheckListaProdottiNegozio(row_index[0]);
                    // Prima Riga scaffale
                    scaffale1.Image = Globals.listProdottiNegozio.ElementAt(row_index[0]).Immagine;
                    scaffale1.Tag = Globals.listProdottiNegozio.ElementAt(row_index[0]).PrezzoAcquisto.ToString("0.00");
                    scaffale2.Image = Globals.listProdottiNegozio.ElementAt(row_index[0]).Immagine;
                    scaffale2.Tag = Globals.listProdottiNegozio.ElementAt(row_index[0]).PrezzoAcquisto.ToString("0.00");
                    scaffale3.Image = Globals.listProdottiNegozio.ElementAt(row_index[0]).Immagine;
                    scaffale3.Tag = Globals.listProdottiNegozio.ElementAt(row_index[0]).PrezzoAcquisto.ToString("0.00");
                    scaffale4.Image = Globals.listProdottiNegozio.ElementAt(row_index[0]).Immagine;
                    scaffale4.Tag = Globals.listProdottiNegozio.ElementAt(row_index[0]).PrezzoAcquisto.ToString("0.00");
                    scaffale5.Image = Globals.listProdottiNegozio.ElementAt(row_index[0]).Immagine;
                    scaffale5.Tag = Globals.listProdottiNegozio.ElementAt(row_index[0]).PrezzoAcquisto.ToString("0.00");
                    scaffale6.Image = Globals.listProdottiNegozio.ElementAt(row_index[0]).Immagine;
                    scaffale6.Tag = Globals.listProdottiNegozio.ElementAt(row_index[0]).PrezzoAcquisto.ToString("0.00");

                    label1.Text = Globals.listProdottiNegozio.ElementAt(row_index[0]).PrezzoAcquisto.ToString("0.00") + " €";

                    row_iniz[0] = true;

                    break;

                case 2:

                    Prodotti_tipo2 = CheckListaProdottiNegozio(row_index[1]);
                    // Seconda Riga Scffali
                    scaffale7.Image = Globals.listProdottiNegozio.ElementAt(row_index[1]).Immagine;
                    scaffale7.Tag = Globals.listProdottiNegozio.ElementAt(row_index[1]).PrezzoAcquisto.ToString("0.00");
                    scaffale8.Image = Globals.listProdottiNegozio.ElementAt(row_index[1]).Immagine;
                    scaffale8.Tag = Globals.listProdottiNegozio.ElementAt(row_index[1]).PrezzoAcquisto.ToString("0.00");
                    scaffale9.Image = Globals.listProdottiNegozio.ElementAt(row_index[1]).Immagine;
                    scaffale9.Tag = Globals.listProdottiNegozio.ElementAt(row_index[1]).PrezzoAcquisto.ToString("0.00");
                    scaffale10.Image = Globals.listProdottiNegozio.ElementAt(row_index[1]).Immagine;
                    scaffale10.Tag = Globals.listProdottiNegozio.ElementAt(row_index[1]).PrezzoAcquisto.ToString("0.00");
                    scaffale11.Image = Globals.listProdottiNegozio.ElementAt(row_index[1]).Immagine;
                    scaffale11.Tag = Globals.listProdottiNegozio.ElementAt(row_index[1]).PrezzoAcquisto.ToString("0.00");
                    scaffale12.Image = Globals.listProdottiNegozio.ElementAt(row_index[1]).Immagine;
                    scaffale12.Tag = Globals.listProdottiNegozio.ElementAt(row_index[1]).PrezzoAcquisto.ToString("0.00");

                    label2.Text = Globals.listProdottiNegozio.ElementAt(row_index[1]).PrezzoAcquisto.ToString("0.00") + " €";

                    row_iniz[1] = true;

                    break;

                case 3:

                    Prodotti_tipo3 = CheckListaProdottiNegozio(row_index[2]);
                    // Terza Riga Scaffali
                    scaffale13.Image = Globals.listProdottiNegozio.ElementAt(row_index[2]).Immagine;
                    scaffale13.Tag = Globals.listProdottiNegozio.ElementAt(row_index[2]).PrezzoAcquisto.ToString("0.00");
                    scaffale14.Image = Globals.listProdottiNegozio.ElementAt(row_index[2]).Immagine;
                    scaffale14.Tag = Globals.listProdottiNegozio.ElementAt(row_index[2]).PrezzoAcquisto.ToString("0.00");
                    scaffale15.Image = Globals.listProdottiNegozio.ElementAt(row_index[2]).Immagine;
                    scaffale15.Tag = Globals.listProdottiNegozio.ElementAt(row_index[2]).PrezzoAcquisto.ToString("0.00");
                    scaffale16.Image = Globals.listProdottiNegozio.ElementAt(row_index[2]).Immagine;
                    scaffale16.Tag = Globals.listProdottiNegozio.ElementAt(row_index[2]).PrezzoAcquisto.ToString("0.00");
                    scaffale17.Image = Globals.listProdottiNegozio.ElementAt(row_index[2]).Immagine;
                    scaffale17.Tag = Globals.listProdottiNegozio.ElementAt(row_index[2]).PrezzoAcquisto.ToString("0.00");
                    scaffale18.Image = Globals.listProdottiNegozio.ElementAt(row_index[2]).Immagine;
                    scaffale18.Tag = Globals.listProdottiNegozio.ElementAt(row_index[2]).PrezzoAcquisto.ToString("0.00");

                    label3.Text = Globals.listProdottiNegozio.ElementAt(row_index[2]).PrezzoAcquisto.ToString("0.00") + " €";

                    row_iniz[2] = true;
                        
                    break;

                default:

                    Prodotti_tipo4 = CheckListaProdottiNegozio(row_index[3]);
                    // Quarta Riga Scaffali
                    scaffale19.Image = Globals.listProdottiNegozio.ElementAt(row_index[3]).Immagine;
                    scaffale19.Tag = Globals.listProdottiNegozio.ElementAt(row_index[3]).PrezzoAcquisto.ToString("0.00");
                    scaffale20.Image = Globals.listProdottiNegozio.ElementAt(row_index[3]).Immagine;
                    scaffale20.Tag = Globals.listProdottiNegozio.ElementAt(row_index[3]).PrezzoAcquisto.ToString("0.00");
                    scaffale21.Image = Globals.listProdottiNegozio.ElementAt(row_index[3]).Immagine;
                    scaffale21.Tag = Globals.listProdottiNegozio.ElementAt(row_index[3]).PrezzoAcquisto.ToString("0.00");
                    scaffale22.Image = Globals.listProdottiNegozio.ElementAt(row_index[3]).Immagine;
                    scaffale22.Tag = Globals.listProdottiNegozio.ElementAt(row_index[3]).PrezzoAcquisto.ToString("0.00");
                    scaffale23.Image = Globals.listProdottiNegozio.ElementAt(row_index[3]).Immagine;
                    scaffale23.Tag = Globals.listProdottiNegozio.ElementAt(row_index[3]).PrezzoAcquisto.ToString("0.00");
                    scaffale24.Image = Globals.listProdottiNegozio.ElementAt(row_index[3]).Immagine;
                    scaffale24.Tag = Globals.listProdottiNegozio.ElementAt(row_index[3]).PrezzoAcquisto.ToString("0.00");

                    label4.Text = Globals.listProdottiNegozio.ElementAt(row_index[3]).PrezzoAcquisto.ToString("0.00") + " €";

                    row_iniz[3] = true;

                    break;
            }


            if (label1.Text == "label1")

                label1.Text = "";

            if (label2.Text == "label2")

                label2.Text = "";

            if (label3.Text == "label3")

                label3.Text = "";

            if (label4.Text == "label4")

                label4.Text = "";
        }

        private void Inizializza_Scaffali_Vuoti()
        {
	    if(!row_iniz[0])
            {
                scaffale1.Tag = Globals.listProdottiNegozio.ElementAt(0).PrezzoAcquisto.ToString("0.00");
                scaffale2.Tag = Globals.listProdottiNegozio.ElementAt(0).PrezzoAcquisto.ToString("0.00");
                scaffale3.Tag = Globals.listProdottiNegozio.ElementAt(0).PrezzoAcquisto.ToString("0.00");
                scaffale4.Tag = Globals.listProdottiNegozio.ElementAt(0).PrezzoAcquisto.ToString("0.00");
                scaffale5.Tag = Globals.listProdottiNegozio.ElementAt(0).PrezzoAcquisto.ToString("0.00");
                scaffale6.Tag = Globals.listProdottiNegozio.ElementAt(0).PrezzoAcquisto.ToString("0.00");
            }

            if (!row_iniz[1])
            {
                scaffale7.Tag = Globals.listProdottiNegozio.ElementAt(4).PrezzoAcquisto.ToString("0.00");
                scaffale8.Tag = Globals.listProdottiNegozio.ElementAt(4).PrezzoAcquisto.ToString("0.00");
                scaffale9.Tag = Globals.listProdottiNegozio.ElementAt(4).PrezzoAcquisto.ToString("0.00");
                scaffale10.Tag = Globals.listProdottiNegozio.ElementAt(4).PrezzoAcquisto.ToString("0.00");
                scaffale11.Tag = Globals.listProdottiNegozio.ElementAt(4).PrezzoAcquisto.ToString("0.00");
                scaffale12.Tag = Globals.listProdottiNegozio.ElementAt(4).PrezzoAcquisto.ToString("0.00");
            }

            if (!row_iniz[2])
            {
                scaffale13.Tag = Globals.listProdottiNegozio.ElementAt(8).PrezzoAcquisto.ToString("0.00");
                scaffale14.Tag = Globals.listProdottiNegozio.ElementAt(8).PrezzoAcquisto.ToString("0.00");
                scaffale15.Tag = Globals.listProdottiNegozio.ElementAt(8).PrezzoAcquisto.ToString("0.00");
                scaffale16.Tag = Globals.listProdottiNegozio.ElementAt(8).PrezzoAcquisto.ToString("0.00");
                scaffale17.Tag = Globals.listProdottiNegozio.ElementAt(8).PrezzoAcquisto.ToString("0.00");
                scaffale18.Tag = Globals.listProdottiNegozio.ElementAt(8).PrezzoAcquisto.ToString("0.00");
            }

            if (!row_iniz[3])
            {
                scaffale19.Tag = Globals.listProdottiNegozio.ElementAt(12).PrezzoAcquisto.ToString("0.00");
                scaffale20.Tag = Globals.listProdottiNegozio.ElementAt(12).PrezzoAcquisto.ToString("0.00");
                scaffale21.Tag = Globals.listProdottiNegozio.ElementAt(12).PrezzoAcquisto.ToString("0.00");
                scaffale22.Tag = Globals.listProdottiNegozio.ElementAt(12).PrezzoAcquisto.ToString("0.00");
                scaffale23.Tag = Globals.listProdottiNegozio.ElementAt(12).PrezzoAcquisto.ToString("0.00");
                scaffale24.Tag = Globals.listProdottiNegozio.ElementAt(12).PrezzoAcquisto.ToString("0.00");
            } 
        }

        private int First_Row()
        {
            switch (Globals.scarpe.Nome)
            {
                case "rosa":

                    return 1;

                case "rosse":

                    return 2;

                case "viola":

                    return 3;

                default:

                    return 4;
            }
        }

        private int Second_Row()
        {
            switch (Globals.scarpe.Nome)
            {
                case "rosa":

                    return Globals.global_rnd.Next(2, 5);

                case "rosse":

                    return Globals.global_rnd.Next(3, 5);

                case "viola":

                    return 4;

                default:

                    return 0;
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void Button_Esci_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Adattamento_alla_Risoluzione_Schermo()
        {
            double widthFactor = (double)Screen.PrimaryScreen.Bounds.Width / this.Size.Width; // 800;  
            double heightFactor = (double)Screen.PrimaryScreen.Bounds.Height /this.Size.Height;// 600;

            this.Panel_Portafoglio.Width = (int)(this.Panel_Portafoglio.Width * widthFactor);
            this.Panel_Portafoglio.Height = (int)(this.Panel_Portafoglio.Height * heightFactor);
            //this.Button_Esci.Width = (int)(this.Button_Esci.Width * widthFactor);
            //this.Button_Esci.Height = (int)(this.Button_Esci.Height * heightFactor);
            this.button_Menu.Width = (int)(this.button_Menu.Width * widthFactor);
            this.button_Menu.Height = (int)(this.button_Menu.Height * heightFactor);
            this.button_TornaNegozio.Width = (int)(this.button_TornaNegozio.Width * widthFactor);
            this.button_TornaNegozio.Height = (int)(this.button_TornaNegozio.Height * heightFactor);
            this.calcolatrice.Width = (int)(this.calcolatrice.Width * widthFactor);
            this.calcolatrice.Height = (int)(this.calcolatrice.Height * heightFactor);

            this.Panel_Portafoglio.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            //this.Button_Esci.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.button_Menu.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.button_TornaNegozio.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.calcolatrice.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);

            this.Panel_Portafoglio.Location = new Point((int)(this.Panel_Portafoglio.Location.X * widthFactor), (int)(this.Panel_Portafoglio.Location.Y * heightFactor));
            //this.Button_Esci.Location = new Point((int)(this.Button_Esci.Location.X * widthFactor), (int)(this.Button_Esci.Location.Y * heightFactor));
            this.button_Menu.Location = new Point((int)(this.button_Menu.Location.X * widthFactor), (int)(this.button_Menu.Location.Y * heightFactor));
            this.button_TornaNegozio.Location = new Point((int)(this.button_TornaNegozio.Location.X * widthFactor), (int)(this.button_TornaNegozio.Location.Y * heightFactor));
            this.calcolatrice.Location = new Point((int)(this.calcolatrice.Location.X * widthFactor), (int)(this.calcolatrice.Location.Y * heightFactor));

            
            this.Label_50e.Width = (int)(this.Label_50e.Width * widthFactor);
            this.Label_50e.Height = (int)(this.Label_50e.Height * heightFactor);
            this.Label_20e.Width = (int)(this.Label_20e.Width * widthFactor);
            this.Label_20e.Height = (int)(this.Label_20e.Height * heightFactor);
            this.Label_10e.Width = (int)(this.Label_10e.Width * widthFactor);
            this.Label_10e.Height = (int)(this.Label_10e.Height * heightFactor);
            this.Label_5e.Width = (int)(this.Label_5e.Width * widthFactor);
            this.Label_5e.Height = (int)(this.Label_5e.Height * heightFactor);
            this.Label_2e.Width = (int)(this.Label_2e.Width * widthFactor);
            this.Label_2e.Height = (int)(this.Label_2e.Height * heightFactor);
            this.Label_1e.Width = (int)(this.Label_1e.Width * widthFactor);
            this.Label_1e.Height = (int)(this.Label_1e.Height * heightFactor);
            this.Label_50ec.Width = (int)(this.Label_50ec.Width * widthFactor);
            this.Label_50ec.Height = (int)(this.Label_50ec.Height * heightFactor);
            this.Label_20ec.Width = (int)(this.Label_20ec.Width * widthFactor);
            this.Label_20ec.Height = (int)(this.Label_20ec.Height * heightFactor);
            this.Label_10ec.Width = (int)(this.Label_10ec.Width * widthFactor);
            this.Label_10ec.Height = (int)(this.Label_10ec.Height * heightFactor);
            this.Label_5ec.Width = (int)(this.Label_5ec.Width * widthFactor);
            this.Label_5ec.Height = (int)(this.Label_5ec.Height * heightFactor);
            this.Label_2ec.Width = (int)(this.Label_2ec.Width * widthFactor);
            this.Label_2ec.Height = (int)(this.Label_2ec.Height * heightFactor);
            this.Label_1ec.Width = (int)(this.Label_1ec.Width * widthFactor);
            this.Label_1ec.Height = (int)(this.Label_1ec.Height * heightFactor);

            this.Label_50e.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.Label_20e.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.Label_10e.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.Label_5e.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.Label_2e.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.Label_1e.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.Label_50ec.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.Label_20ec.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.Label_10ec.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.Label_5ec.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.Label_2ec.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.Label_1ec.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);


            this.Label_50e.Location = new Point((int)(this.Label_50e.Location.X * widthFactor), (int)(this.Label_50e.Location.Y * heightFactor));
            this.Label_20e.Location = new Point((int)(this.Label_20e.Location.X * widthFactor), (int)(this.Label_20e.Location.Y * heightFactor));
            this.Label_10e.Location = new Point((int)(this.Label_10e.Location.X * widthFactor), (int)(this.Label_10e.Location.Y * heightFactor));
            this.Label_5e.Location = new Point((int)(this.Label_5e.Location.X * widthFactor), (int)(this.Label_5e.Location.Y * heightFactor));
            this.Label_2e.Location = new Point((int)(this.Label_2e.Location.X * widthFactor), (int)(this.Label_2e.Location.Y * heightFactor));
            this.Label_1e.Location = new Point((int)(this.Label_1e.Location.X * widthFactor), (int)(this.Label_1e.Location.Y * heightFactor));
            this.Label_50ec.Location = new Point((int)(this.Label_50ec.Location.X * widthFactor), (int)(this.Label_50ec.Location.Y * heightFactor));
            this.Label_20ec.Location = new Point((int)(this.Label_20ec.Location.X * widthFactor), (int)(this.Label_20ec.Location.Y * heightFactor));
            this.Label_10ec.Location = new Point((int)(this.Label_10ec.Location.X * widthFactor), (int)(this.Label_10ec.Location.Y * heightFactor));
            this.Label_5ec.Location = new Point((int)(this.Label_5ec.Location.X * widthFactor), (int)(this.Label_5ec.Location.Y * heightFactor));
            this.Label_2ec.Location = new Point((int)(this.Label_2ec.Location.X * widthFactor), (int)(this.Label_2ec.Location.Y * heightFactor));
            this.Label_1ec.Location = new Point((int)(this.Label_1ec.Location.X * widthFactor), (int)(this.Label_1ec.Location.Y * heightFactor));
            



            this.PictureBox_50e.Width = (int)(this.PictureBox_50e.Width * widthFactor);
            this.PictureBox_50e.Height = (int)(this.PictureBox_50e.Height * heightFactor);
            this.PictureBox_20e.Width = (int)(this.PictureBox_20e.Width * widthFactor);
            this.PictureBox_20e.Height = (int)(this.PictureBox_20e.Height * heightFactor);
            this.PictureBox_10e.Width = (int)(this.PictureBox_10e.Width * widthFactor);
            this.PictureBox_10e.Height = (int)(this.PictureBox_10e.Height * heightFactor);
            this.PictureBox_5e.Width = (int)(this.PictureBox_5e.Width * widthFactor);
            this.PictureBox_5e.Height = (int)(this.PictureBox_5e.Height * heightFactor);
            this.PictureBox_2e.Width = (int)(this.PictureBox_2e.Width * widthFactor);
            this.PictureBox_2e.Height = (int)(this.PictureBox_2e.Height * heightFactor);
            this.PictureBox_1e.Width = (int)(this.PictureBox_1e.Width * widthFactor);
            this.PictureBox_1e.Height = (int)(this.PictureBox_1e.Height * heightFactor);
            this.PictureBox_50ec.Width = (int)(this.PictureBox_50ec.Width * widthFactor);
            this.PictureBox_50ec.Height = (int)(this.PictureBox_50ec.Height * heightFactor);
            this.PictureBox_20ec.Width = (int)(this.PictureBox_20ec.Width * widthFactor);
            this.PictureBox_20ec.Height = (int)(this.PictureBox_20ec.Height * heightFactor);
            this.PictureBox_10ec.Width = (int)(this.PictureBox_10ec.Width * widthFactor);
            this.PictureBox_10ec.Height = (int)(this.PictureBox_10ec.Height * heightFactor);
            this.PictureBox_5ec.Width = (int)(this.PictureBox_5ec.Width * widthFactor);
            this.PictureBox_5ec.Height = (int)(this.PictureBox_5ec.Height * heightFactor);
            this.PictureBox_2ec.Width = (int)(this.PictureBox_2ec.Width * widthFactor);
            this.PictureBox_2ec.Height = (int)(this.PictureBox_2ec.Height * heightFactor);
            this.PictureBox_1ec.Width = (int)(this.PictureBox_1ec.Width * widthFactor);
            this.PictureBox_1ec.Height = (int)(this.PictureBox_1ec.Height * heightFactor);

            this.PictureBox_50e.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.PictureBox_20e.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.PictureBox_10e.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.PictureBox_5e.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.PictureBox_2e.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.PictureBox_1e.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.PictureBox_50ec.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.PictureBox_20ec.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.PictureBox_10ec.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.PictureBox_5ec.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.PictureBox_2ec.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.PictureBox_1ec.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            

            this.PictureBox_50e.Location = new Point((int)(this.PictureBox_50e.Location.X * widthFactor), (int)(this.PictureBox_50e.Location.Y * heightFactor));
            this.PictureBox_20e.Location = new Point((int)(this.PictureBox_20e.Location.X * widthFactor), (int)(this.PictureBox_20e.Location.Y * heightFactor));
            this.PictureBox_10e.Location = new Point((int)(this.PictureBox_10e.Location.X * widthFactor), (int)(this.PictureBox_10e.Location.Y * heightFactor));
            this.PictureBox_5e.Location = new Point((int)(this.PictureBox_5e.Location.X * widthFactor), (int)(this.PictureBox_5e.Location.Y * heightFactor));
            this.PictureBox_2e.Location = new Point((int)(this.PictureBox_2e.Location.X * widthFactor), (int)(this.PictureBox_2e.Location.Y * heightFactor));
            this.PictureBox_1e.Location = new Point((int)(this.PictureBox_1e.Location.X * widthFactor), (int)(this.PictureBox_1e.Location.Y * heightFactor));
            this.PictureBox_50ec.Location = new Point((int)(this.PictureBox_50ec.Location.X * widthFactor), (int)(this.PictureBox_50ec.Location.Y * heightFactor));
            this.PictureBox_20ec.Location = new Point((int)(this.PictureBox_20ec.Location.X * widthFactor), (int)(this.PictureBox_20ec.Location.Y * heightFactor));
            this.PictureBox_10ec.Location = new Point((int)(this.PictureBox_10ec.Location.X * widthFactor), (int)(this.PictureBox_10ec.Location.Y * heightFactor));
            this.PictureBox_5ec.Location = new Point((int)(this.PictureBox_5ec.Location.X * widthFactor), (int)(this.PictureBox_5ec.Location.Y * heightFactor));
            this.PictureBox_2ec.Location = new Point((int)(this.PictureBox_2ec.Location.X * widthFactor), (int)(this.PictureBox_2ec.Location.Y * heightFactor));
            this.PictureBox_1ec.Location = new Point((int)(this.PictureBox_1ec.Location.X * widthFactor), (int)(this.PictureBox_1ec.Location.Y * heightFactor));
            



            this.Txt_Box_Portafoglio.Width = (int)(this.Txt_Box_Portafoglio.Width * widthFactor);
            this.Txt_Box_Portafoglio.Height = (int)(this.Txt_Box_Portafoglio.Height * heightFactor);
            this.Txt_Box_Scaffale.Width = (int)(this.Txt_Box_Scaffale.Width * widthFactor);
            this.Txt_Box_Scaffale.Height = (int)(this.Txt_Box_Scaffale.Height * heightFactor);
            this.Text_Box_Soldi_Pagati.Width = (int)(this.Text_Box_Soldi_Pagati.Width * widthFactor);
            this.Text_Box_Soldi_Pagati.Height = (int)(this.Text_Box_Soldi_Pagati.Height * heightFactor);

            this.Txt_Box_Portafoglio.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 9F, FontStyle.Bold);
            this.Txt_Box_Scaffale.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 12F, FontStyle.Bold);
            this.Text_Box_Soldi_Pagati.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
           
          

            this.Txt_Box_Portafoglio.Location = new Point((int)(this.Txt_Box_Portafoglio.Location.X * widthFactor), (int)(this.Txt_Box_Portafoglio.Location.Y * heightFactor));
            this.Txt_Box_Scaffale.Location = new Point((int)(this.Txt_Box_Scaffale.Location.X * widthFactor), (int)(this.Txt_Box_Scaffale.Location.Y * heightFactor));
            this.Text_Box_Soldi_Pagati.Location = new Point((int)(this.Text_Box_Soldi_Pagati.Location.X * widthFactor), (int)(this.Text_Box_Soldi_Pagati.Location.Y * heightFactor));
            


            this.panel1.Width = (int)(this.panel1.Width * widthFactor);
            this.panel1.Height = (int)(this.panel1.Height * heightFactor);
            this.panel2.Width = (int)(this.panel2.Width * widthFactor);
            this.panel2.Height = (int)(this.panel2.Height * heightFactor);
            this.panel3.Width = (int)(this.panel3.Width * widthFactor);
            this.panel3.Height = (int)(this.panel3.Height * heightFactor);
            this.panel4.Width = (int)(this.panel4.Width * widthFactor);
            this.panel4.Height = (int)(this.panel4.Height * heightFactor);
            this.panel5.Width = (int)(this.panel5.Width * widthFactor);
            this.panel5.Height = (int)(this.panel5.Height * heightFactor);
            this.panel6.Width = (int)(this.panel6.Width * widthFactor);
            this.panel6.Height = (int)(this.panel6.Height * heightFactor);

            this.panel1.Location = new Point((int)(this.panel1.Location.X * widthFactor), (int)(this.panel1.Location.Y * heightFactor));
            this.panel2.Location = new Point((int)(this.panel2.Location.X * widthFactor), (int)(this.panel2.Location.Y * heightFactor));
            this.panel3.Location = new Point((int)(this.panel3.Location.X * widthFactor), (int)(this.panel3.Location.Y * heightFactor));
            this.panel4.Location = new Point((int)(this.panel4.Location.X * widthFactor), (int)(this.panel4.Location.Y * heightFactor));
            this.panel5.Location = new Point((int)(this.panel5.Location.X * widthFactor), (int)(this.panel5.Location.Y * heightFactor));
            this.panel6.Location = new Point((int)(this.panel6.Location.X * widthFactor), (int)(this.panel6.Location.Y * heightFactor));

            this.scaffale1.Width = (int)(this.scaffale1.Width * widthFactor);
            this.scaffale1.Height = (int)(this.scaffale1.Height * heightFactor);
            this.scaffale2.Width = (int)(this.scaffale2.Width * widthFactor);
            this.scaffale2.Height = (int)(this.scaffale2.Height * heightFactor);
            this.scaffale3.Width = (int)(this.scaffale3.Width * widthFactor);
            this.scaffale3.Height = (int)(this.scaffale3.Height * heightFactor);
            this.scaffale4.Width = (int)(this.scaffale4.Width * widthFactor);
            this.scaffale4.Height = (int)(this.scaffale4.Height * heightFactor);
            this.scaffale5.Width = (int)(this.scaffale5.Width * widthFactor);
            this.scaffale5.Height = (int)(this.scaffale5.Height * heightFactor);
            this.scaffale6.Width = (int)(this.scaffale6.Width * widthFactor);
            this.scaffale6.Height = (int)(this.scaffale6.Height * heightFactor);
            this.scaffale7.Width = (int)(this.scaffale7.Width * widthFactor);
            this.scaffale7.Height = (int)(this.scaffale7.Height * heightFactor);
            this.scaffale8.Width = (int)(this.scaffale8.Width * widthFactor);
            this.scaffale8.Height = (int)(this.scaffale8.Height * heightFactor);
            this.scaffale9.Width = (int)(this.scaffale9.Width * widthFactor);
            this.scaffale9.Height = (int)(this.scaffale9.Height * heightFactor);
            this.scaffale10.Width = (int)(this.scaffale10.Width * widthFactor);
            this.scaffale10.Height = (int)(this.scaffale10.Height * heightFactor);
            this.scaffale11.Width = (int)(this.scaffale11.Width * widthFactor);
            this.scaffale11.Height = (int)(this.scaffale11.Height * heightFactor);
            this.scaffale12.Width = (int)(this.scaffale12.Width * widthFactor);
            this.scaffale12.Height = (int)(this.scaffale12.Height * heightFactor);
            this.scaffale13.Width = (int)(this.scaffale13.Width * widthFactor);
            this.scaffale13.Height = (int)(this.scaffale13.Height * heightFactor);
            this.scaffale14.Width = (int)(this.scaffale14.Width * widthFactor);
            this.scaffale14.Height = (int)(this.scaffale14.Height * heightFactor);
            this.scaffale15.Width = (int)(this.scaffale15.Width * widthFactor);
            this.scaffale15.Height = (int)(this.scaffale15.Height * heightFactor);
            this.scaffale16.Width = (int)(this.scaffale16.Width * widthFactor);
            this.scaffale16.Height = (int)(this.scaffale16.Height * heightFactor);
            this.scaffale17.Width = (int)(this.scaffale17.Width * widthFactor);
            this.scaffale17.Height = (int)(this.scaffale17.Height * heightFactor);
            this.scaffale18.Width = (int)(this.scaffale18.Width * widthFactor);
            this.scaffale18.Height = (int)(this.scaffale18.Height * heightFactor);
            this.scaffale19.Width = (int)(this.scaffale19.Width * widthFactor);
            this.scaffale19.Height = (int)(this.scaffale19.Height * heightFactor);
            this.scaffale20.Width = (int)(this.scaffale20.Width * widthFactor);
            this.scaffale20.Height = (int)(this.scaffale20.Height * heightFactor);
            this.scaffale21.Width = (int)(this.scaffale21.Width * widthFactor);
            this.scaffale21.Height = (int)(this.scaffale21.Height * heightFactor);
            this.scaffale22.Width = (int)(this.scaffale22.Width * widthFactor);
            this.scaffale22.Height = (int)(this.scaffale22.Height * heightFactor);
            this.scaffale23.Width = (int)(this.scaffale23.Width * widthFactor);
            this.scaffale23.Height = (int)(this.scaffale23.Height * heightFactor);
            this.scaffale24.Width = (int)(this.scaffale24.Width * widthFactor);
            this.scaffale24.Height = (int)(this.scaffale24.Height * heightFactor);

            this.scaffale1.Location = new Point((int)(this.scaffale1.Location.X * widthFactor), (int)(this.scaffale1.Location.Y * heightFactor));
            this.scaffale2.Location = new Point((int)(this.scaffale2.Location.X * widthFactor), (int)(this.scaffale2.Location.Y * heightFactor));
            this.scaffale3.Location = new Point((int)(this.scaffale3.Location.X * widthFactor), (int)(this.scaffale3.Location.Y * heightFactor));
            this.scaffale4.Location = new Point((int)(this.scaffale4.Location.X * widthFactor), (int)(this.scaffale4.Location.Y * heightFactor));
            this.scaffale5.Location = new Point((int)(this.scaffale5.Location.X * widthFactor), (int)(this.scaffale5.Location.Y * heightFactor));
            this.scaffale6.Location = new Point((int)(this.scaffale6.Location.X * widthFactor), (int)(this.scaffale6.Location.Y * heightFactor));
            this.scaffale7.Location = new Point((int)(this.scaffale7.Location.X * widthFactor), (int)(this.scaffale7.Location.Y * heightFactor));
            this.scaffale8.Location = new Point((int)(this.scaffale8.Location.X * widthFactor), (int)(this.scaffale8.Location.Y * heightFactor));
            this.scaffale9.Location = new Point((int)(this.scaffale9.Location.X * widthFactor), (int)(this.scaffale9.Location.Y * heightFactor));
            this.scaffale10.Location = new Point((int)(this.scaffale10.Location.X * widthFactor), (int)(this.scaffale10.Location.Y * heightFactor));
            this.scaffale11.Location = new Point((int)(this.scaffale11.Location.X * widthFactor), (int)(this.scaffale11.Location.Y * heightFactor));
            this.scaffale12.Location = new Point((int)(this.scaffale12.Location.X * widthFactor), (int)(this.scaffale12.Location.Y * heightFactor));
            this.scaffale13.Location = new Point((int)(this.scaffale13.Location.X * widthFactor), (int)(this.scaffale13.Location.Y * heightFactor));
            this.scaffale14.Location = new Point((int)(this.scaffale14.Location.X * widthFactor), (int)(this.scaffale14.Location.Y * heightFactor));
            this.scaffale15.Location = new Point((int)(this.scaffale15.Location.X * widthFactor), (int)(this.scaffale15.Location.Y * heightFactor));
            this.scaffale16.Location = new Point((int)(this.scaffale16.Location.X * widthFactor), (int)(this.scaffale16.Location.Y * heightFactor));
            this.scaffale17.Location = new Point((int)(this.scaffale17.Location.X * widthFactor), (int)(this.scaffale17.Location.Y * heightFactor));
            this.scaffale18.Location = new Point((int)(this.scaffale18.Location.X * widthFactor), (int)(this.scaffale18.Location.Y * heightFactor));
            this.scaffale19.Location = new Point((int)(this.scaffale19.Location.X * widthFactor), (int)(this.scaffale19.Location.Y * heightFactor));
            this.scaffale20.Location = new Point((int)(this.scaffale20.Location.X * widthFactor), (int)(this.scaffale20.Location.Y * heightFactor));
            this.scaffale21.Location = new Point((int)(this.scaffale21.Location.X * widthFactor), (int)(this.scaffale21.Location.Y * heightFactor));
            this.scaffale22.Location = new Point((int)(this.scaffale22.Location.X * widthFactor), (int)(this.scaffale22.Location.Y * heightFactor));
            this.scaffale23.Location = new Point((int)(this.scaffale23.Location.X * widthFactor), (int)(this.scaffale23.Location.Y * heightFactor));
            this.scaffale24.Location = new Point((int)(this.scaffale24.Location.X * widthFactor), (int)(this.scaffale24.Location.Y * heightFactor));
            



            this.label1.Width = (int)(this.label1.Width * widthFactor);
            this.label1.Height = (int)(this.label1.Height * heightFactor);
            this.label2.Width = (int)(this.label2.Width * widthFactor);
            this.label2.Height = (int)(this.label2.Height * heightFactor);
            this.label3.Width = (int)(this.label3.Width * widthFactor);
            this.label3.Height = (int)(this.label3.Height * heightFactor);
            this.label4.Width = (int)(this.label4.Width * widthFactor);
            this.label4.Height = (int)(this.label4.Height * heightFactor);
            this.label5.Width = (int)(this.label5.Width * widthFactor);
            this.label5.Height = (int)(this.label5.Height * heightFactor);
           
            this.label22.Width = (int)(this.label22.Width * widthFactor);
            this.label22.Height = (int)(this.label22.Height * heightFactor);
            this.label23.Width = (int)(this.label23.Width * widthFactor);
            this.label23.Height = (int)(this.label23.Height * heightFactor);
            this.label24.Width = (int)(this.label24.Width * widthFactor);
            this.label24.Height = (int)(this.label24.Height * heightFactor);
            this.label25.Width = (int)(this.label25.Width * widthFactor);
            this.label25.Height = (int)(this.label25.Height * heightFactor);
            this.label26.Width = (int)(this.label26.Width * widthFactor);
            this.label26.Height = (int)(this.label26.Height * heightFactor);
            this.label27.Width = (int)(this.label27.Width * widthFactor);
            this.label27.Height = (int)(this.label27.Height * heightFactor);
            this.label28.Width = (int)(this.label28.Width * widthFactor);
            this.label28.Height = (int)(this.label28.Height * heightFactor);
            this.label29.Width = (int)(this.label29.Width * widthFactor);
            this.label29.Height = (int)(this.label29.Height * heightFactor);
            this.label30.Width = (int)(this.label30.Width * widthFactor);
            this.label30.Height = (int)(this.label30.Height * heightFactor);
            this.label31.Width = (int)(this.label31.Width * widthFactor);
            this.label31.Height = (int)(this.label31.Height * heightFactor);
            this.label32.Width = (int)(this.label32.Width * widthFactor);
            this.label32.Height = (int)(this.label32.Height * heightFactor);
            this.label33.Width = (int)(this.label33.Width * widthFactor);
            this.label33.Height = (int)(this.label33.Height * heightFactor);
            this.label34.Width = (int)(this.label34.Width * widthFactor);
            this.label34.Height = (int)(this.label34.Height * heightFactor);
            this.label35.Width = (int)(this.label35.Width * widthFactor);
            this.label35.Height = (int)(this.label35.Height * heightFactor);
            this.label36.Width = (int)(this.label36.Width * widthFactor);
            this.label36.Height = (int)(this.label36.Height * heightFactor);
            this.label37.Width = (int)(this.label37.Width * widthFactor);
            this.label37.Height = (int)(this.label37.Height * heightFactor);

            this.label1.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 8F, FontStyle.Bold);
            this.label2.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 8F, FontStyle.Bold);
            this.label3.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 8F, FontStyle.Bold);
            this.label4.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 8F, FontStyle.Bold);
            this.label5.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 8F, FontStyle.Bold);

            this.label22.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 6F, FontStyle.Bold);
            this.label23.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 6F, FontStyle.Bold);
            this.label24.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 6F, FontStyle.Bold);
            this.label25.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 6F, FontStyle.Bold);
            this.label26.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 6F, FontStyle.Bold);
            this.label27.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 6F, FontStyle.Bold);
            this.label28.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 6F, FontStyle.Bold);
            this.label29.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 6F, FontStyle.Bold);
            this.label30.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 6F, FontStyle.Bold);
            this.label31.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 6F, FontStyle.Bold);
            this.label32.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 6F, FontStyle.Bold);
            this.label33.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 6F, FontStyle.Bold);
            this.label34.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 6F, FontStyle.Bold);
            this.label35.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 6F, FontStyle.Bold);
            this.label36.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 6F, FontStyle.Bold);
            this.label37.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 6F, FontStyle.Bold);
            

            this.label1.Location = new Point((int)(this.label1.Location.X * widthFactor), (int)(this.label1.Location.Y * heightFactor));
            this.label2.Location = new Point((int)(this.label2.Location.X * widthFactor), (int)(this.label2.Location.Y * heightFactor));
            this.label3.Location = new Point((int)(this.label3.Location.X * widthFactor), (int)(this.label3.Location.Y * heightFactor));
            this.label4.Location = new Point((int)(this.label4.Location.X * widthFactor), (int)(this.label4.Location.Y * heightFactor));
            this.label5.Location = new Point((int)(this.label5.Location.X * widthFactor), (int)(this.label5.Location.Y * heightFactor));
          
            this.label22.Location = new Point((int)(this.label22.Location.X * widthFactor), (int)(this.label22.Location.Y * heightFactor));
            this.label23.Location = new Point((int)(this.label23.Location.X * widthFactor), (int)(this.label23.Location.Y * heightFactor));
            this.label24.Location = new Point((int)(this.label24.Location.X * widthFactor), (int)(this.label24.Location.Y * heightFactor));
            this.label25.Location = new Point((int)(this.label25.Location.X * widthFactor), (int)(this.label25.Location.Y * heightFactor));
            this.label26.Location = new Point((int)(this.label26.Location.X * widthFactor), (int)(this.label26.Location.Y * heightFactor));
            this.label27.Location = new Point((int)(this.label27.Location.X * widthFactor), (int)(this.label27.Location.Y * heightFactor));
            this.label28.Location = new Point((int)(this.label28.Location.X * widthFactor), (int)(this.label28.Location.Y * heightFactor));
            this.label29.Location = new Point((int)(this.label29.Location.X * widthFactor), (int)(this.label29.Location.Y * heightFactor));
            this.label30.Location = new Point((int)(this.label30.Location.X * widthFactor), (int)(this.label30.Location.Y * heightFactor));
            this.label31.Location = new Point((int)(this.label31.Location.X * widthFactor), (int)(this.label31.Location.Y * heightFactor));
            this.label32.Location = new Point((int)(this.label32.Location.X * widthFactor), (int)(this.label32.Location.Y * heightFactor));
            this.label33.Location = new Point((int)(this.label33.Location.X * widthFactor), (int)(this.label33.Location.Y * heightFactor));
            this.label34.Location = new Point((int)(this.label34.Location.X * widthFactor), (int)(this.label34.Location.Y * heightFactor));
            this.label35.Location = new Point((int)(this.label35.Location.X * widthFactor), (int)(this.label35.Location.Y * heightFactor));
            this.label36.Location = new Point((int)(this.label36.Location.X * widthFactor), (int)(this.label36.Location.Y * heightFactor));
            this.label37.Location = new Point((int)(this.label37.Location.X * widthFactor), (int)(this.label37.Location.Y * heightFactor));
            



            this.panelCamion.Width = (int)(this.panelCamion.Width * widthFactor);
            this.panelCamion.Height = (int)(this.panelCamion.Height * heightFactor);
            this.pictureBoxCamion.Width = (int)(this.pictureBoxCamion.Width * widthFactor);
            this.pictureBoxCamion.Height = (int)(this.pictureBoxCamion.Height * heightFactor);
            this.pictureBox1.Width = (int)(this.pictureBox1.Width * widthFactor);
            this.pictureBox1.Height = (int)(this.pictureBox1.Height * heightFactor);
            this.textInfo.Width = (int)(this.textInfo.Width * widthFactor);
            this.textInfo.Height = (int)(this.textInfo.Height * heightFactor);
            this.importoCompratore.Width = (int)(this.importoCompratore.Width * widthFactor);
            this.importoCompratore.Height = (int)(this.importoCompratore.Height * widthFactor);
            this.SimboloEuro.Width = (int)(this.SimboloEuro.Width * widthFactor);
            this.SimboloEuro.Height = (int)(this.SimboloEuro.Height * widthFactor);


            this.panelCamion.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.pictureBoxCamion.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.pictureBox1.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.textInfo.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 10F, FontStyle.Bold);
            this.importoCompratore.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.SimboloEuro.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 15F, FontStyle.Bold);

            this.panelCamion.Location = new Point((int)(this.panelCamion.Location.X * widthFactor), (int)(this.panelCamion.Location.Y * heightFactor));
            this.pictureBoxCamion.Location = new Point((int)(this.pictureBoxCamion.Location.X * widthFactor), (int)(this.pictureBoxCamion.Location.Y * heightFactor));
            this.pictureBox1.Location = new Point((int)(this.pictureBox1.Location.X * widthFactor), (int)(this.pictureBox1.Location.Y * heightFactor));
            this.textInfo.Location = new Point((int)(this.textInfo.Location.X * widthFactor), (int)(this.textInfo.Location.Y * heightFactor));
            this.importoCompratore.Location = new Point((int)(this.importoCompratore.Location.X * widthFactor), (int)(this.importoCompratore.Location.Y * heightFactor));
            this.SimboloEuro.Location = new Point((int)(this.SimboloEuro.Location.X * widthFactor), (int)(this.SimboloEuro.Location.Y * heightFactor));
 

            this.panelCompratore.Width = (int)(this.panelCompratore.Width * widthFactor);
            this.panelCompratore.Height = (int)(this.panelCompratore.Height * heightFactor);
            this.panelControlloCompratore.Width = (int)(this.panelControlloCompratore.Width * widthFactor);
            this.panelControlloCompratore.Height = (int)(this.panelControlloCompratore.Height * heightFactor);
            this.okCompratore.Width = (int)(this.okCompratore.Width * widthFactor);
            this.okCompratore.Height = (int)(this.okCompratore.Height * heightFactor);

            this.panelCompratore.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.panelControlloCompratore.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.okCompratore.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);

            this.panelCompratore.Location = new Point((int)(this.panelCompratore.Location.X * widthFactor), (int)(this.panelCompratore.Location.Y * heightFactor));
            this.panelControlloCompratore.Location = new Point((int)(this.panelControlloCompratore.Location.X * widthFactor), (int)(this.panelControlloCompratore.Location.Y * heightFactor));
            this.okCompratore.Location = new Point((int)(this.okCompratore.Location.X * widthFactor), (int)(this.okCompratore.Location.Y * heightFactor));
            




            this.banconotefabbrica1.Width = (int)(this.banconotefabbrica1.Width * widthFactor);
            this.banconotefabbrica1.Height = (int)(this.banconotefabbrica1.Height * heightFactor);
            this.banconotefabbrica2.Width = (int)(this.banconotefabbrica2.Width * widthFactor);
            this.banconotefabbrica2.Height = (int)(this.banconotefabbrica2.Height * heightFactor);
            this.banconotefabbrica3.Width = (int)(this.banconotefabbrica3.Width * widthFactor);
            this.banconotefabbrica3.Height = (int)(this.banconotefabbrica3.Height * heightFactor);
            this.banconotefabbrica4.Width = (int)(this.banconotefabbrica4.Width * widthFactor);
            this.banconotefabbrica4.Height = (int)(this.banconotefabbrica4.Height * heightFactor);
            this.banconotefabbrica5.Width = (int)(this.banconotefabbrica5.Width * widthFactor);
            this.banconotefabbrica5.Height = (int)(this.banconotefabbrica5.Height * heightFactor);
            this.banconotefabbrica6.Width = (int)(this.banconotefabbrica6.Width * widthFactor);
            this.banconotefabbrica6.Height = (int)(this.banconotefabbrica6.Height * heightFactor);
            this.banconotefabbrica7.Width = (int)(this.banconotefabbrica7.Width * widthFactor);
            this.banconotefabbrica7.Height = (int)(this.banconotefabbrica7.Height * heightFactor);
            this.banconotefabbrica8.Width = (int)(this.banconotefabbrica8.Width * widthFactor);
            this.banconotefabbrica8.Height = (int)(this.banconotefabbrica8.Height * heightFactor);

            this.banconotefabbrica1.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.banconotefabbrica2.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.banconotefabbrica3.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.banconotefabbrica4.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.banconotefabbrica5.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.banconotefabbrica6.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.banconotefabbrica7.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.banconotefabbrica8.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);

            this.banconotefabbrica1.Location = new Point((int)(this.banconotefabbrica1.Location.X * widthFactor), (int)(this.banconotefabbrica1.Location.Y * heightFactor));
            this.banconotefabbrica2.Location = new Point((int)(this.banconotefabbrica2.Location.X * widthFactor), (int)(this.banconotefabbrica2.Location.Y * heightFactor));
            this.banconotefabbrica3.Location = new Point((int)(this.banconotefabbrica3.Location.X * widthFactor), (int)(this.banconotefabbrica3.Location.Y * heightFactor));
            this.banconotefabbrica4.Location = new Point((int)(this.banconotefabbrica4.Location.X * widthFactor), (int)(this.banconotefabbrica4.Location.Y * heightFactor));
            this.banconotefabbrica5.Location = new Point((int)(this.banconotefabbrica5.Location.X * widthFactor), (int)(this.banconotefabbrica5.Location.Y * heightFactor));
            this.banconotefabbrica6.Location = new Point((int)(this.banconotefabbrica6.Location.X * widthFactor), (int)(this.banconotefabbrica6.Location.Y * heightFactor));
            this.banconotefabbrica7.Location = new Point((int)(this.banconotefabbrica7.Location.X * widthFactor), (int)(this.banconotefabbrica7.Location.Y * heightFactor));
            this.banconotefabbrica8.Location = new Point((int)(this.banconotefabbrica8.Location.X * widthFactor), (int)(this.banconotefabbrica8.Location.Y * heightFactor));



            this.monetefabbrica1.Width = (int)(this.monetefabbrica1.Width * widthFactor);
            this.monetefabbrica1.Height = (int)(this.monetefabbrica1.Height * heightFactor);
            this.monetefabbrica2.Width = (int)(this.monetefabbrica2.Width * widthFactor);
            this.monetefabbrica2.Height = (int)(this.monetefabbrica2.Height * heightFactor);
            this.monetefabbrica3.Width = (int)(this.monetefabbrica3.Width * widthFactor);
            this.monetefabbrica3.Height = (int)(this.monetefabbrica3.Height * heightFactor);
            this.monetefabbrica4.Width = (int)(this.monetefabbrica4.Width * widthFactor);
            this.monetefabbrica4.Height = (int)(this.monetefabbrica4.Height * heightFactor);
            this.monetefabbrica5.Width = (int)(this.monetefabbrica5.Width * widthFactor);
            this.monetefabbrica5.Height = (int)(this.monetefabbrica5.Height * heightFactor);
            this.monetefabbrica6.Width = (int)(this.monetefabbrica6.Width * widthFactor);
            this.monetefabbrica6.Height = (int)(this.monetefabbrica6.Height * heightFactor);
            this.monetefabbrica7.Width = (int)(this.monetefabbrica7.Width * widthFactor);
            this.monetefabbrica7.Height = (int)(this.monetefabbrica7.Height * heightFactor);
            this.monetefabbrica8.Width = (int)(this.monetefabbrica8.Width * widthFactor);
            this.monetefabbrica8.Height = (int)(this.monetefabbrica8.Height * heightFactor);
            this.monetefabbrica9.Width = (int)(this.monetefabbrica9.Width * widthFactor);
            this.monetefabbrica9.Height = (int)(this.monetefabbrica9.Height * heightFactor);
            this.monetefabbrica10.Width = (int)(this.monetefabbrica10.Width * widthFactor);
            this.monetefabbrica10.Height = (int)(this.monetefabbrica10.Height * heightFactor);

            this.monetefabbrica1.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.monetefabbrica2.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.monetefabbrica3.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.monetefabbrica4.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.monetefabbrica5.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.monetefabbrica6.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.monetefabbrica7.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.monetefabbrica8.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.monetefabbrica9.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.monetefabbrica10.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
        

            this.monetefabbrica1.Location = new Point((int)(this.monetefabbrica1.Location.X * widthFactor), (int)(this.monetefabbrica1.Location.Y * heightFactor));
            this.monetefabbrica2.Location = new Point((int)(this.monetefabbrica2.Location.X * widthFactor), (int)(this.monetefabbrica2.Location.Y * heightFactor));
            this.monetefabbrica3.Location = new Point((int)(this.monetefabbrica3.Location.X * widthFactor), (int)(this.monetefabbrica3.Location.Y * heightFactor));
            this.monetefabbrica4.Location = new Point((int)(this.monetefabbrica4.Location.X * widthFactor), (int)(this.monetefabbrica4.Location.Y * heightFactor));
            this.monetefabbrica5.Location = new Point((int)(this.monetefabbrica5.Location.X * widthFactor), (int)(this.monetefabbrica5.Location.Y * heightFactor));
            this.monetefabbrica6.Location = new Point((int)(this.monetefabbrica6.Location.X * widthFactor), (int)(this.monetefabbrica6.Location.Y * heightFactor));
            this.monetefabbrica7.Location = new Point((int)(this.monetefabbrica7.Location.X * widthFactor), (int)(this.monetefabbrica7.Location.Y * heightFactor));
            this.monetefabbrica8.Location = new Point((int)(this.monetefabbrica8.Location.X * widthFactor), (int)(this.monetefabbrica8.Location.Y * heightFactor));
            this.monetefabbrica9.Location = new Point((int)(this.monetefabbrica9.Location.X * widthFactor), (int)(this.monetefabbrica9.Location.Y * heightFactor));
            this.monetefabbrica10.Location = new Point((int)(this.monetefabbrica10.Location.X * widthFactor), (int)(this.monetefabbrica10.Location.Y * heightFactor));

         
            this.smile.Width = (int)(this.smile.Width * widthFactor);
            this.smile.Height = (int)(this.smile.Height * heightFactor);
            this.smile.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.smile.Location = new Point((int)(this.smile.Location.X * widthFactor), (int)(this.smile.Location.Y * heightFactor));

        }

        // // // // Picture Box Banconote Mouse Down function // // // //
        private void PictureBox_50e_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox_50e.DoDragDrop(PictureBox_50e.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            PictureBox_50e.Cursor = System.Windows.Forms.Cursors.Hand;
        }          
        private void PictureBox_20e_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox_20e.DoDragDrop(PictureBox_20e.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            PictureBox_20e.Cursor = System.Windows.Forms.Cursors.Hand;
           
        }
        private void PictureBox_10e_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox_10e.DoDragDrop(PictureBox_10e.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            PictureBox_10e.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void PictureBox_5e_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox_5e.DoDragDrop(PictureBox_5e.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            PictureBox_5e.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void PictureBox_2e_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox_2e.DoDragDrop(PictureBox_2e.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            PictureBox_2e.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void PictureBox_1e_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox_1e.DoDragDrop(PictureBox_1e.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            PictureBox_1e.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void PictureBox_50ec_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox_50ec.DoDragDrop(PictureBox_50ec.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            PictureBox_50ec.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void PictureBox_20ec_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox_20ec.DoDragDrop(PictureBox_20ec.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            PictureBox_20ec.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void PictureBox_10ec_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox_10ec.DoDragDrop(PictureBox_10ec.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            PictureBox_10ec.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void PictureBox_5ec_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox_5ec.DoDragDrop(PictureBox_5ec.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            PictureBox_5ec.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void PictureBox_2ec_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox_2ec.DoDragDrop(PictureBox_2ec.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            PictureBox_2ec.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void PictureBox_1ec_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox_1ec.DoDragDrop(PictureBox_1ec.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            PictureBox_1ec.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        // // // // ************************************************************** // // // //

        // ************************************* picture box panel venditore mouse down ************************* //
        private void banconotefabbrica1_MouseDown(object sender, MouseEventArgs e)
        {
            imm_da_rimuovere = 1;
            banconotefabbrica1.DoDragDrop(banconotefabbrica1.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            banconotefabbrica1.Cursor = System.Windows.Forms.Cursors.Hand;
           
        }
        private void banconotefabbrica2_MouseDown(object sender, MouseEventArgs e)
        {
            imm_da_rimuovere = 2;
            banconotefabbrica2.DoDragDrop(banconotefabbrica2.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            banconotefabbrica2.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void banconotefabbrica3_MouseDown(object sender, MouseEventArgs e)
        {
            imm_da_rimuovere = 3;
            banconotefabbrica3.DoDragDrop(banconotefabbrica3.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            banconotefabbrica3.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void banconotefabbrica4_MouseDown(object sender, MouseEventArgs e)
        {
            imm_da_rimuovere = 4;
            banconotefabbrica4.DoDragDrop(banconotefabbrica4.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            banconotefabbrica4.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void banconotefabbrica5_MouseDown(object sender, MouseEventArgs e)
        {
            imm_da_rimuovere = 5;
            banconotefabbrica5.DoDragDrop(banconotefabbrica5.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            banconotefabbrica5.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void banconotefabbrica6_MouseDown(object sender, MouseEventArgs e)
        {
            imm_da_rimuovere = 6;
            banconotefabbrica6.DoDragDrop(banconotefabbrica6.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            banconotefabbrica6.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void banconotefabbrica7_MouseDown(object sender, MouseEventArgs e)
        {
            imm_da_rimuovere = 7;
            banconotefabbrica7.DoDragDrop(banconotefabbrica7.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            banconotefabbrica7.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void banconotefabbrica8_MouseDown(object sender, MouseEventArgs e)
        {
            imm_da_rimuovere = 8;
            banconotefabbrica8.DoDragDrop(banconotefabbrica8.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            banconotefabbrica8.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void monetefabbrica1_MouseDown(object sender, MouseEventArgs e)
        {
            imm_da_rimuovere = 9;
            monetefabbrica1.DoDragDrop(monetefabbrica1.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            monetefabbrica1.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void monetefabbrica2_MouseDown(object sender, MouseEventArgs e)
        {
            imm_da_rimuovere = 10;
            monetefabbrica2.DoDragDrop(monetefabbrica2.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            monetefabbrica2.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void monetefabbrica3_MouseDown(object sender, MouseEventArgs e)
        {
            imm_da_rimuovere = 11;
            monetefabbrica3.DoDragDrop(monetefabbrica3.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            monetefabbrica3.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void monetefabbrica4_MouseDown(object sender, MouseEventArgs e)
        {
            imm_da_rimuovere = 12;
            monetefabbrica4.DoDragDrop(monetefabbrica4.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            monetefabbrica4.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void monetefabbrica5_MouseDown(object sender, MouseEventArgs e)
        {
            imm_da_rimuovere = 13;
            monetefabbrica5.DoDragDrop(monetefabbrica5.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            monetefabbrica5.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void monetefabbrica6_MouseDown(object sender, MouseEventArgs e)
        {
            imm_da_rimuovere = 14;
            monetefabbrica6.DoDragDrop(monetefabbrica6.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            monetefabbrica6.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void monetefabbrica7_MouseDown(object sender, MouseEventArgs e)
        {
            imm_da_rimuovere = 15;
            monetefabbrica7.DoDragDrop(monetefabbrica7.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            monetefabbrica7.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void monetefabbrica8_MouseDown(object sender, MouseEventArgs e)
        {
            imm_da_rimuovere = 16;
            monetefabbrica8.DoDragDrop(monetefabbrica8.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            monetefabbrica8.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void monetefabbrica9_MouseDown(object sender, MouseEventArgs e)
        {
            imm_da_rimuovere = 17;
            monetefabbrica9.DoDragDrop(monetefabbrica9.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            monetefabbrica9.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void monetefabbrica10_MouseDown(object sender, MouseEventArgs e)
        {
            imm_da_rimuovere = 18;
            monetefabbrica10.DoDragDrop(monetefabbrica10.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            monetefabbrica10.Cursor = System.Windows.Forms.Cursors.Hand;
        }





        // ******************** Picture Box Prodotti Mouse Down Function ********************** //

        private void scaffale1_MouseDown(object sender, MouseEventArgs e)
        {
            scaffale1.DoDragDrop(scaffale1.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            scaffale1.Cursor = System.Windows.Forms.Cursors.Hand;
            
        }
        private void scaffale2_MouseDown(object sender, MouseEventArgs e)
        {
            scaffale2.DoDragDrop(scaffale2.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            scaffale2.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void scaffale3_MouseDown(object sender, MouseEventArgs e)
        {
            scaffale3.DoDragDrop(scaffale3.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            scaffale3.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void scaffale4_MouseDown(object sender, MouseEventArgs e)
        {
            scaffale4.DoDragDrop(scaffale4.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            scaffale4.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void scaffale5_MouseDown(object sender, MouseEventArgs e)
        {
            scaffale5.DoDragDrop(scaffale5.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            scaffale5.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void scaffale6_MouseDown(object sender, MouseEventArgs e)
        {
            scaffale6.DoDragDrop(scaffale6.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            scaffale6.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void scaffale7_MouseDown(object sender, MouseEventArgs e)
        {
            scaffale7.DoDragDrop(scaffale7.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            scaffale7.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void scaffale8_MouseDown(object sender, MouseEventArgs e)
        {
            scaffale8.DoDragDrop(scaffale8.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            scaffale8.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void scaffale9_MouseDown(object sender, MouseEventArgs e)
        {
            scaffale9.DoDragDrop(scaffale9.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            scaffale9.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void scaffale10_MouseDown(object sender, MouseEventArgs e)
        {
            scaffale10.DoDragDrop(scaffale10.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            scaffale10.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void scaffale11_MouseDown(object sender, MouseEventArgs e)
        {
            scaffale11.DoDragDrop(scaffale11.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            scaffale11.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void scaffale12_MouseDown(object sender, MouseEventArgs e)
        {
            scaffale12.DoDragDrop(scaffale12.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            scaffale12.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void scaffale13_MouseDown(object sender, MouseEventArgs e)
        {
            scaffale13.DoDragDrop(scaffale13.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            scaffale13.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void scaffale14_MouseDown(object sender, MouseEventArgs e)
        {
            scaffale14.DoDragDrop(scaffale14.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            scaffale14.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void scaffale15_MouseDown(object sender, MouseEventArgs e)
        {
            scaffale15.DoDragDrop(scaffale15.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            scaffale15.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void scaffale16_MouseDown(object sender, MouseEventArgs e)
        {
            scaffale16.DoDragDrop(scaffale16.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            scaffale16.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void scaffale17_MouseDown(object sender, MouseEventArgs e)
        {
            scaffale17.DoDragDrop(scaffale17.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            scaffale17.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void scaffale18_MouseDown(object sender, MouseEventArgs e)
        {
            scaffale18.DoDragDrop(scaffale18.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            scaffale18.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void scaffale19_MouseDown(object sender, MouseEventArgs e)
        {
            scaffale19.DoDragDrop(scaffale19.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            scaffale19.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void scaffale20_MouseDown(object sender, MouseEventArgs e)
        {
            scaffale20.DoDragDrop(scaffale20.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            scaffale20.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void scaffale21_MouseDown(object sender, MouseEventArgs e)
        {
            scaffale21.DoDragDrop(scaffale21.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            scaffale21.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void scaffale22_MouseDown(object sender, MouseEventArgs e)
        {
            scaffale22.DoDragDrop(scaffale22.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            scaffale22.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void scaffale23_MouseDown(object sender, MouseEventArgs e)
        {
            scaffale23.DoDragDrop(scaffale23.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            scaffale23.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void scaffale24_MouseDown(object sender, MouseEventArgs e)
        {
            scaffale24.DoDragDrop(scaffale24.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            scaffale24.Cursor = System.Windows.Forms.Cursors.Hand;

        }
       
        // **********************************************************************************************************//

        
        
        
        // ******************** Label Camion Mouse Down *******************************************************************//

        private void label22_MouseDown(object sender, MouseEventArgs e)
        {
            label22.DoDragDrop(label22.Text, DragDropEffects.Copy | DragDropEffects.Move);
            label22.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void label23_MouseDown(object sender, MouseEventArgs e)
        {
            label23.DoDragDrop(label23.Text, DragDropEffects.Copy | DragDropEffects.Move);
            label23.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void label24_MouseDown(object sender, MouseEventArgs e)
        {
            label24.DoDragDrop(label24.Text, DragDropEffects.Copy | DragDropEffects.Move);
            label24.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void label25_MouseDown(object sender, MouseEventArgs e)
        {
            label25.DoDragDrop(label25.Text, DragDropEffects.Copy | DragDropEffects.Move);
            label25.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void label26_MouseDown(object sender, MouseEventArgs e)
        {
            label26.DoDragDrop(label26.Text, DragDropEffects.Copy | DragDropEffects.Move);
            label26.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void label27_MouseDown(object sender, MouseEventArgs e)
        {
            label27.DoDragDrop(label27.Text, DragDropEffects.Copy | DragDropEffects.Move);
            label27.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void label28_MouseDown(object sender, MouseEventArgs e)
        {
            label28.DoDragDrop(label28.Text, DragDropEffects.Copy | DragDropEffects.Move);
            label28.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void label29_MouseDown(object sender, MouseEventArgs e)
        {
            label29.DoDragDrop(label29.Text, DragDropEffects.Copy | DragDropEffects.Move);
            label29.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void label30_MouseDown(object sender, MouseEventArgs e)
        {
            label30.DoDragDrop(label30.Text, DragDropEffects.Copy | DragDropEffects.Move);
            label30.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void label31_MouseDown(object sender, MouseEventArgs e)
        {
            label31.DoDragDrop(label31.Text, DragDropEffects.Copy | DragDropEffects.Move);
            label31.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void label32_MouseDown(object sender, MouseEventArgs e)
        {
            label32.DoDragDrop(label32.Text, DragDropEffects.Copy | DragDropEffects.Move);
            label32.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void label33_MouseDown(object sender, MouseEventArgs e)
        {
            label33.DoDragDrop(label33.Text, DragDropEffects.Copy | DragDropEffects.Move);
            label33.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void label34_MouseDown(object sender, MouseEventArgs e)
        {
            label34.DoDragDrop(label34.Text, DragDropEffects.Copy | DragDropEffects.Move);
            label34.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void label35_MouseDown(object sender, MouseEventArgs e)
        {
            label35.DoDragDrop(label35.Text, DragDropEffects.Copy | DragDropEffects.Move);
            label35.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void label36_MouseDown(object sender, MouseEventArgs e)
        {
            label36.DoDragDrop(label36.Text, DragDropEffects.Copy | DragDropEffects.Move);
            label36.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void label37_MouseDown(object sender, MouseEventArgs e)
        {
            label36.DoDragDrop(label36.Text, DragDropEffects.Copy | DragDropEffects.Move);
            label36.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        // *******************************************************************************************************************//


        // // // // Drag and drop soldi // // // // // 
        private void panelCompratore_DragDrop(object sender, DragEventArgs e)
        {
            string testo = e.Data.GetData(DataFormats.Text).ToString();
            double newimporto = Convert.ToDouble(testo);
            soldi_spostati = newimporto + soldi_spostati;
            soldi_spostati = Math.Round(soldi_spostati, 2);

            // Controllo Tipo Di Banconote
            if(newimporto == 50.00)
            {
                int param = 0;
                slot_liberi_banconote = ricerca_slot_liberi_banconote();
                Aggiorna_Soldi_Pagati_Banconote(slot_liberi_banconote, newimporto, param);


            }
            if (newimporto == 20.00 )
            {
                int param = 1;
                slot_liberi_banconote = ricerca_slot_liberi_banconote();
                Aggiorna_Soldi_Pagati_Banconote(slot_liberi_banconote, newimporto,param);
 
            }
            if (newimporto == 10.00)
            {
                int param = 2;
                slot_liberi_banconote = ricerca_slot_liberi_banconote();
                Aggiorna_Soldi_Pagati_Banconote(slot_liberi_banconote, newimporto, param);

            }
            if (newimporto == 5.00)
            {
                int param = 3;
                slot_liberi_banconote = ricerca_slot_liberi_banconote(); 
                Aggiorna_Soldi_Pagati_Banconote(slot_liberi_banconote, newimporto, param);

            }
            if (newimporto == 2.00)
            {
                int param = 4;
                slot_liberi_monete = ricerca_slot_liberi_monete();
                Aggiorna_Soldi_Pagati_Monete(slot_liberi_monete, newimporto, param);

            }
            if (newimporto == 1.00)
            {
                int param = 5;
                slot_liberi_monete = ricerca_slot_liberi_monete();
                Aggiorna_Soldi_Pagati_Monete(slot_liberi_monete, newimporto, param);

            }
            if (newimporto == 0.50)
            {
                int param = 6;
                slot_liberi_monete = ricerca_slot_liberi_monete();
                Aggiorna_Soldi_Pagati_Monete(slot_liberi_monete, newimporto, param);

            }
            if (newimporto == 0.20)
            {
                int param = 7;
                slot_liberi_monete = ricerca_slot_liberi_monete();
                Aggiorna_Soldi_Pagati_Monete(slot_liberi_monete, newimporto, param);

            }
            if (newimporto == 0.10)
            {
                int param = 8;
                slot_liberi_monete = ricerca_slot_liberi_monete();
                Aggiorna_Soldi_Pagati_Monete(slot_liberi_monete, newimporto, param);

            }
            if (newimporto == 0.05)
            {
                int param = 9;
                slot_liberi_monete = ricerca_slot_liberi_monete();
                Aggiorna_Soldi_Pagati_Monete(slot_liberi_monete, newimporto, param);

            }
            if (newimporto == 0.02)
            {
                int param = 10;
                slot_liberi_monete = ricerca_slot_liberi_monete();
                Aggiorna_Soldi_Pagati_Monete(slot_liberi_monete, newimporto, param);

            }
            if (newimporto == 0.01)
            {
                int param = 11;
                slot_liberi_monete = ricerca_slot_liberi_monete();
                Aggiorna_Soldi_Pagati_Monete(slot_liberi_monete, newimporto, param);

            }
         
        }
        private void panelCompratore_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        // ****************************************************************************************************//



        // **********************************   Panel portafoglio drag e drop **************************** //
        private void Panel_Portafoglio_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
           
            
        }
        private void Panel_Portafoglio_DragDrop(object sender, DragEventArgs e)
        {
            
            string testo = e.Data.GetData(DataFormats.Text).ToString();
            double newimporto = Convert.ToDouble(testo);
            soldi_spostati -= newimporto;
            soldi_spostati = Math.Round(soldi_spostati, 2);


            if (newimporto == 50.00)
            {
                int param = 0;
                Globals.portafogli[param]++;
                Inizializza_Portafoglio();
                immagine_da_rimuovere(imm_da_rimuovere);
            }
            if (newimporto == 20.00)
            {
                int param = 1;
                Globals.portafogli[param]++;
                Inizializza_Portafoglio();
                immagine_da_rimuovere(imm_da_rimuovere);

            }
            if (newimporto == 10.00)
            {
                int param = 2;
                Globals.portafogli[param]++;
                Inizializza_Portafoglio();
                immagine_da_rimuovere(imm_da_rimuovere);

            }
            if (newimporto == 5.00)
            {
                int param = 3;
                Globals.portafogli[param]++;
                Inizializza_Portafoglio();
                immagine_da_rimuovere(imm_da_rimuovere);

            }
            if (newimporto == 2.00)
            {
                int param = 4;
                Globals.portafogli[param]++;
                Inizializza_Portafoglio();
                immagine_da_rimuovere(imm_da_rimuovere);

            }
            if (newimporto == 1.00)
            {
                int param = 5;
                Globals.portafogli[param]++;
                Inizializza_Portafoglio();
                immagine_da_rimuovere(imm_da_rimuovere);

            }
            if (newimporto == 0.50)
            {
                int param = 6;
                Globals.portafogli[param]++;
                Inizializza_Portafoglio();
                immagine_da_rimuovere(imm_da_rimuovere);

            }
            if (newimporto == 0.20)
            {
                int param = 7;
                Globals.portafogli[param]++;
                Inizializza_Portafoglio();
                immagine_da_rimuovere(imm_da_rimuovere);

            }
            if (newimporto == 0.10)
            {
                int param = 8;
                Globals.portafogli[param]++;
                Inizializza_Portafoglio();
                immagine_da_rimuovere(imm_da_rimuovere);
            }
            if (newimporto == 0.05)
            {
                int param = 9;
                Globals.portafogli[param]++;
                Inizializza_Portafoglio();
                immagine_da_rimuovere(imm_da_rimuovere);

            }
            if (newimporto == 0.02)
            {
                int param = 10;
                Globals.portafogli[param]++;
                Inizializza_Portafoglio();
                immagine_da_rimuovere(imm_da_rimuovere);

            }
            if (newimporto == 0.01)
            {
                int param = 11;
                Globals.portafogli[param]++;
                Inizializza_Portafoglio();
                immagine_da_rimuovere(imm_da_rimuovere);

            }
        }

        // ****************************************************************************************************//

        private void Aggiorna_Soldi_Pagati_Banconote(int slot_liberi,double importo,int a)
        {
            switch (slot_liberi)
            {
                case 1:
                    banconotefabbrica1.Image = assegnaImmagini(importo);
                    banconotefabbrica1.Tag = importo.ToString();
                    Globals.portafogli[a]--;
                    Globals.pFase2[a]--;
                    Inizializza_Portafoglio();
                    break;

                case 2:
                    banconotefabbrica2.Image = assegnaImmagini(importo);
                    banconotefabbrica2.Tag = importo.ToString();
                    Globals.portafogli[a]--;
                    Inizializza_Portafoglio();
                    break;

                case 3:
                    banconotefabbrica3.Image = assegnaImmagini(importo);
                    banconotefabbrica3.Tag = importo.ToString();
                    Globals.portafogli[a]--;
                    Inizializza_Portafoglio();
                    break;
                case 4:
                    banconotefabbrica4.Image = assegnaImmagini(importo);
                    banconotefabbrica4.Tag = importo.ToString();
                    Globals.portafogli[a]--;
                    Inizializza_Portafoglio();
                    break;
                case 5:
                    banconotefabbrica5.Image = assegnaImmagini(importo);
                    banconotefabbrica5.Tag = importo.ToString();
                    Globals.portafogli[a]--;
                    Inizializza_Portafoglio();
                    break;
                case 6:
                    banconotefabbrica6.Image = assegnaImmagini(importo);
                    banconotefabbrica6.Tag = importo.ToString();
                    Globals.portafogli[a]--;
                    Inizializza_Portafoglio();
                    break;
                case 7:
                    banconotefabbrica7.Image = assegnaImmagini(importo);
                    banconotefabbrica7.Tag = importo.ToString();
                    Globals.portafogli[a]--;
                    Inizializza_Portafoglio();
                    break;
                case 8:
                    banconotefabbrica8.Image = assegnaImmagini(importo);
                    banconotefabbrica8.Tag = importo.ToString();
                    Globals.portafogli[a]--;
                    Inizializza_Portafoglio();
                    break;
                case 9:
                   
                    break;

            }
            
        }
        private void Aggiorna_Soldi_Pagati_Monete(int slot_liberi, double importo, int a)
        {
            switch (slot_liberi)
            {
                case 1:
                    monetefabbrica1.Image = assegnaImmagini(importo);
                    monetefabbrica1.Tag = importo.ToString();
                    Globals.portafogli[a]--;
                    Inizializza_Portafoglio();
                    break;

                case 2:
                    monetefabbrica2.Image = assegnaImmagini(importo);
                    monetefabbrica2.Tag = importo.ToString();
                    Globals.portafogli[a]--;
                    Inizializza_Portafoglio();
                    break;

                case 3:
                    monetefabbrica3.Image = assegnaImmagini(importo);
                    monetefabbrica3.Tag = importo.ToString();
                    Globals.portafogli[a]--;
                    Inizializza_Portafoglio();
                    break;
                case 4:
                    monetefabbrica4.Image = assegnaImmagini(importo);
                    monetefabbrica4.Tag = importo.ToString();
                    Globals.portafogli[a]--;
                    Inizializza_Portafoglio();
                    break;
                case 5:
                    monetefabbrica5.Image = assegnaImmagini(importo);
                    monetefabbrica5.Tag = importo.ToString();
                    Globals.portafogli[a]--;
                    Inizializza_Portafoglio();
                    break;
                case 6:
                    monetefabbrica6.Image = assegnaImmagini(importo);
                    monetefabbrica6.Tag = importo.ToString();
                    Globals.portafogli[a]--;
                    Inizializza_Portafoglio();
                    break;
                case 7:
                    monetefabbrica7.Image = assegnaImmagini(importo);
                    monetefabbrica7.Tag = importo.ToString();
                    Globals.portafogli[a]--;
                    Inizializza_Portafoglio();
                    break;
                case 8:
                    monetefabbrica8.Image = assegnaImmagini(importo);
                    monetefabbrica8.Tag = importo.ToString();
                    Globals.portafogli[a]--;
                    Inizializza_Portafoglio();
                    break;
                case 9:
                    monetefabbrica9.Image = assegnaImmagini(importo);;
                    monetefabbrica9.Tag = importo.ToString();
                    Globals.portafogli[a]--;
                    Inizializza_Portafoglio();
                    break;
                case 10:
                    monetefabbrica10.Image = assegnaImmagini(importo);
                    monetefabbrica10.Tag = importo.ToString();
                    Globals.portafogli[a]--;
                    Inizializza_Portafoglio();
                    break;
                case 11:

                    break;
            }
               
        }

        // ******************************************************************************************* //

        
        // Assegnazione imaagine a seconda dell'importo letto
        private Image assegnaImmagini(double importo)
        {
            if (importo == 50.00)
                return global::Negozio_di_Viola.Properties.Resources._50euro;
            else if (importo == 20.00)
                return global::Negozio_di_Viola.Properties.Resources._20euro;
            else if (importo == 10.00)
                return global::Negozio_di_Viola.Properties.Resources._10euro;
            else if (importo == 5.00)
                return global::Negozio_di_Viola.Properties.Resources._5euro;
            else if (importo == 2.00)
                return global::Negozio_di_Viola.Properties.Resources._2euro;
            else if (importo == 1.00)
                return global::Negozio_di_Viola.Properties.Resources._1euro;
            else if (importo == 0.50)
                return global::Negozio_di_Viola.Properties.Resources._50cent;
            else if (importo == 0.20)
                return global::Negozio_di_Viola.Properties.Resources._20cent;
            else if (importo == 0.10)
                return global::Negozio_di_Viola.Properties.Resources._10cent;
            else if (importo == 0.05)
                return global::Negozio_di_Viola.Properties.Resources._5cent;
            else if (importo == 0.02)
                return global::Negozio_di_Viola.Properties.Resources._2cent;
            else if (importo == 0.01)
                return global::Negozio_di_Viola.Properties.Resources._1cent;
            else return null;
        }

        // // // // ******************************************************************* // // // // 

        // rimuovi immagine banconote o monete rimesse nel portafoglio

        private void immagine_da_rimuovere(int indice_picture_box)
        {
            if (indice_picture_box == 1)
            {
                banconotefabbrica1.Image = null;
            }
            if (indice_picture_box == 2)
            {
                banconotefabbrica2.Image = null;
            }
            if (indice_picture_box == 3)
            {
                banconotefabbrica3.Image = null;
            }
            if (indice_picture_box == 4)
            {
                banconotefabbrica4.Image = null;
            }
            if (indice_picture_box == 5)
            {
                banconotefabbrica5.Image = null;
            }
            if (indice_picture_box == 6)
            {
                banconotefabbrica6.Image = null;
            }
            if (indice_picture_box == 7)
            {
                banconotefabbrica7.Image = null;
            }
            if (indice_picture_box == 8)
            {
                banconotefabbrica8.Image = null;
            }
            if (indice_picture_box == 9)
            {
                monetefabbrica1.Image = null;
            }
            if (indice_picture_box == 10)
            {
                monetefabbrica2.Image = null;
            }
            if (indice_picture_box == 11)
            {
                monetefabbrica3.Image = null;
            }
            if (indice_picture_box == 12)
            {
                monetefabbrica4.Image = null;
            }
            if (indice_picture_box == 13)
            {
                monetefabbrica5.Image = null;
            }
            if (indice_picture_box == 14)
            {
                monetefabbrica6.Image = null;
            }
            if (indice_picture_box == 15)
            {
                monetefabbrica7.Image = null;
            }
            if (indice_picture_box == 16)
            {
                monetefabbrica8.Image = null;
            }
            if (indice_picture_box == 17)
            {
                monetefabbrica9.Image = null;
            }
            if (indice_picture_box == 18)
            {
                monetefabbrica10.Image = null;
            }



        }

        // ********************************************************************************************** //


        
        // ************* Drag and Drop Prodotti ***************************** //

        private int flagCount()
        {
            int nFlag = 0;
            foreach (Prodotto p in Globals.listProdottiNegozio)
                if (!p.venduto)
                    nFlag++;
            return nFlag;
        }


        private void panelCamion_DragDrop_1(object sender, DragEventArgs e)
        {
            textInfo.Text = null;
            textInfo.Text = "Trascina i soldi dal portafoglio per pagare";

            int tot_numero_prodotti = slot_liberi_camion1 + slot_liberi_camion2 + slot_liberi_camion3 + slot_liberi_camion4 - 4;

            if (e.Data.GetData(DataFormats.Text).ToString() == scaffale1.Tag.ToString())
            {
                if (tot_numero_prodotti < (16 - flagCount()/*Globals.listProdottiNegozio.Count()*/) && Prodotti_tipo1 < 4)
                {

                    switch (slot_liberi_camion1)
                    {
                        case 1:

                            button_Menu.Hide();
                            button_TornaNegozio.Hide();
                            costo_scarpe_selezionate += Convert.ToDouble(e.Data.GetData(DataFormats.Text).ToString());
                            label22.Tag = e.Data.GetData(DataFormats.Text).ToString();
                            label22.AllowDrop = true;
                            label22.Text = e.Data.GetData(DataFormats.Text).ToString() + " €";
                            label22.AllowDrop = false;
                            slot_liberi_camion1++;
                            Prodotti_tipo1++;
                            scaffale6.Hide();

                            break;

                        case 2:

                            costo_scarpe_selezionate += Convert.ToDouble(e.Data.GetData(DataFormats.Text).ToString());
                            label23.Tag = e.Data.GetData(DataFormats.Text).ToString();
                            label23.AllowDrop = true;
                            label23.Text = e.Data.GetData(DataFormats.Text).ToString() + " €";
                            label23.AllowDrop = false;
                            slot_liberi_camion1++;
                            Prodotti_tipo1++;
                            scaffale5.Hide();

                            break;

                        case 3:

                            costo_scarpe_selezionate += Convert.ToDouble(e.Data.GetData(DataFormats.Text).ToString());
                            label24.Tag = e.Data.GetData(DataFormats.Text).ToString();
                            label24.AllowDrop = true;
                            label24.Text = e.Data.GetData(DataFormats.Text).ToString() + " €";
                            label24.AllowDrop = false;
                            slot_liberi_camion1++;
                            Prodotti_tipo1++;
                            scaffale4.Hide();

                            break;

                        case 4:

                            costo_scarpe_selezionate += Convert.ToDouble(e.Data.GetData(DataFormats.Text).ToString());
                            label25.Tag = e.Data.GetData(DataFormats.Text).ToString();
                            label25.AllowDrop = true;
                            label25.Text = e.Data.GetData(DataFormats.Text).ToString() + " €";
                            label25.AllowDrop = false;
                            slot_liberi_camion1++;
                            Prodotti_tipo1++;
                            scaffale3.Hide();
                            break;
                    }
                }
                else
                {
                    if (tot_numero_prodotti == 16)
                        textInfo.Text = ("Negozio pieno");
                    else
                        textInfo.Text = ("Prodotto non necessario");
                }
            }

            if (e.Data.GetData(DataFormats.Text).ToString() == scaffale7.Tag.ToString())
            {
                if (tot_numero_prodotti < (16 - flagCount()/*Globals.listProdottiNegozio.Count()*/) && Prodotti_tipo2 < 4)
                {
                    switch (slot_liberi_camion2)
                    {
                        case 1:

                            button_Menu.Hide();
                            button_TornaNegozio.Hide();
                            costo_scarpe_selezionate += Convert.ToDouble(e.Data.GetData(DataFormats.Text).ToString());
                            label26.Tag = e.Data.GetData(DataFormats.Text).ToString();
                            label26.AllowDrop = true;
                            label26.Text = e.Data.GetData(DataFormats.Text).ToString() + " €";
                            label26.AllowDrop = false;
                            slot_liberi_camion2++;
                            Prodotti_tipo2++;
                            scaffale12.Hide();

                            break;

                        case 2:

                            costo_scarpe_selezionate += Convert.ToDouble(e.Data.GetData(DataFormats.Text).ToString());
                            label27.Tag = e.Data.GetData(DataFormats.Text).ToString();
                            label27.AllowDrop = true;
                            label27.Text = e.Data.GetData(DataFormats.Text).ToString() + " €";
                            label27.AllowDrop = false;
                            slot_liberi_camion2++;
                            Prodotti_tipo2++;
                            scaffale11.Hide();

                            break;

                        case 3:

                            costo_scarpe_selezionate += Convert.ToDouble(e.Data.GetData(DataFormats.Text).ToString());
                            label28.Tag = e.Data.GetData(DataFormats.Text).ToString();
                            label28.AllowDrop = true;
                            label28.Text = e.Data.GetData(DataFormats.Text).ToString() + " €";
                            label22.AllowDrop = false;
                            slot_liberi_camion2++;
                            Prodotti_tipo2++;
                            scaffale10.Hide();

                            break;

                        case 4:

                            costo_scarpe_selezionate += Convert.ToDouble(e.Data.GetData(DataFormats.Text).ToString());
                            label29.Tag = e.Data.GetData(DataFormats.Text).ToString();
                            label29.AllowDrop = true;
                            label29.Text = e.Data.GetData(DataFormats.Text).ToString() + " €";
                            label29.AllowDrop = false;
                            slot_liberi_camion2++;
                            Prodotti_tipo2++;
                            scaffale9.Hide();

                            break;
                    }
                }
                else
                {
                    if (tot_numero_prodotti == 16)
                        textInfo.Text = ("Negozio pieno");
                    else
                        textInfo.Text = ("Prodotto non necessario");
                }
            }

            if (e.Data.GetData(DataFormats.Text).ToString() == scaffale13.Tag.ToString())
            {
                if (tot_numero_prodotti < (16 - flagCount()/*Globals.listProdottiNegozio.Count()*/) && Prodotti_tipo3 < 4)
                {
                    switch (slot_liberi_camion3)
                    {
                        case 1:

                            button_Menu.Hide();
                            button_TornaNegozio.Hide();
                            costo_scarpe_selezionate += Convert.ToDouble(e.Data.GetData(DataFormats.Text).ToString());
                            label30.Tag = e.Data.GetData(DataFormats.Text).ToString();
                            label30.AllowDrop = true;
                            label30.Text = e.Data.GetData(DataFormats.Text).ToString() + " €";
                            label30.AllowDrop = false;
                            slot_liberi_camion3++;
                            Prodotti_tipo3++;
                            scaffale18.Hide();

                            break;

                        case 2:

                            costo_scarpe_selezionate += Convert.ToDouble(e.Data.GetData(DataFormats.Text).ToString());
                            label31.Tag = e.Data.GetData(DataFormats.Text).ToString();
                            label31.AllowDrop = true;
                            label31.Text = e.Data.GetData(DataFormats.Text).ToString() + " €";
                            label31.AllowDrop = false;
                            slot_liberi_camion3++;
                            Prodotti_tipo3++;
                            scaffale17.Hide();

                            break;

                        case 3:

                            costo_scarpe_selezionate += Convert.ToDouble(e.Data.GetData(DataFormats.Text).ToString());
                            label32.Tag = e.Data.GetData(DataFormats.Text).ToString();
                            label32.AllowDrop = true;
                            label32.Text = e.Data.GetData(DataFormats.Text).ToString() + " €";
                            label32.AllowDrop = false;
                            slot_liberi_camion3++;
                            Prodotti_tipo3++;
                            scaffale16.Hide();

                            break;

                        case 4:

                            costo_scarpe_selezionate += Convert.ToDouble(e.Data.GetData(DataFormats.Text).ToString());
                            label33.Tag = e.Data.GetData(DataFormats.Text).ToString();
                            label33.AllowDrop = true;
                            label33.Text = e.Data.GetData(DataFormats.Text).ToString() + " €";
                            label33.AllowDrop = false;
                            slot_liberi_camion3++;
                            Prodotti_tipo3++;
                            scaffale15.Hide();

                            break;
                    }
                }
                else
                {
                    if (tot_numero_prodotti == 16)
                        textInfo.Text = ("Negozio pieno");
                    else
                        textInfo.Text = ("Prodotto non necessario");
                }
            }
            if (e.Data.GetData(DataFormats.Text).ToString() == scaffale19.Tag.ToString())
            {
                if (tot_numero_prodotti < (16 - flagCount()/*Globals.listProdottiNegozio.Count()*/) && Prodotti_tipo4 < 4)
                {
                    switch (slot_liberi_camion4)
                    {

                        case 1:

                            button_Menu.Hide();
                            button_TornaNegozio.Hide();
                            costo_scarpe_selezionate += Convert.ToDouble(e.Data.GetData(DataFormats.Text).ToString());
                            label34.Tag = e.Data.GetData(DataFormats.Text).ToString();
                            label34.AllowDrop = true;
                            label34.Text = e.Data.GetData(DataFormats.Text).ToString() + " €";
                            label34.AllowDrop = false;
                            slot_liberi_camion4++;
                            Prodotti_tipo4++;
                            scaffale24.Hide();

                            break;

                        case 2:

                            costo_scarpe_selezionate += Convert.ToDouble(e.Data.GetData(DataFormats.Text).ToString());
                            label35.Tag = e.Data.GetData(DataFormats.Text).ToString();
                            label35.AllowDrop = true;
                            label35.Text = e.Data.GetData(DataFormats.Text).ToString() + " €";
                            label35.AllowDrop = false;
                            slot_liberi_camion4++;
                            Prodotti_tipo4++;
                            scaffale23.Hide();

                            break;

                        case 3:

                            costo_scarpe_selezionate += Convert.ToDouble(e.Data.GetData(DataFormats.Text).ToString());
                            label36.Tag = e.Data.GetData(DataFormats.Text).ToString();
                            label36.AllowDrop = true;
                            label36.Text = e.Data.GetData(DataFormats.Text).ToString() + " €";
                            label36.AllowDrop = false;
                            slot_liberi_camion4++;
                            Prodotti_tipo4++;
                            scaffale22.Hide();

                            break;

                        case 4:

                            costo_scarpe_selezionate += Convert.ToDouble(e.Data.GetData(DataFormats.Text).ToString());
                            label37.Tag = e.Data.GetData(DataFormats.Text).ToString();
                            label37.AllowDrop = true;
                            label37.Text = e.Data.GetData(DataFormats.Text).ToString() + " €";
                            label37.AllowDrop = false;
                            slot_liberi_camion4++;
                            Prodotti_tipo4++;
                            scaffale21.Hide();

                            break;
                    }
                }
                else
                {
                    if (tot_numero_prodotti == 16)
                        textInfo.Text = ("Negozio pieno");
                    else
                        textInfo.Text = ("Prodotto non necessario");
                }
            }
            costo_scarpe_selezionate = Math.Round(costo_scarpe_selezionate, 2);
        }


        private void panelCamion_DragOver_1(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;

        }


        // Drag and drop prodotti da camion a scaffali
        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.Text).ToString() == scaffale1.Tag.ToString() + " €")
            {
                switch (slot_liberi_camion1)
                {
                    case 2:                        
                        scaffale6.Show();
                        label22.Text = null;
                        label22.Tag = null;
                        slot_liberi_camion1--;
                        Prodotti_tipo1--;
                        break;
                    case 3:

                        scaffale5.Show();
                        label23.Text = null;
                        label23.Tag = null;
                        slot_liberi_camion1--;
                        Prodotti_tipo1--;
                        break;
                    case 4:

                        scaffale4.Show();
                        label24.Text = null;
                        label24.Tag = null;
                        slot_liberi_camion1--;
                        Prodotti_tipo1--;
                        break;
                    case 5:

                        scaffale3.Show();
                        label25.Text = null;
                        label25.Tag = null;
                        slot_liberi_camion1--;
                        Prodotti_tipo1--;
                        break;
                }
                costo_scarpe_selezionate -= Convert.ToDouble(scaffale1.Tag);
            }
            if (e.Data.GetData(DataFormats.Text).ToString() == scaffale7.Tag.ToString() + " €")
            {
                switch (slot_liberi_camion2)
                {
                    case 2:

                        scaffale12.Show();
                        label26.Text = null;
                        label26.Tag = null;
                        slot_liberi_camion2--;
                        Prodotti_tipo2--;
                        break;
                    case 3:

                        scaffale11.Show();
                        label27.Text = null;
                        label27.Tag = null;
                        slot_liberi_camion2--;
                        Prodotti_tipo2--;
                        break;
                    case 4:

                        scaffale10.Show();
                        label28.Text = null;
                        label28.Tag = null;
                        slot_liberi_camion2--;
                        Prodotti_tipo2--;
                        break;
                    case 5:

                        scaffale9.Show();
                        label29.Text = null;
                        label29.Tag = null;
                        slot_liberi_camion2--;
                        Prodotti_tipo2--;
                        break;
                }
                costo_scarpe_selezionate -= Convert.ToDouble(scaffale7.Tag);
            }
            if (e.Data.GetData(DataFormats.Text).ToString() == scaffale13.Tag.ToString() + " €")
            {
                switch (slot_liberi_camion3)
                {
                    case 2:

                        scaffale18.Show();
                        label30.Text = null;
                        label30.Tag = null;
                        slot_liberi_camion3--;
                        Prodotti_tipo3--;
                        break;
                    case 3:

                        scaffale17.Show();
                        label31.Text = null;
                        label31.Tag = null;
                        slot_liberi_camion3--;
                        Prodotti_tipo3--;
                        break;
                    case 4:

                        scaffale16.Show();
                        label32.Text = null;
                        label32.Tag = null;
                        slot_liberi_camion3--;
                        Prodotti_tipo3--;
                        break;
                    case 5:

                        scaffale15.Show();
                        label33.Text = null;
                        label33.Tag = null;
                        slot_liberi_camion3--;
                        Prodotti_tipo3--;
                        break;
                }
                costo_scarpe_selezionate -= Convert.ToDouble(scaffale13.Tag);
            }
            if (e.Data.GetData(DataFormats.Text).ToString() == scaffale19.Tag.ToString() + " €")
            {
                switch (slot_liberi_camion4)
                {
                    case 2:

                        scaffale24.Show();
                        label34.Text = null;
                        label34.Tag = null;
                        slot_liberi_camion4--;
                        Prodotti_tipo4--;
                        break;
                    case 3:

                        scaffale23.Show();
                        label35.Text = null;
                        label35.Tag = null;
                        slot_liberi_camion4--;
                        Prodotti_tipo4--;
                        break;
                    case 4:

                        scaffale22.Show();
                        label36.Text = null;
                        label36.Tag = null;
                        slot_liberi_camion4--;
                        Prodotti_tipo4--;
                        break;
                    case 5:

                        scaffale21.Show();
                        label37.Text = null;
                        label37.Tag = null;
                        slot_liberi_camion4--;
                        Prodotti_tipo4--;
                        break;
                }
                costo_scarpe_selezionate -= Convert.ToDouble(scaffale19.Tag);
            }

            // controllo per riabilitare il tasto mappa
            if (label22.Text == "" && label26.Text == "" && label30.Text == "" && label34.Text == "") 
            {
                button_Menu.Show();
                button_TornaNegozio.Show();
            }
        }

        private void panel1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }



        // Ricerca dentro la lista tutti i prodotti
        private int indice_lista_prodotti(string prezzo)
        {
            int indice = 0;

            for (int i = 0; i < Globals.listProdottiNegozio.Capacity; i++)
            {
                if (Convert.ToDouble(prezzo) == Globals.listProdottiNegozio.ElementAt(i).PrezzoAcquisto)
                {
                    indice = i;
                    break;
                }
            }
            return indice;
        }


        // Aggiorna lista prodotti per il negozio
        private void aggiorna_lista_prodotti()
        {
            // riga camion 1


            if (label22.Tag != null)
            {
                Globals.listProdottiNegozio[0].venduto = false;

                if (label23.Tag != null)
                {
                    Globals.listProdottiNegozio[1].venduto = false;

                    if (label24.Tag != null)
                    {
                        Globals.listProdottiNegozio[2].venduto = false;

                        if (label25.Tag != null)
                        {
                            Globals.listProdottiNegozio[3].venduto = false;

                        }
                    }
                }
            } 

            // riga camion 2
            if (label26.Tag != null)
            {
                Globals.listProdottiNegozio[4].venduto = false;

                if (label27.Tag != null)
                {
                    Globals.listProdottiNegozio[5].venduto = false;

                    if (label28.Tag != null)
                    {
                        Globals.listProdottiNegozio[6].venduto = false;

                        if (label29.Tag != null)
                        {
                            Globals.listProdottiNegozio[7].venduto = false;

                        }
                    }
                }
            }

            // riga camion 3
            if (label30.Tag != null)
            {
                Globals.listProdottiNegozio[8].venduto = false;

                if (label31.Tag != null)
                {
                    Globals.listProdottiNegozio[9].venduto = false;

                    if (label32.Tag != null)
                    {
                        Globals.listProdottiNegozio[10].venduto = false;

                        if (label33.Tag != null)
                        {
                            Globals.listProdottiNegozio[11].venduto = false;

                        }
                    }
                }
            }

            // riga camion 4
            if (label34.Tag != null)
            {
                Globals.listProdottiNegozio[12].venduto = false;

                if (label35.Tag != null)
                {
                    Globals.listProdottiNegozio[13].venduto = false;

                    if (label36.Tag != null)
                    {
                        Globals.listProdottiNegozio[14].venduto = false;

                        if (label37.Tag != null)
                        {
                            Globals.listProdottiNegozio[15].venduto = false;

                        }
                    }
                }
            }


        }

        // Ricerca slot liberi banconote
        private int ricerca_slot_liberi_banconote()
        {
            int slot = 0;

            if(banconotefabbrica1.Image == null)
            {
                slot = 1;
            }
            else if (banconotefabbrica2.Image == null)
            {
                slot = 2;
            }
            else if (banconotefabbrica3.Image == null)
            {
                slot = 3;
            }
            else if (banconotefabbrica4.Image == null)
            {
                slot = 4;
            }
            else if (banconotefabbrica5.Image == null)
            {
                slot = 5;
            }
            else if (banconotefabbrica6.Image == null)
            {
                slot = 6;
            }
            else if (banconotefabbrica7.Image == null)
            {
                slot = 7;
            }
            else if (banconotefabbrica8.Image == null)
            {
                slot = 8;
            }
            else
            {
                slot = 9;
            }
            
            return slot;
        }

        // Ricerca slot liberi banconote
        private int ricerca_slot_liberi_monete()
        {
            int slot = 0;
            if (monetefabbrica1.Image == null)
            {
                slot = 1;
            }
            else if (monetefabbrica2.Image == null)
            {
                slot = 2;
            }
            else if (monetefabbrica3.Image == null)
            {
                slot = 3;
            }
            else if (monetefabbrica4.Image == null)
            {
                slot = 4;
            }
            else if (monetefabbrica5.Image == null)
            {
                slot = 5;
            }
            else if (monetefabbrica6.Image == null)
            {
                slot = 6;
            }
            else if (monetefabbrica7.Image == null)
            {
                slot = 7;
            }
            else if (monetefabbrica8.Image == null)
            {
                slot = 8;
            }
            else if (monetefabbrica9.Image == null)
            {
                slot = 9;
            }
            else if (monetefabbrica10.Image == null)
            {
                slot = 10;
            }
            else
            {
                slot = 11;
            }
            return slot;
        }
        
        private void okCompratore_MouseClick(object sender, MouseEventArgs e)
        {
            if (label22.Tag == null && label26.Tag == null && label30.Tag == null && label34.Tag == null)
            {
                textInfo.Text = "camion vuoto";
            }
            else
            {
                if (importoCompratore.Text != "")
                {

                    textInfo.Text = null;
                    double cifra_scritta = Convert.ToDouble(importoCompratore.Text);

                    if (cifra_scritta == costo_scarpe_selezionate && soldi_spostati == costo_scarpe_selezionate)
                    {
                        Globals.visualizzaDialogo = true;
                        button_Menu.Show();
                        button_TornaNegozio.Show();
                        textInfo.Text = "Perfetto, ora possiamo tornare al negozio !!!";
                        smile.Image = global::Negozio_di_Viola.Properties.Resources.SmileFelice;
                        Panel_Portafoglio.AllowDrop = false;
                        panelCompratore.AllowDrop = false;
                        Globals.statoGioco = 4;

                        for (int i = 0; i < 12; i++)
                        {
                            Globals.pFase2[i] = Globals.portafogli[i];
                        }
                    }
                    else if (soldi_spostati < costo_scarpe_selezionate)
                    {
                        if (Globals.PortafoglioVuoto())
                        {
                            textInfo.Text = "I soldi del portafoglio non sono sufficienti per acquistare il prodotto selezionato !!!";
                            smile.Image = global::Negozio_di_Viola.Properties.Resources.SmileTriste;
                        }
                        else
                        {
                            textInfo.Text = "I Soldi spostati non sono sufficienti per acquistare il prodotto selezionato !!!";
                            smile.Image = global::Negozio_di_Viola.Properties.Resources.SmileTriste;
                        }
                    }
                    else if (soldi_spostati > costo_scarpe_selezionate) // non per il livello 1
                    {
                        textInfo.Text = "I soldi spostati sono di più di quelli richiesti per acquistare il prodotto selezionato !!!";
                        smile.Image = global::Negozio_di_Viola.Properties.Resources.SmileTriste;
                    }
                    else if (cifra_scritta != costo_scarpe_selezionate && soldi_spostati == costo_scarpe_selezionate)
                    {
                        textInfo.Text = "Controllare la cifra inserita !!!";
                        smile.Image = global::Negozio_di_Viola.Properties.Resources.SmileTriste;
                    }
                    else if (cifra_scritta == costo_scarpe_selezionate && soldi_spostati != costo_scarpe_selezionate)
                    {
                        textInfo.Text = "Controllare i soldi spostati !!!";
                        smile.Image = global::Negozio_di_Viola.Properties.Resources.SmileTriste;
                    }
                    else if (cifra_scritta != costo_scarpe_selezionate && soldi_spostati != costo_scarpe_selezionate)
                    {
                        textInfo.Text = "Controllare le banconote messe e la cifra inserita !!!";
                        smile.Image = global::Negozio_di_Viola.Properties.Resources.SmileTriste;
                    }
                }
                else
                {
                    textInfo.Text = "Controllare i soldi pagati!!!";

                }
            }

        }

        // set di funzioni per evitari di copiare banconote più volte nei vari panel
        private void Panel_Portafoglio_MouseHover(object sender, EventArgs e)
        {
            Panel_Portafoglio.AllowDrop = false;
            panelCompratore.AllowDrop = true;
        }
        private void panelCompratore_MouseHover(object sender, EventArgs e)
        {
            Panel_Portafoglio.AllowDrop = true;
            panelCompratore.AllowDrop = false;
            
            
        }        
        private void banconotefabbrica1_MouseHover(object sender, EventArgs e)
        {
            Panel_Portafoglio.AllowDrop = true;
            panelCompratore.AllowDrop = false;
        }
        private void PictureBox_50e_MouseHover(object sender, EventArgs e)
        {
            Panel_Portafoglio.AllowDrop = false;
            panelCompratore.AllowDrop = true;
        }
        private void panel1_MouseHover(object sender, EventArgs e)
        {
            Panel_Portafoglio.AllowDrop = false;
            panelCompratore.AllowDrop = false;
          
        }
        

        //Test bottone calcolatrice
        private void calcolatrice_MouseClick(object sender, MouseEventArgs e)
        {
            calc = new Calcolatrice();
            calc.ShowDialog();
        }

        // funzione Temp di test
        private void button_Menu_MouseClick(object sender, MouseEventArgs e)
        {   
// codice con button_Mappa
/*            aggiorna_lista_prodotti();
            Globals.soldiDopo = Globals.GetSoldiPortafoglio();
            this.Close();
            mappa = new Mappa();
            mappa.ShowDialog();
            System.Console.WriteLine("SONO NELLA FABBRICA E CLICCO MAPPA");
            //Globals.stampaProdottiNegozio();
            System.Console.WriteLine("PRODOTTI STAMPATI");
*/
	    
            this.Close();
            home = new HomePage();
            home.ShowDialog();
        }

        private void button_TornaNegozio_MouseClick(object sender, MouseEventArgs e)
        {
            aggiorna_lista_prodotti();
            Globals.soldiDopo = Globals.GetSoldiPortafoglio();

            /*NonSo ns = new NonSo();
            ns.ShowDialog();
            this.Close();*/

            Globals.statoGioco = 0;
            this.Close();
            mappa = new Mappa();
            mappa.ShowDialog();

            //negozio = new Negozio2();
            //negozio.ShowDialog();

            System.Console.WriteLine("SONO NELLA FABBRICA E CLICCO NEGOZIO");
            //Globals.stampaProdottiNegozio();
            System.Console.WriteLine("PRODOTTI STAMPATI");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxCamion_Click(object sender, EventArgs e)
        {

        }

        // ********************************************************************** //

       

        
        


    }
}
