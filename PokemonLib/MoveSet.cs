using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonLib
{
    public class MoveSet
    {
        public List<Movimiento> Movimientos = new List<Movimiento>();
        public int num;

        public MoveSet()
        {

        }


        public void AddMovimiento(Movimiento mov)
        {
            this.Movimientos.Add(mov);
            this.num = num + 1;
        }

        public Movimiento BuscarMovimiento(string nombre)
        {
            bool encontrado = false;
            int i = 0;
            while ((encontrado == false) && (i < this.num))
            {
                if (this.Movimientos[i].Nombre == nombre)
                {
                    encontrado = true;
                }
                else
                    i = i + 1;
            }
            return this.Movimientos[i];
        }
    }
}
