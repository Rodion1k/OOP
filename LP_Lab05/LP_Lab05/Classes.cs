using System;
using System.Collections.Generic;
public enum POTYPE
{
    Game,
    SystemSoftware,
    OtherSoftware,
}
namespace LP_Lab05
{

    class Printer
    {
        public void IAmPrinting(ProgrammingSoftware obj)
        {
            Console.WriteLine($"Type: {obj.ToString()} ");
        }
    }
   
    public abstract class ProgrammingSoftware :IOperationsWithPO
    {
        protected float occupiedRAM;
        public string name;
        public float needRam;
        public float needRom;
        public POTYPE type;
        public string version;

        public ProgrammingSoftware(string name, float needRam, float needRom)
        {
            this.name = name;
            this.needRam = needRam;
            this.needRom = needRom;
        }
        public override string ToString() => GetType().Name;
        public override int GetHashCode() => Convert.ToInt32(GetType().Name);

        public override bool Equals(object obj) => GetType().Name == obj.ToString();
        public virtual void Starting(Computer<ProgrammingSoftware> pc)
        {
            if (pc.isWork)
            {
                if (Check.CheckRAMMemory(pc, needRam) && Check.CheckNeedSoft(pc.InstaledSoft, this))
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

        public void Ending(Computer<ProgrammingSoftware> pc)
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
       
        public DirectX(string name, float needRom, float needRam, string version) : base(name, needRom, needRam)
        {
            this.version = version;
            type = POTYPE.SystemSoftware;
        }

    }

    class WordProcessor : SystemProgrammingSoftware
    {
        private string _version;

        public WordProcessor(string name, float needRom, float needRam, string version) : base(name, needRom, needRam)
        {
            this._version = version;
            type = POTYPE.SystemSoftware;
        }

    }

    class Word : ProgrammingSoftware
    {
        public Word(string name, float needRom, float needRam,string version) : base(name, needRom, needRam)
        {
            this.version = version;
        }

        public override void Starting(Computer<ProgrammingSoftware> pc)
        {
            if (Check.CheckNeedSystemSoft(pc, "WordProcessor"))
            {
                base.Starting(pc);
            }
            else
            {
                throw new Exception("установите word proc\n");
            }
        }
    }
    public struct Games
    {
        public Game _game;
        public CLASSTYPE gametype;
        
       public Games(Game _game,CLASSTYPE gametype)
       {
           this._game = _game;
           this.gametype = gametype;
       }
       
       public enum CLASSTYPE
       {
           firstpublic,
           second,
       }

        
        // структура классов можно ли так если да то закинуть класс сапер и тд 
    }
    public class Game : ProgrammingSoftware // partial
    {
        
        public Game(string name, float needRam, float needRom) : base(name, needRam, needRom)
        {
            this.name = name;
            this.needRam = needRam;
            this.needRom = needRom;
            type = POTYPE.Game;
        }

        public override void Starting(Computer<ProgrammingSoftware> pc)
        {
            if (Check.CheckNeedSystemSoft(pc, "DirectX"))
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

        public override void Starting(Computer<ProgrammingSoftware> pc)
        {
            base.Starting(pc);
            Console.Write("сапер запущен\n");
        }
    }

    abstract class MaliciousProgrammingSoftware : SystemProgrammingSoftware
    {
        public MaliciousProgrammingSoftware(string name, float needRom, float needRam) : base(name, needRom, needRam)
        {
            type = POTYPE.SystemSoftware;
        }
        

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