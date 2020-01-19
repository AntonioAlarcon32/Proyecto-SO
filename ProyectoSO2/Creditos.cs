using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonBattle
{
    public partial class Creditos : Form
    {
        Icon pokeball = new Icon(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\UI\\icono.ico");
        public Creditos()
        {
            InitializeComponent();
            linkLabel1.Links.Add(0,linkLabel1.Text.Length,"https://eetac.upc.edu/ca");
            this.Icon = pokeball;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://eetac.upc.edu/ca");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.pokestadium.com/tools/sprites");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.spriters-resource.com/");
        }
    }
}
