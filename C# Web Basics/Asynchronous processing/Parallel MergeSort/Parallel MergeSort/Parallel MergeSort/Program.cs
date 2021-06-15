using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace Parallel_MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new Stopwatch();
            var textNums = File.ReadAllText("list.txt");

            watch.Start();

            //List<int> listOfNums = new List<int> { 5, 10, 6, 1, 2, 9, 3, 8, 7, 4 };
            List<int> listOfNums = textNums.Split(", ").Select(int.Parse).ToList();

            //Linq sort(way more faster)
            //var sortlistOfNums = listOfNums.OrderBy(x => x).ToList();

            //Merge sort
            var mtCount = 4; //Number of Threads that will be open during the sort
            var sortlistOfNums = merge_sort(listOfNums, mtCount);

            watch.Stop();

            //Console.WriteLine(string.Join(Environment.NewLine, sortlistOfNums));
            Console.WriteLine(watch.ElapsedMilliseconds);
        }

        public static List<int> merge_sort(List<int> list, int mtCount)
        {
            if (list.Count <= 1)
            {
                return list;
            }

            var left = new List<int>();
            var right = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (i%2 != 0)
                {
                    left.Add(list[i]);
                }
                else
                {
                    right.Add(list[i]);
                }
            }
            if (mtCount > 0)
            {
                var t = new Thread(() => left = merge_sort(left, mtCount - 1));
                t.Start();
                right = merge_sort(right, mtCount - 1);

                t.Join();
            }
            else
            {
                left = merge_sort(left, 0);
                right = merge_sort(right, 0);
            }
            

            return merge(left, right);
        }

        public static List<int> merge(List<int> left, List<int> right)
        {
            var result = new List<int>();

            while (left.Count > 0 && right.Count > 0)
            {
                if (left[0] <= right[0])
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }

            while (left.Count > 0)
            {
                result.Add(left[0]);
                left.RemoveAt(0);
            }

            while (right.Count > 0)
            {
                result.Add(right[0]);
                right.RemoveAt(0);
            }

            return result;
        }
    }
}

//function merge(left, right)
//    var result := empty list

//    while left is not empty and right is not empty do
//        if first(left) ≤ first(right) then
//            append first(left) to result
//            left := rest(left)
//        else
//    append first(right) to result
//            right := rest(right)

//    // Either left or right may have elements left; consume them.
//    // (Only one of the following loops will actually be entered.)
//while left is not empty do
//        append first(left) to result
//        left := rest(left)
//    while right is not empty do
//        append first(right) to result
//        right := rest(right)
//    return result

//function merge_sort(list m)
//    // Base case. A list of zero or one elements is sorted, by definition.
//    if length of m ≤ 1 then
//        return m

//    // Recursive case. First, divide the list into equal-sized sublists
//    // consisting of the even and odd-indexed elements.
//var left := empty list
//    var right := empty list
//    for each x with index i in m do
//        if i is odd then
//            add x to left
//        else
//    add x to right

//    // Recursively sort both sublists.
//    left := merge_sort(left)
//    right:= merge_sort(right)

//    // Then merge the now-sorted sublists.
//return merge(left, right)