using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace XmlSerialization
{
    class Program
    {
       public  static void Xml()
        {
            XmlSerializer xs = new XmlSerializer(typeof(person));
            FileStream fs = new FileStream("data.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            person a = new person("Baglan", "Bialieva", 40);
            a.works.Add(new Workplace("bank"));

            xs.Serialize(fs, a);
            fs.Close();
        }
        static void Binform()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            person b = bf.Deserialize(fs) as person;
            Console.WriteLine(b.name + " " + b.works[1].name);
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Xml();
        }
    }
}