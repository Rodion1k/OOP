using System;
using System.Collections.Generic;
namespace LP_Lab05
{
    public class Controller
    {
        public List<Computer<ProgrammingSoftware>> computers;

        public Controller()
        {
            computers = new List<Computer<ProgrammingSoftware>>();
        }

        public void AddPc(Computer<ProgrammingSoftware> pc)
        {
            computers.Add(pc);
        }
        public void DelPc(Computer<ProgrammingSoftware> pc)
        {
            computers.Remove(pc);
        }
        
        public ProgrammingSoftware FindNeedWordVersion(string name,string type)
        {
            foreach (var pc in computers)
            {
                foreach (var soft in pc.InstaledSoft)
                {
                    if (soft.GetType().Name == "Word")
                    {
                        if (soft.version == type && soft.name == name)
                        {
                            Console.Write("найден на ПК: "+pc.name);
                            Console.WriteLine();
                            return soft;
                        }
                    }
                }

            }
          
            return null;
        }
        public void FindGamesType(Game.GameType gameType)
        {
            Console.Write("игры типа "+gameType+":\n");
            foreach (var pc in computers)
            {
                foreach (var soft in pc.InstaledSoft)
                {
                    if (soft.type == POTYPE.Game)
                    {
                        var tempsoft = (Game)soft;
                        if (tempsoft.gameInfo._type == gameType)
                            Console.Write("игра: "+soft.name+"на компе: "+pc.name);
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}