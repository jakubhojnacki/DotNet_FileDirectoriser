using System.Windows;
using System.Windows.Input;

namespace Fortah.FileDirectoriser.UI {
    public class DirectoryPathBoxProperties : DependencyObject {
        public static readonly DependencyProperty SelectProperty = DependencyProperty.RegisterAttached("Select",
            typeof(ICommand), typeof(DirectoryPathBoxProperties), new PropertyMetadata(default(ICommand)));
        public static ICommand GetSelect(DependencyObject pParent) { return (ICommand)pParent.GetValue(SelectProperty); }
        public static void SetSelect(DependencyObject pParent, ICommand pValue) { pParent.SetValue(SelectProperty, pValue); }
    }
}
