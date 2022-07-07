using System;
using System.IO;
using System.Linq;

namespace RegistryEditor.Helper
{
    public static class LogFilesHelper
    {
        public static void Copy(string source, string destination, DateTime from, DateTime to, string filter)
        {
            if (!Directory.Exists(source))
                return;
            Directory.CreateDirectory(destination);
            var dirInfo = new DirectoryInfo(source);
            var allFiles = filter.Split('|').SelectMany(e => dirInfo.GetFiles(e.Trim()));
            var files = allFiles.Where(f =>
            {
                var dt = f.CreationTime;
                return dt >= from && dt <= to;
            }).ToList();
            files.ForEach(f => f.CopyTo(Path.Combine(destination, f.Name), true));
        }
    }
}
