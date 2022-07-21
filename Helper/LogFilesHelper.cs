using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RegistryEditor.Helper
{
    public static class LogFilesHelper
    {
        public static List<FileInfo> FilterFiles(List<string> source, DateTime from, DateTime to, string filter)
        {
            var result = new List<FileInfo>();
            source.ForEach(path =>
            {
                if (!Directory.Exists(path))
                    return;
                var dirInfo = new DirectoryInfo(path);
                var allFiles = filter.Split('|').SelectMany(e => dirInfo.GetFiles(e.Trim()));
                result.AddRange(allFiles.Where(f =>
                {
                    var dt = f.CreationTime;
                    return dt >= from && dt <= to;
                }));
            });
            return result;
        }

        public static void Copy(List<FileInfo> files, string destination)
        {
            Directory.CreateDirectory(destination);
            files.ForEach(f => f.CopyTo(Path.Combine(destination, f.Name), true));
        }
    }
}
