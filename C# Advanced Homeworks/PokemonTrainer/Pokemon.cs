﻿using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace PokemonTrainer
{
    class Pokemon
    {
        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }

        public Pokemon(string name, string element, int health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }
    }
}
