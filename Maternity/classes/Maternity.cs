using System;
using System.Xml;
using System.Xml.Serialization;


namespace Maternity
{
    [XmlRoot("Maternity")]
    public class Maternity
    {
        [XmlElement("Id")]
        public Guid Id { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Boss")]

        public Boss Boss { get; set; }
        [XmlElement("Doctors")]
        public Doctors docs { get; set; }
        [XmlElement("Midwives")]
        public MidWives mids { get; set; }
        [XmlElement("Patients")]
        public Patients patients { get; set; }
        [XmlElement("Children")]
        public Children children{ get; set; }

        public Maternity() { }
    }
}
