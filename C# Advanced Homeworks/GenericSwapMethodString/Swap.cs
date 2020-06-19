using System.Collections.Generic;

namespace GenericSwapMethodString
{
    public static class ListSwap<T>
    {
        public static List<T> SwapedElements(List<T> listToSwap, int firstIndex, int secondIndex)
        {

            T firstElement = listToSwap[firstIndex];
            T secondElement = listToSwap[secondIndex];

            listToSwap[firstIndex] = secondElement;
            listToSwap[secondIndex] = firstElement;
            return listToSwap;
        }
    }
}