using System;
using System.Collections.Generic;
using System.Linq;

namespace Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string parenth = Console.ReadLine();

            Stack<char> parenthChars = new Stack<char>();

            
            bool isTrue = true;


            foreach (var item in parenth)
            {
                if (item == '{' || item == '[' || item == '(')
                {
                    parenthChars.Push(item);
                }
                else
                {
                    if (!parenthChars.Any())
                    {
                        isTrue = false;
                        break;
                    }
                    char curOpenParenth = parenthChars.Pop();
                    bool squareParenth = curOpenParenth == '[' && item == ']';
                    bool normalParenth = curOpenParenth == '(' && item == ')';
                    bool curlyParenth = curOpenParenth == '{' && item == '}';

                    if (!squareParenth && !normalParenth && !curlyParenth)
                    {
                        isTrue = false;
                        break;
                    }
                }
            }

            if (isTrue)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
