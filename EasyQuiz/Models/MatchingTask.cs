using System;
using System.Collections.ObjectModel;

using EasyQuiz.Infrastructure;

namespace EasyQuiz.Models
{
	public class MatchingTask : ITestTask
	{
		private string _question = "Введите вопрос...";
		private int _point = 1;
		private ObservableCollection<MatchingAnswer> _answers;

		public MatchingTask() => _answers = new ObservableCollection<MatchingAnswer>();

		public string Question { get => _question; set => _question = value; }
		public int Point { get => _point; set => _point = value; }
		public ObservableCollection<MatchingAnswer> Answers { get => _answers; }

		public void AddNewAnswer() => _answers.Add(new MatchingAnswer());
		public void RemoveAnswer(Answer answer) => _answers.Remove(answer as MatchingAnswer);
		public int GetResult() => 10;
		public int GetMaxPointsPerTask() => Answers.Count * Point;

		public void ShuffleAnswers()
		{
			Random rng = new Random();
			rng.Shuffle(Answers);
		}
	}
}
