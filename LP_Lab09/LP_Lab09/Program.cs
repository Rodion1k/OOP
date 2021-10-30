using System;
using System.IO;

namespace LP_Lab09
{
   
    class Program
    {
        static void Main(string[] args)
        {
            Computer pc1 = new Computer();
            User user1 = new User();
            Computer pc2 = new Computer();
            pc1.AddUser(user1);
            Game sapper = new Game("saper", 800, 1000);
            SystemProgrammingSoftware systemSoft = new SystemProgrammingSoftware("kek", 100, 200);
            pc1.programmingSoft.Add(systemSoft);
            pc1.programmingSoft.Add(sapper);
            user1.CompressPO(pc1,sapper,2.5f);
            user1.TryMove(pc1, pc2, sapper);
            // второе задание
            string str = "hello:, world";
            Func<string,string> stringDelegat;
            Func<string,string,char,string> stringDelegat2;
            Console.WriteLine($"\n\n\nString: {str}");
            stringDelegat = StringEditor.RemovePunctuation;
            Console.WriteLine($"{stringDelegat.Method.Name}: {stringDelegat(str)}");
            stringDelegat = StringEditor.RemoveSpaces;
            Console.WriteLine($"{stringDelegat.Method.Name}: {stringDelegat(str)}");// посмотреть что за {} в console.write
            stringDelegat = StringEditor.CreateTitle;
            Console.WriteLine($"{stringDelegat.Method.Name}: {stringDelegat(str)}");
            stringDelegat = StringEditor.ToLower;
            Console.WriteLine($"{stringDelegat.Method.Name}: {stringDelegat(str)}");
            stringDelegat2 = StringEditor.InsertFromSymbol;
             Console.WriteLine($"{stringDelegat.Method.Name}: {stringDelegat2(str,"kok",'w')}");

        }

    }
}