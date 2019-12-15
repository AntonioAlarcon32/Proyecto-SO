using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.Media;

namespace ProyectoSO2
{
    public partial class Inicio : Form
    {
        SoundPlayer pokemon = new SoundPlayer(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Music\\Inicio.wav");
        public Inicio()
        {
            InitializeComponent();

            pokemon.PlayLooping();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn li = new LogIn();
            li.Closed += (s, args) => this.Close();
            pokemon.Stop();
            li.Show();
        }
    }
}
