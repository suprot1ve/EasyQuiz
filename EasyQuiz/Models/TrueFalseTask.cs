using System.Collections.ObjectModel;

namespace EasyQuiz.Models
{
	public class TrueFalseTask : ITestTask
	{
		private string _question = "Введите вопрос...";
		private int _point = 1;
		private bool _swapAnswer;
		private ObservableCollection<TrueFalseAnswer> _answers;

		public TrueFalseTask() => _answers = new ObservableCollection<TrueFalseAnswer>();

		public string Question { get => _question; set => _question = value; }
		public int Point { get => _point; set => _point = value; }
		public bool SwapAnswer { get => _swapAnswer; set => _swapAnswer = value; }
		public ObservableCollection<TrueFalseAnswer> Answers { get => _answers; }

		public void AddAnswer() => _answers.Add(new TrueFalseAnswer());
		public int GetResult() => throw new System.NotImplementedException();
	}
}
