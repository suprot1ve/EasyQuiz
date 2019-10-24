using System.Windows;

using EasyQuiz.Models;
using EasyQuiz.ViewModels;

namespace EasyQuiz.Views
{
	/// <summary>
	/// Логика взаимодействия для QuizRunner.xaml
	/// </summary>
	public partial class QuizRunner : Window
	{
		public QuizRunner(Quiz quiz)
		{
			InitializeComponent();
			QuizRunnerViewModel vm = new QuizRunnerViewModel(quiz);
			if (vm.CloseAction == null)
				vm.CloseAction = new System.Action(Close);
			if (vm.MinimizeAction == null)
				vm.MinimizeAction = new System.Action(() => WindowState = WindowState.Minimized);
			if (vm.MaximizeAction == null)
				vm.MaximizeAction = new System.Action(() => { if (WindowState == WindowState.Normal) WindowState = WindowState.Maximized; else WindowState = WindowState.Normal; });
			DataContext = vm;
		}

		private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) => DragMove();
	}
}