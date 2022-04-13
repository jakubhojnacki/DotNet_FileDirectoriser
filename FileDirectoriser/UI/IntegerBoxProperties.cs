using System.Windows;
using System.Windows.Input;

namespace FileDirectoriser {
    public class IntegerBoxProperties : DependencyObject {
        public static readonly DependencyProperty DecreaseProperty = DependencyProperty.RegisterAttached("Decrease",
            typeof(ICommand), typeof(DirectoryPathBoxProperties), new PropertyMetadata(default(ICommand)));
        public static ICommand GetDecrease(DependencyObject pParent) { return (ICommand)pParent.GetValue(DecreaseProperty); }
        public static void SetDecrease(DependencyObject pParent, ICommand pValue) { pParent.SetValue(DecreaseProperty, pValue); }

        public static readonly DependencyProperty IncreaseProperty = DependencyProperty.RegisterAttached("Increase",
            typeof(ICommand), typeof(DirectoryPathBoxProperties), new PropertyMetadata(default(ICommand)));
        public static ICommand GetIncrease(DependencyObject pParent) { return (ICommand)pParent.GetValue(IncreaseProperty); }
        public static void SetIncrease(DependencyObject pParent, ICommand pValue) { pParent.SetValue(IncreaseProperty, pValue); }
    }
}
