namespace ProyectoSO2
{
    partial class TeamBuilder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PokemonSeleccionado = new System.Windows.Forms.PictureBox();
            this.Stats = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pokemon1 = new System.Windows.Forms.PictureBox();
            this.Pokemon2 = new System.Windows.Forms.PictureBox();
            this.Pokemon3 = new System.Windows.Forms.PictureBox();
            this.Añadir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PokemonsDisponibles = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Eliminar = new System.Windows.Forms.Button();
            this.Mov1 = new System.Windows.Forms.Label();
            this.Mov2 = new System.Windows.Forms.Label();
            this.Mov3 = new System.Windows.Forms.Label();
            this.Mov4 = new System.Windows.Forms.Label();
            this.Tipo1 = new System.Windows.Forms.PictureBox();
            this.Tipo2 = new System.Windows.Forms.PictureBox();
            this.Confirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PokemonSeleccionado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pokemon1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pokemon2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pokemon3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PokemonsDisponibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tipo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tipo2)).BeginInit();
            this.SuspendLayout();
            // 
            // PokemonSeleccionado
            // 
            this.PokemonSeleccionado.Location = new System.Drawing.Point(520, 89);
            this.PokemonSeleccionado.Margin = new System.Windows.Forms.Padding(2);
            this.PokemonSeleccionado.Name = "PokemonSeleccionado";
            this.PokemonSeleccionado.Size = new System.Drawing.Size(153, 126);
            this.PokemonSeleccionado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PokemonSeleccionado.TabIndex = 1;
            this.PokemonSeleccionado.TabStop = false;
            // 
            // Stats
            // 
            this.Stats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Stats.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Stats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Stats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.Stats.Location = new System.Drawing.Point(510, 288);
            this.Stats.Margin = new System.Windows.Forms.Padding(2);
            this.Stats.Name = "Stats";
            this.Stats.ReadOnly = true;
            this.Stats.RowHeadersVisible = false;
            this.Stats.RowHeadersWidth = 82;
            this.Stats.RowTemplate.Height = 33;
            this.Stats.Size = new System.Drawing.Size(189, 179);
            this.Stats.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Estadistica";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 105;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Valor";
            this.Column2.MinimumWidth = 10;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 70;
            // 
            // Pokemon1
            // 
            this.Pokemon1.Location = new System.Drawing.Point(762, 303);
            this.Pokemon1.Margin = new System.Windows.Forms.Padding(2);
            this.Pokemon1.Name = "Pokemon1";
            this.Pokemon1.Size = new System.Drawing.Size(47, 38);
            this.Pokemon1.TabIndex = 3;
            this.Pokemon1.TabStop = false;
            // 
            // Pokemon2
            // 
            this.Pokemon2.Location = new System.Drawing.Point(762, 355);
            this.Pokemon2.Margin = new System.Windows.Forms.Padding(2);
            this.Pokemon2.Name = "Pokemon2";
            this.Pokemon2.Size = new System.Drawing.Size(47, 38);
            this.Pokemon2.TabIndex = 4;
            this.Pokemon2.TabStop = false;
            // 
            // Pokemon3
            // 
            this.Pokemon3.Location = new System.Drawing.Point(762, 406);
            this.Pokemon3.Margin = new System.Windows.Forms.Padding(2);
            this.Pokemon3.Name = "Pokemon3";
            this.Pokemon3.Size = new System.Drawing.Size(47, 38);
            this.Pokemon3.TabIndex = 5;
            this.Pokemon3.TabStop = false;
            // 
            // Añadir
            // 
            this.Añadir.Location = new System.Drawing.Point(772, 116);
            this.Añadir.Margin = new System.Windows.Forms.Padding(2);
            this.Añadir.Name = "Añadir";
            this.Añadir.Size = new System.Drawing.Size(171, 35);
            this.Añadir.TabIndex = 6;
            this.Añadir.Text = "Transferir a Equipo";
            this.Añadir.UseVisualStyleBackColor = true;
            this.Añadir.Click += new System.EventHandler(this.Añadir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(813, 316);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(813, 364);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(813, 416);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // PokemonsDisponibles
            // 
            this.PokemonsDisponibles.AllowUserToAddRows = false;
            this.PokemonsDisponibles.AllowUserToDeleteRows = false;
            this.PokemonsDisponibles.AllowUserToResizeColumns = false;
            this.PokemonsDisponibles.AllowUserToResizeRows = false;
            this.PokemonsDisponibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PokemonsDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PokemonsDisponibles.Location = new System.Drawing.Point(25, 24);
            this.PokemonsDisponibles.Margin = new System.Windows.Forms.Padding(2);
            this.PokemonsDisponibles.MultiSelect = false;
            this.PokemonsDisponibles.Name = "PokemonsDisponibles";
            this.PokemonsDisponibles.ReadOnly = true;
            this.PokemonsDisponibles.RowHeadersVisible = false;
            this.PokemonsDisponibles.RowHeadersWidth = 82;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PokemonsDisponibles.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.PokemonsDisponibles.RowTemplate.Height = 33;
            this.PokemonsDisponibles.Size = new System.Drawing.Size(331, 660);
            this.PokemonsDisponibles.TabIndex = 10;
            this.PokemonsDisponibles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PokemonsDisponibles_CellContentClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(959, 355);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 38);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // Eliminar
            // 
            this.Eliminar.Location = new System.Drawing.Point(772, 179);
            this.Eliminar.Margin = new System.Windows.Forms.Padding(2);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(171, 36);
            this.Eliminar.TabIndex = 16;
            this.Eliminar.Text = "Eliminar Del Equipo";
            this.Eliminar.UseVisualStyleBackColor = true;
            this.Eliminar.Click += new System.EventHandler(this.Eliminar_Click);
            // 
            // Mov1
            // 
            this.Mov1.AutoSize = true;
            this.Mov1.Location = new System.Drawing.Point(507, 497);
            this.Mov1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Mov1.Name = "Mov1";
            this.Mov1.Size = new System.Drawing.Size(46, 17);
            this.Mov1.TabIndex = 18;
            this.Mov1.Text = "label6";
            this.Mov1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mov1.Visible = false;
            // 
            // Mov2
            // 
            this.Mov2.AutoSize = true;
            this.Mov2.Location = new System.Drawing.Point(652, 497);
            this.Mov2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Mov2.Name = "Mov2";
            this.Mov2.Size = new System.Drawing.Size(46, 17);
            this.Mov2.TabIndex = 19;
            this.Mov2.Text = "label7";
            this.Mov2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mov2.Visible = false;
            // 
            // Mov3
            // 
            this.Mov3.AutoSize = true;
            this.Mov3.Location = new System.Drawing.Point(507, 533);
            this.Mov3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Mov3.Name = "Mov3";
            this.Mov3.Size = new System.Drawing.Size(46, 17);
            this.Mov3.TabIndex = 20;
            this.Mov3.Text = "label8";
            this.Mov3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mov3.Visible = false;
            // 
            // Mov4
            // 
            this.Mov4.AutoSize = true;
            this.Mov4.Location = new System.Drawing.Point(652, 533);
            this.Mov4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Mov4.Name = "Mov4";
            this.Mov4.Size = new System.Drawing.Size(46, 17);
            this.Mov4.TabIndex = 21;
            this.Mov4.Text = "label9";
            this.Mov4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mov4.Visible = false;
            // 
            // Tipo1
            // 
            this.Tipo1.Location = new System.Drawing.Point(520, 219);
            this.Tipo1.Margin = new System.Windows.Forms.Padding(2);
            this.Tipo1.Name = "Tipo1";
            this.Tipo1.Size = new System.Drawing.Size(67, 32);
            this.Tipo1.TabIndex = 22;
            this.Tipo1.TabStop = false;
            // 
            // Tipo2
            // 
            this.Tipo2.Location = new System.Drawing.Point(607, 219);
            this.Tipo2.Margin = new System.Windows.Forms.Padding(2);
            this.Tipo2.Name = "Tipo2";
            this.Tipo2.Size = new System.Drawing.Size(67, 32);
            this.Tipo2.TabIndex = 23;
            this.Tipo2.TabStop = false;
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(772, 533);
            this.Confirm.Margin = new System.Windows.Forms.Padding(2);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(171, 36);
            this.Confirm.TabIndex = 24;
            this.Confirm.Text = "Confirmar Equipo";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // TeamBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1042, 675);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.Tipo2);
            this.Controls.Add(this.Tipo1);
            this.Controls.Add(this.Mov4);
            this.Controls.Add(this.Mov3);
            this.Controls.Add(this.Mov2);
            this.Controls.Add(this.Mov1);
            this.Controls.Add(this.Eliminar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PokemonsDisponibles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Añadir);
            this.Controls.Add(this.Pokemon3);
            this.Controls.Add(this.Pokemon2);
            this.Controls.Add(this.Pokemon1);
            this.Controls.Add(this.Stats);
            this.Controls.Add(this.PokemonSeleccionado);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TeamBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Team Builder";
            this.Load += new System.EventHandler(this.TeamBuilder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PokemonSeleccionado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pokemon1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pokemon2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pokemon3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PokemonsDisponibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tipo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tipo2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PokemonSeleccionado;
        private System.Windows.Forms.DataGridView Stats;
        private System.Windows.Forms.PictureBox Pokemon1;
        private System.Windows.Forms.PictureBox Pokemon2;
        private System.Windows.Forms.PictureBox Pokemon3;
        private System.Windows.Forms.Button Añadir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView PokemonsDisponibles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Eliminar;
        private System.Windows.Forms.Label Mov1;
        private System.Windows.Forms.Label Mov2;
        private System.Windows.Forms.Label Mov3;
        private System.Windows.Forms.Label Mov4;
        private System.Windows.Forms.PictureBox Tipo1;
        private System.Windows.Forms.PictureBox Tipo2;
        private System.Windows.Forms.Button Confirm;
    }
}