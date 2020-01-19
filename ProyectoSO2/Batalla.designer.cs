namespace ProyectoSO2
{
    partial class Batalla
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.Jug1 = new System.Windows.Forms.Label();
            this.Jug2 = new System.Windows.Forms.Label();
            this.PokemonP1 = new System.Windows.Forms.Label();
            this.PokemonP2 = new System.Windows.Forms.Label();
            this.CambiarPokemon = new System.Windows.Forms.Button();
            this.Notif = new System.Windows.Forms.Label();
            this.counter = new System.Windows.Forms.Label();
            this.Mov1Text = new System.Windows.Forms.Label();
            this.Mov2Text = new System.Windows.Forms.Label();
            this.Mov3Text = new System.Windows.Forms.Label();
            this.Mov4Text = new System.Windows.Forms.Label();
            this.PPMov1 = new System.Windows.Forms.Label();
            this.PPMov2 = new System.Windows.Forms.Label();
            this.PPMov3 = new System.Windows.Forms.Label();
            this.PPMov4 = new System.Windows.Forms.Label();
            this.Mov4 = new System.Windows.Forms.PictureBox();
            this.Mov3 = new System.Windows.Forms.PictureBox();
            this.Mov2 = new System.Windows.Forms.PictureBox();
            this.Mov1 = new System.Windows.Forms.PictureBox();
            this.HealthBar1 = new System.Windows.Forms.PictureBox();
            this.HealthBar2 = new System.Windows.Forms.PictureBox();
            this.pokeball6 = new System.Windows.Forms.PictureBox();
            this.pokeball5 = new System.Windows.Forms.PictureBox();
            this.pokeball4 = new System.Windows.Forms.PictureBox();
            this.pokeball3 = new System.Windows.Forms.PictureBox();
            this.pokeball2 = new System.Windows.Forms.PictureBox();
            this.pokeball1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Fondo = new System.Windows.Forms.PictureBox();
            this.Abandonar = new System.Windows.Forms.Button();
            this.EnviarChat = new System.Windows.Forms.Button();
            this.MensajeChat = new System.Windows.Forms.TextBox();
            this.ChatData = new System.Windows.Forms.DataGridView();
            this.IDLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Mov4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mov3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mov2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mov1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealthBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealthBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokeball6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokeball5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokeball4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokeball3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokeball2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokeball1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fondo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChatData)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Jug1
            // 
            this.Jug1.AutoSize = true;
            this.Jug1.Location = new System.Drawing.Point(50, 639);
            this.Jug1.Name = "Jug1";
            this.Jug1.Size = new System.Drawing.Size(108, 25);
            this.Jug1.TabIndex = 13;
            this.Jug1.Text = "Jugador 1";
            // 
            // Jug2
            // 
            this.Jug2.AutoSize = true;
            this.Jug2.Location = new System.Drawing.Point(639, 648);
            this.Jug2.Name = "Jug2";
            this.Jug2.Size = new System.Drawing.Size(108, 25);
            this.Jug2.TabIndex = 14;
            this.Jug2.Text = "Jugador 2";
            // 
            // PokemonP1
            // 
            this.PokemonP1.AutoSize = true;
            this.PokemonP1.Location = new System.Drawing.Point(298, 648);
            this.PokemonP1.Name = "PokemonP1";
            this.PokemonP1.Size = new System.Drawing.Size(128, 25);
            this.PokemonP1.TabIndex = 18;
            this.PokemonP1.Text = "PokemonP1";
            this.PokemonP1.Visible = false;
            // 
            // PokemonP2
            // 
            this.PokemonP2.AutoSize = true;
            this.PokemonP2.Location = new System.Drawing.Point(890, 648);
            this.PokemonP2.Name = "PokemonP2";
            this.PokemonP2.Size = new System.Drawing.Size(128, 25);
            this.PokemonP2.TabIndex = 19;
            this.PokemonP2.Text = "PokemonP2";
            this.PokemonP2.Visible = false;
            // 
            // CambiarPokemon
            // 
            this.CambiarPokemon.Location = new System.Drawing.Point(1072, 441);
            this.CambiarPokemon.Name = "CambiarPokemon";
            this.CambiarPokemon.Size = new System.Drawing.Size(429, 105);
            this.CambiarPokemon.TabIndex = 26;
            this.CambiarPokemon.Text = "Cambiar Pokemon";
            this.CambiarPokemon.UseVisualStyleBackColor = true;
            this.CambiarPokemon.Click += new System.EventHandler(this.CambiarPokemon_Click);
            // 
            // Notif
            // 
            this.Notif.AutoSize = true;
            this.Notif.BackColor = System.Drawing.Color.Transparent;
            this.Notif.Location = new System.Drawing.Point(1066, 48);
            this.Notif.MaximumSize = new System.Drawing.Size(480, 0);
            this.Notif.Name = "Notif";
            this.Notif.Size = new System.Drawing.Size(210, 25);
            this.Notif.TabIndex = 28;
            this.Notif.Text = "La batalla comienza!";
            // 
            // counter
            // 
            this.counter.AutoSize = true;
            this.counter.Location = new System.Drawing.Point(1328, 678);
            this.counter.Name = "counter";
            this.counter.Size = new System.Drawing.Size(70, 25);
            this.counter.TabIndex = 27;
            this.counter.Text = "label1";
            // 
            // Mov1Text
            // 
            this.Mov1Text.AutoSize = true;
            this.Mov1Text.BackColor = System.Drawing.Color.Transparent;
            this.Mov1Text.Location = new System.Drawing.Point(1066, 198);
            this.Mov1Text.Name = "Mov1Text";
            this.Mov1Text.Size = new System.Drawing.Size(107, 25);
            this.Mov1Text.TabIndex = 36;
            this.Mov1Text.Text = "Mov1Text";
            this.Mov1Text.Visible = false;
            // 
            // Mov2Text
            // 
            this.Mov2Text.AutoSize = true;
            this.Mov2Text.BackColor = System.Drawing.Color.Transparent;
            this.Mov2Text.Location = new System.Drawing.Point(1328, 198);
            this.Mov2Text.Name = "Mov2Text";
            this.Mov2Text.Size = new System.Drawing.Size(107, 25);
            this.Mov2Text.TabIndex = 37;
            this.Mov2Text.Text = "Mov2Text";
            this.Mov2Text.Visible = false;
            // 
            // Mov3Text
            // 
            this.Mov3Text.AutoSize = true;
            this.Mov3Text.BackColor = System.Drawing.Color.Transparent;
            this.Mov3Text.Location = new System.Drawing.Point(1066, 327);
            this.Mov3Text.Name = "Mov3Text";
            this.Mov3Text.Size = new System.Drawing.Size(107, 25);
            this.Mov3Text.TabIndex = 38;
            this.Mov3Text.Text = "Mov3Text";
            this.Mov3Text.Visible = false;
            // 
            // Mov4Text
            // 
            this.Mov4Text.AutoSize = true;
            this.Mov4Text.BackColor = System.Drawing.Color.Transparent;
            this.Mov4Text.Location = new System.Drawing.Point(1328, 327);
            this.Mov4Text.Name = "Mov4Text";
            this.Mov4Text.Size = new System.Drawing.Size(107, 25);
            this.Mov4Text.TabIndex = 39;
            this.Mov4Text.Text = "Mov4Text";
            this.Mov4Text.Visible = false;
            // 
            // PPMov1
            // 
            this.PPMov1.AutoSize = true;
            this.PPMov1.BackColor = System.Drawing.Color.Transparent;
            this.PPMov1.Location = new System.Drawing.Point(1125, 239);
            this.PPMov1.Name = "PPMov1";
            this.PPMov1.Size = new System.Drawing.Size(100, 25);
            this.PPMov1.TabIndex = 40;
            this.PPMov1.Text = "PPMOV1";
            this.PPMov1.Visible = false;
            // 
            // PPMov2
            // 
            this.PPMov2.AutoSize = true;
            this.PPMov2.BackColor = System.Drawing.Color.Transparent;
            this.PPMov2.Location = new System.Drawing.Point(1374, 239);
            this.PPMov2.Name = "PPMov2";
            this.PPMov2.Size = new System.Drawing.Size(100, 25);
            this.PPMov2.TabIndex = 41;
            this.PPMov2.Text = "PPMOV2";
            this.PPMov2.Visible = false;
            // 
            // PPMov3
            // 
            this.PPMov3.AutoSize = true;
            this.PPMov3.BackColor = System.Drawing.Color.Transparent;
            this.PPMov3.Location = new System.Drawing.Point(1125, 373);
            this.PPMov3.Name = "PPMov3";
            this.PPMov3.Size = new System.Drawing.Size(100, 25);
            this.PPMov3.TabIndex = 42;
            this.PPMov3.Text = "PPMOV3";
            this.PPMov3.Visible = false;
            // 
            // PPMov4
            // 
            this.PPMov4.AutoSize = true;
            this.PPMov4.BackColor = System.Drawing.Color.Transparent;
            this.PPMov4.Location = new System.Drawing.Point(1374, 373);
            this.PPMov4.Name = "PPMov4";
            this.PPMov4.Size = new System.Drawing.Size(100, 25);
            this.PPMov4.TabIndex = 43;
            this.PPMov4.Text = "PPMOV4";
            this.PPMov4.Visible = false;
            // 
            // Mov4
            // 
            this.Mov4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Mov4.Location = new System.Drawing.Point(1306, 306);
            this.Mov4.Name = "Mov4";
            this.Mov4.Size = new System.Drawing.Size(262, 106);
            this.Mov4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Mov4.TabIndex = 35;
            this.Mov4.TabStop = false;
            this.Mov4.Click += new System.EventHandler(this.Mov4_Click);
            // 
            // Mov3
            // 
            this.Mov3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Mov3.Location = new System.Drawing.Point(1048, 306);
            this.Mov3.Name = "Mov3";
            this.Mov3.Size = new System.Drawing.Size(252, 106);
            this.Mov3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Mov3.TabIndex = 34;
            this.Mov3.TabStop = false;
            this.Mov3.Click += new System.EventHandler(this.Mov3_Click);
            // 
            // Mov2
            // 
            this.Mov2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Mov2.Location = new System.Drawing.Point(1306, 175);
            this.Mov2.Name = "Mov2";
            this.Mov2.Size = new System.Drawing.Size(262, 106);
            this.Mov2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Mov2.TabIndex = 33;
            this.Mov2.TabStop = false;
            this.Mov2.Click += new System.EventHandler(this.Mov2_Click);
            // 
            // Mov1
            // 
            this.Mov1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Mov1.Location = new System.Drawing.Point(1048, 175);
            this.Mov1.Name = "Mov1";
            this.Mov1.Size = new System.Drawing.Size(252, 106);
            this.Mov1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Mov1.TabIndex = 32;
            this.Mov1.TabStop = false;
            this.Mov1.Click += new System.EventHandler(this.Mov1_Click);
            // 
            // HealthBar1
            // 
            this.HealthBar1.Location = new System.Drawing.Point(894, 697);
            this.HealthBar1.Name = "HealthBar1";
            this.HealthBar1.Size = new System.Drawing.Size(231, 23);
            this.HealthBar1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HealthBar1.TabIndex = 31;
            this.HealthBar1.TabStop = false;
            // 
            // HealthBar2
            // 
            this.HealthBar2.Location = new System.Drawing.Point(296, 697);
            this.HealthBar2.Name = "HealthBar2";
            this.HealthBar2.Size = new System.Drawing.Size(231, 23);
            this.HealthBar2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HealthBar2.TabIndex = 30;
            this.HealthBar2.TabStop = false;
            // 
            // pokeball6
            // 
            this.pokeball6.Location = new System.Drawing.Point(802, 688);
            this.pokeball6.Name = "pokeball6";
            this.pokeball6.Size = new System.Drawing.Size(49, 54);
            this.pokeball6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pokeball6.TabIndex = 6;
            this.pokeball6.TabStop = false;
            // 
            // pokeball5
            // 
            this.pokeball5.Location = new System.Drawing.Point(723, 688);
            this.pokeball5.Name = "pokeball5";
            this.pokeball5.Size = new System.Drawing.Size(49, 54);
            this.pokeball5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pokeball5.TabIndex = 5;
            this.pokeball5.TabStop = false;
            // 
            // pokeball4
            // 
            this.pokeball4.Location = new System.Drawing.Point(644, 688);
            this.pokeball4.Name = "pokeball4";
            this.pokeball4.Size = new System.Drawing.Size(49, 54);
            this.pokeball4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pokeball4.TabIndex = 4;
            this.pokeball4.TabStop = false;
            // 
            // pokeball3
            // 
            this.pokeball3.Location = new System.Drawing.Point(210, 681);
            this.pokeball3.Name = "pokeball3";
            this.pokeball3.Size = new System.Drawing.Size(49, 54);
            this.pokeball3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pokeball3.TabIndex = 3;
            this.pokeball3.TabStop = false;
            this.pokeball3.Click += new System.EventHandler(this.pokeball3_Click);
            // 
            // pokeball2
            // 
            this.pokeball2.Location = new System.Drawing.Point(134, 681);
            this.pokeball2.Name = "pokeball2";
            this.pokeball2.Size = new System.Drawing.Size(49, 54);
            this.pokeball2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pokeball2.TabIndex = 2;
            this.pokeball2.TabStop = false;
            this.pokeball2.Click += new System.EventHandler(this.pokeball2_Click);
            // 
            // pokeball1
            // 
            this.pokeball1.Location = new System.Drawing.Point(54, 681);
            this.pokeball1.Name = "pokeball1";
            this.pokeball1.Size = new System.Drawing.Size(49, 54);
            this.pokeball1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pokeball1.TabIndex = 1;
            this.pokeball1.TabStop = false;
            this.pokeball1.Click += new System.EventHandler(this.pokeball1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(45, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 552);
            this.panel1.TabIndex = 0;
            // 
            // Fondo
            // 
            this.Fondo.Location = new System.Drawing.Point(1048, 38);
            this.Fondo.Name = "Fondo";
            this.Fondo.Size = new System.Drawing.Size(520, 95);
            this.Fondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Fondo.TabIndex = 29;
            this.Fondo.TabStop = false;
            // 
            // Abandonar
            // 
            this.Abandonar.Location = new System.Drawing.Point(1173, 554);
            this.Abandonar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Abandonar.Name = "Abandonar";
            this.Abandonar.Size = new System.Drawing.Size(207, 62);
            this.Abandonar.TabIndex = 50;
            this.Abandonar.Text = "Rendirse";
            this.Abandonar.UseVisualStyleBackColor = true;
            this.Abandonar.Click += new System.EventHandler(this.Abandonar_Click);
            // 
            // EnviarChat
            // 
            this.EnviarChat.Location = new System.Drawing.Point(1900, 762);
            this.EnviarChat.Name = "EnviarChat";
            this.EnviarChat.Size = new System.Drawing.Size(207, 48);
            this.EnviarChat.TabIndex = 48;
            this.EnviarChat.Text = "Enviar";
            this.EnviarChat.UseVisualStyleBackColor = true;
            this.EnviarChat.Click += new System.EventHandler(this.EnviarChat_Click);
            // 
            // MensajeChat
            // 
            this.MensajeChat.Location = new System.Drawing.Point(1575, 773);
            this.MensajeChat.Name = "MensajeChat";
            this.MensajeChat.Size = new System.Drawing.Size(310, 31);
            this.MensajeChat.TabIndex = 47;
            // 
            // ChatData
            // 
            this.ChatData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ChatData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChatData.Location = new System.Drawing.Point(1575, 62);
            this.ChatData.Name = "ChatData";
            this.ChatData.RowHeadersVisible = false;
            this.ChatData.RowHeadersWidth = 82;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ChatData.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ChatData.RowTemplate.Height = 33;
            this.ChatData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ChatData.Size = new System.Drawing.Size(489, 695);
            this.ChatData.TabIndex = 46;
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(1779, 34);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(32, 25);
            this.IDLabel.TabIndex = 49;
            this.IDLabel.Text = "ID";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1328, 710);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 51;
            this.label1.Text = "label1";
            // 
            // Batalla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1924, 912);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Abandonar);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.EnviarChat);
            this.Controls.Add(this.MensajeChat);
            this.Controls.Add(this.ChatData);
            this.Controls.Add(this.PPMov4);
            this.Controls.Add(this.PPMov3);
            this.Controls.Add(this.PPMov2);
            this.Controls.Add(this.PPMov1);
            this.Controls.Add(this.Mov4Text);
            this.Controls.Add(this.Mov3Text);
            this.Controls.Add(this.Mov2Text);
            this.Controls.Add(this.Mov1Text);
            this.Controls.Add(this.Mov4);
            this.Controls.Add(this.Mov3);
            this.Controls.Add(this.Mov2);
            this.Controls.Add(this.Mov1);
            this.Controls.Add(this.HealthBar1);
            this.Controls.Add(this.HealthBar2);
            this.Controls.Add(this.Notif);
            this.Controls.Add(this.counter);
            this.Controls.Add(this.CambiarPokemon);
            this.Controls.Add(this.PokemonP2);
            this.Controls.Add(this.PokemonP1);
            this.Controls.Add(this.Jug2);
            this.Controls.Add(this.Jug1);
            this.Controls.Add(this.pokeball6);
            this.Controls.Add(this.pokeball5);
            this.Controls.Add(this.pokeball4);
            this.Controls.Add(this.pokeball3);
            this.Controls.Add(this.pokeball2);
            this.Controls.Add(this.pokeball1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Fondo);
            this.Name = "Batalla";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Batalla_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Mov4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mov3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mov2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mov1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealthBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealthBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokeball6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokeball5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokeball4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokeball3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokeball2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokeball1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fondo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChatData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox pokeball1;
        private System.Windows.Forms.PictureBox pokeball2;
        private System.Windows.Forms.PictureBox pokeball3;
        private System.Windows.Forms.PictureBox pokeball4;
        private System.Windows.Forms.PictureBox pokeball5;
        private System.Windows.Forms.PictureBox pokeball6;
        private System.Windows.Forms.Label Jug1;
        private System.Windows.Forms.Label Jug2;
        private System.Windows.Forms.Label PokemonP1;
        private System.Windows.Forms.Label PokemonP2;
        private System.Windows.Forms.Button CambiarPokemon;
        private System.Windows.Forms.Label Notif;
        private System.Windows.Forms.Label counter;
        private System.Windows.Forms.PictureBox Fondo;
        private System.Windows.Forms.PictureBox HealthBar2;
        private System.Windows.Forms.PictureBox HealthBar1;
        private System.Windows.Forms.PictureBox Mov1;
        private System.Windows.Forms.PictureBox Mov2;
        private System.Windows.Forms.PictureBox Mov3;
        private System.Windows.Forms.PictureBox Mov4;
        private System.Windows.Forms.Label Mov1Text;
        private System.Windows.Forms.Label Mov2Text;
        private System.Windows.Forms.Label Mov3Text;
        private System.Windows.Forms.Label Mov4Text;
        private System.Windows.Forms.Label PPMov1;
        private System.Windows.Forms.Label PPMov2;
        private System.Windows.Forms.Label PPMov3;
        private System.Windows.Forms.Label PPMov4;
        private System.Windows.Forms.Button Abandonar;
        private System.Windows.Forms.Button EnviarChat;
        private System.Windows.Forms.TextBox MensajeChat;
        private System.Windows.Forms.DataGridView ChatData;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
    }
}

