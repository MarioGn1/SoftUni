using System;
using System.Linq;

namespace Applied_aritmetics
{
    class Program
    {
        public delegate int [] Arithmetics(int [] x);

        static void Main(string[] args)
        {
            Arithmetics add =  x => x.Select(element => element+1).ToArray();
            Arithmetics mult =  x => x.Select(element => element*2).ToArray();
            Arithmetics subtr =  x => x.Select(element => element-1).ToArray();

            int[] inputNums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        inputNums = add(inputNums);
                        break;
                    case "multiply":
                        inputNums = mult(inputNums);
                        break;
                    case "subtract":
                        inputNums = subtr(inputNums);
                        break;
                    case "print":
                        Console.WriteLine(string.Join(' ', inputNums));
                        break;
                    default:
                        throw new ArgumentException("Invalid action!");
                }
            }
        }

        
    }
}
