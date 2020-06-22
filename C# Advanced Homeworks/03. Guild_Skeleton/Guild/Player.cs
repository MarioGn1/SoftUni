using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    class Player
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; }
        public string Description { get; set; }

        public Player(string name, string Class)
        {
            this.Name = name;
            this.Class = Class;
            this.Rank = "Trial";
            this.Description = "n/a";
        }
        public override string ToString()
        {
            return $"Player {Name}: {Class}"
                + Environment.NewLine + $"Rank: {Rank}"
                + Environment.NewLine + $"Description: {Description}".TrimEnd();
        }
    }
}
