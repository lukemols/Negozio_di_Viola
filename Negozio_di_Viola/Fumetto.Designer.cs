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
    partial class Fumetto
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
        private void InitializeComponent(int n)
        {
            pagina = n;

            setValues();

            int bx = 320;
            int tx = bx + 40;
            int deltaY = 50;

            this.avanti = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.Button();
            this.menu2 = new System.Windows.Forms.Button();
            this.esci = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.bOpt1 = new System.Windows.Forms.Button();
            this.bOpt2 = new System.Windows.Forms.Button();
            this.bOpt3 = new System.Windows.Forms.Button();
            this.indietro = new System.Windows.Forms.Button();
            this.nota1 = new System.Windows.Forms.Button();
            this.nota2 = new System.Windows.Forms.Button();
            this.testo = new System.Windows.Forms.Button();
            this.testo2 = new System.Windows.Forms.Button();
            this.testo3 = new System.Windows.Forms.Button();
            this.testo4 = new System.Windows.Forms.Button();
            this.testo5 = new System.Windows.Forms.Button();
            this.tOpt1 = new System.Windows.Forms.Button();
            this.tOpt2 = new System.Windows.Forms.Button();
            this.tOpt3 = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.panelTesto = new System.Windows.Forms.Panel();
            this.panelViola = new System.Windows.Forms.Panel();
            this.smile = new System.Windows.Forms.PictureBox();
            this.viola = new System.Windows.Forms.PictureBox();

            ((System.ComponentModel.ISupportInitialize)(this.smile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viola)).BeginInit();

            this.panel.SuspendLayout();
            this.panelViola.SuspendLayout();
            this.SuspendLayout();

            // bOpt1

            #region

            if (pagina == 1)
            {
                this.bOpt1.Location = new System.Drawing.Point(280, 600);
                this.bOpt1.Size = new System.Drawing.Size(150, 75);
                this.bOpt1.Text = text1;
            }

            else if (pagina == 2)
            {
                this.bOpt1.Location = new System.Drawing.Point(bx, 490 + deltaY);
                this.bOpt1.Size = new System.Drawing.Size(25, 25);
            }

            this.bOpt1.Name = "bOpt1";
            this.bOpt1.TabIndex = 1;
            this.bOpt1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bOpt1.UseVisualStyleBackColor = true;
            this.bOpt1.Click += new System.EventHandler(this.onClick);

            #endregion

            // bOpt2

            #region

            if (pagina == 1)
            {
                this.bOpt2.Location = new System.Drawing.Point(480, 600);
                this.bOpt2.Size = new System.Drawing.Size(150, 75);
                this.bOpt2.Text = text2;
            }

            else if (pagina == 2)
            {
                this.bOpt2.Location = new System.Drawing.Point(bx, 540 + deltaY);
                this.bOpt2.Size = new System.Drawing.Size(25, 25);
            }

            this.bOpt2.Name = "bOpt2";
            this.bOpt2.TabIndex = 2;
            this.bOpt2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bOpt2.UseVisualStyleBackColor = true;
            this.bOpt2.Click += new System.EventHandler(this.onClick);

            #endregion

            // bOpt3

            #region

            if (pagina == 1)
            {
                this.bOpt3.Location = new System.Drawing.Point(680, 600);
                this.bOpt3.Size = new System.Drawing.Size(150, 75);
                this.bOpt3.Text = text3;
            }

            else if (pagina == 2)
            {
                this.bOpt3.Location = new System.Drawing.Point(bx, 590 + deltaY);
                this.bOpt3.Size = new System.Drawing.Size(25, 25);
            }

            this.bOpt3.Name = "bOpt3";
            this.bOpt3.TabIndex = 3;
            this.bOpt3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bOpt3.UseVisualStyleBackColor = true;
            this.bOpt3.Click += new System.EventHandler(this.onClick);

            #endregion

            // ok

            #region

            this.ok.ForeColor = System.Drawing.Color.MidnightBlue;
            this.ok.Location = new System.Drawing.Point(630, 730);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(130, 75);
            this.ok.TabIndex = 4;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.onClick);

            #endregion

            // smile

            #region

            this.smile.BackColor = System.Drawing.Color.Transparent;
            this.smile.Location = new System.Drawing.Point(395, 675);
            this.smile.Name = "smile";
            this.smile.Size = new System.Drawing.Size(120, 130);
            this.smile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.smile.TabIndex = 7;
            this.smile.TabStop = false;

            #endregion

            // esci

            #region

            this.esci.ForeColor = System.Drawing.Color.MidnightBlue;
            this.esci.Location = new System.Drawing.Point(0, 10);
            this.esci.Name = "esci";
            this.esci.Size = new System.Drawing.Size(100, 50);
            this.esci.TabIndex = 5;
            this.esci.Text = "Esci";
            this.esci.UseVisualStyleBackColor = true;
            this.esci.Click += new System.EventHandler(this.onClick);

            #endregion

            // tOpt1

            #region

            this.tOpt1.TextAlign = ContentAlignment.MiddleLeft;
            this.tOpt1.Text = text1;
            this.tOpt1.BackColor = System.Drawing.Color.Transparent;
            this.tOpt1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.tOpt1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.tOpt1.FlatAppearance.BorderSize = 0;
            this.tOpt1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tOpt1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tOpt1.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Regular);
            this.tOpt1.Location = new System.Drawing.Point(tx, 485 + deltaY);
            this.tOpt1.Name = "tOpt1";
            this.tOpt1.Size = new System.Drawing.Size(500, 35);
            this.tOpt1.TabIndex = 15;
            this.tOpt1.UseVisualStyleBackColor = true;

            #endregion

            // tOpt2

            #region

            this.tOpt2.Text = text2;
            this.tOpt2.TextAlign = ContentAlignment.MiddleLeft;
            this.tOpt2.TextAlign = ContentAlignment.MiddleLeft;
            this.tOpt2.FlatAppearance.BorderSize = 0;
            this.tOpt2.BackColor = System.Drawing.Color.Transparent;
            this.tOpt2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.tOpt2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.tOpt2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tOpt2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tOpt2.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Regular);
            this.tOpt2.Size = new System.Drawing.Size(500, 35);
            this.tOpt2.Location = new Point(tx, 535 + deltaY);
            this.tOpt2.Name = "tOpt2";
            this.tOpt2.TabIndex = 15;
            this.tOpt2.UseVisualStyleBackColor = true;

            #endregion

            // tOpt3

            #region

            this.tOpt3.Text = text3;
            this.tOpt3.FlatAppearance.BorderSize = 0;
            this.tOpt3.TextAlign = ContentAlignment.MiddleLeft;
            this.tOpt3.BackColor = System.Drawing.Color.Transparent;
            this.tOpt3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.tOpt3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.tOpt3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tOpt3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tOpt3.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Regular);
            this.tOpt3.Name = "tOpt3";
            this.tOpt3.Size = new System.Drawing.Size(500, 35);
            this.tOpt3.Location = new Point(tx, 585 + deltaY);
            this.tOpt3.TabIndex = 16;
            this.tOpt3.UseVisualStyleBackColor = true;



            #endregion

            // avanti

            #region

            this.avanti.ForeColor = System.Drawing.Color.MidnightBlue;
            this.avanti.Location = new System.Drawing.Point(600, 920);//[RIV] 600, 940
            this.avanti.Name = "avanti";
            this.avanti.Size = new System.Drawing.Size(150, 75);
            this.avanti.TabIndex = 6;
            this.avanti.Text = "Avanti";
            this.avanti.UseVisualStyleBackColor = true;
            this.avanti.Click += new System.EventHandler(this.onClick);

            #endregion

            // menu

            #region

            this.menu.Text = "Menu";
            this.menu.Size = new System.Drawing.Size(150, 75);
            this.menu.Location = new System.Drawing.Point(235, 920);//[RIV] 235, 940
            this.menu.UseVisualStyleBackColor = true;
            this.menu.ForeColor = System.Drawing.Color.MidnightBlue;
            this.menu.Name = "menu";
            this.menu.TabIndex = 600;
            this.menu.Click += new System.EventHandler(this.onClick);

            #endregion

            // menu2

            #region

            this.menu2.Name = "menu";
            this.menu2.TabIndex = 101;
            this.menu2.UseVisualStyleBackColor = true;
            this.menu2.Size = new System.Drawing.Size(600, 200);
            this.menu2.Location = new System.Drawing.Point(300, 510);
            //this.menu2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            //this.menu2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            //this.menu2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu2.BackColor = System.Drawing.Color.Azure;
            this.menu2.ForeColor = System.Drawing.Color.MidnightBlue;
            //this.menu2.FlatAppearance.BorderSize = 1;
            this.menu2.Font = new Font("Verdana", (float)widthFactor * 32F, FontStyle.Bold);
            this.menu2.Text = "MENU!";
            this.menu2.Click += new System.EventHandler(this.onClick);

            #endregion

            // viola

            #region

            this.viola.Image = global::Negozio_di_Viola.Properties.Resources.Viola;
            //this.viola.Location = new System.Drawing.Point(28, 245);
            this.viola.Location = new System.Drawing.Point(0, 0);
            this.viola.Name = "viola";
            this.viola.Size = new System.Drawing.Size(750, 1500);
            this.viola.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.viola.TabIndex = 8;
            this.viola.TabStop = false;

            #endregion

            // testo, testo2, testo3, testo4, testo5 e indietro

            #region

            if (pagina == 1)
            {
                int x1, x2, x3, y, d1, d2, d3, dist;

                d1 = 430;
                d2 = 150;
                d3 = 220;
                dist = -20;
                x1 = -20;//10;//[RIV]
                x2 = x1 + d1 + dist;
                x3 = x2 + d2 + dist + 10;
                y = 260;

                this.indietro.Name = "indietro";
                this.indietro.Click += new System.EventHandler(this.onClick);
                this.nota1.Text = "(se non te ne sei accorto torna al";
                this.indietro.Text = "NEGOZIO";
                this.nota2.Text = "per controllare),";
                this.nota1.ForeColor = System.Drawing.Color.MidnightBlue;
                this.indietro.ForeColor = System.Drawing.Color.MidnightBlue;
                this.nota2.ForeColor = System.Drawing.Color.MidnightBlue;
                this.nota1.BackColor = System.Drawing.Color.White;
                this.indietro.BackColor = System.Drawing.Color.Azure;
                this.nota2.BackColor = System.Drawing.Color.White;
                this.nota1.Size = new System.Drawing.Size(d1, 40);
                this.indietro.Size = new System.Drawing.Size(d2, 40);
                this.nota2.Size = new System.Drawing.Size(d3, 40);
                this.nota1.Location = new System.Drawing.Point(x1, y);
                this.indietro.Location = new System.Drawing.Point(x2, y);
                this.nota2.Location = new System.Drawing.Point(x3, y);
                this.nota1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
                this.nota1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
                this.nota1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.nota2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
                this.nota2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
                this.nota2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.nota1.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
                this.indietro.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
                this.nota2.Font = new Font("Verdana", (float)widthFactor * 14F, FontStyle.Bold);
                this.nota1.FlatAppearance.BorderSize = 0;
                this.nota2.FlatAppearance.BorderSize = 0;

                this.testo.Text = "In fabbrica ho comprato le scarpe pagandole";
                this.testo2.Text = Globals.scarpe.PrezzoAcquisto + "€";
                this.testo3.Text = "Hai visto che voglio vendere quelle scarpe a";
                this.testo4.Text = Globals.scarpe.PrezzoVendita + "€";
                this.testo5.Text = "quindi ad un prezzo";
                this.testo.Size = new System.Drawing.Size(650, 60);
                this.testo2.Size = new System.Drawing.Size(200, 60);
                this.testo3.Size = new System.Drawing.Size(720, 60);
                this.testo4.Size = new System.Drawing.Size(200, 60);
                this.testo5.Size = new System.Drawing.Size(720, 60);
                this.testo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
                this.testo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
                this.testo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.testo2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
                this.testo2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
                this.testo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.testo3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
                this.testo3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
                this.testo3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.testo4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
                this.testo4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
                this.testo4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.testo5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
                this.testo5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
                this.testo5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.testo2.FlatAppearance.BorderSize = 0;
                this.testo2.ForeColor = System.Drawing.Color.Red;
                this.testo3.FlatAppearance.BorderSize = 0;
                this.testo3.ForeColor = System.Drawing.Color.MidnightBlue;
                this.testo4.FlatAppearance.BorderSize = 0;
                this.testo4.ForeColor = System.Drawing.Color.Red;
                this.testo5.FlatAppearance.BorderSize = 0;
                this.testo5.ForeColor = System.Drawing.Color.MidnightBlue;
                this.testo.BackColor = System.Drawing.Color.White;
                this.testo2.BackColor = System.Drawing.Color.White;
                this.testo3.BackColor = System.Drawing.Color.White;
                this.testo4.BackColor = System.Drawing.Color.White;
                this.testo5.BackColor = System.Drawing.Color.White;
                this.testo.Location = new System.Drawing.Point(10, 20);
                this.testo2.Location = new System.Drawing.Point(280, 75);
                this.testo3.Location = new System.Drawing.Point(10, 130);
                this.testo4.Location = new System.Drawing.Point(280, 185);
                this.testo5.Location = new System.Drawing.Point(10, 295);
                this.testo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
                this.testo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
                this.testo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.testo2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
                this.testo2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
                this.testo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.testo3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
                this.testo3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
                this.testo3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.testo4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
                this.testo4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
                this.testo4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.testo5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
                this.testo5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
                this.testo5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.testo2.Name = "testo2";
                this.testo2.TabIndex = 91;
                this.testo3.Name = "testo3";
                this.testo3.TabIndex = 92;
                this.testo4.Name = "testo4";
                this.testo4.TabIndex = 93;
                this.testo5.Name = "testo5";
                this.testo5.TabIndex = 94;
                this.testo.Font = new Font("Verdana", (float)widthFactor * 18F, FontStyle.Bold);
                this.testo2.Font = new Font("Verdana", (float)widthFactor * 32F, FontStyle.Bold);
                this.testo3.Font = new Font("Verdana", (float)widthFactor * 18F, FontStyle.Bold);
                this.testo4.Font = new Font("Verdana", (float)widthFactor * 32F, FontStyle.Bold);
                this.testo5.Font = new Font("Verdana", (float)widthFactor * 18F, FontStyle.Bold);
            }

            else if (pagina == 2)
            {
                this.testo.Text = "Hai notato che voglio vendere le scarpe ad un prezzo maggiore di quello a cui ";
                this.testo.Text += "l'ho comprato. Come mai?";
                this.testo.Font = new Font("Verdana", (float)widthFactor * 32F, FontStyle.Bold);
                this.testo.Size = new System.Drawing.Size(640, 280);
                this.testo.BackColor = System.Drawing.Color.White;
                this.testo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
                this.testo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
                this.testo.Location = new System.Drawing.Point(20, 20);
            }

            else if (pagina == 22)
            {
                this.testo.Text = "Voglio vendere le scarpe ad un prezzo maggiore di quello a cui l'ho comprato!";
                this.testo.Size = new System.Drawing.Size(660, 525);
                this.testo.Font = new Font("Verdana", (float)widthFactor * 32F, FontStyle.Bold);
                this.testo.Location = new System.Drawing.Point(10, 10);
                //BY   Negozio2.text = Globals.fumChiamaCliente;
                //BY   Negozio2.textSetted = true;
            }

            else if (pagina == 3)
            {
                this.testo.Text = "Eh, no!! Vendere è il mio lavoro e io da questa vendita voglio guadagnare, cioè aumentare i";
                this.testo.Text += " soldi nel mio portafoglio! Ora aspetto un cliente che venga a comprare le scarpe.";
                this.testo.Size = new System.Drawing.Size(660, 520); //435
                this.testo.Font = new Font("Verdana", (float)widthFactor * 32F, FontStyle.Bold);
                this.testo.Location = new System.Drawing.Point(10, 15);
                this.testo.FlatAppearance.BorderSize = 2;
                this.testo.BackColor = System.Drawing.Color.White;
                //BY Negozio2.text = Globals.fumChiamaCliente;
                //BY Negozio2.textSetted = true;
            }

            else if (pagina == 4)
            {
                this.testo.Text = "Esatto! Ora aspetto un cliente che venga a comprare le scarpe!";
                this.testo.Size = new System.Drawing.Size(660, 525);
                this.testo.Font = new Font("Verdana", (float)widthFactor * 32F, FontStyle.Bold);
                this.testo.Location = new System.Drawing.Point(10, 10);
                //BY Negozio2.text = Globals.fumChiamaCliente;
                //BY Negozio2.textSetted = true;
            }

            else if (pagina == 100)
            {
                this.testo.Text = "Bravo! Torna al ";
                this.testo.Size = new System.Drawing.Size(660, 300);
                this.testo.Font = new Font("Verdana", (float)widthFactor * 32F, FontStyle.Bold);
                this.testo.Location = new System.Drawing.Point(10, 10);
                //BY Negozio2.text = Globals.fumChiamaCliente;
                //BY Negozio2.textSetted = true;
            }

            this.testo.BackColor = System.Drawing.Color.White;
            this.testo.FlatAppearance.BorderSize = 0;
            this.testo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.testo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.testo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testo.ForeColor = System.Drawing.Color.MidnightBlue;

            this.testo.Name = "testo";
            this.testo.TabIndex = 9;
            //this.testo.Text = "In fabbrica ho pagato le scarpe " + Mappa.pFabbrica + ". Voglio vendere le scarpe a ";
            //this.testo.Text += Mappa.pNegozio + ". Il prezzo delle scarpe adesso è";
            this.testo.UseVisualStyleBackColor = true;

            #endregion

            // panelTesto

            #region

            this.panelTesto.BackColor = System.Drawing.Color.Transparent;
            this.panelTesto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.panelTesto.Location = new Point(0, 0);
            this.panelTesto.Name = "panelTesto";

            if (pagina != 100)

                this.panelTesto.Size = new System.Drawing.Size(1120, 600);

            else

                this.panelTesto.Size = new System.Drawing.Size(1120, 510);

            this.panelTesto.TabIndex = 40;
            this.Controls.Add(this.testo);

            if (pagina == 1)
            {
                this.Controls.Add(this.testo2);
                this.Controls.Add(this.testo3);
                this.Controls.Add(this.testo4);
                this.Controls.Add(this.testo5);
                this.Controls.Add(this.nota1);
                this.Controls.Add(this.nota2);
                this.Controls.Add(this.indietro);
            }

            indietro.BringToFront();

            #endregion

            // panelViola

            #region

            this.panelViola.Name = "panelViola";
            this.panelViola.TabIndex = 11;
            this.panelViola.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.panelViola.Size = new System.Drawing.Size(800, 1000);
            this.panelViola.Location = new Point(720, 0);//710, 0 //[RIV]
            this.panelViola.Controls.Add(this.viola);

            #endregion

            // panel

            #region
            //          bmp = new Bitmap(Globals.immaginiPath + "nuvoletta.png");
            bmp = new Bitmap(global::Negozio_di_Viola.Properties.Resources.nuvoletta);
            BgImg = new Bitmap(bmp, new Size(1125, 1000));//[RIV]1200, 1000
            this.panel.BackgroundImage = BgImg;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.None;

            if (pagina == 1)
            {
                this.panel.Controls.Add(this.bOpt1);
                this.panel.Controls.Add(this.bOpt2);
                this.panel.Controls.Add(this.bOpt3);
                this.panel.Controls.Add(this.ok);
                this.panel.Controls.Add(this.smile);
            }

            else if (pagina == 2)
            {
                this.panel.Controls.Add(this.bOpt1);
                this.panel.Controls.Add(this.bOpt2);
                this.panel.Controls.Add(this.bOpt3);
                this.panel.Controls.Add(this.tOpt1);
                this.panel.Controls.Add(this.tOpt2);
                this.panel.Controls.Add(this.tOpt3);
                this.panel.Controls.Add(this.ok);
                this.panel.Controls.Add(this.smile);
            }


            //this.panel.Controls.Add(this.esci);

            if (pagina != 100)
            {
                this.panel.Controls.Add(this.avanti);
                this.panel.Controls.Add(this.menu);
            }

            else
            {
                this.panel.Controls.Add(this.menu2);
            }

            this.panel.Location = new Point(-220, -220);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1120, 1000);
            this.panel.TabIndex = 10;

            #endregion

            // Fumetto

            #region

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 749);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Fumetto";
            this.Text = "Fumetto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.panel);
            this.panel.Controls.Add(this.panelTesto);
            this.Controls.Add(this.panelViola);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Fumetto";
            this.Text = "Fumetto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Fumetto_Load);

            ((System.ComponentModel.ISupportInitialize)(this.smile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viola)).EndInit();
            this.panel.ResumeLayout(false);
            this.panelViola.ResumeLayout(false);
            this.ResumeLayout(false);

            #endregion

        }

        #endregion

        private void setValues()
        {
            // Scelgo casualmente la disposizione delle risposte.


            disposizione = Globals.global_rnd.Next(1, 7);

            int x = 426;
            int p = 490;
            //int x = 226;
            //int p = 290;

            switch (disposizione)
            {
                case 1:

                    if (pagina == 1)
                    {
                        text1 = ">\nMaggiore";
                        text2 = "<\nMinore";
                        text3 = "=\nUguale";
                    }

                    else if (pagina == 2)
                    {
                        text1 = "Voglio guadagnare dalla vendita.";
                        text2 = "Mi sono sbagliata.";
                        text3 = "In realtà potevo mettere un prezzo qualsiasi.";

                        size1 = new System.Drawing.Size(x, 30);
                        point1 = new System.Drawing.Point(p, 400);
                        size2 = new System.Drawing.Size(x, 30);
                        point2 = new System.Drawing.Point(p, 400);
                        size3 = new System.Drawing.Size(x, 30);
                        point3 = new System.Drawing.Point(p, 400);
                    }

                    risCorretta = 1;

                    break;

                case 2:

                    if (pagina == 1)
                    {
                        text1 = ">\nMaggiore";
                        text2 = "=\nMinore";
                        text3 = "<\nUguale";
                    }

                    else if (pagina == 2)
                    {
                        text1 = "Voglio guadagnare dalla vendita.";
                        text2 = "In realtà potevo mettere un prezzo qualsiasi.";
                        text3 = "Mi sono sbagliata.";

                        size1 = new System.Drawing.Size(x, 30);
                        point1 = new System.Drawing.Point(p, 400);
                        size2 = new System.Drawing.Size(x, 30);
                        point2 = new System.Drawing.Point(p, 400);
                        size3 = new System.Drawing.Size(x, 30);
                        point3 = new System.Drawing.Point(p, 400);
                    }

                    risCorretta = 1;

                    break;

                case 3:

                    if (pagina == 1)
                    {
                        text1 = "<\nMinore";
                        text2 = ">\nMaggiore";
                        text3 = "=\nUguale";
                    }

                    else if (pagina == 2)
                    {
                        text1 = "Mi sono sbagliata.";
                        text2 = "Voglio guadagnare dalla vendita.";
                        text3 = "In realtà potevo mettere un prezzo qualsiasi.";

                        size1 = new System.Drawing.Size(x, 30);
                        point1 = new System.Drawing.Point(p, 400);
                        size2 = new System.Drawing.Size(x, 30);
                        point2 = new System.Drawing.Point(p, 400);
                        size3 = new System.Drawing.Size(x, 30);
                        point3 = new System.Drawing.Point(p, 400);
                    }

                    risCorretta = 2;

                    break;

                case 4:

                    if (pagina == 1)
                    {
                        text1 = "<\nMinore";
                        text2 = "=\nUguale";
                        text3 = ">\nMaggiore";
                    }

                    else if (pagina == 2)
                    {
                        text1 = "Mi sono sbagliata.";
                        text2 = "In realtà potevo mettere un prezzo qualsiasi.";
                        text3 = "Voglio guadagnare dalla vendita.";

                        size1 = new System.Drawing.Size(x, 30);
                        point1 = new System.Drawing.Point(p, 400);
                        size2 = new System.Drawing.Size(x, 30);
                        point2 = new System.Drawing.Point(p, 400);
                        size3 = new System.Drawing.Size(x, 30);
                        point3 = new System.Drawing.Point(p, 400);
                    }

                    risCorretta = 3;

                    break;

                case 5:

                    if (pagina == 1)
                    {
                        text1 = "=\nUguale";
                        text2 = ">\nMaggiore";
                        text3 = "<\nMinore";
                    }

                    else if (pagina == 2)
                    {
                        text1 = "In realtà potevo mettere un prezzo qualsiasi.";
                        text2 = "Voglio guadagnare dalla vendita.";
                        text3 = "Mi sono sbagliata.";

                        size1 = new System.Drawing.Size(x, 30);
                        point1 = new System.Drawing.Point(p, 400);
                        size2 = new System.Drawing.Size(x, 30);
                        point2 = new System.Drawing.Point(p, 400);
                        size3 = new System.Drawing.Size(x, 30);
                        point3 = new System.Drawing.Point(p, 400);
                    }

                    risCorretta = 2;

                    break;

                default:

                    if (pagina == 1)
                    {
                        text1 = "=\nUguale";
                        text2 = "<\nMinore";
                        text3 = ">\nMaggiore";
                    }

                    else if (pagina == 2)
                    {
                        text1 = "In realtà potevo mettere un prezzo qualsiasi.";
                        text2 = "Mi sono sbagliata.";
                        text3 = "Voglio guadagnare dalla vendita.";

                        size1 = new System.Drawing.Size(x, 30);
                        point1 = new System.Drawing.Point(p, 400);
                        size2 = new System.Drawing.Size(x, 30);
                        point2 = new System.Drawing.Point(p, 400);
                        size3 = new System.Drawing.Size(x, 30);
                        point3 = new System.Drawing.Point(p, 400);
                    }

                    risCorretta = 3;

                    break;
            }
        }

        private int risUtente, risCorretta, disposizione, pagina;
        private string text1, text2, text3;
        private Size size1, size2, size3;
        private Point point1, point2, point3;
        private System.Drawing.Bitmap bmp;
        private System.Drawing.Bitmap BgImg;
        private System.Windows.Forms.Button avanti;
        private System.Windows.Forms.Button menu;
        private System.Windows.Forms.Button menu2;
        private System.Windows.Forms.Button bOpt1;
        private System.Windows.Forms.Button bOpt2;
        private System.Windows.Forms.Button bOpt3;
        private System.Windows.Forms.Button esci;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button indietro;
        private System.Windows.Forms.Button nota1;
        private System.Windows.Forms.Button nota2;
        private System.Windows.Forms.Button testo;
        private System.Windows.Forms.Button testo2;
        private System.Windows.Forms.Button testo3;
        private System.Windows.Forms.Button testo4;
        private System.Windows.Forms.Button testo5;
        private System.Windows.Forms.Button tOpt1;
        private System.Windows.Forms.Button tOpt2;
        private System.Windows.Forms.Button tOpt3;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel panelTesto;
        private System.Windows.Forms.Panel panelViola;
        private System.Windows.Forms.PictureBox smile;
        private System.Windows.Forms.PictureBox viola;
    }
}
