using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Text;
using WMPLib;
using System.Net.Sockets;
using PokemonLib;

namespace ProyectoSO2
{
    public partial class Batalla : Form
    {
        Icon iconopokeball = new Icon(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\UI\\icono.ico");

        public BattleManager bt = new BattleManager();
        string directorio = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        PrivateFontCollection pfc = new PrivateFontCollection();

        Equipo EquipoJugador1 = new Equipo();
        Equipo EquipoJugador2 = new Equipo();
        //Todos los bitmaps 
        Bitmap pokeball = new Bitmap(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\UI\\pokeball.png");
        Bitmap pokeballdebilitado = new Bitmap(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\UI\\pokeballblanco.png"); 
        Bitmap HealthBar = new Bitmap(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\UI\\healthbar.png");
        Bitmap FondoNotif = new Bitmap(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\UI\\Dialog.png");

        //Elegimos cancion aleatoriamente
        static Random rand = new Random();
        SoundPlayer Player1 = new SoundPlayer(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Music\\batalla" + Convert.ToString(rand.Next(1, 10)) + ".wav");

        Pokemon PokemonLuchando1 = new Pokemon();
        int numPokemonLuchandoPlayer1 = 0;
        Pokemon PokemonLuchando2 = new Pokemon();
        int numPokemonLuchandoPlayer2 = 0;

        bool CambiandoPoke = false;
        bool debilitado = false;
        bool Orden1Done = false;        //Booleans para procesar los turnos
        bool Orden2Done = false;
        bool PartidaGanada = false;
        bool Procesado = false;

        int ID;

        string Jugador1;
        string Jugador2;
        string[] ordenes = new string[8];

        Socket Server;

        delegate void EscribirChat(string MensajeChat);
        delegate void CerrarChat();                                 //Delegados para los mensajes entrantes
        delegate void CambiarPokemonDebilitado(string contenido);


        PictureBox barrasalud1 = new PictureBox();
        PictureBox barrasalud2 = new PictureBox();

        PictureBox SpritePokemon1 = new PictureBox();
        PictureBox SpritePokemon2 = new PictureBox();

        int contador, TimerUltimaOrden;
        public void GetEquipoPropio(Equipo team)
        {
            EquipoJugador1 = team;
           
        }


        public Batalla(string Play1, string Play2, Equipo EqJugador1, Equipo EqJugador2, int ID, Socket Server)
        {
            pfc.AddFontFile(directorio + "\\UI\\fuente.ttf");
            this.Jugador1 = Play1;
            this.Jugador2 = Play2;
            this.EquipoJugador1.CopiarEquipo(EqJugador1);
            this.EquipoJugador2.CopiarEquipo(EqJugador2);
            this.ID = ID;                                       //Constructor del form
            this.Server = Server;
            this.bt.SetPlayers(Play1, Play2);
            InitializeComponent();
            Fondo.Image = (Image)FondoNotif;
            this.Icon = iconopokeball;
            this.Text = "Batalla " + Convert.ToString(ID);
        }
        public void EscribirMensaje(string contenido)
        {   //Funcion que escribe el mensaje que le entra en el chat
            EscribirChat delegadoChat = new EscribirChat(EscribirMensajeDelegado);
            ChatData.Invoke(delegadoChat, new object[] { contenido });             
            string[] Message = contenido.Split(';');
        }

        public void PokemonDebilitadoDelegado(string contenido)
        {   //Funcion que permite al thread cambiar al pokemon en batalla cuando se debilita
            CambiarPokemonDebilitado delegadoPoke = new CambiarPokemonDebilitado(PokemonDebilitado);
            panel1.Invoke(delegadoPoke, new object[] { contenido });
        }

        public void SetOrders(string mensaje)   //Funcion para darle los mensajes al BattleManager
        {
            this.bt.RecibirOrden(mensaje);      
        }

        public void EscribirMensajeDelegado(string contenido)   //Funcion para escribir el mensaje en el chat
        {
            string[] Message = contenido.Split(';');
            ChatData.Rows.Add(Message);
        }

        public void AbandonarPartida() 
        {
            CerrarChat delegado = new CerrarChat(CerrarPartida);
            label1.Invoke(delegado);

        }

        public void CerrarPartida()
        {
            this.Close();
        }

        private void PreMatch(Equipo Player1, string Juga1, Equipo Player2, string Juga2)
        {   //Funcion que muestra en el panel los pokemons de los dos equipos los primeros 10 segundos
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

        private int ProporcionPS(int PSActuales, int PSMax)
        {   //Normaliza los PS respecto a la longitud de la barra de vida
            float pend = (float)85 / (float)PSMax;
            float x = PSActuales * pend;
            return (int) x;
        }
        private void ActualizarBarraSalud1(Pokemon pokemon, PictureBox barra)
        {   //Cambia la longitud de la barra de vida segun los PS del jugador 1
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
        {   //Cambia la longitud de la barra de vida segun los PS del jugador 2
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
        {   //Hace que aparezca el pokemon en el hueco del jugador 1, ademas hace aparecer los botones
            panel1.Controls.Remove(SpritePokemon1);
            SpritePokemon1.ClientSize = new Size(140, 140);
            SpritePokemon1.Location = new Point(50,140);

            Bitmap image4 = new Bitmap(directorio + "\\Sprites\\" + Poke.Nombre + "Back.gif");                             //Cogemos el icono
            SpritePokemon1.Image = (Image)image4;
            SpritePokemon1.SizeMode = PictureBoxSizeMode.StretchImage;
            int h = Convert.ToInt32(140 - image4.Height * 1.4);
            int l = Convert.ToInt32(140 - image4.Width * 1.4) / 2;
            SpritePokemon1.Padding = new Padding(l, h, l, 0);
            SpritePokemon1.BackColor = Color.Transparent;
            panel1.Controls.Add(SpritePokemon1);
            WindowsMediaPlayer pokemon4 = new WindowsMediaPlayer();
            pokemon4.URL = directorio + "\\Sounds\\" + Poke.Nombre + ".wav";
            pokemon4.controls.play();
            PokemonP1.Font = new Font(pfc.Families[0], 12, FontStyle.Regular);
            PokemonP1.Text = Poke.Nombre;
            PokemonP1.Visible = true;
            SpritePokemon1.BringToFront();
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
            PPMov4.Text = Convert.ToString(Poke.moveSet.Movimientos[3].PPAct) + "/" + Convert.ToString(Poke.moveSet.Movimientos[3].PPMax);
            PPMov4.Parent = Mov4;
            PPMov4.Font = new Font(pfc.Families[0], 10, FontStyle.Regular);
            PPMov4.Location = new Point(72, 29);
            PPMov4.BringToFront();
            PPMov4.Visible = true;
            Notif.Text = Jugador1 + " saca a " + Poke.Nombre;
            HealthBar2.Image = (Image)HealthBar;
            ActualizarBarraSalud1(PokemonLuchando1, barrasalud1);
        }

        private void SpawnPokemon2(Pokemon poke)
        {   //Hace que aparezcan los pokemons en el hueco del jugador 2

            SpritePokemon2.ClientSize = new Size(100, 100);
            SpritePokemon2.Location = new Point(310, 80);
            Bitmap image = new Bitmap(directorio + "\\Sprites\\" + poke.Nombre + ".gif");
            SpritePokemon2.Image = (Image)image;
            int h = 100 - image.Height;
            int l = (100 - image.Width) / 2;
            SpritePokemon2.Padding = new Padding(l, h, 0, 0);
            PokemonP2.Font = new Font(pfc.Families[0], 12, FontStyle.Regular);
            PokemonP2.Text = poke.Nombre;
            SpritePokemon2.BackColor = Color.Transparent;
            panel1.Controls.Add(SpritePokemon2);
            WindowsMediaPlayer pokemon = new WindowsMediaPlayer();
            pokemon.URL = directorio + "\\Sounds\\" + poke.Nombre + ".wav";
            pokemon.controls.play();
            PokemonP2.Visible = true;
            HealthBar1.Image = (Image)HealthBar;
            Notif.Text = Jugador2 + " saca a " + poke.Nombre;
            ActualizarBarraSalud2(PokemonLuchando2, barrasalud2);
        }

        public void ChangePokemon(string Player, int PokemonActual, int PokemonCambio)
        {   //Cambia el pokemon en memoria y guarda los PS
            if (Player == this.Jugador1)
            {
                EquipoJugador1.Pokemons[PokemonActual].PSactuales = PokemonLuchando1.PSactuales;
                PokemonLuchando1 = EquipoJugador1.GetPokemon(PokemonCambio);
                SpawnPokemon1(PokemonLuchando1);
                ActualizarBarraSalud1(PokemonLuchando1, barrasalud1);
            }
            if (Player == this.Jugador2)
            {
                EquipoJugador2.Pokemons[PokemonActual].PSactuales = PokemonLuchando2.PSactuales;
                PokemonLuchando2 = EquipoJugador2.GetPokemon(PokemonCambio);
                SpawnPokemon2(PokemonLuchando2);
                ActualizarBarraSalud2(PokemonLuchando2, barrasalud2);
            }
        }

        public void PokemonDebilitado(string contenido)
        {   //Cambia a un pokemon cuando se ha debilitado
            string[] ordenes = contenido.Split(';');
            if (ordenes[0] == Jugador1)
            {
                ChangePokemon(Jugador1, Convert.ToInt32(ordenes[2]), Convert.ToInt32(ordenes[3]));
                numPokemonLuchandoPlayer1 = Convert.ToInt32(ordenes[3]);
            }
            if (ordenes[0] == Jugador2)
            {
                ChangePokemon(Jugador2, Convert.ToInt32(ordenes[2]), Convert.ToInt32(ordenes[3]));
                numPokemonLuchandoPlayer2 = Convert.ToInt32(ordenes[3]);
            }
            bt.ResetOrders();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            IDLabel.Text = Convert.ToString(ID);
            ChatData.ColumnCount = 2;
            PokemonLuchando1 = EquipoJugador1.GetPokemon(0);
            PokemonLuchando2 = EquipoJugador2.GetPokemon(0);
            timer.Interval = (2000);
            timer.Tick += new EventHandler(timer_Tick);
            timer1.Interval = (3000);
            timer1.Tick += new EventHandler(timer1_Tick);
            pokeball1.Image = (Image)pokeball;
            pokeball2.Image = (Image)pokeball;
            pokeball3.Image = (Image)pokeball;      //Pokeballs que aparecen en la barra de abajo
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

        private void CambiarPokemon_Click(object sender, EventArgs e)  
        {
            if (bt.GetAllowAttack() == true)
            {
                CambiandoPoke = true;
                Notif.Text = "Selecciona el Pokemon al que cambiar";
            }
        }

        private void pokeball1_Click(object sender, EventArgs e)
        {
            if (debilitado == true)
            {
                string mensaje = "16/" + Convert.ToString(ID) + "," + Jugador1 + ";" + "Cambiar;" + Convert.ToString(numPokemonLuchandoPlayer1) + ";0";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                Server.Send(msg);
                debilitado = false;

            }
            else if ((CambiandoPoke == true) && (numPokemonLuchandoPlayer1 != 0) && (EquipoJugador1.GetPokemon(0).PSactuales > 0))
            {
                string mensaje = "15/" + Convert.ToString(ID) + "," + Jugador1 + ";" + "Cambiar;" + Convert.ToString(numPokemonLuchandoPlayer1) + ";0";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                Server.Send(msg);
                CambiandoPoke = false;
                Notif.Text = "Esperando al rival";
                bt.FinTurno();
            }
        }

        private void pokeball2_Click(object sender, EventArgs e)
        {
           
            if (debilitado == true)
            {
                string mensaje = "16/" + Convert.ToString(ID) + "," + Jugador1 + ";" + "Cambiar;" + Convert.ToString(numPokemonLuchandoPlayer1) + ";1";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                Server.Send(msg);
                debilitado = false;
            }
            else if ((CambiandoPoke == true) && (numPokemonLuchandoPlayer1 != 1) && (EquipoJugador1.GetPokemon(1).PSactuales > 0))
            {
                string mensaje = "15/" + Convert.ToString(ID) + "," + Jugador1 + ";" + "Cambiar;" + Convert.ToString(numPokemonLuchandoPlayer1) + ";1";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                Server.Send(msg);
                CambiandoPoke = false;
                Notif.Text = "Esperando al rival";
                bt.FinTurno();
            }
        }

        private void pokeball3_Click(object sender, EventArgs e)
        {
            if (debilitado == true)
            {
                string mensaje = "16/" + Convert.ToString(ID) + "," + Jugador1 + ";" + "Cambiar;" + Convert.ToString(numPokemonLuchandoPlayer1) + ";2";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                Server.Send(msg);
                debilitado = false;
            }
            else if ((CambiandoPoke == true) && (numPokemonLuchandoPlayer1 != 2) && (EquipoJugador1.GetPokemon(2).PSactuales > 0))
            {
                string mensaje = "15/" + Convert.ToString(ID) + "," + Jugador1 + ";" + "Cambiar;" + Convert.ToString(numPokemonLuchandoPlayer1) + ";2";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                Server.Send(msg);
                CambiandoPoke = false;
                Notif.Text = "Esperando al rival";
                bt.FinTurno();
            }
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
            string Ganador;
            string Perdedor;
            int PokemonsRestantes;
            DateTime thisDay = DateTime.Today;
            string date = thisDay.ToString("d");
            string[] fecha = date.Split('/');       //Datos necesarios para la base de datos
            string dia = fecha[0];
            string mes = fecha[1];
            string año = fecha[2];
            string date2 = dia + "." + mes + "." + año;
            Ganador = Jugador2;
            Perdedor = Jugador1;
            PokemonsRestantes = EquipoJugador2.PokemonsRestantes();
            string mensaje = "11/" + Convert.ToString(ID) + "," + Jugador1 + "," + "2" + "," + date2 + "," + Convert.ToString(bt.GetTurnos()) + "," + Ganador + "," + Perdedor + "," + Convert.ToString(PokemonsRestantes);
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje); 
            Server.Send(msg);
            this.Close();
        }

        private void Mov1_Click(object sender, EventArgs e)
        {
            if ((bt.GetAllowAttack() == true) && (PokemonLuchando1.moveSet.Movimientos[2].PPAct > 0))
            {
                string mensaje = "15/" + Convert.ToString(ID) + "," + Jugador1 + ";" + "Atacar;" + PokemonLuchando1.moveSet.Movimientos[0].Nombre + ";" + PokemonLuchando2.Nombre;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                Server.Send(msg);
                Notif.Text = "Esperando al Rival";  //Manda el mensaje al servidor
                CambiandoPoke = false;
                PokemonLuchando1.moveSet.Movimientos[0].PPAct -= 1;
                PPMov1.Text = Convert.ToString(PokemonLuchando1.moveSet.Movimientos[0].PPAct) + "/" + Convert.ToString(PokemonLuchando1.moveSet.Movimientos[0].PPMax);
                bt.FinTurno();
            }
        }

        private void Mov2_Click(object sender, EventArgs e)
        {
            if ((bt.GetAllowAttack() == true) && (PokemonLuchando1.moveSet.Movimientos[1].PPAct > 0))
            {
                string mensaje = "15/" + Convert.ToString(ID) + "," + Jugador1 + ";" + "Atacar;" + PokemonLuchando1.moveSet.Movimientos[1].Nombre + ";" + PokemonLuchando2.Nombre;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                Server.Send(msg);
                Notif.Text = "Esperando al Rival";
                CambiandoPoke = false;
                PokemonLuchando1.moveSet.Movimientos[1].PPAct -= 1;
                PPMov2.Text = Convert.ToString(PokemonLuchando1.moveSet.Movimientos[1].PPAct) + "/" + Convert.ToString(PokemonLuchando1.moveSet.Movimientos[1].PPMax);
                bt.FinTurno();
            }
        }

        private void Mov3_Click(object sender, EventArgs e)
        {
            if ((bt.GetAllowAttack() == true) && (PokemonLuchando1.moveSet.Movimientos[2].PPAct > 0))
            {
                string mensaje = "15/" + Convert.ToString(ID) + "," + Jugador1 + ";" + "Atacar;" + PokemonLuchando1.moveSet.Movimientos[2].Nombre + ";" + PokemonLuchando2.Nombre;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                Server.Send(msg);
                Notif.Text = "Esperando al Rival";
                CambiandoPoke = false;
                PokemonLuchando1.moveSet.Movimientos[2].PPAct -= 1;
                PPMov3.Text = Convert.ToString(PokemonLuchando1.moveSet.Movimientos[2].PPAct) + "/" + Convert.ToString(PokemonLuchando1.moveSet.Movimientos[2].PPMax);
                bt.FinTurno();
            }
        }

        private void Mov4_Click(object sender, EventArgs e)
        {
            if ((bt.GetAllowAttack() == true) && (PokemonLuchando1.moveSet.Movimientos[3].PPAct > 0))
            {
                string mensaje = "15/" + Convert.ToString(ID) + "," + Jugador1 + ";" + "Atacar;" + PokemonLuchando1.moveSet.Movimientos[3].Nombre + ";" + PokemonLuchando2.Nombre;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                Server.Send(msg);
                Notif.Text = "Esperando al Rival";
                CambiandoPoke = false;
                PokemonLuchando1.moveSet.Movimientos[3].PPAct -= 1;
                PPMov4.Text = Convert.ToString(PokemonLuchando1.moveSet.Movimientos[3].PPAct) + "/" + Convert.ToString(PokemonLuchando1.moveSet.Movimientos[3].PPMax);
                bt.FinTurno();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimerUltimaOrden = TimerUltimaOrden + 1;
        }

        private void timer_Tick(object sender, EventArgs e)
        {       //Timer que controla los turnos y ejecuta las ordenes
            contador = contador + 1;
            counter.Text = Convert.ToString(contador);
            bool Recibido = bt.OrdenesRecibidas();
            if (contador == 1)
                PreMatch(EquipoJugador1, Jugador1, EquipoJugador2, Jugador2);       
            if (contador == 10)
            {
                panel1.Controls.Clear();
                Bitmap campo = new Bitmap(directorio + "\\UI\\campo.png");  //Carga el campo y los pokemons y permite empezar a luchar
                panel1.BackgroundImage = campo;
                Player1.PlayLooping();
            }
            if (contador == 14)
                SpawnPokemon2(PokemonLuchando2);
            if (contador == 18)
            {
                SpawnPokemon1(PokemonLuchando1);
                bt.InicioTurno();
            }
            if (Recibido == true)
            {
                if (Procesado == false)
                {
                    ordenes = bt.ProcesarOrdenes(EquipoJugador1, EquipoJugador2, PokemonLuchando1, PokemonLuchando2);
                }
                if ((ordenes[0] == "Cambio") && (ordenes[1] == "Cambio"))       //Se ejecuta si los dos cambian
                {
                    if (ordenes[0] == "Cambio" && !Orden1Done)
                    {
                        ChangePokemon(Jugador1, Convert.ToInt32(ordenes[2]), Convert.ToInt32(ordenes[3]));
                        numPokemonLuchandoPlayer1 = Convert.ToInt32(ordenes[3]);        //Cambia el primer pokemon
                        Orden1Done = true;
                        TimerUltimaOrden = 0;
                        timer1.Start();

                    }
                    if ((ordenes[1] == "Cambio") && (TimerUltimaOrden > 0) && !Orden2Done)
                    {
                        ChangePokemon(Jugador2, Convert.ToInt32(ordenes[4]), Convert.ToInt32(ordenes[5]));  //Cambia el segundo pokemon
                        numPokemonLuchandoPlayer2 = Convert.ToInt32(ordenes[5]);
                        Orden2Done = true;
                        timer1.Stop();
                        TimerUltimaOrden = 0;
                    }
                }
                if ((ordenes[0] == "Ataque") && (ordenes[1] == "Ataque"))
                {       //Se ejecuta si los dos atacan
                    string AtacaPrimero = ordenes[2];       
                    if (AtacaPrimero == Jugador1)
                    {
                        if (!Orden1Done)
                        {
                            double eficacia = bt.CalcularDebilidad(PokemonLuchando1.moveSet.BuscarMovimiento(ordenes[5]).Tipo, PokemonLuchando2.Tipo1, PokemonLuchando2.Tipo2);
                            string add = " ";
                            if (eficacia == 0)
                                add = "No ha tenido ningún efecto";
                            else if (eficacia == 0.5)
                                add = "No es muy eficaz";
                            else if (eficacia == 1)
                                add = " ";                  //Muestra la eficacia del movimiento
                            else if (eficacia == 2)
                                add = "Es muy eficaz!";
                            else if (eficacia == 4)
                                add = "Es super eficaz!";
                            Notif.Text = PokemonLuchando1.Nombre + " ha usado " + ordenes[5] + " " + add;
                            PokemonLuchando2.PSactuales -= Convert.ToInt32(ordenes[3]); //Restamos a los PS el daño
                            ActualizarBarraSalud2(PokemonLuchando2, barrasalud2);
                            TimerUltimaOrden = 0;
                            Orden1Done = true;
                            timer1.Start();             //Empezamos el timer para ejecutar la segunda orden
                        }
                    }
                    if ((TimerUltimaOrden > 0) && (!Orden2Done) && ((AtacaPrimero == Jugador1)))
                    {
                        if (ordenes[4] != "debilitado")     //Ejecutamos la segunda orden si no se ha debilitado
                        {
                            double eficacia = bt.CalcularDebilidad(PokemonLuchando2.moveSet.BuscarMovimiento(ordenes[6]).Tipo, PokemonLuchando1.Tipo1, PokemonLuchando1.Tipo2);
                            string add = " ";
                            if (eficacia == 0)
                                add = "No ha tenido ningún efecto";
                            else if (eficacia == 0.5)
                                add = "No es muy eficaz";
                            else if (eficacia == 1)
                                add = " ";
                            else if (eficacia == 2)
                                add = "Es muy eficaz!";
                            else if (eficacia == 4)
                                add = "Es super eficaz!";
                            Notif.Text = PokemonLuchando2.Nombre + " ha usado " + ordenes[6] + " " + add;
                            PokemonLuchando1.PSactuales -= Convert.ToInt32(ordenes[4]);
                            ActualizarBarraSalud1(PokemonLuchando1, barrasalud1);
                        }
                        Orden2Done = true;
                        timer1.Stop();
                        TimerUltimaOrden = 0;
                    }
                    if (AtacaPrimero == Jugador2)
                    {
                        if (!Orden2Done)
                        {
                            double eficacia = bt.CalcularDebilidad(PokemonLuchando2.moveSet.BuscarMovimiento(ordenes[6]).Tipo, PokemonLuchando1.Tipo1, PokemonLuchando1.Tipo2);
                            string add = " ";
                            if (eficacia == 0)
                                add = "No ha tenido ningún efecto";
                            else if (eficacia == 0.5)
                                add = "No es muy eficaz";
                            else if (eficacia == 1)
                                add = " ";
                            else if (eficacia == 2)
                                add = "Es muy eficaz!";
                            else if (eficacia == 4)
                                add = "Es super eficaz!";
                            Notif.Text = PokemonLuchando2.Nombre + " ha usado " + ordenes[6] + " " + add;
                            PokemonLuchando1.PSactuales -= Convert.ToInt32(ordenes[4]);
                            ActualizarBarraSalud1(PokemonLuchando1, barrasalud1);
                            TimerUltimaOrden = 0;
                            timer1.Start();
                            Orden2Done = true;
                        }
                    }
                    if ((TimerUltimaOrden > 0) && (!Orden1Done) && (AtacaPrimero == Jugador2))
                    {
                        if (ordenes[3] != "debilitado")
                        {
                            double eficacia = bt.CalcularDebilidad(PokemonLuchando1.moveSet.BuscarMovimiento(ordenes[5]).Tipo, PokemonLuchando2.Tipo1, PokemonLuchando2.Tipo2);
                            string add = " ";
                            if (eficacia == 0)
                                add = "No ha tenido ningún efecto";
                            else if (eficacia == 0.5)
                                add = "No es muy eficaz";
                            else if (eficacia == 1)
                                add = " ";
                            else if (eficacia == 2)
                                add = "Es muy eficaz!";
                            else if (eficacia == 4)
                                add = "Es super eficaz!";
                            Notif.Text = PokemonLuchando1.Nombre + " ha usado " + ordenes[5] + " " + add;
                            PokemonLuchando2.PSactuales -= Convert.ToInt32(ordenes[3]);
                            ActualizarBarraSalud2(PokemonLuchando2, barrasalud2);
                        }
                        Orden1Done = true;
                        timer1.Stop();
                        TimerUltimaOrden = 0;
                    }
                }
                if (!((ordenes[0] == "Ataque") && (ordenes[1] == "Ataque")) && !((ordenes[0] == "Cambio") && (ordenes[1] == "Cambio")))
                {       //Se ejecuta si uno de los dos cambia y el otro ataca
                    if (ordenes[7] == Jugador1)
                    {
                        if (ordenes[0] == "Cambio" && !Orden1Done)
                        {
                            ChangePokemon(Jugador1, Convert.ToInt32(ordenes[2]), Convert.ToInt32(ordenes[3]));
                            numPokemonLuchandoPlayer1 = Convert.ToInt32(ordenes[3]);
                            Orden1Done = true;              //Primero cambiamos al pokemon
                            TimerUltimaOrden = 0;
                            timer1.Start();
                        }
                    }

                    else if (ordenes[7] == Jugador2 && !Orden2Done)
                    {
                        ChangePokemon(Jugador2, Convert.ToInt32(ordenes[4]), Convert.ToInt32(ordenes[5]));
                        numPokemonLuchandoPlayer2 = Convert.ToInt32(ordenes[5]);
                        Orden2Done = true;
                        timer1.Start();
                        TimerUltimaOrden = 0;
                    }

                    if ((TimerUltimaOrden > 0) && !Orden2Done)
                    {
                        double eficacia = bt.CalcularDebilidad(PokemonLuchando2.moveSet.BuscarMovimiento(ordenes[6]).Tipo, PokemonLuchando1.Tipo1, PokemonLuchando1.Tipo2);
                        string add = " ";
                        if (eficacia == 0)
                            add = "No ha tenido ningún efecto";
                        else if (eficacia == 0.5)
                            add = "No es muy eficaz";
                        else if (eficacia == 1)             //Por ultimo hacemos el ataque
                            add = " ";
                        else if (eficacia == 2)
                            add = "Es muy eficaz!";
                        else if (eficacia == 4)
                            add = "Es super eficaz!";
                        Notif.Text = PokemonLuchando2.Nombre + " ha usado " + ordenes[6] + " " + add;
                        PokemonLuchando1.PSactuales -= Convert.ToInt32(ordenes[4]);
                        ActualizarBarraSalud1(PokemonLuchando1, barrasalud1);
                        TimerUltimaOrden = 0;
                        timer1.Stop();
                        Orden2Done = true;
                    }
                    if ((TimerUltimaOrden > 0) && !Orden1Done)
                    {
                        double eficacia = bt.CalcularDebilidad(PokemonLuchando1.moveSet.BuscarMovimiento(ordenes[6]).Tipo, PokemonLuchando2.Tipo1, PokemonLuchando2.Tipo2);
                        string add = " ";
                        if (eficacia == 0)
                            add = "No ha tenido ningún efecto";
                        else if (eficacia == 0.5)
                            add = "No es muy eficaz";
                        else if (eficacia == 1)
                            add = " ";
                        else if (eficacia == 2)
                            add = "Es muy eficaz!";
                        else if (eficacia == 4)
                            add = "Es super eficaz!";
                        Notif.Text = PokemonLuchando1.Nombre + " ha usado " + ordenes[6] + " " + add;
                        PokemonLuchando2.PSactuales -= Convert.ToInt32(ordenes[3]);
                        ActualizarBarraSalud2(PokemonLuchando2, barrasalud2);
                        TimerUltimaOrden = 0;
                        timer1.Stop();
                        Orden1Done = true;
                    }    
                }
            }
            if (Orden1Done && Orden2Done)
            {
                Procesado = false;          //Cuando los dos han hecho su orden, aumentamo en 1 el turno y reseteamos el Battle manager 
                bt.IncreaseTurno();             //para recibir ordenes otra vez
                bt.ResetOrders();
                bt.InicioTurno();
                Notif.Text = "Elige una accion";
                Orden1Done = false;
                Orden2Done = false;
                if (PokemonLuchando1.PSactuales <= 0)
                {
                    Notif.Text = "Tu Pokemon se ha debilitado, selecciona otro";//Si uno se debilita obliga a cambiar al otro
                    debilitado = true;
                    if (numPokemonLuchandoPlayer1 == 0)
                    {
                        pokeball1.Image = (Image)pokeballdebilitado;
                    }
                    if (numPokemonLuchandoPlayer1 == 1)
                    {
                        pokeball2.Image = (Image)pokeballdebilitado;
                    }
                    if (numPokemonLuchandoPlayer1 == 2)
                    {
                        pokeball3.Image = (Image)pokeballdebilitado;
                    }
                }
                if (PokemonLuchando2.PSactuales <= 0)
                {
                    if (numPokemonLuchandoPlayer2 == 0)
                    {
                        pokeball4.Image = (Image)pokeballdebilitado;
                    }
                    if (numPokemonLuchandoPlayer2 == 1)
                    {
                        pokeball5.Image = (Image)pokeballdebilitado;
                    }
                    if (numPokemonLuchandoPlayer2 == 2)
                    {
                        pokeball6.Image = (Image)pokeballdebilitado;
                    }
                }
                if (EquipoJugador1.PokemonsRestantes() == 0)
                {
                    Notif.Text = "Has perdido, finalizando partida";
                    Abandonar.Enabled = false;
                }
                if (EquipoJugador2.PokemonsRestantes() == 0)
                {
                    Notif.Text = "Has ganado, finalizando partida";
                    PartidaGanada = true;
                    Abandonar.Enabled = false;
                }
                label1.Text = Convert.ToString(bt.GetTurnos());     //El que gana envia los datos al servidor para guardar la partida
                if (PartidaGanada == true)
                {
                    string Ganador;
                    string Perdedor;
                    int PokemonsRestantes;
                    DateTime thisDay = DateTime.Today;
                    string date = thisDay.ToString("d");
                    string[] fecha = date.Split('/');
                    string dia = fecha[0];
                    string mes = fecha[1];
                    string año = fecha[2];
                    string date2 = dia + "." + mes + "." + año;
                    if (EquipoJugador1.PokemonsRestantes() == 0)
                    {
                        Ganador = Jugador2;
                        Perdedor = Jugador1;
                        PokemonsRestantes = EquipoJugador2.PokemonsRestantes();
                    }
                    else
                    {
                        Ganador = Jugador1;
                        Perdedor = Jugador2;
                        PokemonsRestantes = EquipoJugador1.PokemonsRestantes();
                    }
                    
                    string mensaje = "11/" + Convert.ToString(ID) + "," + Jugador1 + "," + "2" + "," + date2 + "," + Convert.ToString(bt.GetTurnos()) + "," + Ganador + "," + Perdedor + "," + Convert.ToString(PokemonsRestantes);
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    Server.Send(msg);
                    this.Close();
                    PartidaGanada = false;
                }
            }
        }

        private void Batalla_FormClosing(object sender, FormClosingEventArgs e)
        {
            Player1.Stop();
        }
    }
}
