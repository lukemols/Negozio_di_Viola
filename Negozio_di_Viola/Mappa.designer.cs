using System.Drawing;


namespace Negozio_di_Viola
{
    partial class Mappa
    {


        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bEsci = new System.Windows.Forms.Button();
            this.bHome = new System.Windows.Forms.Button();
            this.bCliente1 = new System.Windows.Forms.Button();
            this.bCliente2 = new System.Windows.Forms.Button();
            this.bCliente3 = new System.Windows.Forms.Button();
            this.bNegozio = new System.Windows.Forms.Button();
            this.bFabbrica = new System.Windows.Forms.Button();
            this.bChiamaCliente = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // bEsci
            // 

            #region

            this.bEsci.Location = new System.Drawing.Point(1022, 720);
	    this.bEsci.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bEsci.Name = "bEsci";
            this.bEsci.Size = new System.Drawing.Size(169, 61);
            this.bEsci.TabIndex = 2;
            this.bEsci.Text = "ESCI";
            this.bEsci.UseVisualStyleBackColor = true;
            this.bEsci.Click += new System.EventHandler(this.onClick);

            #endregion

            // 
            // bHome
            // 
            this.bHome.Location = new System.Drawing.Point(65, 720);
	    this.bHome.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bHome.Name = "bHome";
            this.bHome.Size = new System.Drawing.Size(169, 61);
            this.bHome.TabIndex = 3;
            this.bHome.Text = "MENU";
            this.bHome.UseVisualStyleBackColor = true;
            this.bHome.Click += new System.EventHandler(this.onClick);

            // 
            // bChiamaCliente
            // 
            this.bChiamaCliente.Location = new System.Drawing.Point(544, 720);
            this.bChiamaCliente.Name = "bHbChiamaClienteome";
            this.bChiamaCliente.Size = new System.Drawing.Size(169, 61);
            this.bChiamaCliente.TabIndex = 3;
            this.bChiamaCliente.Text = "CHIAMA CLIENTE";
            this.bChiamaCliente.UseVisualStyleBackColor = true;
            this.bChiamaCliente.Click += new System.EventHandler(this.onClick);
            
            // 
            // Bottoni Clienti
            // 

            // bCliente1

            this.bCliente1.BackgroundImage = cl1;
            this.bCliente1.FlatAppearance.BorderSize = 0;
            this.bCliente1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCliente1.Location = new System.Drawing.Point(998, 382);
            this.bCliente1.Name = "cliente1";
            this.bCliente1.Size = new System.Drawing.Size(170, 250);
            this.bCliente1.TabIndex = 4;
            this.bCliente1.UseVisualStyleBackColor = true;
            this.bCliente1.BackColor = Color.Transparent;
            this.bCliente1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.bCliente1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            //if (Globals.statoGioco == 3)
            this.bCliente1.Click += new System.EventHandler(this.onClick);
            

            // bCliente2
            this.bCliente2.BackgroundImage = cl2;
            this.bCliente2.FlatAppearance.BorderSize = 0;
            this.bCliente2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCliente2.Location = new System.Drawing.Point(255, 10);
            this.bCliente2.Name = "cliente2";
            this.bCliente2.Size = new System.Drawing.Size(170, 250);
            this.bCliente2.TabIndex = 4;
            this.bCliente2.UseVisualStyleBackColor = true;
            this.bCliente2.BackColor = Color.Transparent;
            this.bCliente2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.bCliente2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            //if (Globals.statoGioco == 3) 
                this.bCliente2.Click += new System.EventHandler(this.onClick);

            // bCliente3
            this.bCliente3.BackgroundImage = cl3;
            this.bCliente3.FlatAppearance.BorderSize = 0;
            this.bCliente3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCliente3.Location = new System.Drawing.Point(133, 375);
            this.bCliente3.Name = "cliente3";
            this.bCliente3.Size = new System.Drawing.Size(170, 250);
            this.bCliente3.TabIndex = 4;
            this.bCliente3.UseVisualStyleBackColor = true;
            this.bCliente3.BackColor = Color.Transparent;
            this.bCliente3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.bCliente3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            //if (Globals.statoGioco == 3) 
            this.bCliente3.Click += new System.EventHandler(this.onClick);

            //bNegozio

          if (Globals.statoGioco == 0 || Globals.statoGioco == 2 || Globals.statoGioco ==4)
                this.bNegozio.BackgroundImage = negH;
          else
              this.bNegozio.BackgroundImage = neg;
            this.bNegozio.FlatAppearance.BorderSize = 0;
            this.bNegozio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bNegozio.Location = new System.Drawing.Point(530,248);
            this.bNegozio.Name = "negozio";
            this.bNegozio.Size = new System.Drawing.Size(280, 230);
            this.bNegozio.TabIndex = 4;
            this.bNegozio.UseVisualStyleBackColor = true;
            this.bNegozio.BackColor = Color.Transparent;
            this.bNegozio.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.bNegozio.FlatAppearance.MouseDownBackColor = Color.Transparent;
          if (Globals.statoGioco == 0 || Globals.statoGioco == 2 || Globals.statoGioco == 4)
              this.bNegozio.Click += new System.EventHandler(this.onClick);

            //bFabbrica
          if (Globals.statoGioco == 1 || Globals.statoGioco == 2)
                this.bFabbrica.BackgroundImage = fabH;
          else
                this.bFabbrica.BackgroundImage = fab;
            this.bFabbrica.FlatAppearance.BorderSize = 0;
            this.bFabbrica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bFabbrica.Location = new System.Drawing.Point(910, 20);
            this.bFabbrica.Name = "fabbrica";
            this.bFabbrica.Size = new System.Drawing.Size(300, 220);
            this.bFabbrica.TabIndex = 4;
            this.bFabbrica.UseVisualStyleBackColor = true;
            this.bFabbrica.BackColor = Color.Transparent;
            this.bFabbrica.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.bFabbrica.FlatAppearance.MouseDownBackColor = Color.Transparent;
          if (Globals.statoGioco == 1 || Globals.statoGioco == 2)
              this.bFabbrica.Click += new System.EventHandler(this.onClick);


            // 
            // Mappa
            // 

//          Bitmap bmp = new Bitmap(Globals.immaginiPath + "mappaVuota.png");
	    Bitmap bmp = new Bitmap(global::Negozio_di_Viola.Properties.Resources.mappaVuota);
            Bitmap BgImg = new Bitmap(bmp, new Size(Globals.screenWidth, Globals.screenHeight));//objImage is the origional Image
            this.BackgroundImage = BgImg;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.bCliente1);
            this.Controls.Add(this.bCliente2);
            this.Controls.Add(this.bCliente3);
            if(Globals.statoGioco == 2)
                this.Controls.Add(this.bChiamaCliente);
            this.Controls.Add(this.bNegozio);
            this.Controls.Add(this.bFabbrica);
            this.Controls.Add(this.bHome);
            this.Controls.Add(this.bEsci);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Mappa";
            this.Text = "MappaTemp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public void getTexts()
        {
            if (Globals.statoGioco == 0)
                
                if (Globals.Lingua == "IT")
                {
                    text1 = "CIAO! CONTROLLA IL TUO NEGOZIO!!";
                    text2 = "CLICCA SUL NEGOZIO DI VIOLA!";
                }

                else
                {
                    text1 = "CHECK THE SHOP!";
                    text2 = text1;
                }

            if (Globals.statoGioco == 1)

                if (Globals.Lingua == "IT")
                {
                    text1 = "DEVI FARE ACQUISTI? VAI ALLA FABBRICA!";
                    text2 = "CLICCA SULLA FABBRICA!";
                }

                else
                {
                    text1 = "GO TO THE FACTORY!";
                    text2 = text1;
                }

            if (Globals.statoGioco == 2)

                if (Globals.Lingua == "IT")
                {
                    text1 = "DOVRESTI CHIAMARE UN CLIENTE!!";
                    text2 = "CLICCA SU 'CHIAMA CLIENTE'";
                }

                else
                {
                    text1 = "CALL A CLIENT!";
                    text2 = text1;
                }

            if (Globals.statoGioco == 3)

                if (Globals.Lingua == "IT")
                {
                    text1 = "SCEGLI UN CLIENTE!!";
                    text2 = "CLICCA SULLA CASA DI UN CLIENTE!";
                }

                else
                {
                    text1 = "CLICK ON A HOUSE!";
                    text2 = text1;
                }

            if (Globals.statoGioco == 4)

                if (Globals.Lingua == "IT")
                {
                    text1 = "CIAO! CONTROLLA IL TUO NEGOZIO!!";
                    text2 = "CLICCA SUL NEGOZIO DI VIOLA!";
                }

                else
                {
                    text1 = "CHECK THE SHOP!";
                    text2 = text1;
                }
        }

        private string text1;
        private string text2;
        private System.Windows.Forms.Button bEsci;
        private System.Windows.Forms.Button bHome;
        private System.Windows.Forms.Button bCliente1;
        private System.Windows.Forms.Button bCliente2;
        private System.Windows.Forms.Button bCliente3;
        private System.Windows.Forms.Button bNegozio;
        private System.Windows.Forms.Button bChiamaCliente;
        private System.Windows.Forms.Button bFabbrica;


        //Dichiarazione e definizione immagini
//      public static Bitmap cliente1 = new Bitmap(Globals.immaginiPath + "casaB.png");
        public static Bitmap cliente1 = new Bitmap(global::Negozio_di_Viola.Properties.Resources.casaB);
        public static Bitmap cl1 = new Bitmap(cliente1, new Size((int)(cliente1.Width * Globals.widthFactor), (int)(cliente1.Height * Globals.heightFactor)));
//      public static Bitmap cliente1H = new Bitmap(Globals.immaginiPath + "casaBH.png");
        public static Bitmap cliente1H = new Bitmap(global::Negozio_di_Viola.Properties.Resources.casaBH);
        public static Bitmap cl1H = new Bitmap(cliente1H, new Size((int)(cliente1H.Width * Globals.widthFactor), (int)(cliente1H.Height * Globals.heightFactor)));
//      public static Bitmap cliente1Mouse = new Bitmap(Globals.immaginiPath + "casaBBH.png");
        public static Bitmap cliente1Mouse = new Bitmap(global::Negozio_di_Viola.Properties.Resources.casaBBH);
        public static Bitmap cl1M = new Bitmap(cliente1Mouse, new Size((int)(cliente1Mouse.Width * Globals.widthFactor), (int)(cliente1Mouse.Height * Globals.heightFactor)));

//      public static Bitmap cliente2 = new Bitmap(Globals.immaginiPath + "casaG.png");
        public static Bitmap cliente2 = new Bitmap(global::Negozio_di_Viola.Properties.Resources.casaG);
        public static Bitmap cl2 = new Bitmap(cliente2, new Size((int)(cliente2.Width * Globals.widthFactor), (int)(cliente2.Height * Globals.heightFactor)));
//      public static Bitmap cliente2H = new Bitmap(Globals.immaginiPath + "casaGH.png");
        public static Bitmap cliente2H = new Bitmap(global::Negozio_di_Viola.Properties.Resources.casaGH);
        public static Bitmap cl2H = new Bitmap(cliente2H, new Size((int)(cliente2H.Width * Globals.widthFactor), (int)(cliente2H.Height * Globals.heightFactor)));
//      public static Bitmap cliente2Mouse = new Bitmap(Globals.immaginiPath + "casaGBH.png");
        public static Bitmap cliente2Mouse = new Bitmap(global::Negozio_di_Viola.Properties.Resources.casaGBH);
        public static Bitmap cl2M = new Bitmap(cliente2Mouse, new Size((int)(cliente2Mouse.Width * Globals.widthFactor), (int)(cliente2Mouse.Height * Globals.heightFactor)));

//      public static Bitmap cliente3 = new Bitmap(Globals.immaginiPath + "casaR.png");
        public static Bitmap cliente3 = new Bitmap(global::Negozio_di_Viola.Properties.Resources.casaR);
        public static Bitmap cl3 = new Bitmap(cliente3, new Size((int)(cliente3.Width * Globals.widthFactor), (int)(cliente3.Height * Globals.heightFactor)));
//      public static Bitmap cliente3H = new Bitmap(Globals.immaginiPath + "casaRH.png");
        public static Bitmap cliente3H = new Bitmap(global::Negozio_di_Viola.Properties.Resources.casaRH);
        public static Bitmap cl3H = new Bitmap(cliente3H, new Size((int)(cliente3H.Width * Globals.widthFactor), (int)(cliente3H.Height * Globals.heightFactor)));
//      public static Bitmap cliente3Mouse = new Bitmap(Globals.immaginiPath + "casaRBH.png");
        public static Bitmap cliente3Mouse = new Bitmap(global::Negozio_di_Viola.Properties.Resources.casaRBH);
        public static Bitmap cl3M = new Bitmap(cliente3Mouse, new Size((int)(cliente3Mouse.Width * Globals.widthFactor), (int)(cliente3Mouse.Height * Globals.heightFactor)));

//      public static Bitmap negViola = new Bitmap(Globals.immaginiPath + "negozioN.png");
        public static Bitmap negViola = new Bitmap(global::Negozio_di_Viola.Properties.Resources.negozioN);
        public static Bitmap neg = new Bitmap(negViola, new Size((int)(negViola.Width * Globals.widthFactor), (int)(negViola.Height * Globals.heightFactor)));
//      public static Bitmap negozioH = new Bitmap(Globals.immaginiPath + "negozioH.png");
        public static Bitmap negozioH = new Bitmap(global::Negozio_di_Viola.Properties.Resources.negozioH);
        public static Bitmap negH = new Bitmap(negozioH, new Size((int)(negozioH.Width * Globals.widthFactor), (int)(negozioH.Height * Globals.heightFactor)));
//      public static Bitmap negozioMouse = new Bitmap(Globals.immaginiPath + "negozioBH.png");
        public static Bitmap negozioMouse = new Bitmap(global::Negozio_di_Viola.Properties.Resources.negozioBH);
        public static Bitmap negM = new Bitmap(negozioMouse, new Size((int)(negozioH.Width * Globals.widthFactor), (int)(negozioH.Height * Globals.heightFactor)));


//      public static Bitmap fabbrica = new Bitmap(Globals.immaginiPath + "fabbricaN.png");
        public static Bitmap fabbrica = new Bitmap(global::Negozio_di_Viola.Properties.Resources.fabbricaN);
        public static Bitmap fab= new Bitmap(fabbrica, new Size((int)(fabbrica.Width * Globals.widthFactor), (int)(fabbrica.Height * Globals.heightFactor)));
//      public static Bitmap fabbricaH = new Bitmap(Globals.immaginiPath + "fabbricaH.png");
        public static Bitmap fabbricaH = new Bitmap(global::Negozio_di_Viola.Properties.Resources.fabbricaH);
        public static Bitmap fabH = new Bitmap(fabbricaH, new Size((int)(fabbricaH.Width * Globals.widthFactor), (int)(fabbricaH.Height * Globals.heightFactor)));
//      public static Bitmap fabbricaMouse = new Bitmap(Globals.immaginiPath + "fabbricaBH.png");
        public static Bitmap fabbricaMouse = new Bitmap(global::Negozio_di_Viola.Properties.Resources.fabbricaBH);
        public static Bitmap fabM = new Bitmap(fabbricaMouse, new Size((int)(fabbrica.Width * Globals.widthFactor), (int)(fabbrica.Height * Globals.heightFactor)));

    }
}
