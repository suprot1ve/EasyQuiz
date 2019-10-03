namespace EasyQuiz.Models
{
	public class CreatorShortAnswerTask : ICreatorTask
	{
		public ITestTask CreateTask() => new ShortAnswerTask();
	}
}
