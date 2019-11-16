namespace ProyectoSO2
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.User = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.InicioSesion = new System.Windows.Forms.Button();
            this.RegistroBoton = new System.Windows.Forms.Button();
            this.Enviar = new System.Windows.Forms.Button();
            this.Consulta1 = new System.Windows.Forms.RadioButton();
            this.Consulta2 = new System.Windows.Forms.RadioButton();
            this.Consulta3 = new System.Windows.Forms.RadioButton();
            this.Desconexion = new System.Windows.Forms.Button();
            this.Mensaje = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // User
            // 
            this.User.Location = new System.Drawing.Point(86, 141);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(212, 31);
            this.User.TabIndex = 0;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(86, 231);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(212, 31);
            this.Password.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña";
            // 
            // InicioSesion
            // 
            this.InicioSesion.Location = new System.Drawing.Point(86, 299);
            this.InicioSesion.Name = "InicioSesion";
            this.InicioSesion.Size = new System.Drawing.Size(160, 59);
            this.InicioSesion.TabIndex = 4;
            this.InicioSesion.Text = "Iniciar Sesión";
            this.InicioSesion.UseVisualStyleBackColor = true;
            this.InicioSesion.Click += new System.EventHandler(this.InicioSesion_Click);
            // 
            // RegistroBoton
            // 
            this.RegistroBoton.Location = new System.Drawing.Point(86, 386);
            this.RegistroBoton.Name = "RegistroBoton";
            this.RegistroBoton.Size = new System.Drawing.Size(160, 59);
            this.RegistroBoton.TabIndex = 5;
            this.RegistroBoton.Text = "Registrarse";
            this.RegistroBoton.UseVisualStyleBackColor = true;
            this.RegistroBoton.Click += new System.EventHandler(this.Registro_Click);
            // 
            // Enviar
            // 
            this.Enviar.Enabled = false;
            this.Enviar.Location = new System.Drawing.Point(657, 299);
            this.Enviar.Name = "Enviar";
            this.Enviar.Size = new System.Drawing.Size(235, 59);
            this.Enviar.TabIndex = 6;
            this.Enviar.Text = "Enviar Al Servidor";
            this.Enviar.UseVisualStyleBackColor = true;
            this.Enviar.Click += new System.EventHandler(this.Enviar_Click);
            // 
            // Consulta1
            // 
            this.Consulta1.AutoSize = true;
            this.Consulta1.Location = new System.Drawing.Point(460, 142);
            this.Consulta1.Name = "Consulta1";
            this.Consulta1.Size = new System.Drawing.Size(349, 29);
            this.Consulta1.TabIndex = 7;
            this.Consulta1.TabStop = true;
            this.Consulta1.Text = "Partida más larga de un jugador";
            this.Consulta1.UseVisualStyleBackColor = true;
            // 
            // Consulta2
            // 
            this.Consulta2.AutoSize = true;
            this.Consulta2.Location = new System.Drawing.Point(460, 188);
            this.Consulta2.Name = "Consulta2";
            this.Consulta2.Size = new System.Drawing.Size(328, 29);
            this.Consulta2.TabIndex = 8;
            this.Consulta2.TabStop = true;
            this.Consulta2.Text = "Jugadores de una partida (ID)";
            this.Consulta2.UseVisualStyleBackColor = true;
            // 
            // Consulta3
            // 
            this.Consulta3.AutoSize = true;
            this.Consulta3.Location = new System.Drawing.Point(460, 233);
            this.Consulta3.Name = "Consulta3";
            this.Consulta3.Size = new System.Drawing.Size(475, 29);
            this.Consulta3.TabIndex = 9;
            this.Consulta3.TabStop = true;
            this.Consulta3.Text = "Partidas que un jugador no perdió Pokémons";
            this.Consulta3.UseVisualStyleBackColor = true;
            // 
            // Desconexion
            // 
            this.Desconexion.Enabled = false;
            this.Desconexion.Location = new System.Drawing.Point(657, 383);
            this.Desconexion.Name = "Desconexion";
            this.Desconexion.Size = new System.Drawing.Size(235, 62);
            this.Desconexion.TabIndex = 10;
            this.Desconexion.Text = "Desconectarse";
            this.Desconexion.UseVisualStyleBackColor = true;
            this.Desconexion.Click += new System.EventHandler(this.Desconexion_Click);
            // 
            // Mensaje
            // 
            this.Mensaje.Enabled = false;
            this.Mensaje.Location = new System.Drawing.Point(412, 353);
            this.Mensaje.Name = "Mensaje";
            this.Mensaje.Size = new System.Drawing.Size(176, 31);
            this.Mensaje.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(407, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Mensaje al Servidor";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(974, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 82;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(298, 450);
            this.dataGridView1.TabIndex = 14;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 526);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Mensaje);
            this.Controls.Add(this.Desconexion);
            this.Controls.Add(this.Consulta3);
            this.Controls.Add(this.Consulta2);
            this.Controls.Add(this.Consulta1);
            this.Controls.Add(this.Enviar);
            this.Controls.Add(this.RegistroBoton);
            this.Controls.Add(this.InicioSesion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.User);
            this.Name = "Inicio";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox User;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button InicioSesion;
        private System.Windows.Forms.Button RegistroBoton;
        private System.Windows.Forms.Button Enviar;
        private System.Windows.Forms.RadioButton Consulta1;
        private System.Windows.Forms.RadioButton Consulta2;
        private System.Windows.Forms.RadioButton Consulta3;
        private System.Windows.Forms.Button Desconexion;
        private System.Windows.Forms.TextBox Mensaje;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

