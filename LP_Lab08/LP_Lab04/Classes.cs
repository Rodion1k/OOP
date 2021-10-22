using System;

namespace LP_Lab04
{
    abstract class ProgrammingSoftware
    {
        public string name;
        public ProgrammingSoftware(string name)
        {
            this.name = name;
        }

        public override string ToString() => name;
    }
    class Word : ProgrammingSoftware
    {
        public Word(string name):base(name)
        {
            
        }
    }
    class Game : ProgrammingSoftware 
    {
        public Game(string name):base(name)
        {
            
        }
       

    }
    
}