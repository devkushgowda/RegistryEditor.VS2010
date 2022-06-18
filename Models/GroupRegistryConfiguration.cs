using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace RegistryEditor.Models
{
    [XmlRoot("Configuration")]
    public class GroupRegistryConfiguration
    {
        public static readonly string ConfigurationPath = Directory.GetCurrentDirectory();

        public string LogFolderPath { get; set; }

        [XmlArrayItem("Group")]
        public List<RegistryGroup> Groups = new List<RegistryGroup>();
    }
}