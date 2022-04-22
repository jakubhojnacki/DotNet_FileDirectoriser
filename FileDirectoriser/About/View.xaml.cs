using System.Windows;

namespace Fortah.FileDirectoriser.About {
    public partial class View : Window {
        public ViewModel ViewModel { get; private set; }

        public View() : this(null) {
        }

        public View(ViewModel? pViewModel = null) {
            this.ViewModel = pViewModel != null ? pViewModel : new ViewModel();
            this.DataContext = this.ViewModel;
            this.InitializeComponent();
        }
    }
}
