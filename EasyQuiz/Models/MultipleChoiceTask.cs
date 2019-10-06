using System.Collections.ObjectModel;

namespace EasyQuiz.Models
{
	public class MultipleChoiceTask : ITestTask
	{
		private string _question = "Введите вопрос...";
		private int _point = 1;
		private bool _swapAnswer;
		private ObservableCollection<Answer> _answers;
		private Answer _rightAnswer;

		public MultipleChoiceTask() => _answers = new ObservableCollection<Answer>();

		public string Question { get => _question; set => _question = value; }
		public int Point { get => _point; set => _point = value; }
		public bool SwapAnswer { get => _swapAnswer; set => _swapAnswer = value; }
		public ObservableCollection<Answer> Answers { get => _answers; }
		public Answer RightAnswer { get => _rightAnswer; set => _rightAnswer = value; }

		public void AddAnswer() => _answers.Add(new Answer());
		public int GetResult() => throw new System.NotImplementedException();
	}
}
