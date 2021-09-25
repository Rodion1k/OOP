using System;
using System.Runtime.InteropServices.ComTypes;

namespace LP_Lab03
{

  class Program
  {

    public static void Main(string[] args)
    {

      Vector vector1 = new Vector(2.23f, 3, 5);
      Vector vector2 = new Vector(1, 3, 6);
      var vectorcopy = new Vector(vector1);
      Console.Write("\nвторой вектор: ");
      vectorcopy.PrintValue();
      vector1.x = 0;
      Console.Write("\nпервый вектор: ");
      vector1.PrintValue();
      Vector vector = vector1 + vector2;
      Console.Write("вектор после сложения : ");
      vector.PrintValue();
      vector = vector1 * vector2;
      vector.PrintValue();
      Console.Write("вектор после умножения : ");
      Console.Write("\nкол-во " + vector.Count);
      var length = vector.Length;
      Console.Write("\nfirst length: " + length);
      vector.DoubleLengthIncrease(ref length);
      Console.Write("\nsecond length: " + length);
      Vector[] vectors = new Vector[5];
      vectors[0] = new Vector(10, 5, 7);
      vectors[1] = new Vector(12, 6, 7);
      vectors[2] = new Vector(7, 8, 9);
      vectors[3] = new Vector(8, 0, 12);
      vectors[4] = new Vector(43, 76, 89);
      foreach (var vec in vectors)
      {
        if (FinedVectorWithNullParam(vec))
        {
          Console.Write("\nвектор с нулем в параметре " + vec);
        }
      }

      var minVector = FinedVectorWithSmallestModule(vectors);
      Console.Write("\nвектор с минимальным модулем: ");
      minVector.PrintValue();
      var user = new { Name = "Tom", Age = 34 };
      Console.WriteLine("анонимный тип "+user.Name);
      Console.Write("\nкол-во " + vector.Count);
      Console.Write(Vector.MethodAbout());



    }

    private static bool FinedVectorWithNullParam(Vector vector)
    {
      if (vector.x == 0 || vector.y == 0 || vector.z == 0)
        return true;
      return false;
    }

    private static Vector FinedVectorWithSmallestModule(Vector[] vectors)
    {
      double minLength = vectors[0].Length;
      int num = 0, count = 0;
      foreach (var vec in vectors)
      {
        if (vec.Length < minLength)
        {
          minLength = vec.Length;
          num = count;
        }

        count++;
      }

      return vectors[num];
    }


  }
}