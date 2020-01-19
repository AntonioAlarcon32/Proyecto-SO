using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using PokemonLib;
using WMPLib;
using System.Net.Sockets;

namespace ProyectoSO2
{
    public partial class TeamBuilder : Form
    {
        StreamReader r = null;
        StreamReader r2 = null;
        public int PokemonsSeleccionados;
        Equipo Disponibles = new Equipo();
        Equipo EquipoBatalla = new Equipo();
        MoveSet MovDisponibles = new MoveSet();
        string directorio = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        Socket Server;
        Icon iconopokeball = new Icon(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\UI\\icono.ico");


        public TeamBuilder(Socket Server)
        {
            this.Icon = iconopokeball;
            this.Server = Server;
            r = new StreamReader(directorio+ "\\Pokemons.txt");
            r2 = new StreamReader(directorio + "\\Movements.txt");
            string linea;
            string[] Partes;
            while(true)
            {
                linea = r2.ReadLine();
                Partes = linea.Split('/');
                if (Partes[0] == "-")
                {
                    break;
                }
                else
                {
                    string nombre = Partes[0];
                    string categoria = Partes[1];
                    int PP = Convert.ToInt32(Partes[2]);
                    string Tipo = Partes[3];
                    int prioridad = Convert.ToInt32(Partes[4]);
                    int potencia = Convert.ToInt32(Partes[5]);
                    string alcance = Partes[6];
                    string descripcion = Partes[7];
                    Movimiento Mov = new Movimiento(nombre, categoria, PP, Tipo, prioridad, potencia, alcance, descripcion);
                    MovDisponibles.AddMovimiento(Mov);
                }
            }
            while (true) 
            {
                linea = r.ReadLine();
                Partes = linea.Split('/');
                if (Partes[0] == "-")
                {
                    break;
                }
                else
                {
                    string name = Partes[0];
                    string Tipo1 = Partes[7];
                    string Tipo2 = Partes[8];
                    int PS = Convert.ToInt32(Partes[1]);
                    int Ataque = Convert.ToInt32(Partes[2]);
                    int Defensa = Convert.ToInt32(Partes[3]);
                    int AtEsp = Convert.ToInt32(Partes[4]);
                    int DefEsp = Convert.ToInt32(Partes[5]);
                    int Vel = Convert.ToInt32(Partes[6]);
                    string Mov1 = Partes[9];
                    string Mov2 = Partes[10];
                    string Mov3 = Partes[11];
                    string Mov4 = Partes[12];
                    Movimiento mov1 = MovDisponibles.BuscarMovimiento(Mov1); 
                    Movimiento mov2 = MovDisponibles.BuscarMovimiento(Mov2);
                    Movimiento mov3 = MovDisponibles.BuscarMovimiento(Mov3);
                    Movimiento mov4 = MovDisponibles.BuscarMovimiento(Mov4);


                    Pokemon pok = new Pokemon(name, Tipo1, Tipo2, PS, Ataque, Defensa, AtEsp, DefEsp, Vel);
                    pok.AddMovimientos(mov1, mov2, mov3, mov4);
                    Disponibles.AddPokemon(pok);
                }
            }
            
            InitializeComponent();
            PokemonsDisponibles.ColumnCount = 1;
            PokemonsDisponibles.RowCount = Disponibles.Pokemons_Iniciales;
            int i = 0;
            foreach (Pokemon pokemon in Disponibles.Pokemons)
            {
                PokemonsDisponibles[0, i].Value = pokemon.Nombre;
                i = i + 1;
            }
        }

        private void PokemonsDisponibles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Bitmap image = new Bitmap(directorio + "\\Sprites\\" + PokemonsDisponibles.CurrentCell.Value + ".gif");                               
            PokemonSeleccionado.Image = (Image)image;
            PokemonSeleccionado.BackColor = Color.Transparent;
            Bitmap tipo1 = new Bitmap(directorio +"\\Tipos\\" + Disponibles.Pokemons[PokemonsDisponibles.CurrentCell.RowIndex].Tipo1 + ".gif");
            Tipo1.Image = (Image)tipo1;
            Tipo1.BackColor = Color.Transparent;
            string SegundoTipo = Disponibles.Pokemons[PokemonsDisponibles.CurrentCell.RowIndex].Tipo2;
            if (SegundoTipo != "-")
            {
                Bitmap tipo2 = new Bitmap(directorio + "\\Tipos\\" + SegundoTipo + ".gif");
                Tipo2.Image = (Image)tipo2;
                Tipo2.BackColor = Color.Transparent;
                Tipo2.Visible = true;
            }
            else
                Tipo2.Visible = false;

            Stats.RowCount = 6;
            Stats[0, 0].Value = "PS";
            Stats[0, 1].Value = "Ataque";
            Stats[0, 2].Value = "Defensa";
            Stats[0, 3].Value = "At. Especial";
            Stats[0, 4].Value = "Def. Especial";
            Stats[0, 5].Value = "Velocidad";
            Stats[1, 0].Value = Disponibles.Pokemons[PokemonsDisponibles.CurrentCell.RowIndex].PS;
            Stats[1, 1].Value = Disponibles.Pokemons[PokemonsDisponibles.CurrentCell.RowIndex].Ataque;
            Stats[1, 2].Value = Disponibles.Pokemons[PokemonsDisponibles.CurrentCell.RowIndex].Defensa;
            Stats[1, 3].Value = Disponibles.Pokemons[PokemonsDisponibles.CurrentCell.RowIndex].Ataque_Especial;
            Stats[1, 4].Value = Disponibles.Pokemons[PokemonsDisponibles.CurrentCell.RowIndex].Defensa_Especial;
            Stats[1, 5].Value = Disponibles.Pokemons[PokemonsDisponibles.CurrentCell.RowIndex].Velocidad;
            Mov1.Text = Disponibles.Pokemons[PokemonsDisponibles.CurrentCell.RowIndex].moveSet.Movimientos[0].Nombre;
            Mov2.Text = Disponibles.Pokemons[PokemonsDisponibles.CurrentCell.RowIndex].moveSet.Movimientos[1].Nombre;
            Mov3.Text = Disponibles.Pokemons[PokemonsDisponibles.CurrentCell.RowIndex].moveSet.Movimientos[2].Nombre;
            Mov4.Text = Disponibles.Pokemons[PokemonsDisponibles.CurrentCell.RowIndex].moveSet.Movimientos[3].Nombre;
            WindowsMediaPlayer pokemon = new WindowsMediaPlayer();
            pokemon.URL = directorio + "\\Sounds\\" + PokemonsDisponibles.CurrentCell.Value + ".wav";
            pokemon.controls.play();
        }

        private void Añadir_Click(object sender, EventArgs e)
        {
            int numPokes = EquipoBatalla.Pokemons_Iniciales;
            if (numPokes == 0)
            {
                label1.Text = Convert.ToString(PokemonsDisponibles.CurrentCell.Value);
                Bitmap image = new Bitmap(directorio + "\\SmallSprites\\" + PokemonsDisponibles.CurrentCell.Value + ".png"); 
                Pokemon1.Image = (Image)image;
                Pokemon1.BackColor = Color.Transparent;
                EquipoBatalla.AddPokemon(Disponibles.GetPokemon(PokemonsDisponibles.CurrentCell.RowIndex));
            }
            else if (numPokes == 1)
            {
                label2.Text = Convert.ToString(PokemonsDisponibles.CurrentCell.Value);
                Bitmap image = new Bitmap(directorio + "\\SmallSprites\\" + PokemonsDisponibles.CurrentCell.Value + ".png");
                Pokemon2.Image = (Image)image;
                Pokemon2.BackColor = Color.Transparent;
                EquipoBatalla.AddPokemon(Disponibles.GetPokemon(PokemonsDisponibles.CurrentCell.RowIndex));
            }
            else if (numPokes == 2)
            {
                label3.Text = Convert.ToString(PokemonsDisponibles.CurrentCell.Value);
                Bitmap image = new Bitmap(directorio + "\\SmallSprites\\" + PokemonsDisponibles.CurrentCell.Value + ".png");
                Pokemon3.Image = (Image)image;
                Pokemon3.BackColor = Color.Transparent;
                EquipoBatalla.AddPokemon(Disponibles.GetPokemon(PokemonsDisponibles.CurrentCell.RowIndex));
            }
            else
            {
                MessageBox.Show("Ya tienes 3 Pokemons");
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            int numPokes = EquipoBatalla.Pokemons_Iniciales;
            if (numPokes == 0)
            {
                MessageBox.Show("No Hay Pokemons en el equipo");
            }
            else if (numPokes == 1)
            {
                label1.Text = "";
                Bitmap image = new Bitmap(directorio + "\\SmallSprites\\" + "questionmark.png");
                Pokemon1.Image = (Image)image;
                Pokemon1.BackColor = Color.Transparent;
                Pokemon1.SizeMode = PictureBoxSizeMode.StretchImage;
                EquipoBatalla.EliminarPokemon();
            }
            else if (numPokes == 2)
            {
                label2.Text = "";
                Bitmap image = new Bitmap(directorio + "\\SmallSprites\\" + "questionmark.png");
                Pokemon2.Image = (Image)image;
                Pokemon2.BackColor = Color.Transparent;
                Pokemon2.SizeMode = PictureBoxSizeMode.StretchImage;
                EquipoBatalla.EliminarPokemon();
            }
            else if (numPokes == 3)
            {
                label3.Text = "";
                Bitmap image = new Bitmap(directorio + "\\SmallSprites\\" + "questionmark.png");
                Pokemon3.Image = (Image)image;
                Pokemon3.BackColor = Color.Transparent;
                Pokemon3.SizeMode = PictureBoxSizeMode.StretchImage;
                EquipoBatalla.EliminarPokemon();
            }

        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (EquipoBatalla.Pokemons_Iniciales == 3)
            {
                string mensaje = "12/" + EquipoBatalla.GetPokemon(0).Nombre + "," + EquipoBatalla.GetPokemon(1).Nombre + "," + EquipoBatalla.GetPokemon(2).Nombre;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                Server.Send(msg);
                this.Close();
            }
            else
                MessageBox.Show("No hay 3 Pokemons en el equipo");
            
        }
    }
}
