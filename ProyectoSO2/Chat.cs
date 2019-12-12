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
        delegate void CerrarChat();
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

        public void AbandonarPartida()
        {
            CerrarChat delegado = new CerrarChat(CerrarPartida);
            Abandonar.Invoke(delegado);

        }

        public void CerrarPartida()
        {
            this.Close();
        } 
        private void EnviarChat_Click(object sender, EventArgs e)
        {
            string mensaje = "10/" + Convert.ToString(IDPartida) + "," + User + ";" + MensajeChat.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            MensajeChat.Clear();
        }

        private void Abandonar_Click(object sender, EventArgs e)
        {
            string mensaje = "11/" + Convert.ToString(IDPartida) + "," + User;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            this.Close();
            
        }
    }
}
