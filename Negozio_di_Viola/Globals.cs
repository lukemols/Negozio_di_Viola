using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using Negozio_di_Viola.Properties;

namespace Negozio_di_Viola
{
    class Globals
    {
        // Portafoglio fasi

        public static int[] pFase1 = new int[12];       // Situazione iniziale, prima che Viola vada in fabbrica.
        public static int[] pFase2 = new int[12];       // Situazione dopo l'acquisto delle scarpe in fabbrica.
        public static int[] pFase3 = new int[12];       // Situazione dopo la vendita delle scarpe al cliente.
//---------------------------------------------
        public static int[] seqAcquisto = new int[100]; 
        public static int   nAcquisto = 0; 
        public static int[] seqVendita = new int[100]; 
        public static int   nVendita = 0; 
//---------------------------------------------

        public static List<int> casellaP2 = new List<int>();
        public static Image[] soldiImg = new Image[12];

        public static Prodotto scarpe;
        public static int indice_scarpe;
        public static double soldiPrima;        // Soldi prima dell'acquisto in fabbrica.
        public static double soldiDopo;         // Soldi dopo l'acquisto in fabbrica.
        public static double soldiDopoVendita;  // Soldi dopo la vendita.
        public static string pFabbrica;
        public static string pNegozio;

        public static Random global_rnd = new Random(Environment.TickCount);


        public static void Inizializza_soldiImg()
        {
	    soldiImg[0] = global::Negozio_di_Viola.Properties.Resources._50euro;
	    soldiImg[1] = global::Negozio_di_Viola.Properties.Resources._20euro;
	    soldiImg[2] = global::Negozio_di_Viola.Properties.Resources._10euro;
	    soldiImg[3] = global::Negozio_di_Viola.Properties.Resources._5euro;
	    soldiImg[4] = global::Negozio_di_Viola.Properties.Resources._2euro;
	    soldiImg[5] = global::Negozio_di_Viola.Properties.Resources._1euro;
	    soldiImg[6] = global::Negozio_di_Viola.Properties.Resources._50cent;
	    soldiImg[7] = global::Negozio_di_Viola.Properties.Resources._20cent;
	    soldiImg[8] = global::Negozio_di_Viola.Properties.Resources._10cent;
	    soldiImg[9] = global::Negozio_di_Viola.Properties.Resources._5cent;
	    soldiImg[10] = global::Negozio_di_Viola.Properties.Resources._2cent;
	    soldiImg[11] = global::Negozio_di_Viola.Properties.Resources._1cent;
       }


        public static Queue<Image> riempiListaImg(int fase)
        {
            Queue<Image> immagini = new Queue<Image>();
            Image tmp;
            int[] soldi;
            int i, count;
            //double scale = 1;

	    Inizializza_soldiImg();

            if (fase == 1)

                soldi = pFase1;

            else if (fase == 2)

                soldi = pFase2;

            else if (fase == 3)

                soldi = pFase3;

            else

                return null;

            for (int j = 0; j < 12 ; j++ )
            {
                count = soldi[j];

                if(count != 0)
                {
                    tmp = soldiImg[j];
                    //var newWidth = (int)(scale * soldiImg[j].Width);
                    //var newHeight = (int)(scale * soldiImg[j].Height);
                    var newWidth = 50;
                    var newHeight = 32;

                    var newImage = new Bitmap(newWidth, newHeight);

                    using (var graphics = Graphics.FromImage(newImage))
                        graphics.DrawImage(tmp, 0, 0, newWidth, newHeight);

                    for (i = 0; i < count; i++)
                    {
                        immagini.Enqueue(newImage);
                    }
                }
            }

            return immagini;
        }
        
        // Percorsi

    //  public static string path = Directory.GetCurrentDirectory();
        public static string prodottiPath = "Prodotti/";
        public static string immaginiPath = "Immagini/";

        // Variabili
        public static int numeroProdotti;
        public static int numeroProdottiTutti;

        public static string prVendita;
        public static string prAcquisto;
        public static double prezzo1;
        public static double prezzo2;
        public static System.Windows.Forms.PictureBox pictureBoxacq = new System.Windows.Forms.PictureBox();
        public static int statoGioco = 0;
        public static int msTimer = 1000;
        public static MODE mode = MODE.auto;
        public static double speedFactor1 = 4.5; // per mappa 1.5
        public static double speedFactor2 = 14; // per cliente 4
      
        // mode definisce la modalità del gioco: con mode impostato ad auto, il livello varia nel momento in cui l'utente
        // dimostra di avere compreso i concetti del livello corrente, con mode impostato a select, il livello viene scelto
        // manualmente.
        
        public enum MODE
        {
            auto,
            selLev
        }

        public static bool visualizzaDialogo = false;
        
        // Stati:
        
        // Stato 0: si può cliccare solo il negozio (che è vuoto)
        // Stato 1: si può cliccare solo la fabbrica perchè il negozio è vuoto ed è stato controllato
        // Stato 2: si può cliccare negozio, fabbrica, e si può chiamare un cliente
        // Stato 3: si può cliccare una casa di un cliente dopo che è stato deciso di chiamarlo
        // Stato 4: si può cliccare solo il negozio dopo essere stati in fabbrica
        // Stato 5: ho il cliente nel negozio. Posso solo tornare al negozio.


        // Stringhe

        public static string fumMagazzino = "Gli scaffali sono vuoti... Devo andare alla fabbrica";
        public static string fumSperoCliente = "Il portafoglio ora è vuoto... Spero venga un cliente a comprare le scarpe.";
        public static string fumChiamaCliente = "Ora aspetto un cliente che venga a comprare le scarpe!";
        
        // Flag

        public static bool newGame = false;
        public static bool newLevel = true;
        public static bool wallet_exists = false;  // Bool che mi dice se esiste già un portafoglio. False all'inizio del gioco.

        // Immagini
 //MOD  public static string[] listImgProdotti = Directory.GetFiles(prodottiPath, "*.jpg");
 //     public static string[] listImgProdotti;

        // Vettori di stato

        public static List<Prodotto> listProdottiTutti = new List<Prodotto>();
        public static List<Prodotto> listProdottiNegozio = new List<Prodotto>();    // Lista prodotti (16) 
        public static Prodotto[]         ProdottiNegozio = new Prodotto[16];    // Array prodotti (16) 

        public static int[] portafogli = new int[12];   // (50e, 20e, 10e, 5e, 2e, 1e, 50c, 20c, 10c, 5c, 2c, 1c)
        public static double[] valoreSoldi = new double[]{50.0, 20.0, 10.0, 5.0, 2.0, 1.0, 0.5, 0.2, 0.1, 0.05, 0.02, 0.01};

        //public static bool cliente = false;

        //public static bool fabbrica = false;

        // Coefficienti di adattamento

        public static int screenWidth = (int)Screen.PrimaryScreen.Bounds.Width;
        public static int screenHeight = (int)Screen.PrimaryScreen.Bounds.Height;
        public static double widthFactor = (double)screenWidth / 1280;  // 1241  1257
        public static double heightFactor = (double)screenHeight / 800; //  774   781
    //  public static double widthFactor = (double)Screen.PrimaryScreen.Bounds.Width / 1600; //screenWidth;  // 1241  1257
    //  public static double heightFactor = (double)Screen.PrimaryScreen.Bounds.Height / 900; //screenHeight; //  774   781

        // Dichiarazione Form

        public static Calcolatrice calcolatrice = new Calcolatrice();
        //public static Mappa mappa = new Mappa();


        // Config values

        public static string PANEL_BACKGROUND;
        public static string BUTTON_BACKGROUND;
        public static string BUTTON_BACKGROUND_OK;
        public static string BUTTON_TEXT;
        public static string ACTIVE_BACKGROUND;
        public static string INACTIVE_BACKGROUND;
        public static string SELECTION;
        public static int    Livello;
        public static string Tipo;
        public static string Lingua;

        public static string PANEL_BACKGROUND_DEF = "LightSeaGreen";
        public static string BUTTON_BACKGROUND_DEF = "Yellow";
        public static string BUTTON_BACKGROUND_OK_DEF = "Orange";
        public static string BUTTON_OK_DEF = "Orange";
        public static string BUTTON_TEXT_DEF = "MidnightBlue";
        public static string ACTIVE_BACKGROUND_DEF = "LightCyan";
        public static string INACTIVE_BACKGROUND_DEF = "LightSeaGreen";
        public static string SELECTION_DEF = "Red";
        public static int    Livello_DEF = 1;
        public static string Tipo_DEF = "Scarpe";
        public static string Lingua_DEF = "IT";

        public static int Num_Prodotti_DEF = 16;

        public static double[] Prezzi_Fabbrica_DEF = new double[]
        {
            /* NASCONDIAMO I PREZZI DEL PROF PER METTERE PREZZI TONDI ED EVITARE PROBLEMI DI CAMBIO
            60.50,
            65.50,
            70.50,
            75.50,
            53.60,
            58.60,
            62.60,
            67.60,
            40.40,
            45.40,
            50.40,
            55.40,
            20.20,
            25.20,
            30.20,
            35.20
            */
            60.00,
            65.00,
            70.00,
            75.00,
            53.00,
            58.00,
            62.00,
            67.00,
            40.00,
            45.00,
            50.00,
            55.00,
            20.00,
            25.00,
            30.00,
            35.00
        };

        public static double[] Prezzi_Negozio_DEF = new double[]
        {
            75.50,
            80.50,
            85.50,
            90.50,
            70.00,
            75.00,
            80.00,
            85.00,
            55.50,
            60.50,
            65.50,
            70.50,
            30.00,
            35.00,
            40.00,
            45.00
        };

        public static string[] Nomi_Prodotti_DEF = new string[]
        {
            "Scarpe bianche 1",
            "Scarpe bianche 2",
            "Scarpe bianche 3",
            "Scarpe bianche 4",
            "Scarpe nere 1",
            "Scarpe nere 2",
            "Scarpe nere 3",
            "Scarpe nere 4",
            "Scarpe rosa 1",
            "Scarpe rosa 2",
            "Scarpe rosa 3",
            "Scarpe rosa 4",
            "Scarpe rosse 1",
            "Scarpe rosse 2",
            "Scarpe rosse 3",
            "Scarpe rosse 4"
        };

        public static Image[] Image_Prodotti_DEF = new Image[]
        {
            global::Negozio_di_Viola.Properties.Resources.Scarpe_bianche_1,
            global::Negozio_di_Viola.Properties.Resources.Scarpe_bianche_2,
            global::Negozio_di_Viola.Properties.Resources.Scarpe_bianche_3,
            global::Negozio_di_Viola.Properties.Resources.Scarpe_bianche_4,
            global::Negozio_di_Viola.Properties.Resources.Scarpe_nere_1,
            global::Negozio_di_Viola.Properties.Resources.Scarpe_nere_2,
            global::Negozio_di_Viola.Properties.Resources.Scarpe_nere_3,
            global::Negozio_di_Viola.Properties.Resources.Scarpe_nere_4,
            global::Negozio_di_Viola.Properties.Resources.Scarpe_rosa_1,
            global::Negozio_di_Viola.Properties.Resources.Scarpe_rosa_2,
            global::Negozio_di_Viola.Properties.Resources.Scarpe_rosa_3,
            global::Negozio_di_Viola.Properties.Resources.Scarpe_rosa_4,
            global::Negozio_di_Viola.Properties.Resources.Scarpe_rosse_1,
            global::Negozio_di_Viola.Properties.Resources.Scarpe_rosse_2,
            global::Negozio_di_Viola.Properties.Resources.Scarpe_rosse_3,
            global::Negozio_di_Viola.Properties.Resources.Scarpe_rosse_4
        };

        // Funzioni

        //public static void CreaLista()
        //{
        //    Random rnd = new Random();
        //    Prodotto p;
        //    for (int i = 0; i < 8; i++)
        //    {
        //        p = Globals.listProdottiTutti[rnd.Next(Globals.listProdottiTutti.Count)];
        //        Globals.listProdottiNegozio.Add(p);
        //    }
        //}



        public static void CreaPortafogli()
        {
	    double prezzo_min =  1000.00;
	    double prezzo_min2 = 1000.00;
	    int    prezzo;

            switch (Globals.Livello)
            {
                case 1:

                case 2:

                    // Scelgo come target il paio di scarpe con il prezzo acquisto minore 
		    // tra i 4 tipi possibili che l'utente puÃ² comprare e inserisco nel portafoglio 
                    // il denaro contato per le scarpe scelte.

                    for (int i=0; i<4; i++)
                        if (Globals.listProdottiNegozio[4*i].PrezzoAcquisto < prezzo_min)
                        {
                            prezzo_min = Globals.listProdottiNegozio[4*i].PrezzoAcquisto;
		            Globals.indice_scarpe = i;
                        }

                    Globals.scarpe = Globals.listProdottiNegozio[4*Globals.indice_scarpe];

                    Globals.pFabbrica = Convert.ToString(Globals.scarpe.PrezzoAcquisto) + "â¬";
                    Globals.pNegozio = Convert.ToString(Globals.scarpe.PrezzoVendita) + "â¬";

                    prezzo = (int)Globals.scarpe.prezzo_acquisto;

                    Globals.nAcquisto = 0; 

		    while (prezzo != 0)
                    {
            		if (prezzo >= 50)
            		{
                            Insert50E();
			    prezzo -= 50;
            		}
            		else if (prezzo >= 20)
            		{
                            Insert20E();
			    prezzo -= 20;
            		}
            		else if (prezzo >= 10)
            		{
                            Insert10E();
			    prezzo -= 10;
            		}
            		else if (prezzo >= 5)
            		{
                            Insert5E();
			    prezzo -= 5;
            		}
            		else if (prezzo >= 2)
            		{
                            Insert2E();
			    prezzo -= 2;
            		}
            		else if (prezzo >= 1)
            		{
                            Insert1E();
			    prezzo -= 1;
            		}
                    }

                    break;

                case 3:

                case 4:

                case 5:

                case 6:

                    // Scelgo come target il paio di scarpe con il prezzo acquisto minore 
		    // tra i 4 tipi possibili che l'utente puÃ² comprare e inserisco nel portafoglio 
                    // una cifra >= del denaro contato per le scarpe scelte e < del prezzo delle scarpe 
		    // con prezzo immediatamente superiore.

                    for (int i=0; i<4; i++)
                        if (Globals.listProdottiNegozio[4*i].PrezzoAcquisto < prezzo_min)
                        {
                            prezzo_min = Globals.listProdottiNegozio[4*i].PrezzoAcquisto;
		            Globals.indice_scarpe = i;
                        }

                    Globals.scarpe = Globals.listProdottiNegozio[4*Globals.indice_scarpe];

                    Globals.pFabbrica = Convert.ToString(Globals.scarpe.PrezzoAcquisto) + "â¬";
                    Globals.pNegozio = Convert.ToString(Globals.scarpe.PrezzoVendita) + "â¬";

                    for (int i=0; i<4; i++)
                        if ( (i!=Globals.indice_scarpe) && (Globals.listProdottiNegozio[4*i].PrezzoAcquisto < prezzo_min2) )
                            prezzo_min2 = Globals.listProdottiNegozio[4*i].PrezzoAcquisto;

                    prezzo = Globals.global_rnd.Next((int)prezzo_min, (int)(prezzo_min2 - 1));  

                    Globals.nAcquisto = 0; 

		    while (prezzo != 0)
                    {
            		if (prezzo >= 50)
            		{
                            Insert50E();
			    prezzo -= 50;
            		}
            		else if (prezzo >= 20)
            		{
                            Insert20E();
			    prezzo -= 20;
            		}
            		else if (prezzo >= 10)
            		{
                            Insert10E();
			    prezzo -= 10;
            		}
            		else if (prezzo >= 5)
            		{
                            Insert5E();
			    prezzo -= 5;
            		}
            		else if (prezzo >= 2)
            		{
                            Insert2E();
			    prezzo -= 2;
            		}
            		else if (prezzo >= 1)
            		{
                            Insert1E();
			    prezzo -= 1;
            		}
                    }

                    break;

                default:

                    for (int i = 0; i < Globals.portafogli.Length; i++)
                    {
                        Globals.portafogli[i] = Globals.global_rnd.Next(5);
                    }

                    break;
            }

            Globals.wallet_exists = true;
        }



        private static void Insert50E()
        {
            int random = Globals.global_rnd.Next(101);

            if ((random % 3) == 0)
            {
                Globals.portafogli[0]++;
                Globals.pFase1[0]++;
                Globals.seqAcquisto[Globals.nAcquisto++] = 0;  
            }

            else
            {
                Insert20E();
                Insert10E();
                
                if(Globals.pFase1[3] != 6)
                {
                    Insert20E();
                }

                else
                {
                    random = Globals.global_rnd.Next(101);

                    if ((random % 2) == 0)
                    {
                        Globals.portafogli[2] += 2;
                        Globals.pFase1[2] += 2;
                        Globals.seqAcquisto[Globals.nAcquisto++] = 2;  
                        Globals.seqAcquisto[Globals.nAcquisto++] = 2;  
                    }

                    else
                    {
                        Globals.portafogli[1]++;
                        Globals.pFase1[1]++;
                        Globals.seqAcquisto[Globals.nAcquisto++] = 1;  
                    }
                }
                
            }
        }



        private static void Insert20E()
        {
            int random = Globals.global_rnd.Next(101);

            if ((random % 2) == 0)
            {
                Globals.portafogli[1]++;
                Globals.pFase1[1]++;
                Globals.seqAcquisto[Globals.nAcquisto++] = 1;  
            }

            else
            {
                Insert10E();
                Insert10E();
            }
        }



        private static void Insert10E()
        {
            int random = Globals.global_rnd.Next(101);

            if ((random % 3) == 0)
            {
                Globals.portafogli[3] += 2;
                Globals.pFase1[3] += 2;
                Globals.seqAcquisto[Globals.nAcquisto++] = 3;  
                Globals.seqAcquisto[Globals.nAcquisto++] = 3;  
            }

            else
            {
                Globals.portafogli[2]++;
                Globals.pFase1[2]++;
                Globals.seqAcquisto[Globals.nAcquisto++] = 2;  
            }
        }



        private static void Insert5E()
        {
            Globals.portafogli[3]++;
            Globals.pFase1[3]++;
            Globals.seqAcquisto[Globals.nAcquisto++] = 3;  
        }



        private static void Insert2E()
        {
            Globals.portafogli[4]++;
            Globals.pFase1[4]++;
            Globals.seqAcquisto[Globals.nAcquisto++] = 4;  
        }



        private static void Insert1E()
        {
            Globals.portafogli[5]++;
            Globals.pFase1[5]++;
            Globals.seqAcquisto[Globals.nAcquisto++] = 5;  
        }



       public static void CostruisciSequenzaVendita()
        {
           double prezzo1, prezzo2; 
           double prezzo_double, prezzo1_double, prezzo2_double;
           int    prezzo_int, prezzo1_int, prezzo2_int;

	    prezzo1 = Globals.prezzo1;
            prezzo1_int = Convert.ToInt16(prezzo1);

            if (prezzo1_int > Globals.prezzo1)
                prezzo1_int = prezzo1_int - 1;

            prezzo1_double = prezzo1 - Convert.ToDouble(prezzo1_int);
            prezzo1_double = Math.Round(prezzo1_double, 2);

            prezzo2 = Globals.prezzo2;
            prezzo2_int = Convert.ToInt16(prezzo2);

            if (prezzo2_int > prezzo2)
                prezzo2_int = prezzo2_int - 1;

            prezzo2_double = prezzo2 - Convert.ToDouble(prezzo2_int);
            prezzo2_double = Math.Round(prezzo2_double, 2);

            switch (Globals.Livello)
            {
                case 1:

                case 3:

                    for (int i = 0; i < Globals.nAcquisto; i++)
                    {
                        Globals.seqVendita[i] = Globals.seqAcquisto[i]; 
                        Globals.pFase3[Globals.seqAcquisto[i]]++;
                    }
        
                    Globals.nVendita = Globals.nAcquisto;
        
        	        prezzo_int = prezzo1_int - prezzo2_int;
        	        prezzo_double = prezzo1_double - prezzo2_double;
        
                    while((prezzo_int!=0) || (prezzo_double!=0))
                    {
                        if(prezzo_int >= 50)
                        {
                            prezzo_int = prezzo_int - 50;
                            Globals.pFase3[0]++;
                            Globals.seqVendita[Globals.nVendita++] = 0;
                        }
                        else if(prezzo_int >= 20)
                        {
                            prezzo_int = prezzo_int - 20;
                            Globals.pFase3[1]++;
                            Globals.seqVendita[Globals.nVendita++] = 1;
                        }
                        else if(prezzo_int >= 10)
                        {
                            prezzo_int = prezzo_int - 10;
                            Globals.pFase3[2]++;
                            Globals.seqVendita[Globals.nVendita++] = 2;
                        }
                        else if(prezzo_int >= 5)
                        {
                            prezzo_int = prezzo_int - 5;
                            Globals.pFase3[3]++;
                            Globals.seqVendita[Globals.nVendita++] = 3;
                        }
                        else if(prezzo_int >= 2)
                        {
                            prezzo_int = prezzo_int - 2;
                            Globals.pFase3[4]++;
                            Globals.seqVendita[Globals.nVendita++] = 4;
                        }
                        else if(prezzo_int >= 1)
                        {
                            prezzo_int = prezzo_int - 1;
                            Globals.pFase3[5]++;
                            Globals.seqVendita[Globals.nVendita++] = 5;
                        }
                        else if (prezzo_double >= (double)0.50)
                        {
                            prezzo_double = prezzo_double - (double)0.50;
                            Globals.pFase3[6]++;
                            Globals.seqVendita[Globals.nVendita++] = 6;
                        }
                        else if (prezzo_double >= (double)0.20)
                        {
                            prezzo_double = prezzo_double - (double)0.20;
                            Globals.pFase3[7]++;
                            Globals.seqVendita[Globals.nVendita++] = 7;
                        }
                        else if (prezzo_double >= (double)0.10)
                        {
                            prezzo_double = prezzo_double - (double)0.10;
                            Globals.pFase3[8]++;
                            Globals.seqVendita[Globals.nVendita++] = 8;
                        }
                        else if (prezzo_double >= (double)0.05)
                        {
                            prezzo_double = prezzo_double - 0.05;
                            Globals.pFase3[9]++;
                            Globals.seqVendita[Globals.nVendita++] = 9;
                        }
                        else if (prezzo_double >= (double)0.02)
                        {
                            prezzo_double = prezzo_double - (double)0.02;
                            Globals.pFase3[10]++;
                            Globals.seqVendita[Globals.nVendita++] = 10;
                        }
                        else if (prezzo_double >= (double)0.01)
                        {
                            prezzo_double = prezzo_double - (double)0.01;
                            Globals.pFase3[11]++;
                            Globals.seqVendita[Globals.nVendita++] = 11;
                        }
                        else
                        {
                            prezzo_double = 0;
                            prezzo_int = 0;
                        }
    
                    }

                    break;

                case 2:

                case 4:

                case 5:

                case 6:

                    Globals.nVendita = 0;
        
        	        prezzo_int = prezzo1_int;
        	        prezzo_double = prezzo1_double;
        
                    while((prezzo_int!=0) || (prezzo_double!=0))
                    {
                        if(prezzo_int >= 50)
                        {
                            prezzo_int = prezzo_int - 50;
                            Globals.pFase3[0]++;
                            Globals.seqVendita[Globals.nVendita++] = 0;
                        }
                        else if(prezzo_int >= 20)
                        {
                            prezzo_int = prezzo_int - 20;
                            Globals.pFase3[1]++;
                            Globals.seqVendita[Globals.nVendita++] = 1;
                        }
                        else if(prezzo_int >= 10)
                        {
                            prezzo_int = prezzo_int - 10;
                            Globals.pFase3[2]++;
                            Globals.seqVendita[Globals.nVendita++] = 2;
                        }
                        else if(prezzo_int >= 5)
                        {
                            prezzo_int = prezzo_int - 5;
                            Globals.pFase3[3]++;
                            Globals.seqVendita[Globals.nVendita++] = 3;
                        }
                        else if(prezzo_int >= 2)
                        {
                            prezzo_int = prezzo_int - 2;
                            Globals.pFase3[4]++;
                            Globals.seqVendita[Globals.nVendita++] = 4;
                        }
                        else if(prezzo_int >= 1)
                        {
                            prezzo_int = prezzo_int - 1;
                            Globals.pFase3[5]++;
                            Globals.seqVendita[Globals.nVendita++] = 5;
                        }
                        else if (prezzo_double >= (double)0.50)
                        {
                            prezzo_double = prezzo_double - (double)0.50;
                            Globals.pFase3[6]++;
                            Globals.seqVendita[Globals.nVendita++] = 6;
                        }
                        else if (prezzo_double >= (double)0.20)
                        {
                            prezzo_double = prezzo_double - (double)0.20;
                            Globals.pFase3[7]++;
                            Globals.seqVendita[Globals.nVendita++] = 7;
                        }
                        else if (prezzo_double >= (double)0.10)
                        {
                            prezzo_double = prezzo_double - (double)0.10;
                            Globals.pFase3[8]++;
                            Globals.seqVendita[Globals.nVendita++] = 8;
                        }
                        else if (prezzo_double >= (double)0.05)
                        {
                            prezzo_double = prezzo_double - 0.05;
                            Globals.pFase3[9]++;
                            Globals.seqVendita[Globals.nVendita++] = 9;
                        }
                        else if (prezzo_double >= (double)0.02)
                        {
                            prezzo_double = prezzo_double - (double)0.02;
                            Globals.pFase3[10]++;
                            Globals.seqVendita[Globals.nVendita++] = 10;
                        }
                        else if (prezzo_double >= (double)0.01)
                        {
                            prezzo_double = prezzo_double - (double)0.01;
                            Globals.pFase3[11]++;
                            Globals.seqVendita[Globals.nVendita++] = 11;
                        }
                        else
                        {
                            prezzo_double = 0;
                            prezzo_int = 0;
                        }
    
                    }

                    break;

            }

        }





        public static bool PortafoglioVuoto()
        {
            for (int i = 0; i < 12; i++)
            {
                if(Globals.portafogli[i] > 0)
                    return false;
            }
	    return true;
        }

        public static double GetSoldiPortafoglio()
        {
            double soldi = 0.0;

            for (int i = 0; i < Globals.portafogli.Length; i++)
            {
                soldi += Globals.portafogli[i] * Globals.valoreSoldi[i];
            }

            return soldi;
        }

        public static void stampaPortafoglio(string t)
        {
            System.Console.WriteLine("\n\n" + t + "!!!!\n");
            System.Console.WriteLine("\n\t50E\t20E\t10E\t5E\t2E\t1E\t0.50E\t0.20E\t0.10E\t0.05E\t0.02E\t0.001E\n");
            System.Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t\t{7}\t\t{8}\t\t{9}\t\t{10}\t\t{11}\n",
                Globals.portafogli[0], Globals.portafogli[1], Globals.portafogli[2], Globals.portafogli[3],
                Globals.portafogli[4], Globals.portafogli[5], Globals.portafogli[6], Globals.portafogli[7],
                Globals.portafogli[8], Globals.portafogli[9], Globals.portafogli[10], Globals.portafogli[11]);
        }

        public static void stampaProdottiNegozio()
        {
            int i = 0;

            if(listProdottiNegozio.Count == 0)
            {
                System.Console.WriteLine("Nessun prodotto nel negozio!!");
            }

            else
            {
                foreach (Prodotto p in listProdottiNegozio)
                {
                    System.Console.WriteLine("\n\t{0} - {1}\n", i++, p.Nome);
                }
            }
        }
	///////////////////////////////////////////////////////////////////////////////////

	        private void MyGlobals()
        {
        }

        public static string Versione = "1.1";
        public static string Mese = "Novembre";
        public static string Anno = "2015";

        public static string Titolo_Text =  "Il Negozio di Viola";
	public static string Sottotitolo_Text = "Versione " + Versione + ", " + Mese + " " + Anno ;

        public static string Programma_text = Titolo_Text;
        public static string Versione_text = Sottotitolo_Text;
        public static string Autori_text = "Francesco Curatelli e Chiara Martinengo";
        public static string Ditta_text = "Università di Genova";
        public static string Contatto_text = "Per contattare gli Autori:    curatelli@unige.it"; 
        public static string Collab_text = ""; // "(hanno collaborato alla realizzazione:\r\nxxxxx)";

        public static string ApplicationData_text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string EastLab_text = "EAST-Lab";
        public static string CartellaLocale_text = Path.Combine(ApplicationData_text , EastLab_text , Programma_text);

        public static string Licenza_text = "LICENZA FREEWARE - Questo programma software è distribuito gratuitamente per uso personale e non commerciale, ed è rilasciato così com'è, senza garanzie di alcun tipo, esplicite o implicite (incluse, senza limitazioni, le garanzie implicite di buona qualità ed idoneità ad un uso specifico). Tutti i rischi derivanti dal funzionamento o dal mancato funzionamento del programma software sono a carico dell'Utente.  In nessun caso gli Autori potranno essere considerati responsabili per qualsiasi danno diretto o indiretto di qualsiasi tipo (inclusi, senza limitazioni, danni per perdita di profitti, di interruzione di servizi, perdite di dati, o ogni altra perdita pecuniaria) derivanti dall'utilizzo o dalla impossibilità di utilizzo del programma software, anche se gli Autori sono stati avvisati sulla possibilità che si verifichino questi danni.  Installando, copiando o utilizzando in qualsiasi modo il programma software l'Utente accetta implicitamente ed in tutte le loro parti le suddette condizioni.";

    }

	///////////////////////////////////////////////////////////////////////////////////
      

    // Classe per contenere i prodotti da gestire all'interno del gioco.

    public class Prodotto
    {
        public string nome;
        public Image immagine;

        public double prezzo_vendita;
        public double prezzo_acquisto;
        public bool venduto;

        public Prodotto(string nome, double prezzo_acquisto, double prezzo_vendita, Image immagine, bool venduto)
        {
            this.nome = nome;
            this.prezzo_acquisto = prezzo_acquisto;
            this.prezzo_vendita = prezzo_vendita;
            this.immagine = immagine;
            this.venduto = venduto;
        }

        public string Nome { get { return nome; } }
        public double PrezzoAcquisto { get { return prezzo_acquisto; } }
        public double PrezzoVendita { get { return prezzo_vendita; } }
        public Image Immagine { get { return immagine; } }

        private double prezzo;
        public double Prezzo { get { return prezzo; } }
        public Prodotto(string nome, double prezzo, Image immagine)
        {
            this.nome = nome;
            this.prezzo = prezzo;
            this.immagine = immagine;
            this.venduto = false;
        }
    }
}



    
