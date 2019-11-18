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
using System.Threading;


namespace ProyectoSO2
{
    public partial class Inicio : Form
    {
        Socket server;
        Thread Atender;
        string ip = "147.83.117.22";
        int puerto = 50057;
        public Inicio()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void AtenderServidor()
        {
            try
            {
                while (true)
                {
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    string[] mensaje = Encoding.ASCII.GetString(msg2).Split(':');
                    int codigo = Convert.ToInt32(mensaje[0]);
                    string contenido = mensaje[1].Split('\0')[0];
                    switch (codigo)
                    {
                        case 1:
                            if (contenido == "0")
                            {
                                Mensaje.Enabled = true;
                                Enviar.Enabled = true;
                                Desconexion.Enabled = true;

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
                                Atender.Abort();
                            }
                            break;
                        case 2:
                            if (contenido == "0")
                            {
                                Mensaje.Enabled = true;
                                Enviar.Enabled = true;
                                Desconexion.Enabled = true;
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
                                Atender.Abort();
                            }
                            break;
                        case 3:
                            if (contenido == "NoEncontrado")
                            {
                                MessageBox.Show("No se ha encontrado el jugador");
                            }
                            else if (contenido != "")
                            {
                                MessageBox.Show("Número de turnos:" + contenido);
                            }
                            else
                            {
                                MessageBox.Show("Error");
                            }
                            break;
                        case 4:
                            if (contenido == "NoEncontrado")
                            {
                                MessageBox.Show("No se ha encontrado la partida");
                            }
                            else if (contenido != "")
                            {
                                MessageBox.Show("Jugadores:" + contenido);
                            }
                            else
                            {
                                MessageBox.Show("Error");
                            }
                            break;
                        case 5:
                            if (contenido == "NoEncontrado")
                            {
                                MessageBox.Show("No se ha encontrado la partida");
                            }
                            else if (contenido != "")
                            {
                                MessageBox.Show("Número de turnos:" + contenido);
                            }
                            else
                            {
                                MessageBox.Show("Error");
                            }
                            break;
                        case 6:
                            string[] str = contenido.Split('/');
                            int i = Convert.ToInt32(str[0]);
                            string usuarios = str[1];
                            string[] Users = usuarios.Split(',');
                            dataGridView1.ColumnCount = 1;
                            dataGridView1.RowCount = Users.Length;
                            i = 0;
                            foreach (string User in Users)
                            {
                                dataGridView1[0, i].Value = Users[i];
                                i = i + 1;
                            }
                            break;
                    }
                }
            }

            catch (SocketException)
            {
                MessageBox.Show("Error de conexión con el servidor");
            }
        }

        private void Registro_Click(object sender, EventArgs e)
        {
            if ((User.Text == "") || (Password.Text == ""))
            {
                MessageBox.Show("No hay datos introducidos");
            }

            else
            {
                try
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

                    ThreadStart ts = delegate { AtenderServidor(); };
                    Atender = new Thread(ts);
                    Atender.Start();
                }

                catch (SocketException)
                {
                    MessageBox.Show("Error de conexión con el servidor");
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
                try
                {
                    IPAddress direc = IPAddress.Parse(ip);
                    IPEndPoint ipep = new IPEndPoint(direc, puerto);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    server.Connect(ipep);//Intentamos conectar el socket

                    string mensaje = "2/" + User.Text + "," + Password.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    ThreadStart ts = delegate { AtenderServidor(); };
                    Atender = new Thread(ts);
                    Atender.Start();
                }

                catch (SocketException)
                {
                    MessageBox.Show("Error de conexión con el servidor");
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
                    try
                    {
                        if (Consulta1.Checked)
                        {
                            string mensaje = "3/" + Mensaje.Text;
                            // Enviamos al servidor el nombre tecleado
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);
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
                            }
                        }

                        if (Consulta3.Checked)
                        {
                            if (Mensaje.Text == "")
                            {
                                MessageBox.Show("No hay datos introducidos");
                            }

                            else
                            {
                                string mensaje = "5/" + Mensaje.Text;
                                // Enviamos al servidor el nombre tecleado
                                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                                server.Send(msg);
                            }
                        }
                    }
                    catch (SocketException)
                    {
                        MessageBox.Show("Error de conexión con el servidor");
                    }
                }
            }
        }

        private void Desconexion_Click(object sender, EventArgs e)
        {
            try
            {
                Atender.Abort();
                string mensaje = "0/" + User.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                Mensaje.Enabled = false;
                Enviar.Enabled = false;
                Desconexion.Enabled = false;
                MessageBox.Show("Te has desconectado");
                InicioSesion.Enabled = true;
                RegistroBoton.Enabled = true;
                User.Enabled = true;
                Password.Enabled = true;
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
            }

            catch (SocketException)
            {
                MessageBox.Show("Error de conexión con el servidor");
            }
        }
    }
}


