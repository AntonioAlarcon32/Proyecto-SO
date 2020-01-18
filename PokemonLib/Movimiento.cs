using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonLib
{
    public class Movimiento
    {
        public string Nombre;
        public string Categoria;
        public int PPMax;
        public int PPAct;
        public string Tipo;
        public int prioridad;
        public int Potencia;
        public string Alcance;
        public string Descripcion;
        //public string CambiarEstado;
        //public string Probabilidad;
        //public string Precision;

        public Movimiento()
        {
            
        }

        public Movimiento(string nombre,string Categoria, int PP, string tipo, int prioridad, int potencia, string alcance, string descripcion)
        {
            this.Nombre = nombre;
            this.Categoria = Categoria;
            this.PPMax = PP;
            this.PPAct = PP;
            this.Tipo = tipo;
            this.prioridad = prioridad;
            this.Potencia = potencia;
            this.Alcance = alcance;
            this.Descripcion = descripcion;

        }

        public void CambiarNombre(string nombre)
        {
            this.Nombre = nombre;
        }

        public void CopiarMov(Movimiento MovOriginal)
        {
            this.Nombre = MovOriginal.Nombre;
            this.Categoria = MovOriginal.Categoria;
            this.PPMax = MovOriginal.PPMax;
            this.PPAct = MovOriginal.PPAct;
            this.Tipo = MovOriginal.Tipo;
            this.prioridad = MovOriginal.prioridad;
            this.Potencia = MovOriginal.Potencia;
            this.Alcance = MovOriginal.Alcance;
            this.Descripcion = MovOriginal.Descripcion;
        }

        public void RestarPP()
        {
            this.PPAct = this.PPAct - 1;
        }

    }
}
