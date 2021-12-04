using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace LP_Lab15
{
    class Program
    {
        static void Main(string[] args)
        {
            // первое задание
            MyProcess.PrintProcessesInfo();
            // второе задание
            var appDomain = AppDomain.CurrentDomain;
            Console.WriteLine(
                $"name: {appDomain.FriendlyName}, config info: {appDomain.SetupInformation}, Assemblies: ");
            foreach (var assembly in appDomain.GetAssemblies())
                Console.WriteLine(assembly.FullName);
            AppDomain domain= AppDomain.CreateDomain("ApplicationDomain");
            domain.Load(Assembly.GetExecutingAssembly().FullName);
            AppDomain.Unload(domain);
            // третье задание
            Thread numbersThread = new Thread(Counter.Count);
            numbersThread.Name = "CounterTread";
            Console.WriteLine("введите чило для третьего задания");
            numbersThread.Start(Convert.ToInt32(Console.ReadLine()));
            Thread.Sleep(300);
            numbersThread.Suspend();
            Console.WriteLine($"status: {numbersThread.ThreadState}");
            Console.WriteLine($"name: {numbersThread.Name}");
            Console.WriteLine($"priority: {numbersThread.Priority}");
            Console.WriteLine($"ID: {numbersThread.ManagedThreadId}");
            numbersThread.Resume();
            //resume and suspend почему нельзя использовать?  
            // четвертое задание
            OddAndEvenCounter.PrintNumbersByOne(Convert.ToInt32(Console.ReadLine()));
            OddAndEvenCounter.PrintNumbersByTurns(Convert.ToInt32(Console.ReadLine()));
            Thread.Sleep(1000);
            // пятое задание 
            Timer timer = new Timer(2000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
            Console.WriteLine("введите символ, чтобы завершить программу ");
            Console.ReadLine();
            timer.Stop();
            timer.Dispose();
            
            // доп задание 
            using (StreamReader sr = new StreamReader(@"D:\GitHub\OOP\LP_Lab15V\LP_Lab15V\sklad.txt"))
            {
                List<string> firstMachine = new List<string>(3);
                List<string> secondMachine = new List<string>(3);
                List<string> thirdMachine = new List<string>(3);

            }
        }

       
        private static void OnTimedEvent(object obj,ElapsedEventArgs e) => Console.WriteLine($"задача повторилась в: {e.SignalTime}");
        
    }
}