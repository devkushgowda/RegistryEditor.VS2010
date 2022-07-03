using System;
using System.IO;
using System.Linq;

namespace RegistryEditor.Helper
{
    public static class LogFilesHelper
    {
        public static void Copy(string source, string destination, DateTime from, DateTime to)
        {
            if (!Directory.Exists(source))
                return;
            Directory.CreateDirectory(destination);
            var files = new DirectoryInfo(source).GetFiles("*.log").ToList().Where(f =>
            {
                var dt = parseDateTime(f.Name);
                return dt >= from && dt <= to;
            }).ToList();
            files.ForEach(f => f.CopyTo(Path.Combine(destination, f.Name), true));
        }

        private static DateTime parseDateTime(string filename)
        {
            return DateTime.ParseExact(filename.Split('.')[0], "ddMMyyyyHHmmssfff", null);
        }
    }
}
