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
    public partial class Calcolatrice : Form
    {
        int operation;
        bool virgola = false;
        string euro;
        string cent;
        string risultato;
        string[] elementi_risultato;
        double num1 = 0;
        double num2 =0;
        double ans = 0;
        double temp;

        //COSTRUTTORE--------------------------------------------------------
        public Calcolatrice()
        {
            //Globals.calcolatrice.Location = new Point((Globals.screenWidth / 2), (Globals.screenHeight / 2));
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(Calcolatrice_KeyPress);
            InitializeComponent();
            Adattamento_Risoluzione();
            TextBoxE.Text = null;
            TextBoxC.Text = null;
        }

        //SETTAGGIO COLORI------------------------------------------------------
        private void Calcolatrice_Load(object sender, EventArgs e)
        {
            button1.BackColor = ColorTranslator.FromHtml("#33CC33");
            button2.BackColor = ColorTranslator.FromHtml("#33CC33");
            button3.BackColor = ColorTranslator.FromHtml("#33CC33");
            button4.BackColor = ColorTranslator.FromHtml("#33CC33");
            button5.BackColor = ColorTranslator.FromHtml("#33CC33");
            button6.BackColor = ColorTranslator.FromHtml("#33CC33");
            button7.BackColor = ColorTranslator.FromHtml("#33CC33");
            button8.BackColor = ColorTranslator.FromHtml("#33CC33");
            button9.BackColor = ColorTranslator.FromHtml("#33CC33");
            button0.BackColor = ColorTranslator.FromHtml("#33CC33");
            buttonPlus.BackColor = ColorTranslator.FromHtml("#33CC33");
            buttonMinus.BackColor = ColorTranslator.FromHtml("#33CC33");
            buttonX.BackColor = ColorTranslator.FromHtml("#33CC33");
            buttonC.BackColor = ColorTranslator.FromHtml("#33CC33");
            buttonCE.BackColor = ColorTranslator.FromHtml("#33CC33");
            buttonV.BackColor = ColorTranslator.FromHtml("#33CC33");
            buttonEqual.BackColor = ColorTranslator.FromHtml("#33CC33");
            buttonExit.BackColor = ColorTranslator.FromHtml("#33CC33");

        }      

        //ADATTAMENTO ALLA RISOLUZIONE--------------------------------------------------------
        private void Adattamento_Risoluzione()
        {
        //  int screen_Height = Screen.PrimaryScreen.Bounds.Height;
        //  int screen_Width = Screen.PrimaryScreen.Bounds.Width;

        //  double widthFactor = (double) screen_Width / this.Size.Width;
        //  double heightFactor = (double) screen_Height / this.Size.Height;

            double widthFactor = Globals.widthFactor;
            double heightFactor = Globals.heightFactor;

            this.Width = (int)(this.Width * widthFactor);
            this.Height = (int)(this.Height * heightFactor);
            TextBoxE.Width = (int)(TextBoxE.Width * widthFactor);
            TextBoxE.Height = (int)(TextBoxE.Height * heightFactor);
            TextBoxC.Width = (int)(TextBoxC.Width * widthFactor);
            TextBoxC.Height = (int)(TextBoxC.Height * heightFactor);
            button1.Width = (int)(button1.Width * widthFactor);
            button1.Height = (int)(button1.Height * heightFactor);
            button2.Width = (int)(button2.Width * widthFactor);
            button2.Height = (int)(button2.Height * heightFactor);
            button3.Width = (int)(button3.Width * widthFactor);
            button3.Height = (int)(button3.Height * heightFactor);
            button4.Width = (int)(button4.Width * widthFactor);
            button4.Height = (int)(button4.Height * heightFactor);
            button5.Width = (int)(button5.Width * widthFactor);
            button5.Height = (int)(button5.Height * heightFactor);
            button6.Width = (int)(button6.Width * widthFactor);
            button6.Height = (int)(button6.Height * heightFactor);
            button7.Width = (int)(button7.Width * widthFactor);
            button7.Height = (int)(button7.Height * heightFactor);
            button8.Width = (int)(button8.Width * widthFactor);
            button8.Height = (int)(button8.Height * heightFactor);
            button9.Width = (int)(button9.Width * widthFactor);
            button9.Height = (int)(button9.Height * heightFactor);
            button0.Width = (int)(button0.Width * widthFactor);
            button0.Height = (int)(button0.Height * heightFactor);
            buttonC.Width = (int)(buttonC.Width * widthFactor);
            buttonC.Height = (int)(buttonC.Height * heightFactor);
            buttonCE.Width = (int)(buttonCE.Width * widthFactor);
            buttonCE.Height = (int)(buttonCE.Height * heightFactor);
            buttonPlus.Width = (int)(buttonPlus.Width * widthFactor);
            buttonPlus.Height = (int)(buttonPlus.Height * heightFactor);
            buttonMinus.Width = (int)(buttonMinus.Width * widthFactor);
            buttonMinus.Height = (int)(buttonMinus.Height * heightFactor);
            buttonX.Width = (int)(buttonX.Width * widthFactor);
            buttonX.Height = (int)(buttonX.Height * heightFactor);
            buttonEqual.Width = (int)(buttonEqual.Width * widthFactor);
            buttonEqual.Height = (int)(buttonEqual.Height * heightFactor);
            buttonExit.Width = (int)(buttonExit.Width * widthFactor);
            buttonExit.Height = (int)(buttonExit.Height * heightFactor);
            buttonV.Width = (int)(buttonV.Width * widthFactor);
            buttonV.Height = (int)(buttonV.Height * heightFactor);
            label1.Width = (int)(label1.Width * widthFactor);
            label1.Height = (int)(label1.Height * heightFactor);
            label2.Width = (int)(label2.Width * widthFactor);
            label2.Height = (int)(label2.Height * heightFactor);
            labelVirg.Width = (int)(labelVirg.Width * widthFactor);
            labelVirg.Height = (int)(labelVirg.Height * heightFactor);
            labelEuro.Width = (int)(labelEuro.Width * widthFactor);
            labelEuro.Height = (int)(labelEuro.Height * heightFactor);
            labelCent.Width = (int)(labelCent.Width * widthFactor);
            labelCent.Height = (int)(labelCent.Height * heightFactor);
            labelUguale.Width = (int)(labelUguale.Width * widthFactor);
            labelUguale.Height = (int)(labelUguale.Height * heightFactor);
            labelRis.Width = (int)(labelRis.Width * widthFactor);
            labelRis.Height = (int)(labelRis.Height * heightFactor);
            labelSegno.Width = (int)(labelSegno.Width * widthFactor);
            labelSegno.Height = (int)(labelSegno.Height * heightFactor);
            labelErrore.Width = (int)(labelErrore.Width * widthFactor);
            labelErrore.Height = (int)(labelErrore.Height * heightFactor);
            labelV2.Width = (int)(labelV2.Width * widthFactor);
            labelV2.Height = (int)(labelV2.Height * heightFactor);
            labelV3.Width = (int)(labelV3.Width * widthFactor);
            labelV3.Height = (int)(labelV3.Height * heightFactor);
            labelV4.Width = (int)(labelV4.Width * widthFactor);
            labelV4.Height = (int)(labelV4.Height * heightFactor);
            label1C.Width = (int)(label1C.Width * widthFactor);
            label1C.Height = (int)(label1C.Height * heightFactor);
            label2C.Width = (int)(label2C.Width * widthFactor);
            label2C.Height = (int)(label2C.Height * heightFactor);
            labelRisC.Width = (int)(labelRisC.Width * widthFactor);
            labelRisC.Height = (int)(labelRisC.Height * heightFactor);
            labelLine.Width = (int)(labelRisC.Width * widthFactor);
            labelLine.Height = (int)(labelRisC.Height * heightFactor);

            this.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)widthFactor * 24F);
            TextBoxE.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)widthFactor * 24F);
            TextBoxC.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)widthFactor * 24F);
            button1.Font = new System.Drawing.Font("Wasco Sans", (float)widthFactor * 24F);
            button2.Font = new System.Drawing.Font("Wasco Sans", (float)widthFactor * 24F);
            button3.Font = new System.Drawing.Font("Wasco Sans", (float)widthFactor * 24F);
            button4.Font = new System.Drawing.Font("Wasco Sans", (float)widthFactor * 24F);
            button5.Font = new System.Drawing.Font("Wasco Sans", (float)widthFactor * 24F);
            button6.Font = new System.Drawing.Font("Wasco Sans", (float)widthFactor * 24F);
            button7.Font = new System.Drawing.Font("Wasco Sans", (float)widthFactor * 24F);
            button8.Font = new System.Drawing.Font("Wasco Sans", (float)widthFactor * 24F);
            button9.Font = new System.Drawing.Font("Wasco Sans", (float)widthFactor * 24F);
            button0.Font = new System.Drawing.Font("Wasco Sans", (float)widthFactor * 24F);
            buttonC.Font = new System.Drawing.Font("Wasco Sans", (float)widthFactor * 24F);
            buttonCE.Font = new System.Drawing.Font("Wasco Sans", (float)widthFactor * 24F);
            buttonPlus.Font = new System.Drawing.Font("Wasco Sans", (float)widthFactor * 24F);
            buttonMinus.Font = new System.Drawing.Font("Wasco Sans", (float)widthFactor * 24F);
            buttonX.Font = new System.Drawing.Font("Wasco Sans", (float)widthFactor * 24F);
            buttonEqual.Font = new System.Drawing.Font("Wasco Sans", (float)widthFactor * 24F);
            buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)widthFactor * 16F);
            buttonV.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)widthFactor * 16F);
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)widthFactor * 16F);
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)widthFactor * 16F);
            labelVirg.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)widthFactor * 16F);
            labelV2.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)widthFactor * 16F);
            labelV3.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)widthFactor * 16F);
            labelV4.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)widthFactor * 16F);
            labelEuro.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)widthFactor * 16F);
            labelRisC.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)widthFactor * 16F);
            labelCent.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)widthFactor * 16F);
            label1C.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)widthFactor * 16F);
            label2C.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)widthFactor * 16F);
            labelUguale.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)widthFactor * 16F);
            labelRis.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)widthFactor * 16F);
            labelSegno.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)widthFactor * 16F);
            labelErrore.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)widthFactor * 16F);
            labelLine.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)widthFactor * 16F);

            this.Location = new Point((int)(this.Location.X * widthFactor), (int)(this.Location.Y * heightFactor));
            TextBoxE.Location = new Point((int)(TextBoxE.Location.X * widthFactor), (int)(TextBoxE.Location.Y * heightFactor));
            TextBoxC.Location = new Point((int)(TextBoxC.Location.X * widthFactor), (int)(TextBoxC.Location.Y * heightFactor));
            button1.Location = new Point((int)(button1.Location.X * widthFactor), (int)(button1.Location.Y * heightFactor));
            button2.Location = new Point((int)(button2.Location.X * widthFactor), (int)(button2.Location.Y * heightFactor));
            button3.Location = new Point((int)(button3.Location.X * widthFactor), (int)(button3.Location.Y * heightFactor));
            button4.Location = new Point((int)(button4.Location.X * widthFactor), (int)(button4.Location.Y * heightFactor));
            button5.Location = new Point((int)(button5.Location.X * widthFactor), (int)(button5.Location.Y * heightFactor));
            button6.Location = new Point((int)(button6.Location.X * widthFactor), (int)(button6.Location.Y * heightFactor));
            button7.Location = new Point((int)(button7.Location.X * widthFactor), (int)(button7.Location.Y * heightFactor));
            button8.Location = new Point((int)(button8.Location.X * widthFactor), (int)(button8.Location.Y * heightFactor));
            button9.Location = new Point((int)(button9.Location.X * widthFactor), (int)(button9.Location.Y * heightFactor));
            button0.Location = new Point((int)(button0.Location.X * widthFactor), (int)(button0.Location.Y * heightFactor));
            buttonC.Location = new Point((int)(buttonC.Location.X * widthFactor), (int)(buttonC.Location.Y * heightFactor));
            buttonCE.Location = new Point((int)(buttonCE.Location.X * widthFactor), (int)(buttonCE.Location.Y * heightFactor));
            buttonPlus.Location = new Point((int)(buttonPlus.Location.X * widthFactor), (int)(buttonPlus.Location.Y * heightFactor));
            buttonMinus.Location = new Point((int)(buttonMinus.Location.X * widthFactor), (int)(buttonMinus.Location.Y * heightFactor));
            buttonX.Location = new Point((int)(buttonX.Location.X * widthFactor), (int)(buttonX.Location.Y * heightFactor));
            buttonEqual.Location = new Point((int)(buttonEqual.Location.X * widthFactor), (int)(buttonEqual.Location.Y * heightFactor));
            buttonExit.Location = new Point((int)(buttonExit.Location.X * widthFactor), (int)(buttonExit.Location.Y * heightFactor));
            buttonV.Location = new Point((int)(buttonV.Location.X * widthFactor), (int)(buttonV.Location.Y * heightFactor));
            label1.Location = new Point((int)(label1.Location.X * widthFactor), (int)(label1.Location.Y * heightFactor));
            label2.Location = new Point((int)(label2.Location.X * widthFactor), (int)(label2.Location.Y * heightFactor));
            label1C.Location = new Point((int)(label1C.Location.X * widthFactor), (int)(label1C.Location.Y * heightFactor));
            label2C.Location = new Point((int)(label2C.Location.X * widthFactor), (int)(label2C.Location.Y * heightFactor));
            labelRisC.Location = new Point((int)(labelRisC.Location.X * widthFactor), (int)(labelRisC.Location.Y * heightFactor));
            labelVirg.Location = new Point((int)(labelVirg.Location.X * widthFactor), (int)(labelVirg.Location.Y * heightFactor));
            labelV2.Location = new Point((int)(labelV2.Location.X * widthFactor), (int)(labelV2.Location.Y * heightFactor));
            labelV3.Location = new Point((int)(labelV3.Location.X * widthFactor), (int)(labelV3.Location.Y * heightFactor));
            labelV4.Location = new Point((int)(labelV4.Location.X * widthFactor), (int)(labelV4.Location.Y * heightFactor));
            labelEuro.Location = new Point((int)(labelEuro.Location.X * widthFactor), (int)(labelEuro.Location.Y * heightFactor));
            labelCent.Location = new Point((int)(labelCent.Location.X * widthFactor), (int)(labelCent.Location.Y * heightFactor));
            labelUguale.Location = new Point((int)(labelUguale.Location.X * widthFactor), (int)(labelUguale.Location.Y * heightFactor));
            labelRis.Location = new Point((int)(labelRis.Location.X * widthFactor), (int)(labelRis.Location.Y * heightFactor));
            labelSegno.Location = new Point((int)(labelSegno.Location.X * widthFactor), (int)(labelSegno.Location.Y * heightFactor));
            labelErrore.Location = new Point((int)(labelErrore.Location.X * widthFactor), (int)(labelErrore.Location.Y * heightFactor));
            labelLine.Location = new Point((int)(labelLine.Location.X * widthFactor), (int)(labelLine.Location.Y * heightFactor));
        }

        //GESTIONE INPUT DA TASTIERA--------------------------------------------------------
        void Calcolatrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar >= 42 && e.KeyChar <= 46 || e.KeyChar == 08 || e.KeyChar == 83 || e.KeyChar == 61 || e.KeyChar == 13)
            {
                switch (e.KeyChar)
                {
                    case (char)42:          //caso *
                        Multiply_function();
                        break;
                    case (char)43:          //caso +
                        Plus_function();
                        break;
                    case (char)44:          //caso ,
                        if (string.IsNullOrEmpty(TextBoxE.Text))
                        {
                            System.Media.SystemSounds.Beep.Play();
                        }
                        else
                            virgola = true;
                        break;
                    case (char)45:          //caso -
                        Minus_function();
                        break;
                    case (char)46:          //caso .
                        if (string.IsNullOrEmpty(TextBoxE.Text))
                        {
                            System.Media.SystemSounds.Beep.Play();
                        }
                        else
                            virgola = true;
                        break;
                    case (char)48:          //casi 0-9
                    case (char)49:
                    case (char)50:
                    case (char)51:
                    case (char)52:
                    case (char)53:
                    case (char)54:
                    case (char)55:
                    case (char)56:
                    case (char)57:
                        labelErrore.Text = null;
                        if (virgola == false && TextBoxE.TextLength < 3)
                        {
                            TextBoxE.Text = TextBoxE.Text + e.KeyChar.ToString();
                        }
                        else if (virgola == true && TextBoxC.TextLength < 2)
                        {
                            TextBoxC.Text = TextBoxC.Text + e.KeyChar.ToString();
                        }
                        else
                            System.Media.SystemSounds.Beep.Play();
                        break;
                    case (char)13:      //caso Invio
                    case (char)61:      //caso =
                        Equal_function();
                        break;
                    case (char)83:      //caso Canc (Del)
                        clear_all();
                        break;
                    case (char)08:      //caso Backspace
                        CE_function();
                        break;
                }
            }
        }

        //GESTIONE INPUT DA MOUSE--------------------------------------------------------
        private void buttonCE_Click(object sender, EventArgs e)
        {
            CE_function();
        }
        
        private void buttonC_Click(object sender, EventArgs e)
        {
            clear_all();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            clear_all();
            this.Close();
        }

        private void buttonV_Click(object sender, EventArgs e)
        {
            labelErrore.Text = null;
            if (string.IsNullOrEmpty(TextBoxE.Text))
            {
                System.Media.SystemSounds.Beep.Play();
            }
            virgola = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            labelErrore.Text = null;
            if (virgola == false && TextBoxE.TextLength < 3)
            {
                TextBoxE.Text = TextBoxE.Text + 1;
            }
            else if (virgola == true && TextBoxC.TextLength < 2 && !string.IsNullOrEmpty(TextBoxE.Text))
            {
                TextBoxC.Text = TextBoxC.Text + 1;
            }
            else if (virgola == true && string.IsNullOrEmpty(TextBoxE.Text))
            {
                TextBoxE.Text = TextBoxE.Text + 1;
                virgola = false;
            }
            else
                System.Media.SystemSounds.Beep.Play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            labelErrore.Text = null;
            if (virgola == false && TextBoxE.TextLength < 3)
            {
                TextBoxE.Text = TextBoxE.Text + 2;
            }
            else if (virgola == true && TextBoxC.TextLength < 2 && !string.IsNullOrEmpty(TextBoxE.Text))
            {
                TextBoxC.Text = TextBoxC.Text + 2;
            }
            else if (virgola == true && string.IsNullOrEmpty(TextBoxE.Text))
            {
                TextBoxE.Text = TextBoxE.Text + 2;
                virgola = false;
            }
            else
                System.Media.SystemSounds.Beep.Play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            labelErrore.Text = null;
            if (virgola == false && TextBoxE.TextLength < 3)
            {
                TextBoxE.Text = TextBoxE.Text + 3;
            }
            else if (virgola == true && TextBoxC.TextLength < 2 && !string.IsNullOrEmpty(TextBoxE.Text))
            {
                TextBoxC.Text = TextBoxC.Text + 3;
            }
            else if (virgola == true && string.IsNullOrEmpty(TextBoxE.Text))
            {
                TextBoxE.Text = TextBoxE.Text + 3;
                virgola = false;
            }
            else
                System.Media.SystemSounds.Beep.Play();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            labelErrore.Text = null;
            if (virgola == false && TextBoxE.TextLength < 3)
            {
                TextBoxE.Text = TextBoxE.Text + 4;
            }
            else if (virgola == true && TextBoxC.TextLength < 2 && !string.IsNullOrEmpty(TextBoxE.Text))
            {
                TextBoxC.Text = TextBoxC.Text + 4;
            }
            else if (virgola == true && string.IsNullOrEmpty(TextBoxE.Text))
            {
                TextBoxE.Text = TextBoxE.Text + 4;
                virgola = false;
            }
            else
                System.Media.SystemSounds.Beep.Play();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            labelErrore.Text = null;
            if (virgola == false && TextBoxE.TextLength < 3)
            {
                TextBoxE.Text = TextBoxE.Text + 5;
            }
            else if (virgola == true && TextBoxC.TextLength < 2 && !string.IsNullOrEmpty(TextBoxE.Text))
            {
                TextBoxC.Text = TextBoxC.Text + 5;
            }
            else if (virgola == true && string.IsNullOrEmpty(TextBoxE.Text))
            {
                TextBoxE.Text = TextBoxE.Text + 5;
                virgola = false;
            }
            else
                System.Media.SystemSounds.Beep.Play();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            labelErrore.Text = null;
            if (virgola == false && TextBoxE.TextLength < 3)
            {
                TextBoxE.Text = TextBoxE.Text + 6;
            }
            else if (virgola == true && TextBoxC.TextLength < 2 && !string.IsNullOrEmpty(TextBoxE.Text))
            {
                TextBoxC.Text = TextBoxC.Text + 6;
            }
            else if (virgola == true && string.IsNullOrEmpty(TextBoxE.Text))
            {
                TextBoxE.Text = TextBoxE.Text + 6;
                virgola = false;
            }
            else
                System.Media.SystemSounds.Beep.Play();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            labelErrore.Text = null;
            if (virgola == false && TextBoxE.TextLength < 3)
            {
                TextBoxE.Text = TextBoxE.Text + 7;
            }
            else if (virgola == true && TextBoxC.TextLength < 2 && !string.IsNullOrEmpty(TextBoxE.Text))
            {
                TextBoxC.Text = TextBoxC.Text + 7;
            }
            else if (virgola == true && string.IsNullOrEmpty(TextBoxE.Text))
            {
                TextBoxE.Text = TextBoxE.Text + 7;
                virgola = false;
            }
            else
                System.Media.SystemSounds.Beep.Play();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            labelErrore.Text = null;
            if (virgola == false && TextBoxE.TextLength < 3)
            {
                TextBoxE.Text = TextBoxE.Text + 8;
            }
            else if (virgola == true && TextBoxC.TextLength < 2 && !string.IsNullOrEmpty(TextBoxE.Text))
            {
                TextBoxC.Text = TextBoxC.Text + 8;
            }
            else if (virgola == true && string.IsNullOrEmpty(TextBoxE.Text))
            {
                TextBoxE.Text = TextBoxE.Text + 8;
                virgola = false;
            }
            else
                System.Media.SystemSounds.Beep.Play();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            labelErrore.Text = null;
            if (virgola == false && TextBoxE.TextLength < 3)
            {
                TextBoxE.Text = TextBoxE.Text + 9;
            }
            else if (virgola == true && TextBoxC.TextLength < 2 && !string.IsNullOrEmpty(TextBoxE.Text))
            {
                TextBoxC.Text = TextBoxC.Text + 9;
            }
            else if (virgola == true && string.IsNullOrEmpty(TextBoxE.Text))
            {
                TextBoxE.Text = TextBoxE.Text + 9;
                virgola = false;
            }
            else
                System.Media.SystemSounds.Beep.Play();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            labelErrore.Text = null;
            if (virgola == false && TextBoxE.TextLength < 3)
            {
                TextBoxE.Text = TextBoxE.Text + 0;
            }
            else if (virgola == true && TextBoxC.TextLength < 2 && !string.IsNullOrEmpty(TextBoxE.Text))
            {
                TextBoxC.Text = TextBoxC.Text + 0;
            }
            else if (virgola == true && string.IsNullOrEmpty(TextBoxE.Text))
            {
                TextBoxE.Text = TextBoxE.Text + 0;
                virgola = false;
            }
            else
                System.Media.SystemSounds.Beep.Play();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            Plus_function();
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            Minus_function();
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            Multiply_function();
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            Equal_function();
        }

        //FUNZIONI AUSILIARIE--------------------------------------------------------
        private void CE_function()
        {
            TextBoxE.Clear();
            TextBoxC.Clear();
            virgola = false;
            labelErrore.Text = null;
        }
        
        private void Plus_function()
        {
            labelErrore.Text = null; 
            virgola = false;
            if (string.IsNullOrEmpty(TextBoxE.Text))
            {
                System.Media.SystemSounds.Beep.Play();
            }
            else if (operation == 0)
            {
                if (num1 == 0)
                {
                    parse_num1();
                    label1.Text = euro;
                    label1C.Text = cent;
                    label2.Text = null;
                    label2C.Text = null;
                    labelRis.Text = null;
                    labelRisC.Text = null;
                }
                else
                {
                    temp = num1;
                    parse_num1();
                    num1 += temp;
                    parse_num1();       //devo richiamarla per aggiornare i campi "euro" e "cent"
                    label2.Text = euro;
                    label2C.Text = cent;

                }
                operation = 1;
                TextBoxE.Clear();
                TextBoxC.Clear();
                labelSegno.Text = "+";
            }
            else 
            {
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void Minus_function()
        {
            labelErrore.Text = null;
            virgola = false;
            if (string.IsNullOrEmpty(TextBoxE.Text))
            {
                System.Media.SystemSounds.Beep.Play();
            }
            else if (operation == 0)
            {
                if (num1 == 0)
                {
                    parse_num1();
                    label1.Text = euro;
                    label1C.Text = cent;
                    label2.Text = null;
                    label2C.Text = null;
                    labelRis.Text = null;
                    labelRisC.Text = null;
                }
                else
                {
                    temp = num1;
                    parse_num1();
                    num1 = temp - num1;
                    parse_num1();       //devo richiamarla per aggiornare i campi "euro" e "cent"
                    label2.Text = euro;
                    label2C.Text = cent;
                }
                operation = 2;
                TextBoxE.Clear();
                TextBoxC.Clear();
                labelSegno.Text = "-";
            }
        }

        private void Multiply_function()
        {
            labelErrore.Text = null;
            virgola = false;
            if (string.IsNullOrEmpty(TextBoxE.Text))
            {
                System.Media.SystemSounds.Beep.Play();
            }
            else if (operation == 0)
            {
                if (num1 == 0)
                {
                    parse_num1();
                    label1.Text = euro;
                    label1C.Text = cent;
                    label2.Text = null;
                    label2C.Text = null;
                    labelRis.Text = null;
                    labelRisC.Text = null;
                }
                else
                {
                    temp = num1;
                    parse_num1();
                    num1 *= temp;
                    parse_num1();       //devo richiamarla per aggiornare i campi "euro" e "cent"
                    label2.Text = euro;
                    label2C.Text = cent;
                }
                operation = 3;
                TextBoxE.Clear();
                TextBoxC.Clear();
                labelSegno.Text = "x";
            }
        }

        private void Equal_function()
        {
            labelErrore.Text = null;
            virgola = false;
            if (string.IsNullOrEmpty(TextBoxE.Text))
            {
                System.Media.SystemSounds.Beep.Play();
            }
            else if (operation != 0)
            {
                parse_num2();
                label2.Text = euro;
                label2C.Text = cent;
                compute(operation);
                num1 = 0;
                num2 = 0;
                labelUguale.Text = "=";
                parse_ans();
            }
            else
                System.Media.SystemSounds.Beep.Play();
        }

        private void parse_num1()
        {
            euro = TextBoxE.Text;
            if (string.IsNullOrEmpty(TextBoxC.Text))
            {
                cent = "00";
            }
            else
            {
                cent = TextBoxC.Text;
                if (cent.Length < 2)
                {
                    cent = cent + "0";
                }
            }
            num1 = Convert.ToDouble(euro + "," + cent);
        }

        private void parse_num2()
        {
            euro = TextBoxE.Text;
            if (string.IsNullOrEmpty(TextBoxC.Text))
            {
                cent = "00";
            }
            else
            {
                cent = TextBoxC.Text;
                if (cent.Length < 2)
                {
                    cent = cent + "0";
                }
            }
            num2 = Convert.ToDouble(euro + "," + cent);    
        }

        private void parse_ans()
        {
            euro = null;
            cent = null;
            if (ans == 0.0)
            {
                labelRis.Text = "0";
                labelRisC.Text = "00";
                TextBoxE.Text = "0";
                TextBoxC.Text = "00";

            }
            else if (ans > 999.99 || ans < -999.99)
            {
                System.Media.SystemSounds.Beep.Play();
                clear_all();
                labelErrore.Text = "Overflow";
                return;
            }
            else
            {
                risultato = Convert.ToString(ans * 100);
                elementi_risultato = risultato.Select(c => c.ToString()).ToArray();
                for (int i = 0; i < (elementi_risultato.Length - 2); i++)
                {
                    euro += elementi_risultato[i];
                }
                cent = elementi_risultato[elementi_risultato.Length - 2] + elementi_risultato[elementi_risultato.Length - 1];
                labelRis.Text = euro;
                labelRisC.Text = cent;
                TextBoxE.Text = euro;
                TextBoxC.Text = cent;
            }
        }

        private void compute(int count)
        {
            switch (count)
            {
                case 0:
                    break;
                case 1:
                    ans = num1 + num2; // +
                    operation = 0;
                    break;
                case 2:
                    ans = num1 - num2; // -
                    operation = 0;
                    break;
                case 3:
                    ans = num1 * num2; // X
                    operation = 0;
                    break;
            }
        }

        private void clear_all()
        {
            TextBoxE.Clear();
            TextBoxC.Clear();
            num1 = 0;
            num2 = 0;
            ans = 0;
            operation = 0;
            virgola = false;
            euro = null;
            cent = null;
            risultato = null;
            label1.Text = null;
            label1C.Text = null;
            label2.Text = null;
            label2C.Text = null;
            labelRis.Text = null;
            labelRisC.Text = null;
            labelSegno.Text = null;
            labelUguale.Text = null;
            labelErrore.Text = null;
        }  
    }

    //NUOVA CLASSE BUTTON "NON FOCUSABILE"--------------------------------------------------------
    class NoSelectButton : Button
    {
        public NoSelectButton()
        {
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
