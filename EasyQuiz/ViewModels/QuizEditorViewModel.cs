using System;
using System.Windows;

using EasyQuiz.Infrastructure;
using EasyQuiz.Models;

namespace EasyQuiz.ViewModels
{
	class QuizEditorViewModel : ViewModelBase
	{
		private IFileService _fileService;
		private IDialogService _dialogService;

		private Quiz _currentQuiz;
		private ITestTask _selectedTask;

		private void CreateQuiz() => CurrentQuiz = new Quiz("newQuiz");

		public void OpenQuiz()
		{
			try
			{
				if (_dialogService.OpenFileDialog() == true)
					CurrentQuiz = _fileService.Open(_dialogService.FilePath);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public void SaveQuiz()
		{
			try
			{
				if (_dialogService.SaveFileDialog(CurrentQuiz.Name) == true)
					_fileService.Save(_dialogService.FilePath, CurrentQuiz);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void CreateAndAddTask(ICreatorTask creatorTask)
		{
			if (creatorTask != null)
			{
				int indexOfNewTask = CurrentQuiz.Tasks.Count;
				CurrentQuiz.Tasks.Add(creatorTask.CreateTask());
				SelectedTask = CurrentQuiz.Tasks[indexOfNewTask];
			}
		}

		public QuizEditorViewModel(IDialogService dialogService, IFileService fileService)
		{
			_dialogService = dialogService;
			_fileService = fileService;

			NewCommand = new Command(obj => CreateQuiz());
			OpenCommand = new Command(obj => OpenQuiz());
			SaveCommand = new Command(obj => SaveQuiz());
			EditCommand = new Command(obj => throw new NotImplementedException());
			AddTaskCommand = new Command(obj => CreateAndAddTask(obj as ICreatorTask));
			AddAnswerCommand = new Command(obj => SelectedTask.AddNewAnswer());
		}

		public Command NewCommand { get; set; }
		public Command OpenCommand { get; set; }
		public Command SaveCommand { get; set; }
		public Command EditCommand { get; set; }
		public Command AddTaskCommand { get; set; }
		public Command AddAnswerCommand { get; set; }

		public Quiz CurrentQuiz
		{
			get => _currentQuiz;
			set
			{
				_currentQuiz = value;
				OnPropertyChanged("CurrentQuiz");
			}
		}

		public ITestTask SelectedTask
		{
			get => _selectedTask;
			set
			{
				_selectedTask = value;
				OnPropertyChanged("SelectedTask");
			}
		}
	}
}
