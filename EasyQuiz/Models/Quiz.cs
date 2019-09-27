using System;
using System.Collections.Generic;

namespace EasyQuiz.Models
{
	public class Quiz
	{
		private string _name;
		private TimeSpan _timeLimit;
		private List<ITestTask> _tasks;
		private List<GradePoint> _gradePoints;

		public Quiz(string name)
		{
			_name = name;
			_timeLimit = TimeSpan.Zero;
			_tasks = new List<ITestTask>();
			_gradePoints = new List<GradePoint>();
		}

		public string Name { get => _name; set => _name = value; }
		public TimeSpan TimeLimit { get => _timeLimit; set => _timeLimit = value; }
		public List<ITestTask> Tasks { get => _tasks; }
		public List<GradePoint> GradePoints { get => _gradePoints; }

		public void AddTask(ICreatorTask creator) => _tasks.Add(creator.Create());
		public void AddGradePoint() => _gradePoints.Add(new GradePoint());
		public int GetResult() => throw new NotImplementedException();
	}
}
