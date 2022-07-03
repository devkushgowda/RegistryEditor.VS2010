using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace RegistryEditor.Models
{
    [XmlRoot("Configuration")]
    public class RegistryEditorConfiguration
    {
        public static readonly string ConfigurationPath = Directory.GetCurrentDirectory();

        public string DefaultBackupFolder { get; set; }

        public string RootRegistryPath { get; set; }

        public string LogFolderPath { get; set; }

        [XmlArrayItem("Group")]
        public List<RegistryGroup> Groups = new List<RegistryGroup>();
    }
}