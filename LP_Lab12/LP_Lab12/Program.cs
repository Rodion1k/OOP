using System;
using System.Runtime.InteropServices.ComTypes;

namespace LP_Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game("tanks",200,3000,Game.GameType.shooter);
            Word word = new Word("word",200,100,"2");
           Console.WriteLine( Reflector.GetAssemblyName(game));
           Console.WriteLine(Reflector.HasConstructors(game));
           var list = Reflector.GetPublicMethods(game);
          Reflector.GetMethodsByParms(game,"Object");
         Developer developer = new Developer("Rodion");
           Reflector.GetMethodsByParam(developer,"String name"); // работает с int32
           Reflector.GetMethodsByParam(developer,"Int32 i");
          var kek= Reflector.Create(developer.GetType(), "sasha");
          Printer printer = new Printer();
          Console.WriteLine();
          Reflector.Invoke(printer,"CreateTitle");
          Console.WriteLine();
        }
    }
}