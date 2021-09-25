
using System;

namespace LP_Lab04.Properties
{
    public static class StatisticOperation
    {
        public static void DeleteNegativeValue(Array array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    array[i] = array[i + 1];
                    // удалить элемент 
                    array.Length--;
                }
            }
       
        }

        public static void PrintArray(Array array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]+" ");
            }
            Console.Write("\n");
        }

        public static bool FindSomeSymbol(Array array,int symbol)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == symbol)
                {
                    return true;
                }
            }
            return false;
        }

        public static int ArraySum(Array array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }
        
    }
}