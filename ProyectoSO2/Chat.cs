using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace ProyectoSO2
{
    public partial class Chat : Form
    {

        
        int IDPartida;
        Socket server;
        string User;
        delegate void EscribirChat(string MensajeChat);
        public Chat(int ID, Socket servidor, string User)
        {
            this.IDPartida = ID;
            this.server = servidor;
            this.User = User;
            InitializeComponent();
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            IDLabel.Text = Convert.ToString(IDPartida);
            ChatData.ColumnCount = 2;
        }
        public void EscribirMensaje(string contenido)
        {
            EscribirChat delegadoChat = new EscribirChat(EscribirMensajeDelegado);
            ChatData.Invoke(delegadoChat, new object[] { contenido });
            string[] Message = contenido.Split(';');
        }


        public void EscribirMensajeDelegado(string contenido)
        {
            string[] Message = contenido.Split(';');
            ChatData.Rows.Add(Message);
        }


        private void EnviarChat_Click(object sender, EventArgs e)
        {
            string mensaje = "10/" + Convert.ToString(IDPartida) + "," + User + ";" + MensajeChat.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            MensajeChat.Clear();
        }
    }
}
