using System;
using System.Xml.Serialization;


namespace Maternity
{
    public class Patient
    {
        [XmlElement("Id")]
        public Guid Id { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("SurName")]
        public string Surname { get; set; }
        [XmlElement("BirthDate")]
        public string BirthDate { get; set; }
        [XmlElement("Sex")]
        public string Sex { get; set; }
        [XmlElement("Children")]
        public Guid Child { get; set; }
    }
}
