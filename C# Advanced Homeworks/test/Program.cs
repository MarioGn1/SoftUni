using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<string>();
            var text = new StringBuilder();

            for (var i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var command = int.Parse(input[0]);
                switch (command)
                {
                    case 1:
                        text.Append(input[1]);
                        stack.Push(text.ToString());
                        break;
                    case 2:
                        text = text.Remove(text.Length - int.Parse(input[1]), int.Parse(input[1]));
                        stack.Push(text.ToString());
                        break;
                    case 3:
                        {
                            Console.WriteLine(text[int.Parse(input[1]) - 1]);
                        }
                        break;
                    case 4:
                        stack.Pop();
                        text.Clear();
                        text.Append(stack.Any() ? stack.Peek() : String.Empty);
                        break;
                }
            }
        }
    }
}