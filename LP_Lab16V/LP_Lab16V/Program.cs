using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.IO;
namespace LP_Lab16
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
            // 8 задание 
            ReadWriteAsync();
            FactorialAsync(10);
            Task7();                   
        }

        private static async void FactorialAsync(int n)
        {
            int x = await Task.Run(() => Factorial(n));
            Console.WriteLine($"Факториал равен {x}");
        }
        static async void ReadWriteAsync()
        {
            string s = "Hello world! kek kek kek kek lol lol lol lol ";
 
            // hello.txt - файл, который будет записываться и считываться
            using (StreamWriter writer = new StreamWriter(@"D:\GitHub\OOP\LP_Lab16V\LP_Lab16V\hello.txt", false))
            {
                await writer.WriteLineAsync(s);  // асинхронная запись в файл
            }
            using (StreamReader reader = new StreamReader(@"D:\GitHub\OOP\LP_Lab16V\LP_Lab16V\hello.txt"))
            {
                string result = await reader.ReadToEndAsync();  // асинхронное чтение из файла
                Console.WriteLine(result);
            }
        } 

        private static void Task1()
        {
            Console.WriteLine("************TASK1************");
            for (int i = 0; i < 5; i++)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Task task = new Task(() => ExecuteEratosfen(100000));
                task.Start();
                Console.WriteLine($"Task id: {task.Id}, status: {task.Status}");
                task.Wait();
                Console.WriteLine($"Task id: {task.Id}, status: {task.Status}");
                sw.Stop();
                Console.WriteLine($"Task #1: {sw.ElapsedMilliseconds}ms");
                Console.WriteLine();
                task.Dispose();
            }
        }

        private static void Task2() // хуево работает? 
        {
            Console.WriteLine("************TASK2************");
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

            Task task = new Task(() => ExecuteEratosfen(100000, cancelTokenSource));
            task.Start();
            Console.WriteLine($"Task id: {task.Id}, status: {task.Status}");
            task.Wait();
            Console.WriteLine($"Task id: {task.Id}, status: {task.Status}");

            Console.WriteLine();
            task.Dispose();
        }

        private static void Task3()
        {
            Console.WriteLine("************TASK3************");
            Task<int> task1 = new Task<int>(() => ExecuteEratosfen(10).Sum());
            Task<int> task2 = new Task<int>(() => new Random().Next(0, 10));
            Task<int> task3 = new Task<int>(() => Factorial(5));
            task1.Start();
            task2.Start();
            task3.Start();
            Task.WaitAll(task1, task2, task3);
            Task t = new Task(() => Console.WriteLine(task1.Result+task2.Result+task3.Result));
            t.Start();
            t.Wait();
        }

        private static void Task4()// разобраться со вторым заданием
        {
            Console.WriteLine("************TASK4.1************");
            Task<int> task1 = new Task<int>(() => Factorial(5));
            Task<int> task2 = task1.ContinueWith((fact) => ExecuteEratosfen(fact.Result).Sum());
            Task show = task2.ContinueWith((result) => Console.WriteLine(result.Result));
            task1.Start();
            show.Wait();
            Console.WriteLine("************TASK4.2************");
            Task<int> task3 = new Task<int>(() => Factorial(5));
            TaskAwaiter<int> awaiter = task3.GetAwaiter();
            awaiter.OnCompleted(() => Console.WriteLine($"Result is: {task3.Result}"));
            task3.Start();
            task3.Wait();
            awaiter.GetResult();
        }

        private static void Task5()
        {
            Console.WriteLine("************TASK5************");
            int[] arr1 = new int[100000];
            int[] arr2 = new int[100000];
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Parallel.For(0, 100000, FillArrays);
            sw.Stop();
            Console.WriteLine($"Parallel Cycle for: {sw.ElapsedMilliseconds}ms");

            sw.Restart();
            for(int i = 0; i < 100000; i++)
            {
                arr1[i] = i;
                arr2[i] = i;
            }
            sw.Stop();
            Console.WriteLine($"Normal Cycle for: {sw.ElapsedMilliseconds}ms");
            sw.Start();
            Parallel.ForEach(new List<int>() { 1, 3, 5, 8 }, FactorialX);
            sw.Stop();
            Console.WriteLine($"Parallel Cycle foreach: {sw.ElapsedMilliseconds}ms");
            void FillArrays(int j)
            {
                arr1[j] = j*100/10-9;
                arr2[j] = j*100/10-9;
            }
            
        }

        private static void Task6()
        {
            Parallel.Invoke( DisplayMassage,
                () => { 
                    Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                    Thread.Sleep(3000);
                },
                () => Factorial(5));
        }

        private static void Task7()
        {
            BlockingCollection<string> blockColl = new BlockingCollection<string>();
        
            Task[] sellers = new Task[10]
            {
                new Task(() => { while (true) { Thread.Sleep(1000); blockColl.Add("Стол"); } }),
                new Task(() => { while (true) { Thread.Sleep(1000); blockColl.Add("Шкаф"); } }),
                new Task(() => { while (true) { Thread.Sleep(1000); blockColl.Add("Зеркало"); } }),
                new Task(() => { while (true) { Thread.Sleep(1000); blockColl.Add("чайник"); } }),
                new Task(() => { while (true) { Thread.Sleep(1000); blockColl.Add("Подоконник"); } }),
                new Task(() => { while (true) { Thread.Sleep(1000); blockColl.Add("Микроволновка"); } }),
                new Task(() => { while (true) { Thread.Sleep(1000); blockColl.Add("миксер"); } }),
                new Task(() => { while (true) { Thread.Sleep(1000); blockColl.Add("утюг"); } }),
                new Task(() => { while (true) { Thread.Sleep(1000); blockColl.Add("стералка"); } }),
                new Task(() => { while (true) { Thread.Sleep(1000); blockColl.Add("телевизор"); } })
            };
            Task[] consumers = new Task[5]
            {
                new Task(() => { while (true) { Thread.Sleep(300); blockColl.Take(); } }),
                new Task(() => { while (true) { Thread.Sleep(500); blockColl.Take(); } }),
                new Task(() => { while (true) { Thread.Sleep(500); blockColl.Take(); } }),
                new Task(() => { while (true) { Thread.Sleep(400); blockColl.Take(); } }),
                new Task(() => { while (true) { Thread.Sleep(250); blockColl.Take(); } })
            };
            foreach (var i in sellers)
                if (i.Status != TaskStatus.Running)
                    i.Start();

            foreach (var i in consumers)
                if (i.Status != TaskStatus.Running)
                    i.Start();

            int count = 1;
            while (true)
            {
                if (blockColl.Count != count && blockColl.Count != 0)
                {
                    count = blockColl.Count;
                    Thread.Sleep(500);
                    Console.WriteLine("---Склад---");
                    foreach(var i in blockColl)
                        Console.WriteLine(i);
                    Console.WriteLine("--------------------------------------");
                }
            }
            
        }

        private static void DisplayMassage()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("kek");
                
            }
        }
        private static int Factorial(int x)
        {
            int result = 1;
 
            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
 
            return result;
        }
        private static void FactorialX(int x)
        {
            int result = 1;
 
            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
 
            Console.WriteLine(result);
        }
       
        private static List<int> ExecuteEratosfen(int maxNumber,CancellationTokenSource cancelTokenSource)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            CancellationToken cancelToken = cancelTokenSource.Token;
            List<int> simple = new List<int>();
            for (int i = 2; i < maxNumber; i++)
                simple.Add(i);
            DoEratosfen();
            
            
            void DoEratosfen()
            {
                int i=1;
                while (i < simple.Count)
                { 
                    if (cancelToken.IsCancellationRequested)
                    {
                        Console.WriteLine("Операция прервана токеном");
                        return;
                    }
                    Step(simple[i], i);
                    i++;
                }
            }
            
            int Step(int Prime, int startFrom)
            {
                int i = startFrom+1;
                int Removed = 0;
                while (i < simple.Count)
                    if (simple[i] % Prime == 0)
                    {
                        simple.RemoveAt(i);
                        Removed++;
                    }
                    else
                        i++;
                if (sw.ElapsedMilliseconds >= 300) 
                    cancelTokenSource.Cancel();
                return Removed;
            }
            sw.Stop();
            return simple;
        }
        
        private static List<int> ExecuteEratosfen(int maxNumber)
        {
            List<int> simple = new List<int>();
            for (int i = 2; i < maxNumber; i++)
                simple.Add(i);
            DoEratosfen();
            
            
            void DoEratosfen()
            {
                int i=1;
                while (i < simple.Count)
                {
                    Step(simple[i], i);
                    i++;
                }
            }
            
            int Step(int Prime, int startFrom)
            {
                int i = startFrom+1;
                int Removed = 0;
                while (i < simple.Count)
                    if (simple[i] % Prime == 0)
                    {
                        simple.RemoveAt(i);
                        Removed++;
                    }
                    else
                        i++;
                return Removed;
            }
            return simple;
        }

    }
}