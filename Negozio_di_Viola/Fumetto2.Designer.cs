namespace Negozio_di_Viola
{
    partial class Fumetto2
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
            this.button1 = new System.Windows.Forms.Button();
            this.ViolaPictureBox = new System.Windows.Forms.PictureBox();
            this.NuvolettaPictureBox = new System.Windows.Forms.PictureBox();
            this.MenuButton = new System.Windows.Forms.Button();
            this.AvantiButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ViolaPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NuvolettaPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(999, 367);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(280, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "Assegnazione Guadagno (PROVVISORIO)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ViolaPictureBox
            // 
            this.ViolaPictureBox.Image = global::Negozio_di_Viola.Properties.Resources.Viola;
            this.ViolaPictureBox.Location = new System.Drawing.Point(798, 1);
            this.ViolaPictureBox.Name = "ViolaPictureBox";
            this.ViolaPictureBox.Size = new System.Drawing.Size(506, 297);
            this.ViolaPictureBox.TabIndex = 1;
            this.ViolaPictureBox.TabStop = false;
            // 
            // NuvolettaPictureBox
            // 
            this.NuvolettaPictureBox.Image = global::Negozio_di_Viola.Properties.Resources.nuvoletta;
            this.NuvolettaPictureBox.Location = new System.Drawing.Point(1, 1);
            this.NuvolettaPictureBox.Name = "NuvolettaPictureBox";
            this.NuvolettaPictureBox.Size = new System.Drawing.Size(791, 297);
            this.NuvolettaPictureBox.TabIndex = 2;
            this.NuvolettaPictureBox.TabStop = false;
            // 
            // MenuButton
            // 
            this.MenuButton.Location = new System.Drawing.Point(75, 509);
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.Size = new System.Drawing.Size(75, 23);
            this.MenuButton.TabIndex = 3;
            this.MenuButton.Text = "Menu";
            this.MenuButton.UseVisualStyleBackColor = true;
            // 
            // AvantiButton
            // 
            this.AvantiButton.Location = new System.Drawing.Point(156, 509);
            this.AvantiButton.Name = "AvantiButton";
            this.AvantiButton.Size = new System.Drawing.Size(75, 23);
            this.AvantiButton.TabIndex = 4;
            this.AvantiButton.Text = "Avanti";
            this.AvantiButton.UseVisualStyleBackColor = true;
            // 
            // Fumetto2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 581);
            this.Controls.Add(this.AvantiButton);
            this.Controls.Add(this.MenuButton);
            this.Controls.Add(this.ViolaPictureBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NuvolettaPictureBox);
            this.Name = "Fumetto2";
            this.Text = "Fumetto2";
            ((System.ComponentModel.ISupportInitialize)(this.ViolaPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NuvolettaPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox ViolaPictureBox;
        private System.Windows.Forms.PictureBox NuvolettaPictureBox;
        private System.Windows.Forms.Button MenuButton;
        private System.Windows.Forms.Button AvantiButton;
    }
}