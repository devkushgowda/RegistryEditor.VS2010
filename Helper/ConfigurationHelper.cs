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
            var configuration = XmlHelper.Load<GroupRegistryConfiguration>();
            return configuration;
        }

        public static void Save()
        {
            Configuration.Save();
        }
    }
}
