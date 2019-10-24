using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace EasyQuiz.Models
{
	[DataContract]
	[KnownType(typeof(Answer))]
	[KnownType(typeof(MultipleChoiceTask))]
	[KnownType(typeof(MultipleResponseTask))]
	[KnownType(typeof(ShortAnswerTask))]
	[KnownType(typeof(SequenceTask))]
	[KnownType(typeof(MatchingTask))]
	[KnownType(typeof(TrueFalseTask))]
	[KnownType(typeof(SequenceAnswer))]
	[KnownType(typeof(MatchingAnswer))]
	[KnownType(typeof(TrueFalseAnswer))]
	public class Quiz : INotifyPropertyChanged
	{
		private string _name;
		private TimeSpan _timeLimit;
		private bool _timeLimitOn;
		private bool _swapTasks;
		private bool _showResult;
		private string _resultMsg;
		private ObservableCollection<ITestTask> _tasks;
		private ObservableCollection<GradePoint> _gradePoints;

		public Quiz(string name)
		{
			_name = name;
			_timeLimit = TimeSpan.Zero;
			_timeLimitOn = false;
			_swapTasks = false;
			_showResult = true;
			_resultMsg = "Your quiz result:";
			_tasks = new ObservableCollection<ITestTask>();
			_gradePoints = new ObservableCollection<GradePoint>();
		}

		[DataMember]
		public string Name
		{
			get => _name;
			set
			{
				_name = value;
				OnPropertyChanged("Name");
			}
		}
		[DataMember]
		public TimeSpan TimeLimit
		{
			get => _timeLimit;
			set
			{
				_timeLimit = value;
				OnPropertyChanged("TimeLimit");
			}
		}
		[DataMember]
		public bool TimeLimitOn
		{
			get => _timeLimitOn;
			set
			{
				_timeLimitOn = value;
				OnPropertyChanged("TimeLimitOn");
			}
		}
		[DataMember]
		public bool SwapTasks
		{
			get => _swapTasks;
			set
			{
				_swapTasks = value;
				OnPropertyChanged("SwapTasks");
			}
		}
		[DataMember]
		public bool ShowResult
		{
			get => _showResult;
			set
			{
				_showResult = value;
				OnPropertyChanged("ShowResult");
			}
		}
		[DataMember]
		public string ResultMsg
		{
			get => _resultMsg;
			set
			{
				_resultMsg = value;
				OnPropertyChanged("ResultMsg");
			}
		}
		[DataMember]
		public ObservableCollection<ITestTask> Tasks { get => _tasks; set => _tasks = value; }
		[DataMember]
		public ObservableCollection<GradePoint> GradePoints { get => _gradePoints; set => _gradePoints = value; }

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}

		public void AddNewTask(ICreatorTask creator) => _tasks.Add(creator.CreateTask());
		public void AddNewGradePoint() => _gradePoints.Add(new GradePoint());
		public int GetResultGradePoint(int userScore)
		{
			int percent = Convert.ToInt32(GetPercentageOfCorrectAnswers(userScore));
			return (from gp in GradePoints orderby gp.Percent where gp.Percent >= percent select gp.Point).FirstOrDefault();
		}

		private double GetPercentageOfCorrectAnswers(int userScore)
		{
			int maxPointsPerQuiz = GetMaxPointsPerQuiz();
			double pointsInPercent = (double)maxPointsPerQuiz / 100;
			return (double)userScore / pointsInPercent;
		}

		private int GetMaxPointsPerQuiz()
		{
			int maxPointsPerQuiz = 0;
			foreach (var task in Tasks)
				maxPointsPerQuiz += task.GetMaxPointsPerTask();
			return maxPointsPerQuiz;
		}
	}
}
