using System;

using EasyQuiz.Infrastructure;
using EasyQuiz.Models;

namespace EasyQuiz.ViewModels
{
	class ResultWindowViewModel : ViewModelBase
	{
		private int _userScore;
		private Quiz _currentQuiz;
		private int _resultGradePoint;

		public ResultWindowViewModel(int userScore, Quiz quiz)
		{
			UserScore = userScore;
			CurrentQuiz = quiz;
			ResultGradePoint = CurrentQuiz.GetResultGradePoint(UserScore);

			CloseCommand = new Command(obj => CloseAction());
		}

		public int UserScore { get => _userScore; private set => _userScore = value; }
		public Quiz CurrentQuiz { get => _currentQuiz; private set => _currentQuiz = value; }
		public int ResultGradePoint { get => _resultGradePoint; set => _resultGradePoint = value; }

		public Command CloseCommand { get; set; }
		public Action CloseAction { get; set; }
	}
}
