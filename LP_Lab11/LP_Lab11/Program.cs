using System;
using System.Collections.Generic;
using System.Linq;

namespace LP_Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            // первое задание 
            string[] months = new string[]
            {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December"
            };

            var str1 = months.Where(n => n.Length == 7);
            var str2 = months.Where((n, i) => i == 11 || (i < 2) || (5 <= i && i <= 7));
            var str3 = months.OrderBy(n => n);
            var str4 = months.Count(n => n.Contains('u') && n.Length >= 4);
            PrintString(str1);
            PrintString(str2);
            PrintString(str3);
            Console.WriteLine($"кол-во месяцев содержащие букву «u» и длиной имени не менее 4-х {str4}");
            
            // второе и третье задание

            List<Vector> list = new List<Vector>()
            {
                new Vector(1,1,1),
                new Vector(2,2,3),
                new Vector(2,1,0),
                new Vector(1,2,2),
                new Vector(6,3,-1),
                new Vector(6,1,-5),
                new Vector(4,2,4),
                new Vector(15,3,12),
            };

            var list1 = list.Where(n => (n.x == 0) || (n.y == 0) || (n.z == 0));
            var list2 = list.OrderByDescending(n => n.Length).TakeLast(1);
            var list3 = list.Where(n => n.Length == 3 || n.Length == 5 || n.Length == 7);
            var list4 = list.OrderBy(n => n.Length).TakeLast(1);
            var list5 = list.Where(n => n.x < 0 || n.y < 0 || n.z < 0).Take(1);
            var list6 = list.OrderBy(n => n.Length);
            PrintList(list1);
            PrintList(list2);
            PrintList(list3);
            PrintList(list4);
            PrintList(list5);
            PrintList(list6);
            // четвертое задание
            var list7 = list.Where(n => n.Length > 5).TakeWhile(n => (n.x + n.y) > 2)
                .OrderByDescending(n => n.Length).Select(n=>n);
            PrintList(list7);
            var list10 = list.ToArray();
            // пятое задание
            var newTipe = months
                .Join
                (
                    list10,
                    w => w.Length, 
                    q => q.Length,
                    (w, q) => new
                    {
                        id = q.Length,
                        name=w,
                    }
                );
Console.WriteLine("последнее задание ***********************************************");
            foreach (var val in newTipe) 
            {
                Console.WriteLine(val);
            }

        }

        private static void PrintString(IEnumerable<string> str)
        {
            Console.WriteLine("******новый запрос string*******");
            foreach (var s in str)
            {
                Console.WriteLine(s);
            }
        }

        private static void PrintList(IEnumerable<Vector> vectors)
        {
            Console.WriteLine("******новый запрос list*******");
            foreach (var vector in vectors)
            {
                Console.WriteLine(vector);
            }
        }
    }
}