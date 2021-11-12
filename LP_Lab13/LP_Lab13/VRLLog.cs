using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace LP_Lab13
{
    static class VRLLog
    {
        public static void AddAction(string name, string path, string massage)
        {
            using StreamWriter writer = new StreamWriter(@"D:\GitHub\OOP\LP_Lab13\LP_Lab13\VRLlogfile.txt", true);
            writer.WriteLine($"Time: {DateTime.Now}");
            writer.WriteLine($"{name}: {path}\n{massage}");
            writer.WriteLine();

        }

        public static void ClearLogFile()
        {
            using StreamWriter writer = new StreamWriter(@"D:\GitHub\OOP\LP_Lab13\LP_Lab13\VRLlogfile.txt");
            writer.Close();
        }

        public static void CloseVRLLog()
        {
            using StreamWriter writer = new StreamWriter(@"D:\GitHub\OOP\LP_Lab13\LP_Lab13\VRLlogfile.txt", true);
            writer.Close();
        }

        public static void PrintInfoFromLogFile(DateTime date)
        {
            Console.WriteLine($"\nactions on the {date.Day}");
            using StreamReader reader = new StreamReader(@"D:\GitHub\OOP\LP_Lab13\LP_Lab13\VRLlogfile.txt", true);
            Regex regex =
                new Regex(@".*\s(?<day>\d\d).(?<month>\d\d).(?<year>\d\d\d\d)\s(?<h>\d\d):(?<m>\d\d):(?<s>\d\d)");
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (regex.IsMatch(line))
                {
                    line = line.Remove(0, 6);
                    if (DateTime.Compare(date, Convert.ToDateTime(line).Date) == 0)
                    {
                        Console.WriteLine("---------------");
                        Console.WriteLine(line);
                        Console.WriteLine(reader.ReadLine());
                        Console.WriteLine(reader.ReadLine());
                    }
                }
            }
            reader.Close();
        }

        public static void PrintInfoFromLogFile(string time1, string time2)
        {
            Console.WriteLine($"\nactions in the period between {time1} and {time2}");
            using StreamReader reader = new StreamReader(@"D:\GitHub\OOP\LP_Lab13\LP_Lab13\VRLlogfile.txt", true);
            Regex regex =
                new Regex(@".*\s(?<day>\d\d).(?<month>\d\d).(?<year>\d\d\d\d)\s(?<h>\d\d):(?<m>\d\d):(?<s>\d\d)");
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (regex.IsMatch(line))
                {
                    line = line.Remove(0, 6);
                    var lineTime = Convert.ToDateTime(line).TimeOfDay;
                    if (Convert.ToDateTime(time1).TimeOfDay <= lineTime &&
                        lineTime <= Convert.ToDateTime(time2).TimeOfDay)
                    {
                        Console.WriteLine("---------------");
                        Console.WriteLine(line);
                        Console.WriteLine(reader.ReadLine());
                        Console.WriteLine(reader.ReadLine());
                    }
                }
            }
            reader.Close();
        }

        public static void PrintInfoFromLogFile(string keyword)
        {
            Console.WriteLine($"\nkeyword({keyword}) actions");

            using StreamReader reader = new StreamReader(@"D:\GitHub\OOP\LP_Lab13\LP_Lab13\VRLlogfile.txt", true);
            Regex regex1 = new Regex(@".*\s(?<day>\d\d).(?<month>\d\d).(?<year>\d\d\d\d)\s(?<h>\d\d):(?<m>\d\d):(?<s>\d\d)");
            Regex regex2 = new Regex(@$".*{keyword}.*");
            List<string> tempStr = new List<string>();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (regex1.IsMatch(line))
                {
                    line += $"\n{reader.ReadLine()}\n{reader.ReadLine()}";
                    tempStr.Add(line);
                }
            }
            reader.Close();
            foreach (var temp in tempStr)
            {
                if (regex2.IsMatch(temp))
                    Console.WriteLine(temp);
            }
        }

        public static void DeleteInfoSkippingHour(int hour)
        {
            using StreamReader reader = new StreamReader(@"D:\GitHub\OOP\LP_Lab13\LP_Lab13\VRLlogfile.txt", true);
            Regex regex = new Regex(@".*\s(?<day>\d\d).(?<month>\d\d).(?<year>\d\d\d\d)\s(?<h>\d\d):(?<m>\d\d):(?<s>\d\d)");
            List<string> tempStr = new List<string>();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (regex.IsMatch(line))
                {
                    if (hour == Convert.ToInt32(regex.Match(line).Groups["h"].Value))
                    {
                        //line = line.Remove(0,6);
                        line += $"\n{reader.ReadLine()}\n{reader.ReadLine()}\n";
                        tempStr.Add(line);
                    }
                }
            }
            reader.Close();
           // ClearLogFile();
            using StreamWriter writer=new StreamWriter(@"D:\GitHub\OOP\LP_Lab13\LP_Lab13\VRLlogfile.txt");
            foreach (var temp in tempStr)
            {
                writer.WriteLine(temp);
            }
            
        }

        public static int GetCountInfoFromLogFile()
        {
            int count = 0;
            using StreamReader reader = new StreamReader(@"D:\GitHub\OOP\LP_Lab13\LP_Lab13\VRLlogfile.txt", true);
            Regex regex =
                new Regex(@".*\s(?<day>\d\d).(?<month>\d\d).(?<year>\d\d\d\d)\s(?<h>\d\d):(?<m>\d\d):(?<s>\d\d)");
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (regex.IsMatch(line))
                    count++;

            }
            reader.Close();
            return count;
        }
    }

 
}
