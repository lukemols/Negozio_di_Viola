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
    public partial class NonSo : Form
    {
        int page;
        
        NonSo nonSo;

	double guadagno, spesa, risp, val_4;

	bool pagina_ok = false;

        static int current_page;

        static int[] val_porta_1 = new int[6];       // Situazione iniziale, prima che Viola vada in fabbrica.
        static int[] val_porta_2 = new int[6];       // Situazione dopo l'acquisto delle scarpe in fabbrica.
        static int[] val_porta_3 = new int[6];       // Situazione dopo la vendita delle scarpe al cliente.
        static int[] val_porta_4 = new int[6];       // 

	static int porta_start = 0;

        public NonSo(int p)
        {
            page = current_page = p;

            if(page > 0) //XXXXXXXXXXXXXXXXXXXXXXXXXXXXx
            {
	        Globals.soldiDopoVendita = Globals.soldiDopo + Globals.scarpe.PrezzoVendita;
	        soldiPostNegozio = Globals.soldiDopoVendita.ToString("0.00");
            }

            InitializeComponent();

            MyInitializeComponent();

            AdattamentoRisoluzione();

            Visualizzazione();
        }

        private void AdattamentoRisoluzione()
        {
            int screen_Height = Screen.PrimaryScreen.Bounds.Height;
            int screen_Width = Screen.PrimaryScreen.Bounds.Width;

            double widthFactor = (double) screen_Width / this.Size.Width;
            double heightFactor = (double) screen_Height / this.Size.Height;

            if(page == 1)
            {

                si.Width = (int)(si.Width * widthFactor);
                si.Height = (int)(si.Height * heightFactor);
                si.Location = new Point((int)(si.Location.X * widthFactor), (int)(si.Location.Y * heightFactor));
                si.Font = new Font("Verdana", (float)widthFactor * 20F, FontStyle.Bold);
                si.Click += new System.EventHandler(this.OnClick);
                si.Visible = true;

                no.Width = (int)(no.Width * widthFactor);
                no.Height = (int)(no.Height * heightFactor);
                no.Location = new Point((int)(no.Location.X * widthFactor), (int)(no.Location.Y * heightFactor));
                no.Font = new Font("Verdana", (float)widthFactor * 20F, FontStyle.Bold);
                no.Click += new System.EventHandler(this.OnClick);
                no.Visible = true;

                ok_1.Width = (int)(ok_1.Width * widthFactor);
                ok_1.Height = (int)(ok_1.Height * heightFactor);
                ok_1.Location = new Point((int)(ok_1.Location.X * widthFactor), (int)(ok_1.Location.Y * heightFactor));
                ok_1.Font = new Font("Verdana", (float)widthFactor * 20F, FontStyle.Bold);
                ok_1.Click += new System.EventHandler(this.OnClick);
                ok_1.Visible = true;

                ok_2.Visible = false;

                ok_3.Visible = false;

                risposta.Visible = false;

            }

            else if(page == 2)
            {
                si.Visible = false;

                no.Visible = false;

                ok_1.Visible = false;

                ok_2.Width = (int)(ok_2.Width * widthFactor);
                ok_2.Height = (int)(ok_2.Height * heightFactor);
                ok_2.Location = new Point((int)(ok_2.Location.X * widthFactor), (int)(ok_2.Location.Y * heightFactor));
                ok_2.Font = new Font("Verdana", (float)widthFactor * 20F, FontStyle.Bold);
                ok_2.Click += new System.EventHandler(this.OnClick);
                ok_2.Visible = true;

                ok_3.Width = (int)(ok_3.Width * widthFactor);
                ok_3.Height = (int)(ok_3.Height * heightFactor);
                ok_3.Location = new Point((int)(ok_3.Location.X * widthFactor), (int)(ok_3.Location.Y * heightFactor));
                ok_3.Font = new Font("Verdana", (float)widthFactor * 20F, FontStyle.Bold);
                ok_3.Click += new System.EventHandler(this.OnClick);
                ok_3.Visible = false;

                risposta.Width = (int)(risposta.Width * widthFactor);
                risposta.Height = (int)(risposta.Height * heightFactor);
                risposta.Location = new Point((int)(risposta.Location.X * widthFactor), (int)(risposta.Location.Y * heightFactor));
                risposta.Font = new Font("Verdana", (float)widthFactor * 20F, FontStyle.Bold);
                risposta.Visible = false;

            }

            else if(page == 3)
            {
                si.Visible = false;

                no.Visible = false;

                ok_1.Visible = false;

                ok_2.Width = (int)(ok_2.Width * widthFactor);
                ok_2.Height = (int)(ok_2.Height * heightFactor);
                ok_2.Location = new Point((int)(ok_2.Location.X * widthFactor), (int)(ok_2.Location.Y * heightFactor));
                ok_2.Font = new Font("Verdana", (float)widthFactor * 20F, FontStyle.Bold);
                ok_2.Click += new System.EventHandler(this.OnClick);
                ok_2.Visible = true;

                ok_3.Width = (int)(ok_3.Width * widthFactor);
                ok_3.Height = (int)(ok_3.Height * heightFactor);
                ok_3.Location = new Point((int)(ok_3.Location.X * widthFactor), (int)(ok_3.Location.Y * heightFactor));
                ok_3.Font = new Font("Verdana", (float)widthFactor * 20F, FontStyle.Bold);
                ok_3.Click += new System.EventHandler(this.OnClick);
                ok_3.Visible = false;

                risposta.Width = (int)(risposta.Width * widthFactor);
                risposta.Height = (int)(risposta.Height * heightFactor);
                risposta.Location = new Point((int)(risposta.Location.X * widthFactor), (int)(risposta.Location.Y * heightFactor));
                risposta.Font = new Font("Verdana", (float)widthFactor * 20F, FontStyle.Bold);
                risposta.Visible = false;

            }

            menu.Width = (int)(menu.Width * widthFactor);
            menu.Height = (int)(menu.Height * heightFactor);
            menu.Location = new Point((int)(menu.Location.X * widthFactor), (int)(menu.Location.Y * heightFactor));
            menu.Font = new Font("Verdana", (float)widthFactor * 20F, FontStyle.Bold);

            avanti.Width = (int)(avanti.Width * widthFactor);
            avanti.Height = (int)(avanti.Height * heightFactor);
            avanti.Location = new Point((int)(avanti.Location.X * widthFactor), (int)(avanti.Location.Y * heightFactor));
            avanti.Font = new Font("Verdana", (float)widthFactor * 20F, FontStyle.Bold);

            Titolo.Width = (int)(Titolo.Width * widthFactor);
            Titolo.Height = (int)(Titolo.Height * heightFactor);
            Titolo.Location = new Point((int)(Titolo.Location.X * widthFactor), (int)(Titolo.Location.Y * heightFactor));
            Titolo.Font = new Font("Verdana", (float)widthFactor * 45F, FontStyle.Bold);

            pbViola.Width = (int)(pbViola.Width * widthFactor);
            pbViola.Height = (int)(pbViola.Height * heightFactor);
            pbViola.Location = new Point((int)(pbViola.Location.X * widthFactor), (int)(pbViola.Location.Y * heightFactor));

            smile.Width = (int)(smile.Width * widthFactor);
            smile.Height = (int)(smile.Height * heightFactor);
            smile.Location = new Point((int)(smile.Location.X * widthFactor), (int)(smile.Location.Y * heightFactor));

            nosmile.Width = (int)(nosmile.Width * widthFactor);
            nosmile.Height = (int)(nosmile.Height * heightFactor);
            nosmile.Location = new Point((int)(nosmile.Location.X * widthFactor), (int)(nosmile.Location.Y * heightFactor));

            smile2.Width = (int)(smile2.Width * widthFactor);
            smile2.Height = (int)(smile2.Height * heightFactor);
            smile2.Location = new Point((int)(smile2.Location.X * widthFactor), (int)(smile2.Location.Y * heightFactor));

            nosmile2.Width = (int)(nosmile2.Width * widthFactor);
            nosmile2.Height = (int)(nosmile2.Height * heightFactor);
            nosmile2.Location = new Point((int)(nosmile2.Location.X * widthFactor), (int)(nosmile2.Location.Y * heightFactor));

            testo.Width = (int)(testo.Width * widthFactor);
            testo.Height = (int)(testo.Height * heightFactor);
            testo.Location = new Point((int)(testo.Location.X * widthFactor), (int)(testo.Location.Y * heightFactor));
            testo.Font = new Font("Verdana", (float)widthFactor * 18F, FontStyle.Bold);

            testo2.Width = (int)(testo2.Width * widthFactor);
            testo2.Height = (int)(testo2.Height * heightFactor);
            testo2.Location = new Point((int)(testo2.Location.X * widthFactor), (int)(testo2.Location.Y * heightFactor));
            testo2.Font = new Font("Verdana", (float)widthFactor * 18F, FontStyle.Bold);

            portafoglio.Width = (int)(portafoglio.Width * widthFactor);
            portafoglio.Height = (int)(portafoglio.Height * heightFactor);
            portafoglio.Location = new Point((int)(portafoglio.Location.X * widthFactor), (int)(portafoglio.Location.Y * heightFactor));
            portafoglio.Font = new Font("Verdana", (float)widthFactor * 18F, FontStyle.Bold);

            scaffale.Width = (int)(scaffale.Width * widthFactor);
            scaffale.Height = (int)(scaffale.Height * heightFactor);
            scaffale.Location = new Point((int)(scaffale.Location.X * widthFactor), (int)(scaffale.Location.Y * heightFactor));
            scaffale.Font = new Font("Verdana", (float)widthFactor * 18F, FontStyle.Bold);

            fase_1.Width = (int)(fase_1.Width * widthFactor);
            fase_1.Height = (int)(fase_1.Height * heightFactor);
            fase_1.Location = new Point((int)(fase_1.Location.X * widthFactor), (int)(fase_1.Location.Y * heightFactor));
            fase_1.Font = new Font("Verdana", (float)widthFactor * 18F, FontStyle.Bold);

            fase_2.Width = (int)(fase_2.Width * widthFactor);
            fase_2.Height = (int)(fase_2.Height * heightFactor);
            fase_2.Location = new Point((int)(fase_2.Location.X * widthFactor), (int)(fase_2.Location.Y * heightFactor));
            fase_2.Font = new Font("Verdana", (float)widthFactor * 18F, FontStyle.Bold);

            fase_3.Width = (int)(fase_3.Width * widthFactor);
            fase_3.Height = (int)(fase_3.Height * heightFactor);
            fase_3.Location = new Point((int)(fase_3.Location.X * widthFactor), (int)(fase_3.Location.Y * heightFactor));
            fase_3.Font = new Font("Verdana", (float)widthFactor * 18F, FontStyle.Bold);

            scaff_11.Width = (int)(scaff_11.Width * widthFactor);
            scaff_11.Height = (int)(scaff_11.Height * heightFactor);
            scaff_11.Location = new Point((int)(scaff_11.Location.X * widthFactor), (int)(scaff_11.Location.Y * heightFactor));
            scaff_11.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);
            lscaff_11.Width = (int)(lscaff_11.Width * widthFactor);
            lscaff_11.Height = (int)(lscaff_11.Height * heightFactor);
            lscaff_11.Location = new Point((int)(lscaff_11.Location.X * widthFactor), (int)(lscaff_11.Location.Y * heightFactor));
            lscaff_11.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            scaff_12.Width = (int)(scaff_12.Width * widthFactor);
            scaff_12.Height = (int)(scaff_12.Height * heightFactor);
            scaff_12.Location = new Point((int)(scaff_12.Location.X * widthFactor), (int)(scaff_12.Location.Y * heightFactor));
            scaff_12.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);
            lscaff_12.Width = (int)(lscaff_12.Width * widthFactor);
            lscaff_12.Height = (int)(lscaff_12.Height * heightFactor);
            lscaff_12.Location = new Point((int)(lscaff_12.Location.X * widthFactor), (int)(lscaff_12.Location.Y * heightFactor));
            lscaff_12.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            scaff_13.Width = (int)(scaff_13.Width * widthFactor);
            scaff_13.Height = (int)(scaff_13.Height * heightFactor);
            scaff_13.Location = new Point((int)(scaff_13.Location.X * widthFactor), (int)(scaff_13.Location.Y * heightFactor));
            scaff_13.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);
            lscaff_13.Width = (int)(lscaff_13.Width * widthFactor);
            lscaff_13.Height = (int)(lscaff_13.Height * heightFactor);
            lscaff_13.Location = new Point((int)(lscaff_13.Location.X * widthFactor), (int)(lscaff_13.Location.Y * heightFactor));
            lscaff_13.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            scaff_21.Width = (int)(scaff_21.Width * widthFactor);
            scaff_21.Height = (int)(scaff_21.Height * heightFactor);
            scaff_21.Location = new Point((int)(this.scaff_21.Location.X * widthFactor), (int)(this.scaff_21.Location.Y * heightFactor));
            scaff_21.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);
            scaff_21.Image = Globals.pictureBoxacq.Image; //MOD Globals.scarpe.Immagine;
            scaff_21.Visible = true;
            lscaff_21.Width = (int)(lscaff_21.Width * widthFactor);
            lscaff_21.Height = (int)(lscaff_21.Height * heightFactor);
            lscaff_21.Location = new Point((int)(this.lscaff_21.Location.X * widthFactor), (int)(this.lscaff_21.Location.Y * heightFactor));
            lscaff_21.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);
            lscaff_21.Text = Globals.prAcquisto;
            lscaff_21.Visible = true;

            scaff_22.Width = (int)(scaff_22.Width * widthFactor);
            scaff_22.Height = (int)(scaff_22.Height * heightFactor);
            scaff_22.Location = new Point((int)(scaff_22.Location.X * widthFactor), (int)(scaff_22.Location.Y * heightFactor));
            scaff_22.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);
            lscaff_22.Width = (int)(lscaff_22.Width * widthFactor);
            lscaff_22.Height = (int)(lscaff_22.Height * heightFactor);
            lscaff_22.Location = new Point((int)(lscaff_22.Location.X * widthFactor), (int)(lscaff_22.Location.Y * heightFactor));
            lscaff_22.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            scaff_23.Width = (int)(scaff_23.Width * widthFactor);
            scaff_23.Height = (int)(scaff_23.Height * heightFactor);
            scaff_23.Location = new Point((int)(scaff_23.Location.X * widthFactor), (int)(scaff_23.Location.Y * heightFactor));
            scaff_23.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);
            lscaff_23.Width = (int)(lscaff_23.Width * widthFactor);
            lscaff_23.Height = (int)(lscaff_23.Height * heightFactor);
            lscaff_23.Location = new Point((int)(lscaff_23.Location.X * widthFactor), (int)(lscaff_23.Location.Y * heightFactor));
            lscaff_23.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            scaff_31.Width = (int)(scaff_31.Width * widthFactor);
            scaff_31.Height = (int)(scaff_31.Height * heightFactor);
            scaff_31.Location = new Point((int)(scaff_31.Location.X * widthFactor), (int)(scaff_31.Location.Y * heightFactor));
            scaff_31.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);
            lscaff_31.Width = (int)(lscaff_31.Width * widthFactor);
            lscaff_31.Height = (int)(lscaff_31.Height * heightFactor);
            lscaff_31.Location = new Point((int)(lscaff_31.Location.X * widthFactor), (int)(lscaff_31.Location.Y * heightFactor));
            lscaff_31.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            scaff_32.Width = (int)(scaff_32.Width * widthFactor);
            scaff_32.Height = (int)(scaff_32.Height * heightFactor);
            scaff_32.Location = new Point((int)(scaff_32.Location.X * widthFactor), (int)(scaff_32.Location.Y * heightFactor));
            scaff_32.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);
            lscaff_32.Width = (int)(lscaff_32.Width * widthFactor);
            lscaff_32.Height = (int)(lscaff_32.Height * heightFactor);
            lscaff_32.Location = new Point((int)(lscaff_32.Location.X * widthFactor), (int)(lscaff_32.Location.Y * heightFactor));
            lscaff_32.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            scaff_33.Width = (int)(scaff_33.Width * widthFactor);
            scaff_33.Height = (int)(scaff_33.Height * heightFactor);
            scaff_33.Location = new Point((int)(scaff_33.Location.X * widthFactor), (int)(scaff_33.Location.Y * heightFactor));
            scaff_33.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);
            lscaff_33.Width = (int)(lscaff_33.Width * widthFactor);
            lscaff_33.Height = (int)(lscaff_33.Height * heightFactor);
            lscaff_33.Location = new Point((int)(lscaff_33.Location.X * widthFactor), (int)(lscaff_33.Location.Y * heightFactor));
            lscaff_33.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            picture_scaff_1.Width = (int)(picture_scaff_1.Width * widthFactor);
            picture_scaff_1.Height = (int)(picture_scaff_1.Height * heightFactor);
            picture_scaff_1.Location = new Point((int)(picture_scaff_1.Location.X * widthFactor), (int)(picture_scaff_1.Location.Y * heightFactor));
            picture_scaff_1.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            picture_scaff_2.Width = (int)(picture_scaff_2.Width * widthFactor);
            picture_scaff_2.Height = (int)(picture_scaff_2.Height * heightFactor);
            picture_scaff_2.Location = new Point((int)(this.picture_scaff_2.Location.X * widthFactor), (int)(this.picture_scaff_2.Location.Y * heightFactor));
            picture_scaff_2.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            picture_scaff_3.Width = (int)(picture_scaff_3.Width * widthFactor);
            picture_scaff_3.Height = (int)(picture_scaff_3.Height * heightFactor);
            picture_scaff_3.Location = new Point((int)(picture_scaff_3.Location.X * widthFactor), (int)(picture_scaff_3.Location.Y * heightFactor));
            picture_scaff_3.Font = new Font("Verdana", (float)widthFactor * 16F, FontStyle.Bold);

            porta_1.Width = (int)(porta_1.Width * widthFactor);
            porta_1.Height = (int)(porta_1.Height * heightFactor);
            porta_1.Location = new Point((int)(this.porta_1.Location.X * widthFactor), (int)(this.porta_1.Location.Y * heightFactor));

            porta_2.Width = (int)(porta_2.Width * widthFactor);
            porta_2.Height = (int)(porta_2.Height * heightFactor);
            porta_2.Location = new Point((int)(this.porta_2.Location.X * widthFactor), (int)(this.porta_2.Location.Y * heightFactor));

            porta_3.Width = (int)(porta_3.Width * widthFactor);
            porta_3.Height = (int)(porta_3.Height * heightFactor);
            porta_3.Location = new Point((int)(this.porta_3.Location.X * widthFactor), (int)(this.porta_3.Location.Y * heightFactor));

            porta_4.Width = (int)(porta_4.Width * widthFactor);
            porta_4.Height = (int)(porta_4.Height * heightFactor);
            porta_4.Location = new Point((int)(this.porta_4.Location.X * widthFactor), (int)(this.porta_4.Location.Y * heightFactor));

            label_11.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            label_12.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            label_13.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            label_14.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            label_15.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            label_16.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            label_21.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            label_22.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            label_23.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            label_24.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            label_25.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            label_26.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            label_31.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            label_32.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            label_33.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            label_34.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            label_35.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            label_36.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            label_41.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            label_42.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            label_43.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            label_44.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            label_45.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            label_46.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);

            foreach (Control c in porta_1.Controls)
            {
                c.Width = (int)(c.Width * widthFactor);
                c.Height = (int)(c.Height * heightFactor);
                c.Location = new Point((int)(c.Location.X * widthFactor), (int)(c.Location.Y * heightFactor));
            }

            foreach (Control c in porta_2.Controls)
            {
                c.Width = (int)(c.Width * widthFactor);
                c.Height = (int)(c.Height * heightFactor);
                c.Location = new Point((int)(c.Location.X * widthFactor), (int)(c.Location.Y * heightFactor));
            }

            foreach (Control c in porta_3.Controls)
            {
                c.Width = (int)(c.Width * widthFactor);
                c.Height = (int)(c.Height * heightFactor);
                c.Location = new Point((int)(c.Location.X * widthFactor), (int)(c.Location.Y * heightFactor));
            }

            foreach (Control c in porta_4.Controls)
            {
                c.Width = (int)(c.Width * widthFactor);
                c.Height = (int)(c.Height * heightFactor);
                c.Location = new Point((int)(c.Location.X * widthFactor), (int)(c.Location.Y * heightFactor));
            }

        }


        private void MyInitializeComponent()
        {

            if(page == 1)
            {
            }

            else if ((page == 2) || (page == 3))
            {
            }

            this.SuspendLayout();

        // Visualizzazione soldi in panels porta_1,2,3

 	    Globals.Inizializza_soldiImg();
	    string spaziprima = " ";

            for (int i = 0; i < 6; i++)
            {
                val_porta_1[i] = Globals.pFase1[i];
                val_porta_2[i] = Globals.pFase2[i];
                val_porta_3[i] = Globals.pFase3[i];
                val_porta_4[i] = 0;
            }

	//porta_1
            if (Globals.pFase1[0] == 0)
            {
                porta_11.Visible = false;
                label_11.Visible = false;
            }
            else
            {
                porta_11.Image = Globals.soldiImg[0];
                if(Globals.pFase1[0] > 0)
                    label_11.Text = spaziprima + Globals.pFase1[0].ToString();
		else
                    label_11.Text = spaziprima;
                porta_11.Visible = true;
                label_11.Visible = true;
            }

            if (Globals.pFase1[1] == 0)
            {
                porta_12.Visible = false;
                label_12.Visible = false;
            }
            else
            {
                porta_12.Image = Globals.soldiImg[1];
                if(Globals.pFase1[1] > 0)
                    label_12.Text = spaziprima + Globals.pFase1[1].ToString();
		else
                    label_12.Text = spaziprima;
                porta_12.Visible = true;
                label_12.Visible = true;
            }

            if (Globals.pFase1[2] == 0)
            {
                porta_13.Visible = false;
                label_13.Visible = false;
            }
            else
            {
                porta_13.Image = Globals.soldiImg[2];
                if(Globals.pFase1[2] > 0)
                    label_13.Text = spaziprima + Globals.pFase1[2].ToString();
		else
                    label_13.Text = spaziprima;
                porta_13.Visible = true;
                label_13.Visible = true;
            }

            if (Globals.pFase1[3] == 0)
            {
                porta_14.Visible = false;
                label_14.Visible = false;
            }
            else
            {
                porta_14.Image = Globals.soldiImg[3];
                if(Globals.pFase1[3] > 0)
                    label_14.Text = spaziprima + Globals.pFase1[3].ToString();
		else
                    label_14.Text = spaziprima;
                porta_14.Visible = true;
                label_14.Visible = true;
            }

            if (Globals.pFase1[4] == 0)
            {
                porta_15.Visible = false;
                label_15.Visible = false;
            }
            else
            {
                porta_15.Image = Globals.soldiImg[4];
                if(Globals.pFase1[4] > 0)
                    label_15.Text = spaziprima + Globals.pFase1[4].ToString();
		else
                    label_15.Text = spaziprima;
                porta_15.Visible = true;
                label_15.Visible = true;
            }

            if (Globals.pFase1[5] == 0)
            {
                porta_16.Visible = false;
                label_16.Visible = false;
            }
            else
            {
                porta_16.Image = Globals.soldiImg[5];
                if(Globals.pFase1[5] > 0)
                    label_16.Text = spaziprima + Globals.pFase1[5].ToString();
		else
                    label_16.Text = spaziprima;
                porta_16.Visible = true;
                label_16.Visible = true;
            }


	//porta_2  attualmente inattivo (no soldi)

            if (Globals.pFase2[0] == 0)
            {
                porta_21.Visible = false;
                label_21.Visible = false;
            }
            else
            {
                porta_21.Image = Globals.soldiImg[0];
                if(Globals.pFase2[0] > 0)
                    label_21.Text = spaziprima + Globals.pFase2[0].ToString();
		else
                    label_21.Text = spaziprima;
                porta_21.Visible = true;
                label_21.Visible = true;
            }

            if (Globals.pFase2[1] == 0)
            {
                porta_22.Visible = false;
                label_22.Visible = false;
            }
            else
            {
                porta_22.Image = Globals.soldiImg[1];
                if(Globals.pFase2[1] > 0)
                    label_22.Text = spaziprima + Globals.pFase2[1].ToString();
		else
                    label_22.Text = spaziprima;
                porta_22.Visible = true;
                label_22.Visible = true;
            }

            if (Globals.pFase2[2] == 0)
            {
                porta_23.Visible = false;
                label_23.Visible = false;
            }
            else
            {
                porta_23.Image = Globals.soldiImg[2];
                if(Globals.pFase2[2] > 0)
                    label_23.Text = spaziprima + Globals.pFase2[2].ToString();
		else
                    label_23.Text = spaziprima;
                porta_23.Visible = true;
                label_23.Visible = true;
            }

            if (Globals.pFase2[3] == 0)
            {
                porta_24.Visible = false;
                label_24.Visible = false;
            }
            else
            {
                porta_24.Image = Globals.soldiImg[3];
                if(Globals.pFase2[3] > 0)
                    label_24.Text = spaziprima + Globals.pFase2[3].ToString();
		else
                    label_24.Text = spaziprima;
                porta_24.Visible = true;
                label_24.Visible = true;
            }

            if (Globals.pFase2[4] == 0)
            {
                porta_25.Visible = false;
                label_25.Visible = false;
            }
            else
            {
                porta_25.Image = Globals.soldiImg[4];
                if(Globals.pFase2[4] > 0)
                    label_25.Text = spaziprima + Globals.pFase2[4].ToString();
		else
                    label_25.Text = spaziprima;
                porta_25.Visible = true;
                label_25.Visible = true;
            }

            if (Globals.pFase2[5] == 0)
            {
                porta_26.Visible = false;
                label_26.Visible = false;
            }
            else
            {
                porta_26.Image = Globals.soldiImg[5];
                if(Globals.pFase2[5] > 0)
                    label_26.Text = spaziprima + Globals.pFase2[5].ToString();
		else
                    label_26.Text = spaziprima;
                porta_26.Visible = true;
                label_26.Visible = true;
            }


	//porta_3

            if (Globals.pFase3[0] == 0)
            {
                porta_31.Visible = false;
                label_31.Visible = false;
            }
            else
            {
                porta_31.Image = Globals.soldiImg[0];
                if(Globals.pFase3[0] > 0)
                    label_31.Text = spaziprima + Globals.pFase3[0].ToString();
		else
                    label_31.Text = spaziprima;
                porta_31.Visible = true;
                label_31.Visible = true;
            }

            if (Globals.pFase3[1] == 0)
            {
                porta_32.Visible = false;
                label_32.Visible = false;
            }
            else
            {
                porta_32.Image = Globals.soldiImg[1];
                if(Globals.pFase3[1] > 0)
                    label_32.Text = spaziprima + Globals.pFase3[1].ToString();
		else
                    label_32.Text = spaziprima;
                porta_32.Visible = true;
                label_32.Visible = true;
            }

            if (Globals.pFase3[2] == 0)
            {
                porta_33.Visible = false;
                label_33.Visible = false;
            }
            else
            {
                porta_33.Image = Globals.soldiImg[2];
                if(Globals.pFase3[2] > 0)
                    label_33.Text = spaziprima + Globals.pFase3[2].ToString();
		else
                    label_33.Text = spaziprima;
                porta_33.Visible = true;
                label_33.Visible = true;
            }

            if (Globals.pFase3[3] == 0)
            {
                porta_34.Visible = false;
                label_34.Visible = false;
            }
            else
            {
                porta_34.Image = Globals.soldiImg[3];
                if(Globals.pFase3[3] > 0)
                    label_34.Text = spaziprima + Globals.pFase3[3].ToString();
		else
                    label_34.Text = spaziprima;
                porta_34.Visible = true;
                label_34.Visible = true;
            }

            if (Globals.pFase3[4] == 0)
            {
                porta_35.Visible = false;
                label_35.Visible = false;
            }
            else
            {
                porta_35.Image = Globals.soldiImg[4];
                if(Globals.pFase3[4] > 0)
                    label_35.Text = spaziprima + Globals.pFase3[4].ToString();
		else
                    label_35.Text = spaziprima;
                porta_35.Visible = true;
                label_35.Visible = true;
            }

            if (Globals.pFase3[5] == 0)
            {
                porta_36.Visible = false;
                label_36.Visible = false;
            }
            else
            {
                porta_36.Image = Globals.soldiImg[5];
                if(Globals.pFase3[5] > 0)
                    label_36.Text = spaziprima + Globals.pFase3[5].ToString();
		else
                    label_36.Text = spaziprima;
                porta_36.Visible = true;
                label_36.Visible = true;
            }

	//porta_4

            porta_41.Image = Globals.soldiImg[0];
            label_41.Text = spaziprima;
            porta_41.Visible = false;
            label_41.Visible = false;

            porta_42.Image = Globals.soldiImg[1];
            label_42.Text = spaziprima;
            porta_42.Visible = false;
            label_42.Visible = false;

            porta_43.Image = Globals.soldiImg[2];
            label_43.Text = spaziprima;
            porta_43.Visible = false;
            label_43.Visible = false;

            porta_44.Image = Globals.soldiImg[3];
            label_44.Text = spaziprima;
            porta_44.Visible = false;
            label_44.Visible = false;

            porta_45.Image = Globals.soldiImg[4];
            label_45.Text = spaziprima;
            porta_45.Visible = false;
            label_45.Visible = false;

            porta_46.Image = Globals.soldiImg[5];
            label_46.Text = spaziprima;
            porta_46.Visible = false;
            label_46.Visible = false;


	///////////////////////////////////////////////////////////////////////////77

            if(page == 1)
            {
                this.testo.Text = "Nella situazione 3 ci sono più soldi nel portafoglio rispetto alla situazione 1?";
		this.testo.Visible = true;
		this.testo2.Visible = false;

                porta_4.Visible = false;
            }

            else if(page == 2)
            {
                this.testo.Text = "Trascina qui, dal portafoglio della situazione 3, i soldi che avevo nella situazione 1";
		this.testo.Visible = true;
                this.testo2.Text = "questi sono i soldi che hanno sostituito nel mio portafoglio quelli che ho speso alla fabbrica:";
		this.testo2.Visible = true; //XXXXXX false;

                porta_4.Visible = true;

            }

            else if(page == 3)
            {
                this.testo.Text = "Trascina qui, dal portafoglio della situazione 3, i soldi che non avevo nella situazione 1";
		this.testo.Visible = true;
                this.testo2.Text = "questo è il guadagno che ho fatto per il lavoro di vendere le scarpe! Scrivi qui l'importo:";
		this.testo2.Visible = true; //XXXXXX false;

                porta_4.Visible = true;

            }

            else if(page == 4)
            {
	// DA IMPLEMENTARE
            }


            // 
            // NonSo
            // 

/****************************** XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX ******************************
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1044, 620);
       //?? this.Controls.Add(this.tabella);
            if(page > 3)
            {
                this.Controls.Add(risposta);
                this.KeyPreview = true;
                this.KeyPress += new KeyPressEventHandler(aKeyPress);
            }
 ****************************** XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX ******************************/

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NonSo";
            this.Text = "Portafoglio-cassa di Viola";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.ResumeLayout(false);
        }



        private void Visualizzazione()
        {
            this.BackColor = Color.FromName(Globals.PANEL_BACKGROUND);

            this.avanti.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
	    this.menu.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
	    this.si.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
	    this.no.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND); 
            this.ok_1.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
	    this.ok_2.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
	    this.ok_3.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);

            this.lscaff_11.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.lscaff_21.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.lscaff_31.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.lscaff_12.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.lscaff_22.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.lscaff_32.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.lscaff_13.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.lscaff_23.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.lscaff_33.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);

            this.lscaff_11.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.lscaff_21.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.lscaff_31.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.lscaff_12.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.lscaff_22.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.lscaff_32.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.lscaff_13.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.lscaff_23.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.lscaff_33.ForeColor = Color.FromName(Globals.BUTTON_TEXT);

            this.avanti.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.menu.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.si.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.no.ForeColor = Color.FromName(Globals.BUTTON_TEXT); 
            this.ok_1.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.ok_2.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.ok_3.ForeColor = Color.FromName(Globals.BUTTON_TEXT);

	    this.Titolo.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.portafoglio.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.scaffale.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.fase_1.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.fase_2.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.fase_3.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.testo.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.testo2.ForeColor = Color.FromName(Globals.BUTTON_TEXT);

	    this.label_11.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.label_12.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.label_13.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.label_14.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.label_15.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.label_16.ForeColor = Color.FromName(Globals.BUTTON_TEXT);

	    this.label_21.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.label_22.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.label_23.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.label_24.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.label_25.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.label_26.ForeColor = Color.FromName(Globals.BUTTON_TEXT);

	    this.label_31.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.label_32.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.label_33.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.label_34.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.label_35.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.label_36.ForeColor = Color.FromName(Globals.BUTTON_TEXT);

	    this.label_41.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.label_42.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.label_43.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.label_44.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.label_45.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
	    this.label_46.ForeColor = Color.FromName(Globals.BUTTON_TEXT);

        }



        private void OnClick(object sender, System.EventArgs e)
        {
            if (sender is System.Windows.Forms.Button)
            {
                System.Drawing.Color highlighting_color = Color.FromName(Globals.BUTTON_BACKGROUND_OK);

                switch (((System.Windows.Forms.Button)sender).Name)
                {
                    case "menu":

                        Globals.newGame = false;
                        HomePage pagIniz = new HomePage();
                        this.Close();
                        pagIniz.ShowDialog();

                        break;

                    case "si": 


                        si.BackColor = highlighting_color;
                        no.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);

                        risUtente = "si";

                        this.ok_1.Click += new System.EventHandler(this.OnClick);

                        break;

		    case "no": 

                        no.BackColor = highlighting_color;
                        si.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);

                        risUtente = "no";
                        this.ok_1.Click += new System.EventHandler(this.OnClick);

                        break;

                    case "ok_1":

                        if(page == 1)
                        {
                            if (risUtente == "si")
                            {
                                smile.Visible = true;
                                nosmile.Visible = false;
                                smile2.Visible = false;
                                nosmile2.Visible = false;

                                pagina_ok = true;
                            }

                            else if (risUtente == "no")
                            {
                                nosmile.Visible = true;
                                smile.Visible = false;
                                smile2.Visible = false;
                                nosmile2.Visible = false;

                                pagina_ok = false;
                            }
                        }

                        break;

                    case "ok_2":

                        spesa = Globals.soldiPrima - Globals.soldiDopo;
                        guadagno = Globals.soldiDopoVendita - Globals.soldiPrima + Globals.soldiDopo;
                        val_4 = Val_porta_4();

                        if(page == 2)
                        {
                            if(spesa == val_4)
                            {
                                ok_2.Visible = false;
                                testo.Visible = true; //XXXXXX false;
                                ok_3.Visible = true;
                                testo2.Visible = true;
                                risposta.Visible = true;
                                smile.Visible = true;
                                nosmile.Visible = false;
                                smile2.Visible = false;
                                nosmile2.Visible = false;
                            }

                            else
                            {
                                nosmile.Visible = true;
                                smile.Visible = false;
                                smile2.Visible = false;
                                nosmile2.Visible = false;
                            }
                        }
			else if(page == 3)
                        {
                            if(guadagno == val_4)
                            {
                                ok_2.Visible = false;
                                testo.Visible = true; //XXXXXX false;
                                ok_3.Visible = true;
                                testo2.Visible = true;
                                risposta.Visible = true;
                                smile.Visible = true;
                                nosmile.Visible = false;
                                smile2.Visible = false;
                                nosmile2.Visible = false;
                            }

                            else
                            {
                                nosmile.Visible = true;
                                smile.Visible = false;
                                smile2.Visible = false;
                                nosmile2.Visible = false;
                            }
                        }
                        
                        break;

                    case "ok_3":

                        spesa = Globals.soldiPrima - Globals.soldiDopo;
                        guadagno = Globals.soldiDopoVendita - Globals.soldiPrima + Globals.soldiDopo;
                        val_4 = Val_porta_4();
                        risp = System.Convert.ToDouble(risposta.Text);

                        if(page == 2)
                        {
                            if(risp == val_4)
                            {
                                ok_2.Visible = false;
                                testo.Visible = true; //XXXXXX false;
                                ok_3.Visible = true;
                                testo2.Visible = true;
                                risposta.Visible = true;
                                smile2.Visible = true;
                                nosmile2.Visible = false;
                                smile.Visible = false;
                                nosmile.Visible = false;

                                pagina_ok = true;
                            }

                            else
                            {
                                nosmile2.Visible = true;
                                smile2.Visible = false;
                                smile.Visible = false;
                                nosmile.Visible = false;

                                pagina_ok = false;
                            }
                        }
			else if(page == 3)
                        {
                            if(risp == val_4)
                            {
                                ok_2.Visible = false;
                                testo.Visible = true; //XXXXXX false;
                                ok_3.Visible = true;
                                testo2.Visible = true;
                                risposta.Visible = true;
                                smile2.Visible = true;
                                nosmile2.Visible = false;
                                smile.Visible = false;
                                nosmile.Visible = false;

                                pagina_ok = true;
                            }

                            else
                            {
                                nosmile2.Visible = true;
                                smile2.Visible = false;
                                smile.Visible = false;
                                nosmile.Visible = false;

                                pagina_ok = false;
                            }
                        }

                        break;

                    case "avanti":

                        if(pagina_ok == true)
                        {
                            if(page == 1)
                            {
                          //    nonSo = new NonSo(2);
                                nonSo = new NonSo(2);
                                nonSo.ShowDialog();
                                this.Close();
                            }
                            else if(page == 2)
                            {
                                nonSo = new NonSo(3);
                                nonSo.ShowDialog();
                                this.Close();
                            }
                            else if(page == 3)
                            {
                                this.Close();
                            }
                        }

                        break;
                }
            }
        }

/* ----------------------------------------- DELETED ----------------------------------------------- *
	//
	// funzione per accumulare i char inseriti d tastiera per produrre la crifra in risposta
	// ora inutile perché l'inlut è gestito da textbox
	//
        void aKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 08 || e.KeyChar == 24 || e.KeyChar == 44 || e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                switch (e.KeyChar)
                {
                    case (char)08:          // backspace

                        if(risposta.Text.Length != 0)
                        
                            risposta.Text = risposta.Text.Substring(0, risposta.Text.Length - 1);

                        break;

                    case (char)24:          // canc

                        risposta.Clear();

                        break;

                    case (char)44:          // virgola

                        if (!risposta.Text.Contains(','))

                            risposta.Text += e.KeyChar.ToString();

                        break;

                    case (char)48:          // cifre
                    case (char)49:
                    case (char)50:
                    case (char)51:
                    case (char)52:
                    case (char)53:
                    case (char)54:
                    case (char)55:
                    case (char)56:
                    case (char)57:

                        risposta.Text += e.KeyChar.ToString();

                        break;
                }
            }
        }
 * ----------------------------------------- DELETED ----------------------------------------------- */

        private void fase_1_Click(object sender, EventArgs e)
        {

        }

        private void fase_2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void NonSo_Load(object sender, EventArgs e)
        {

        }

        private void porta_22_Click(object sender, EventArgs e)
        {

        }


        private int get_param_porta(string testo)
        {
            double newimporto = Convert.ToDouble(testo);
	    int param = 0;

            if (newimporto == 50.00)
                param = 0;
	    else if (newimporto == 20.00)
                param = 1;
	    else if (newimporto == 10.00)
                param = 2;
	    else if (newimporto == 5.00)
                param = 3;
	    else if (newimporto == 2.00)
                param = 4;
	    else if (newimporto == 1.00)
                param = 5;
	    else if (newimporto == 0.50)
                param = 6;
	    else if (newimporto == 0.20)
                param = 7;
	    else if (newimporto == 0.10)
                param = 8;
	    else if (newimporto == 0.05)
                param = 9;
	    else if (newimporto == 0.02)
                param = 10;
	    else if (newimporto == 0.01)
                param = 11;

            return param;
        }



        // **********************************   Panels porta_1,2,3 drag e drop **************************** //

        private void aggiorna_val_porta_start(int p_start, int p)
        {
            if      (p_start == 1) val_porta_1[p]--;
	    else if (p_start == 2) val_porta_2[p]--;
	    else if (p_start == 3) val_porta_3[p]--;
	    else if (p_start == 4) val_porta_4[p]--;
        }


        private void porta_1_DragOver(object sender, DragEventArgs e)
        {
//BY        if (e.Data.GetDataPresent(DataFormats.Text))
//BY            e.Effect = DragDropEffects.Copy;
//BY        else
//BY            e.Effect = DragDropEffects.None;
        }

        private void porta_1_DragDrop(object sender, DragEventArgs e)
        {
//BY        string testo = e.Data.GetData(DataFormats.Text).ToString();
//BY
//BY        int param = get_param_porta(testo);
//BY
//BY        val_porta_1[param]++;
//BY
//BY        aggiorna_val_porta_start(porta_start, param);
//BY
//BY        Def_porta_1234();
        }

        private void porta_2_DragOver(object sender, DragEventArgs e)
        {
//BY        if (e.Data.GetDataPresent(DataFormats.Text))
//BY            e.Effect = DragDropEffects.Copy;
//BY        else
//BY            e.Effect = DragDropEffects.None;
        }

        private void porta_2_DragDrop(object sender, DragEventArgs e)
        {
//BY        string testo = e.Data.GetData(DataFormats.Text).ToString();
//BY        double newimporto = Convert.ToDouble(testo);
//BY
//BY        int param = get_param_porta(testo);
//BY
//BY        val_porta_2[param]++;
//BY
//BY        aggiorna_val_porta_start(porta_start, param);
//BY
//BY        Def_porta_1234();
        }


        private void porta_3_DragOver(object sender, DragEventArgs e)
        {
            if(page == 2 || page == 3)
            {
                if (e.Data.GetDataPresent(DataFormats.Text))
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            }
        }

        private void porta_3_DragDrop(object sender, DragEventArgs e)
        {
            if(page == 2 || page == 3)
            {
                string testo = e.Data.GetData(DataFormats.Text).ToString();
                double newimporto = Convert.ToDouble(testo);

                int param = get_param_porta(testo);

                val_porta_3[param]++;

	        aggiorna_val_porta_start(porta_start, param);

                Def_porta_1234();
            }
        }
	

        private void porta_4_DragOver(object sender, DragEventArgs e)
        {
            if(page == 2 || page == 3)
            {
                if (e.Data.GetDataPresent(DataFormats.Text))
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            }
        }

        private void porta_4_DragDrop(object sender, DragEventArgs e)
        {
            if(page == 2 || page == 3)
            {
                string testo = e.Data.GetData(DataFormats.Text).ToString();
                double newimporto = Convert.ToDouble(testo);

                int param = get_param_porta(testo);

                val_porta_4[param]++;

	        aggiorna_val_porta_start(porta_start, param);

                Def_porta_1234();
            }
        }



        // set di funzioni per evitari di copiare banconote piÃ¹ volte nei vari panel

        private void porta_1_MouseHover(object sender, EventArgs e)
        {
            porta_1.AllowDrop = false;
            porta_2.AllowDrop = false;
            porta_3.AllowDrop = true;
            porta_4.AllowDrop = true;
        }

        private void porta_2_MouseHover(object sender, EventArgs e)
        {
            porta_1.AllowDrop = false;
            porta_2.AllowDrop = false;
            porta_3.AllowDrop = true;
            porta_4.AllowDrop = true;
        }

        private void porta_3_MouseHover(object sender, EventArgs e)
        {
            porta_1.AllowDrop = false;
            porta_2.AllowDrop = false;
            porta_3.AllowDrop = false;
            porta_4.AllowDrop = true;
        }

        private void porta_4_MouseHover(object sender, EventArgs e)
        {
            porta_1.AllowDrop = false;
            porta_2.AllowDrop = false;
            porta_3.AllowDrop = true;
            porta_4.AllowDrop = false;
        }

        private void porta_11_MouseHover(object sender, EventArgs e)
        {
            porta_1.AllowDrop = false;
            porta_2.AllowDrop = false;
            porta_3.AllowDrop = true;
            porta_4.AllowDrop = true;
        }

        private void porta_21_MouseHover(object sender, EventArgs e)
        {
            porta_1.AllowDrop = false;
            porta_2.AllowDrop = false;
            porta_3.AllowDrop = true;
            porta_4.AllowDrop = true;
        }

        private void porta_31_MouseHover(object sender, EventArgs e)
        {
            porta_1.AllowDrop = false;
            porta_2.AllowDrop = false;
            porta_3.AllowDrop = false;
            porta_4.AllowDrop = true;
        }

        private void porta_41_MouseHover(object sender, EventArgs e)
        {
            porta_1.AllowDrop = false;
            porta_2.AllowDrop = false;
            porta_3.AllowDrop = true;
            porta_4.AllowDrop = false;
        }

        // Picture Box Banconote Mouse Down function // // // //

        private void porta_11_MouseDown(object sender, MouseEventArgs e)
        {
/*BY
	    porta_start = 1;
            porta_11.DoDragDrop(porta_11.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_11.Cursor = System.Windows.Forms.Cursors.Hand;
  BY*/
        }      

        private void porta_12_MouseDown(object sender, MouseEventArgs e)
        {
/*BY
	    porta_start = 1;
            porta_12.DoDragDrop(porta_12.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_12.Cursor = System.Windows.Forms.Cursors.Hand;
  BY*/
        }      

        private void porta_13_MouseDown(object sender, MouseEventArgs e)
        {
/*BY
	    porta_start = 1;
            porta_13.DoDragDrop(porta_13.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_13.Cursor = System.Windows.Forms.Cursors.Hand;
  BY*/
        }      

        private void porta_14_MouseDown(object sender, MouseEventArgs e)
        {
/*BY
	    porta_start = 1;
            porta_14.DoDragDrop(porta_14.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_14.Cursor = System.Windows.Forms.Cursors.Hand;
  BY*/
        }      

        private void porta_15_MouseDown(object sender, MouseEventArgs e)
        {
/*BY
	    porta_start = 1;
            porta_15.DoDragDrop(porta_15.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_15.Cursor = System.Windows.Forms.Cursors.Hand;
  BY*/
        }      

        private void porta_16_MouseDown(object sender, MouseEventArgs e)
        {
/*BY
	    porta_start = 1;
            porta_16.DoDragDrop(porta_16.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_16.Cursor = System.Windows.Forms.Cursors.Hand;
  BY*/
        }      

        private void porta_21_MouseDown(object sender, MouseEventArgs e)
        {
/*BY
	    porta_start = 2;
            porta_21.DoDragDrop(porta_21.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_21.Cursor = System.Windows.Forms.Cursors.Hand;
  BY*/
        }      

        private void porta_22_MouseDown(object sender, MouseEventArgs e)
        {
/*BY
	    porta_start = 2;
            porta_22.DoDragDrop(porta_22.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_22.Cursor = System.Windows.Forms.Cursors.Hand;
  BY*/
        }      

        private void porta_23_MouseDown(object sender, MouseEventArgs e)
        {
/*BY
	    porta_start = 2;
            porta_23.DoDragDrop(porta_23.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_23.Cursor = System.Windows.Forms.Cursors.Hand;
  BY*/
        }      

        private void porta_24_MouseDown(object sender, MouseEventArgs e)
        {
/*BY
	    porta_start = 2;
            porta_24.DoDragDrop(porta_24.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_24.Cursor = System.Windows.Forms.Cursors.Hand;
  BY*/
        }      

        private void porta_25_MouseDown(object sender, MouseEventArgs e)
        {
/*BY
	    porta_start = 2;
            porta_25.DoDragDrop(porta_25.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_25.Cursor = System.Windows.Forms.Cursors.Hand;
  BY*/
        }      

        private void porta_26_MouseDown(object sender, MouseEventArgs e)
        {
/*BY
	    porta_start = 2;
            porta_26.DoDragDrop(porta_26.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_26.Cursor = System.Windows.Forms.Cursors.Hand;
  BY*/
        }      

        private void porta_31_MouseDown(object sender, MouseEventArgs e)
        {
	    porta_start = 3;
            porta_31.DoDragDrop(porta_31.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_31.Cursor = System.Windows.Forms.Cursors.Hand;
        }      

        private void porta_32_MouseDown(object sender, MouseEventArgs e)
        {
	    porta_start = 3;
            porta_32.DoDragDrop(porta_32.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_32.Cursor = System.Windows.Forms.Cursors.Hand;
        }      

        private void porta_33_MouseDown(object sender, MouseEventArgs e)
        {
	    porta_start = 3;
            porta_33.DoDragDrop(porta_33.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_33.Cursor = System.Windows.Forms.Cursors.Hand;
        }      

        private void porta_34_MouseDown(object sender, MouseEventArgs e)
        {
	    porta_start = 3;
            porta_34.DoDragDrop(porta_34.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_34.Cursor = System.Windows.Forms.Cursors.Hand;
        }      

        private void porta_35_MouseDown(object sender, MouseEventArgs e)
        {
	    porta_start = 3;
            porta_35.DoDragDrop(porta_35.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_35.Cursor = System.Windows.Forms.Cursors.Hand;
        }      

        private void porta_36_MouseDown(object sender, MouseEventArgs e)
        {
	    porta_start = 3;
            porta_36.DoDragDrop(porta_36.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_36.Cursor = System.Windows.Forms.Cursors.Hand;
        }      

        private void porta_41_MouseDown(object sender, MouseEventArgs e)
        {
	    porta_start = 4;
            porta_41.DoDragDrop(porta_41.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_41.Cursor = System.Windows.Forms.Cursors.Hand;
        }      

        private void porta_42_MouseDown(object sender, MouseEventArgs e)
        {
	    porta_start = 4;
            porta_42.DoDragDrop(porta_42.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_42.Cursor = System.Windows.Forms.Cursors.Hand;
        }      

        private void porta_43_MouseDown(object sender, MouseEventArgs e)
        {
	    porta_start = 4;
            porta_43.DoDragDrop(porta_43.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_43.Cursor = System.Windows.Forms.Cursors.Hand;
        }      

        private void porta_44_MouseDown(object sender, MouseEventArgs e)
        {
	    porta_start = 4;
            porta_44.DoDragDrop(porta_44.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_44.Cursor = System.Windows.Forms.Cursors.Hand;
        }      

        private void porta_45_MouseDown(object sender, MouseEventArgs e)
        {
	    porta_start = 4;
            porta_45.DoDragDrop(porta_45.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_45.Cursor = System.Windows.Forms.Cursors.Hand;
        }      

        private void porta_46_MouseDown(object sender, MouseEventArgs e)
        {
	    porta_start = 4;
            porta_46.DoDragDrop(porta_46.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_46.Cursor = System.Windows.Forms.Cursors.Hand;
        }      


        // Definisci e visualizza portafogli porta_1,2,3

        private void Def_porta_1234()
        {
	//  porta_1
            if (val_porta_1[0] == 0)
            {
                porta_11.Visible = false;
                label_11.Visible = false;
            }
            
            else
            {
                   label_11.Text = val_porta_1[0].ToString();
                   label_11.Visible = true;
                   porta_11.Visible = true;
            }

            if (val_porta_1[1] == 0)
            {
                porta_12.Visible = false;
                label_12.Visible = false;
            }

            else
            {
                label_12.Text = val_porta_1[1].ToString();
                label_12.Visible = true;
                porta_12.Visible = true;
            }

            if (val_porta_1[2] == 0)
            {
                porta_13.Visible = false;
                label_13.Visible = false;
            }

            else
            {
                label_13.Text = val_porta_1[2].ToString();
                label_13.Visible = true;
                porta_13.Visible = true;
            }

            if (val_porta_1[3] == 0)
            {
                porta_14.Visible = false;
                label_14.Visible = false;
            }

            else
            {
                label_14.Text = val_porta_1[3].ToString();
                label_14.Visible = true;
                porta_14.Visible = true;
            }


            if (val_porta_1[4] == 0)
            {
                porta_15.Visible = false;
                label_15.Visible = false;
            }

            else
            {
                label_15.Text = val_porta_1[4].ToString();
                label_15.Visible = true;
                porta_15.Visible = true;
            }

            if (val_porta_1[5] == 0)
            {
                porta_16.Visible = false;
                label_16.Visible = false;
            }

            else
            {
                label_16.Text = val_porta_1[5].ToString();
                label_16.Visible = true;
                porta_16.Visible = true;
            }


	//  porta_2
            if (val_porta_2[0] == 0)
            {
                porta_21.Visible = false;
                label_21.Visible = false;
            }
            
            else
            {
                   label_21.Text = val_porta_2[0].ToString();
                   label_21.Visible = true;
                   porta_21.Visible = true;
            }

            if (val_porta_2[1] == 0)
            {
                porta_22.Visible = false;
                label_22.Visible = false;
            }

            else
            {
                label_22.Text = val_porta_2[1].ToString();
                label_22.Visible = true;
                porta_22.Visible = true;
            }

            if (val_porta_2[2] == 0)
            {
                porta_23.Visible = false;
                label_23.Visible = false;
            }

            else
            {
                label_23.Text = val_porta_2[2].ToString();
                label_23.Visible = true;
                porta_23.Visible = true;
            }

            if (val_porta_2[3] == 0)
            {
                porta_24.Visible = false;
                label_24.Visible = false;
            }

            else
            {
                label_24.Text = val_porta_2[3].ToString();
                label_24.Visible = true;
                porta_24.Visible = true;
            }


            if (val_porta_2[4] == 0)
            {
                porta_25.Visible = false;
                label_25.Visible = false;
            }

            else
            {
                label_25.Text = val_porta_2[4].ToString();
                label_25.Visible = true;
                porta_25.Visible = true;
            }

            if (val_porta_2[5] == 0)
            {
                porta_26.Visible = false;
                label_26.Visible = false;
            }

            else
            {
                label_26.Text = val_porta_2[5].ToString();
                label_26.Visible = true;
                porta_26.Visible = true;
            }


	//  porta_3
            if (val_porta_3[0] == 0)
            {
                porta_31.Visible = false;
                label_31.Visible = false;
            }
            
            else
            {
                   label_31.Text = val_porta_3[0].ToString();
                   label_31.Visible = true;
                   porta_31.Visible = true;
            }

            if (val_porta_3[1] == 0)
            {
                porta_32.Visible = false;
                label_32.Visible = false;
            }

            else
            {
                label_32.Text = val_porta_3[1].ToString();
                label_32.Visible = true;
                porta_32.Visible = true;
            }

            if (val_porta_3[2] == 0)
            {
                porta_33.Visible = false;
                label_33.Visible = false;
            }

            else
            {
                label_33.Text = val_porta_3[2].ToString();
                label_33.Visible = true;
                porta_33.Visible = true;
            }

            if (val_porta_3[3] == 0)
            {
                porta_34.Visible = false;
                label_34.Visible = false;
            }

            else
            {
                label_34.Text = val_porta_3[3].ToString();
                label_34.Visible = true;
                porta_34.Visible = true;
            }


            if (val_porta_3[4] == 0)
            {
                porta_35.Visible = false;
                label_35.Visible = false;
            }

            else
            {
                label_35.Text = val_porta_3[4].ToString();
                label_35.Visible = true;
                porta_35.Visible = true;
            }

            if (val_porta_3[5] == 0)
            {
                porta_36.Visible = false;
                label_36.Visible = false;
            }

            else
            {
                label_36.Text = val_porta_3[5].ToString();
                label_36.Visible = true;
                porta_36.Visible = true;
            }

	
	//  porta_4
            if (val_porta_4[0] == 0)
            {
                porta_41.Visible = false;
                label_41.Visible = false;
            }
            
            else
            {
                   label_41.Text = val_porta_4[0].ToString();
                   label_41.Visible = true;
                   porta_41.Visible = true;
            }

            if (val_porta_4[1] == 0)
            {
                porta_42.Visible = false;
                label_42.Visible = false;
            }

            else
            {
                label_42.Text = val_porta_4[1].ToString();
                label_42.Visible = true;
                porta_42.Visible = true;
            }

            if (val_porta_4[2] == 0)
            {
                porta_43.Visible = false;
                label_43.Visible = false;
            }

            else
            {
                label_43.Text = val_porta_4[2].ToString();
                label_43.Visible = true;
                porta_43.Visible = true;
            }

            if (val_porta_4[3] == 0)
            {
                porta_44.Visible = false;
                label_44.Visible = false;
            }

            else
            {
                label_44.Text = val_porta_4[3].ToString();
                label_44.Visible = true;
                porta_44.Visible = true;
            }


            if (val_porta_4[4] == 0)
            {
                porta_45.Visible = false;
                label_45.Visible = false;
            }

            else
            {
                label_45.Text = val_porta_4[4].ToString();
                label_45.Visible = true;
                porta_45.Visible = true;
            }

            if (val_porta_4[5] == 0)
            {
                porta_46.Visible = false;
                label_46.Visible = false;
            }

            else
            {
                label_46.Text = val_porta_4[5].ToString();
                label_46.Visible = true;
                porta_46.Visible = true;
            }


        }


        // Definisci e visualizza portafogli porta_1,2,3

        private double Val_porta_4()
        {
            return (double) ( val_porta_4[0] * 50.00 +
                              val_porta_4[1] * 20.00 +
                              val_porta_4[2] * 10.00 +
                              val_porta_4[3] *  5.00 +
                              val_porta_4[4] *  2.00 +
                              val_porta_4[5] *  1.00  );
        }


    }
}
