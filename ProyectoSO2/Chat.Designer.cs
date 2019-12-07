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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.EnviarChat = new System.Windows.Forms.Button();
            this.MensajeChat = new System.Windows.Forms.TextBox();
            this.ChatData = new System.Windows.Forms.DataGridView();
            this.IDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ChatData)).BeginInit();
            this.SuspendLayout();
            // 
            // EnviarChat
            // 
            this.EnviarChat.Location = new System.Drawing.Point(561, 836);
            this.EnviarChat.Name = "EnviarChat";
            this.EnviarChat.Size = new System.Drawing.Size(207, 49);
            this.EnviarChat.TabIndex = 26;
            this.EnviarChat.Text = "Enviar";
            this.EnviarChat.UseVisualStyleBackColor = true;
            this.EnviarChat.Click += new System.EventHandler(this.EnviarChat_Click);
            // 
            // MensajeChat
            // 
            this.MensajeChat.Location = new System.Drawing.Point(82, 845);
            this.MensajeChat.Name = "MensajeChat";
            this.MensajeChat.Size = new System.Drawing.Size(473, 31);
            this.MensajeChat.TabIndex = 25;
            // 
            // ChatData
            // 
            this.ChatData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ChatData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChatData.Location = new System.Drawing.Point(82, 120);
            this.ChatData.Name = "ChatData";
            this.ChatData.RowHeadersVisible = false;
            this.ChatData.RowHeadersWidth = 82;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ChatData.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.ChatData.RowTemplate.Height = 33;
            this.ChatData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ChatData.Size = new System.Drawing.Size(686, 695);
            this.ChatData.TabIndex = 24;
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(396, 50);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(32, 25);
            this.IDLabel.TabIndex = 27;
            this.IDLabel.Text = "ID";
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 940);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.EnviarChat);
            this.Controls.Add(this.MensajeChat);
            this.Controls.Add(this.ChatData);
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
    }
}