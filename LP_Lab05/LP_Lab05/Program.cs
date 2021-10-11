using System;
using System.Collections.Generic;

namespace LP_Lab05
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // посмотреть, что еще нужно сделать в заданиях и разбрасать классы с интерфейсами по разным файлам
            Computer pc = new Computer(20000,80000,"Asus");
            pc.PrintInstalSofts();
            pc.PrintLaunchedSofts();
            Word word = new Word("office2002",200,500);
            Sapper sapper = new Sapper("sapper2001", 2000, 5000);
            WordProcessor wordProcessor = new WordProcessor("WPr",200,100,"1");
            CConficker conficker = new CConficker("CConfickerKEK", 200, 100);
            DirectX directX = new DirectX("CConfickerKEK", 200, 100,"2");
            pc.RunComputer();
            pc.Instal(word);
            pc.Instal(directX);
            pc.Instal(sapper);
            pc.Instal(wordProcessor);
            Console.Write("\nToString ");
            Console.Write(pc.ToString());
            Console.Write(" ToString\n");
            pc.Instal(conficker);
            sapper.Starting(pc);
            word.Starting(pc);
            sapper.Ending(pc);
            pc.PrintInstalSofts();
            pc.PrintLaunchedSofts();
            Developer developer = new Developer();
            developer.CreatePO("Excellence");
            pc.TurnOffComputer();
            Printer printer = new Printer();
            Console.Write("\n");
            List<ProgrammingSoftware> list = new List<ProgrammingSoftware>(){sapper,word,directX};
            foreach (var aitem in list)
            {
                printer.IAmPrinting(aitem);
            }
            
            ICheckOperations obj = pc as ICheckOperations;
            if (obj != null)
                Console.WriteLine("Тип Computer поддерживает интерфейс ICheckOperations");
            else
                throw new Exception("интерфейс не поддерживается");
            
            // IOperationsWithPC obj2 = word as IOperationsWithPC;
            // if (obj2 != null)
            //     Console.WriteLine("Тип Word поддерживает интерфейс IOperationsWithPC");
            // else
            //     throw new Exception("интерфейс не поддерживается");
            
            
            // if (pc is ProgrammingSoftware)
            //     Console.WriteLine("Тип Computer поддерживает абстрактный класс ProgrammingSoftware");
            // else
            //     throw new Exception("абстрактный класс  не поддерживается");
            
            if (word is ProgrammingSoftware)
                Console.WriteLine("Тип word поддерживает абстрактный класс ProgrammingSoftware");
            else
                throw new Exception("абстрактный класс  не поддерживается");
        }
    }
}