using System.Xml.Serialization;
namespace RegistryEditor.Models
{
    public class RegistryEntry
    {
        public string Path { get; set; }

        [XmlIgnore]
        public bool IsChecked { get; set; }
        [XmlIgnore]
        public bool IsMissing { get; set; }
    }
}
