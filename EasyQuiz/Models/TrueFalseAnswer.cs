namespace EasyQuiz.Models
{
	public class TrueFalseAnswer : Answer
	{
		private bool _isTrue;

		public bool IsTrue { get => _isTrue; set => _isTrue = value; }
	}
}
