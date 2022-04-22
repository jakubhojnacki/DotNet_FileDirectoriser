using Fortah.FileDirectoriser.Toolkits;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Fortah.FileDirectoriser.Logic {
    internal class DirectoryTree {
        private string Name { get; }
        private int NoOfCharacters { get; }
        private CaseType Case { get; }
        public string Result { get; set; }
        public bool ReservedNameDetected { get; set; }

        public string ConvertedName { 
            get {
                string ConvertedName = Path.GetFileNameWithoutExtension(this.Name);
                ConvertedName = (new Regex("[^a-zA-Z0-9]")).Replace(ConvertedName, string.Empty);
                ConvertedName = DirectoryTree.ConvertCase(ConvertedName, this.Case);
                return ConvertedName;
            }
        }

        public DirectoryTree(string pName, int pNoOfCharacters, CaseType pCase) {
            this.Name = pName;
            this.NoOfCharacters = pNoOfCharacters;
            this.Case = pCase;
            this.Result = string.Empty;
            this.ReservedNameDetected = false;
        }

        public string Create() {
            this.Result = string.Empty;
            this.ReservedNameDetected = false;
            string ConvertedName = this.ConvertedName;
            int NoOfCharacters = Math.Min(this.NoOfCharacters, ConvertedName.Length);
            for (int Index = 0; Index < NoOfCharacters; Index++) {
                int DirectoryNameMaxLength = ConvertedName.Length > Index ? Index + 1 : ConvertedName.Length;
                string DirectoryName = ConvertedName.Substring(0, DirectoryNameMaxLength);
                string ProperDirectoryName = FileSystemToolkit.CreateProperDirectoryName(DirectoryName);
                if (DirectoryName != ProperDirectoryName)
                    this.ReservedNameDetected = true;
                this.Result = Path.Combine(this.Result, ProperDirectoryName);
            }
            return this.Result;
        }

        public static DirectoryTree Create(string pName, int pNoOfCharacters, CaseType pCase) {
            DirectoryTree DirectoryTree = new DirectoryTree(pName, pNoOfCharacters, pCase);
            DirectoryTree.Create();
            return DirectoryTree;
        }

        private static string ConvertCase(string pText, CaseType pCase) {
            string Text = pText.Trim();
            string Result = string.Empty;
            switch (pCase) {
                case CaseType.Upper: 
                    Result = Text.ToUpper(); 
                    break;
                case CaseType.Lower: 
                    Result = Text.ToLower(); 
                    break;
                default: {
                    if (Text.Length >= 1)
                        Result += Text.Substring(0, 1).ToUpper();
                    if (Text.Length >= 2)
                        Result += Text.Substring(1).ToLower();
                } break;
            }
            return Result;
        }
    }
}
