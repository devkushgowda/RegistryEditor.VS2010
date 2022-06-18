using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace RegistryEditor.Models
{
    public class GroupRegistryConfiguration
    {
        public static readonly string ConfigurationPath = Directory.GetCurrentDirectory();

        [XmlArrayItem("Group")]
        public List<RegistryGroup> Groups = new List<RegistryGroup>();
    }
}