using System.Xml.Serialization;

namespace RegistryEditor.Helper
{
    public static class XmlHelper
    {
        public const string ConfigurationFile = "./RegistryEditorConfiguration.xml";

        public static T Load<T>() where T : new()
        {
            using (var stream = System.IO.File.OpenRead(ConfigurationFile))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stream);
            }
        }

        public static void Save<T>(this T obj) where T : new()
        {
            using (var writer = new System.IO.StreamWriter(ConfigurationFile))
            {
                var serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(writer, obj);
                writer.Flush();
            }
        }
    }
}
