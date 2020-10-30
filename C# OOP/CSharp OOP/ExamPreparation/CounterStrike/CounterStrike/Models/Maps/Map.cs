using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            ICollection<IPlayer>  terrorists = players.Where(el => el.GetType().Name == "Terrorist").ToList();
            ICollection<IPlayer>  counterTerrorists = players.Where(el => el.GetType().Name == "CounterTerrorist").ToList();

            while ((terrorists.Sum(el => el.Health) != 0) && (counterTerrorists.Sum(el => el.Health) != 0))
            {
                foreach (var terrorist in terrorists)
                {
                    foreach (var counterTerrorist in counterTerrorists)
                    {
                        int dmg = terrorist.Gun.Fire();
                        counterTerrorist.TakeDamage(dmg);
                    }
                }
                foreach (var counterTerrorist in counterTerrorists)
                {
                    foreach (var terrorist in terrorists)
                    {
                        int dmg = counterTerrorist.Gun.Fire();
                        terrorist.TakeDamage(dmg);
                    }
                }
            }

            if ((terrorists.Sum(el => el.Health) == 0))
            {
                return "Counter Terrorist wins!";
            }
            return "Terrorist wins!";
        }
    }
}
