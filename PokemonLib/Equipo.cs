using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonLib
{
    public class Equipo
    {
        public List<Pokemon> Pokemons = new List<Pokemon>();
        public int Pokemons_Iniciales = 0;
        public int Pokemons_Restantes = 0;

        public Equipo()
        {
        }

        public void AddPokemon(Pokemon pokemon)
        {
            this.Pokemons.Add(pokemon);
            Pokemons_Iniciales += 1;
            Pokemons_Restantes += 1;
        }

        public Pokemon GetPokemon(int num)
        {
            return this.Pokemons[num];
        }

        public int PokemonsRestantes()
        {
            this.Pokemons_Restantes = 0;
            foreach (Pokemon pokemon in this.Pokemons)
            {
                if (pokemon.PSactuales > 0)
                    this.Pokemons_Restantes = this.Pokemons_Restantes + 1;
            }
            return this.Pokemons_Restantes;
        }
        public void EliminarPokemon()
        {
            if (this.Pokemons_Iniciales == 0)
            {
                this.Pokemons_Iniciales = 0;
            }
            else
            {
                this.Pokemons.Remove(this.Pokemons[Pokemons_Iniciales - 1]);
                this.Pokemons_Iniciales -= 1;
            }
        }
        public void DeleteEquipo()
        {
            this.Pokemons.Clear();
            this.Pokemons_Restantes = 0;
            this.Pokemons_Iniciales = 0;
        }

        public void CopiarEquipo(Equipo Original)
        {
            Pokemon copia1 = new Pokemon();
            Pokemon copia2 = new Pokemon();
            Pokemon copia3 = new Pokemon();

            copia1.CopiarPokemon(Original.GetPokemon(0));
            copia2.CopiarPokemon(Original.GetPokemon(1));
            copia3.CopiarPokemon(Original.GetPokemon(2));

            this.AddPokemon(copia1);
            this.AddPokemon(copia2);
            this.AddPokemon(copia3);
        }
    }

  
}
