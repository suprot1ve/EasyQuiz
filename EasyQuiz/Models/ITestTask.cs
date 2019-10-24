namespace EasyQuiz.Models
{
	public interface ITestTask
	{
		string Question { get; set; }
		int Point { get; set; }

		void AddNewAnswer();

		void RemoveAnswer(Answer answer);
		int GetResult();
		void ShuffleAnswers();
		int GetMaxPointsPerTask();
	}
}