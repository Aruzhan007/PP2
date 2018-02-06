using System;
namespace XmlSerialization
{
    [Serializable]
    public class Workplace
    {
        public string name;
        public Workplace(){ }

        public Workplace(string name)
        {
            this.name = name;
        }
    }
}
