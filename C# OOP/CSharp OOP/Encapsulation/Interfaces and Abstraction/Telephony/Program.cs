using System;

namespace Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] sites = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);

            var smartphone = new Smartphone();
            var statinaryPhone = new StationaryPhone();

            foreach (var item in numbers)
            {
                try
                {
                    if (item.Length == 10)
                    {
                        smartphone.Call(item);
                    }
                    else
                    {
                        statinaryPhone.Call(item);
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message); ;
                }
            }

            foreach (var item in sites)
            {
                try
                {
                    smartphone.Browse(item);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
