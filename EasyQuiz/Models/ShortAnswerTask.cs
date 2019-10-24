using System.Collections.ObjectModel;
using System.Linq;

namespace EasyQuiz.Models
{
	public class ShortAnswerTask : ITestTask
	{
		private string _question = "Введите вопрос...";
		private int _point = 1;
		private string _userAnswer;
		private ObservableCollection<Answer> _answers;

		public ShortAnswerTask() => _answers = new ObservableCollection<Answer>();

		public string Question { get => _question; set => _question = value; }
		public int Point { get => _point; set => _point = value; }
		public ObservableCollection<Answer> Answers { get => _answers; }
		public string UserAnswer { get => _userAnswer; set => _userAnswer = value; }

		public void AddNewAnswer() => _answers.Add(new Answer());
		public void RemoveAnswer(Answer answer) => _answers.Remove(answer);
		public int GetResult()
		{
			Answer userAnswer = (from ans in Answers where ans.Value.ToLower() == UserAnswer?.ToLower() select ans).FirstOrDefault();
			return (userAnswer != null) ? Point : 0;
		}

		public int GetMaxPointsPerTask() => Point;

		public void ShuffleAnswers()
		{
			return;
		}
	}
}
