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


namespace Negozio_di_Viola
{
    public partial class Mappa : Form
    {
        delegate void SetTextCallback(string text);
        private Thread thread = null;

        // Le due righe sopra servono per potere cambiare il testo del textbox in modo sicuro.

        Negozio1 ngz1;
        Negozio2 ngz2;
        Negozio3 ngz3;
        Fabbrica mgzz;
        HomePage pagIniz;
        Cliente cl;
  
        System.Timers.Timer timer1;
        System.Timers.Timer timer2;
	int screen_Height = Screen.PrimaryScreen.Bounds.Height;
        int screen_Width = Screen.PrimaryScreen.Bounds.Width;

        double widthFactor;
        double heightFactor;
    //  double widthFactor = Globals.widthFactor;
    //  double heightFactor = Globals.heightFactor;

        public static List<Prodotto> prodotti = new List<Prodotto>();        // E' la lista di tutti i prodotti possibili.

        int ghost;

        
        public Mappa()
        {
            this.getTexts();

            if(Globals.newLevel)
            {
                riempiListeProdotti();
                Globals.newLevel = false;
            }

            InitializeComponent();

            widthFactor = (double) screen_Width / this.Size.Width;
            heightFactor = (double) screen_Height / this.Size.Height;
 
            Adattamento_Risoluzione();

            Def_Immagini_Animazioni();

            visualizzazione();      //visualizzazione si occupa dei colori di sfondo e bottoni

            highlighting();
            AddPicturebox3();
            //this.pictureBox3.BringToFront();

            timer1 = new System.Timers.Timer(7000);
            timer1.Elapsed += new ElapsedEventHandler(OnTimedEvent1);
            timer1.Enabled = true;
        }

        private void riempiListeProdotti()
        {
            string str;
            string[] split_vec;

            double pFabbrica, pNegozio;

            int numProdottiTutti;

            Prodotto prod; 

            try
            {

  // MessageBox.Show("  " + Globals.prodottiPath + "Prodotti.txt" ); // DEBUG
                StreamReader sr = new StreamReader(Globals.prodottiPath + "Prodotti.txt");

	// Riempi lista Prodotti tutti
	
                Globals.numeroProdottiTutti = numProdottiTutti = Convert.ToInt32(sr.ReadLine());

                for (int i = 0; i < numProdottiTutti; i++)
                {
                    str = sr.ReadLine();
                    split_vec = str.Split(new Char[] { ';' });

                    switch (Globals.Livello)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:

                            //  pFabbrica = Convert.ToDouble(Convert.ToInt16(Convert.ToDouble(split_vec[1])));
                            //  pNegozio = Convert.ToDouble(Convert.ToInt16(Convert.ToDouble(split_vec[2])));
                            pFabbrica = Convert.ToDouble((int)(Convert.ToDouble(split_vec[1])));
                            pNegozio = Convert.ToDouble((int)(Convert.ToDouble(split_vec[2])));

                            break;

                        default:

                            pFabbrica = Convert.ToDouble(split_vec[1]);
                            pNegozio = Convert.ToDouble(split_vec[2]);

                            break;
                    }

                    Globals.listProdottiTutti.Add(new Prodotto(split_vec[0], pFabbrica, pNegozio, Image.FromFile(Globals.prodottiPath + split_vec[3]), true));

                }
            }
	    catch (Exception IOException)
            {
                Globals.numeroProdottiTutti = numProdottiTutti = Globals.Num_Prodotti_DEF;

                for (int i = 0; i < numProdottiTutti; i++)
                {
                    switch (Globals.Livello)
                    {
                        case 1:

                            pFabbrica = Convert.ToDouble((int)Globals.Prezzi_Fabbrica_DEF[i]);
                            pNegozio = Convert.ToDouble((int)Globals.Prezzi_Negozio_DEF[i]);

                            break;

                        default:

                            pFabbrica = Globals.Prezzi_Fabbrica_DEF[i];
                            pNegozio  = Globals.Prezzi_Negozio_DEF[i];

                            break;
                    }

                    Globals.listProdottiTutti.Add(new Prodotto(Globals.Nomi_Prodotti_DEF[i], pFabbrica, pNegozio, Globals.Image_Prodotti_DEF[i], true));
                }
            }

	// Scegli 4 tipi di prodotti e riempi lista prodotti negozio
	
		int n1, n2, n3, n4;

		if (Globals.numeroProdottiTutti == 4)
		{
                    n1 = 0;    n2 = 1;    n3 = 2;    n4 = 3;   
		}
		else
		{
                    n1 = Globals.global_rnd.Next(0, Globals.numeroProdottiTutti-1);

		    while (true)
		    {
		        n2 = Globals.global_rnd.Next(0, Globals.numeroProdottiTutti-1);
                        if(n2 != n1) break;
		    }

		    while (true)
		    {
		        n3 = Globals.global_rnd.Next(0, Globals.numeroProdottiTutti-1);
                        if(n3 != n1 && n3 != n2) break;
		    }

		    while (true)
		    {
		        n4 = Globals.global_rnd.Next(0, Globals.numeroProdottiTutti-1);
                        if(n4 != n1 && n4 != n2 && n4 != n3) break;
		    }
		}

// MessageBox.Show("n1 - n4 =  " + n1 + ", " + n2 + ", " + n3 + ", " + n4 + " "); // DEBUG


                prod = new Prodotto(Globals.listProdottiTutti[n1].nome, 
                                    Globals.listProdottiTutti[n1].prezzo_acquisto, Globals.listProdottiTutti[n1].prezzo_vendita, 
                                    Globals.listProdottiTutti[n1].immagine, Globals.listProdottiTutti[n1].venduto);
                Globals.listProdottiNegozio.Add(prod);
                prod = new Prodotto(Globals.listProdottiTutti[n1].nome, 
                                    Globals.listProdottiTutti[n1].prezzo_acquisto, Globals.listProdottiTutti[n1].prezzo_vendita, 
                                    Globals.listProdottiTutti[n1].immagine, Globals.listProdottiTutti[n1].venduto);
                Globals.listProdottiNegozio.Add(prod);
                prod = new Prodotto(Globals.listProdottiTutti[n1].nome, 
                                    Globals.listProdottiTutti[n1].prezzo_acquisto, Globals.listProdottiTutti[n1].prezzo_vendita, 
                                    Globals.listProdottiTutti[n1].immagine, Globals.listProdottiTutti[n1].venduto);
                Globals.listProdottiNegozio.Add(prod);
                prod = new Prodotto(Globals.listProdottiTutti[n1].nome, 
                                    Globals.listProdottiTutti[n1].prezzo_acquisto, Globals.listProdottiTutti[n1].prezzo_vendita, 
                                    Globals.listProdottiTutti[n1].immagine, Globals.listProdottiTutti[n1].venduto);
                Globals.listProdottiNegozio.Add(prod);

                prod = new Prodotto(Globals.listProdottiTutti[n2].nome, 
                                    Globals.listProdottiTutti[n2].prezzo_acquisto, Globals.listProdottiTutti[n2].prezzo_vendita, 
                                    Globals.listProdottiTutti[n2].immagine, Globals.listProdottiTutti[n2].venduto);
                Globals.listProdottiNegozio.Add(prod);
                prod = new Prodotto(Globals.listProdottiTutti[n2].nome, 
                                    Globals.listProdottiTutti[n2].prezzo_acquisto, Globals.listProdottiTutti[n2].prezzo_vendita, 
                                    Globals.listProdottiTutti[n2].immagine, Globals.listProdottiTutti[n2].venduto);
                Globals.listProdottiNegozio.Add(prod);
                prod = new Prodotto(Globals.listProdottiTutti[n2].nome, 
                                    Globals.listProdottiTutti[n2].prezzo_acquisto, Globals.listProdottiTutti[n2].prezzo_vendita, 
                                    Globals.listProdottiTutti[n2].immagine, Globals.listProdottiTutti[n2].venduto);
                Globals.listProdottiNegozio.Add(prod);
                prod = new Prodotto(Globals.listProdottiTutti[n2].nome, 
                                    Globals.listProdottiTutti[n2].prezzo_acquisto, Globals.listProdottiTutti[n2].prezzo_vendita, 
                                    Globals.listProdottiTutti[n2].immagine, Globals.listProdottiTutti[n2].venduto);
                Globals.listProdottiNegozio.Add(prod);

                prod = new Prodotto(Globals.listProdottiTutti[n3].nome, 
                                    Globals.listProdottiTutti[n3].prezzo_acquisto, Globals.listProdottiTutti[n3].prezzo_vendita, 
                                    Globals.listProdottiTutti[n3].immagine, Globals.listProdottiTutti[n3].venduto);
                Globals.listProdottiNegozio.Add(prod);
                prod = new Prodotto(Globals.listProdottiTutti[n3].nome, 
                                    Globals.listProdottiTutti[n3].prezzo_acquisto, Globals.listProdottiTutti[n3].prezzo_vendita, 
                                    Globals.listProdottiTutti[n3].immagine, Globals.listProdottiTutti[n3].venduto);
                Globals.listProdottiNegozio.Add(prod);
                prod = new Prodotto(Globals.listProdottiTutti[n3].nome, 
                                    Globals.listProdottiTutti[n3].prezzo_acquisto, Globals.listProdottiTutti[n3].prezzo_vendita, 
                                    Globals.listProdottiTutti[n3].immagine, Globals.listProdottiTutti[n3].venduto);
                Globals.listProdottiNegozio.Add(prod);
                prod = new Prodotto(Globals.listProdottiTutti[n3].nome, 
                                    Globals.listProdottiTutti[n3].prezzo_acquisto, Globals.listProdottiTutti[n3].prezzo_vendita, 
                                    Globals.listProdottiTutti[n3].immagine, Globals.listProdottiTutti[n3].venduto);
                Globals.listProdottiNegozio.Add(prod);
                prod = new Prodotto(Globals.listProdottiTutti[n3].nome, 
                                    Globals.listProdottiTutti[n3].prezzo_acquisto, Globals.listProdottiTutti[n3].prezzo_vendita, 
                                    Globals.listProdottiTutti[n3].immagine, Globals.listProdottiTutti[n3].venduto);

                prod = new Prodotto(Globals.listProdottiTutti[n4].nome, 
                                    Globals.listProdottiTutti[n4].prezzo_acquisto, Globals.listProdottiTutti[n4].prezzo_vendita, 
                                    Globals.listProdottiTutti[n4].immagine, Globals.listProdottiTutti[n4].venduto);
                Globals.listProdottiNegozio.Add(prod);
                prod = new Prodotto(Globals.listProdottiTutti[n4].nome, 
                                    Globals.listProdottiTutti[n4].prezzo_acquisto, Globals.listProdottiTutti[n4].prezzo_vendita, 
                                    Globals.listProdottiTutti[n4].immagine, Globals.listProdottiTutti[n4].venduto);
                Globals.listProdottiNegozio.Add(prod);
                prod = new Prodotto(Globals.listProdottiTutti[n4].nome, 
                                    Globals.listProdottiTutti[n4].prezzo_acquisto, Globals.listProdottiTutti[n4].prezzo_vendita, 
                                    Globals.listProdottiTutti[n4].immagine, Globals.listProdottiTutti[n4].venduto);
                Globals.listProdottiNegozio.Add(prod);
                prod = new Prodotto(Globals.listProdottiTutti[n4].nome, 
                                    Globals.listProdottiTutti[n4].prezzo_acquisto, Globals.listProdottiTutti[n4].prezzo_vendita, 
                                    Globals.listProdottiTutti[n4].immagine, Globals.listProdottiTutti[n4].venduto);
                Globals.listProdottiNegozio.Add(prod);
                prod = new Prodotto(Globals.listProdottiTutti[n4].nome, 
                                    Globals.listProdottiTutti[n4].prezzo_acquisto, Globals.listProdottiTutti[n4].prezzo_vendita, 
                                    Globals.listProdottiTutti[n4].immagine, Globals.listProdottiTutti[n4].venduto);

                Globals.numeroProdotti = 16;

        }

        public void OnTimedEvent1(object source, ElapsedEventArgs e)
        {
            if(this.pictureBox3.Image == null)

                this.pictureBox3.Image = this.fumetto;

            firstText = true;

            this.thread = new Thread(new ThreadStart(this.ThreadProcSafe));

            this.thread.Start();
            
            timer2 = new System.Timers.Timer(5000);
            timer2.Elapsed += new ElapsedEventHandler(OnTimedEvent2);
            timer2.Enabled = true;
        }

        public void OnTimedEvent2(object source, ElapsedEventArgs e)
        {
            firstText = false;
            
            this.thread = new Thread(new ThreadStart(this.ThreadProcSafe));

            try { this.thread.Start(); }//[RIV] vengono avviati thread già in esecuzione?
            catch { }
	    }

        private void ThreadProcSafe()
        {
            if (firstText)

                this.SetText(this.text1);

            else
            
                this.SetText(this.text2);
        }

        private void SetText(string text)
        {
            if (this.textBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }

            else
            {
                this.textBox.Text = text;
                this.pictureBox3.SendToBack();
            }
        }
         
        public void visualizzazione()
        {
            this.bEsci.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.bHome.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.bChiamaCliente.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);

            this.bEsci.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.bHome.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.bChiamaCliente.ForeColor = Color.FromName(Globals.BUTTON_TEXT);

            if (Globals.statoGioco ==3)
            {
                this.bCliente1.BackgroundImage = cl1H;
                this.bCliente2.BackgroundImage = cl2H;
                this.bCliente3.BackgroundImage = cl3H;
            }

            if (HomePage.newGame)
            
                putFurgNeg();
            
        }

        public void highlighting()
        {
            if (Globals.statoGioco == 0 || Globals.statoGioco == 2 || Globals.statoGioco == 4 || Globals.statoGioco == 5)
            {
                this.bNegozio.MouseEnter += new EventHandler(this.bNegozio_MouseEnter);
                this.bNegozio.MouseLeave += new EventHandler(this.bNegozio_MouseLeave);
            }

//            if (Globals.statoGioco == 1 || Globals.statoGioco == 2)
            if (Globals.statoGioco == 1)
            {
                this.bFabbrica.MouseEnter += new EventHandler(this.bFabbrica_MouseEnter);
                this.bFabbrica.MouseLeave += new EventHandler(this.bFabbrica_MouseLeave);
            }

            if (Globals.statoGioco == 3)
            {
                this.bCliente1.MouseEnter += new EventHandler(this.bCliente1_MouseEnter);
                this.bCliente1.MouseLeave += new EventHandler(this.bCliente1_MouseLeave);
                this.bCliente2.MouseEnter += new EventHandler(this.bCliente2_MouseEnter);
                this.bCliente2.MouseLeave += new EventHandler(this.bCliente2_MouseLeave);
                this.bCliente3.MouseEnter += new EventHandler(this.bCliente3_MouseEnter);
                this.bCliente3.MouseLeave += new EventHandler(this.bCliente3_MouseLeave);
            }
        }

        void Adattamento_Risoluzione()
        {
            bEsci.Width = (int)(bEsci.Width * widthFactor);
            bEsci.Height = (int)(bEsci.Height * heightFactor);
            bEsci.Location = new Point((int)(bEsci.Location.X * widthFactor), (int)(bEsci.Location.Y * heightFactor));
            bEsci.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            bHome.Width = (int)(bHome.Width * widthFactor);
            bHome.Height = (int)(bHome.Height * heightFactor);
            bHome.Location = new Point((int)(bHome.Location.X * widthFactor), (int)(bHome.Location.Y * heightFactor));
            bHome.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            bCliente1.Width = (int)(bCliente1.Width * widthFactor);
            bCliente1.Height = (int)(bCliente1.Height * heightFactor);
            bCliente1.Location = new Point((int)(bCliente1.Location.X * widthFactor), (int)(bCliente1.Location.Y * heightFactor));

            bCliente2.Width = (int)(bCliente2.Width * widthFactor);
            bCliente2.Height = (int)(bCliente2.Height * heightFactor);
            bCliente2.Location = new Point((int)(bCliente2.Location.X * widthFactor), (int)(bCliente2.Location.Y * heightFactor));

            bCliente3.Width = (int)(bCliente3.Width * widthFactor);
            bCliente3.Height = (int)(bCliente3.Height * heightFactor);
            bCliente3.Location = new Point((int)(bCliente3.Location.X * widthFactor), (int)(bCliente3.Location.Y * heightFactor));

            bNegozio.Width = (int)(bNegozio.Width * widthFactor);
            bNegozio.Height = (int)(bNegozio.Height * heightFactor);
            bNegozio.Location = new Point((int)(bNegozio.Location.X * widthFactor), (int)(bNegozio.Location.Y * heightFactor));

            bFabbrica.Width = (int)(bFabbrica.Width * widthFactor);
            bFabbrica.Height = (int)(bFabbrica.Height * heightFactor);
            bFabbrica.Location = new Point((int)(bFabbrica.Location.X * widthFactor), (int)(bFabbrica.Location.Y * heightFactor));

            bChiamaCliente.Width = (int)(bChiamaCliente.Width * widthFactor);
            bChiamaCliente.Height = (int)(bChiamaCliente.Height * heightFactor);
            bChiamaCliente.Location = new Point((int)(bChiamaCliente.Location.X * widthFactor), (int)(bChiamaCliente.Location.Y * heightFactor));
            bChiamaCliente.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);
        }


        private void onClick(object sender, EventArgs e)
        {            
            if (sender is Button)
            {                
                if(timer1 != null)

                    timer1.Stop();

                if (timer2 != null)
                
                    timer2.Stop();

                this.SuspendLayout();
                textBox.Hide();
                this.ResumeLayout(false);

                switch (((Button)sender).Name)
                {
                    case "negozio":

                        //if(Globals.statoGioco == 5)
                        //{
                          //  this.Close();
                        //}

//                        else
  //                      {
                            this.pictureBox3.Visible = false;

                            if (!HomePage.newGame)
                            {
                                animFabNeg();
                            }

                            else

                                HomePage.newGame = false;

                            pictureBox2.Visible = false;
                            this.Close();

                           /* if(Globals.statoGioco == 0 || !Globals.visualizzaDialogo)
                            {
                                ngz2 = new Negozio2();
                                ngz2.ShowDialog();
                            }

                            else
                            {
                                ngz1 = new Negozio1();
                                ngz1.ShowDialog();
                            }*/

                            if (Globals.visualizzaDialogo)
                            {
                                if (Globals.Livello == 6)
                                {
                                    ngz3 = new Negozio3();
                                    ngz3.ShowDialog();
                                }
                                else
                                {
                                    ngz1 = new Negozio1();
                                    ngz1.ShowDialog();
                                }
                            }

                            else
                            {
                                ngz2 = new Negozio2();
                                ngz2.ShowDialog();
                            }
    //                    }

                        break;

                    case "fabbrica":

                        this.pictureBox3.Visible = false;
                        animNegFab();
                        mgzz = new Fabbrica();
                        this.Close();
                        mgzz.ShowDialog();

                        break;

                    case "cliente1":

                        this.pictureBox3.Visible = false;
           
                        if (Globals.statoGioco == 3)
                        {
                            //Globals.statoGioco = 2;
                            Globals.statoGioco = 5;
                            animClNeg1();
                            cl = new Cliente();
                            this.Close();
                            cl.ShowDialog();
                        }

                        break;

                    case "cliente2":

                        this.pictureBox3.Visible = false;
            
                        if (Globals.statoGioco == 3)
                        {
                            //Globals.statoGioco = 2;
                            Globals.statoGioco = 5;
                            animClNeg2();
                            cl = new Cliente();
                            this.Close();
                            cl.ShowDialog();
                        }

                        break;

                    case "cliente3":

                        this.pictureBox3.Visible = false;
            
                        if (Globals.statoGioco == 3)
                        {
                            //Globals.statoGioco = 2;
                            Globals.statoGioco = 5;
                            animClNeg3();
                            cl = new Cliente();
                            this.Close();
                            cl.ShowDialog();
                        }

                        break;

                    case "bHome":

                        Globals.newGame = false;
                        pagIniz = new HomePage();
                        this.Close();
                        pagIniz.ShowDialog();

                        break;

                    case "bChiamaCliente":

                        Globals.statoGioco = 3;
                        Mappa mappa = new Mappa();
                        this.Close();
                        mappa.ShowDialog();
                        //animazioneClienteDaFuori();

                        break;

                    case "bEsci":

                        Application.Exit();

                        break;
                }

                this.Close();
            }
        }

        //////Funzioni per l'Highlighting////

        void bCliente1_MouseLeave(object sender, EventArgs e)
        {
            if (Globals.statoGioco == 3)
                this.bCliente1.BackgroundImage = cl1H;
            else
                this.bCliente1.BackgroundImage = cl1;
        }

        void bCliente1_MouseEnter(object sender, EventArgs e)
        {
            this.bCliente1.BackgroundImage = cl1M;
            if (ghost == 2)
                ghost = 3;
            else if (ghost == 4)
                ghostAnimation();
            else
                ghost = 0;
        }

        void bCliente2_MouseLeave(object sender, EventArgs e)
        {
            if (Globals.statoGioco == 3)
                this.bCliente2.BackgroundImage = cl2H;
            else
                this.bCliente2.BackgroundImage = cl2;
        }

        void bCliente2_MouseEnter(object sender, EventArgs e)
        {
            this.bCliente2.BackgroundImage = cl2M;
            if (ghost == 0)
                ghost = 1;
            else if (ghost == 3)
                ghost = 4;
            else
                ghost = 0;
        }

        void bCliente3_MouseLeave(object sender, EventArgs e)
        {
            if (Globals.statoGioco == 3)
                this.bCliente3.BackgroundImage = cl3H;
            else
                this.bCliente3.BackgroundImage = cl3;
        }

        void bCliente3_MouseEnter(object sender, EventArgs e)
        {
            this.bCliente3.BackgroundImage = cl3M;
            if (ghost == 1)
                ghost = 2;
            else
                ghost = 0;
        }

        void bNegozio_MouseLeave(object sender, EventArgs e)
        {
            if (Globals.statoGioco == 0 || Globals.statoGioco == 2 || Globals.statoGioco == 4 || Globals.statoGioco == 5)
                this.bNegozio.BackgroundImage = negH;
            else
                this.bNegozio.BackgroundImage = neg;
        }

        void bNegozio_MouseEnter(object sender, EventArgs e)
        {
            this.bNegozio.BackgroundImage = negM;
            if (ghost == 4)
            {
                ghostAnimation();
                ghost = 0;
            }
        }

        void bFabbrica_MouseLeave(object sender, EventArgs e)
        {
            if (Globals.statoGioco == 1 || Globals.statoGioco == 2)
                this.bFabbrica.BackgroundImage = fabH;
            else
                this.bFabbrica.BackgroundImage = fab;
        }

        void bFabbrica_MouseEnter(object sender, EventArgs e)
        {
            this.bFabbrica.BackgroundImage = fabM;
            ghost = 1;
        }

        ////Funzione animazione

        public void AddPicturebox1()
        {
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Controls.Add(this.pictureBox1);
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Name = "macchina";
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Size = new System.Drawing.Size((int)(118*widthFactor), (int)(63*heightFactor));

            
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        }

        public void AddPicturebox2()
        {
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.Controls.Add(this.pictureBox2);
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Name = "furgone";
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Size = new System.Drawing.Size((int)(147 * widthFactor), (int)(78 * heightFactor));


            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
        }

        public void AddPicturebox3()
        {
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.Controls.Add(this.pictureBox3);
            this.pictureBox3.Location = new System.Drawing.Point((int)(628 * widthFactor), (int)(25 * heightFactor));
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Name = "fumetto1";
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 25;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Size = new System.Drawing.Size((int)(285 * widthFactor), (int)(225 * heightFactor));
            this.AddTextBox();
            
            

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
        }

        public void AddTextBox()
        {
            this.SuspendLayout();
            this.textBox.Location = new System.Drawing.Point((int)(674 * widthFactor), (int)(59 * heightFactor));
            //this.textBox.Location = new System.Drawing.Point((int)(184 * widthFactor), (int)(120 * heightFactor));
            this.textBox.Size = new System.Drawing.Size((int)(200 * widthFactor), (int)(110 * heightFactor));
            //this.textBox.Multiline = true;
            //this.textBox.WordWrap = true;
            this.textBox.Name = "Testo";
            this.textBox.TabIndex = 26;
            this.textBox.TabStop = false;
            this.textBox.Visible = true;
            this.textBox.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Regular);
            this.textBox.ForeColor = System.Drawing.Color.MidnightBlue;
            this.textBox.BackColor = System.Drawing.Color.White;
            this.textBox.FlatAppearance.BorderSize = 0;
            this.textBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.textBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.textBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //this.textBox.TextAlign = HorizontalAlignment.Center;
            //this.textBox.BorderStyle = BorderStyle.None;
            //this.textBox.BringToFront();
            this.Controls.Add(this.textBox);
            this.ResumeLayout();
        }

        public void ChangeText()
        {
            this.SuspendLayout();
            this.Controls.Remove(textBox);
            //this.textBox.Text = this.text2;
            this.Controls.Add(textBox);
            //this.textBox.Hide();
            this.ResumeLayout();
        }

//
//	Funzioni per animazione veicoli
//

        public void animClNeg1()
        {
            this.pictureBox1.Image = macchinaV;
            location.X = (int)(1053 * widthFactor);
            location.Y = (int)(635 * heightFactor);
            AddPicturebox1();
            pictureBox1.Visible = true;
            while (location.X > (860 * widthFactor))
            {
                this.pictureBox1.BringToFront();
                location.X = (int)(location.X - 2 * Globals.speedFactor1 * widthFactor);
                
                this.pictureBox1.Location = location;
                ((Form)this).Update();
                Thread.Sleep(2);

            }

            while (location.Y > (480 * heightFactor))
            {
                this.pictureBox1.BringToFront();
                location.Y = (int)(location.Y - 2 * Globals.speedFactor1 * heightFactor);

                this.pictureBox1.Location = location;
                ((Form)this).Update();
                Thread.Sleep(2);
            }

            while (location.X > (615 * widthFactor))
            {
                this.pictureBox1.BringToFront();
                location.X = (int)(location.X - 2 * Globals.speedFactor1 * widthFactor);

                this.pictureBox1.Location = location;
                ((Form)this).Update();
                Thread.Sleep(2);

            }

            this.pictureBox1.Visible = false;
            
        }

        public void animClNeg2()
        {
            this.pictureBox1.Image = macchinaR;
            location.X = (int)(279 * widthFactor);
            location.Y = (int)(272 * heightFactor);
            AddPicturebox1();
            pictureBox1.Visible = true;
            while (location.X < (370 * widthFactor))
            {
                this.pictureBox1.BringToFront();
                location.X = (int)(location.X + 2 * Globals.speedFactor1 * widthFactor);

                this.pictureBox1.Location = location;
                ((Form)this).Update();
                Thread.Sleep(2);

            }

            while (location.Y < (480 * heightFactor))
            {
                this.pictureBox1.BringToFront();
                location.Y = (int)(location.Y + 2 * Globals.speedFactor1 * heightFactor);

                this.pictureBox1.Location = location;
                ((Form)this).Update();
                Thread.Sleep(2);
            }

            while (location.X < (615 * widthFactor))
            {
                this.pictureBox1.BringToFront();
                location.X = (int)(location.X + 2.5 * Globals.speedFactor1 * widthFactor);

                this.pictureBox1.Location = location;
                ((Form)this).Update();
                Thread.Sleep(2);

            }

            this.pictureBox1.Visible = false;

        }

        public void animClNeg3()
        {
            this.pictureBox1.Image = macchinaB;
            location.X = (int)(157 * widthFactor);
            location.Y = (int)(635 * heightFactor);
            AddPicturebox1();
            pictureBox1.Visible = true;
            while (location.X < (370 * widthFactor))
            {
                this.pictureBox1.BringToFront();
                location.X = (int)(location.X + 3 * Globals.speedFactor1 * widthFactor);

                this.pictureBox1.Location = location;
                ((Form)this).Update();
                Thread.Sleep(2);

            }

            while (location.Y > (480 * heightFactor))
            {
                this.pictureBox1.BringToFront();
                location.Y = (int)(location.Y - 2 * Globals.speedFactor1 * heightFactor);

                this.pictureBox1.Location = location;
                ((Form)this).Update();
                Thread.Sleep(2);
            }

            while (location.X < (615 * widthFactor))
            {
                this.pictureBox1.BringToFront();
                location.X = (int)(location.X + 3 * Globals.speedFactor1 * widthFactor);

                this.pictureBox1.Location = location;
                ((Form)this).Update();
                Thread.Sleep(2);

            }

            this.pictureBox1.Visible = false;

        }

        public void animFabNeg()
        {
            location.X = (int)(1030 * widthFactor);
            location.Y = (int)(240 * heightFactor);
            this.pictureBox2.Image = furgoneRib;
            AddPicturebox2();
            pictureBox2.Visible = true;

            while (location.X > (830 * widthFactor))
            {
                this.pictureBox2.BringToFront();
                location.X = (int)(location.X - 2 * Globals.speedFactor1 * widthFactor);

                this.pictureBox2.Location = location;
                ((Form)this).Update();
                Thread.Sleep(2);

            }

            while (location.Y < (480 * heightFactor))
            {
                this.pictureBox2.BringToFront();
                location.Y = (int)(location.Y + 2 * Globals.speedFactor1 * heightFactor);

                this.pictureBox2.Location = location;
                ((Form)this).Update();
                Thread.Sleep(2);
            }

            while (location.X > (615 * widthFactor))
            {
                this.pictureBox2.BringToFront();
                location.X = (int)(location.X - 2 * Globals.speedFactor1 * widthFactor);

                this.pictureBox2.Location = location;
                ((Form)this).Update();
                Thread.Sleep(2);
            }

            this.pictureBox2.Visible = false;
        }

        public void animNegFab()
        {

            location.X = (int)(615 * widthFactor);
            location.Y = (int)(480 * heightFactor);
            AddPicturebox2();
            this.pictureBox2.Image = furgone;
            pictureBox2.Visible = true;
            while (location.X < (835 * widthFactor))
            {
                this.pictureBox2.BringToFront();
                location.X = (int)(location.X + 2 * Globals.speedFactor1 * widthFactor);

                this.pictureBox2.Location = location;
                ((Form)this).Update();
                Thread.Sleep(2);

            }

            while (location.Y > (240 * heightFactor))
            {
                this.pictureBox2.BringToFront();
                location.Y = (int)(location.Y - 2 * Globals.speedFactor1 * heightFactor) ;

                this.pictureBox2.Location = location;
                ((Form)this).Update();
                Thread.Sleep(2);
            }

            while (location.X < (1030 * widthFactor))
            {
                this.pictureBox2.BringToFront();
                location.X = (int)(location.X + 2 * Globals.speedFactor1 * widthFactor);

                this.pictureBox2.Location = location;
                ((Form)this).Update();
                Thread.Sleep(2);

            }

            this.pictureBox2.Visible = false;

        }

        public void ghostAnimation()
        {
            this.pictureBox1.Image = macchinaN;
            location.X = (int)(0 * widthFactor);
            location.Y = (int)(272 * heightFactor);
            AddPicturebox1();
            pictureBox1.Visible = true;
            while (location.X < (370 * widthFactor))
            {
                this.pictureBox1.BringToFront();
                location.X = (int)(location.X + 5 * Globals.speedFactor1 * widthFactor);

                this.pictureBox1.Location = location;
                ((Form)this).Update();
                Thread.Sleep(2);

            }

            while (location.Y < (480 * heightFactor))
            {
                this.pictureBox1.BringToFront();
                location.Y = (int)(location.Y + 5 * Globals.speedFactor1 * heightFactor);

                this.pictureBox1.Location = location;
                ((Form)this).Update();
                Thread.Sleep(2);
            }

            while (location.X < (860 * widthFactor))
            {
                this.pictureBox1.BringToFront();
                location.X = (int)(location.X + 5 * Globals.speedFactor1 * widthFactor);

                this.pictureBox1.Location = location;
                ((Form)this).Update();
                Thread.Sleep(2);

            }

            while (location.Y > (271 * heightFactor))
            {
                this.pictureBox1.BringToFront();
                location.Y = (int)(location.Y - 5 * Globals.speedFactor1 * heightFactor);

                this.pictureBox1.Location = location;
                ((Form)this).Update();
                Thread.Sleep(2);
            }

            while (location.X < (1280* widthFactor))
            {
                this.pictureBox1.BringToFront();
                location.X = (int)(location.X + 5 * Globals.speedFactor1 * widthFactor);

                this.pictureBox1.Location = location;
                ((Form)this).Update();
                Thread.Sleep(2);

            }

            this.pictureBox1.Visible = false;

        }

        public void animazioneClienteDaFuori()
        {
            int i = Globals.global_rnd.Next(2);
            switch (i)
            {
                case 0: animClNeg1();
                    break;
                case 1: animClNeg2();
                    break;
                case 2: animClNeg3();
                    break;                    
            }
            
            cl = new Cliente();
            this.Close();
            cl.ShowDialog();
        }

        public void animazioneFabbricaDaFuori()
        {
            animNegFab();
            mgzz = new Fabbrica();
            this.Close();
            mgzz.ShowDialog();
        }

        public void putFurgNeg()
        {
            location.X = (int)(620 * widthFactor); //650
            location.Y = (int)(480 * heightFactor);
            this.pictureBox2.Image = furgoneRib;
            AddPicturebox2();
            this.pictureBox2.BringToFront();
            location.X = (int)(location.X - 2 * Globals.speedFactor1 * widthFactor);
            location.Y = (int)(location.Y + 2 * Globals.speedFactor1 * heightFactor);
            this.pictureBox2.Location = location;
            pictureBox2.Visible = true;
        }

        //DEF. IMMAGINI MACCHINE E PICTUREBOX PER ANIMAZIONI//

        public void Def_Immagini_Animazioni()
        {
//          mr = new Bitmap(Globals.immaginiPath + "macchinaR.png");
            mr = new Bitmap(global::Negozio_di_Viola.Properties.Resources.macchinaR);

            macchinaR = new Bitmap(mr, new Size((int)(mr.Width * widthFactor), (int)(mr.Height * heightFactor)));

//          mb = new Bitmap(Globals.immaginiPath + "macchinaB.png");
            mb = new Bitmap(global::Negozio_di_Viola.Properties.Resources.macchinaB);

            macchinaB = new Bitmap(mb, new Size((int)(mb.Width * widthFactor), (int)(mb.Height * heightFactor)));

//          mv = new Bitmap(Globals.immaginiPath + "macchinaV2.png");
            mv = new Bitmap(global::Negozio_di_Viola.Properties.Resources.macchinaV2);

            macchinaV = new Bitmap(mv, new Size((int)(mv.Width * widthFactor), (int)(mv.Height * heightFactor)));

//          fr = new Bitmap(Globals.immaginiPath + "furgoneRib.png");
            fr = new Bitmap(global::Negozio_di_Viola.Properties.Resources.furgoneRib);

//          f = new Bitmap(Globals.immaginiPath + "furgone.png");
            f = new Bitmap(global::Negozio_di_Viola.Properties.Resources.furgone);

            furgoneRib = new Bitmap(fr, new Size((int)(f.Width * widthFactor), (int)(f.Height * heightFactor)));
            furgoneRib = new Bitmap(fr, new Size((int)(f.Width * widthFactor), (int)(f.Height * heightFactor)));

            furgone = new Bitmap(f, new Size((int)(f.Width * widthFactor), (int)(f.Height * heightFactor)));

//          b = new Bitmap(Globals.immaginiPath + "macchinaN.png");
            b = new Bitmap(global::Negozio_di_Viola.Properties.Resources.macchinaN);

            macchinaN = new Bitmap(b, new Size((int)(b.Width * widthFactor), (int)(b.Height * heightFactor)));

//          fum = new Bitmap(Globals.immaginiPath + "fumetto.png");
            fum = new Bitmap(global::Negozio_di_Viola.Properties.Resources.fumetto);

            fumetto = new Bitmap(fum, new Size((int)(fum.Width * widthFactor), (int)(fum.Height * heightFactor)));
        }


        //DICHIARAZIONE IMMAGINI MACCHINE E PICTUREBOX PER ANIMAZIONI//

        public static Bitmap mr;
        Bitmap macchinaR;
        public static Bitmap mb;
        Bitmap macchinaB;
        public static Bitmap mv;
        Bitmap macchinaV;
        public static Bitmap fr;
        Bitmap furgoneRib;
        public static Bitmap f;
        Bitmap furgone;
        public static Bitmap b;
        Bitmap macchinaN;

        public static Bitmap fum;
        Bitmap fumetto;

        private bool firstText;
        private Point location;
        private System.Windows.Forms.PictureBox pictureBox1 = new System.Windows.Forms.PictureBox();
        private System.Windows.Forms.PictureBox pictureBox2 = new System.Windows.Forms.PictureBox();
        private System.Windows.Forms.PictureBox pictureBox3 = new System.Windows.Forms.PictureBox();
        private System.Windows.Forms.Button textBox = new Button();
    }
}
