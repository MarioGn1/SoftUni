using Raiding.Factories;
using Raiding.IO;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private ICollection<IBaseHero> heroes;
        private IReader reader;
        private IWriter writer;
        private IHeroCreator heroCreator;
        private int totalHeroPower;

        public Engine(IReader reader, IWriter writer, IHeroCreator heroCreator)
        {
            this.reader = reader;
            this.writer = writer;
            this.heroCreator = heroCreator;
            this.heroes = new List<IBaseHero>();
        }

        public void Run()
        {
            int n = int.Parse(this.reader.ReadLine());
            

            while (heroes.Count < n)
            {
                string name = this.reader.ReadLine();
                string type = this.reader.ReadLine();

                try
                {
                    IBaseHero curHero = heroCreator.CreateHero(name, type);
                    this.heroes.Add(curHero);
                }
                catch (ArgumentException e)
                {
                    this.writer.WriteLine(e.Message);
                }                
            }

            int bossPower = int.Parse(this.reader.ReadLine());

            foreach (IBaseHero hero in heroes)
            {
                this.totalHeroPower += hero.Power;
                this.writer.WriteLine(hero.CastAbility());
            }

            if (bossPower > this.totalHeroPower)
            {
                this.writer.WriteLine("Defeat...");
            }
            else 
            {
                this.writer.WriteLine("Victory!");
            }
        }
    }
}
