using System.Collections.Generic;

namespace EasyQuiz.Models
{
	public class ShortAnswerTask : ITestTask
	{
		private string _question = "Введите вопрос...";
		private int _point = 1;
		private List<Answer> _answers;

		public ShortAnswerTask() => _answers = new List<Answer>();

		public string Question { get => _question; set => _question = value; }
		public int Point { get => _point; set => _point = value; }
		public List<Answer> Answers { get => _answers; }

		public void AddAnswer() => _answers.Add(new Answer());
		public int GetResult() => throw new System.NotImplementedException();
	}
}
