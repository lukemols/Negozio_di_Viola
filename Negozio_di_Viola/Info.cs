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
    public partial class  Info : Form
    {
        public Info()
        {
            double WidthFactor = (double) Screen.PrimaryScreen.Bounds.Width / 1280;
            double HeightFactor = (double) Screen.PrimaryScreen.Bounds.Height / 800;

// MessageBox.Show("1");
	    
            InitializeComponent();

            this.TopMost = true;

            this.Width =  (int) (Screen.PrimaryScreen.Bounds.Width/2.5);  
            this.Height = (int) (Screen.PrimaryScreen.Bounds.Height/1.5);

            this.textBox1.Location = new System.Drawing.Point(10, 20);
            this.textBox1.Width = this.Width - 30;
            this.textBox1.Height = (int) (this.Height/2.5);
            this.textBox1.Text = Globals.Programma_text + "  -  " + Globals.Versione_text + 
                               Environment.NewLine +
                               Environment.NewLine +
                               Globals.Autori_text + 
                               Environment.NewLine +
			       Globals.Ditta_text + 
                               Environment.NewLine +
                               Environment.NewLine +
                               Globals.Contatto_text + 
                               Environment.NewLine +
                               Environment.NewLine +
                               Globals.Collab_text;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (12*WidthFactor), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.AutoSize = true;
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Name = "textBox1";
            this.textBox1.TabIndex = 3;


            this.button1.Width = (int)(100 * WidthFactor);
            this.button1.Height = (int)(40 * HeightFactor);
            this.button1.Location = new System.Drawing.Point((int)(this.Width / 6 - this.button1.Width / 2), (int)(this.Height - 2.5 * this.button1.Height));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)(12 * WidthFactor), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.button2.Width = (int)(100 * WidthFactor);
            this.button2.Height = (int)(40 * HeightFactor);
            this.button2.Location = new System.Drawing.Point((int)(this.Width / 1.4 - this.button2.Width / 20), (int)(this.Height - 2.5 * this.button1.Height));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)(12 * WidthFactor), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


            this.richTextBox1.Location = new System.Drawing.Point(10, this.textBox1.Location.Y + this.textBox1.Height + 10);
            this.richTextBox1.Width = this.Width - 30;
            this.richTextBox1.Height = this.button1.Location.Y - this.richTextBox1.Location.Y - 20;
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = Globals.Licenza_text;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (12*WidthFactor), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Info_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
    //??    Guida guida = new Guida();
    //??    guida.ShowDialog();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}



