using System;
using System.Linq;

namespace DateModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            //DateModifier dates = new DateModifier();

            //for (int i = 0; i < 2; i++)
            //{
            //    int[] date = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //    DateTime curDate = new DateTime(date[0],date[1],date[2]);
            //    dates.AddDate(curDate);
            //}

            //Console.WriteLine(Math.Abs(dates.GetDifferenceOfTwoDays()));

            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();
            double res = DateModifier.GetDaysBetween(firstDate, secondDate);
            Console.WriteLine(res);
        }
    }
}
