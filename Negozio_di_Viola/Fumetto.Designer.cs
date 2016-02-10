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
            this.SuspendLayout();
            // 
            // Fumetto
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "Fumetto";
            this.ResumeLayout(false);

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
