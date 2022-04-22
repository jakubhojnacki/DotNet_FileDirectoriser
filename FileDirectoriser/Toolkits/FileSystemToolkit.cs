using System.IO;
using System.Collections.Generic;

namespace Fortah.FileDirectoriser.Toolkits {
    internal static class FileSystemToolkit {
        public static void MakeSureDirectoryTreeExists(string pDirectoryPath) {
            string[] DirectoryNames = pDirectoryPath.Split(Path.DirectorySeparatorChar);
            string DirectoryPath = string.Empty;
            foreach (string DirectoryName in DirectoryNames) {
                DirectoryPath = Path.Combine(DirectoryPath, DirectoryName);
                if (!Directory.Exists(DirectoryPath))
                    Directory.CreateDirectory(DirectoryPath);
            }
        }

        public static string CreateProperDirectoryName(string pName) {
            List<string>  ReservedDirectoryNames = new List<string>(new string[] { "aux", "com1", "com2", "com3", "com4", "com5", "com6", "com7", 
                "com8", "com9", "lpt1", "lpt2", "lpt3", "lpt4", "lpt5", "lpt6", "lpt7", "lpt8", "lpt9", "con", "nul", "prn" });
            string NewName = pName.Trim();
            if (ReservedDirectoryNames.Contains(NewName.ToLower()))
                NewName = NewName + "_";
            return NewName;               
        }
    }
}
