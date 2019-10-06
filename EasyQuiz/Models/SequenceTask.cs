﻿using System.Collections.ObjectModel;

namespace EasyQuiz.Models
{
	public class SequenceTask : ITestTask
	{
		private string _question = "Введите вопрос...";
		private int _point = 1;
		private ObservableCollection<SequenceAnswer> _answers;

		public SequenceTask() => _answers = new ObservableCollection<SequenceAnswer>();

		public string Question { get => _question; set => _question = value; }
		public int Point { get => _point; set => _point = value; }
		public ObservableCollection<SequenceAnswer> Answers { get => _answers; }

		public void AddAnswer() => _answers.Add(new SequenceAnswer());
		public int GetResult() => throw new System.NotImplementedException();
	}
}
