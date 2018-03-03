using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace XmlSerialization
{
    class Program
    {
      /* public  static void Xml()
        {
           // XmlSerializer xs = new XmlSerializer(typeof(person));
            FileStream fs = new FileStream("data.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            person a = new person("Baglan", "Bialieva", 40);
            a.works.Add(new Workplace("bank"));

            xs.Serialize(fs, a);
            fs.Close();
        }*/
        static void Binorm()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            person a = new person("Baglan", "Bialieva", 40);
            a.works.Add(new Workplace("bank"));
            bf.Serialize(fs,a);
            /*person b = bf.Deserialize(fs) as person;
            Console.WriteLine(b.name + " " + b.works[1].name);
*/

            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Binorm();
        }

    }
}