using System;
namespace LP_Lab03
{
    partial class Vector
    {
        public double Length
        {
            get
            {
                return Math.Sqrt(x * x + y * y + z * z);
            }
            private set { }
        }
        public int Id {
            get { return id; }
            set {
                if (value <= maxId)
                    id = value;
                else
                    Console.WriteLine("Неверный ID!");
            }
        }
        public int Count
        {
            get
            {
                return _count;
            }
          
        }
    
        public void PrintValue()
        {
            Console.Write($"({x};{y};{z})\n");
        }

        public void DoubleLengthIncrease(ref double length)
        {
            length *= 2;
        }

        // public static string About
        // {
        //     get { return about; } 
        //     
        // }

        public static string MethodAbout()
        {
            return about;
        }

        public static Vector operator +(Vector first, Vector second)
        {
            return new Vector(first.x + second.x, first.y + second.y, first.z + second.z);
        }
    
        public static Vector operator *(Vector first, Vector second)
        {
            return new Vector(first.x * second.x, first.y * second.y, first.z * second.z);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Vector vector = (Vector)obj;
            return (x == vector.x) && (y == vector.y) && (z == vector.z);
        }
        public override int GetHashCode()
        {
            return id^2+id%10;
        }
        public override string ToString()
        {
            return $"\nx=" + this.x +
                   $"\ny=" + this.y +
                   $"\nz=" + this.z +
                   $"\nlength=" + this.Length;
        }
        
    }
}