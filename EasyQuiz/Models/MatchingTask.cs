using System.Collections.Generic;

namespace EasyQuiz.Models
{
	public class MatchingTask : ITestTask
	{
		private string _question = "Введите вопрос...";
		private int _point = 1;
		private bool _swapAnswer;
		private List<MatchingAnswer> _answers;

		public MatchingTask() => _answers = new List<MatchingAnswer>();

		public string Question { get => _question; set => _question = value; }
		public int Point { get => _point; set => _point = value; }
		public bool SwapAnswer { get => _swapAnswer; set => _swapAnswer = value; }
		public List<MatchingAnswer> Answers { get => _answers; }

		public void AddAnswer() => _answers.Add(new MatchingAnswer());
		public int GetResult() => throw new System.NotImplementedException();
	}
}
