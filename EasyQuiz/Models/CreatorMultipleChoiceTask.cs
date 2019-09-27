namespace EasyQuiz.Models
{
	public class CreatorMultipleChoiceTask : ICreatorTask
	{
		public ITestTask Create() => new MultipleChoiceTask();
	}
}
