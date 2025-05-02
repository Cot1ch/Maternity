using System.Xml.Serialization;

namespace Maternity
{
    public class Patients
    {
        [XmlElement("Patient")]
        public Patient[] patients { get; set; }
    }
}
