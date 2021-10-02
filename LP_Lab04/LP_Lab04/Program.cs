using System;
using LP_Lab04;

namespace LP_Lab04
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      Array array1 = new Array();
      
      Console.Write(array1.Length);
      array1[0] = 5;
      array1[1] = -1;
      array1[2] = 2;
      
      Console.Write(array1.Length);
      array1[3] = 3;
      Console.Write(array1.Length);
      Array array2 = new Array();
      array2[0] = 1;
      array2[1] = 1;
      array2[2] = 2;
      array2[3] = 3;
      
      Array array3 = array1 * array2;
      for (int i = 0; i < array3.Length; i++)
      {
        Console.Write(array3[i] + "\t");
      }

      CheckArray(array1);
      array1[1] = 2;
      Console.Write("\n");
      CheckArray(array1);
      // int length = (int)lol; // явное преобразование
      // Console.Write("\n"+length);
      int lenggfd = array3; // неявное преобразование
      Console.Write("\n" + lenggfd);
      // сравнение массивов 
      Console.Write("\nсравнение массивов: ");
      if (array1 == array2)
      {
        Console.Write("равны");
      }
      else
      {
        Console.Write("не равны");
      }
      //  для стринга 
      Console.Write("\n");
      Console.Write(StatisticOperation.FindSomeSymbol(array1, 2)+"\n");
      StatisticOperation.DeleteNegativeValue(array1);
      Console.Write(array1.Length+"\n");
      StatisticOperation.PrintArray(array1);
      Console.Write(StatisticOperation.ArraySum(array1));

    }
    private static void CheckArray(Array array)
    {
      if (array)
      {
        Console.Write("\nположит");
      }
      else
      {
        Console.Write("\nотриц");
      }
    }

   
  }
}