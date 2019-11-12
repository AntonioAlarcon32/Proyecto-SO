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
using System.Net;


namespace ProyectoSO2
{
    public partial class Inicio : Form
    {
        Socket server;
        string ip = "192.168.56.104";
        int puerto = 9094;
        public Inicio()
        {
            InitializeComponent();
        }



        private void Registro_Click(object sender, EventArgs e)
        {
            if ((User.Text == "") || (Password.Text == ""))
            {
                MessageBox.Show("No hay datos introducidos");
            }

            else
            {
                //al que deseamos conectarnos
                IPAddress direc = IPAddress.Parse(ip);
                IPEndPoint ipep = new IPEndPoint(direc, puerto);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Connect(ipep);//Intentamos conectar el socket

                string mensaje = "1/" + User.Text + "," + Password.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                if (mensaje == "0")
                {
                    Mensaje.Enabled = true;
                    Enviar.Enabled = true;
                    Desconexion.Enabled = true;
                    ListaConectados.Enabled = true;
                    MessageBox.Show("Sesion Iniciada");
                    InicioSesion.Enabled = false;
                    RegistroBoton.Enabled = false;
                    User.Enabled = false;
                    Password.Enabled = false;
                    
                }
                else
                {
                    string mensaje2 = "0/" + User.Text;
                    byte[] msg3 = System.Text.Encoding.ASCII.GetBytes(mensaje2);
                    server.Send(msg3);
                    server.Shutdown(SocketShutdown.Both);
                    server.Close();
                    MessageBox.Show("El nombre ya está registrado");
                }

            }
        }

        private void InicioSesion_Click(object sender, EventArgs e)
        {
            if ((User.Text == "") || (Password.Text == ""))
            {
                MessageBox.Show("No hay datos introducidos");
            }

            else
            {

                IPAddress direc = IPAddress.Parse(ip);
                IPEndPoint ipep = new IPEndPoint(direc, puerto);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Connect(ipep);//Intentamos conectar el socket

                string mensaje = "2/" + User.Text + "," + Password.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                if (mensaje == "0")
                {
                    Mensaje.Enabled = true;
                    Enviar.Enabled = true;
                    Desconexion.Enabled = true;
                    ListaConectados.Enabled = true;
                    MessageBox.Show("Sesion Iniciada");
                    InicioSesion.Enabled = false;
                    RegistroBoton.Enabled = false;
                    User.Enabled = false;
                    Password.Enabled = false;
                }
                else
                {
                    string mensaje2 = "0/" + User.Text;
                    byte[] msg3 = System.Text.Encoding.ASCII.GetBytes(mensaje2);
                    server.Send(msg3);
                    server.Shutdown(SocketShutdown.Both);
                    server.Close();
                    MessageBox.Show("El nombre o la contraseña son incorrectos");
                }
            }
        }

        private void Enviar_Click(object sender, EventArgs e)
        {
            if ((Consulta1.Checked == false) && (Consulta2.Checked == false) && (Consulta3.Checked == false))
                MessageBox.Show("Marca una consulta");
            else
            {
                if (Mensaje.Text == "")
                {
                    MessageBox.Show("No hay texto en la consulta");
                }
                else
                {
                    if (Consulta1.Checked)
                    {
                        string mensaje = "3/" + Mensaje.Text;
                        // Enviamos al servidor el nombre tecleado
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                        //Recibimos la respuesta del servidor
                        byte[] msg2 = new byte[80];
                        server.Receive(msg2);
                        mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                        if (mensaje == "NoEncontrado")
                        {
                            MessageBox.Show("No se ha encontrado el jugador");
                        }
                        else if (mensaje != "")
                        {
                            MessageBox.Show("Número de turnos:" + mensaje);
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                        
                    }

                    if (Consulta2.Checked)
                    {
                        if (Mensaje.Text == "")
                        {
                            MessageBox.Show("No hay datos introducidos");
                        }

                        else
                        {


                            string mensaje = "4/" + Mensaje.Text;

                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);

                            //Recibimos la respuesta del servidor
                            byte[] msg2 = new byte[80];
                            server.Receive(msg2);
                            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                            if (mensaje == "NoEncontrado")
                            {
                                MessageBox.Show("No se ha encontrado la partida");
                            }
                            else if (mensaje != "")
                            {
                                MessageBox.Show("Jugadores:" + mensaje);
                            }
                            else
                            {
                                MessageBox.Show("Error");
                            }
                        }
                    }

                    if (Consulta3.Checked)
                    {
                        string mensaje = "5/" + Mensaje.Text;
                        // Enviamos al servidor el nombre tecleado
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                        //Recibimos la respuesta del servidor
                        byte[] msg2 = new byte[80];
                        server.Receive(msg2);
                        mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                        if (mensaje == "NoEncontrado")
                        {
                            MessageBox.Show("No se ha encontrado la partida");
                        }
                        else if (mensaje != "")
                        {
                            MessageBox.Show("Número de turnos:" + mensaje);
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }
                }
            }
        }

        private void Desconexion_Click(object sender, EventArgs e)
        {
            string mensaje = "0/" + User.Text;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            server.Shutdown(SocketShutdown.Both);
            server.Close();
            Mensaje.Enabled = false;
            Enviar.Enabled = false;
            Desconexion.Enabled = false;
            ListaConectados.Enabled = false;
            MessageBox.Show("Te has desconectado");
            InicioSesion.Enabled = true;
            RegistroBoton.Enabled = true;
            User.Enabled = true;
            Password.Enabled = true;
        }

        private void ListaConectados_Click(object sender, EventArgs e)
        {
            string mensaje = "6/" + User.Text;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            ListaConectados FormConectados = new ListaConectados();
            FormConectados.GetStringConectados(mensaje);
            FormConectados.Show();
        }
    }
}

        
