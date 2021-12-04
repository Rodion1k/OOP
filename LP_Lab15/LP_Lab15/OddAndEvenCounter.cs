using System;
using System.Diagnostics;
using System.Threading;

namespace LP_Lab15
{
    public static class OddAndEvenCounter
    {
        public static void PrintNumbersByOne(int number)
        {
            object locker = new object();
            Thread oddThread = new Thread(PrintOdd);
            Thread evenThread = new Thread(PrintEven);
            oddThread.Start();
            evenThread.Start();
            oddThread.Join();
            evenThread.Join();
            void PrintOdd()
            {
                lock (locker)
                {
                    for (int i = 1; i < number; i+=2)
                    {
                       // Thread.Sleep(100);
                        Console.WriteLine($"{i}");
                    }
                }   
                
            }

            void PrintEven()
            {
                lock (locker)
                { 
                    for (int i =2; i < number; i+=2)
                    {
                        Thread.Sleep(100);
                        Console.WriteLine($"{i}");
                    }
                    
                }
            }
        }

        public static void PrintNumbersByTurns(int number)
        {
            Mutex mutex = new Mutex();
            object locker = new object();
            Thread oddThread = new Thread(PrintOdd);
            Thread evenThread = new Thread(PrintEven);
            evenThread.Start();
            oddThread.Start();

            void PrintOdd()
            {

                for (int i = 1; i < number; i += 2)
                {
                    mutex.WaitOne();
                    Thread.Sleep(50);
                    Console.WriteLine($"{i}");
                    mutex.ReleaseMutex();
                }
                
            }

            void PrintEven()
            {

                for (int i = 0; i < number; i += 2)
                {
                    mutex.WaitOne();
                    Thread.Sleep(100);
                    Console.WriteLine($"{i}");
                    mutex.ReleaseMutex();
                }
            }

        }

    }
}