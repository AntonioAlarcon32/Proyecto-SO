using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonLib
{
    public class Pokemon
    {
        public string Nombre;
        public string Tipo1;
        public string Tipo2;
        public int PS;
        public int PSactuales;
        public int Ataque;
        public int Defensa;
        public int Ataque_Especial;
        public int Defensa_Especial;
        public int Velocidad;
        public MoveSet moveSet = new MoveSet();


        public Pokemon()
        {
        }
        public Pokemon(string name, string Type1, string Type2, int HP, int Attack, int Defense, int EspAttack, int EspDef, int Speed)
        {
            this.Nombre = name;
            this.Tipo1 = Type1;
            this.Tipo2 = Type2;
            this.PS = HP;
            this.PSactuales = HP;
            this.Ataque = Attack;
            this.Defensa = Defense;
            this.Ataque_Especial = EspAttack;
            this.Defensa_Especial = EspDef;
            this.Velocidad = Speed;
        }

        public void AddMovimientos(Movimiento mov1, Movimiento mov2, Movimiento mov3, Movimiento mov4)
        {
            this.moveSet.AddMovimiento(mov1);
            this.moveSet.AddMovimiento(mov2);
            this.moveSet.AddMovimiento(mov3);
            this.moveSet.AddMovimiento(mov4);
        }
    }

}
