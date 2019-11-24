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
        string ip = "192.168.56.106";
        int puerto = 9077;
        List<string> Aceptados = new List<string>();
        List<string> Respuestas = new List<string>();
        int Invitaciones;
        string UsuarioInvita;
        public Inicio()
        {
            this.ControlBox = false;
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            
        }

        private void AtenderServidor()
        {
                while (true)
                {
                    byte[] msg2 = new byte[80];
                try
                {
                    server.Receive(msg2);
                }
                catch(SocketException ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

                    string[] mensaje = Encoding.ASCII.GetString(msg2).Split(':');
                try
                {
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
                        case 7:
                            Invitacion.Text = contenido + " te ha invitado a jugar";
                            UsuarioInvita = contenido;
                            AceptarInvitacion.Enabled = true;
                            RechazarInvitacion.Enabled = true;
                            break;
                        case 8:
                            Aceptados.Add(contenido);
                            Respuestas.Add(contenido);
                            MessageBox.Show(contenido + " ha aceptado la partida");
                            if (Invitaciones == Aceptados.Count)
                            {
                                MessageBox.Show("Todos los jugadores han aceptado la partida");
                                Empezar_Partida();
                            }
                            else if ((Invitaciones == Respuestas.Count()) && (Respuestas.Count != Aceptados.Count()))
                            {
                                MessageBox.Show("Algun jugador ha rechazado la partida");
                                Invite.Enabled = true;
                                Invitaciones = 0;
                                Respuestas.Clear();
                                Aceptados.Clear();

                            }
                            break;
                        case 9:
                            MessageBox.Show(contenido + " ha rechazado la partida");
                            Respuestas.Add(contenido);
                            if ((Invitaciones == Respuestas.Count()) && (Respuestas.Count != Aceptados.Count()))
                            {
                                MessageBox.Show("Algun jugador ha rechazado la partida");
                                Invite.Enabled = true;
                                Invitaciones = 0;
                                Respuestas.Clear();
                                Aceptados.Clear();
                            }
                            break;
                        case 10:
                            MessageBox.Show("Iniciando partida");                          
                            break;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Se ha perdido la conexion con el servidor");
                    Application.Exit();
                    break;
                }
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
                    IPAddress direc = IPAddress.Parse(ip);
                    IPEndPoint ipep = new IPEndPoint(direc, puerto);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    server.Connect(ipep);

                    string mensaje = "1/" + User.Text + "," + Password.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    ThreadStart ts = delegate { AtenderServidor(); };
                    Atender = new Thread(ts);
                    Atender.Start();
                }
                catch(SocketException)
                {
                    MessageBox.Show("Error al conectar con el servidor");
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
                    server.Connect(ipep);

                    string mensaje = "2/" + User.Text + "," + Password.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    ThreadStart ts = delegate { AtenderServidor(); };
                    Atender = new Thread(ts);
                    Atender.Start();
                    Cerrar.Enabled = false;
                }
                catch (SocketException)
                {
                    MessageBox.Show("Error al conectar con el servidor");
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
                                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                                server.Send(msg);
                            }
                        }
                    }
                    catch(SocketException)
                    {
                        MessageBox.Show("Error al conectar con el servidor");
                    }
                }
            }
        }

        private void Desconexion_Click(object sender, EventArgs e)
        {
                Atender.Abort();
                string mensaje = "0/" + User.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                Mensaje.Enabled = false;
                Enviar.Enabled = false;
                Desconexion.Enabled = false;
                MessageBox.Show("Te has desconectado");
                Cerrar.Enabled = true;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
        }

        private void Invite_Click(object sender, EventArgs e)
        {
            string UsuariosInvitados = "";
            bool PermitirInvitacion = true;
            int Seleccionados = dataGridView1.SelectedRows.Count;
            int i = 0;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (Convert.ToString(row.Cells[0].Value) == User.Text)
                {
                    MessageBox.Show("No puedes invitarte a ti mismo");
                    PermitirInvitacion = false;
                    break;
                }
                else if (Seleccionados-1 != i )
                {
                    UsuariosInvitados = UsuariosInvitados + row.Cells[0].Value+",";
                }
                else
                {
                    UsuariosInvitados = UsuariosInvitados + row.Cells[0].Value;
                }
                i = i + 1;
            }
            if (PermitirInvitacion == true)
            {
                string mensaje ="6/" + Convert.ToString(i+1) + ":" + User.Text +","+ UsuariosInvitados;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                Invitaciones = i;
                Invite.Enabled = false;
            }
            
        }

        private void AceptarInvitacion_Click(object sender, EventArgs e)
        {
            string mensaje = "7/" + UsuarioInvita + "," + User.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            AceptarInvitacion.Enabled = false;
            RechazarInvitacion.Enabled = false;
            Invite.Enabled = false;
        }

        private void RechazarInvitacion_Click(object sender, EventArgs e)
        {
            string mensaje = "8/" + UsuarioInvita + "," + User.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            AceptarInvitacion.Enabled = false;
            RechazarInvitacion.Enabled = false;
            Invite.Enabled = true;
        }
        private void Empezar_Partida()
        {
            string Usuarios="";
            int i = 0;
            foreach (string usuario in Aceptados)
            {
                Usuarios = Usuarios + usuario + ",";
                i = i + 1;
            }
            string mensaje = "9/" +  Usuarios + User.Text + ',';
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


