using System.Xml.Serialization;

namespace Maternity
{
    public class MidWives
    {
        [XmlElement("Midwife")]
        public MidWife[] midWives { get; set; }
    }
}
