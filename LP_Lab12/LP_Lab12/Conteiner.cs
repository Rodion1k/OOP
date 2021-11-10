using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LP_Lab05.Exceptions;
using LP_Lab12;

namespace LP_Lab05
{
    public class Computer<T> where T:ProgrammingSoftware
    {
        public float RAMmemory { get; set; }
        public float ROMmemory { get; set; }
        public string name;
        public bool isWork;
        public float occupiedROM;
        public float occupiedRAM;
        public List<ProgrammingSoftware> LaunchedSoft;
        public List<ProgrammingSoftware> InstaledSoft;
        public List<ProgrammingSoftware> InstaledSystemSoft;
       
        public Computer(float RAMmemory, float ROMmemory,string name)
        {
            this.ROMmemory = ROMmemory;
            this.RAMmemory = RAMmemory;
            this.name = name;
            LaunchedSoft = new List<ProgrammingSoftware>();
            InstaledSoft = new List<ProgrammingSoftware>();
            InstaledSystemSoft = new List<ProgrammingSoftware>();
        }
      
        private  bool CheckROMMemory(Computer<T> pc, float rm)
        {
            if (pc.ROMmemory - (pc.occupiedROM + rm) <= 0.05f * pc.ROMmemory)
            {
                throw new PcExc(
                    $"недостаточно памяти на жестком диске!\n нужно: {occupiedROM + rm}, имеется: {ROMmemory} ");
            }
            return true;
        }
        public void Instal(ProgrammingSoftware pSoftware)
        {
            if (isWork && CheckROMMemory(this, pSoftware.needRom))
            {
                if (pSoftware.type == POTYPE.SystemSoftware) 
                {
                    InstaledSystemSoft.Add(pSoftware);
                }
                else
                {
                    InstaledSoft.Add(pSoftware);
                }

                Console.Write("ПО "+pSoftware.name+" установлено\n");
            }
            else
            {
                throw new PcExc("ошибка установки, ПК выключен!\n");
            }
        }

        public void Delete(ProgrammingSoftware pSoftware)
        {
            // возможно нужно сделать проверку на присутствие элемента в списке,
            // но в данном случае, если проги нету, то она не удалиться
            if (pSoftware.type == POTYPE.SystemSoftware)
            {
                InstaledSystemSoft.Remove(pSoftware);
                return;
            }

            InstaledSoft.Remove(pSoftware);
        }

        private void StartingAllSystemPO(Computer<T> pc, ProgrammingSoftware soft)
        {
            // мб будет enum типов PO 
            occupiedRAM += soft.needRam;
            pc.RAMmemory -= occupiedRAM;
            Console.Write(soft.name + " запущена\n");
            pc.LaunchedSoft.Add(soft);
        }

        public void RunComputer()
        {

            if (!isWork)
            {
                Console.Write(name+" ПК включен\n");
                isWork = true;
                foreach (var soft in InstaledSystemSoft)
                {
                    StartingAllSystemPO(this,soft);
                }

            }
            else
            {
                throw new PcExc("повторное включение ПК\n");
            }
        }

        public void TurnOffComputer()
        {
            Console.Write(name+" ПК выключен\n");
            isWork = false;
            LaunchedSoft.Clear();
            occupiedRAM = 0;
        }
        public void Sort()
        {
            InstaledSoft = InstaledSoft.OrderByDescending(soft => soft.name).ToList();
            InstaledSystemSoft = InstaledSystemSoft.OrderByDescending(soft => soft.name).ToList();
        }
        public ProgrammingSoftware FindNeedWordVersion(string name,string type)
        {
            foreach (var soft in InstaledSoft)
            {
                if (soft.GetType().Name == "Word")
                {
                    if (soft.version == type && soft.name == name)
                    {
                        return soft;
                    }
                }
            }

            return null;
        }
        public void PrintInstalSofts()
        {
            Console.Write("установленное ПО\n");
            foreach (var software in InstaledSoft)  
            {
                Console.Write(software.GetType().Name + " " +software.name );
                Console.WriteLine();
            }
        }
        public void PrintLaunchedSofts()
        {
            Console.Write("запущенное ПО\n");
            foreach (var software in LaunchedSoft)
            {
                Console.Write(software.GetType().Name + " " +software.name );
                Console.WriteLine();
            }
        }

        public void FindGamesType(Game.GameType gameType)
        {
            Console.Write("игры типа "+gameType+":\n");
            foreach (var soft in InstaledSoft)
            {
                if (soft.type == POTYPE.Game)
                {
                    var tempsoft = (Game)soft;
                    if(tempsoft.gameInfo._type == gameType)
                        Console.Write(soft.name);
                    Console.WriteLine();
                }
            }
        }

    }
}