using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    class MyThreeuple<T,V,U>
    {
        private T item1;
        private V item2;
        private U item3;

        public MyThreeuple(T item1, V item2, U item3)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
        }

        public T Item1 { get; set; }
        public V Item2 { get; set; }
        public U Item3 { get; set; }

        public override string ToString()
        {
            return $"{item1} -> {item2} -> {item3}";
        }
    }
}
