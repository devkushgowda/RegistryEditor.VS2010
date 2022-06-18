using System.Xml.Serialization;
namespace RegistryEditor.Models
{
    public class RegistryEntry
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlIgnore]
        public bool IsChecked { get; set; }
        [XmlIgnore]
        public bool IsMissing { get; set; }

        [XmlIgnore]
        public string Path
        {
            get { return Constants.RootRegistryPath + "\\" + Name; }
        }
    }
}
