using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputStringOne = Console.ReadLine().Split();
            string name = inputStringOne[0] + " " + inputStringOne[1];
            string street = inputStringOne[2];
            List<string> town = new List<string>();
            for (int i = 3; i < inputStringOne.Length; i++)
            {
                town.Add(inputStringOne[i]);
            }
            MyThreeuple<string, string, string> myThreeupleStrings = new MyThreeuple<string, string, string>(name, street, string.Join(" ", town));
            Console.WriteLine(myThreeupleStrings);

            string[] inputStringTwo = Console.ReadLine().Split();
            string nameTwo = inputStringTwo[0];
            double beerLiters = int.Parse(inputStringTwo[1]);
            bool action = false;
            if (inputStringTwo[2] == "drunk")
            {
                action = true;
            }
            else if (inputStringTwo[2] == "not")
            {
                action = false;
            }             

            MyThreeuple<string, double, bool> myThreeupleStringsTwo = new MyThreeuple<string, double, bool>(nameTwo, beerLiters, action);
            Console.WriteLine(myThreeupleStringsTwo);

            string[] inputStringThree = Console.ReadLine().Split();
            string nameThree = inputStringThree[0];
            double amount = double.Parse(inputStringThree[1]);
            string bankName = inputStringThree[2];

            MyThreeuple<string, double, string> myThreeupleStringsThree = new MyThreeuple<string, double, string>(nameThree, amount, bankName);
            Console.WriteLine(myThreeupleStringsThree);
        }
    }
}
