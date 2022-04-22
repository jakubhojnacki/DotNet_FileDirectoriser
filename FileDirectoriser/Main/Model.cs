using Fortah.FileDirectoriser.Generic;
using Fortah.FileDirectoriser.Logic;
using System.Collections.ObjectModel;

namespace Fortah.FileDirectoriser.Main {
    public class Model {
        public const int DefaultNoOfCharacters = 3;
        public const int MinimumNoOfCharacters = 1;
        public const int MaximumNoOfCharacters = 5;

        public string SourceDirectoryPath { get; set; }
        public string DestinationDirectoryPath { get; set; }
        public int NoOfCharacters { get; set; }
        public CaseType Case { get; set; }

        public int Progress { get; set; }
        public ObservableCollection<Message> Messages { get; set; }

        public Model() {
            this.SourceDirectoryPath = string.Empty;
            this.DestinationDirectoryPath = string.Empty;
            this.NoOfCharacters = Model.DefaultNoOfCharacters;
            this.Case = CaseType.Proper;

            this.Progress = 0;
            this.Messages = new ObservableCollection<Message>();
        }
    }
}
