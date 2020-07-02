using System;
using System.Collections.Generic;
using System.Text;

namespace Tupple
{
    class MyTuple<T, V>
    {
        private T item1;
        private V item2;

        public MyTuple(T item1, V item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public T Item1 => this.item1;
        public V Item2 => this.item2;
        public override string ToString()
        {
            return $"{item1} -> {item2}";
        }
    }
}
