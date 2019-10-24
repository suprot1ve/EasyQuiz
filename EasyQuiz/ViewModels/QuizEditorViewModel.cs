using System;
using System.Windows;

using EasyQuiz.Infrastructure;
using EasyQuiz.Models;
using EasyQuiz.Views;

namespace EasyQuiz.ViewModels
{
	class QuizEditorViewModel : ViewModelBase
	{
		private IFileService _fileService;
		private IDialogService _dialogService;

		private Quiz _currentQuiz;
		private ITestTask _selectedTask;
		private GradePoint _selectedGradePoint;
		private Answer _selectedAnswer;

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

		private void Close()
		{
			SaveQuiz();
			CloseAction();
		}

		public QuizEditorViewModel(IDialogService dialogService, IFileService fileService)
		{
			_dialogService = dialogService;
			_fileService = fileService;

			NewCommand = new Command(obj => CreateQuiz());
			OpenCommand = new Command(obj => OpenQuiz());
			SaveCommand = new Command(obj => SaveQuiz(), obj => CurrentQuiz != null);
			EditCommand = new Command(obj => new SettingsWindow(CurrentQuiz).Show(), obj => CurrentQuiz != null);
			AddTaskCommand = new Command(obj => CreateAndAddTask(obj as ICreatorTask), obj => CurrentQuiz != null);
			RemoveTaskCommand = new Command(obj => CurrentQuiz.Tasks.Remove(SelectedTask), obj => SelectedTask != null);
			AddGradePointCommand = new Command(obj => CurrentQuiz.AddNewGradePoint(), obj => CurrentQuiz != null);
			RemoveGradePointCommand = new Command(obj => CurrentQuiz.GradePoints.Remove(SelectedGradePoint), obj => SelectedGradePoint != null);
			AddAnswerCommand = new Command(obj => SelectedTask.AddNewAnswer(), obj => SelectedTask != null);
			RemoveAnswerCommand = new Command(obj => SelectedTask.RemoveAnswer(SelectedAnswer), obj => SelectedAnswer != null);
			CloseCommand = new Command(obj => Close());
			MinimizeCommand = new Command(obj => MinimizeAction());
			MaximizeCommand = new Command(obj => MaximizeAction());
		}

		public Command NewCommand { get; set; }
		public Command OpenCommand { get; set; }
		public Command SaveCommand { get; set; }
		public Command EditCommand { get; set; }
		public Command AddTaskCommand { get; set; }
		public Command RemoveTaskCommand { get; set; }
		public Command AddGradePointCommand { get; set; }
		public Command RemoveGradePointCommand { get; set; }
		public Command AddAnswerCommand { get; set; }
		public Command RemoveAnswerCommand { get; set; }

		public Command MinimizeCommand { get; set; }
		public Action MinimizeAction { get; set; }
		public Command MaximizeCommand { get; set; }
		public Action MaximizeAction { get; set; }
		public Command CloseCommand { get; set; }
		public Action CloseAction { get; set; }

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

		public GradePoint SelectedGradePoint
		{
			get => _selectedGradePoint;
			set
			{
				_selectedGradePoint = value;
				OnPropertyChanged("SelectedGradePoint");
			}
		}

		public Answer SelectedAnswer
		{
			get => _selectedAnswer;
			set
			{
				_selectedAnswer = value;
				OnPropertyChanged("SelectedAnswer");
			}
		}
	}
}