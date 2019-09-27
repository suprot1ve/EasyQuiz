namespace EasyQuiz.Models
{
	public class CreatorMatchingTask : ICreatorTask
	{
		public ITestTask Create() => new MatchingTask();
	}
}
