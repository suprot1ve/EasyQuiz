namespace EasyQuiz.Models
{
	public class CreatorShortAnswerTask : ICreatorTask
	{
		public ITestTask Create() => new ShortAnswerTask();
	}
}
