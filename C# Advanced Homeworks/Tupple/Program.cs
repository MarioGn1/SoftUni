using System;

namespace Tupple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputStrings = Console.ReadLine().Split();
            MyTuple<string, string> myTupleString = new MyTuple<string, string>(inputStrings[0] +" "+ inputStrings[1], inputStrings[2]);
            Console.WriteLine(myTupleString);

            string[] inputIntString = Console.ReadLine().Split();
            MyTuple<string, int> myTupleStringInt = new MyTuple<string, int>(inputIntString[0], int.Parse(inputIntString[1]));
            Console.WriteLine(myTupleStringInt);

            string[] inputIntDouble = Console.ReadLine().Split();
            MyTuple<int, double> myTupleIntDouble = new MyTuple<int, double>(int.Parse(inputIntDouble[0]), double.Parse(inputIntDouble[1]));
            Console.WriteLine(myTupleIntDouble);
        }
    }
}
