namespace EasyQuiz.Models
{
	public class CreatorTrueFalseTask : ICreatorTask
	{
		public ITestTask CreateTask() => new TrueFalseTask();
	}
}
