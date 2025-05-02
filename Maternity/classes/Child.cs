using System;
using System.Xml.Serialization;

namespace Maternity
{
    public class Child
    {
        [XmlElement("Id")]
        public Guid Id { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("BirthDate")]
        public string BirthDate { get; set; }

    }
}
