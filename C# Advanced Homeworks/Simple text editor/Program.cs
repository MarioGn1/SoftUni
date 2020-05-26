using System;
using System.Collections.Generic;

namespace Simple_text_editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> lastChange = new Stack<string>();
            string text = "";

            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();
                string operand = "";
                if (command.Length > 1)
                {
                    operand = command.Remove(0, 2);
                }


                switch (command[0])
                {
                    case '1':
                        text = text + operand;
                        lastChange.Push(text);                        
                        break;
                    case '2':
                        int remlenght = int.Parse(operand);                                             
                        text = text.Remove(text.Length - remlenght, remlenght);
                        lastChange.Push(text);
                        break;
                    case '3':
                        int index = int.Parse(operand) - 1;
                        Console.WriteLine(text[index]);
                        break;
                    case '4':
                        lastChange.Pop();
                        text = string.Empty;
                        if (lastChange.TryPeek(out string result))
                        {
                            text = lastChange.Peek();
                        }
                        break;
                    default:
                        throw new ArgumentException("Wrong command!");
                }
            }
        }
    }
}
