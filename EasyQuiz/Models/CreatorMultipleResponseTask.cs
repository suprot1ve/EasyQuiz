namespace EasyQuiz.Models
{
	public class CreatorMultipleResponseTask : ICreatorTask
	{
		public ITestTask Create() => new MultipleResponseTask();
	}
}
