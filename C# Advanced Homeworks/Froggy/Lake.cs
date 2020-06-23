using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Froggy
{
    class Lake<T> : IEnumerable<T>
    {
        private List<T> stonesArr;

        public Lake()
        {
            this.stonesArr = new List<T>();
        }

        public void AddElements(params T[] elements)
        {
            foreach (T item in elements)
            {
                stonesArr.Add(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < stonesArr.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return stonesArr[i]; 
                }

            }
            for (int i = stonesArr.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return stonesArr[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }



}
