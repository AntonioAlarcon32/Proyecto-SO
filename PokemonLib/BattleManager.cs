using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonLib
{
    public class BattleManager
    {
        private string Jugador1;
        private string Jugador2;
        private string Orden1;
        private string Orden2;
        private string clima;
        private int OrdenesRecibidas = 0;
        private bool PuedeAtacar = false;

        private string[] Tipos = {"Normal","Fuego","Agua","Electrico","Planta","Hielo","Lucha","Veneno","Tierra",
                                "Volador","Psiquico","Bicho","Roca","Fantasma","Dragon","Siniestro","Acero"};

        double[,] debilidad = new double[17, 17] { {1,1,1,1,1,1,1,1,1,1,1,1,0.5,0,1,1,0.5},
                                                   {1,0.5,0.5,1,2,2,1,1,1,1,1,2,0.5,1,0.5,1,2},
                                                   {1,2,0.5,1,0.5,1,1,1,2,1,1,1,2,1,0.5,1,1},
                                                   {1,1,2,0.5,0.5,1,1,1,0,2,1,1,1,1,0.5,1,1},
                                                   {1,0.5,2,1,0.5,1,1,0.5,2,0.5,1,0.5,2,1,0.5,1,0.5},
                                                   {1,0.5,0.5,1,2,0.5,1,1,2,2,1,1,1,1,2,1,0.5},
                                                   {2,1,1,1,1,2,1,0.5,1,0.5,0.5,0.5,2,0,1,2,2},
                                                   {1,1,1,1,2,1,1,0.5,0.5,1,1,1,0.5,0.5,1,1,0},
                                                   {1,2,1,2,0.5,1,1,2,1,0,1,0.5,2,1,1,1,2},
                                                   {1,1,1,0.5,2,1,2,1,1,1,1,2,0.5,1,1,1,0.5},
                                                   {1,1,1,1,1,1,2,2,1,1,0.5,1,1,1,1,0,0.5},
                                                   {1,0.5,1,1,2,1,0.5,0.5,1,0.5,2,1,1,0.5,1,2,0.5},
                                                   {1,2,1,1,1,2,0.5,1,0.5,2,1,2,1,1,1,1,0.5},
                                                   {0,1,1,1,1,1,1,1,1,1,2,1,1,2,1,0.5,1},
                                                   {1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,0.5},
                                                   {1,1,1,1,1,1,0.5,1,1,1,2,1,1,2,1,0.5,1},
                                                   {1,0.5,0.5,0.5,1,2,1,1,1,1,1,1,2,1,1,1,0.5}
        };

        public BattleManager()
        {
        }

        public void InicioTurno()
        {
            this.PuedeAtacar = true;
        }
        public void FinTurno()
        {
            this.PuedeAtacar = false;
        }

        public bool GetAllowAttack()
        {
            return this.PuedeAtacar;
        }

        public double CalcularDebilidad(string TipoAtaque, string Tipo1, string Tipo2)
        {
            int AtacanteIndex = 1;
            int DefensaIndex = 1; 
            int Defensa2Index = 1;
            bool Atacante = false;
            bool Defensa = false;
            bool Defensa2 = false;

            if (Tipo2 == "-")
                Defensa2 = true;
            int i = 0;
            while ((!Atacante) || (!Defensa) || (!Defensa2))
            {
                if ((TipoAtaque == this.Tipos[i]) && (!Atacante))
                {
                    AtacanteIndex = i;
                    Atacante = true;
                }
                if ((Tipo1 == this.Tipos[i]) && (!Defensa))
                {
                    DefensaIndex = i;
                    Defensa = true;
                }
                if ((Tipo2 == this.Tipos[i]) && (!Defensa2))
                {
                    Defensa2Index = i;
                    Defensa2 = true;
                }
                i = i + 1;
            }
            double debilidad = this.debilidad[AtacanteIndex, DefensaIndex];
            if (Tipo2 != "-")
                debilidad = debilidad * this.debilidad[AtacanteIndex, Defensa2Index];

            return debilidad;
        }

        public void CalcularDaño(Pokemon PokemonAtacante, Pokemon PokemonDefensa, string Ataque)
        {
            bool encontrado = false;
            int i = 0;
            while (!encontrado)
            {
                if (Ataque == PokemonAtacante.moveSet.Movimientos[i].Nombre)
                {
                    encontrado = true;
                }
                i = i + 1;
            }
            PokemonAtacante.moveSet.Movimientos[i].PPAct -= 1; // Quitamos un PP al ataque que usa el pokemon

            double dmg, B, E, V, N, A = 0, P = 0, D = 0;
            Movimiento Attq = PokemonAtacante.moveSet.BuscarMovimiento(Ataque);
            string tipoAtaque = Attq.Tipo;
            string TipoDefensa1 = PokemonDefensa.Tipo1;
            string TipoDefensa2 = PokemonDefensa.Tipo2;
            string categoria = Attq.Categoria;

            if ((tipoAtaque == PokemonAtacante.Tipo1) || (tipoAtaque == PokemonAtacante.Tipo2))
                B = 1.5;
            else                    //Bonificacion si el pokemon es del mismo tipo que el ataque
                B = 1;

            E = CalcularDebilidad(tipoAtaque, TipoDefensa1, TipoDefensa2);  //Efectividad del ataque

            Random rnd = new Random();
            int Ran = rnd.Next(85, 100);        //Valor aleatorio entre 85 y 100
            V = (double) Ran;               
            
            N = 100;            //Nivel del pokemon, siempre 100
            if (categoria == "Fisico")
            {
                D = (double)PokemonDefensa.Defensa;
                A = (double)PokemonAtacante.Ataque;
            }
            if (categoria == "Especial")
            {
                D = (double)PokemonDefensa.Defensa_Especial;
                A = (double)PokemonAtacante.Ataque_Especial;
            }

            P = (double)Attq.Potencia;

            if ((this.clima == "Sol" && tipoAtaque == "Fuego") || (this.clima == "Lluvia" && tipoAtaque == "Agua"))
                P = P * 1.5;
            if ((this.clima == "Sol" && tipoAtaque == "Agua") || (this.clima == "Lluvia" && tipoAtaque == "Fuego"))
                P = P * 1.5;

            dmg = 0.01 * B * E * V * ((((0.2 * N + 1) * A * P) / (25 * D)) + 2); // Formula del daño
            int dmgfinal = (int)dmg;
            PokemonDefensa.PSactuales -= dmgfinal;
        }
    }
}
