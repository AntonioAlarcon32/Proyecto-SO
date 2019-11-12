using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSO2
{
    public partial class ListaConectados : Form
    {
        string Conectados;
        public void GetStringConectados(string c)
        {
            Conectados = c;                                                 
        }
        public ListaConectados()
        {
            
            InitializeComponent();
        }

        private void ListaConectados_Load(object sender, EventArgs e)
        {
            string[] str = Conectados.Split('/');
            int i = Convert.ToInt32(str[0]);
            string usuarios = str[1];
            string[] Users = usuarios.Split(',');
            dataGridView1.ColumnCount = 2;
            dataGridView1.RowCount = Users.Length;
            i = 0;
            foreach (string User in Users)
            {
                dataGridView1[0, i].Value = i + 1;
                dataGridView1[1, i].Value = Users[i];
                i = i + 1;
            }
        }
    }
}
