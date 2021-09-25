using System;
using System.Reflection.Emit;

namespace LP_Lab04
{
    public enum TypeOfArray
    {
        Int,
        String
    }
    public class Array
    {
        private bool trueArray;
        private bool isHasSize;
        private TypeOfArray _typeOfArray;
        class Owner
        {
            private string _organization;
            private string _name;
            private int _id;

            Owner(string organization,string name)
            {
                this._organization = organization;
                this._name = name;
                _id++;
            }

        }

        class Date
        {
            private DateTime _time;
            Date()
            {
                _time = DateTime.Today;
            }
        }
        // ///// /////// 
      

        // private int[] number = new int[10];
        private int[] number;
        private string[] str = new string[10];


        public int this[int index]
        {

            get
            {
                return number[index];
            }
            set
            {
                if (!isHasSize)
                {
                    number = new int[100];
                    isHasSize = true;
                }
                if(index>Length-1)
                    Length++;
                number[index] = value;
            }
        }

        public Array()
        {
            trueArray = true;
            _typeOfArray = TypeOfArray.Int;
            Length = 0;
            number = new int[0];
            isHasSize = false;

        }
        public Array(TypeOfArray typeOfArray)
        {
            trueArray = true;
            _typeOfArray = typeOfArray;
            Length = 0;
            isHasSize = false;

        }
        public Array(int size)
        {
            trueArray = true;
            number = new int[size];
            Length = size;
            isHasSize = true;

        }
        
        public int Length { get; set; }


        public static Array operator *(Array first, Array second)
        {
            Array newArray = new Array(first.Length);
            for (int i = 0; i < first.Length; i++)
            {
                newArray.number[i] = first.number[i] * second.number[i];
            }

            newArray.Length = first.Length;
        
            return newArray;
        }

        public static bool operator true(Array arr)
        {
           
            return arr.trueArray;
        }
        public static bool operator false(Array arr)
        {
            
            return arr.trueArray;
        }

        public static implicit operator int(Array array) // неявное преобразование
        {
            return array.Length;
        }
        // public static explicit  operator int(Array array) // явное преобразование
        // {
        //     return array.Length;
        // }
        public static bool operator ==(Array first, Array second)
        {
            if (first.Length != second.Length)
                return false;
            if (first.trueArray != second.trueArray)
                return false;
            for (int i = 0; i < first.Length; i++)
            {
                if (first.number[i] != second.number[i])
                    return false;
            }

            return true;
        }
        public static bool operator !=(Array first, Array second)
        {
            if (first.Length != second.Length)
                return true;
            if (first.trueArray != second.trueArray)
                return true;
            for (int i = 0; i < first.Length; i++)
            {
                if (first.number[i] != second.number[i])
                    return true;
            }

            return false;
        }

        public static bool operator <(Array first, Array second)
        {
            if (first.Length < second.Length)
                return true;
            else
            {
                return false;
            }
        }
        public static bool operator >(Array first, Array second)
        {
            if (first.Length > second.Length)
                return true;
            else
            {
                return false;
            }
        }
       





    }
}