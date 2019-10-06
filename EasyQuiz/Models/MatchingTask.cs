using System.Collections.ObjectModel;

namespace EasyQuiz.Models
{
	public class MatchingTask : ITestTask
	{
		private string _question = "Введите вопрос...";
		private int _point = 1;
		private bool _swapAnswer;
		private ObservableCollection<MatchingAnswer> _answers;

		public MatchingTask() => _answers = new ObservableCollection<MatchingAnswer>();

		public string Question { get => _question; set => _question = value; }
		public int Point { get => _point; set => _point = value; }
		public bool SwapAnswer { get => _swapAnswer; set => _swapAnswer = value; }
		public ObservableCollection<MatchingAnswer> Answers { get => _answers; }

		public void AddNewAnswer() => _answers.Add(new MatchingAnswer());
		public int GetResult() => throw new System.NotImplementedException();
	}
}
