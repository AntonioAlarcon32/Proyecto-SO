using System;
using System.IO;
using System.Windows.Forms;
using System.Media;
using PokemonBattle;

using System.Drawing;

namespace ProyectoSO2
{
    public partial class Inicio : Form
    {
        SoundPlayer pokemon = new SoundPlayer(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Music\\Inicio.wav");
        string directorio = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        Icon pokeball = new Icon(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\UI\\icono.ico");
        
        public Inicio()
        {
            InitializeComponent();
            pokemon.PlayLooping();
            this.Icon = pokeball;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn li = new LogIn();
            li.Closed += (s, args) => this.Close();
            pokemon.Stop();
            li.Show();
        }

        private void credits_Click(object sender, EventArgs e)
        {
            Creditos cr = new Creditos();
            cr.Show();
        }
    }
}
