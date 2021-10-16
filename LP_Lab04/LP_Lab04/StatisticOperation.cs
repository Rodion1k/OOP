
using System;

namespace LP_Lab04
{
    public static class StatisticOperation
    {
        public static void DeleteNegativeValue(Array array)
        {
            for (int i = array.Length - 1; i >=0 ; i--)
            {
                if (array[i] < 0)
                {
                    for (int j = i; j < array.Length; j++)
                    {
                        array[j] = array[j + 1];
                    }
            
                    array.Length--;
                }
            }
            
        }

        public static void PrintArray(Array array)
        {
            Console.WriteLine("массив: ");
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
            Console.WriteLine("сумма массива: ");
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }
        
    }
}