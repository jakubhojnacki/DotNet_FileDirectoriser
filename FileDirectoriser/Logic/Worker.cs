using System.ComponentModel;

namespace FileDirectoriser {
    internal class Worker : BackgroundWorker {
        private Directoriser Directoriser { get; set; }

        public Worker(Directoriser pDirectoriser) {
            this.Directoriser = pDirectoriser;
            this.WorkerReportsProgress = true;
            this.WorkerSupportsCancellation = true;
        }

        public new void Dispose() {
            this.Stop();
            base.Dispose();
        }

        public void Start() {
            this.DoWork += this.BackgroundWorker_DoWork;
            this.RunWorkerAsync();
        }

        private void BackgroundWorker_DoWork(object? pSender, DoWorkEventArgs pEventArgs) {
            this.Directoriser.Run(this);
        }

        public void Stop() {
            if (this.IsBusy)
                this.CancelAsync();
        }
    }
}
