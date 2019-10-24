namespace EasyQuiz.Models
{
	public class SequenceAnswer : Answer
	{
		private int _sequenceNumber = 1;
		private int _userSequenceNumber = 1;

		public int SequenceNumber { get => _sequenceNumber; set => _sequenceNumber = value; }
		public int UserSequenceNumber { get => _userSequenceNumber; set => _userSequenceNumber = value; }
	}
}
