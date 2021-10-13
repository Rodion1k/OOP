using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Newtonsoft.Json;

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
                            Console.Write("игра: "+soft.name+" на компе: "+pc.name);
                        Console.WriteLine();
                    }
                }
            }
        }

        public void ParseTextFile(Computer<ProgrammingSoftware> pc)
        {
            using StreamReader streamReader =
                new StreamReader(@"D:\GitHub\OOP\LP_Lab05\LP_Lab05\ProgrammingSoftware.txt");
            
            while (streamReader.ReadLine() is string line)      // или  while (stream.ReadLine() is string line)
            {
                int length = 0;
                length=line.IndexOf(']')-line.IndexOf('[');
                if (line.Substring(line.IndexOf('[')+1,length-1) == "Game")
                {
                    string temp = GetStringParms(line);
                    pc.Instal(new Game(GetParms(ref temp),Convert.ToSingle(GetParms(ref temp)),
                        Convert.ToSingle(GetParms(ref temp)),
                        (Game.GameType)Enum.Parse(typeof(Game.GameType),GetParms(ref temp))));
                }
                else if (line.Substring(line.IndexOf('[')+1,length-1) == "Word")
                {
                    // лень
                    // pc.Instal(new Word());
                }
                
            }
        }

        public void ParseJsonFile(Computer<ProgrammingSoftware> pc)
        {
            using StreamReader streamReader =
                new StreamReader(@"D:\GitHub\OOP\LP_Lab05\LP_Lab05\ProgrammingSoftware.json");
            string json = streamReader.ReadToEnd();
            Game game = JsonConvert.DeserializeObject<Game>(json); // не получилось init type Game
        }

        private string GetParms(ref string line)
        {
            int length = line.IndexOf(',');
            string newLine = line.Substring(0,length );
            line = line.Remove(0, length+1);
            return newLine;
        }
       
        private string GetStringParms(string line)
        {
            int length = 0;
            length=line.IndexOf(')')-line.IndexOf('(');
            return line.Substring(line.IndexOf('(')+1,length-1).Trim(new char[]{ '(',')'});
        }
        
        
        
    }
}