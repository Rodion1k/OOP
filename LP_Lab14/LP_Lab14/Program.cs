using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace LP_Lab14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            // первое задание
            Game tanks = new Game("world of tanks", 100, 3000);
            Game ships = new Game("world of warships", 200, 4404);
            Game planes = new Game("world of warplanes", 400, 5000);
            //Game tanks = new Game();
            CustomSerializer<Game>.Serialize(tanks,SERIALIZETYPE.JSON,@"D:\GitHub\OOP\LP_Lab14\LP_Lab14\DATA");
            CustomSerializer<Game>.Serialize(tanks,SERIALIZETYPE.XML,@"D:\GitHub\OOP\LP_Lab14\LP_Lab14\DATA");
            CustomSerializer<Game>.Serialize(tanks,SERIALIZETYPE.SOAP,@"D:\GitHub\OOP\LP_Lab14\LP_Lab14\DATA");
            CustomSerializer<Game>.Serialize(tanks,SERIALIZETYPE.Binary,@"D:\GitHub\OOP\LP_Lab14\LP_Lab14\DATA");
            var binTanks= CustomSerializer<Game>.Deserialize(@"D:\GitHub\OOP\LP_Lab14\LP_Lab14\DATA\LP_Lab14.Game.bin");
            var xmlTanks= CustomSerializer<Game>.Deserialize(@"D:\GitHub\OOP\LP_Lab14\LP_Lab14\DATA\LP_Lab14.Game.xml");
            var soapTanks= CustomSerializer<Game>.Deserialize(@"D:\GitHub\OOP\LP_Lab14\LP_Lab14\DATA\LP_Lab14.Game.soap");
            var jsonTanks= CustomSerializer<Game>.Deserialize(@"D:\GitHub\OOP\LP_Lab14\LP_Lab14\DATA\LP_Lab14.Game.json");
            // второе задание 
            List<Game> games = new List<Game>() { tanks, ships, planes };
            CustomSerializer<Game>.Serialize(games,SERIALIZETYPE.JSON,@"D:\GitHub\OOP\LP_Lab14\LP_Lab14\DATA");
            CustomSerializer<Game>.Serialize(games,SERIALIZETYPE.XML,@"D:\GitHub\OOP\LP_Lab14\LP_Lab14\DATA");
            var xmlList = CustomSerializer<Game>.DeserializeToList(
                @"D:\GitHub\OOP\LP_Lab14\LP_Lab14\DATA\System.Collections.Generic.List`1[LP_Lab14.Game].xml");
            var jsonList = CustomSerializer<Game>.DeserializeToList(
                @"D:\GitHub\OOP\LP_Lab14\LP_Lab14\DATA\System.Collections.Generic.List`1[LP_Lab14.Game].json");
            // третье задание 
            XMLSelector.SelectByName("world of tanks",@"D:\GitHub\OOP\LP_Lab14\LP_Lab14\DATA\System.Collections.Generic.List`1[LP_Lab14.Game].xml");
            XMLSelector.SelectByPo("Game",@"D:\GitHub\OOP\LP_Lab14\LP_Lab14\DATA\System.Collections.Generic.List`1[LP_Lab14.Game].xml");
            // четвертое задание
            XDocument xDocument = new XDocument();
            XElement plane = new XElement("game");
            XAttribute nameAttr = new XAttribute("name", "plane20");
            XElement yearElem = new XElement("releaseYear", "2020");
            plane.Add(nameAttr);
            plane.Add(yearElem);
            
            XElement ship = new XElement("game");
            nameAttr = new XAttribute("name", "ship10");
            yearElem = new XElement("releaseYear", "2010");
            ship.Add(nameAttr);
            ship.Add(yearElem);

            XElement gamesElement = new XElement("games");
            gamesElement.Add(plane);
            gamesElement.Add(ship);
            xDocument.Add(gamesElement);
            xDocument.Save(@"D:\GitHub\OOP\LP_Lab14\LP_Lab14\Games.xml");
            Console.WriteLine("запрос");
            var allGames = gamesElement.Elements("game");
            foreach (var game in allGames)
            {
                if (game.Attribute("name").Value == "plane20")
                    Console.WriteLine(game.Attribute("name").Value);
            }
            
            
        }
    }
}