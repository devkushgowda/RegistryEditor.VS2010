using System;
using RegistryEditor.Models;

namespace RegistryEditor.Helper
{
    public static class ConfigurationHelper
    {
        private static readonly Lazy<GroupRegistryConfiguration> _configuration =
            new Lazy<GroupRegistryConfiguration>(() => Load());

        public static GroupRegistryConfiguration Configuration { get { return _configuration.Value; } }

        private static GroupRegistryConfiguration Load()
        {
            //var configuration = new GroupRegistryConfiguration()
            //{
            //    Groups = new List<RegistryGroup>()
            //    {
            //    new RegistryGroup("Session Summary",true){RegistryValues = new List<RegistryEntry>(){new RegistryEntry(){Path ="TestPath" }}},
            //    new RegistryGroup("Handles",true){RegistryValues = new List<RegistryEntry>(){new RegistryEntry(){Path ="TestPath" }}},
            //    new RegistryGroup("Factory Automation",true){RegistryValues = new List<RegistryEntry>(){new RegistryEntry(){Path ="TestPath" }}},
            //    new RegistryGroup("Wafer Location",true){RegistryValues = new List<RegistryEntry>(){new RegistryEntry(){Path ="TestPath" }}},
            //    new RegistryGroup("Scan Data",true){RegistryValues = new List<RegistryEntry>(){new RegistryEntry(){Path ="TestPath" }}},
            //    new RegistryGroup("Diagnostic",true){RegistryValues = new List<RegistryEntry>(){new RegistryEntry(){Path ="TestPath" }}},
            //    new RegistryGroup("Custom"){},
            //    }
            //};
            var configuration = XmlHelper.Load<GroupRegistryConfiguration>();
            //configuration.Save();
            return configuration;
        }

        public static void Save()
        {
            Configuration.Save();
        }
    }
}
