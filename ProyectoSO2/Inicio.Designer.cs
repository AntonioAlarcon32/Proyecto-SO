namespace ProyectoSO2
{
    partial class Inicio
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
            this.Start = new System.Windows.Forms.Button();
            this.credits = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Start.Location = new System.Drawing.Point(377, 389);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(347, 66);
            this.Start.TabIndex = 1;
            this.Start.Text = "Inicio";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // credits
            // 
            this.credits.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.credits.Location = new System.Drawing.Point(377, 461);
            this.credits.Name = "credits";
            this.credits.Size = new System.Drawing.Size(347, 66);
            this.credits.TabIndex = 2;
            this.credits.Text = "Créditos";
            this.credits.UseVisualStyleBackColor = false;
            this.credits.Click += new System.EventHandler(this.credits_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PokemonBattle.Properties.Resources.portada_pokemon__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1116, 647);
            this.Controls.Add(this.credits);
            this.Controls.Add(this.Start);
            this.DoubleBuffered = true;
            this.Name = "Inicio";
            this.Text = "Pokémon SO";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button credits;
    }
}