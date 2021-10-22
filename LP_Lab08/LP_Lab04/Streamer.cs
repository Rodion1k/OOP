using System;
using System.Collections.Generic;
using System.IO;

namespace LP_Lab04
{
    static class Streamer
    {
        public static void ReadFile(ref Array<string> list)
        {
            int num = 0;
            for(int i=0;i<list.Length;i++)
            {
                if (list[i] is null)
                {
                    num = i;
                    break;
                }
            }
            using (StreamReader sr = new StreamReader(@"D:\GitHub\OOP\LP_Lab08\LP_Lab04\Generic.txt"))
            {
                string[] str = sr.ReadToEnd().Split('-');
                foreach (var val in str)
                {
                    list.Add(val,num++);
                }
            }
        }
        public static void WriteFile(Array<string> list)
        {
            using (StreamWriter sw =new StreamWriter(@"D:\GitHub\OOP\LP_Lab08\LP_Lab04\Generic.txt"))
            {
                for (int i = 0; i < list.Length; i++)
                {
                    if(list[i]is null)
                        break;
                    sw.Write($"{list[i]}-");
                }
            }
        }
    }
}