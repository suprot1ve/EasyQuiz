using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
		private ObservableCollection<ITestTask> _tasks;
		private ObservableCollection<GradePoint> _gradePoints;

		public Quiz(string name)
		{
			_name = name;
			_timeLimit = TimeSpan.Zero;
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
		public int GetResult() => throw new NotImplementedException();
	}
}
