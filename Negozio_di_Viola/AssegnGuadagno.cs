using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;

namespace Negozio_di_Viola
{
    public partial class AssegnGuadagno : Form
    {
        HomePage home;
        int[] array_guadagno;
        Fumetto2 fumetto2;
        int[] array_spesa_fabbrica; // pFase1 - pFase2.

        /*Array con contatori quantità banconote [50e, 20e, 10e, 5e, 2e, 1e]*/
        static int[] val_porta_1 = new int[6];       // Situazione iniziale, prima che Viola vada in fabbrica.
        static int[] val_porta_2 = new int[6];       // Banconote per il guadagno.
        static int[] val_porta_3 = new int[6];       // Banconote trascinate dall'utente (prezzo di fabbrica scarpe).
        static int[] val_porta_4 = new int[6];       // Banconote trascinate dall'utente (guadagno voluto).
        static int[] val_porta_5 = new int[6];       // Somma val_porta_3 e val_porta_4.

        static int[] inizio_porta_1 = new int[6];    // Array che conserva la situazione di val_porta_1 anche dopo che si fanno degli spostamenti di banconote. Utile per AllowDrop.
        static int[] inizio_porta_2 = new int[6];    // Array che conserva la situazione di val_porta_2 anche dopo che si fanno degli spostamenti di banconote. Utile per AllowDrop.

        static int porta_start = 0; // Porta da cui inizia il trascinamento.

        double widthFactor;
        Point location_start;
        Point location_start_3;
        Point location_start_4;
        Point location_target;

        //Costruttore form.
        public AssegnGuadagno()
        {

            array_guadagno = assegnazione_array_guadagno(Globals.prezzoConGuadagnoDinamico);
            array_spesa_fabbrica = Differeza_fasi_12();

            InitializeComponent();
            MyInitializeComponent();
            Adattamento_Risoluzione();
            Visualizzazione();
        }

        void Adattamento_Risoluzione()
        {
            int screen_Height = Screen.PrimaryScreen.Bounds.Height;
            int screen_Width = Screen.PrimaryScreen.Bounds.Width;

                   widthFactor = (double)screen_Width / this.Size.Width;
            double heightFactor = (double)screen_Height / this.Size.Height;

            this.ok_1.Width = (int)(ok_1.Width * widthFactor);
            this.ok_1.Height = (int)(ok_1.Height * heightFactor);
            this.ok_1.Location = new Point((int)(ok_1.Location.X * widthFactor), (int)(ok_1.Location.Y * heightFactor));
            this.ok_1.Font = new Font("Verdana", (float)widthFactor * 20F, FontStyle.Bold);


            this.ok_1.Visible = true;
            this.ok_2.Visible = false;

            this.ok_2.Width = (int)(ok_2.Width * widthFactor);
            this.ok_2.Height = (int)(ok_2.Height * heightFactor);
            this.ok_2.Location = new Point((int)(ok_2.Location.X * widthFactor), (int)(ok_2.Location.Y * heightFactor));
            this.ok_2.Font = new Font("Verdana", (float)widthFactor * 20F, FontStyle.Bold);

            this.domanda.Width = (int)(domanda.Width * widthFactor);
            this.domanda.Height = (int)(domanda.Height * heightFactor);
            this.domanda.Location = new Point((int)(domanda.Location.X * widthFactor), (int)(domanda.Location.Y * heightFactor));
            this.domanda.Font = new Font("Verdana", (float)widthFactor * 18F, FontStyle.Bold);

            this.risposta.Width = (int)(this.risposta.Width * widthFactor);
            this.risposta.Height = (int)(this.risposta.Height * widthFactor);
            this.risposta.Font = new System.Drawing.Font("Verdana", (float)widthFactor * 28F, FontStyle.Bold);
            this.risposta.Location = new Point((int)(this.risposta.Location.X * widthFactor), (int)(this.risposta.Location.Y * heightFactor));

            this.InsNumero.Width = (int)(InsNumero.Width * widthFactor);
            this.InsNumero.Height = (int)(InsNumero.Height * heightFactor);
            this.InsNumero.Location = new Point((int)(InsNumero.Location.X * widthFactor), (int)(InsNumero.Location.Y * heightFactor));
            this.InsNumero.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);

            this.sicuro.Width = (int)(sicuro.Width * widthFactor);
            this.sicuro.Height = (int)(sicuro.Height * heightFactor);
            this.sicuro.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.sicuro.Location = new Point((int)((porta_3.Location.X + 2) * widthFactor), (int)((porta_3.Location.Y + porta_3.Height - sicuro.Height - 2) * heightFactor));
            this.sicuro.BackColor = Color.Tomato;
            this.sicuro.FlatAppearance.MouseOverBackColor = Color.Tomato;

            this.sicuro2.Width = (int)(sicuro2.Width * widthFactor);
            this.sicuro2.Height = (int)(sicuro2.Height * heightFactor);
            this.sicuro2.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.sicuro2.Location = new Point((int)((porta_4.Location.X + 2) * widthFactor), (int)((porta_4.Location.Y + porta_4.Height - sicuro2.Height - 2) * heightFactor));
            this.sicuro2.BackColor = Color.Lime;
            this.sicuro2.FlatAppearance.MouseOverBackColor = Color.Lime;

            this.buttonMenu.Width = (int)(buttonMenu.Width * widthFactor);
            this.buttonMenu.Height = (int)(buttonMenu.Height * heightFactor);
            this.buttonMenu.Location = new Point((int)(buttonMenu.Location.X * widthFactor), (int)(buttonMenu.Location.Y * heightFactor));
            this.buttonMenu.Font = new Font("Verdana", (float)widthFactor * 20F, FontStyle.Bold);

            this.buttonEsci.Width = (int)(buttonEsci.Width * widthFactor);
            this.buttonEsci.Height = (int)(buttonEsci.Height * heightFactor);
            this.buttonEsci.Location = new Point((int)(buttonEsci.Location.X * widthFactor), (int)(buttonEsci.Location.Y * heightFactor));
            this.buttonEsci.Font = new Font("Verdana", (float)widthFactor * 20F, FontStyle.Bold);

            this.buttonCalcolatrice.Width = (int)(buttonCalcolatrice.Width * widthFactor);
            this.buttonCalcolatrice.Height = (int)(buttonCalcolatrice.Height * heightFactor);
            this.buttonCalcolatrice.Location = new Point((int)(buttonCalcolatrice.Location.X * widthFactor), (int)(buttonCalcolatrice.Location.Y * heightFactor));
            this.buttonCalcolatrice.Font = new Font("Verdana", (float)widthFactor * 20F, FontStyle.Bold);

            this.titolo.Width = (int)(titolo.Width * widthFactor);
            this.titolo.Height = (int)(titolo.Height * heightFactor);
            this.titolo.Location = new Point((int)(titolo.Location.X * widthFactor), (int)(titolo.Location.Y * heightFactor));
            this.titolo.Font = new Font("Verdana", (float)widthFactor * 26F, FontStyle.Bold);

            this.smile.Width = (int)(smile.Width * widthFactor);
            this.smile.Height = (int)(smile.Height * heightFactor);
            this.smile.Location = new Point((int)(smile.Location.X * widthFactor), (int)(smile.Location.Y * heightFactor));

            this.smile2.Width = (int)(smile2.Width * widthFactor);
            this.smile2.Height = (int)(smile2.Height * heightFactor);
            this.smile2.Location = new Point((int)(smile2.Location.X * widthFactor), (int)(smile2.Location.Y * heightFactor));

            this.nosmile.Width = (int)(nosmile.Width * widthFactor);
            this.nosmile.Height = (int)(nosmile.Height * heightFactor);
            this.nosmile.Location = new Point((int)(nosmile.Location.X * widthFactor), (int)(nosmile.Location.Y * heightFactor));

            this.pbViola.Width = (int)(pbViola.Width * widthFactor);
            this.pbViola.Height = (int)(pbViola.Height * heightFactor);
            this.pbViola.Location = new Point((int)(pbViola.Location.X * widthFactor), (int)(pbViola.Location.Y * heightFactor));

            this.fase_1.Width = (int)(fase_1.Width * widthFactor);
            this.fase_1.Height = (int)(fase_1.Height * heightFactor);
            this.fase_1.Location = new Point((int)(fase_1.Location.X * widthFactor), (int)(fase_1.Location.Y * heightFactor));
            this.fase_1.Font = new Font("Verdana", (float)widthFactor * 18F, FontStyle.Bold);

            this.fase_2.Width = (int)(fase_2.Width * widthFactor);
            this.fase_2.Height = (int)(fase_2.Height * heightFactor);
            this.fase_2.Location = new Point((int)(fase_2.Location.X * widthFactor), (int)(fase_2.Location.Y * heightFactor));
            this.fase_2.Font = new Font("Verdana", (float)widthFactor * 18F, FontStyle.Bold);

            this.fase_3.Width = (int)(fase_3.Width * widthFactor);
            this.fase_3.Height = (int)(fase_3.Height * heightFactor);
            this.fase_3.Location = new Point((int)(fase_3.Location.X * widthFactor), (int)(fase_3.Location.Y * heightFactor));
            this.fase_3.Font = new Font("Verdana", (float)widthFactor * 18F, FontStyle.Bold);

            this.porta_1.Width = (int)(porta_1.Width * widthFactor);
            this.porta_1.Height = (int)(porta_1.Height * heightFactor);
            this.porta_1.Location = new Point((int)(this.porta_1.Location.X * widthFactor), (int)(this.porta_1.Location.Y * heightFactor));

            this.porta_2.Width = (int)(porta_2.Width * widthFactor);
            this.porta_2.Height = (int)(porta_2.Height * heightFactor);
            this.porta_2.Location = new Point((int)(this.porta_2.Location.X * widthFactor), (int)(this.porta_2.Location.Y * heightFactor));

            this.porta_3.Width = (int)(porta_3.Width * widthFactor);
            this.porta_3.Height = (int)(porta_3.Height * heightFactor);
            this.porta_3.Location = new Point((int)(this.porta_3.Location.X * widthFactor), (int)(this.porta_3.Location.Y * heightFactor));

            this.porta_4.Width = (int)(porta_4.Width * widthFactor);
            this.porta_4.Height = (int)(porta_4.Height * heightFactor);
            this.porta_4.Location = new Point((int)(this.porta_4.Location.X * widthFactor), (int)(this.porta_4.Location.Y * heightFactor));

            this.porta_5.Width = (int)(porta_5.Width * widthFactor);
            this.porta_5.Height = (int)(porta_5.Height * heightFactor);
            this.porta_5.Location = new Point((int)(this.porta_5.Location.X * widthFactor), (int)(this.porta_5.Location.Y * heightFactor));

            this.label_11.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_12.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_13.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_14.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_15.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_16.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_21.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_22.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_23.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_24.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_25.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_26.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_31.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_32.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_33.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_34.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_35.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_36.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_41.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_42.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_43.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_44.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_45.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_46.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_51.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_52.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_53.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_54.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_55.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
            this.label_56.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);

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

            foreach (Control c in porta_5.Controls)
            {
                c.Width = (int)(c.Width * widthFactor);
                c.Height = (int)(c.Height * heightFactor);
                c.Location = new Point((int)(c.Location.X * widthFactor), (int)(c.Location.Y * heightFactor));
            }

        }

        private void MyInitializeComponent()
        {

            this.SuspendLayout();

            // Visualizzazione soldi in panels porta_1,2,3,4,5

            Globals.Inizializza_soldiImg();
            string spaziprima = " ";

            for (int i = 0; i < 6; i++)
            {
                val_porta_1[i] = array_spesa_fabbrica[i];
                val_porta_2[i] = array_guadagno[i];
                inizio_porta_1[i] = array_spesa_fabbrica[i];
                inizio_porta_2[i] = array_guadagno[i];
                val_porta_3[i] = 0;
                val_porta_4[i] = 0;
                val_porta_5[i] = 0;
            }

            //porta_1
            if (val_porta_1[0] == 0)
            {
                porta_11.Visible = false;
                label_11.Visible = false;
            }
            else
            {
                porta_11.Image = Globals.soldiImg[0];
                if (val_porta_1[0] > 0)
                    label_11.Text = spaziprima + val_porta_1[0].ToString();
                else
                    label_11.Text = spaziprima;
                porta_11.Visible = true;
                label_11.Visible = true;
            }
            if (val_porta_1[1] == 0)
            {
                porta_12.Visible = false;
                label_12.Visible = false;
            }
            else
            {
                porta_12.Image = Globals.soldiImg[1];
                if (val_porta_1[1] > 0)
                    label_12.Text = spaziprima + val_porta_1[1].ToString();
                else
                    label_12.Text = spaziprima;
                porta_12.Visible = true;
                label_12.Visible = true;
            }

            if (val_porta_1[2] == 0)
            {
                porta_13.Visible = false;
                label_13.Visible = false;
            }
            else
            {
                porta_13.Image = Globals.soldiImg[2];
                if (val_porta_1[2] > 0)
                    label_13.Text = spaziprima + val_porta_1[2].ToString();
                else
                    label_13.Text = spaziprima;
                porta_13.Visible = true;
                label_13.Visible = true;
            }

            if (val_porta_1[3] == 0)
            {
                porta_14.Visible = false;
                label_14.Visible = false;
            }
            else
            {
                porta_14.Image = Globals.soldiImg[3];
                if (val_porta_1[3] > 0)
                    label_14.Text = spaziprima + val_porta_1[3].ToString();
                else
                    label_14.Text = spaziprima;
                porta_14.Visible = true;
                label_14.Visible = true;
            }

            if (val_porta_1[4] == 0)
            {
                porta_15.Visible = false;
                label_15.Visible = false;
            }
            else
            {
                porta_15.Image = Globals.soldiImg[4];
                if (val_porta_1[4] > 0)
                    label_15.Text = spaziprima + val_porta_1[4].ToString();
                else
                    label_15.Text = spaziprima;
                porta_15.Visible = true;
                label_15.Visible = true;
            }

            if (val_porta_1[5] == 0)
            {
                porta_16.Visible = false;
                label_16.Visible = false;
            }
            else
            {
                porta_16.Image = Globals.soldiImg[5];
                if (val_porta_1[5] > 0)
                    label_16.Text = spaziprima + val_porta_1[5].ToString();
                else
                    label_16.Text = spaziprima;
                porta_16.Visible = true;
                label_16.Visible = true;
            }


            //porta_2

            if (val_porta_2[0] == 0)
            {
                porta_21.Visible = false;
                label_21.Visible = false;
            }
            else
            {
                porta_21.Image = Globals.soldiImg[0];
                if (val_porta_2[0] > 0)
                    label_21.Text = spaziprima + val_porta_2[0].ToString();
                else
                    label_21.Text = spaziprima;
                porta_21.Visible = true;
                label_21.Visible = true;
            }

            if (val_porta_2[1] == 0)
            {
                porta_22.Visible = false;
                label_22.Visible = false;
            }
            else
            {
                porta_22.Image = Globals.soldiImg[1];
                if (val_porta_2[1] > 0)
                    label_22.Text = spaziprima + val_porta_2[1].ToString();
                else
                    label_22.Text = spaziprima;
                porta_22.Visible = true;
                label_22.Visible = true;
            }

            if (val_porta_2[2] == 0)
            {
                porta_23.Visible = false;
                label_23.Visible = false;
            }
            else
            {
                porta_23.Image = Globals.soldiImg[2];
                if (val_porta_2[2] > 0)
                    label_23.Text = spaziprima + val_porta_2[2].ToString();
                else
                    label_23.Text = spaziprima;
                porta_23.Visible = true;
                label_23.Visible = true;
            }

            if (val_porta_2[3] == 0)
            {
                porta_24.Visible = false;
                label_24.Visible = false;
            }
            else
            {
                porta_24.Image = Globals.soldiImg[3];
                if (val_porta_2[3] > 0)
                    label_24.Text = spaziprima + val_porta_2[3].ToString();
                else
                    label_24.Text = spaziprima;
                porta_24.Visible = true;
                label_24.Visible = true;
            }

            if (val_porta_2[4] == 0)
            {
                porta_25.Visible = false;
                label_25.Visible = false;
            }
            else
            {
                porta_25.Image = Globals.soldiImg[4];
                if (val_porta_2[4] > 0)
                    label_25.Text = spaziprima + val_porta_2[4].ToString();
                else
                    label_25.Text = spaziprima;
                porta_25.Visible = true;
                label_25.Visible = true;
            }

            if (val_porta_2[5] == 0)
            {
                porta_26.Visible = false;
                label_26.Visible = false;
            }
            else
            {
                porta_26.Image = Globals.soldiImg[5];
                if (val_porta_2[5] > 0)
                    label_26.Text = spaziprima + val_porta_2[5].ToString();
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
                if (Globals.pFase3[0] > 0)
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
                if (Globals.pFase3[1] > 0)
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
                if (Globals.pFase3[2] > 0)
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
                if (Globals.pFase3[3] > 0)
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
                if (Globals.pFase3[4] > 0)
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
                if (Globals.pFase3[5] > 0)
                    label_36.Text = spaziprima + Globals.pFase3[5].ToString();
                else
                    label_36.Text = spaziprima;
                porta_36.Visible = true;
                label_36.Visible = true;
            }



            //porta 4
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


            //porta_5
            if (val_porta_5[0] == 0)
            {
                porta_51.Visible = false;
                label_51.Visible = false;
            }
            else
            {
                porta_51.Image = Globals.soldiImg[0];
                if (val_porta_5[0] > 0)
                    label_51.Text = spaziprima + val_porta_5[0].ToString();
                else
                    label_51.Text = spaziprima;
                porta_51.Visible = true;
                label_51.Visible = true;
            }

            if (val_porta_5[1] == 0)
            {
                porta_52.Visible = false;
                label_52.Visible = false;
            }
            else
            {
                porta_52.Image = Globals.soldiImg[1];
                if (val_porta_5[1] > 0)
                    label_52.Text = spaziprima + val_porta_5[1].ToString();
                else
                    label_52.Text = spaziprima;
                porta_52.Visible = true;
                label_52.Visible = true;
            }

            if (val_porta_5[2] == 0)
            {
                porta_53.Visible = false;
                label_53.Visible = false;
            }
            else
            {
                porta_53.Image = Globals.soldiImg[2];
                if (val_porta_5[2] > 0)
                    label_53.Text = spaziprima + val_porta_5[2].ToString();
                else
                    label_53.Text = spaziprima;
                porta_53.Visible = true;
                label_53.Visible = true;
            }

            if (val_porta_5[3] == 0)
            {
                porta_54.Visible = false;
                label_54.Visible = false;
            }
            else
            {
                porta_54.Image = Globals.soldiImg[3];
                if (val_porta_5[3] > 0)
                    label_54.Text = spaziprima + val_porta_5[3].ToString();
                else
                    label_54.Text = spaziprima;
                porta_54.Visible = true;
                label_54.Visible = true;
            }

            if (val_porta_5[4] == 0)
            {
                porta_55.Visible = false;
                label_55.Visible = false;
            }
            else
            {
                porta_55.Image = Globals.soldiImg[4];
                if (val_porta_5[4] > 0)
                    label_55.Text = spaziprima + val_porta_5[4].ToString();
                else
                    label_55.Text = spaziprima;
                porta_55.Visible = true;
                label_55.Visible = true;
            }

            if (val_porta_5[5] == 0)
            {
                porta_56.Visible = false;
                label_56.Visible = false;
            }
            else
            {
                porta_56.Image = Globals.soldiImg[5];
                if (val_porta_5[5] > 0)
                    label_56.Text = spaziprima + val_porta_5[5].ToString();
                else
                    label_56.Text = spaziprima;
                porta_56.Visible = true;
                label_56.Visible = true;
            }

            //Pre-carica le immagini in porta 1
            porta_11.Image = Globals.soldiImg[0];
            porta_12.Image = Globals.soldiImg[1];
            porta_13.Image = Globals.soldiImg[2];
            porta_14.Image = Globals.soldiImg[3];
            porta_15.Image = Globals.soldiImg[4];
            porta_16.Image = Globals.soldiImg[5];

            //Pre-carica le immagini in porta 2
            porta_21.Image = Globals.soldiImg[0];
            porta_22.Image = Globals.soldiImg[1];
            porta_23.Image = Globals.soldiImg[2];
            porta_24.Image = Globals.soldiImg[3];
            porta_25.Image = Globals.soldiImg[4];
            porta_26.Image = Globals.soldiImg[5];

            //Pre-carica le immagini in porta 3
            porta_31.Image = Globals.soldiImg[0];
            label_31.Text = spaziprima;
            porta_31.Visible = false;
            label_31.Visible = false;

            porta_32.Image = Globals.soldiImg[1];
            label_32.Text = spaziprima;
            porta_32.Visible = false;
            label_32.Visible = false;

            porta_33.Image = Globals.soldiImg[2];
            label_33.Text = spaziprima;
            porta_33.Visible = false;
            label_33.Visible = false;

            porta_34.Image = Globals.soldiImg[3];
            label_34.Text = spaziprima;
            porta_34.Visible = false;
            label_34.Visible = false;

            porta_35.Image = Globals.soldiImg[4];
            label_35.Text = spaziprima;
            porta_35.Visible = false;
            label_35.Visible = false;

            porta_36.Image = Globals.soldiImg[5];
            label_36.Text = spaziprima;
            porta_36.Visible = false;
            label_36.Visible = false;


            //Pre-carica le immagini in porta 4
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

            //Pre-carica le immagini in porta 5
            porta_51.Image = Globals.soldiImg[0];
            label_51.Text = spaziprima;
            porta_51.Visible = false;
            label_51.Visible = false;

            porta_52.Image = Globals.soldiImg[1];
            label_52.Text = spaziprima;
            porta_52.Visible = false;
            label_52.Visible = false;

            porta_53.Image = Globals.soldiImg[2];
            label_53.Text = spaziprima;
            porta_53.Visible = false;
            label_53.Visible = false;

            porta_54.Image = Globals.soldiImg[3];
            label_54.Text = spaziprima;
            porta_54.Visible = false;
            label_54.Visible = false;

            porta_55.Image = Globals.soldiImg[4];
            label_55.Text = spaziprima;
            porta_55.Visible = false;
            label_55.Visible = false;

            porta_56.Image = Globals.soldiImg[5];
            label_56.Text = spaziprima;
            porta_56.Visible = false;
            label_56.Visible = false;

            
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AssegnGuadagno";
            /*this.Text = "Portafoglio-cassa di Viola";*/
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.ResumeLayout(false);

        }

        //Per uscire dalla prova
        private void buttonEsci_Click(object sender, EventArgs e)
        {
            fumetto2 = new Fumetto2();
            fumetto2.ShowDialog();
        }

        //Compotamento di ok_1.
        private void ok_1_Click(object sender, EventArgs e)
        {
            if (Val_array_spesa_fabbrica() == Val_porta_3() && Globals.prezzoConGuadagnoDinamico == Val_porta_4())
            {
                this.ok_1.Visible = false;
                this.nosmile.Visible = false;
                this.fase_3.Visible = false;
                muovi_porta_3_4();
                mostra_porta_5();
                
                this.smile2.Visible = true;
                
                
                this.ok_2.Visible = true;
                
                this.domanda.Visible = true;
                this.risposta.Visible = true;

                for (int i = 0; i < 6; i++)
                {
                    val_porta_5[i] = val_porta_3[i] + val_porta_4[i];
                }

                Def_porta_5();
            }
            else
                nosmile.Visible = true;
        }

        //Compotamento di ok_2.
        private void ok_2_Click(object sender, EventArgs e)
        {
            double val_risposta;

            try
            {
                val_risposta = Convert.ToDouble(risposta.Text);

                if (val_risposta == Val_porta_3() + Val_porta_4())
                {
                    if (this.InsNumero.Visible == true)
                    {
                        this.InsNumero.Visible = false;
                    }

                    this.smile.Visible = true;
                    this.risposta.Enabled = false;
                    this.nosmile.Visible = false;
                    this.buttonEsci.Visible = true;
                    this.ok_2.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND_OK);
                }
                else
                {
                    if (this.InsNumero.Visible == true)
                    {
                        this.InsNumero.Visible = false;
                    }

                    this.nosmile.Visible = true;
                    this.smile.Visible = false;
                    this.risposta.Text = "";
                }
            }
            catch (FormatException)
            {
                this.InsNumero.Visible = true;
                this.risposta.Text = "";

                if (this.smile.Visible == true)
                {
                    this.smile.Visible = false;
                }

                if (this.nosmile.Visible == true)
                {
                    this.nosmile.Visible = false;
                }
            }
        }

        //Torna al menu'
        private void buttonMenu_Click(object sender, EventArgs e)
        {
            home = new HomePage();
            this.Close();
            home.ShowDialog();
        }

        private void buttonCalcolatrice_Click(object sender, EventArgs e)
        {
            Globals.calcolatrice.ShowDialog();
        }

        /*-----------------------------------------------------------*/
        private void porta_1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /*----------------------------------------------------------*/

        //Mouse down per le banconote (inizio trascinamento)
        //Porta 1
        private void porta_11_MouseDown(object sender, MouseEventArgs e)
        {
            porta_start = 1;

            if (this.sicuro.Visible == true)
            {
                this.sicuro.Visible = false;
            }

            if (this.sicuro2.Visible == true)
            {
                this.sicuro2.Visible = false;
            }

            porta_1.AllowDrop = false;
            porta_2.AllowDrop = false;
            porta_3.AllowDrop = true;
            porta_4.AllowDrop = true;

            porta_11.DoDragDrop(porta_11.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_11.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void porta_12_MouseDown(object sender, MouseEventArgs e)
        {
            porta_start = 1;

            if (this.sicuro.Visible == true)
            {
                this.sicuro.Visible = false;
            }

            if (this.sicuro2.Visible == true)
            {
                this.sicuro2.Visible = false;
            }

            porta_1.AllowDrop = false;
            porta_2.AllowDrop = false;
            porta_3.AllowDrop = true;
            porta_4.AllowDrop = true;

            porta_12.DoDragDrop(porta_12.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_12.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void porta_13_MouseDown(object sender, MouseEventArgs e)
        {
            porta_start = 1;

            if (this.sicuro.Visible == true)
            {
                this.sicuro.Visible = false;
            }

            if (this.sicuro2.Visible == true)
            {
                this.sicuro2.Visible = false;
            }

            porta_1.AllowDrop = false;
            porta_2.AllowDrop = false;
            porta_3.AllowDrop = true;
            porta_4.AllowDrop = true;

            porta_13.DoDragDrop(porta_13.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_13.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void porta_14_MouseDown(object sender, MouseEventArgs e)
        {
            porta_start = 1;

            if (this.sicuro.Visible == true)
            {
                this.sicuro.Visible = false;
            }

            if (this.sicuro2.Visible == true)
            {
                this.sicuro2.Visible = false;
            }

            porta_1.AllowDrop = false;
            porta_2.AllowDrop = false;
            porta_3.AllowDrop = true;
            porta_4.AllowDrop = true;

            porta_14.DoDragDrop(porta_14.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_14.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void porta_15_MouseDown(object sender, MouseEventArgs e)
        {
            porta_start = 1;

            if (this.sicuro.Visible == true)
            {
                this.sicuro.Visible = false;
            }

            if (this.sicuro2.Visible == true)
            {
                this.sicuro2.Visible = false;
            }

            porta_1.AllowDrop = false;
            porta_2.AllowDrop = false;
            porta_3.AllowDrop = true;
            porta_4.AllowDrop = true;

            porta_15.DoDragDrop(porta_15.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_15.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void porta_16_MouseDown(object sender, MouseEventArgs e)
        {
            porta_start = 1;

            if (this.sicuro.Visible == true)
            {
                this.sicuro.Visible = false;
            }

            if (this.sicuro2.Visible == true)
            {
                this.sicuro2.Visible = false;
            }

            porta_1.AllowDrop = false;
            porta_2.AllowDrop = false;
            porta_3.AllowDrop = true;
            porta_4.AllowDrop = true;

            porta_16.DoDragDrop(porta_16.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_16.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        //Porta 2
        private void porta_21_MouseDown(object sender, MouseEventArgs e)
        {
            porta_start = 2;

            if (this.sicuro.Visible == true)
            {
                this.sicuro.Visible = false;
            }

            if (this.sicuro2.Visible == true)
            {
                this.sicuro2.Visible = false;
            }

            porta_1.AllowDrop = false;
            porta_2.AllowDrop = false;
            porta_3.AllowDrop = true;
            porta_4.AllowDrop = true;

            porta_21.DoDragDrop(porta_21.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_21.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void porta_22_MouseDown(object sender, MouseEventArgs e)
        {
            porta_start = 2;

            if (this.sicuro.Visible == true)
            {
                this.sicuro.Visible = false;
            }

            if (this.sicuro2.Visible == true)
            {
                this.sicuro2.Visible = false;
            }

            porta_1.AllowDrop = false;
            porta_2.AllowDrop = false;
            porta_3.AllowDrop = true;
            porta_4.AllowDrop = true;

            porta_22.DoDragDrop(porta_22.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_22.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void porta_23_MouseDown(object sender, MouseEventArgs e)
        {
            porta_start = 2;

            if (this.sicuro.Visible == true)
            {
                this.sicuro.Visible = false;
            }

            if (this.sicuro2.Visible == true)
            {
                this.sicuro2.Visible = false;
            }

            porta_1.AllowDrop = false;
            porta_2.AllowDrop = false;
            porta_3.AllowDrop = true;
            porta_4.AllowDrop = true;

            porta_23.DoDragDrop(porta_23.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_23.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void porta_24_MouseDown(object sender, MouseEventArgs e)
        {
            porta_start = 2;

            if (this.sicuro.Visible == true)
            {
                this.sicuro.Visible = false;
            }

            if (this.sicuro2.Visible == true)
            {
                this.sicuro2.Visible = false;
            }

            porta_1.AllowDrop = false;
            porta_2.AllowDrop = false;
            porta_3.AllowDrop = true;
            porta_4.AllowDrop = true;

            porta_24.DoDragDrop(porta_24.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_24.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void porta_25_MouseDown(object sender, MouseEventArgs e)
        {
            porta_start = 2;

            if (this.sicuro.Visible == true)
            {
                this.sicuro.Visible = false;
            }

            if (this.sicuro2.Visible == true)
            {
                this.sicuro2.Visible = false;
            }

            porta_1.AllowDrop = false;
            porta_2.AllowDrop = false;
            porta_3.AllowDrop = true;
            porta_4.AllowDrop = true;

            porta_25.DoDragDrop(porta_25.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_25.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void porta_26_MouseDown(object sender, MouseEventArgs e)
        {
            porta_start = 2;

            if (this.sicuro.Visible == true)
            {
                this.sicuro.Visible = false;
            }

            if (this.sicuro2.Visible == true)
            {
                this.sicuro2.Visible = false;
            }

            porta_1.AllowDrop = false;
            porta_2.AllowDrop = false;
            porta_3.AllowDrop = true;
            porta_4.AllowDrop = true;

            porta_26.DoDragDrop(porta_26.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_26.Cursor = System.Windows.Forms.Cursors.Hand;
        }


        //Porta 3
        private void porta_31_MouseDown(object sender, MouseEventArgs e)
        {
            porta_start = 3;

            if (this.sicuro.Visible == true)
            {
                this.sicuro.Visible = false;
            }

            if (this.sicuro2.Visible == true)
            {
                this.sicuro2.Visible = false;
            }

            porta_1.AllowDrop = true;
            porta_2.AllowDrop = true;
            porta_3.AllowDrop = false;
            porta_4.AllowDrop = false;

            porta_31.DoDragDrop(porta_31.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_31.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void porta_32_MouseDown(object sender, MouseEventArgs e)
        {
            porta_start = 3;

            if (this.sicuro.Visible == true)
            {
                this.sicuro.Visible = false;
            }

            if (this.sicuro2.Visible == true)
            {
                this.sicuro2.Visible = false;
            }

            porta_1.AllowDrop = true;
            porta_2.AllowDrop = true;
            porta_3.AllowDrop = false;
            porta_4.AllowDrop = false;

            porta_32.DoDragDrop(porta_32.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_32.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void porta_33_MouseDown(object sender, MouseEventArgs e)
        {
            porta_start = 3;

            if (this.sicuro.Visible == true)
            {
                this.sicuro.Visible = false;
            }

            if (this.sicuro2.Visible == true)
            {
                this.sicuro2.Visible = false;
            }

            porta_1.AllowDrop = true;
            porta_2.AllowDrop = true;
            porta_3.AllowDrop = false;
            porta_4.AllowDrop = false;

            porta_33.DoDragDrop(porta_33.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_33.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void porta_34_MouseDown(object sender, MouseEventArgs e)
        {
            porta_start = 3;

            if (this.sicuro.Visible == true)
            {
                this.sicuro.Visible = false;
            }

            if (this.sicuro2.Visible == true)
            {
                this.sicuro2.Visible = false;
            }

            porta_1.AllowDrop = true;
            porta_2.AllowDrop = true;
            porta_3.AllowDrop = false;
            porta_4.AllowDrop = false;

            porta_34.DoDragDrop(porta_34.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_34.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void porta_35_MouseDown(object sender, MouseEventArgs e)
        {
            porta_start = 3;

            if (this.sicuro.Visible == true)
            {
                this.sicuro.Visible = false;
            }

            if (this.sicuro2.Visible == true)
            {
                this.sicuro2.Visible = false;
            }

            porta_1.AllowDrop = true;
            porta_2.AllowDrop = true;
            porta_3.AllowDrop = false;
            porta_4.AllowDrop = false;

            porta_35.DoDragDrop(porta_35.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_35.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void porta_36_MouseDown(object sender, MouseEventArgs e)
        {
            porta_start = 3;

            if (this.sicuro.Visible == true)
            {
                this.sicuro.Visible = false;
            }

            if (this.sicuro2.Visible == true)
            {
                this.sicuro2.Visible = false;
            }

            porta_1.AllowDrop = true;
            porta_2.AllowDrop = true;
            porta_3.AllowDrop = false;
            porta_4.AllowDrop = false;

            porta_36.DoDragDrop(porta_36.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_36.Cursor = System.Windows.Forms.Cursors.Hand;
        }


        //porta 4
        private void porta_41_MouseDown(object sender, MouseEventArgs e)
        {
            porta_start = 4;

            if (this.sicuro.Visible == true)
            {
                this.sicuro.Visible = false;
            }

            if (this.sicuro2.Visible == true)
            {
                this.sicuro2.Visible = false;
            }

            porta_1.AllowDrop = true;
            porta_2.AllowDrop = true;
            porta_3.AllowDrop = false;
            porta_4.AllowDrop = false;

            porta_41.DoDragDrop(porta_41.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_41.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void porta_42_MouseDown(object sender, MouseEventArgs e)
        {
            porta_start = 4;

            if (this.sicuro.Visible == true)
            {
                this.sicuro.Visible = false;
            }

            if (this.sicuro2.Visible == true)
            {
                this.sicuro2.Visible = false;
            }

            porta_1.AllowDrop = true;
            porta_2.AllowDrop = true;
            porta_3.AllowDrop = false;
            porta_4.AllowDrop = false;

            porta_42.DoDragDrop(porta_42.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_42.Cursor = System.Windows.Forms.Cursors.Hand;

        }
        private void porta_43_MouseDown(object sender, MouseEventArgs e)
        {
            porta_start = 4;

            if (this.sicuro.Visible == true)
            {
                this.sicuro.Visible = false;
            }

            if (this.sicuro2.Visible == true)
            {
                this.sicuro2.Visible = false;
            }

            porta_1.AllowDrop = true;
            porta_2.AllowDrop = true;
            porta_3.AllowDrop = false;
            porta_4.AllowDrop = false;

            porta_43.DoDragDrop(porta_43.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_43.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void porta_44_MouseDown(object sender, MouseEventArgs e)
        {
            porta_start = 4;

            if (this.sicuro.Visible == true)
            {
                this.sicuro.Visible = false;
            }

            if (this.sicuro2.Visible == true)
            {
                this.sicuro2.Visible = false;
            }

            porta_1.AllowDrop = true;
            porta_2.AllowDrop = true;
            porta_3.AllowDrop = false;
            porta_4.AllowDrop = false;

            porta_44.DoDragDrop(porta_44.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_44.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void porta_45_MouseDown(object sender, MouseEventArgs e)
        {
            porta_start = 4;

            if (this.sicuro.Visible == true)
            {
                this.sicuro.Visible = false;
            }

            if (this.sicuro2.Visible == true)
            {
                this.sicuro2.Visible = false;
            }

            porta_1.AllowDrop = true;
            porta_2.AllowDrop = true;
            porta_3.AllowDrop = false;
            porta_4.AllowDrop = false;

            porta_45.DoDragDrop(porta_45.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_45.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void porta_46_MouseDown(object sender, MouseEventArgs e)
        {
            porta_start = 4;

            if (this.sicuro.Visible == true)
            {
                this.sicuro.Visible = false;
            }

            if (this.sicuro2.Visible == true)
            {
                this.sicuro2.Visible = false;
            }

            porta_1.AllowDrop = true;
            porta_2.AllowDrop = true;
            porta_3.AllowDrop = false;
            porta_4.AllowDrop = false;

            porta_46.DoDragDrop(porta_46.Tag, DragDropEffects.Copy | DragDropEffects.Move);
            porta_46.Cursor = System.Windows.Forms.Cursors.Hand;
        }


        //Funzione per ottenere l'elemento degli array val_porta_X su cui agire
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

        //Funzione che aggiorna gli array val_porta_X in base al risultato della funzione get_param_porta.
        private void aggiorna_val_porta_start(int p_start, int p)
        {
            if (p_start == 1) val_porta_1[p]--;
            else if (p_start == 2) val_porta_2[p]--;
            else if (p_start == 3) val_porta_3[p]--;
            else if (p_start == 4) val_porta_4[p]--;
        }


        //Funzione che si occupa della visualizzazione delle banconote e delle label
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

        //Funzione che gestisce la visualizzazione delle banconote nella porta 5.
        private void Def_porta_5()
        {
            if (val_porta_5[0] == 0)
            {
                porta_51.Visible = false;
                label_51.Visible = false;
            }

            else
            {
                label_51.Text = val_porta_5[0].ToString();
                label_51.Visible = true;
                porta_51.Visible = true;
            }

            if (val_porta_5[1] == 0)
            {
                porta_52.Visible = false;
                label_52.Visible = false;
            }

            else
            {
                label_52.Text = val_porta_5[1].ToString();
                label_52.Visible = true;
                porta_52.Visible = true;
            }

            if (val_porta_5[2] == 0)
            {
                porta_53.Visible = false;
                label_53.Visible = false;
            }

            else
            {
                label_53.Text = val_porta_5[2].ToString();
                label_53.Visible = true;
                porta_53.Visible = true;
            }

            if (val_porta_5[3] == 0)
            {
                porta_54.Visible = false;
                label_54.Visible = false;
            }

            else
            {
                label_54.Text = val_porta_5[3].ToString();
                label_54.Visible = true;
                porta_54.Visible = true;
            }


            if (val_porta_5[4] == 0)
            {
                porta_55.Visible = false;
                label_55.Visible = false;
            }

            else
            {
                label_55.Text = val_porta_5[4].ToString();
                label_55.Visible = true;
                porta_55.Visible = true;
            }

            if (val_porta_5[5] == 0)
            {
                porta_56.Visible = false;
                label_56.Visible = false;
            }

            else
            {
                label_56.Text = val_porta_5[5].ToString();
                label_56.Visible = true;
                porta_56.Visible = true;
            }
        }

        //Eventi drag over
        private void porta_1_DragOver(object sender, DragEventArgs e)
        {
            string testo = e.Data.GetData(DataFormats.Text).ToString();
            int param = get_param_porta(testo);

            if (val_porta_1[param] == inizio_porta_1[param])
            {
                porta_1.AllowDrop = false;
            }
            else
            {
                porta_1.AllowDrop = true;
            }

            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void porta_2_DragOver(object sender, DragEventArgs e)
        {
            string testo = e.Data.GetData(DataFormats.Text).ToString();
            int param = get_param_porta(testo);

            if (val_porta_2[param] == inizio_porta_2[param])
            {
                porta_2.AllowDrop = false;
            }
            else
            {
                porta_2.AllowDrop = true;
            }


            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void porta_3_DragOver(object sender, DragEventArgs e)
        {
            if (porta_start == 2 && this.sicuro.Visible == false)
            {
                porta_3.AllowDrop = false;
                this.sicuro.Visible = true;
            }

            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void porta_4_DragOver(object sender, DragEventArgs e)
        {
            if (porta_start == 1 && this.sicuro2.Visible == false)
            {
                porta_4.AllowDrop = false;
                this.sicuro2.Visible = true;
            }

            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        //Fine trascinamento
        private void porta_1_DragDrop(object sender, DragEventArgs e)
        {

            string testo = e.Data.GetData(DataFormats.Text).ToString();
            double newimporto = Convert.ToDouble(testo);

            int param = get_param_porta(testo);

            val_porta_1[param]++;

            aggiorna_val_porta_start(porta_start, param);

            Def_porta_1234();



        }

        private void porta_2_DragDrop(object sender, DragEventArgs e)
        {

            string testo = e.Data.GetData(DataFormats.Text).ToString();
            double newimporto = Convert.ToDouble(testo);

            int param = get_param_porta(testo);

            val_porta_2[param]++;

            aggiorna_val_porta_start(porta_start, param);

            Def_porta_1234();



        }

        private void porta_3_DragDrop(object sender, DragEventArgs e)
        {

            if (this.sicuro2.Visible == true)
            {
                this.sicuro2.Visible = false;
            }

            string testo = e.Data.GetData(DataFormats.Text).ToString();
            double newimporto = Convert.ToDouble(testo);

            int param = get_param_porta(testo);

            val_porta_3[param]++;

            aggiorna_val_porta_start(porta_start, param);

            Def_porta_1234();


        }

        private void porta_4_DragDrop(object sender, DragEventArgs e)
        {

            if (this.sicuro.Visible == true)
            {
                this.sicuro.Visible = false;
            }

            string testo = e.Data.GetData(DataFormats.Text).ToString();
            double newimporto = Convert.ToDouble(testo);

            int param = get_param_porta(testo);

            val_porta_4[param]++;

            aggiorna_val_porta_start(porta_start, param);

            Def_porta_1234();



        }

        //Funzione che gestisce i colori della pagina
        private void Visualizzazione()
        {
            this.BackColor = Color.FromName(Globals.PANEL_BACKGROUND);

            this.buttonMenu.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.ok_1.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.ok_2.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.buttonEsci.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);
            this.buttonCalcolatrice.BackColor = Color.FromName(Globals.BUTTON_BACKGROUND);

            this.buttonMenu.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.ok_1.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.ok_2.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.buttonEsci.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.buttonCalcolatrice.ForeColor = Color.FromName(Globals.BUTTON_TEXT);

            this.titolo.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.fase_1.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.fase_2.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.fase_3.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.domanda.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.risposta.ForeColor = Color.FromName(Globals.BUTTON_TEXT);

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

            this.label_51.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.label_52.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.label_53.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.label_54.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.label_55.ForeColor = Color.FromName(Globals.BUTTON_TEXT);
            this.label_56.ForeColor = Color.FromName(Globals.BUTTON_TEXT);

        }

        //Funzione per calcolare l'importo nella porta3
        private double Val_porta_3()
        {
            return (double)(val_porta_3[0] * 50.00 +
                              val_porta_3[1] * 20.00 +
                              val_porta_3[2] * 10.00 +
                              val_porta_3[3] * 5.00 +
                              val_porta_3[4] * 2.00 +
                              val_porta_3[5] * 1.00);
        }

        //Funzione per calcolare l'importo della spesa in fabbrica
        private double Val_array_spesa_fabbrica()
        {
            return (double)(array_spesa_fabbrica[0] * 50.00 +
                              array_spesa_fabbrica[1] * 20.00 +
                              array_spesa_fabbrica[2] * 10.00 +
                              array_spesa_fabbrica[3] * 5.00 +
                              array_spesa_fabbrica[4] * 2.00 +
                              array_spesa_fabbrica[5] * 1.00);
        }

        //Funzione per calcolare l'importo nella porta4
        private double Val_porta_4()
        {
            return (double)(val_porta_4[0] * 50.00 +
                              val_porta_4[1] * 20.00 +
                              val_porta_4[2] * 10.00 +
                              val_porta_4[3] * 5.00 +
                              val_porta_4[4] * 2.00 +
                              val_porta_4[5] * 1.00);
        }

        //Funzione che genera le banconote per il guadagno.
        private int[] assegnazione_array_guadagno(double g)
        {
            int[] result = new int[6];
            double g_temp = g;


            while (g_temp >= 50)
            {
                result[0]++;
                g_temp -= 50;
            }
            while (g_temp >= 20)
            {
                result[1]++;
                g_temp -= 20;
            }
            while (g_temp >= 10)
            {
                result[2]++;
                g_temp -= 10;
            }
            while (g_temp >= 5)
            {
                result[3]++;
                g_temp -= 5;
            }
            while (g_temp >= 2)
            {
                result[4]++;
                g_temp -= 2;
            }
            while (g_temp >= 1)
            {
                result[5]++;
                g_temp -= 1;
            }

            return result;
        }

        //Funzione che esegue pFase1 - pFase2
        private int[] Differeza_fasi_12()
        {
            int[] spesa = new int[6];

            for (int i = 0; i < 6; i++)
            {
                spesa[i] = Globals.pFase1[i] - Globals.pFase2[i];
            }

            return spesa;

        }

        //Funzione che sposta le porte 3 e 4 e le fa dissolvere dopo aver risposto giusto.
        public void muovi_porta_3_4()
        {
            location_start_3 = porta_3.Location;
            location_start_4 = porta_4.Location;
            location_target = porta_5.Location;
            int alpha_start = 255;

            this.porta_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.porta_4.BorderStyle = System.Windows.Forms.BorderStyle.None;

            while (location_start_3.X < location_target.X && location_start_4.X > location_target.X)
            {


                location_start_3.X = (int)(location_start_3.X + 5 /* * Globals.speedFactor1 * widthFactor*/);
                location_start_4.X = (int)(location_start_4.X - 5 /* * Globals.speedFactor1 * widthFactor*/);
                alpha_start = alpha_start - 5;
                this.porta_3.Location = location_start_3;
                
                this.porta_4.Location = location_start_4;
                

                if(alpha_start >= 3)
                {
                    this.porta_3.BackColor = Color.FromArgb(alpha_start, Color.Tomato);
                    this.porta_4.BackColor = Color.FromArgb(alpha_start, Color.Lime);
                }

                foreach(Control c in porta_3.Controls)
                {
                    location_start = c.Location;                       /*Sposta le banconote con il panel*/
                    location_start.X = (int)(location_start.X + 0.1);
                    c.Location = location_start;
                    //c.Visible = false;                                   /*Nasconde le banconote del panel*/
                }

                foreach (Control c in porta_4.Controls)
                {
                    location_start = c.Location;
                    location_start.X = (int)(location_start.X - 0.1);
                    c.Location = location_start;
                    //c.Visible = false;
                }
                //this.pictureBox1.BringToFront();
                Thread.Sleep(5);
                ((Form)this).Update();

            }
            this.porta_3.Visible = false;
            this.porta_4.Visible = false;

        }

        //Mostra la porta 5 con un effetto dissolvenza
        public void mostra_porta_5()
        {
            int alpha_start = 0;
            this.porta_5.Visible = true;

            while(alpha_start < 255)
            {
                alpha_start = alpha_start + 15;
                this.porta_5.BackColor = Color.FromArgb(alpha_start, Color.White);

                Thread.Sleep(5);
                ((Form)this).Update();
            }

            this.porta_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }


    }
}
