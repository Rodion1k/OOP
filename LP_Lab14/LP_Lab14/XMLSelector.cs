using System;
using System.Xml;
using System.Linq;
using System.Text.RegularExpressions;
namespace LP_Lab14
{
    public static class XMLSelector
    {
        public static void SelectByName(string name,string path)
        { 
            if (path.Split('.').Last() != "xml")
                throw new Exception("not xml document");
            Console.WriteLine("******select by name******");
            Regex regex = new Regex(@"<name>(?<N>[\s\w]+)\</name><needRam>(?<Ra>\d+)</needRam><needRom>(?<Ro>\d+)</needRom>");
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            XmlElement xRoot = xmlDocument.DocumentElement;
            XmlNodeList xmlNode = xRoot?.SelectNodes("*");
            foreach (XmlNode node in xmlNode)
            {
                if(regex.Match(node.InnerXml).Groups["N"].Value==name)
                    Console.WriteLine($"{regex.Match(node.InnerXml).Groups["N"].Value},{regex.Match(node.InnerXml).Groups["Ra"].Value},{regex.Match(node.InnerXml).Groups["Ro"].Value}");
            }
        }
        public static void SelectByPo(string poName,string path)
        {
            if (path.Split('.').Last() != "xml")
                throw new Exception("not xml document");
            Console.WriteLine("*****select by PO name******");
            Regex regex = new Regex(@$"<{poName}><name>(?<N>[\s\w]+)\</name><needRam>(?<Ra>\d+)</needRam><needRom>(?<Ro>\d+)</needRom></{poName}>");
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            XmlElement xRoot = xmlDocument.DocumentElement;
            XmlNodeList xmlNode = xRoot?.SelectNodes("*");
            foreach (XmlNode node in xmlNode)
            {
                if(regex.IsMatch(node.OuterXml))
                    Console.WriteLine($"{regex.Match(node.OuterXml).Groups["N"].Value},{regex.Match(node.OuterXml).Groups["Ra"].Value},{regex.Match(node.OuterXml).Groups["Ro"].Value}");
            }
            
         
        }

    }
}