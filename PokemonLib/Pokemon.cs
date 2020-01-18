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
    
        public void CopiarPokemon(Pokemon PokemonOriginal)
        {
            this.Nombre = PokemonOriginal.Nombre;
            this.Tipo1 = PokemonOriginal.Tipo1;
            this.Tipo2 = PokemonOriginal.Tipo2; 
            this.PS = PokemonOriginal.PS;
            this.PSactuales = PokemonOriginal.PSactuales;
            this.Ataque = PokemonOriginal.Ataque;
            this.Defensa = PokemonOriginal.Defensa;
            this.Ataque_Especial = PokemonOriginal.Ataque_Especial;
            this.Defensa_Especial = PokemonOriginal.Defensa_Especial;
            this.Velocidad = PokemonOriginal.Velocidad;
            this.moveSet.CopiarMoveset(PokemonOriginal.moveSet);
        }

        public void RestarPS(int dmg)
        {
            this.PSactuales = this.PSactuales - dmg;
        }
    }

}
