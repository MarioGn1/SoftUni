using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CounterStrike.Models.Players;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IGun> guns;
        private readonly IRepository<IPlayer> players;
        private readonly IMap map;

        public Controller()
        {
            guns = new GunRepository();
            players = new PlayerRepository();
            map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            //Valid types are: "Pistol" and "Rifle".  
            IGun gun = null;

            if (type != "Pistol" && type != "Rifle")
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            if (type == "Pistol")
            {
                gun = new Pistol(name, bulletsCount);                
            }
            else
            {
                gun = new Rifle(name, bulletsCount);                
            }

            this.guns.Add(gun);
            return string.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            //Valid types are: "Terrorist" and "CounterTerrorist"
            IPlayer player = null;
            
            if (this.guns.FindByName(gunName) == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            if (type != "Terrorist" && type != "CounterTerrorist")
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            if (type == "Terrorist")
            {
                player = new Terrorist(username, health, armor, this.guns.FindByName(gunName));
            }
            else
            {
                player = new CounterTerrorist(username, health, armor, this.guns.FindByName(gunName));
            }

            this.players.Add(player);
            return string.Format(OutputMessages.SuccessfullyAddedPlayer, username);
        }

        public string Report()
        {
            var sortedPlayers = players.Models.OrderBy(el => el.GetType().Name).ThenByDescending(el => el.Health).ThenBy(el => el.Username);
            StringBuilder sb = new StringBuilder();
            foreach (var item in sortedPlayers)
            {
                sb.Append(item + Environment.NewLine);
            }
            return sb.ToString().Trim();
        }

        public string StartGame()
        {                       
           return this.map.Start(players.Models.Where(el => el.IsAlive == true).ToList());
        }
    }
}
