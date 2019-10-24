using System.Windows;

using EasyQuiz.Infrastructure;
using EasyQuiz.ViewModels;

namespace EasyQuiz.Views
{
	/// <summary>
	/// Логика взаимодействия для QuizEditor.xaml
	/// </summary>
	public partial class QuizEditor : Window
	{
		public QuizEditor()
		{
			InitializeComponent();
			QuizEditorViewModel vm = new QuizEditorViewModel(new DefaultDialogService(), new JsonFileService());
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