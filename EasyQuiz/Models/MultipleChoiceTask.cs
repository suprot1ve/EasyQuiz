using System;
using System.Collections.ObjectModel;
using System.Linq;

using EasyQuiz.Infrastructure;

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

		public void AddNewAnswer() => _answers.Add(new Answer());

		public void RemoveAnswer(Answer answer) => _answers.Remove(answer);
		public int GetResult()
		{
			Answer userAnswer = (from ans in Answers where ans.UserChoice select ans).FirstOrDefault();
			return (userAnswer?.Value == RightAnswer?.Value) ? Point : 0;
		}

		public int GetMaxPointsPerTask() => Point;

		public void ShuffleAnswers()
		{
			if (SwapAnswer)
			{
				Random rng = new Random();
				rng.Shuffle(Answers);
			}
		}
	}
}
