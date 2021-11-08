using System;
using System.Collections.Generic;

namespace LP_Lab10
{
    public class MyDictionary<T> : Dictionary<int, T>
    {

        public void ShowElements()
        {
            Console.WriteLine($"сейчас в коллекции {Count} элементов");
            foreach (var T in this)
            {
                Console.WriteLine(T);
            }
        }

        public void RemoveElements(int firstIdx, int secondIdx)
        {
            
            for (int i = firstIdx; i <= secondIdx && i<Count; i++)
            {
                Remove(i);
            }
            
        }
    }

}
