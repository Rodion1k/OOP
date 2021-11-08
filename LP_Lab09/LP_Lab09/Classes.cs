using System;

using System.Collections.Generic;


namespace LP_Lab09
{
   
    public class User
    {
        
      
        public delegate void OperSoft(Computer pc,ProgrammingSoftware soft);
        public delegate void OperDataSoft(ProgrammingSoftware soft,float coefficient);
        public event OperSoft MOVE;
        public event OperDataSoft COMPRESS;
      

        public bool TryMove(Computer pc1, Computer pc2, ProgrammingSoftware PO)
        {
            foreach (var soft in pc1.programmingSoft)
            {
                if (ISFound(soft, PO.name))
                {
                    if (MOVE != null)
                    { 
                        MOVE.Invoke(pc2,soft);
                        return true;
                    }
                    return false;
                }
            }
        
            return false;
        }

        
        public bool CompressPO(Computer pc,ProgrammingSoftware PO, float coefficient)
        {
            foreach (var soft in pc.programmingSoft)
            {
                if (ISFound(soft,PO.name))
                {
                    if (COMPRESS != null)
                    {
                        COMPRESS.Invoke(soft,coefficient);
                        return true;
                    }
                    return true;
                }
            }
            return false;
        }
        private bool ISFound(ProgrammingSoftware software, string name) => software.name == name; 
    }

    public abstract class ProgrammingSoftware
    {
        public string name;
        public float needRom;

        
        public ProgrammingSoftware(string name, float needRom)
        {
            this.name = name;
            this.needRom = needRom;
            
            
        }
       
    }

    class Game : ProgrammingSoftware
    {
        public Game(string name, float needRam, float needRom) : base(name, needRom)
        {
        }
    }

    class SystemProgrammingSoftware : ProgrammingSoftware
    {
            
        public SystemProgrammingSoftware(string name, float needRam, float needRom) : base(name, needRom)
        {
        }
    }
    public class Computer
    {
        public List<ProgrammingSoftware> programmingSoft;
        private User user;
        public Computer()
        {
            programmingSoft = new List<ProgrammingSoftware>();
        }

        public void AddUser(User user)
        {
            this.user = user;
            user.MOVE += MoveSoft;
            user.COMPRESS += CompressSoft;
        }

        private void CompressSoft(ProgrammingSoftware soft, float coefficient) => soft.needRom /= coefficient;
        // {
        //     soft.needRom /= coefficient;
        // }
        
        private void MoveSoft(Computer pc2,ProgrammingSoftware soft)
        {
            pc2.programmingSoft.Add(soft);
            programmingSoft.Remove(soft);
        }

    }
}