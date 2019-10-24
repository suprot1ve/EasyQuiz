using System.Windows;

using EasyQuiz.Models;
using EasyQuiz.ViewModels;

namespace EasyQuiz.Views
{
	/// <summary>
	/// Логика взаимодействия для SettingsWindow.xaml
	/// </summary>
	public partial class SettingsWindow : Window
	{
		public SettingsWindow(Quiz quiz)
		{
			InitializeComponent();
			SettingsWindowViewModel vm = new SettingsWindowViewModel(quiz);
			if (vm.CloseAction == null)
				vm.CloseAction = new System.Action(Close);
			DataContext = vm;
		}

		private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) => DragMove();
	}
}