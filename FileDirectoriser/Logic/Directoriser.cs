using System.Threading;

namespace FileDirectoriser {
    internal class Directoriser {
        public string SourceDirectoryPath { get; }
        public string DestinationDirectoryPath { get; }
        public int NoOfCharacters { get; set; }

        private Worker? Worker { get; set; }

        public Directoriser(string pSourceDirectoryPath, string pDestinationDirectoryPath, int pNoOfCharacters) {
            this.SourceDirectoryPath = pSourceDirectoryPath;
            this.DestinationDirectoryPath = pDestinationDirectoryPath;
            this.NoOfCharacters = pNoOfCharacters;
            this.Worker = null;
        }

        public void Run(Worker? pWorker = null) {
            this.Worker = pWorker;
            for (int i = 0; i < 100; i++) {
                this.Worker?.ReportProgress(i, new Message(i.ToString()));
                Thread.Sleep(500);
                if (this.Worker != null)
                    if (this.Worker.CancellationPending)
                        break;
            }
        }
    }
}
