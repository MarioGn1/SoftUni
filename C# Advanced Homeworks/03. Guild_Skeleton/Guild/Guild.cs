using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    class Guild
    {
        private List<Player> players;

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => players.Count;

        public Guild(string name, int capacity)
        {
            this.players = new List<Player>();
            this.Name = name;
            this.Capacity = capacity;
        }

        public void AddPlayer(Player player)
        {
            if (players.Count < this.Capacity)
            {
                this.players.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            bool isRemoved = false;
            if (players.Any(el => el.Name == name))
            {
                isRemoved = true;
                this.players = players.Where(pl => pl.Name != name).ToList();
            }
            return isRemoved;
        }
        public void PromotePlayer(string name)
        {
            foreach (var item in this.players)
            {
                if (item.Name == name && item.Rank != "Member")
                {
                    item.Rank = "Member";
                    break;
                }
                else if (item.Rank == "Member")
                {
                    break;
                }
            }

        }
        public void DemotePlayer(string name)
        {
            foreach (var item in this.players)
            {
                if (item.Name == name && item.Rank != "Trial")
                {
                    item.Rank = "Trial";
                    break;
                }
                else if (item.Rank == "Trial")
                {
                    break;
                }
            }
        }
        public Player[] KickPlayersByClass(string Class)
        {
            Player[] removedPlayers = players.Where(el => el.Class == Class).ToArray();
            players = players.Where(el => el.Class != Class).ToList();

            return removedPlayers;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Players in the guild: {this.Name}" + Environment.NewLine);
            sb.Append(string.Join(Environment.NewLine, players));
            return sb.ToString().Trim();
        }
    }
}
