using System;
using System.IO;
using System.Threading;

namespace LP_Lab15
{
    public static class Counter
    {
        public static void Count(object num)
        {
            int number = (int)num;
            // StreamWriter sw = new StreamWriter(@"D:\GitHub\OOP\LP_Lab15\LP_Lab15\counter.txt")
            using (StreamWriter sw = new StreamWriter(@"D:\GitHub\OOP\LP_Lab15V\LP_Lab15V\counter.txt"))
            {
                for (int i = 1; i < number; i++)
                {
                    Console.WriteLine(i);
                    sw.WriteLine(i);
                    Thread.Sleep(200);
                }
            }
        }
    }
}