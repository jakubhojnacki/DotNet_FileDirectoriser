using System.ComponentModel;

namespace FileDirectoriser {
    public abstract class ViewModelBase : INotifyPropertyChanged {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void TriggerPropertyChanged(string pPropertyName) {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(pPropertyName));
        }
    }
}
