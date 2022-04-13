namespace FileDirectoriser {
    public class MainModel {
        public const int DefaultNoOfCharacters = 3;

        public string SourceDirectoryPath { get; set; }
        public string DestinationDirectoryPath { get; set; }
        public int NoOfCharacters { get; set; }

        public MainModel() {
            this.SourceDirectoryPath = "Test Source Directory Path"; //TODO - Remove
            this.DestinationDirectoryPath = "Test Destination Directory Path"; //TODO - Remove
            this.NoOfCharacters = 17; //TODO - Remove
        }
    }
}
