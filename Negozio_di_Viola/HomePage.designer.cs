using System.Drawing;

namespace Negozio_di_Viola
{
    partial class HomePage
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
            this.Titolo = new System.Windows.Forms.Button();
            this.bHelp = new System.Windows.Forms.Button();
            this.bGioca = new System.Windows.Forms.Button();
            this.bSettings = new System.Windows.Forms.Button();
            this.bCont = new System.Windows.Forms.Button();
            this.Sottotitolo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bEsci
            // 
            this.bEsci.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bEsci.Location = new System.Drawing.Point(401, 561);
            this.bEsci.Name = "bEsci";
            this.bEsci.Size = new System.Drawing.Size(363, 63);
            this.bEsci.TabIndex = 1;
            this.bEsci.Text = "ESCI";
            this.bEsci.UseVisualStyleBackColor = true;
            this.bEsci.Click += new System.EventHandler(this.esci_Click);
            // 
            // Titolo
            // 
            this.Titolo.BackColor = System.Drawing.Color.Transparent;
            this.Titolo.FlatAppearance.BorderSize = 0;
            this.Titolo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Titolo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Titolo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Titolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F);
            this.Titolo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Titolo.Location = new System.Drawing.Point(167, 54);
            this.Titolo.Name = "Titolo";
            this.Titolo.Size = new System.Drawing.Size(859, 158);
            this.Titolo.TabIndex = 66;
            this.Titolo.Text = "Il Negozio di Viola";
            this.Titolo.UseVisualStyleBackColor = true;
            this.Titolo.Click += new System.EventHandler(this.Titolo_Click);
            // 
            // bHelp
            // 
            this.bHelp.FlatAppearance.BorderSize = 0;
            this.bHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bHelp.ForeColor = System.Drawing.Color.Yellow;
            this.bHelp.Location = new System.Drawing.Point(575, 283);
            this.bHelp.Name = "bHelp";
            this.bHelp.Size = new System.Drawing.Size(46, 40);
            this.bHelp.TabIndex = 0;
            this.bHelp.Text = "?";
            this.bHelp.UseVisualStyleBackColor = true;
            this.bHelp.Click += new System.EventHandler(this.bHelp_Click);
            // 
            // bGioca
            // 
            this.bGioca.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bGioca.Location = new System.Drawing.Point(401, 365);
            this.bGioca.Name = "bGioca";
            this.bGioca.Size = new System.Drawing.Size(363, 64);
            this.bGioca.TabIndex = 0;
            this.bGioca.Text = "NUOVO GIOCO";
            this.bGioca.UseVisualStyleBackColor = true;
            this.bGioca.Click += new System.EventHandler(this.mappa_Click);
            // 
            // bSettings
            // 
            this.bSettings.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bSettings.Location = new System.Drawing.Point(401, 463);
            this.bSettings.Name = "bSettings";
            this.bSettings.Size = new System.Drawing.Size(363, 63);
            this.bSettings.TabIndex = 68;
            this.bSettings.Text = "IMPOSTAZIONI";
            this.bSettings.UseVisualStyleBackColor = true;
            this.bSettings.Click += new System.EventHandler(this.settings_Click);
            // 
            // bCont
            // 
            this.bCont.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bCont.Location = new System.Drawing.Point(390, 320);
            this.bCont.Name = "bCont";
            this.bCont.Size = new System.Drawing.Size(500, 100);
            this.bCont.TabIndex = 64;
            this.bCont.Text = "RIPRENDI";
            this.bCont.UseVisualStyleBackColor = true;
            this.bCont.Click += new System.EventHandler(this.riprendi_Click);
            // 
            // Sottotitolo
            // 
            this.Sottotitolo.BackColor = System.Drawing.Color.Transparent;
            this.Sottotitolo.FlatAppearance.BorderSize = 0;
            this.Sottotitolo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Sottotitolo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Sottotitolo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Sottotitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sottotitolo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Sottotitolo.Location = new System.Drawing.Point(328, 219);
            this.Sottotitolo.Name = "Sottotitolo";
            this.Sottotitolo.Size = new System.Drawing.Size(545, 48);
            this.Sottotitolo.TabIndex = 67;
            this.Sottotitolo.Text = "Versione X.X, Giugno 20XX";
            this.Sottotitolo.UseVisualStyleBackColor = true;
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1161, 712);
            this.Controls.Add(this.Sottotitolo);
            this.Controls.Add(this.Titolo);
            this.Controls.Add(this.bEsci);
            this.Controls.Add(this.bGioca);
            this.Controls.Add(this.bHelp);
            this.Controls.Add(this.bSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HomePage";
            this.Text = "Il Negozio di Viola";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bHelp;
        private System.Windows.Forms.Button bGioca;
        private System.Windows.Forms.Button bSettings;
        private System.Windows.Forms.Button bEsci;
        private System.Windows.Forms.Button bCont;
        private System.Windows.Forms.Button Titolo;
        private System.Windows.Forms.Button Sottotitolo;
    }
}
