using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Maternity
{
    public class Doctor
    {
        [XmlElement("Id")]
        public Guid Id { get; set; }
        [DisplayName("Имя")]
        [XmlElement("Name")]
        public string Name { get; set; }
        [DisplayName("Фамилия")]
        [XmlElement("SurName")]
        public string Surname { get; set; }
        [XmlElement("BirthDate")]
        public string BirthDate { get; set; }
        [XmlElement("Sex")]
        public string Sex { get; set; }
        [XmlElement("patient")]
        public Guid Patient {  get; set; }
    }
}
