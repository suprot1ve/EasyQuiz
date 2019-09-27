namespace EasyQuiz.Models
{
	public class MatchingAnswer : Answer
	{
		private string _matchingValue = "Ваш соотвествующий ответ...";

		public string MatchingValue { get => _matchingValue; set => _matchingValue = value; }
	}
}
