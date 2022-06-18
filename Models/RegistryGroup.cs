using System.Collections.Generic;
using System.Xml.Serialization;

namespace RegistryEditor.Models
{
    public class RegistryGroup
    {
        public RegistryGroup() : base()
        {
            RegistryValues = new List<RegistryEntry>();
        }

        public RegistryGroup(string name, bool isReadOnly) : this()
        {
            Name = name;
            IsReadOnly = isReadOnly;
        }
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public bool IsReadOnly { get; set; }

        [XmlArrayItem("Registry")]
        public List<RegistryEntry> RegistryValues { get; set; }
    }
}