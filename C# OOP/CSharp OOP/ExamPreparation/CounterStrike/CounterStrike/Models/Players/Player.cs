using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private IGun gun;
        private int armor;
        private int health;
        private string username;

        protected Player(string username, int health, int armor, IGun gun)
        {
            Username = username;
            Health = health;
            Armor = armor;
            Gun = gun;
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }
                this.username = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }
                this.health = value;
            }
        }

        public int Armor
        {
            get
            {
                return this.armor;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }
                this.armor = value;
            }
        }

        public IGun Gun
        {
            get
            {
                return this.gun;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }
                this.gun = value;
            }
        }

        public bool IsAlive => this.health > 0;

        public void TakeDamage(int points)
        {
            if (this.armor >= points)
            {
                this.armor -= points;
            }
            else
            {
                points -= armor;
                armor = 0;
                if (this.health > points)
                {
                    this.health -= points;
                }
                else
                {
                    health = 0;
                }
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {this.username}");
            sb.AppendLine($"--Health: {this.health}");
            sb.AppendLine($"--Armor: {this.armor}");
            sb.AppendLine($"--Gun: {this.gun.Name}");

            return sb.ToString().Trim();
        }
    }
}
