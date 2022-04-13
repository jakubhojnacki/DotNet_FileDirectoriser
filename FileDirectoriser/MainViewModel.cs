using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;

namespace FileDirectoriser {
    public class MainViewModel : ViewModelBase {
        public MainModel Model { get; private set; }

        public string SourceDirectoryPath { 
            get { return this.Model.SourceDirectoryPath; } 
            set { this.Model.SourceDirectoryPath = value; this.TriggerPropertyChanged("SourceDirectoryPath"); } 
        }
        public string DestinationDirectoryPath { 
            get { return this.Model.DestinationDirectoryPath; } 
            set { this.Model.DestinationDirectoryPath = value; this.TriggerPropertyChanged("DestinationDirectoryPath"); } 
        }
        public int NoOfCharacters { 
            get { return this.Model.NoOfCharacters; } 
            set { this.Model.NoOfCharacters = value; this.TriggerPropertyChanged("NoOfCharacters"); } 
        }
        public ObservableCollection<Message> Messages {
            get { return this.Model.Messages; }
            set { this.Model.Messages = value; this.TriggerPropertyChanged("Messages"); }
        }

        private Worker? Worker { get; set; }
        public bool Running { get; private set; }

        public RelayCommand RunCommand { get; }
        public RelayCommand StopCommand { get; }
        public RelayCommand ResetCommand { get; }
        public RelayCommand SelectSourceDirectoryCommand { get; }
        public RelayCommand SelectDestinationDirectoryCommand { get; }
        public RelayCommand DecreaseNoOfCharactersCommand { get; }
        public RelayCommand IncreaseNoOfCharactersCommand { get; }

        public MainViewModel(MainModel? pModel = null) {
            this.Model = pModel != null ? pModel : new MainModel();

            this.Worker = null;
            this.Running = false;

            this.RunCommand = new RelayCommand(this.OnRun, this.OnRunEnabled);
            this.StopCommand = new RelayCommand(this.OnStop, this.OnStopEnabled);
            this.ResetCommand = new RelayCommand(this.OnReset, this.OnResetEnabled);
            this.SelectSourceDirectoryCommand = new RelayCommand(this.OnSelectSourceDirectoryCommand, this.OnSelectSourceDirectoryCommandEnabled);
            this.SelectDestinationDirectoryCommand = new RelayCommand(this.OnSelectDestinationDirectoryCommand, this.OnSelectDestinationDirectoryCommandEnabled);
            this.DecreaseNoOfCharactersCommand = new RelayCommand(this.OnDecreaseNoOfCharactersCommand, this.OnDecreaseNoOfCharactersCommandEnabled);
            this.IncreaseNoOfCharactersCommand = new RelayCommand(this.OnIncreaseNoOfCharactersCommand, this.OnIncreaseNoOfCharactersCommandEnabled);
        }

        private void OnRun(object? pParameter = null) {
            this.Messages.Clear();
            this.Worker = new Worker(new Directoriser(this.SourceDirectoryPath, this.DestinationDirectoryPath, this.NoOfCharacters));
            this.Worker.ProgressChanged += this.Worker_ProgressChanged;
            this.Worker.RunWorkerCompleted += this.Worker_RunWorkerCompleted;
            this.Worker.Start();
            this.Running = true;
        }

        private void Worker_ProgressChanged(object? pSender, ProgressChangedEventArgs pEventArgs) {
            if (pEventArgs.UserState != null)
                this.Messages.Add((Message)pEventArgs.UserState);
        }

        private void Worker_RunWorkerCompleted(object? pSender, RunWorkerCompletedEventArgs pEventArgs) {
            if (this.Worker != null) {     
                this.Worker.Dispose();
                this.Worker = null;
            }
            this.Running = false;
        }

        private bool OnRunEnabled(object? pParameter = null) {
            return ((!string.IsNullOrEmpty(this.SourceDirectoryPath)) && (!string.IsNullOrEmpty(this.DestinationDirectoryPath)) && (!this.Running));
        }

        private void OnStop(object? pParameter = null) {
            if (this.Worker != null) {
                this.Worker.Stop();
                this.Worker.Dispose();
                this.Worker = null;
            }
            this.Running = false;
        }

        private bool OnStopEnabled(object? pParameter = null) {
            return this.Running;
        }

        private void OnReset(object? pParameter = null) {
            this.SourceDirectoryPath = string.Empty;
            this.DestinationDirectoryPath = string.Empty;
            this.NoOfCharacters = MainModel.DefaultNoOfCharacters;
            this.Messages.Clear();
        }

        private bool OnResetEnabled(object? pParameter = null) {
            return !this.Running;
        }

        private void OnSelectSourceDirectoryCommand(object? pParameter = null) {
            this.SourceDirectoryPath = MainViewModel.SelectDirectoryPath(this.SourceDirectoryPath);
        }

        private bool OnSelectSourceDirectoryCommandEnabled(object? pParameter = null) {
            return !this.Running;
        }

        private void OnSelectDestinationDirectoryCommand(object? pParameter = null) {
            this.DestinationDirectoryPath = MainViewModel.SelectDirectoryPath(this.DestinationDirectoryPath);
        }

        private bool OnSelectDestinationDirectoryCommandEnabled(object? pParameter = null) {
            return !this.Running;
        }

        private void OnDecreaseNoOfCharactersCommand(object? pParameter = null) {
            if (this.NoOfCharacters > 1)
                this.NoOfCharacters -= 1;
        }

        private bool OnDecreaseNoOfCharactersCommandEnabled(object? pParameter = null) {
            return !this.Running;
        }

        private void OnIncreaseNoOfCharactersCommand(object? pParameter = null) {
            this.NoOfCharacters += 1;
        }

        private bool OnIncreaseNoOfCharactersCommandEnabled(object? pParameter = null) {
            return !this.Running;
        }

        private static string SelectDirectoryPath(string pDirectoryPath)
        {
            string DirectoryPath = pDirectoryPath;
            FolderBrowserDialog FolderBrowserDialog = new FolderBrowserDialog();
            FolderBrowserDialog.SelectedPath = pDirectoryPath;
            if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
                DirectoryPath = FolderBrowserDialog.SelectedPath;
            return DirectoryPath;
        }
    }
}
