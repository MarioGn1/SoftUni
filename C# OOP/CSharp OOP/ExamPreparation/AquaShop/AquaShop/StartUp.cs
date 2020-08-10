namespace AquaShop
{
    using System;

    using AquaShop.Core;
    using AquaShop.Core.Contracts;
    using AquaShop.Models.Aquariums;
    using AquaShop.Models.Decorations;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish;
    using AquaShop.Models.Fish.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            //Don't forget to comment out the commented code lines in the Engine class!
            IEngine engine = new Engine();
            engine.Run();

            
        }
    }
}
