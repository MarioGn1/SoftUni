using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    class Trainers
    {
        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> PokemonsColection 
        { get; set; }


        public Trainers(string name,Pokemon pokemon)
        {
            this.Name = name;
            this.PokemonsColection = new List<Pokemon>();
            PokemonsColection.Add(pokemon);
            this.Badges = 0;
        }

        public List<Pokemon> RemoveDeathPokemons(List<Pokemon> pokemons)
        {
            for (int i = 0; i < pokemons.Count; i++)
            {
                if (pokemons[i].Health <= 0)
                {
                    pokemons.RemoveAt(i);
                    i--;
                }
            }
            return pokemons;
        }
    }
}
