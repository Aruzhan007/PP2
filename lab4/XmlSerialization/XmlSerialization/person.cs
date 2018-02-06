using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlSerialization
{
    [Serializable]
    public class person
    {
        public string name, surname;
        [NonSerialized]
        public int age;
        public List<Workplace> works = new List<Workplace>();

        public person() { }
        public person(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }
        public person(string name, string surname, int age)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
        }
    }
}
