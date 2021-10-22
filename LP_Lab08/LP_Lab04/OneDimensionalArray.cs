using System;
using System.Reflection.Emit;

namespace LP_Lab04
{
     class Array<T>:IGenericInterf<T> where T:class 
    {
      
        private bool isHasSize;
        private T[] number;
        public T this[int index]
        {

            get
            {
                return number[index];
            }
            set
            {
                if (!isHasSize)
                {
                    number = new T[100];
                    isHasSize = true;
                }
                if(index>Length-1)
                    Length++;
                number[index] = value;
            }
        }

        public Array()
        {
            
            Length = 0;
            number = new T[0];
            isHasSize = false;

        }
        
        public Array(int size)
        {
            
            number = new T[size];
            Length = size;
            isHasSize = true;

        }
        public int Length { get; set; }

        public void Add(T aitem,int index)
        {
            if (index > Length || index < 0) 
                throw new IndexException("индекс выходит за пределы массива");
            number[index] = aitem;
        }

        public void Del(T aitem)
        {
            
            for (int i = Length - 1; i >= 0; i--)
            {
                T kek = number[i];
                if(number[i] is null) continue; // не инициализированный объект все портит 
                if (number[i].Equals(aitem))
                {
                    for (int j = i; j < Length; j++)
                    {
                        number[j] = number[j + 1];
                        if(number[j] is null && number[j+1] is null)
                            break;
                    }

                    Length--;
                }
            }

        }

        public void Show()
        {
            foreach (var item in number)
            {
                Console.WriteLine(item);
            }
        }

    }
}