namespace EasyQuiz.Models
{
	public class Answer
	{
		private string _value = "Ваш ответ...";
		private bool _userChoice;

		public string Value { get => _value; set => _value = value; }
		public bool UserChoice { get => _userChoice; set => _userChoice = value; }
	}
}