using System.Collections.ObjectModel;

namespace EasyQuiz.Models
{
	public class ShortAnswerTask : ITestTask
	{
		private string _question = "Введите вопрос...";
		private int _point = 1;
		private ObservableCollection<Answer> _answers;

		public ShortAnswerTask() => _answers = new ObservableCollection<Answer>();

		public string Question { get => _question; set => _question = value; }
		public int Point { get => _point; set => _point = value; }
		public ObservableCollection<Answer> Answers { get => _answers; }

		public void AddNewAnswer() => _answers.Add(new Answer());
		public int GetResult() => throw new System.NotImplementedException();
	}
}
