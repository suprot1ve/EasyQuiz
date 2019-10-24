using System;
using System.Windows.Threading;

using EasyQuiz.Infrastructure;
using EasyQuiz.Models;
using EasyQuiz.Views;

namespace EasyQuiz.ViewModels
{
	class QuizRunnerViewModel : ViewModelBase
	{
		private Quiz _currentQuiz;
		private int _countTask;
		private int _countScore;
		private ITestTask _currentTask;
		private DispatcherTimer _timer;

		private void GiveAnswer()
		{
			_countScore += CurrentTask.GetResult();
			if (_countTask + 1 == CurrentQuiz.Tasks.Count)
				new ResultWindow(_countScore, CurrentQuiz).Show();
			else
				SetCurrentTask(++CountTask);
		}

		private void SetCurrentTask(int countTask)
		{
			CurrentTask = CurrentQuiz.Tasks[countTask];
			CurrentTask.ShuffleAnswers();
		}

		private void TimeStart()
		{
			_timer = new DispatcherTimer();
			_timer.Tick += new EventHandler(TimerTick);
			_timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
			_timer.Start();
		}

		private void TimerTick(object sender, EventArgs e)
		{
			if (CurrentQuiz.TimeLimitOn)
			{
				CurrentQuiz.TimeLimit -= new TimeSpan(0, 0, 0, 0, 1000);
				if (CurrentQuiz.TimeLimit == TimeSpan.Zero)
					new ResultWindow(_countScore, CurrentQuiz).Show();
			}
		}

		public QuizRunnerViewModel(Quiz currentQuiz)
		{
			CurrentQuiz = currentQuiz;
			CountTask = 0;
			_countScore = 0;
			SetCurrentTask(CountTask);

			CloseCommand = new Command(obj => CloseAction());
			MinimizeCommand = new Command(obj => MinimizeAction());
			MaximizeCommand = new Command(obj => MaximizeAction());

			GiveAnswerCommand = new Command(obj => GiveAnswer());

			TimeStart();
		}

		public Command MinimizeCommand { get; set; }
		public Action MinimizeAction { get; set; }
		public Command MaximizeCommand { get; set; }
		public Action MaximizeAction { get; set; }
		public Command CloseCommand { get; set; }
		public Action CloseAction { get; set; }

		public Command GiveAnswerCommand { get; set; }

		public Quiz CurrentQuiz
		{
			get => _currentQuiz;
			set
			{
				_currentQuiz = value;
				OnPropertyChanged("CurrentQuiz");
			}
		}

		public ITestTask CurrentTask
		{
			get => _currentTask;
			set
			{
				_currentTask = value;
				OnPropertyChanged("CurrentTask");
			}
		}

		public int CountTask
		{
			get => _countTask;
			set
			{
				_countTask = value;
				OnPropertyChanged("CountTask");
			}
		}
	}
}

