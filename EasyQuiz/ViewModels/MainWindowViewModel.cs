using System;
using System.Windows;

using EasyQuiz.Infrastructure;
using EasyQuiz.Models;
using EasyQuiz.Views;

namespace EasyQuiz.ViewModels
{
	class MainWindowViewModel : ViewModelBase
	{
		private IFileService _fileService;
		private IDialogService _dialogService;

		private void OpenQuizRunner(Quiz runnedQuiz)
		{
			if (runnedQuiz == null) return;
			new QuizRunner(runnedQuiz).Show();
			CloseAction();
		}

		private void OpenQuizEditor()
		{
			new QuizEditor().Show();
			CloseAction();
		}

		public Quiz OpenQuiz()
		{
			try
			{
				if (_dialogService.OpenFileDialog() == true)
					return _fileService.Open(_dialogService.FilePath);
				else
					return null;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return null;
			}
		}

		public MainWindowViewModel(IDialogService dialogService, IFileService fileService)
		{
			_dialogService = dialogService;
			_fileService = fileService;

			OpenRunnerCommand = new Command(obj => OpenQuizRunner(OpenQuiz()));
			OpenEditorCommand = new Command(obj => OpenQuizEditor());
			CloseCommand = new Command(obj => CloseAction());
		}

		public Command OpenRunnerCommand { get; set; }
		public Command OpenEditorCommand { get; set; }
		public Command CloseCommand { get; set; }
		public Action CloseAction { get; set; }
	}
}
