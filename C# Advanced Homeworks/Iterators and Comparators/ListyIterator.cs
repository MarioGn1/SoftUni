using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ListyIterator
{
    class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> collection;
        private int internalIndex;

        public ListyIterator()
        {
            this.collection = new List<T>();
            this.internalIndex = 0;
        }

        public void Create(params T[] elements)
        {
            this.collection = elements.ToList();
        }

        public bool Move ()
        {
            bool hasNext = HasNext();
            if (hasNext)
            {
                this.internalIndex++;
            }
            return hasNext;
        }

        public bool HasNext()
        {
            bool hasNext = false;
            if (this.internalIndex + 1 <= this.collection.Count - 1)
            {
                hasNext = true;
            }
            return hasNext;
        }

        public void Print()
        {
            if (this.collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid operation!");
            }
            
            Console.WriteLine(this.collection[this.internalIndex]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < collection.Count; i++)
            {
                yield return collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
