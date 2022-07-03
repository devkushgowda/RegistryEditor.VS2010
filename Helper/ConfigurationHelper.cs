using System;
using RegistryEditor.Models;

namespace RegistryEditor.Helper
{
    public static class ConfigurationHelper
    {
        private static readonly Lazy<RegistryEditorConfiguration> _configuration =
            new Lazy<RegistryEditorConfiguration>(() => Load());

        public static RegistryEditorConfiguration Configuration { get { return _configuration.Value; } }

        private static RegistryEditorConfiguration Load()
        {
            var configuration = XmlHelper.Load<RegistryEditorConfiguration>();
            return configuration;
        }

        public static void Save()
        {
            Configuration.Save();
        }
    }
}
