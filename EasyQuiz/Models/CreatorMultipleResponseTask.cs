namespace EasyQuiz.Models
{
	public class CreatorMultipleResponseTask : ICreatorTask
	{
		public ITestTask CreateTask() => new MultipleResponseTask();
	}
}
