namespace EasyQuiz.Models
{
	public class MultipleAnswer : Answer
	{
		private bool _isRight;

		public bool IsRight { get => _isRight; set => _isRight = value; }
	}
}
