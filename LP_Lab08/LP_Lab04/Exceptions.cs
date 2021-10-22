using System;
namespace LP_Lab04
{
    public class IndexException:Exception
    {
        public IndexException(string massage) : base(massage) => Console.WriteLine(massage);
    }
    // public class Exception:Exception
    // {
    //     public IndexException(string massage) : base(massage) => Console.WriteLine(massage);
    // }
}