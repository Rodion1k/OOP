using System;
using System.Runtime.InteropServices.ComTypes;
using System;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
namespace LP_Lab14
{
    [Serializable]
    public abstract class ProgrammingSoftware 
    {
        public string name;
        public float needRam;
        public float needRom;
        [NonSerialized]
        public string version;
        public ProgrammingSoftware(string name, float needRam, float needRom)
        {
            this.name = name;
            this.needRam = needRam;
            this.needRom = needRom;
        }
        public ProgrammingSoftware(){}

        public override string ToString() => GetType().Name;
        public override bool Equals(object obj) => GetType().Name == obj.ToString();

    }

    [Serializable]
    public class Game : ProgrammingSoftware
    {
        public Game(string name, float needRam, float needRom) : base(name, needRam, needRom)
        {
            this.name = name;
            this.needRam = needRam;
            this.needRom = needRom;
        }
        public Game(){}

    }
}