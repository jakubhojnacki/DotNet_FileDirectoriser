using Fortah.FileDirectoriser.Logic;
using Fortah.FileDirectoriser.WPF;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Input;

namespace Fortah.FileDirectoriser.Main {
    public class ViewModel : ViewModelBase {
        public Model Model { get; private set; }

        public string SourceDirectoryPath { 
            get { return this.Model.SourceDirectoryPath; } 
            set { this.Model.SourceDirectoryPath = value; this.UpdateView("SourceDirectoryPath", true); } 
        }
        public string DestinationDirectoryPath { 
            get { return this.Model.DestinationDirectoryPath; } 
            set { this.Model.DestinationDirectoryPath = value; this.UpdateView("DestinationDirectoryPath", true); } 
        }
        public int NoOfCharacters { 
            get { return this.Model.NoOfCharacters; } 
            set { this.Model.NoOfCharacters = value; this.UpdateView("NoOfCharacters"); } 
        }
        public CaseType Case {
            get { return this.Model.Case; }
            set { this.Model.Case = value; this.UpdateView("Case"); }
        }

        public int Progress {
            get { return this.Model.Progress; }
            set { this.Model.Progress = value; this.UpdateView("Progress"); }
        }
        public ObservableCollection<Generic.Message> Messages {
            get { return this.Model.Messages; }
            set { this.Model.Messages = value; this.UpdateView("Messages"); }
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
        public RelayCommand AboutCommand { get; }

        public ViewModel(Model? pModel = null) {
            this.Model = pModel != null ? pModel : new Model();

            this.Worker = null;
            this.Running = false;

            this.RunCommand = new RelayCommand(this.OnRun, this.OnRunEnabled);
            this.StopCommand = new RelayCommand(this.OnStop, this.OnStopEnabled);
            this.ResetCommand = new RelayCommand(this.OnReset, this.OnResetEnabled);
            this.SelectSourceDirectoryCommand = new RelayCommand(this.OnSelectSourceDirectory, this.OnSelectSourceDirectoryEnabled);
            this.SelectDestinationDirectoryCommand = new RelayCommand(this.OnSelectDestinationDirectory, this.OnSelectDestinationDirectoryEnabled);
            this.DecreaseNoOfCharactersCommand = new RelayCommand(this.OnDecreaseNoOfCharacters, this.OnDecreaseNoOfCharactersEnabled);
            this.IncreaseNoOfCharactersCommand = new RelayCommand(this.OnIncreaseNoOfCharacters, this.OnIncreaseNoOfCharactersEnabled);
            this.AboutCommand = new RelayCommand(this.OnAbout, this.OnAboutEnabled);
        }

        private void OnRun(object? pParameter = null) {
            this.Messages.Clear();
            this.Worker = new Worker(new Directoriser(this.SourceDirectoryPath, this.DestinationDirectoryPath, this.NoOfCharacters, this.Case, this.Messages));
            this.Worker.ProgressChanged += this.Worker_ProgressChanged;
            this.Worker.RunWorkerCompleted += this.Worker_RunWorkerCompleted;
            this.Worker.Start();
            this.Running = true;
        }

        private void Worker_ProgressChanged(object? pSender, ProgressChangedEventArgs pEventArgs) {
            this.Progress = pEventArgs.ProgressPercentage;
            if (pEventArgs.UserState != null)
                this.Messages.Add((Generic.Message)pEventArgs.UserState);
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
            this.NoOfCharacters = Model.DefaultNoOfCharacters;
            
            this.Progress = 0;
            this.Messages.Clear();
        }

        private bool OnResetEnabled(object? pParameter = null) {
            return !this.Running;
        }

        private void OnSelectSourceDirectory(object? pParameter = null) {
            this.SourceDirectoryPath = ViewModel.SelectDirectoryPath(this.SourceDirectoryPath);
        }

        private bool OnSelectSourceDirectoryEnabled(object? pParameter = null) {
            return !this.Running;
        }

        private void OnSelectDestinationDirectory(object? pParameter = null) {
            this.DestinationDirectoryPath = ViewModel.SelectDirectoryPath(this.DestinationDirectoryPath);
        }

        private bool OnSelectDestinationDirectoryEnabled(object? pParameter = null) {
            return !this.Running;
        }

        private void OnDecreaseNoOfCharacters(object? pParameter = null) {
            if (this.NoOfCharacters > Model.MinimumNoOfCharacters)
                this.NoOfCharacters -= 1;
        }

        private bool OnDecreaseNoOfCharactersEnabled(object? pParameter = null) {
            return !this.Running;
        }

        private void OnIncreaseNoOfCharacters(object? pParameter = null) {
            if (this.NoOfCharacters < Model.MaximumNoOfCharacters)
                this.NoOfCharacters += 1;
        }

        private bool OnIncreaseNoOfCharactersEnabled(object? pParameter = null) {
            return !this.Running;
        }
        private void OnAbout(object? pParameter = null) {
            About.View View = new About.View();
            View.ShowDialog();
        }

        private bool OnAboutEnabled(object? pParameter = null) {
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

        private void UpdateView(string pPropertyName, bool? pUpdateCommands = false) {
            this.TriggerPropertyChanged(pPropertyName);
            if (pUpdateCommands == true)
                CommandManager.InvalidateRequerySuggested();
        }
    }
}
