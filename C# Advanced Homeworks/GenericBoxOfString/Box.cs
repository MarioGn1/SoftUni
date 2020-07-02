using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace GenericBoxOfString
{
    class Box<T> where T: IComparable
    {
        private List<T> colection;
        private T value;
        public Box(T value)
        {
            this.value = value;
        }
        public T Value => this.value;
        
        public Box()
        {
            this.colection = new List<T>();
        }

        public List<T> AddObject(dynamic element)
        {
            
            colection.Add(element);

            return colection;
        }
        public void Swap( int firstIndex, int secondIndex)
        {
            T firstElement = colection[firstIndex];
            T secondElement =colection[secondIndex];

            colection[firstIndex] = secondElement;
            colection[secondIndex] = firstElement;            
        }

        public static int CompareCount(List<T> list, T element)
        {
            int counter = 0;
            foreach (T item in list)
            {                
                if (item.CompareTo(element) == 1)
                {
                    counter++;
                }
            }              
            return counter;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in colection)
            {
                
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            return sb.ToString();
        }
    }
}
