using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LP_Lab12
{
    public static class Reflector
    {
        public static string GetAssemblyName(object obj) => obj.GetType().Assembly.FullName;
        public static bool HasConstructors(object obj) => obj.GetType().
            GetConstructors(BindingFlags.Public | BindingFlags.Instance).Length!=0;

        public static IEquatable<string> GetPublicMethods(object obj) =>
            obj.GetType().GetMethods(BindingFlags.Public | BindingFlags.DeclaredOnly).ToString(); // переделать

        public static IEquatable<string> GetIntefaces(object obj) => obj.GetType().GetInterfaces().ToString(); // переделать

        public static void GetMethodsByParms(object obj,string name) =>
            obj.GetType().GetMethods().Where(n=>n.ReflectedType.Name==name).ToList().ForEach(x=>Console.WriteLine(x)); // не работатет, нужно преобразовать стринг в тип и взять метод

        
        public static void GetMethodsByParam(object ob, string par)
            => ob
                .GetType()
                .GetMethods()
                .Where(x => x.GetParameters().Any(n => n.ToString() == par))
                .ToList()
                .ForEach(x => Console.Write($"{x.Name} "));

        public static object Create(Type type,string parm)
        {
            var constr = type.GetConstructor(new Type[]
            {
                typeof(string)
            });

            object obj = constr?.Invoke(new object[] {parm});
            return obj;
        }

        public static void Invoke(object obj, string name)
        {
            List<string> parms = new List<string>();
            ReadFromFile(ref parms);
            Type type = obj.GetType();
            MethodInfo methodInfo = type.GetMethod(name);
            methodInfo?.Invoke(obj, new object[] {parms[0],Convert.ToChar(parms[1])});
        }

        private static void ReadFromFile(ref List<string> list)
        {
            using StreamReader reader = new StreamReader(@"D:\GitHub\OOP\LP_Lab12\LP_Lab12\kek.txt");
            
                while (!reader.EndOfStream)
                    list.Add(reader.ReadLine());
            
        }
        
    }
    
}