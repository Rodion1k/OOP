using System;
  
namespace LP_Lab03
{
  partial class Vector
      {
        public static readonly DateTime globalStartCreatingTime;

        private static string about = $"\nне знаю зачем это, но пусть будет\n" + $"Информация о классе:\n " 
         + $"есть возможность посмотреть время создания первого экземпляра (Vector.globalStartCreatingTime)\n";

        private const int maxId = 99999;
        private int id;
        public float x;
        public float y;
        public float z;
        private bool _isCreited = false;
        private static int _count;
        static Vector()
        {
          globalStartCreatingTime=DateTime.Now;
          Console.WriteLine("Статический конструктор сработал\n");
          _count = 0;
        }
        public Vector(float x, float y, float z)
        {
          this.x = x;
          this.y = y;
          this.z = z;
          _count++;
        }
    
        public Vector()
        {
          _count++;
        }

        public Vector(Vector vector)
        {
          x = vector.x;
          y = vector.y;
          z = vector.z;
        }
    
        // private Vector()
        // {     //   закрытый конструктор
        //     не допускает создание объектов.
        // }
        
    
      }
    
}