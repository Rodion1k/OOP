using System;
using System.Collections.Generic;
using LP_Lab05.Exceptions;
namespace LP_Lab05
{
    // class Tanks : Game
    // {
    //     private int l;
    //     public Tanks(string name, float needRam, float needRom) : base(name, needRam, needRom)
    //     {
    //         this.name = name;
    //         this.needRam = needRam;
    //         this.needRom = needRom;
    //         type = POTYPE.Game;
    //     }
    // }
    internal class Program
    {

        public static void Main(string[] args)
        {
            try
            {



                // посмотреть, что еще нужно сделать в заданиях и разбрасать классы с интерфейсами по разным файлам
                Computer<ProgrammingSoftware> pc = new Computer<ProgrammingSoftware>(20000, 80000, "Asus");
                pc.PrintInstalSofts();
                pc.PrintLaunchedSofts();
                Word word = new Word("office2002", 200, 500, "2002");
                Sapper sapper = new Sapper("sapper2001", 2000, 5000, Game.GameType.arcade);
                Game sapper2 = new Sapper("sapper2003", 2000, 5000, Game.GameType.arcade);
                WordProcessor wordProcessor = new WordProcessor("WPr", 200, 100, "1");
                CConficker conficker = new CConficker("CConfickerKEK", 200, 100);
                DirectX directX = new DirectX("directX9.0", 200, 100, "9");
                pc.RunComputer();
                pc.Instal(word);
                pc.Instal(directX);
                pc.Instal(sapper);
                pc.Instal(sapper2);
                pc.FindGamesType(Game.GameType.arcade);
                pc.Instal(wordProcessor);
                Console.Write("до сортировки \n");
                pc.PrintInstalSofts();
                pc.Sort();
                Console.Write("после сортировки \n");
                pc.PrintInstalSofts();
                Console.Write(pc.FindNeedWordVersion("office2002", "2002").name);
                pc.TurnOffComputer();

                pc.RunComputer();
                sapper.Starting(pc);
                word.Starting(pc);
                sapper.Ending(pc);
                pc.Instal(conficker);
                pc.PrintInstalSofts();
                pc.PrintLaunchedSofts();

                Console.Write("\nToString ");
                Console.Write(pc.ToString());
                Console.Write(" ToString\n");

                Developer developer = new Developer();
                developer.CreatePO("Excellence");
                pc.TurnOffComputer();
                Console.Write("\n");

                Printer printer = new Printer();
                List<ProgrammingSoftware> list = new List<ProgrammingSoftware>() { sapper, word, directX };
                foreach (var aitem in list)
                {
                    printer.IAmPrinting(aitem);
                }

                Computer<ProgrammingSoftware> pc2 = new Computer<ProgrammingSoftware>(40000, 80000, "Lenovo");
                Controller controller = new Controller();
                controller.AddPc(pc);
                controller.AddPc(pc2);
                controller.FindGamesType(Game.GameType.arcade);
                Console.Write(controller.FindNeedWordVersion("Word", "2002"));
                pc2.RunComputer();
                controller.ParseTextFile(pc2);
                controller.ParseJsonFile(pc2);






                IOperationsWithPO obj = pc as IOperationsWithPO;
                if (obj != null)
                    Console.WriteLine("Тип Computer поддерживает интерфейс ICheckOperations");
                else
                    throw new Exception("интерфейс не поддерживается");

                IOperationsWithPO obj2 = word as IOperationsWithPO; // comment
                if (obj2 != null)
                    Console.WriteLine("Тип Word поддерживает интерфейс IOperationsWithPC");
                else
                    throw new Exception("интерфейс не поддерживается");


                if (pc is ProgrammingSoftware)
                    Console.WriteLine("Тип Computer поддерживает абстрактный класс ProgrammingSoftware");
                else
                    throw new Exception("абстрактный класс  не поддерживается");// comment

                if (word is ProgrammingSoftware)
                    Console.WriteLine("Тип word поддерживает абстрактный класс ProgrammingSoftware");
                else
                    throw new Exception("абстрактный класс  не поддерживается");
            }
            catch (PcExc ex)
            {
                Logger.WriteLog(ex,false);
            }
            catch (SoftExc ex)
            {
                Logger.WriteLog(ex,false);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);

            }
            finally
            {
                Console.Write("\nend\n");
            }
        }
    }
    
}