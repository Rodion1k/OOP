using System;
using System.Collections.Generic;

namespace LP_Lab05
{

    class Printer
    {
        public void IAmPrinting(Check obj)
        {
            Console.WriteLine($"Type: {obj.ToString()} ");
        }
    }
    public abstract class Check : ICheckOperations
    {
        public bool CheckNeedSoft(List<ProgrammingSoftware> software, ProgrammingSoftware needSoft)
        {
            foreach (var soft in software)
            {
                if (soft == needSoft)
                    return true;
            }
            return false;
        }

        public bool CheckRAMMemory(Computer pc, float rm)
        {
            if (pc.RAMmemory - (pc.occupiedRAM + rm) <= 0.05f * pc.RAMmemory)
            {
                throw new Exception("недостаточно ОЗУ!!!\n");
            }
            return true;
        }

        public bool CheckROMMemory(Computer pc, float rm)
        {
            if (pc.ROMmemory - (pc.occupiedROM + rm) <= 0.05f * pc.ROMmemory)
            {
                throw new Exception("недостаточно ПЗУ!!!\n");
            }
            return true;
        }

        public bool CheckNeedSystemSoft(Computer pc, string name)
        {
            foreach (var soft in pc.InstaledSystemSoft)
            {
                if (soft.GetType().Name == name)
                    return true;
            }
            return false;
        }

        public override string ToString() => GetType().Name;
        public override int GetHashCode() => Convert.ToInt32(GetType().Name);

        public override bool Equals(object obj) => GetType().Name == obj.ToString();
    }

   public class Computer : Check, IOperationsWithPC
    {
        public float RAMmemory { get; set; }
        public float ROMmemory { get; set; }
        public string name;
        public bool isWork;
        public float occupiedROM;
        public float occupiedRAM;
        public List<ProgrammingSoftware> LaunchedSoft = new List<ProgrammingSoftware>();
        public List<ProgrammingSoftware> InstaledSoft = new List<ProgrammingSoftware>();
        public List<ProgrammingSoftware> InstaledSystemSoft = new List<ProgrammingSoftware>();
        public Computer(float RAMmemory, float ROMmemory,string name)
        {
            this.ROMmemory = ROMmemory;
            this.RAMmemory = RAMmemory;
            this.name = name;
        }

        public void Instal(ProgrammingSoftware pSoftware)
        {
            if (isWork && CheckROMMemory(this, pSoftware.needRom))
            {
                if (Convert.ToString(pSoftware.GetType().BaseType.Name) == "SystemProgrammingSoftware")
                {
                    InstaledSystemSoft.Add(pSoftware);
                }
                else
                {
                    InstaledSoft.Add(pSoftware);
                }

                Console.Write("ПО установлено\n");
            }
            else
            {
                throw new Exception("недостаточно памяти");
            }
        }
        public void RunComputer()
        {

            if (!isWork)
            {
                isWork = true;
                foreach (var soft in InstaledSystemSoft)
                {
                    LaunchedSoft.Add(soft);
                    soft.Starting(this);
                }

            }
            else
            {
                throw new Exception("повторное включение ПК\n");
            }
        }

        public void TurnOffComputer()
        {
            isWork = false;
            LaunchedSoft.Clear();
            occupiedRAM = RAMmemory;
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

    }

    public abstract class ProgrammingSoftware : Check
    {
        protected float occupiedRAM;
        public string name;
        public float needRam;
        public float needRom;

        public ProgrammingSoftware(string name, float needRam, float needRom)
        {
            this.name = name;
            this.needRam = needRam;
            this.needRom = needRom;
        }
        public virtual void Starting(Computer pc)
        {
            if (pc.isWork)
            {
                if (CheckRAMMemory(pc, needRam) && CheckNeedSoft(pc.InstaledSoft, this))
                {
                    occupiedRAM += needRam;
                    pc.RAMmemory -= occupiedRAM;
                    Console.Write(name + " запущена\n");
                    pc.LaunchedSoft.Add(this);
                    return;
                }
            }

            Console.Write(name + "не запустилась!\n");
        }

        public void Ending(Computer pc)
        {
            occupiedRAM -= needRam;
            pc.RAMmemory += occupiedRAM;
            Console.Write(name + " закрытa\n");
        }

    }

    abstract class SystemProgrammingSoftware : ProgrammingSoftware
    {
        public SystemProgrammingSoftware(string name, float needRom, float needRam) : base(name, needRom, needRam)
        {
        }

    }

    class DirectX : SystemProgrammingSoftware
    {
        private string version;

        public DirectX(string name, float needRom, float needRam, string version) : base(name, needRom, needRam)
        {
            this.version = version;
        }

    }

    class WordProcessor : SystemProgrammingSoftware
    {
        private string version;

        public WordProcessor(string name, float needRom, float needRam, string version) : base(name, needRom, needRam)
        {
            this.version = version;
        }

    }

    class Word : ProgrammingSoftware
    {
        public Word(string name, float needRom, float needRam) : base(name, needRom, needRam)
        {
        }

        public override void Starting(Computer pc)
        {
            if (CheckNeedSystemSoft(pc, "WordProcessor"))
            {
                base.Starting(pc);
            }
            else
            {
                throw new Exception("установите word proc\n");
            }
        }
    }

    abstract class Game : ProgrammingSoftware
    {
        public Game(string name, float needRam, float needRom) : base(name, needRam, needRom)
        {
            this.name = name;
            this.needRam = needRam;
            this.needRom = needRom;
        }

        public override void Starting(Computer pc)
        {
            if (CheckNeedSystemSoft(pc, "DirectX"))
            {
                base.Starting(pc);
            }
            else
            {
                throw new Exception("установите DirectX\n");
            }
        }

    }

    class Sapper : Game
    {
        public Sapper(string name, float needRam, float needRom) : base(name, needRam, needRom)
        {
            this.name = name;
            this.needRam = needRam;
            this.needRom = needRom;
        }

        public override void Starting(Computer pc)
        {
            base.Starting(pc);
            Console.Write("сапер запущен\n");
        }
    }

    abstract class MaliciousProgrammingSoftware : SystemProgrammingSoftware
    {
        public MaliciousProgrammingSoftware(string name, float needRom, float needRam) : base(name, needRom, needRam){}
        

    }

    abstract class Virus : MaliciousProgrammingSoftware
    {
        public Virus(string name, float needRom, float needRam) : base(name, needRom, needRam)
        {
        }

        public virtual void CrashProgramms()
        {
            Console.Write("вирус что-то делает\n");
        }
    }

    class CConficker : Virus
    {
        public CConficker(string name, float needRom, float needRam) : base(name, needRom, needRam)
        {
        }

        public override void CrashProgramms()
        {
            Console.Write("CConficker что-то делает\n");
            base.CrashProgramms();
        }
    }

    sealed class Developer
    {
        // создает ПО
        public void CreatePO(string name)
        {
            Console.Write("создает " + name);
        }
    }
}