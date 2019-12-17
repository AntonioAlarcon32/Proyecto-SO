using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Text;
using WMPLib;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using PokemonLib;

namespace ProyectoSO2
{
    public partial class Batalla : Form
    {
        string directorio = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        PrivateFontCollection pfc = new PrivateFontCollection();
        Equipo EquipoJugador1 = new Equipo();
        Equipo EquipoJugador2 = new Equipo();
        Bitmap pokeball = new Bitmap(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\UI\\pokeball.png");
        Bitmap pokeballdebilitado = new Bitmap(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\UI\\pokeballblanco.png");
        Bitmap HealthBar = new Bitmap(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\UI\\healthbar.png");
        static Random rand = new Random();
        SoundPlayer Player1 = new SoundPlayer(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Music\\batalla" + Convert.ToString(rand.Next(1, 9)) + ".wav");

        Pokemon PokemonLuchando1 = new Pokemon();
        int numPokemonLuchandoPlayer1 = 0;
        Pokemon PokemonLuchando2 = new Pokemon();
        int numPokemonLuchandoPlayer2 = 0;

        bool Spawning = true;
        bool CambiandoPoke = false;

        int ID;

        string Jugador1;
        string Jugador2;
        Socket Server;
        delegate void EscribirChat(string MensajeChat);
        delegate void CerrarChat();


        PictureBox barrasalud1 = new PictureBox();
        PictureBox barrasalud2 = new PictureBox();

        int contador;
        public void GetEquipoPropio(Equipo team)
        {
            EquipoJugador1 = team;
           
        }


        public Batalla(string Play1, string Play2, Equipo EqJugador1, Equipo EqJugador2, int ID, Socket Server)
        {
            pfc.AddFontFile(directorio + "\\UI\\fuente.ttf");
            this.Jugador1 = Play1;
            this.Jugador2 = Play2;
            this.EquipoJugador1 = EqJugador1;
            this.EquipoJugador2 = EqJugador2;
            this.ID = ID;
            this.Server = Server;

            InitializeComponent();
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


        private void PreMatch(Equipo Player1, string Juga1, Equipo Player2, string Juga2)
        {
            PictureBox Pokemon1 = new PictureBox();
            PictureBox Pokemon2 = new PictureBox();
            PictureBox Pokemon3 = new PictureBox();
            Bitmap image1 = new Bitmap(directorio + "\\SmallSprites\\" + Player1.GetPokemon(0).Nombre + ".png");
            Bitmap image2 = new Bitmap(directorio + "\\SmallSprites\\" + Player1.GetPokemon(1).Nombre + ".png");
            Bitmap image3 = new Bitmap(directorio + "\\SmallSprites\\" + Player1.GetPokemon(2).Nombre + ".png");
            Pokemon1.Image = (Image)image1;
            Pokemon2.Image = (Image)image2;
            Pokemon3.Image = (Image)image3;
            Pokemon1.Location = new Point(40, 60);
            Pokemon2.Location = new Point(40, 100);
            Pokemon3.Location = new Point(40, 140);
            panel1.Controls.Add(Pokemon1);
            panel1.Controls.Add(Pokemon2);
            panel1.Controls.Add(Pokemon3);
            Label Jug1 = new Label();
            Jug1.Text = Juga1;
            Jug1.Font = new Font(pfc.Families[0], 10, FontStyle.Regular);
            Jug1.Location = new Point(40, 40);
            panel1.Controls.Add(Jug1);

            PictureBox Pokemon4 = new PictureBox();
            PictureBox Pokemon5 = new PictureBox();
            PictureBox Pokemon6 = new PictureBox();
            Bitmap image4 = new Bitmap(directorio + "\\SmallSprites\\" + Player2.GetPokemon(0).Nombre + ".png");
            Bitmap image5 = new Bitmap(directorio + "\\SmallSprites\\" + Player2.GetPokemon(1).Nombre + ".png");
            Bitmap image6 = new Bitmap(directorio + "\\SmallSprites\\" + Player2.GetPokemon(2).Nombre + ".png");
            Pokemon4.Image = (Image)image4;
            Pokemon5.Image = (Image)image5;
            Pokemon6.Image = (Image)image6;
            Pokemon4.Location = new Point(160, 60);
            Pokemon5.Location = new Point(160, 100);
            Pokemon6.Location = new Point(160, 140);
            panel1.Controls.Add(Pokemon4);
            panel1.Controls.Add(Pokemon5);
            panel1.Controls.Add(Pokemon6);
            Label Jug2 = new Label();
            Jug2.Text = Juga2;
            Jug2.Font = new Font(pfc.Families[0], 10, FontStyle.Regular);
            Jug2.Location = new Point(160, 40);
            panel1.Controls.Add(Jug2);

            Jug1.BringToFront();
            Pokemon1.BringToFront();
            Pokemon2.BringToFront();
            Pokemon3.BringToFront();
            Jug2.BringToFront();
            Pokemon4.BringToFront();
            Pokemon5.BringToFront();
            Pokemon6.BringToFront();
        }

        private void SpawnPokemon2(Pokemon poke)
        {
            PictureBox Pokemon = new PictureBox();                                //Creamos un picturebox y un punto
            Pokemon.ClientSize = new Size(100, 100);
            Pokemon.Location = new Point(310,80);
            Bitmap image = new Bitmap(directorio + "\\Sprites\\" + poke.Nombre + ".gif");
            Pokemon.Image = (Image)image;
            int h = 100 - image.Height;
            int l = (100 - image.Width) / 2;
            Pokemon.Padding = new Padding(l, h, 0, 0);
            PokemonP2.Font = new Font(pfc.Families[0], 12, FontStyle.Regular);
            PokemonP2.Text = poke.Nombre;
            Pokemon.BackColor = Color.Transparent;
            panel1.Controls.Add(Pokemon);
            WindowsMediaPlayer pokemon = new WindowsMediaPlayer();
            pokemon.URL = directorio + "\\Sounds\\" + poke.Nombre + ".wav";
            pokemon.controls.play();
            PokemonP2.Visible = true;
            HealthBar1.Image = (Image)HealthBar;
            Notif.Text = Jugador2 + " saca a " + poke.Nombre;
            ActualizarBarraSalud2(PokemonLuchando2, barrasalud2);
        }

        private int ProporcionPS(int PSActuales, int PSMax)
        {
            float pend = (float)85 / (float)PSMax;
            float x = PSActuales * pend;
            return (int) x;
        }
        private void ActualizarBarraSalud1(Pokemon pokemon, PictureBox barra)
        {
            if ((double)PokemonLuchando1.PSactuales / (double)PokemonLuchando1.PS > 0.6)
            {
                Bitmap color = new Bitmap(directorio + "\\UI\\"  + "verde.png");
                barra.Image = (Image)color;
                barra.SizeMode = PictureBoxSizeMode.StretchImage;
                barra.Parent = HealthBar2;
                barra.Location = (new Point(28, 3));
                barra.Width = ProporcionPS(PokemonLuchando1.PSactuales, PokemonLuchando1.PS);
                barra.Height = 5;
                barra.BringToFront();
            }

            else if ((double)PokemonLuchando1.PSactuales / (double)PokemonLuchando1.PS > 0.25)
            {
                Bitmap color = new Bitmap(directorio + "\\UI\\" + "amarillo.png");
                barra.Image = (Image)color;
                barra.SizeMode = PictureBoxSizeMode.StretchImage;
                barra.Parent = HealthBar2;
                barra.Location = (new Point(28, 3));
                barra.Width = ProporcionPS(PokemonLuchando1.PSactuales, PokemonLuchando1.PS);
                barra.Height = 5;
                barra.BringToFront();
            }
            else
            {
                Bitmap color = new Bitmap(directorio + "\\UI\\" + "rojo.png");
                barra.Image = (Image)color;
                barra.SizeMode = PictureBoxSizeMode.StretchImage;
                barra.Parent = HealthBar2;
                barra.Location = (new Point(28, 3));
                barra.Width = ProporcionPS(PokemonLuchando1.PSactuales, PokemonLuchando1.PS);
                barra.Height = 5;
                barra.BringToFront();
            }
        }
        private void ActualizarBarraSalud2(Pokemon pokemon, PictureBox barra)
        {
            if ((double)PokemonLuchando2.PSactuales / (double)PokemonLuchando2.PS > 0.6)
            {
                Bitmap color = new Bitmap(directorio + "\\UI\\" + "verde.png");
                barra.Image = (Image)color;
                barra.SizeMode = PictureBoxSizeMode.StretchImage;
                barra.Parent = HealthBar1;
                barra.Location = (new Point(28, 3));
                barra.Width = ProporcionPS(PokemonLuchando2.PSactuales, PokemonLuchando2.PS);
                barra.Height = 5;
                barra.BringToFront();
            }

            else if ((double)PokemonLuchando2.PSactuales / (double)PokemonLuchando2.PS > 0.25)
            {
                Bitmap color = new Bitmap(directorio + "\\UI\\" + "amarillo.png");
                barra.Image = (Image)color;
                barra.SizeMode = PictureBoxSizeMode.StretchImage;
                barra.Parent = HealthBar1;
                barra.Location = (new Point(28, 3));
                barra.Width = ProporcionPS(PokemonLuchando2.PSactuales, PokemonLuchando2.PS);
                barra.Height = 5;
                barra.BringToFront();
            }
            else
            {
                Bitmap color = new Bitmap(directorio + "\\UI\\" + "rojo.png");
                barra.Image = (Image)color;
                barra.SizeMode = PictureBoxSizeMode.StretchImage;
                barra.Parent = HealthBar1;
                barra.Location = (new Point(28, 3));
                barra.Width = ProporcionPS(PokemonLuchando2.PSactuales, PokemonLuchando2.PS);
                barra.Height = 5;
                barra.BringToFront();
            }
        }

        private void SpawnPokemon1(Pokemon Poke)
        {
            PictureBox Pokemon4 = new PictureBox(); //Creamos un picturebox y un punto
            panel1.Controls.Remove(Pokemon4);
            Pokemon4.ClientSize = new Size(140, 140);
            Pokemon4.Location = new Point(50,140);

            Bitmap image4 = new Bitmap(directorio + "\\Sprites\\" + Poke.Nombre + "Back.gif");                             //Cogemos el icono
            Pokemon4.Image = (Image)image4;
            Pokemon4.SizeMode = PictureBoxSizeMode.StretchImage;
            int h = Convert.ToInt32(140 - image4.Height * 1.4);
            int l = Convert.ToInt32(140 - image4.Width * 1.4) / 2;
            Pokemon4.Padding = new Padding(l, h, l, 0);
            Pokemon4.BackColor = Color.Transparent;
            panel1.Controls.Add(Pokemon4);
            WindowsMediaPlayer pokemon4 = new WindowsMediaPlayer();
            pokemon4.URL = directorio + "\\Sounds\\" + Poke.Nombre + ".wav";
            pokemon4.controls.play();
            PokemonP1.Font = new Font(pfc.Families[0], 12, FontStyle.Regular);
            PokemonP1.Text = Poke.Nombre;
            PokemonP1.Visible = true;
            Pokemon4.BringToFront();
            Bitmap Boton1 = new Bitmap(directorio + "\\Botones\\" + Poke.moveSet.Movimientos[0].Tipo + ".png");
            Bitmap Boton2 = new Bitmap(directorio + "\\Botones\\" + Poke.moveSet.Movimientos[1].Tipo + ".png");
            Bitmap Boton3 = new Bitmap(directorio + "\\Botones\\" + Poke.moveSet.Movimientos[2].Tipo + ".png");
            Bitmap Boton4 = new Bitmap(directorio + "\\Botones\\" + Poke.moveSet.Movimientos[3].Tipo + ".png");
            Mov1.Image = (Image)Boton1;
            Mov2.Image = (Image)Boton2;
            Mov3.Image = (Image)Boton3;
            Mov4.Image = (Image)Boton4;
            Mov1Text.Text = Poke.moveSet.Movimientos[0].Nombre;
            Mov2Text.Text = Poke.moveSet.Movimientos[1].Nombre;
            Mov3Text.Text = Poke.moveSet.Movimientos[2].Nombre;
            Mov4Text.Text = Poke.moveSet.Movimientos[3].Nombre;
            Mov1Text.Parent = Mov1;
            Mov1Text.Font = new Font(pfc.Families[0], 8, FontStyle.Regular);
            Mov1Text.Location = new Point(Mov1.Width/2-Mov1Text.Width/2, 15);
            Mov1Text.BringToFront();
            Mov1Text.Visible = true;
            PPMov1.Text = Convert.ToString(Poke.moveSet.Movimientos[0].PPAct) + "/" + Convert.ToString(Poke.moveSet.Movimientos[0].PPMax);
            PPMov1.Parent = Mov1;
            PPMov1.Font = new Font(pfc.Families[0], 10, FontStyle.Regular);
            PPMov1.Location = new Point(72, 29);
            PPMov1.BringToFront();
            PPMov1.Visible = true;


            Mov2Text.Parent = Mov2;
            Mov2Text.Font = new Font(pfc.Families[0], 8, FontStyle.Regular);
            Mov2Text.Location = new Point(Mov2.Width / 2 - Mov2Text.Width / 2, 15);
            Mov2Text.BringToFront();
            Mov2Text.Visible = true;
            PPMov2.Text = Convert.ToString(Poke.moveSet.Movimientos[1].PPAct) + "/" + Convert.ToString(Poke.moveSet.Movimientos[1].PPMax);
            PPMov2.Parent = Mov2;
            PPMov2.Font = new Font(pfc.Families[0], 10, FontStyle.Regular);
            PPMov2.Location = new Point(72, 29);
            PPMov2.BringToFront();
            PPMov2.Visible = true;
            Mov3Text.Parent = Mov3;
            Mov3Text.Font = new Font(pfc.Families[0], 8, FontStyle.Regular);
            Mov3Text.Location = new Point(Mov3.Width / 2 - Mov3Text.Width / 2, 15);
            Mov3Text.BringToFront();
            Mov3Text.Visible = true;
            PPMov3.Text = Convert.ToString(Poke.moveSet.Movimientos[2].PPAct) + "/" + Convert.ToString(Poke.moveSet.Movimientos[2].PPMax);
            PPMov3.Parent = Mov3;
            PPMov3.Font = new Font(pfc.Families[0], 10, FontStyle.Regular);
            PPMov3.Location = new Point(72, 29);
            PPMov3.BringToFront();
            PPMov3.Visible = true;

            Mov4Text.Parent = Mov4;
            Mov4Text.Font = new Font(pfc.Families[0], 8, FontStyle.Regular);
            Mov4Text.Location = new Point(Mov4.Width / 2 - Mov4Text.Width / 2, 15);
            Mov4Text.BringToFront();
            Mov4Text.Visible = true;
            PPMov4.Text = Convert.ToString(Poke.moveSet.Movimientos[2].PPAct) + "/" + Convert.ToString(Poke.moveSet.Movimientos[2].PPMax);
            PPMov4.Parent = Mov4;
            PPMov4.Font = new Font(pfc.Families[0], 10, FontStyle.Regular);
            PPMov4.Location = new Point(72, 29);
            PPMov4.BringToFront();
            PPMov4.Visible = true;
            Notif.Text = Jugador1 + " saca a " + Poke.Nombre;
            HealthBar2.Image = (Image)HealthBar;
            ActualizarBarraSalud1(PokemonLuchando1, barrasalud1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IDLabel.Text = Convert.ToString(ID);
            ChatData.ColumnCount = 2;
            PokemonLuchando1 = EquipoJugador1.GetPokemon(0);
            PokemonLuchando2 = EquipoJugador2.GetPokemon(0);
            timer.Interval = (2000);
            timer.Tick += new EventHandler(timer_Tick);
            pokeball1.Image = (Image)pokeball;
            pokeball2.Image = (Image)pokeball;
            pokeball3.Image = (Image)pokeball;
            pokeball4.Image = (Image)pokeball;
            pokeball5.Image = (Image)pokeball;
            pokeball6.Image = (Image)pokeball;
            Notif.Parent = Fondo;
            Notif.Font = new Font(pfc.Families[0], 10, FontStyle.Regular);
            Notif.Location = new Point(15, 5);
            Notif.BringToFront();
            timer.Start();
            Jug1.Text = Jugador1;
            Jug2.Text = Jugador2;


        }

        private void timer_Tick(object sender, EventArgs e)
        {
            contador = contador + 1;
            counter.Text = Convert.ToString(contador);
            if (contador == 1)
                PreMatch(EquipoJugador1,Jugador1,EquipoJugador2,Jugador2);
            if (contador == 10) 
            {
                panel1.Controls.Clear();
                Bitmap campo = new Bitmap(directorio + "\\UI\\campo.png");
                panel1.BackgroundImage = campo; 
                Player1.PlayLooping();
            }
            if (contador == 14)
                SpawnPokemon2(PokemonLuchando2);
            if (contador == 18)
                SpawnPokemon1(PokemonLuchando1);
            Spawning = false;
        }

        

        private void kill_Click(object sender, EventArgs e)
        {
            EquipoJugador1.Pokemons[0].PSactuales = 0;
            if (EquipoJugador1.Pokemons[0].PSactuales == 0)
            {
                pokeball1.Image = (Image)pokeballdebilitado;
            }
        }

        private void CambiarPokemon_Click(object sender, EventArgs e)
        {
            if (Spawning == false)
            {
                CambiandoPoke = true;
                Notif.Text = "Selecciona el Pokemon al que cambiar";
            }
        }

        private void pokeball1_Click(object sender, EventArgs e)
        {
            if ((CambiandoPoke == true) && (numPokemonLuchandoPlayer1 != 0))
            {
                PokemonLuchando1 = EquipoJugador1.GetPokemon(0);
                SpawnPokemon1(PokemonLuchando1);
                panel1.Refresh();
                numPokemonLuchandoPlayer1 = 0;
                CambiandoPoke = false;
            }
        }

        private void pokeball2_Click(object sender, EventArgs e)
        {
            if ((CambiandoPoke == true) && (numPokemonLuchandoPlayer1 != 1))
            {
                PokemonLuchando1 = EquipoJugador1.GetPokemon(1);
                SpawnPokemon1(PokemonLuchando1);
                panel1.Refresh();
                numPokemonLuchandoPlayer1 = 1;
                CambiandoPoke = false;
            }
        }

        private void pokeball3_Click(object sender, EventArgs e)
        {
            if ((CambiandoPoke == true) && (numPokemonLuchandoPlayer1 != 2))
            {
                PokemonLuchando1 = EquipoJugador1.GetPokemon(2);
                SpawnPokemon1(PokemonLuchando1);
                panel1.Refresh();
                numPokemonLuchandoPlayer1 = 2;
                CambiandoPoke = false;
            }
        }

        private void cuarenta_Click(object sender, EventArgs e)
        {
            Double newPS = PokemonLuchando1.PS * 0.4;
            PokemonLuchando1.PSactuales = (int)newPS;
            ActualizarBarraSalud1(PokemonLuchando1, barrasalud1);
        }

        private void dos_Click(object sender, EventArgs e)
        {
            Double newPS = PokemonLuchando1.PS * 0.2;
            PokemonLuchando1.PSactuales = (int)newPS;
            ActualizarBarraSalud1(PokemonLuchando1,barrasalud1);
        }

        private void EnviarChat_Click(object sender, EventArgs e)
        {
            string mensaje = "10/" + Convert.ToString(ID) + "," + Jugador1 + ";" + MensajeChat.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            Server.Send(msg);
            MensajeChat.Clear();
        }

        private void Abandonar_Click(object sender, EventArgs e)
        {
            string mensaje = "11/" + Convert.ToString(ID) + "," + Jugador1;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            Server.Send(msg);
            this.Close();
        }

        private void Batalla_FormClosing(object sender, FormClosingEventArgs e)
        {
            Player1.Stop();
        }
    }
}
