using System;
using System.Linq;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> myStack = new Stack<int>();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] separators = new string[2] { ", ", " " };
                string[] curCommand = command.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                switch (curCommand[0])
                {
                    case "Push":                         
                        foreach (var item in curCommand.Skip(1))
                        {
                            myStack.Push(int.Parse(item));
                        }
                        break;
                    case "Pop":
                        try 
                        {
                            myStack.Pop();
                        }
                        catch (InvalidOperationException e)
                        {

                            Console.WriteLine(e.Message);
                        }
                        break;
                    default:
                        break;
                }
            }
            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }  
            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
