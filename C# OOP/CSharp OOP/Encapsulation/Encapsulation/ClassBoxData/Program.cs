using System;

namespace ClassBoxData
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

           

            try
            {
                Box myBox = new Box(length, width, height);
                Console.WriteLine(myBox.SurfaceArea());
                Console.WriteLine(myBox.LateralSurface());
                Console.WriteLine(myBox.Volume());
            }
            catch (ArgumentException e)
            {

                Console.WriteLine(e.Message);
            }
            
        }
    }
}
