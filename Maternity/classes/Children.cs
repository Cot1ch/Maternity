using System.Xml.Serialization;

namespace Maternity
{
    public class Children
    {
        [XmlElement("Child")]
        public Child[] children { get; set; }
    }
}
