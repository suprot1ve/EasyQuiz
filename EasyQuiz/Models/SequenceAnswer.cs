namespace EasyQuiz.Models
{
	public class SequenceAnswer : Answer
	{
		private int _sequenceNumber = 1;

		public int SequenceNumber { get => _sequenceNumber; set => _sequenceNumber = value; }
	}
}
