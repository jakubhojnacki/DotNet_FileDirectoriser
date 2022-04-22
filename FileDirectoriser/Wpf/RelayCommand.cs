using System;
using System.Windows.Input;

namespace Fortah.FileDirectoriser.WPF {
	public class RelayCommand : ICommand {
		private Action<object?> Action { get; set; }
		private Predicate<object?>? CanExecuteAction { get; set; }

		public RelayCommand(Action<object?> pAction, Predicate<object?>? pCanExecuteAction = null) {
			this.Action = pAction;
			this.CanExecuteAction = pCanExecuteAction;
		}

		public bool CanExecute(object? pParameter = null) {
			return this.CanExecuteAction != null ? this.CanExecuteAction(pParameter) : true;
		}

		public event EventHandler? CanExecuteChanged {
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void TriggerCanExecuteChanged() {
			CommandManager.InvalidateRequerySuggested();
		}

		public void Execute(object? pParameter = null) {
			this.Action(pParameter);
		}
	}
}
