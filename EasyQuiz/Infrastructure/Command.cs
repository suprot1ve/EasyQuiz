using System;
using System.Windows.Input;

namespace EasyQuiz.Infrastructure
{
	public class Command : ICommand
	{
		private readonly Action<object> _execute;
		private readonly Func<object, bool> _canExecute;

		public Command(Action<object> execute) : this(execute, null) { }

		public Command(Action<object> execute, Func<object, bool> canExecute)
		{
			if (execute == null) throw new ArgumentNullException(nameof(execute));
			_execute = execute;
			_canExecute = canExecute ?? (x => true);
		}

		public void Execute(object parametr) => _execute(parametr);

		public bool CanExecute(object parametr) => _canExecute(parametr);

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}
	}
}
