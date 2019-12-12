namespace ProyectoSO2
{
    partial class Chat
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
            this.EnviarChat = new System.Windows.Forms.Button();
            this.MensajeChat = new System.Windows.Forms.TextBox();
            this.ChatData = new System.Windows.Forms.DataGridView();
            this.IDLabel = new System.Windows.Forms.Label();
            this.Abandonar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ChatData)).BeginInit();
            this.SuspendLayout();
            // 
            // EnviarChat
            // 
            this.EnviarChat.Location = new System.Drawing.Point(374, 535);
            this.EnviarChat.Margin = new System.Windows.Forms.Padding(2);
            this.EnviarChat.Name = "EnviarChat";
            this.EnviarChat.Size = new System.Drawing.Size(138, 31);
            this.EnviarChat.TabIndex = 26;
            this.EnviarChat.Text = "Enviar";
            this.EnviarChat.UseVisualStyleBackColor = true;
            this.EnviarChat.Click += new System.EventHandler(this.EnviarChat_Click);
            // 
            // MensajeChat
            // 
            this.MensajeChat.Location = new System.Drawing.Point(55, 541);
            this.MensajeChat.Margin = new System.Windows.Forms.Padding(2);
            this.MensajeChat.Name = "MensajeChat";
            this.MensajeChat.Size = new System.Drawing.Size(317, 22);
            this.MensajeChat.TabIndex = 25;
            // 
            // ChatData
            // 
            this.ChatData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ChatData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChatData.Location = new System.Drawing.Point(55, 77);
            this.ChatData.Margin = new System.Windows.Forms.Padding(2);
            this.ChatData.Name = "ChatData";
            this.ChatData.RowHeadersVisible = false;
            this.ChatData.RowHeadersWidth = 82;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ChatData.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ChatData.RowTemplate.Height = 33;
            this.ChatData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ChatData.Size = new System.Drawing.Size(457, 445);
            this.ChatData.TabIndex = 24;
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(264, 32);
            this.IDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(21, 17);
            this.IDLabel.TabIndex = 27;
            this.IDLabel.Text = "ID";
            // 
            // Abandonar
            // 
            this.Abandonar.Location = new System.Drawing.Point(422, 20);
            this.Abandonar.Name = "Abandonar";
            this.Abandonar.Size = new System.Drawing.Size(138, 40);
            this.Abandonar.TabIndex = 29;
            this.Abandonar.Text = "Abandonar Partida";
            this.Abandonar.UseVisualStyleBackColor = true;
            this.Abandonar.Click += new System.EventHandler(this.Abandonar_Click);
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(609, 627);
            this.ControlBox = false;
            this.Controls.Add(this.Abandonar);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.EnviarChat);
            this.Controls.Add(this.MensajeChat);
            this.Controls.Add(this.ChatData);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Chat";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Chat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ChatData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EnviarChat;
        private System.Windows.Forms.TextBox MensajeChat;
        private System.Windows.Forms.DataGridView ChatData;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Button Abandonar;
    }
}