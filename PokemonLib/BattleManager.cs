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
        private bool PuedeAtacar = false;
        private bool MovimientosRecibidos = false;
        private int NumeroTurnos = 0;

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

        public bool OrdenesRecibidas()
        {
            return this.MovimientosRecibidos;
        }

        public void SetPlayers(string nombre1, string nombre2)
        {
            this.Jugador1 = nombre1;
            this.Jugador2 = nombre2;
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

        public int CalcularDaño(Pokemon PokemonAtacante, Pokemon PokemonDefensa, string Ataque)
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
            int Ran = 92;        //Valor aleatorio entre 85 y 100
            V = (double)Ran;

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
            return dmgfinal;
        }

        public void RecibirOrden(string mensaje)
        {
            if (this.Orden1 == null)
            {
                this.Orden1 = mensaje;
            }
            else
            {
                this.Orden2 = mensaje;
                this.MovimientosRecibidos = true;
            }
        }

        public string[] ProcesarOrdenes(Equipo Equipo1, Equipo Equipo2, Pokemon Poke1, Pokemon Poke2)
        {
            string[] Order1 = this.Orden1.Split(';');
            string[] Order2 = this.Orden2.Split(';');
            string[] salida = new string[8];
            int dmg1 = 0;
            int dmg2 = 0;
            Movimiento MovUsado1 = new Movimiento();
            Movimiento MovUsado2 = new Movimiento();
            bool debilitado = false;
            bool Jug1Ataca1 = false;
            bool Jug2Ataca1 = false;
            if (Order1[1] == "Cambiar")
            {
                if (Jugador1 == Order1[0])
                {
                    salida[0] = "Cambio";
                    salida[2] = Order1[2];
                    salida[3] = Order1[3];
                    Poke1 = Equipo1.GetPokemon(Convert.ToInt32(Order1[3]));
                }
                if (Jugador2 == Order1[0])
                {
                    salida[1] = "Cambio";
                    salida[4] = Order1[2];
                    salida[5] = Order1[3];
                    Poke2 = Equipo2.GetPokemon(Convert.ToInt32(Order1[3]));
                }
            }
            
            if (Order2[1] == "Cambiar")
            {
                if (Jugador1 == Order2[0])
                {
                    salida[0] = "Cambio";
                    salida[2] = Order2[2];
                    salida[3] = Order2[3];
                    Poke1 = Equipo1.GetPokemon(Convert.ToInt32(Order2[3]));
                }
                if (Jugador2 == Order2[0])
                {
                    salida[1] = "Cambio";
                    salida[4] = Order2[2];
                    salida[5] = Order2[3];
                    Poke2 = Equipo2.GetPokemon(Convert.ToInt32(Order2[3]));
                }
            }
            if (Order1[1] == "Atacar")
            {
                if (Jugador1 == Order1[0])
                {
                    MovUsado1 = Poke1.moveSet.BuscarMovimiento(Order1[2]);
                    if (MovUsado1.Categoria == "Estado")
                    {

                    }
                    else
                    {
                        dmg1 = this.CalcularDaño(Poke1, Poke2, MovUsado1.Nombre);
                        salida[0] = "Ataque";
                    }
                }
                if (Jugador2 == Order1[0])
                {
                    MovUsado2 = Poke2.moveSet.BuscarMovimiento(Order1[2]);
                    if (MovUsado2.Categoria == "Estado")
                    {

                    }
                    else
                    {
                        dmg2 = this.CalcularDaño(Poke2, Poke1, MovUsado2.Nombre);
                        salida[1] = "Ataque";
                    }
                }
            }
            if (Order2[1] == "Atacar")
            {
                if (Jugador1 == Order2[0])
                {
                    MovUsado1 = Poke1.moveSet.BuscarMovimiento(Order2[2]);
                    if (MovUsado1.Categoria == "Estado")
                    {

                    }
                    else
                    {
                        dmg1 = this.CalcularDaño(Poke1, Poke2, MovUsado1.Nombre);
                        salida[0] = "Ataque";
                    }
                }
                if (Jugador2 == Order2[0])
                {
                    MovUsado2 = Poke2.moveSet.BuscarMovimiento(Order2[2]);
                    if (MovUsado2.Categoria == "Estado")
                    {

                    }
                    else
                    {
                        dmg2 = this.CalcularDaño(Poke2, Poke1, MovUsado2.Nombre);
                        salida[1] = "Ataque";
                    }
                }

            }
            if ((salida[0] == "Ataque") && (salida[1] == "Ataque"))
            {
                if (MovUsado1.prioridad > MovUsado2.prioridad)
                {
                    salida[2] = Jugador1;
                    Jug1Ataca1 = true;
                    if ((Poke2.PSactuales - dmg1) <= 0)
                    {
                        debilitado = true;
                    }

                }
                else if (MovUsado2.prioridad > MovUsado1.prioridad)
                {
                    Jug2Ataca1 = true;
                    salida[2] = Jugador2;
                    if ((Poke1.PSactuales - dmg2) <= 0)
                    {
                        debilitado = true;
                    }
                }
                else
                {
                    if (Poke1.Velocidad >= Poke2.Velocidad)
                    {
                        Jug1Ataca1 = true;
                        salida[2] = Jugador1;
                        if ((Poke2.PSactuales - dmg1) <= 0)
                        {
                            debilitado = true;
                        }
                    }
                    if (Poke2.Velocidad > Poke1.Velocidad)
                    {
                        Jug2Ataca1 = true;
                        salida[2] = Jugador2;
                        if ((Poke1.PSactuales - dmg2) <= 0)
                        {
                            debilitado = true;
                        }
                    }
                }
                if (!Jug1Ataca1 && debilitado)
                {
                    salida[3] = "0";
                }
                else
                {
                    salida[3] = Convert.ToString(dmg1);
                    salida[5] = MovUsado1.Nombre;
                }
                if (!Jug2Ataca1 && debilitado)
                {
                    salida[4] = "0";
                }
                else
                {
                    salida[4] = Convert.ToString(dmg2);
                    salida[6] = MovUsado2.Nombre;
                }
            }
            return salida;
        }
        public void ResetOrders()
        {
            this.Orden1 = null;
            this.Orden2 = null;
            this.MovimientosRecibidos = false;
        }

        public void IncreaseTurno()
        {
            this.NumeroTurnos += 1;
        }
        public int GetTurnos()
        {
            return this.NumeroTurnos;
        }
    }
}
