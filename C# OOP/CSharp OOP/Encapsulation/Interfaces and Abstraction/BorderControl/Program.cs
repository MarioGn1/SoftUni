using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBuyer> inhabitants = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());

            IBuyer inhabitant = null;
            for (int i = 0; i < n; i++)
            {
                string[] curInhabitant = Console.ReadLine().Split();
                if (curInhabitant.Length == 4)
                {
                    inhabitant = new Citizens(curInhabitant[0],
                        int.Parse(curInhabitant[1]),
                        curInhabitant[2],
                        curInhabitant[3]);                    
                }
                else
                {
                    inhabitant = new Rebel(curInhabitant[0],
                        int.Parse(curInhabitant[1]),
                        curInhabitant[2]);
                }
                inhabitants.Add(inhabitant);
            }
            int totalFood = 0;
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                inhabitant = inhabitants.FirstOrDefault(el => el.Name == command);
                if (inhabitant != null)
                {
                    IBuyer curPerson = (IBuyer)inhabitant;
                    curPerson.BuyFood(); 
                }
            }

            foreach (var item in inhabitants)
            {
                totalFood += item.Food;
            }
            Console.WriteLine(totalFood);

            //Task on 5.	Birthday Celebrations
            //string command;
            //while ((command = Console.ReadLine()) != "End")
            //{

            //    string[] curInhabitant = command.Split();
            //    IInhabitable inhabitant = null;
            //    if (curInhabitant[0] == "Citizen")
            //    {
            //        inhabitant = new Citizens(curInhabitant[1],
            //            int.Parse(curInhabitant[2]),
            //            curInhabitant[3],
            //            curInhabitant[4]);

            //    }
            //    else if (curInhabitant[0] == "Robot")
            //    {
            //        inhabitant = new Robot(curInhabitant[1],
            //            (curInhabitant[2]));

            //    }
            //    else if(curInhabitant[0] == "Pet")
            //    {
            //        inhabitant = new Pet(curInhabitant[1],
            //            (curInhabitant[2]));

            //    }

            //    inhabitants.Add(inhabitant);

            //}

            //string criteria = Console.ReadLine();

            //inhabitants.Where(el => el.Birthday != null)
            //    .ToList()
            //    .Where(el => el.Birthday.EndsWith(criteria))
            //    .ToList()
            //    .ForEach(el => Console.WriteLine(el.Birthday));

        }
    }
}
