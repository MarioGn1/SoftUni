using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    class Stack<T> : IEnumerable<T>
    {
        private List<T> myStack;

        public Stack()
        {
            this.myStack = new List<T>();
        }

        public void Push(T item)
        {
            this.myStack.Add(item);
        }

        public T Pop()
        {
            T item;
            if (this.myStack.Count > 0)
            {
                item = this.myStack[this.myStack.Count - 1];
                this.myStack.RemoveAt(this.myStack.Count - 1);
            }
            else
            {
                throw new InvalidOperationException("No elements");
            }
            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.myStack.Count - 1; i >= 0; i--)
            {
                yield return myStack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
