using System.Xml.Serialization;

namespace Maternity
{
    public class Doctors
    {
        [XmlElement("Doctor")]
        public Doctor[] docs {  get; set; }
    }
}
