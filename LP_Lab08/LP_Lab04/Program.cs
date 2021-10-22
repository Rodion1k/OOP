using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LP_Lab04;

namespace LP_Lab04
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      try
      {
        Game newgame = new Game("lol");
        Word neWord = new Word("kek");
        Array<ProgrammingSoftware> kek = new Array<ProgrammingSoftware>(5);
        kek.Add(newgame, 0);
        kek.Add(neWord, 1);
        kek.Show();
        kek.Del(newgame);
        kek.Show();
        string mam = "mam";
        Array<string> strArray = new Array<string>(10);
        strArray.Add(mam,0);
        Streamer.ReadFile(ref strArray);
        strArray.Show();
        Streamer.WriteFile(strArray);
        Console.ReadKey();
      }
      catch (IndexException e)
      {
        Console.WriteLine(e);
      }
      finally
      {
        Console.WriteLine("end of program");
      }
    }
  }
}