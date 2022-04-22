using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Fortah.FileDirectoriser.Main {
    public partial class View : Window {
        public ViewModel ViewModel { get; private set; }

        public View() : this(null) {
        }

        public View(ViewModel? pViewModel = null) {
            this.ViewModel = pViewModel != null ? pViewModel : new ViewModel();
            this.DataContext = this.ViewModel;
            this.InitializeComponent();
        }

        private void IntegerBoxValidation(object pSender, TextCompositionEventArgs pEventArgs) {
            Regex Regex = new Regex("[^0-9]+");
            pEventArgs.Handled = Regex.IsMatch(pEventArgs.Text);
        }
    }
}
