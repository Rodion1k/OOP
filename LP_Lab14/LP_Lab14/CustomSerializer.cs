using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Xml.Serialization;

namespace LP_Lab14
{
    public enum SERIALIZETYPE
    {
        Binary, 
        SOAP, 
        JSON, 
        XML,
    }
    public static class CustomSerializer<T> where T : class
    {
        public static void Serialize(List<T> list, SERIALIZETYPE type, string path)
        {
            switch (type)
            {
                case SERIALIZETYPE.XML:
                    XmlSerializer xs = new XmlSerializer(typeof(List<T>));
                    using (FileStream fileStream = new FileStream(path+$@"\{list.GetType()}.xml", FileMode.OpenOrCreate))
                    {
                        xs.Serialize(fileStream, list);
                    }

                    break;
                case SERIALIZETYPE.JSON:
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<T>));
                    using (FileStream fileStream = new FileStream(path+$@"\{list.GetType()}.json", FileMode.OpenOrCreate))
                    {
                        js.WriteObject(fileStream, list);
                    }

                    break;
                default: throw new Exception($"can not serialize list of type {type}");
            }
            
        }
        public static void Serialize(T obj, SERIALIZETYPE type, string path)
        {
            switch (type)
            {
                case SERIALIZETYPE.Binary:
                    BinaryFormatter bf = new BinaryFormatter();
                    using (FileStream fileStream = new FileStream(path+$@"\{obj.GetType()}.bin", FileMode.OpenOrCreate))
                    {
                        bf.Serialize(fileStream, obj);
                    }

                    break;
                case SERIALIZETYPE.XML:
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    using (FileStream fileStream = new FileStream(path+$@"\{obj.GetType()}.xml", FileMode.OpenOrCreate))
                    {
                        xs.Serialize(fileStream, obj);
                    }

                    break;
                case SERIALIZETYPE.JSON:
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(T));
                    using (FileStream fileStream = new FileStream(path+$@"\{obj.GetType()}.json", FileMode.OpenOrCreate))
                    {
                        js.WriteObject(fileStream, obj);
                    }

                    break;
                case SERIALIZETYPE.SOAP:
                    SoapFormatter sf = new SoapFormatter();
                    using (FileStream fileStream = new FileStream(path+$@"\{obj.GetType()}.soap", FileMode.OpenOrCreate))
                    {
                        
                        sf.Serialize(fileStream, obj);
                    }

                    break;
            }
        }

        public static List<T> DeserializeToList(string path)
        {
            string format = path.Split('.').Last();
            List<T> list = null;
            switch (format)
            {
                case "xml":
                    XmlSerializer xs = new XmlSerializer(typeof(List<T>));
                    using (FileStream fileStream = new FileStream(path, FileMode.Open))
                    {
                        list = (List<T>)xs.Deserialize(fileStream);
                    }

                    break;
                case "json":
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<T>));
                    using (FileStream fileStream = new FileStream(path, FileMode.Open))
                    {
                        list = (List<T>)js.ReadObject(fileStream);
                    }

                    break;

                default: throw new Exception("can not deserialize\n");
            }
            return list;
        }

        public static T Deserialize(string path)
        {
            string format = path.Split('.').Last();
            T exemp = null;

            switch (format)
            {
                case "bin":
                    BinaryFormatter bf = new BinaryFormatter();
                    using (FileStream fileStream = new FileStream(path, FileMode.Open))
                    {
                        exemp = (T)bf.Deserialize(fileStream);
                    }

                    break;
                case "xml":
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    using (FileStream fileStream = new FileStream(path, FileMode.Open))
                    {
                        exemp = (T)xs.Deserialize(fileStream);
                    }

                    break;
                case "json":
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Game));
                    using (FileStream fileStream = new FileStream(path, FileMode.Open))
                    {
                        exemp = (T)js.ReadObject(fileStream);
                    }

                    break;
                case "soap":
                    SoapFormatter sf = new SoapFormatter();
                    using (FileStream fileStream = new FileStream(path, FileMode.Open))
                    {
                        exemp = (T)sf.Deserialize(fileStream);
                    }

                    break;
                default: throw new Exception("can not deserialize\n");

            }

            return exemp;
        }

    }
}
// case "bin":
// BinaryFormatter bf = new BinaryFormatter();
// using (FileStream fs = new FileStream(file, FileMode.Open))
// {
//     Car car = (Car)bf.Deserialize(fs);
//     Console.WriteLine($"Deserialized car: {car.Brand} {car.Model}");
// }
// break;