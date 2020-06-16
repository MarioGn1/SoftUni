using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainers> trainers = new Dictionary<string, Trainers>();

            string command;
            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] curCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = curCommand[0];
                string pokemonName = curCommand[1];
                string pokemonElement = curCommand[2];
                string pokemonHealth = curCommand[3];

                Pokemon curPokemon = new Pokemon(pokemonName, pokemonElement, int.Parse(pokemonHealth));
                Trainers curTrainer = new Trainers(trainerName, curPokemon);

                if (!trainers.ContainsKey(trainerName))
                {                     
                    trainers[trainerName] = curTrainer;
                }
                else
                {
                    trainers[trainerName].PokemonsColection.Add(curPokemon);
                }
            }

            string secondCommand;
             while ((secondCommand = Console.ReadLine()) != "End")
            {
                foreach (var item in trainers)
                {
                    bool noPokemonElementFound = true;
                    foreach (var pokemon in item.Value.PokemonsColection)
                    {
                        if (pokemon.Element == secondCommand)
                        {
                            item.Value.Badges++;
                            noPokemonElementFound = false;
                            break;
                        }
                    }
                    if (noPokemonElementFound)
                    {
                        foreach (var pokemon in item.Value.PokemonsColection)
                        {
                            pokemon.Health -= 10;                           
                        }
                    }
                    item.Value.PokemonsColection = item.Value.RemoveDeathPokemons(item.Value.PokemonsColection);
                }
            }

            trainers = trainers.OrderByDescending(trainer => trainer.Value.Badges).ToDictionary(x => x.Key, y => y.Value);            

            foreach (var trainer in trainers)
            {
                Console.WriteLine($"{trainer.Value.Name} {trainer.Value.Badges} {trainer.Value.PokemonsColection.Count}");
            }

        }
    }
}
