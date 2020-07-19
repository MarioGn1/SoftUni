using Raiding.Core;
using Raiding.Factories;
using Raiding.IO;
using System;

namespace Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();
            IHeroCreator heroCreator = new HeroCreator();

            IEngine engine = new Engine(reader, writer, heroCreator);
            engine.Run();

        }
    }
}
