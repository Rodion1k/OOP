using System;
using LP_Lab04;

namespace LP_Lab04
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      Array array1 = new Array();
      
      Console.WriteLine(array1.Length);
      array1[0] = 5;
      array1[1] = -1;
      array1[2] = 2;
      Console.Write(StatisticOperation.FindSomeSymbol(array1, 2)+"\n");
      Console.WriteLine(array1.Length);
      Console.WriteLine("удаление негатив");
      StatisticOperation.DeleteNegativeValue(array1);
      Console.WriteLine(array1.Length);
      StatisticOperation.PrintArray(array1);
      
      
      Array array2 = new Array();
      array2[0] = 1;
      array2[1] = 1;
      array2[2] = 2;
      array2[3] = 3;
      
      Array array3 = array1 * array2;
      StatisticOperation.PrintArray(array3);

      Console.WriteLine();
      // int length = (int)lol; // явное преобразование
      // Console.Write("\n"+length);
      int lenggfd = array3; // неявное преобразование
      Console.Write("\n" + lenggfd);
      // сравнение массивов 
      Console.Write("\nсравнение массивов: ");
      if (array1 == array2)
      {
        Console.WriteLine("равны");
      }
      else
      {
        Console.WriteLine("не равны");
      }
      Console.Write("\n");
      
      Console.ReadKey();

    }
    

   
  }
}