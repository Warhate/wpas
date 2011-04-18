using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;


namespace Layout
{
   public class SerializHelper
    {

        /// <summary>
        /// Сереализирует обект карты
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="map">Обект карты</param>
        public static void SaveMap(String name, Map map)
        {
            Stream stream = File.Open(@"maps/"+name+".map", FileMode.OpenOrCreate);
            Stream sr = Stream.Null; 
            BinaryFormatter bf = new BinaryFormatter();
            
            bf.Serialize(stream, map);

            stream.Close();

        }

        /// <summary>
        /// Сереализирует обект карты
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="map">Обект карты</param>
        public static void SaveMap(String name, Map map,int i)
        {
            Stream stream = File.Open(name + ".map", FileMode.OpenOrCreate);
            Stream sr = Stream.Null;
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(stream, map);

            stream.Close();

        }


        /// <summary>
        /// Десерилезирует карту
        /// </summary>
        /// <param name="name">Имя карты</param>
        /// <returns>Обект карты</returns>
        public static Map OpenMapFile(String name)
        {


            Stream stream = File.Open(name, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            Map map = (Map)bf.Deserialize(stream);

            stream.Close();
            return map;


        }
    }
}
