using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;           

            ListyIterator<string> myIterator = new ListyIterator<string>();

            while ((command = Console.ReadLine()) != "END")
            {
                List <string> curCommand = command.Split().ToList();

                switch (curCommand[0])
                {
                    case "Create":
                        curCommand.RemoveAt(0);
                        myIterator.Create(curCommand.ToArray());
                        break;
                    case "Move":
                        Console.WriteLine(myIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(myIterator.HasNext()); 
                        break;
                    case "Print":
                        try
                        {
                            myIterator.Print();
                        }
                        catch (InvalidOperationException e)
                        {

                            Console.WriteLine(e.Message);
                        }
                        
                        break;   
                    case "PrintAll":
                        foreach (var item in myIterator)
                        {
                            Console.Write($"{item} ");
                        }
                        Console.WriteLine();
                        break;                    
                }
            }
        }
    }
}
