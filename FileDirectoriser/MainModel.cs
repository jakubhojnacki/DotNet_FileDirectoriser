using System.Collections.ObjectModel;

namespace FileDirectoriser {
    public class MainModel {
        public const int DefaultNoOfCharacters = 3;

        public string SourceDirectoryPath { get; set; }
        public string DestinationDirectoryPath { get; set; }
        public int NoOfCharacters { get; set; }
        public ObservableCollection<Message> Messages { get; set; }

        public MainModel() {
            this.SourceDirectoryPath = string.Empty;
            this.DestinationDirectoryPath = string.Empty;
            this.NoOfCharacters = MainModel.DefaultNoOfCharacters;
            this.Messages = new ObservableCollection<Message>();
        }
    }
}
