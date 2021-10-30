using System;
using System.Collections.Generic;
using LP_Lab05.Exceptions;

namespace LP_Lab05
{
    public enum POTYPE
    {
        Game,
        SystemSoftware,
        OtherSoftware,
    }

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

            throw new PcExc("ПК выключен, ошибка\n");
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
        public SystemProgrammingSoftware(string name, float needRam, float needRom) : base(name, needRam, needRom)
        {
        }

    }

    class DirectX : SystemProgrammingSoftware
    {
       
        public DirectX(string name, float needRam, float needRom, string version) : base(name, needRam, needRom)
        {
            this.version = version;
            type = POTYPE.SystemSoftware;
        }

    }

    class WordProcessor : SystemProgrammingSoftware
    {
        private string _version;

        public WordProcessor(string name, float needRam, float needRom, string version) : base(name, needRam, needRom)
        {
            this._version = version;
            type = POTYPE.SystemSoftware;
        }

    }

    class Word : ProgrammingSoftware
    {
        public Word(string name, float needRam, float needRom,string version) : base(name, needRam, needRom)
        {
            this.version = version;
            type = POTYPE.OtherSoftware;
        }

        public override void Starting(Computer<ProgrammingSoftware> pc)
        {
            if (Check.CheckNeedSystemSoft(pc, "WordProcessor"))
            {
                base.Starting(pc);
            }
            else
            {
                throw new SoftExc("нету необходимого Системного ПО wordproc\n");
            }
        }
    }

    public class Game : ProgrammingSoftware 
    {
        public GameS gameInfo;
        public enum GameType
        {
            shooter=1,
            strategy,
            arcade,
        }
        
        public struct GameS
        {
            public GameType _type;
            
        }
      
        public Game(string name, float needRam, float needRom,GameType tipe ) : base(name, needRam, needRom)
        {
            this.name = name;
            this.needRam = needRam;
            this.needRom = needRom;
            type = POTYPE.Game;
            gameInfo._type = tipe;
        }

        public override void Starting(Computer<ProgrammingSoftware> pc)
        {
            if (Check.CheckNeedSystemSoft(pc, "DirectX"))
            {
                base.Starting(pc);
            }
            else
            {
                throw new SoftExc("установите DirectX\n");
            }
        }
      


    }
    class Sapper : Game
    {
        public Sapper(string name, float needRam, float needRom,GameType tipe) : base(name, needRam, needRom,tipe)
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
        public MaliciousProgrammingSoftware(string name, float needRom, float needRam) : base(name, needRam, needRom)
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

    sealed class CConficker : Virus
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

    partial class Developer
    {
        // создает ПО
        public void CreatePO(string name)
        {
            Console.Write("создает " + name);
        }
    }
}